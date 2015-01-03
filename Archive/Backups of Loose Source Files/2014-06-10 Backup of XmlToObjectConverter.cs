using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Net45;
using JJ.Framework.Xml.Internal;
using System.Collections;

namespace JJ.Framework.Xml
{
    /// <summary>
    /// Converts an XML structure to an object tree.
    /// 
    /// By default properties are mapped to XML elements.
    /// 
    /// To map to XML attributes, mark a property with the XmlAttribute attribute.
    /// 
    /// If a property is an Array type, a parent XML element is expected,
    /// and a child element for each position in the array.
    /// That single Array property maps to both this parent element and the child elements.
    /// You have to specify the child element name with the Array property using the XmlArrayItem attribute
    /// e.g. [XmlArrayItem("myArrayItem")], because this name cannot be derived from the property name itself.
    /// Do note that the XmlArray attribute itself is not mandatory.
    /// 
    /// By default the names in the XML are the camel-case version of the property names.
    /// To diverge from this standard, you can specify the node name explicitly by using the following .NET attributes
    /// on the properties: XmlElement, XmlAttribute and XmlArray.
    /// 
    /// Reference types are always optional. Value types are optional only if they are nullable.
    /// 
    /// Recognized values are the .NET primitive types Boolean, Char, Byte, 
    /// the numeric types and the signed and unsigned variations,
    /// String, Guid, DateTime and TimeSpan. 
    /// 
    /// The composite types in the object structure must have parameterless constructors.
    /// </summary>
    public class XmlToObjectConverter<TDestObject>
        where TDestObject: new()
    {
        /// <summary>
        /// Converts an XML structure to an object tree.
        /// 
        /// By default properties are mapped to XML elements.
        /// 
        /// To map to XML attributes, mark a property with the XmlAttribute attribute.
        /// 
        /// If a property is an Array type, a parent XML element is expected,
        /// and a child element for each position in the array.
        /// That single Array property maps to both this parent element and the child elements.
        /// You have to specify the child element name with the Array property using the XmlArrayItem attribute
        /// e.g. [XmlArrayItem("myArrayItem")], because this name cannot be derived from the property name itself.
        /// Do note that the XmlArray attribute itself is not mandatory.
        /// 
        /// By default the names in the XML are the camel-case version of the property names.
        /// To diverge from this standard, you can specify the node name explicitly by using the following .NET attributes
        /// on the properties: XmlElement, XmlAttribute and XmlArray.
        /// 
        /// Reference types are always optional. Value types are optional only if they are nullable.
        /// 
        /// Recognized values are the .NET primitive types Boolean, Char, Byte, 
        /// the numeric types and the signed and unsigned variations,
        /// String, Guid, DateTime and TimeSpan. 
        /// 
        /// The composite types in the object structure must have parameterless constructors.
        /// </summary>
        public XmlToObjectConverter()
        { }

        // Only Array types are supported.

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
            XmlElement rootElement = document.DocumentElement;
            return Convert(rootElement);
        }

        public TDestObject Convert(XmlElement sourceElement)
        {
            TDestObject destObject = new TDestObject();
            ConvertProperties(sourceElement, destObject);
            return destObject;
        }

        /// <summary>
        /// Goes through all the properties of the destObject's type, tries to look up
        /// the corresponding child nodes out of the sourceParentNode and reads out values from them
        /// to fill in the property values.
        /// </summary>
        private void ConvertProperties(XmlElement sourceParentElement, object destObject)
        {
            foreach (PropertyInfo destProperty in ReflectionCache.GetProperties(destObject.GetType()))
            {
                ConvertProperty(sourceParentElement, destObject, destProperty);
            }
        }

        // TODO: Add more exaplanation in the summary after you added summaries to the more basic methods.

        /// <summary>
        /// Converts a child element of sourceObjectNode to a property of destObject.
        /// The child element is selected based on the property name.
        /// </summary>
        private void ConvertProperty(XmlElement sourceParentElement, object destParentObject, PropertyInfo destProperty)
        {
            NodeTypeEnum nodeType = GetNodeType(destProperty);
            switch (nodeType)
            {
                case NodeTypeEnum.Element:
                    ConvertElementFromParent(sourceParentElement, destParentObject, destProperty);
                    break;

                case NodeTypeEnum.Attribute:
                    ConvertAttribute(sourceParentElement, destParentObject, destProperty);
                    break;

                case NodeTypeEnum.Array:
                    ConvertXmlArray(sourceParentElement, destParentObject, destProperty);
                    break;

                default:
                    throw new InvalidValueException(nodeType);
            }
        }

