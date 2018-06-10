using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.IO;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;
using JJ.Framework.Xml.Linq.Internal;

namespace JJ.Framework.Xml.Linq
{
	/// <summary>
	/// Under certain platforms standard XML serialization may not be available 
	/// or may not be the best option. That is why this class exists.
	/// </summary>
	[PublicAPI]
	public class ObjectToXmlConverter
	{
		private readonly ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

		private string _rootElementName;
		private bool _mustGenerateNilAttributes;
		private bool _mustSortElementsByName;

		private NameManager _nameManager;

		/// <summary>
		/// If null, standard XML / SOAP formatting of values is applied.
		/// When filled in, values will be formatted in accordance with the provided culture.
		/// </summary>
		private CultureInfo _cultureInfo;
		
		/// <summary>
		/// Under certain platforms standard XML serialization may not be available 
		/// or may not be the best option. That is why this class exists.
		/// Limitation: only formats values in a standard XML way, 
		/// which may not be suitable in all situations.
		/// </summary>
		/// <param name="mustGenerateNamespaces">
		/// If set to true, ObjectToXmlConverter will generate an XML namespace for each .NET namespace,
		/// in a way that conforms to WCF.
		/// The XML namespace will have the format "http://schemas.datacontract.org/2004/07/" followed by the .NET namespace.
		/// The namespace prefixes will be 'alphabetically numbered' spread-sheet style, but in lower case
		/// starting with 'a', then 'b' and so on.
		/// If you need different namespaces, you must translate the namespace yourself.
		/// </param>
		/// <param name="mustGenerateNilAttributes">
		/// If set to false, properties that hold no object or value
		/// will not get an XML element.
		/// If set to true, properties that hold no object or value
		/// will be included with an XML attribute nil="true".
		/// This wil also include an extra namespace that defines the nil attribute:
		/// "http://www.w3.org/2001/XMLSchema-instance".
		/// </param>
		/// <param name="mustSortElementsByName">
		/// WCF will only accept messages in which the composite parameter's members
		/// are ordered by name. Ordinal string ordering is used.
		/// </param>
		/// <param name="cultureInfo">
		/// If null, standard XML / SOAP formatting of values is applied.
		/// When filled in, values will be formatted in accordance with the provided culture.
		/// </param>
		/// <param name="customArrayItemNameMappings">
		/// Nullable.
		/// These mappings define alternative element names for array items.
		/// It maps dot net types to these alternative XML array item names.
		/// This is a feature required for various SOAP implementations.
		/// The names will be put in an XML namespace that WCF expects:
		/// "http://schemas.microsoft.com/2003/10/Serialization/Arrays".
		/// If you need a different namespace, you must translate the namespace youself.
		/// </param>
		public ObjectToXmlConverter(
			XmlCasingEnum casing = XmlCasingEnum.CamelCase, 
			bool mustGenerateNamespaces = false, 
			bool mustGenerateNilAttributes = false,
			bool mustSortElementsByName = false,
			CultureInfo cultureInfo = null,
			string rootElementName = "root",
			IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = null)
		{
		    _rootElementName = rootElementName ?? throw new NullException(() => rootElementName);
			_mustGenerateNilAttributes = mustGenerateNilAttributes;
			_mustSortElementsByName = mustSortElementsByName;
			_cultureInfo = cultureInfo;

			_nameManager = new NameManager(casing, mustGenerateNamespaces, mustGenerateNilAttributes, customArrayItemNameMappings);
		}

		/// <summary> Bytes are UTF-8 encoded. </summary>
		public byte[] ConvertToBytes(object sourceObject)
		{
			string text = ConvertToString(sourceObject);
			byte[] destBytes = StreamHelper.StringToBytes(text, Encoding.UTF8);
			return destBytes;
		}

		/// <summary> Stream is UTF-8 encoded. </summary>
		public Stream ConvertToStream(object sourceObject)
		{
			string text = ConvertToString(sourceObject);
			Stream stream = StreamHelper.StringToStream(text, Encoding.UTF8);
			return stream;
		}

