using JJ.Framework.Common;
using JJ.Framework.IO;
using JJ.Framework.Reflection;
using JJ.Framework.Xml.Linq.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace JJ.Framework.Xml.Linq
{
    /// <summary>
    /// Under certain platforms standard XML serialization may not be available 
    /// or may not be the best option. That is why this class exists.
    /// </summary>
    public class ObjectToXmlConverter
    {
        private string _rootElementName;
        private XmlCasingEnum _casing;
        private bool _useNamespaces;
        private string _firstNamespacePrefix;
        private NamespaceResolver _namespaceResolver;

        /// <summary>
        /// Under certain platforms standard XML serialization may not be available 
        /// or may not be the best option. That is why this class exists.
        /// </summary>
        /// <param name="useNamespaces">
        /// If set to true, ObjectToXmlConverter will generate an XML namespace for each .NET namespace,
        /// in a way that conforms to WCF.
        /// The XML namespace will have the format "http://schemas.datacontract.org/2004/07/" followed by the .NET namespace.
        /// The namespace prefixes will be 'alphabetically numbered', starting with 'a', then 'b' and so on.
        /// </param>
        /// <param name="firstNamespacePrefix">
        /// When you set useNamespaces to true, this parameters specifies which is the first namespace prefix to use.
        /// E.g. if you set firstNamespacePrefix to be "c", then you can use the namespace prefixes "a" and "b" for your own purposes.
        /// </param>
        public ObjectToXmlConverter(XmlCasingEnum casing = XmlCasingEnum.CamelCase, bool useNamespaces = false, string firstNamespacePrefix = "a", string rootElementName = "root")
        {
            if (rootElementName == null) throw new ArgumentNullException("rootElementName");

            _casing = casing;
            _useNamespaces = useNamespaces;
            _firstNamespacePrefix = firstNamespacePrefix;
            _rootElementName = rootElementName;

            _namespaceResolver = new NamespaceResolver();
        }

        public byte[] ConvertToBytes(object sourceObject)
        {
            string text = ConvertToString(sourceObject);
            byte[] destBytes = StreamHelper.StringToBytes(text, Encoding.UTF8);
            return destBytes;
        }

        /// <summary>
        /// UTF-8 encoding is assumed.
        /// </summary>
        public Stream ConvertToStream(object sourceObject)
        {
            string text = ConvertToString(sourceObject);
            Stream stream = StreamHelper.StringToStream(text, Encoding.UTF8);
            return stream;
        }

        public string ConvertToString(object sourceObject)
        {
            if (sourceObject == null) throw new ArgumentNullException("sourceObject");

            XElement destRootElement = ConvertObjectToXElement(sourceObject);

            string destString = destRootElement.ToString();
            return destString;
        }

        public XElement ConvertObjectToXElement(object sourceObject)
        {
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
            XElement rootElement = new XElement(_rootElementName);

            if (_useNamespaces)
            {
                foreach (XAttribute namespaceDeclarationAttribute in _namespaceResolver.GetNamespaceDeclarationAttributes(_firstNamespacePrefix))
                {
                    rootElement.Add(namespaceDeclarationAttribute);
                }
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
            foreach (PropertyInfo sourceProperty in ReflectionCache.GetProperties(sourceObject.GetType()))
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
        /// </summary>
        private XElement TryConvertToElement(object sourceParentObject, PropertyInfo sourceProperty)
        {
            object sourceObject = sourceProperty.GetGetMethod().Invoke(sourceParentObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.

            if (sourceObject == null)
            {
                return null;
            }

            string destName = ConversionHelper.GetElementNameForProperty(sourceProperty, _casing);
            XName destXName = GetXName(destName, sourceProperty);

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
            if (ConversionHelper.IsLeafType(sourceType))
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
            var destElement = new XElement(destXName, sourceValue);
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
            object sourceValue = sourceProperty.GetGetMethod().Invoke(sourceObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.

            if (sourceValue == null)
            {
                return null;
            }

            string destName = ConversionHelper.GetAttributeNameForProperty(sourceProperty, _casing);
            XName destXName = GetXName(destName, sourceProperty);
            var destAttribute = new XAttribute(destXName, sourceValue);
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
            object sourceCollectionObject = sourceCollectionProperty.GetGetMethod().Invoke(sourceParentObject, null); // iOS compatibility: PropertyInfo.GetValue in mono on a generic type may cause JIT compilation, which is not supported by iOS.
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
                throw new Exception(String.Format("Collection of type '{0}' does not implement IList.", sourceCollectionProperty.PropertyType));
            }

            IList sourceCollection = (IList)sourceCollectionObject;

            string destName = ConversionHelper.GetXmlArrayNameForCollectionProperty(sourceCollectionProperty, _casing);
            XName destXName = GetXName(destName, sourceCollectionProperty);

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
            string destName = ConversionHelper.GetXmlArrayItemNameForCollectionProperty(sourceCollectionProperty);
            // For collection items, it is the .NET namespace of the item type that determines the XML namespace of the XML element.
            XName destXName = GetXName(destName, sourceItemType);

            // Recursive call
            XElement destXmlArrayItem = ConvertToElement(sourceItem, destXName);
            return destXmlArrayItem;
        }

        // Helpers

        /// <summary>
        /// Will conditionally generate a namespace.
        /// </summary>
        public XName GetXName(string name, PropertyInfo property)
        {
            if (_useNamespaces)
            {
                return _namespaceResolver.GetXName(name, property);
            }
            else
            {
                return name;
            }
        }

        /// <summary>
        /// Will conditionally generate a namespace.
        /// </summary>
        private XName GetXName(string name, Type type)
        {
            if (_useNamespaces)
            {
                return _namespaceResolver.GetXName(name, type);
            }
            else
            {
                return name;
            }
        }
    }
}