        /// <summary>
        /// Examines the type and attributes of destProperty 
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
        /// If a property is an array type, it cannot also map to a property,
        /// or be marked with the XmlElement attribute.
        /// </summary>
        private NodeTypeEnum GetNodeType(PropertyInfo destProperty)
        {
            bool hasXmlAttributeAttribute = destProperty.GetCustomAttribute<XmlAttributeAttribute>() != null;
            bool hasXmlElementAttribute = destProperty.GetCustomAttribute<XmlElementAttribute>() != null;
            bool hasXmlArrayAttribute = destProperty.GetCustomAttribute<XmlArrayAttribute>() != null;
            bool hasXmlArrayItemAttribute = destProperty.GetCustomAttribute<XmlArrayItemAttribute>() != null;
            bool isCollectionType = IsCollectionType(destProperty.PropertyType);

            if (isCollectionType)
            {
                bool isValid = !hasXmlAttributeAttribute && !hasXmlElementAttribute;
                if (!isValid)
                {
                    throw new Exception(String.Format("Property '{0}' is an Array or IList<T> and therefore cannot be marked with XmlAttribute or XmlElement. Use XmlArray and XmlArrayItem instead.", destProperty.Name));
                }
                return NodeTypeEnum.Array;
            }
            
            else if (hasXmlAttributeAttribute)
            {
                bool isValid = !hasXmlElementAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
                if (!isValid)
                {
                    throw new Exception(String.Format("Property '{0}' is an XML attribute and therefore cannot be marked with XmlElement, XmlArray or XmlArrayItem.", destProperty.Name));
                }
                return NodeTypeEnum.Attribute;
            }

            else
            {
                // If it is not an array or attribute, then it is an element by default.
                bool isValidElement = !hasXmlAttributeAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
                if (!isValidElement)
                {
                    throw new Exception(String.Format("Property '{0}' is an XML element and therefore cannot be marked with XmlAttribute, XmlArray or XmlArrayItem.", destProperty.Name));
                }
                return NodeTypeEnum.Element;
            }
        }

        // XML Elements

