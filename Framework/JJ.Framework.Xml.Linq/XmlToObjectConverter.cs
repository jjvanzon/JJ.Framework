﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using JJ.Framework.Common;
using JJ.Framework.Net45;
using JJ.Framework.Reflection;
using JJ.Framework.Xml.Linq.Internal;

namespace JJ.Framework.Xml.Linq
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
    /// You have to specify the child element name with the collection property using the XmlArrayItem attribute
    /// e.g. [XmlArrayItem("myArrayItem")], because this name cannot be derived from the property name itself.
    /// Do note that the XmlArray attribute itself is not required.
    /// The supported collection types are Array types, List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; and IEnumerable&lt;T&gt;.
    /// 
    /// By default the names in the XML are the camel-case version of the property names.
    /// To diverge from this standard, you can either pass the casing to the constructor 
    /// or specify the node name explicitly by using the following .NET attributes
    /// on the properties: XmlElement, XmlAttribute and XmlArray.
    /// 
    /// Reference types are always optional. Value types are optional only if they are nullable.
    /// Collection types are always optional. If the parent element is present, an empty collection will be assigned.
    /// If the parent element is missing from the XML, the collection will be null.
    /// 
    /// Recognized values are the .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr
    /// the numeric types, their the signed and unsigned variations and
    /// String, Guid, DateTime, TimeSpan and Enum types.
    /// 
    /// The composite types in the object structure must have parameterless constructors.
    /// </summary>
    public class XmlToObjectConverter<TDestObject>
        where TDestObject : new()
    {
        // This class does not work with XML namespaces (yet). 
        // It simply ignores them which may however have a performance penalty.

        private XmlCasingEnum _casing;

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
        /// You have to specify the child element name with the collection property using the XmlArrayItem attribute
        /// e.g. [XmlArrayItem("myArrayItem")], because this name cannot be derived from the property name itself.
        /// Do note that the XmlArray attribute itself is not required.
        /// The supported collection types are Array types, List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; and IEnumerable&lt;T&gt;.
        /// 
        /// By default the names in the XML are the camel-case version of the property names.
        /// To diverge from this standard, you can either pass the casing to the constructor 
        /// or specify the node name explicitly by using the following .NET attributes
        /// on the properties: XmlElement, XmlAttribute and XmlArray.
        /// 
        /// Reference types are always optional. Value types are optional only if they are nullable.
        /// Collection types are always optional. If the parent element is present, an empty collection will be assigned.
        /// If the parent element is missing from the XML, the collection will be null.
        /// 
        /// Recognized values are the .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr
        /// the numeric types, their the signed and unsigned variations and
        /// String, Guid, DateTime, TimeSpan and Enum types.
        /// 
        /// The composite types in the object structure must have parameterless constructors.
        /// </summary>
        public XmlToObjectConverter(XmlCasingEnum casing = XmlCasingEnum.CamelCase)
        {
            _casing = casing;
        }

        public TDestObject Convert(byte[] data)
        {
            string text = Encoding.UTF8.GetString(data);
            return Convert(text);
        }

        public TDestObject Convert(string text)
        {
            XDocument doc = XDocument.Parse(text);
            return Convert(doc);
        }

        public TDestObject Convert(XDocument document)
        {
            XElement rootElement = document.Root;
            return Convert(rootElement);
        }

        public TDestObject Convert(XElement sourceElement)
        {
            TDestObject destObject = new TDestObject();
            ConvertProperties(sourceElement, destObject);
            return destObject;
        }

        // TODO: Code smell: methods are too much dependent on a parent object.

        /// <summary>
        /// Goes through all the properties of the parent object, tries to look up
        /// the corresponding child nodes out of the parent node and reads out values from them
        /// to fill in the properties.
        /// </summary>
        private void ConvertProperties(XElement sourceParentElement, object destParentObject)
        {
            foreach (PropertyInfo destProperty in ReflectionCache.GetProperties(destParentObject.GetType()))
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
        private void ConvertProperty(XElement sourceParentElement, object destParentObject, PropertyInfo destChildProperty)
        {
            NodeTypeEnum nodeType = ConversionHelper.DetermineNodeType(destChildProperty);
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

        // XML Elements

        /// <summary>
        /// Gets a child element from the parent element and converts it to a property of an object.
        /// Recursive calls might be made. Nullability is checked.
        /// </summary>
        private void ConvertElementFromParent(XElement sourceParentElement, object destParentObject, PropertyInfo destChildProperty)
        {
            string sourceChildElementName = ConversionHelper.GetElementNameForProperty(destChildProperty, _casing);

            XElement sourceChildElement = XmlHelper.TryGetElement(sourceParentElement, sourceChildElementName);

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
                throw new Exception(String.Format("XML node '{0}' does not have the required child element '{1}'.", sourceParentElement.Name, sourceChildElementName));
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
        private void ConvertElement(XElement sourceElement, object destParentObject, PropertyInfo destProperty)
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
        private object ConvertElement(XElement sourceElement, Type destType)
        {
            object destValue;
            if (ConversionHelper.IsLeafType(destType))
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
        private object ConvertLeafElement(XElement sourceElement, Type destType)
        {
            string sourceValue = sourceElement.Value;
            object destValue = ConversionHelper.ParseValue(sourceValue, destType);
            return destValue;
        }

        /// <summary>
        /// Creates a new object and does a recursive call to ConvertProperties
        /// to convert each of the composite type's properties.
        /// sourceElement is not nullable.
        /// </summary>
        /// <param name="sourceElement">not nullable</param>
        private object ConvertCompositeElement(XElement sourceElement, Type destType)
        {
            // Create new object
            object destValue = Activator.CreateInstance(destType);

            // Recursive call to convert its properties.
            ConvertProperties(sourceElement, destValue);

            return destValue;
        }

        // XML Attributes

        /// <summary>
        /// Gets an attribute from the given element and converts it to a property of an object.
        /// 
        /// Nullability is checked.
        /// If it is a nullable type or a reference type, an XML attribute can be omitted or its value left blank.
        /// Otherwise, the omission of the attribute causes an exception.
        /// </summary>
        private void ConvertAttributeFromParent(XElement sourceParentElement, object destParentObject, PropertyInfo destProperty)
        {
            string sourceXmlAttributeName = ConversionHelper.GetAttributeNameForProperty(destProperty, _casing);
            XAttribute sourceXmlAttribute = XmlHelper.TryGetAttribute(sourceParentElement, sourceXmlAttributeName);

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
                throw new Exception(String.Format("XML node '{0}' does not specify the required attribute '{1}'.", sourceParentElement.Name, sourceXmlAttributeName));
            }

            destProperty.SetValue(destParentObject, destPropertyValue);
        }

        /// <summary>
        /// Converts an XML attribute to a value of a specific type.
        /// Will return null if the attribute does not exist or if its value is blank.
        /// </summary>
        /// <param name="sourceXmlAttribute">nullable</param>
        private object ConvertAttribute(XAttribute sourceXmlAttribute, Type destType)
        {
            if (sourceXmlAttribute == null)
            {
                return null;
            }

            string sourceAttributeValue = sourceXmlAttribute.Value;

            if (String.IsNullOrEmpty(sourceAttributeValue))
            {
                return null;
            }

            object destValue = ConversionHelper.ParseValue(sourceAttributeValue, destType);
            return destValue;
        }

        // XML Arrays

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
        private void ConvertXmlArrayFromParent(XElement sourceParentElement, object destParentObject, PropertyInfo destCollectionProperty)
        {
            XElement sourceArrayXmlElement = TryGetSourceArrayXmlElement(sourceParentElement, destCollectionProperty);
            if (sourceArrayXmlElement == null)
            {
                return;
            }

            IList<XElement> sourceXmlArrayItems = GetSourceXmlArrayItems(sourceArrayXmlElement, destCollectionProperty);
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
        private void ConvertXmlArrayItems(IList<XElement> sourceXmlArrayItems, object destParentObject, PropertyInfo destCollectionProperty)
        {
            Type destCollectionType = destCollectionProperty.PropertyType;

            bool isArray = destCollectionType.IsAssignableTo(typeof(Array));
            if (isArray)
            {
                IList destCollection = ConvertXmlArrayItemsToArray(sourceXmlArrayItems, destCollectionType);
                destCollectionProperty.SetValue(destParentObject, destCollection);
                return;
            }

            bool isSupportedGenericCollection = ConversionHelper.IsSupportedGenericCollectionType(destCollectionType);
            if (isSupportedGenericCollection)
            {
                IList destCollection = ConvertXmlArrayItemsToList(sourceXmlArrayItems, destCollectionType);
                destCollectionProperty.SetValue(destParentObject, destCollection);
                return;
            }

            throw new Exception(String.Format("Type '{0}' is not supported: it not an Array type or a generic collection type to which List<T> can be assigned.", destCollectionType.Name));
        }

        /// <summary>
        /// Converts XML array items to an instance of an Array type.
        ///
        /// The array items can be loose values or composite types.
        /// For composite types a new object will be created,
        /// and a recursive call to ConvertProperties is made to convert each property of the composite type.
        /// </summary>
        private IList ConvertXmlArrayItemsToArray(IList<XElement> sourceXmlArrayItems, Type destCollectionType)
        {
            int count = sourceXmlArrayItems.Count;

            Type destConcreteCollectionType = destCollectionType;
            IList destCollection = (IList)Activator.CreateInstance(destConcreteCollectionType, count);

            Type destItemType = destCollectionType.GetElementType();
            for (int i = 0; i < count; i++)
            {
                XElement sourceXmlArrayItem = sourceXmlArrayItems[i];

                // Recursive call
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
        private IList ConvertXmlArrayItemsToList(IList<XElement> sourceXmlArrayItems, Type destCollectionType)
        {
            int count = sourceXmlArrayItems.Count;

            // Determine concrete type.
            // For List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; and IEnumerable&lt;T&gt; it is List&ltT&gt.

            Type destItemType = destCollectionType.GetItemType();
            Type destConcreteCollectionType = typeof(List<>).MakeGenericType(destItemType);
            IList destCollection = (IList)Activator.CreateInstance(destConcreteCollectionType, count);

            foreach (XElement sourceXmlArrayItem in sourceXmlArrayItems)
            {
                // Recursive call
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
        private XElement TryGetSourceArrayXmlElement(XElement sourceParentElement, PropertyInfo destCollectionProperty)
        {
            string sourceArrayXmlElementName = ConversionHelper.GetXmlArrayNameForCollectionProperty(destCollectionProperty, _casing);
            XElement sourceArrayXmlElement = XmlHelper.TryGetElement(sourceParentElement, sourceArrayXmlElementName);
            return sourceArrayXmlElement;
        }

        /// <summary>
        /// Gets the array item XML elements from the given array XML element.
        /// destCollectionProperty is used to get the expected XML array item element name.
        /// destCollectionProperty must specify the XmlArrayItem attribute 
        /// to indicate what the name of the array item XML elements should be.
        /// </summary>
        /// <param name="destCollectionProperty">Is used to get the expected XML array item element name.</param>
        private IList<XElement> GetSourceXmlArrayItems(XElement sourceXmlArray, PropertyInfo destCollectionProperty)
        {
            string sourceXmlArrayItemName = ConversionHelper.GetXmlArrayItemNameForCollectionProperty(destCollectionProperty, _casing);
            IList<XElement> sourceXmlArrayItems = XmlHelper.GetElements(sourceXmlArray, sourceXmlArrayItemName);
            return sourceXmlArrayItems;
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
    }
}