		public string ConvertToString(object sourceObject)
		{
			XElement destRootElement = ConvertObjectToXElement(sourceObject);

			string destString = destRootElement.ToString();
			return destString;
		}

		public XElement ConvertObjectToXElement(object sourceObject)
		{
			if (sourceObject == null) throw new NullException(() => sourceObject);

			if (sourceObject.GetType().IsSimpleType())
			{
				XElement destLeafElement = ConvertToLeafElement(sourceObject, _rootElementName);
				return destLeafElement;
			}

			IList<XObject> destObjects = ConvertProperties(sourceObject);

			// Make sure you create the root element last, because then all the generated XML namespaces will be included as xmlns attributes.
			XElement destRootElement = CreateRootElement();
			destRootElement.Add(destObjects);
			return destRootElement;

		}

		/// <summary>
		/// Creates a root element, that also declares the namespace prefixes.
		/// </summary>
		private XElement CreateRootElement()
		{
			var rootElement = new XElement(_rootElementName);

			foreach (XAttribute namespaceDeclarationAttribute in _nameManager.GetNamespaceDeclarationAttributes())
			{
				rootElement.Add(namespaceDeclarationAttribute);
			}

			return rootElement;
		}

		/// <summary>
		/// Loops through the properties of the object and calls
		/// another method to convert each property to XML.
		/// </summary>
		private IList<XObject> ConvertProperties(object sourceObject)
		{
			IList<XObject> destObjects = new List<XObject>();

			PropertyInfo[] sourceProperties = _reflectionCache.GetProperties(sourceObject.GetType());

			if (_mustSortElementsByName)
			{
				sourceProperties = sourceProperties.OrderBy(x => x.Name, StringComparer.Ordinal).ToArray();
			}

			foreach (PropertyInfo sourceProperty in sourceProperties)
			{
				XObject destObject = TryConvertProperty(sourceObject, sourceProperty);
				if (destObject != null)
				{
					destObjects.Add(destObject);
				}
			}

			return destObjects;
		}

		/// <summary>
		/// Converts a property of an object to XML.
		/// It might become an element that holds a value, a composite element, an attribute or an XML array.
		/// Null is returned if the source value is null.
		/// Except when _mustGenerateNilAttributes is true.
		/// </summary>
		private XObject TryConvertProperty(object sourceObject, PropertyInfo sourceProperty)
		{
			NodeTypeEnum nodeType = ConversionHelper.DetermineNodeType(sourceProperty);
			switch (nodeType)
			{
				case NodeTypeEnum.Element:
					XElement destElement = TryConvertToElement(sourceObject, sourceProperty);
					return destElement;

				case NodeTypeEnum.Attribute:
					XAttribute destAttribute = TryConvertToAttribute(sourceObject, sourceProperty);
					return destAttribute;

				case NodeTypeEnum.Array:
					XElement destXmlArray = TryConvertToXmlArray(sourceObject, sourceProperty);
					return destXmlArray;

				default:
					throw new InvalidValueException(nodeType);
			}
		}

		// Elements

		/// <summary>
		/// Converts a property of an object to either an XML element that holds a value or a composite element.
		/// Null is returned if the source value is null.
		/// Except when _mustGenerateNilAttributes is true.
		/// </summary>
		private XElement TryConvertToElement(object sourceParentObject, PropertyInfo sourceProperty)
		{
			object sourceObject = sourceProperty.GetValue_PlatformSafe(sourceParentObject);

			if (_mustGenerateNilAttributes)
			{
				return ConvertToElement_WithNillAttribute(sourceObject, sourceProperty);
			}

			if (sourceObject == null)
			{
				return null;
			}

			XName destXName = _nameManager.GetElementXName(sourceProperty);
			XElement destElement = ConvertToElement(sourceObject, destXName);
			return destElement;
		}

		private XElement ConvertToElement_WithNillAttribute(object sourceObject, PropertyInfo sourceProperty)
		{
			XName destXName = _nameManager.GetElementXName(sourceProperty);

			if (sourceObject == null)
			{
				XElement destNilElement = NilHelper.CreateNilElement(destXName);
				return destNilElement;
			}

			XElement destElement = ConvertToElement(sourceObject, destXName);
			return destElement;
		}