        /// <summary>
        /// Gets a child element from the parent element and converts it to a property of an object.
        /// 
        /// For loose values this means a property's value is assigned.
        /// For composite types this means that a new object is created,
        /// and a recursive call to ConvertProperties is made to convert each property of the composite type.
        /// 
        /// Nullability is checked.
        /// An XML element can be omitted if it is a nullable type or a reference type.
        /// Otherwise, the omission of an element results in an exception.
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
                throw new Exception(String.Format("XML node '{0}' does not have the required child element '{1}'.", sourceParentElement.Name, sourceChildElementName));
            }
        }

        /// <summary>
        /// Gets the XML element name for a property.
        /// By default this is the property name converted to camel case 
        /// e.g. MyProperty -&gt; myProperty.
        /// You can also specify the expected XML element name explicity,
        /// by marking the property with the XmlElement attribute and specifying the
        /// name with it e.g. [XmlElement("myElement")].
        /// </summary>
        private string GetElementNameForProperty(PropertyInfo destProperty)
        {
            // Try get element name from XmlElement attribute.
            string name = TryGetXmlElementNameFromAttribute(destProperty);
            if (!String.IsNullOrEmpty(name))
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
            XmlElementAttribute xmlElementAttribute = destProperty.GetCustomAttribute<XmlElementAttribute>();
            if (xmlElementAttribute != null)
            {
                return xmlElementAttribute.ElementName;
            }

            return null;
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
            if (IsLeafType(destType))
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
        /// Converts the element's value to a specific destination type.
        /// sourceElement is not nullable.
        /// </summary>
        /// <param name="sourceElement">not nullable</param>
        private object ConvertLeafElement(XmlElement sourceElement, Type destType)
        {
            // Convert to a value.
            string sourceValue = sourceElement.Value;
            object destValue = ConversionHelper.ConvertValue(sourceValue, destType);
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

        // XML Attributes

        /// <summary>
        /// Gets an attribute from the given element and converts it to a property of an object.
        /// 
        /// Nullability is checked.
        /// If it is a nullable type or a reference type, an XML attribute can be omitted or its value left blank.
        /// Otherwise, the omission of the attribute results in an exception.
        /// </summary>
        private void ConvertAttribute(XmlElement sourceParentElement, object destParentObject, PropertyInfo destProperty)
        {
            string sourceAttributeName = GetAttributeNameForProperty(destProperty);

            string sourceAttributeValue = XmlHelper.TryGetAttributeValue(sourceParentElement, sourceAttributeName);

            // If attribute filled in, convert the attribute value.
            if (!String.IsNullOrEmpty(sourceAttributeValue))
            {
                Type destPropertyType = destProperty.PropertyType;
                object destPropertyValue = ConversionHelper.ConvertValue(sourceAttributeValue, destPropertyType);
                destProperty.SetValue(destParentObject, destPropertyValue);
                return;
            }

            // Check nullability
            if (String.IsNullOrEmpty(sourceAttributeValue))
            {
                Type type = destProperty.PropertyType;
                if (IsNullable(type))
                {
                    // If nullable and attribute is null or empty, leave property's default value in tact.
                    return;
                }

                // If not nullable and attribute is null or empty, throw an exception.
                throw new Exception(String.Format("XML node '{0}' does not specify the required attribute '{1}'.", sourceParentElement.Name, sourceAttributeName));
            }
        }

        /// <summary>
        /// Gets the XML attribute name for a property.
        /// By default this is the property name converted to camel case 
        /// e.g. MyProperty -&gt; myProperty.
        /// You can also specify the expected XML element name explicity,
        /// by marking the property with the XmlAttribute attribute and specifying the
        /// name with it it e.g. [XmlAttribute("myAttribute")].
        /// </summary>
        private string GetAttributeNameForProperty(PropertyInfo destProperty)
        {
            // Try get attribute name from XmlAttribute attribute.
            string name = TryGetAttributeNameFromAttribute(destProperty);
            if (!String.IsNullOrEmpty(name))
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
            XmlAttributeAttribute xmlAttributeAttribute = destProperty.GetCustomAttribute<XmlAttributeAttribute>();
            if (xmlAttributeAttribute != null)
            {
                return xmlAttributeAttribute.AttributeName;
            }

            return null;
        }

        // XML Arrays

        /// <summary>
        /// Returns whether the type should be handled as an XML Array.
        /// For now this means whether it is Array or IList&lt;T&gt;.
        /// </summary>
        private bool IsCollectionType(Type type)
        {
            // Allowing IEnumerable<> would make String be interpreted as an array type (and perhaps other types too).
            // So for now, stay on the safe side, and only support IList<T>.

            if (type.IsAssignableTo(typeof(Array)))
            {
                return true;
            }

            // TODO: Does <> work?
            if (type.IsAssignableTo(typeof(IList<>)))
            {
                return true;
            }

            // TODO: What about non-generic collection types?

            return false;
        }

        /// <summary>
        /// Converts an XML array: an XML element that represents the whole array with a child element for each position in the array.
        /// It is a converted to a collection property that is either an Array or an IList&lt;T&gt;.
        /// The assumption is made that destCollectionProperty is already of the right type: either Array or IList&lt;T&gt;
        ///
        /// The collection property is always nullable.
        /// 
        /// The collection items can be loose values or composite types.
        /// For composite types a new object will be created,
        /// and a recursive call to ConvertProperties is made to convert each property of the composite type.
        /// </summary>
        /// <param name="sourceParentElement">The parent of the XML Array element.</param>
        private void ConvertXmlArray(XmlElement sourceParentElement, object destParentObject, PropertyInfo destCollectionProperty)
        {
            XmlElement sourceArrayXmlElement = TryGetSourceArrayXmlElement(sourceParentElement, destCollectionProperty);
            if (sourceArrayXmlElement == null)
            {
                return;
            }

            IList<XmlElement> sourceXmlArrayItems = GetSourceXmlArrayItems(sourceArrayXmlElement, destCollectionProperty);

            // The assumption is made here that it is already of the right type: either Array or IList<T>
            Type destCollectionType = destCollectionProperty.PropertyType;
            Type destConcreteCollectionType = GetConcreteCollectionType(destCollectionType);
            IList destCollection = (IList)Activator.CreateInstance(destConcreteCollectionType, sourceXmlArrayItems.Count);
            destCollectionProperty.SetValue(destParentObject, destCollection);

            Type destItemType = destCollectionType.GetItemType();
            for (int i = 0; i < sourceXmlArrayItems.Count; i++)
            {
                XmlElement sourceXmlArrayItem = sourceXmlArrayItems[i];
                object destValue = ConvertElement(sourceXmlArrayItem, destItemType);
                destCollection[i] = destValue;
            }
        }

        /// <summary>
        /// Determine concrete type: for arrays the array type itself, the IList&lt;T&gt; it is List&ltT&gt.
        /// The assumption is made here that it is already of the right type: either Array or IList<T>
        /// </summary>
        private Type GetConcreteCollectionType(Type collectionType)
        {
            Type concreteCollectionType;
            bool isArray = collectionType.IsAssignableTo(typeof(Array));
            if (isArray)
            {
                concreteCollectionType = collectionType;
            }
            else
            {
                Type itemType = collectionType.GetItemType();
                concreteCollectionType = typeof(List<>).MakeGenericType(itemType);
            }

            return concreteCollectionType;
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
        /// name with it it e.g. [XmlArray("myCollection")].
        /// </summary>
        private XmlElement TryGetSourceArrayXmlElement(XmlElement sourceParentElement, PropertyInfo destCollectionProperty)
        {
            string sourceArrayXmlElementName = GetXmlArrayNameForCollectionProperty(destCollectionProperty);
            XmlElement sourceArrayXmlElement = XmlHelper.TryGetElement(sourceParentElement, sourceArrayXmlElementName);
            return sourceArrayXmlElement;
        }

        /// <summary>
        /// Gets the Array XML element name for a collection property.
        /// By default this is the property name converted to camel case 
        /// e.g. MyCollection -&gt; myCollection.
        /// You can also specify the expected XML element name explicity,
        /// by marking the property with the XmlArray attribute and specifying the
        /// name with it it e.g. [XmlArray("myCollection")].
        /// </summary>
        private string GetXmlArrayNameForCollectionProperty(PropertyInfo destCollectionProperty)
        {
            // Try get element name from XmlArray attribute.
            string name = TryGetXmlArrayNameFromAttribute(destCollectionProperty);
            if (!String.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the collection property name converted to camel-case.
            name = destCollectionProperty.Name.StartWithLowerCase();
            return name;
        }

        /// <summary>
        /// Gets an Array XML element name from the XmlArray attribute that the property is marked with,
        /// e.g. [XmlArray("myArray")]. If no name is specified, returns null or empty string.
        /// </summary>
        private string TryGetXmlArrayNameFromAttribute(PropertyInfo destCollectionProperty)
        {
            XmlArrayAttribute xmlArrayAttribute = destCollectionProperty.GetCustomAttribute<XmlArrayAttribute>();
            if (xmlArrayAttribute != null)
            {
                return xmlArrayAttribute.ElementName;
            }

            return null;
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
        /// Gets the XML element name for an array item for the given collection property.
        /// The XML array item name should always be specified in the XmlArrayItem attribute that the property is marked with.
        /// </summary>
        private string GetXmlArrayItemNameForCollectionProperty(PropertyInfo destCollectionProperty)
        {
            // The XML array item name should always be specified in the XmlArrayItem attribute that the property is marked with.
            return GetXmlArrayItemNameFromAttribute(destCollectionProperty);
        }

        /// <summary>
        /// Gets an XML element name from the XmlArrayItem attribute that the property is marked with.
        /// e.g. [XmlArrayItem("myItem")]. If no name is specified there an exception is thrown.
        /// </summary>
        private string GetXmlArrayItemNameFromAttribute(PropertyInfo destCollectionProperty)
        {
            XmlArrayItemAttribute xmlArrayItemAttribute = destCollectionProperty.GetCustomAttribute<XmlArrayItemAttribute>();
            if (xmlArrayItemAttribute != null)
            {
                if (!String.IsNullOrEmpty(xmlArrayItemAttribute.ElementName))
                {
                    return xmlArrayItemAttribute.ElementName;
                }
            }

            throw new Exception(String.Format(
                @"Property '{0}' is a collection type, but does specify the XML array item name. " + 
                @"Mark the property with an XmlArrayItem attribute, e.g. XmlArrayItem(""myItem"").", destCollectionProperty.Name));
        }

        // Helpers

        /// <summary>
        /// Returns whether the type is considered nullable in general.
        /// Concretely this currently means any reference type and any Nullable&lt;T&gt; 
        /// </summary>
        private bool IsNullable(Type type)
        {
            return type.IsReferenceType() || type.IsNullableType();
        }

        /// <summary>
        /// Determines whether a type is considered a single value without any child data members. 
        /// This includes the primitive types (Boolean, Char, Byte, the numeric types and their signed and unsigned variations),
        /// and other types such as String, Guid, DateTime and TimeSpan.
        /// </summary>
        private bool IsLeafType(Type type)
        {
            return type.IsPrimitive || 
                   type == typeof(string) || 
                   type == typeof(Guid) || 
                   type == typeof(DateTime) ||
                   type == typeof(TimeSpan);
        }
    }
}
