﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using JJ.Framework.Conversion;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.Reflection;
using JJ.Framework.Text;
using JJ.Framework.Xml.Internal;
// ReSharper disable StaticMemberInGenericType

namespace JJ.Framework.Xml
{
	/// <summary>
	/// Converts an XML structure to an object tree.
	/// 
	/// (Under certain platforms standard XML serialization may not be available 
	/// or may not be the best option. That is why this class exists.)
	/// 
	/// By default properties are mapped to XML elements.
	/// 
	/// To map to XML attributes, mark a property with the XmlAttribute attribute.
	/// 
	/// If a property is an Array type or a supported collection type, 
	/// a parent XML element is expected,
	/// and a child element for each position in the array.
	/// That single collection property maps to both this parent element and the child elements.
	/// The supported collection types are Array types, List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; and IEnumerable&lt;T&gt;.
	/// 
	/// By default the names in the XML are the camel-case version of the property names.
	/// For XML array items, however, it is not the property name, but the collection property's item type name converted to camel case.
	/// To diverge from this standard, you can specify the node name explicitly by using the following .NET attributes
	/// on the properties: XmlElement, XmlAttribute, XmlArray and XmlArrayItem.
	/// 
	/// Reference types are always optional. Value types are optional only if they are nullable.
	/// Collection types are always optional. If only the parent element is present, an empty collection will be assigned.
	/// If the parent element is missing from the XML, the collection will be null.
	/// 
	/// Recognized values are the .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr
	/// the numeric types, their signed and unsigned variations and
	/// String, Guid, DateTime, TimeSpan and Enum types.
	/// 
	/// The composite types in the object structure must have parameterless constructors.
	/// </summary>
	public class XmlToObjectConverter<TDestObject>
		where TDestObject: new()
	{
		private static readonly CultureInfo _formatProvider = new CultureInfo("en-US");
		private static readonly ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

		public TDestObject Convert(byte[] data)
		{
			string text = Encoding.UTF8.GetString(data);
			return Convert(text);
		}

		public TDestObject Convert(string text)
		{
			var doc = new XmlDocument();
			doc.LoadXml(text);
			return Convert(doc);
		}

		public TDestObject Convert(XmlDocument document)
		{
			if (document == null) throw new NullException(() => document);

			XmlElement rootElement = document.DocumentElement;
			return Convert(rootElement);
		}

		public TDestObject Convert(XmlElement sourceElement)
		{
			var destObject = new TDestObject();
			ConvertProperties(sourceElement, destObject);
			return destObject;
		}

		/// <summary>
		/// Goes through all the properties of the parent object, tries to look up
		/// the corresponding child nodes out of the parent node and reads out values from them
		/// to fill in the properties.
		/// </summary>
		private void ConvertProperties(XmlElement sourceParentElement, object destParentObject)
		{
			foreach (PropertyInfo destProperty in _reflectionCache.GetProperties(destParentObject.GetType()))
			{
				ConvertProperty(sourceParentElement, destParentObject, destProperty);
			}
		}

		/// <summary>
		/// Converts a child node of a parent element to a property of an object.
		/// A child node is selected based on the property name.
		/// First it is determined which type of node it is: an element, XML attribute or XML array.
		/// This is based on the property type and the .NET attributes that the property is annotated with.
		/// 
		/// If the property is a composite type, recursive calls are made to fill the rest of the structure.
		/// This also counts if an XML array has items of a composite type.
		/// </summary>
		private void ConvertProperty(XmlElement sourceParentElement, object destParentObject, PropertyInfo destChildProperty)
		{
			NodeTypeEnum nodeType = DetermineNodeType(destChildProperty);
			switch (nodeType)
			{
				case NodeTypeEnum.Element:
					ConvertElementFromParent(sourceParentElement, destParentObject, destChildProperty);
					break;

				case NodeTypeEnum.Attribute:
					ConvertAttributeFromParent(sourceParentElement, destParentObject, destChildProperty);
					break;

				case NodeTypeEnum.Array:
					ConvertXmlArrayFromParent(sourceParentElement, destParentObject, destChildProperty);
					break;

				default:
					throw new InvalidValueException(nodeType);
			}
		}

		/// <summary>
		/// Examines the type and attributes of property 
		/// to determine what type of XML node is expected for it 
		/// (element, attribute or array).
		/// Also verifies that a property is not marked with conflicting attributes.
		/// 
		/// By default a property maps to an element.
		/// You can optionally mark it with the XmlElement attribute to make that extra clear.
		/// 
		/// To map to an XML attribute, mark the property with the XmlAttribute attribute.
		/// 
		/// To map to an array, the property must be of an Array type,
		/// and the XML needs both a parent element that represents the array,
		/// and child elements that represent the array items.
		/// 
		/// If a property is an array type, it cannot be marked with the XmlAttribute or XmlElement attributes.
		/// </summary>
		private NodeTypeEnum DetermineNodeType(PropertyInfo destProperty)
		{
			// TODO: isCollectionType is always called, even if it is a simple int.
			// Actually, much is called even when it might not be needed and the only reason it is all called,
			// is to check for conflicting annotations, but it might harm performance considerably.

			bool hasXmlAttributeAttribute = destProperty.GetCustomAttribute<XmlAttributeAttribute>() != null;
			bool hasXmlElementAttribute = destProperty.GetCustomAttribute<XmlElementAttribute>() != null;
			bool hasXmlArrayAttribute = destProperty.GetCustomAttribute<XmlArrayAttribute>() != null;
			bool hasXmlArrayItemAttribute = destProperty.GetCustomAttribute<XmlArrayItemAttribute>() != null;
			bool isCollectionType = IsSupportedCollectionType(destProperty.PropertyType);

			if (isCollectionType)
			{
				bool isValid = !hasXmlAttributeAttribute && !hasXmlElementAttribute;
				if (!isValid)
				{
					throw new Exception($"Property '{destProperty.Name}' is an Array or is List<T>-assignable and therefore cannot be marked with XmlAttribute or XmlElement. Use XmlArray and XmlArrayItem instead.");
				}
				return NodeTypeEnum.Array;
			}
			
			if (hasXmlAttributeAttribute)
			{
				bool isValid = !hasXmlElementAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
				if (!isValid)
				{
					throw new Exception($"Property '{destProperty.Name}' is an XML attribute and therefore cannot be marked with XmlElement, XmlArray or XmlArrayItem.");
				}
				return NodeTypeEnum.Attribute;
			}

			// If it is not an array or attribute, then it is an element by default.
			// ReSharper disable once ConditionIsAlwaysTrueOrFalse
			bool isValidElement = !hasXmlAttributeAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
			if (!isValidElement)
			{
				throw new Exception($"Property '{destProperty.Name}' is an XML element and therefore cannot be marked with XmlAttribute, XmlArray or XmlArrayItem.");
			}
			return NodeTypeEnum.Element;
		}

		// XML Elements

		/// <summary>
		/// Gets a child element from the parent element and converts it to a property of an object.
		/// Recursive calls might be made. Nullability is checked.
		/// </summary>
		private void ConvertElementFromParent(XmlElement sourceParentElement, object destParentObject, PropertyInfo destChildProperty)
		{
			string sourceChildElementName = GetElementNameForProperty(destChildProperty);

			XmlElement sourceChildElement = XmlHelper.TryGetElement(sourceParentElement, sourceChildElementName);

			// If element not null, convert the element.
			if (sourceChildElement != null)
			{
				ConvertElement(sourceChildElement, destParentObject, destChildProperty);
			}

			// Check nullability
			if (sourceChildElement == null)
			{
				if (IsNullable(destChildProperty.PropertyType))
				{
					// If nullable and element is null, leave property's default value in tact.
					return;
				}

				// If not nullable and element is null, throw an exception.
				throw new Exception($"XML node '{sourceParentElement.Name}' does not have the required child element '{sourceChildElementName}'.");
			}
		}

		/// <summary>
		/// Converts an element to the object's property value.
		/// For values this means a property's value is assigned.
		/// For composite types this means that a new object is created,
		/// and a recursive call to ConvertProperties is made to convert each property of the composite type.
		/// sourceElement is not nullable.
		/// </summary>
		/// <param name="sourceElement">not nullable</param>
		private void ConvertElement(XmlElement sourceElement, object destParentObject, PropertyInfo destProperty)
		{
			Type destPropertyType = destProperty.PropertyType;
			object destPropertyValue = ConvertElement(sourceElement, destPropertyType);
			destProperty.SetValue(destParentObject, destPropertyValue);
		}

		/// <summary>
		/// Converts an element to a value or composite type.
		/// For loose values this means the text is converted to a specific type.
		/// For composite types this means that a new object is created,
		/// and a recursive call to ConvertProperties is made to convert each property of the composite type.
		/// sourceElement is not nullable.
		/// </summary>
		/// <param name="sourceElement">not nullable</param>
		private object ConvertElement(XmlElement sourceElement, Type destType)
		{
			object destValue;
			if (destType.IsSimpleType())
			{
				destValue = ConvertLeafElement(sourceElement, destType);
			}
			else
			{
				destValue = ConvertCompositeElement(sourceElement, destType);
			}
			return destValue;
		}

		/// <summary>
		/// Converts the element's value to a specific type.
		/// sourceElement is not nullable.
		/// </summary>
		/// <param name="sourceElement">not nullable</param>
		private object ConvertLeafElement(XmlElement sourceElement, Type destType)
		{
			string sourceValue = sourceElement.InnerText;
			object destValue = SimpleTypeConverter.ParseValue(sourceValue, destType, _formatProvider);
			return destValue;
		}

		/// <summary>
		/// Creates a new object and does a recursive call to ConvertProperties
		/// to convert each of the composite type's properties.
		/// sourceElement is not nullable.
		/// </summary>
		/// <param name="sourceElement">not nullable</param>
		private object ConvertCompositeElement(XmlElement sourceElement, Type destType)
		{
			// Create new object
			object destValue = Activator.CreateInstance(destType);

			// Recursive call to convert its properties.
			ConvertProperties(sourceElement, destValue);

			return destValue;
		}

		/// <summary>
		/// Gets the XML element name for a property.
		/// By default this is the property name converted to camel case 
		/// e.g. MyProperty -&gt; myProperty.
		/// You can also specify the expected XML element name explicity
		/// by marking the property with the XmlElement attribute and specifying the
		/// name with it e.g. [XmlElement("myElement")].
		/// </summary>
		private string GetElementNameForProperty(PropertyInfo destProperty)
		{
			// Try get element name from XmlElement attribute.
			string name = TryGetXmlElementNameFromAttribute(destProperty);
			if (!string.IsNullOrEmpty(name))
			{
				return name;
			}

			// Otherwise the property name converted to camel-case.
			name = destProperty.Name.StartWithLowerCase();
			return name;
		}

		/// <summary>
		/// Tries to get an XML element name from the XmlElement attribute that the property is marked with,
		/// e.g. [XmlElement("myElement")]. If no name is specified there, returns null or empty string.
		/// </summary>
		private string TryGetXmlElementNameFromAttribute(PropertyInfo destProperty)
		{
			var xmlElementAttribute = destProperty.GetCustomAttribute<XmlElementAttribute>();
			return xmlElementAttribute?.ElementName;
		}

		// XML Attributes

		/// <summary>
		/// Gets an attribute from the given element and converts it to a property of an object.
		/// 
		/// Nullability is checked.
		/// If it is a nullable type or a reference type, an XML attribute can be omitted or its value left blank.
		/// Otherwise, the omission of the attribute causes an exception.
		/// </summary>
		private void ConvertAttributeFromParent(XmlElement sourceParentElement, object destParentObject, PropertyInfo destProperty)
		{
			string sourceXmlAttributeName = GetAttributeNameForProperty(destProperty);
			XmlAttribute sourceXmlAttribute = XmlHelper.TryGetAttribute(sourceParentElement, sourceXmlAttributeName);

			Type destPropertyType = destProperty.PropertyType;
			object destPropertyValue = ConvertAttribute(sourceXmlAttribute, destProperty.PropertyType);

			// Check nullability
			if (destPropertyValue == null)
			{
				if (IsNullable(destPropertyType))
				{
					// If nullable and attribute is null or empty, leave property's default value in tact.
					return;
				}

				// If not nullable and attribute is null or empty, throw an exception.
				throw new Exception($"XML node '{sourceParentElement.Name}' does not specify the required attribute '{sourceXmlAttributeName}'.");
			}

			destProperty.SetValue(destParentObject, destPropertyValue);
		}

		/// <summary>
		/// Converts an XML attribute to a value of a specific type.
		/// Will return null if the attribute does not exist or if its value is blank.
		/// </summary>
		/// <param name="sourceXmlAttribute">nullable</param>
		private object ConvertAttribute(XmlAttribute sourceXmlAttribute, Type destType)
		{
			string sourceAttributeValue = sourceXmlAttribute?.Value;

			if (string.IsNullOrEmpty(sourceAttributeValue))
			{
				return null;
			}

			object destValue = SimpleTypeConverter.ParseValue(sourceAttributeValue, destType, _formatProvider);
			return destValue;
		}

		/// <summary>
		/// Gets the XML attribute name for a property.
		/// By default this is the property name converted to camel case 
		/// e.g. MyProperty -&gt; myProperty.
		/// You can also specify the expected XML element name explicity,
		/// by marking the property with the XmlAttribute attribute and specifying the
		/// name with it e.g. [XmlAttribute("myAttribute")].
		/// </summary>
		private string GetAttributeNameForProperty(PropertyInfo destProperty)
		{
			// Try get attribute name from XmlAttribute attribute.
			string name = TryGetAttributeNameFromAttribute(destProperty);
			if (!string.IsNullOrEmpty(name))
			{
				return name;
			}

			// Otherwise the property name converted to camel-case.
			name = destProperty.Name.StartWithLowerCase();
			return name;
		}

		/// <summary>
		/// Get the XML attribute name from the XmlAttribute attribute that the property is marked with,
		/// e.g. [XmlAttribute("myAttribute")]. If no name is specified there, returns null or empty string.
		/// </summary>
		private string TryGetAttributeNameFromAttribute(PropertyInfo destProperty)
		{
			var xmlAttributeAttribute = destProperty.GetCustomAttribute<XmlAttributeAttribute>();
			return xmlAttributeAttribute?.AttributeName;
		}

		// XML Arrays

		/// <summary>
		/// Returns whether the type should be handled as an XML Array.
		/// This means whether it is Array or List&lt;T&gt;-assignable.
		/// </summary>
		private bool IsSupportedCollectionType(Type type)
		{
			bool isArray = type.IsAssignableTo(typeof(Array));
			if (isArray)
			{
				return true;
			}

			bool isSupportedGenericCollection = IsSupportedGenericCollectionType(type);
			if (isSupportedGenericCollection)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Converts an XML array: an XML element that represents the whole array with a child element for each position in the array.
		/// It is a converted to a collection property that is an Array, List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; or IEnumerable&lt;T&gt;.
		///
		/// A collection property is always nullable.
		/// For an array a new array is assigned and to any of the other supported collection types a List&lt;T&gt; is assigned.
		/// 
		/// The collection items can be loose values or composite types.
		/// For composite types a new object will be created,
		/// and a recursive call to ConvertProperties is made to convert each property of the composite type.
		/// </summary>
		/// <param name="sourceParentElement">The parent of the XML Array element.</param>
		private void ConvertXmlArrayFromParent(XmlElement sourceParentElement, object destParentObject, PropertyInfo destCollectionProperty)
		{
			XmlElement sourceArrayXmlElement = TryGetSourceArrayXmlElement(sourceParentElement, destCollectionProperty);
			if (sourceArrayXmlElement == null)
			{
				return;
			}

			IList<XmlElement> sourceXmlArrayItems = GetSourceXmlArrayItems(sourceArrayXmlElement, destCollectionProperty);
			ConvertXmlArrayItems(sourceXmlArrayItems, destParentObject, destCollectionProperty);
		}

		/// <summary>
		/// Converts XML array items.
		/// They are converted to a collection property that is an Array, List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; or IEnumerable&lt;T&gt;.
		///
		/// The collection property is always nullable.
		/// For an array a new array is assigned and to any of the other supported collection types a List&lt;T&gt; is assigned.
		/// 
		/// The collection items can be loose values or composite types.
		/// For composite types a new object will be created,
		/// and a recursive call to ConvertProperties is made to convert each property of the composite type.
		/// </summary>
		private void ConvertXmlArrayItems(IList<XmlElement> sourceXmlArrayItems, object destParentObject, PropertyInfo destCollectionProperty)
		{
			Type destCollectionType = destCollectionProperty.PropertyType;

			bool isArray = destCollectionType.IsAssignableTo(typeof(Array));
			if (isArray)
			{
				IList destCollection = ConvertXmlArrayItemsToArray(sourceXmlArrayItems, destCollectionType);
				destCollectionProperty.SetValue(destParentObject, destCollection);
				return;
			}

			bool isSupportedGenericCollection = IsSupportedGenericCollectionType(destCollectionType);
			if (isSupportedGenericCollection)
			{
				IList destCollection = ConvertXmlArrayItemsToList(sourceXmlArrayItems, destCollectionType);
				destCollectionProperty.SetValue(destParentObject, destCollection);
				return;
			}

			throw new Exception($"Type '{destCollectionType.Name}' is not supported: it not an Array type or a generic collection type to which List<T> can be assigned.");
		}

		/// <summary>
		/// Converts XML array items to an instance of an Array type.
		///
		/// The array items can be loose values or composite types.
		/// For composite types a new object will be created,
		/// and a recursive call to ConvertProperties is made to convert each property of the composite type.
		/// </summary>
		private IList ConvertXmlArrayItemsToArray(IList<XmlElement> sourceXmlArrayItems, Type destCollectionType)
		{
			int count = sourceXmlArrayItems.Count;

			Type destConcreteCollectionType = destCollectionType;
			var destCollection = (IList)Activator.CreateInstance(destConcreteCollectionType, count);

			Type destItemType = destCollectionType.GetItemType();
			for (int i = 0; i < count; i++)
			{
				XmlElement sourceXmlArrayItem = sourceXmlArrayItems[i];
				object destValue = ConvertElement(sourceXmlArrayItem, destItemType);
				destCollection[i] = destValue;
			}

			return destCollection;
		}

		/// <summary>
		/// Converts XML array items to List&lt;T&gt;.
		///
		/// The collection items can be loose values or composite types.
		/// For composite types a new object will be created,
		/// and a recursive call to ConvertProperties is made to convert each property of the composite type.
		/// </summary>
		private IList ConvertXmlArrayItemsToList(IList<XmlElement> sourceXmlArrayItems, Type destCollectionType)
		{
			int count = sourceXmlArrayItems.Count;

			// Determine concrete type.
			// For List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; and IEnumerable&lt;T&gt; it is List&ltT&gt.

			Type destItemType = destCollectionType.GetItemType();
			Type destConcreteCollectionType = typeof(List<>).MakeGenericType(destItemType);
			var destCollection = (IList)Activator.CreateInstance(destConcreteCollectionType, count);

			foreach (XmlElement sourceXmlArrayItem in sourceXmlArrayItems)
			{
				object destValue = ConvertElement(sourceXmlArrayItem, destItemType);
				destCollection.Add(destValue);
			}

			return destCollection;
		}

		/// <summary>
		/// Tries to get an XML array from a parent XML element.
		/// An XML array is an XML element representing the whole array,
		/// with a child element for each position in the array.
		/// 
		/// destCollectionProperty is used to get the expected XML array element name.
		/// By default this is the property name converted to camel case 
		/// e.g. MyCollection -&gt; myCollection.
		/// You can also specify the expected XML element name explicity,
		/// by marking the property with the XmlArray attribute and specifying the
		/// name with it e.g. [XmlArray("myCollection")].
		/// </summary>
		private XmlElement TryGetSourceArrayXmlElement(XmlElement sourceParentElement, PropertyInfo destCollectionProperty)
		{
			string sourceArrayXmlElementName = GetXmlArrayNameForCollectionProperty(destCollectionProperty);
			XmlElement sourceArrayXmlElement = XmlHelper.TryGetElement(sourceParentElement, sourceArrayXmlElementName);
			return sourceArrayXmlElement;
		}
		
		/// <summary>
		/// Gets the array item XML elements from the given array XML element.
		/// destCollectionProperty is used to get the expected XML array item element name.
		/// destCollectionProperty must specify the XmlArrayItem attribute 
		/// to indicate what the name of the array item XML elements should be.
		/// </summary>
		/// <param name="destCollectionProperty">Is used to get the expected XML array item element name.</param>
		private IList<XmlElement> GetSourceXmlArrayItems(XmlElement sourceXmlArray, PropertyInfo destCollectionProperty)
		{
			string sourceXmlArrayItemName = GetXmlArrayItemNameForCollectionProperty(destCollectionProperty);
			IList<XmlElement> sourceXmlArrayItems = XmlHelper.GetElements(sourceXmlArray, sourceXmlArrayItemName);
			return sourceXmlArrayItems;
		}

		/// <summary>
		/// Gets the Array XML element name for a collection property.
		/// By default this is the property name converted to camel case 
		/// e.g. MyCollection -&gt; myCollection.
		/// You can also specify the expected XML element name explicity,
		/// by marking the property with the XmlArray attribute and specifying the
		/// name with it e.g. [XmlArray("myCollection")].
		/// </summary>
		private string GetXmlArrayNameForCollectionProperty(PropertyInfo destCollectionProperty)
		{
			// Try get element name from XmlArray attribute.
			string name = TryGetXmlArrayNameFromAttribute(destCollectionProperty);
			if (!string.IsNullOrEmpty(name))
			{
				return name;
			}

			// Otherwise the collection property name converted to camel-case.
			name = destCollectionProperty.Name.StartWithLowerCase();
			return name;
		}

		/// <summary>
		/// Gets an Array XML element name from the XmlArray attribute that the property is marked with,
		/// e.g. [XmlArray("myArray")]. If no name is specified, null or empty string is returned.
		/// </summary>
		private string TryGetXmlArrayNameFromAttribute(PropertyInfo destCollectionProperty)
		{
			var xmlArrayAttribute = destCollectionProperty.GetCustomAttribute<XmlArrayAttribute>();
			return xmlArrayAttribute?.ElementName;
		}

		/// <summary>
		/// Gets the XML element name for an array item for the given collection property.
		/// By default this is the collection property's item type name converted to camel case e.g. MyElementType -&gt; myElementType.
		/// You can also specify the expected XML element name explicity,
		/// by marking the collection property with the XmlArrayItem attribute and specifying the
		/// name with it e.g. [XmlArrayItem("myElementType")].
		/// </summary>
		private string GetXmlArrayItemNameForCollectionProperty(PropertyInfo collectionProperty)
		{
			// Try get element name from XmlArrayItem attribute.
			string name = TryGetXmlArrayItemNameFromAttribute(collectionProperty);
			if (!string.IsNullOrEmpty(name))
			{
				return name;
			}

			// Otherwise the property type name converted to the expected casing (e.g. camel-case).
			Type itemType = collectionProperty.PropertyType.GetItemType();
			name = itemType.Name.StartWithLowerCase();
			return name;
		}

		/// <summary>
		/// Gets an XML element name from the XmlArrayItem attribute that the property is marked with.
		/// e.g. [XmlArrayItem("myItem")]. If no name is specified, null or empty string is returned.
		/// </summary>
		private string TryGetXmlArrayItemNameFromAttribute(PropertyInfo collectionProperty)
		{
			var xmlArrayItemAttribute = collectionProperty.GetCustomAttribute<XmlArrayItemAttribute>();
			return xmlArrayItemAttribute?.ElementName;
		}

		// Helpers

		/// <summary>
		/// Returns whether the type is considered nullable in general.
		/// Concretely this means any reference type and any Nullable&lt;T&gt;.
		/// </summary>
		private bool IsNullable(Type type)
		{
			return type.IsReferenceType() || type.IsNullableType();
		}

		/// <summary>
		/// Returns wheter a generic collection type is supported.
		/// The supported types are List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; and IEnumerable&lt;T&gt;.
		/// </summary>
		private bool IsSupportedGenericCollectionType(Type type)
		{
			if (!type.IsGenericType)
			{
				return false;
			}

			Type openGenericType = type.GetGenericTypeDefinition();
			if (openGenericType == typeof(List<>)) return true;
			if (openGenericType == typeof(IList<>)) return true;
			if (openGenericType == typeof(IEnumerable<>)) return true;
			if (openGenericType == typeof(ICollection<>)) return true;
			return false;
		}
	}
}