		/// <summary>
		/// Converts an object to an XML element with the provided name.
		/// It can either become an XML element that holds a value or a composite element.
		/// </summary>
		private XElement ConvertToElement(object sourceObject, XName destXName)
		{
			Type sourceType = sourceObject.GetType();
			if (sourceType.IsSimpleType())
			{
				XElement destElement = ConvertToLeafElement(sourceObject, destXName);
				return destElement;
			}
			else
			{
				XElement destElement = ConvertToCompositeElement(sourceObject, destXName);
				return destElement;
			}
		}

		/// <summary>
		/// Converts an object to an XML element with the provided name, that only holds a single value.
		/// </summary>
		private XElement ConvertToLeafElement(object sourceValue, XName destXName)
		{
			object destValue = ConversionHelper.FormatValue(sourceValue, _cultureInfo);
			var destElement = new XElement(destXName, destValue);
			return destElement;
		}

		/// <summary>
		/// Converts an object to a composite XML element with the provided name.
		/// </summary>
		private XElement ConvertToCompositeElement(object sourceObject, XName destXName)
		{
			var destElement = new XElement(destXName);
			IEnumerable<XObject> destChildElements = ConvertProperties(sourceObject);
			destElement.Add(destChildElements);
			return destElement;
		}

		// Attributes

		/// <summary>
		/// Converts a property of an object to an XML attribute.
		/// Null is returned if the source value is null.
		/// </summary>
		private XAttribute TryConvertToAttribute(object sourceObject, PropertyInfo sourceProperty)
		{
			object sourceValue = sourceProperty.GetValue_PlatformSafe(sourceObject);

			if (sourceValue == null)
			{
				return null;
			}

			XName destXName = _nameManager.GetAttributeXName(sourceProperty);
			object destValue = ConversionHelper.FormatValue(sourceValue, _cultureInfo);
			var destAttribute = new XAttribute(destXName, destValue);
			return destAttribute;
		}

		// XML Arrays

		/// <summary>
		/// Converts a property of an object to an XML array.
		/// An XML array contains one parent element that represents the whole array,
		/// and a child element for each element in the collection.
		/// The child elements can be simple values or composite types.
		/// The property should hold an object of a type that implements IList.
		/// </summary>
		private XElement TryConvertToXmlArray(object sourceParentObject, PropertyInfo sourceCollectionProperty)
		{
			object sourceCollectionObject = sourceCollectionProperty.GetValue_PlatformSafe(sourceParentObject);
			if (sourceCollectionObject == null)
			{
				return null;
			}

			// This type check might be redundant, because it could never happen that
			// the support collection type does not implement IList.
			// However, the code that makes sure this never happens is in a totally different place,
			// so a programming error is a possibility.
			if (!(sourceCollectionObject is IList))
			{
				throw new Exception($"Collection of type '{sourceCollectionProperty.PropertyType}' does not implement IList.");
			}

			var sourceCollection = (IList)sourceCollectionObject;

			XName destXName = _nameManager.GetXmlArrayXName(sourceCollectionProperty);

			var destXmlArray = new XElement(destXName);

			Type sourceItemType = sourceCollection.GetItemType();

			foreach (object sourceItem in sourceCollection)
			{
				XElement destXmlArrayItem = ConvertToXmlArrayItem(sourceItem, sourceItemType, sourceCollectionProperty);
				destXmlArray.Add(destXmlArrayItem);
			}

			return destXmlArray;
		}

		/// <summary>
		/// Converts an object to an XML array item. It is simply converted to an element,
		/// like any other elements, except that the name of the element is derived from the
		/// collection property and its .NET attributes.
		/// </summary>
		private XElement ConvertToXmlArrayItem(object sourceItem, Type sourceItemType, PropertyInfo sourceCollectionProperty)
		{
			XName destXName = _nameManager.GetXmlArrayItemXName(sourceItemType, sourceCollectionProperty);

			// Recursive call
			// TODO: Call TryConvertToElement to support empty array elements?
			XElement destXmlArrayItem = ConvertToElement(sourceItem, destXName);
			return destXmlArrayItem;
		}
	}
}