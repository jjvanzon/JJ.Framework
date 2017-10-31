using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using JJ.Framework.Common;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;
using JJ.Framework.Exceptions;
using JJ.Framework.Mathematics;

namespace JJ.Framework.Xml.Linq.Internal
{
    internal class NameManager
    {
        private const string WCF_SOAP_NAMESPACE_START = "http://schemas.datacontract.org/2004/07/";

        private XmlCasingEnum _casing;
        private bool _mustGenerateNamespaces;

        private HashSet<string> _xmlNamespaceStrings = new HashSet<string>();
        
        /// <summary> 
        /// Nullable.
        /// These mappings define alternative element names for array items.
        /// It maps dot net types to these alternative XML array item names.
        /// This is a feature required for various SOAP implementations.
        /// The names will be put in an XML namespace that WCF expects:
        /// "http://schemas.microsoft.com/2003/10/Serialization/Arrays".
        /// If you need a different namespace, you must translate the namespace youself.
        /// </summary>
        private Dictionary<Type, string> _customArrayItemNameDictionary;

        public NameManager(
            XmlCasingEnum casing,
            bool mustGenerateNamespaces = false,
            bool mustAddNilNamespace = false,
            IEnumerable<CustomArrayItemNameMapping> customArrayItemNameMappings = null)
        {
            _casing = casing;
            _mustGenerateNamespaces = mustGenerateNamespaces;

            if (customArrayItemNameMappings != null)
            {
                _customArrayItemNameDictionary = customArrayItemNameMappings.ToDictionary(x => x.DotNetItemType, x => x.XmlArrayItemName);

                AddXmlNamespaceString(CustomArrayItemNameMapping.DEFAULT_XML_ARRAY_ITEM_NAMESPACE_STRING);
            }

            // Add extra nil namespace to the namespace resolver.
            if (mustAddNilNamespace)
            {
                AddXmlNamespaceString(NilHelper.NIL_XML_NAMESPACE_NAME);
            }
        }

        // XML Element Names

        /// <summary>
        /// Gets the XML element name for a property.
        /// You can specify the XML element name explicity
        /// by marking the property with the XmlElement attribute and specifying the
        /// name with it e.g. [XmlElement("myElement")].
        /// If no name is supplied there, 
        /// the name will be the property name converted to a certain casing
        /// e.g. MyProperty -&gt; myProperty.
        /// </summary>
        public XName GetElementXName(PropertyInfo property)
        {
            string name = GetElementName(property);
            XName xname = GetXNameWithConditionallyANamespace(name, property);
            return xname;
        }

        /// <summary>
        /// Gets the XML element name for a property.
        /// You can specify the XML element name explicity
        /// by marking the property with the XmlElement attribute and specifying the
        /// name with it e.g. [XmlElement("myElement")].
        /// If no name is supplied there, 
        /// the name will be the property name converted to a certain casing
        /// e.g. MyProperty -&gt; myProperty.
        /// </summary>
        public string GetElementName(PropertyInfo property)
        {
            // Try get element name from XmlElement attribute.
            string name = TryGetXmlElementNameFromAttribute(property);
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the property name converted to the expected casing (e.g. camel-case).
            name = FormatCasing(property.Name, _casing);
            return name;
        }

        /// <summary>
        /// Tries to get an XML element name from the XmlElement attribute that the property is marked with,
        /// e.g. [XmlElement("myElement")]. If no name is specified there, returns null or empty string.
        /// </summary>
        private string TryGetXmlElementNameFromAttribute(PropertyInfo property)
        {
            XmlElementAttribute xmlElementAttribute = property.GetCustomAttribute_PlatformSupport<XmlElementAttribute>();
            if (xmlElementAttribute != null)
            {
                return xmlElementAttribute.ElementName;
            }

            return null;
        }

        // XML Attribute Names

        /// <summary>
        /// Gets the XML attribute name for a property.
        /// You can specify the expected XML attribute name explicity,
        /// by marking the property with the XmlAttribute attribute and specifying the
        /// name with it e.g. [XmlAttribute("myAttribute")].
        /// If no name is specified there, the XML attribute name will bet 
        /// the property name converted to a certain casing 
        /// e.g. MyProperty -&gt; myProperty.
        /// </summary>
        public XName GetAttributeXName(PropertyInfo property)
        {
            string name = GetAttributeName(property);
            XName xname = GetXNameWithConditionallyANamespace(name, property);
            return xname;
        }

        /// <summary>
        /// Gets the XML attribute name for a property.
        /// You can specify the expected XML attribute name explicity,
        /// by marking the property with the XmlAttribute attribute and specifying the
        /// name with it e.g. [XmlAttribute("myAttribute")].
        /// If no name is specified there, the XML attribute name will bet 
        /// the property name converted to a certain casing 
        /// e.g. MyProperty -&gt; myProperty.
        /// </summary>
        public string GetAttributeName(PropertyInfo property)
        {
            // Try get attribute name from XmlAttribute attribute.
            string name = TryGetAttributeNameFromAttribute(property);
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the property name converted to the expected casing (e.g. camel-case).
            name = FormatCasing(property.Name, _casing);
            return name;
        }

        /// <summary>
        /// Get the XML attribute name from the XmlAttribute attribute that the property is marked with,
        /// e.g. [XmlAttribute("myAttribute")]. If no name is specified there, returns null or empty string.
        /// </summary>
        private string TryGetAttributeNameFromAttribute(PropertyInfo property)
        {
            XmlAttributeAttribute xmlAttributeAttribute = property.GetCustomAttribute_PlatformSupport<XmlAttributeAttribute>();
            if (xmlAttributeAttribute != null)
            {
                return xmlAttributeAttribute.AttributeName;
            }

            return null;
        }

        // XML Array Names

        /// <summary>
        /// Gets the Array XML name for a collection property.
        /// You can also specify the expected XML element name explicity,
        /// by marking the property with the XmlArray attribute and specifying the
        /// name with it e.g. [XmlArray("myCollection")].
        /// If no name is specified there the name will be 
        /// the property name converted to a certain casing 
        /// e.g. MyCollection -&gt; myCollection.
        /// </summary>
        public XName GetXmlArrayXName(PropertyInfo collectionProperty)
        {
            string name = GetXmlArrayName(collectionProperty);
            XName xname = GetXNameWithConditionallyANamespace(name, collectionProperty);
            return xname;
        }

        /// <summary>
        /// Gets the Array XML name for a collection property.
        /// You can also specify the expected XML element name explicity,
        /// by marking the property with the XmlArray attribute and specifying the
        /// name with it e.g. [XmlArray("myCollection")].
        /// If no name is specified there the name will be 
        /// the property name converted to a certain casing 
        /// e.g. MyCollection -&gt; myCollection.
        /// </summary>
        public string GetXmlArrayName(PropertyInfo collectionProperty)
        {
            // Try get element name from XmlArray attribute.
            string name = TryGetXmlArrayNameFromAttribute(collectionProperty);
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the property name converted to the expected casing (e.g. camel-case).
            name = FormatCasing(collectionProperty.Name, _casing);
            return name;
        }

        /// <summary>
        /// Gets an Array XML element name from the XmlArray attribute that the property is marked with,
        /// e.g. [XmlArray("myArray")]. If no name is specified, null or empty string is returned.
        /// </summary>
        private string TryGetXmlArrayNameFromAttribute(PropertyInfo collectionProperty)
        {
            XmlArrayAttribute xmlArrayAttribute = collectionProperty.GetCustomAttribute_PlatformSupport<XmlArrayAttribute>();
            if (xmlArrayAttribute != null)
            {
                return xmlArrayAttribute.ElementName;
            }

            return null;
        }

        // XML Array Item Names

        /// <summary>
        /// First tries getting the name from the custom XML array item name mappings.
        /// This is a feature required for various SOAP implementations.
        /// Then tries getting the XML element name from the given collection property.
        /// You can specify the XML element name by marking the collection property 
        /// with the XmlArrayItem attribute and specifying the
        /// name with it e.g. [XmlArrayItem("myElementType")].
        /// If neither of those things specify the name, 
        /// the last resort is to return the collection property's item type name 
        /// converted to a certain casing e.g. MyElementType -&gt; myElementType.
        /// </summary>
        public XName GetXmlArrayItemXName(Type sourceItemType, PropertyInfo collectionProperty)
        {
            // First try getting the name from the custom XML array item name mappings.
            // This is a feature required for various SOAP implementations.
            string name = TryGetCustomArrayItemName(sourceItemType);
            if (!string.IsNullOrEmpty(name))
            {
                XNamespace xmlArrayItemXNamespace = CustomArrayItemNameMapping.DEFAULT_XML_ARRAY_ITEM_NAMESPACE_STRING;
                return xmlArrayItemXNamespace + name;
            }

            // Then try get element name from XmlArrayItem attribute.
            // Otherwise the property type name converted to the expected casing (e.g. camel-case).
            name = GetXmlArayItemNameFromCollectionProperty(collectionProperty);
            XName xname = GetXNameWithConditionallyANamespace(name, sourceItemType);
            return xname;
        }

        /// <summary>
        /// First tries getting the name from the custom XML array item name mappings.
        /// This is a feature required for various SOAP implementations.
        /// Then tries getting the XML element name from the given collection property.
        /// You can specify the XML element name by marking the collection property 
        /// with the XmlArrayItem attribute and specifying the
        /// name with it e.g. [XmlArrayItem("myElementType")].
        /// If neither of those things specify the name, 
        /// the last resort is to return the collection property's item type name 
        /// converted to a certain casing e.g. MyElementType -&gt; myElementType.
        /// </summary>
        public string GetXmlArrayItemName(Type sourceItemType, PropertyInfo collectionProperty)
        {
            // First try getting the name from the custom XML array item name mappings.
            // This is a feature required for various SOAP implementations.
            string name = TryGetCustomArrayItemName(sourceItemType);
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            // Then try get element name from XmlArrayItem attribute.
            // Otherwise the property type name converted to the expected casing (e.g. camel-case).
            return GetXmlArayItemNameFromCollectionProperty(collectionProperty);
        }

        private string GetXmlArayItemNameFromCollectionProperty(PropertyInfo collectionProperty)
        {
            // Then try get element name from XmlArrayItem attribute.
            string name = TryGetXmlArrayItemNameFromAttribute(collectionProperty);
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the property type name converted to the expected casing (e.g. camel-case).
            Type itemType = collectionProperty.GetItemType();
            name = FormatCasing(itemType.Name, _casing);
            return name;
        }

        /// <summary>
        /// Gets an XML element name from the XmlArrayItem attribute that the property is marked with.
        /// e.g. [XmlArrayItem("myItem")]. If no name is specified, null or empty string is returned.
        /// </summary>
        private string TryGetXmlArrayItemNameFromAttribute(PropertyInfo collectionProperty)
        {
            XmlArrayItemAttribute xmlArrayItemAttribute = collectionProperty.GetCustomAttribute_PlatformSupport<XmlArrayItemAttribute>();
            if (xmlArrayItemAttribute != null)
            {
                return xmlArrayItemAttribute.ElementName;
            }

            return null;
        }

        private XName TryGetCustomArrayItemXName(Type sourceItemType)
        {
            string name = TryGetCustomArrayItemName(sourceItemType);
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            XNamespace arrayNamespace = CustomArrayItemNameMapping.DEFAULT_XML_ARRAY_ITEM_NAMESPACE_STRING;
            return arrayNamespace + name;
        }

        private string TryGetCustomArrayItemName(Type sourceItemType)
        {
            if (_customArrayItemNameDictionary == null)
            {
                return null;
            }

            string name;
            if (_customArrayItemNameDictionary.TryGetValue(sourceItemType, out name))
            {
                return name;
            }

            return null;
        }

        // XML Namespaces

        /// <summary>
        /// Adds an extra XML namespace on top of the ones generated on-the-fly.
        /// </summary>
        public void AddXmlNamespaceString(string xmlNamespaceString)
        {
            if (!_xmlNamespaceStrings.Contains(xmlNamespaceString))
            {
                _xmlNamespaceStrings.Add(xmlNamespaceString);
            }
        }

        /// <summary>
        /// As names are retrieved from the NameManager,
        /// XML namespace names are generated and gathered up.
        /// At the end of the process, 
        /// you can get XML namespace declaration attributes
        /// gathered up.
        /// </summary>
        public IEnumerable<XAttribute> GetNamespaceDeclarationAttributes()
        {
            int i = 0;

            foreach (string xmlNamespaceString in _xmlNamespaceStrings)
            {
                string namespacePrefix = NumberingSystems.ToLetterSequence(i, 'a', 'z');

                yield return new XAttribute(XNamespace.Xmlns + namespacePrefix, xmlNamespaceString);

                i++;
            }
        }

        /// <summary>
        /// Will conditionally generate a namespace.
        /// </summary>
        private XName GetXNameWithConditionallyANamespace(string name, PropertyInfo property)
        {
            if (_mustGenerateNamespaces)
            {
                return GetXNameForNamespace(name, property.DeclaringType.Namespace);
            }
            else
            {
                return name;
            }
        }

        /// <summary>
        /// Will conditionally generate a namespace.
        /// For properties the type must be the type that the property is part of, not the type of the property value.
        /// </summary>
        private XName GetXNameWithConditionallyANamespace(string name, Type type)
        {
            if (_mustGenerateNamespaces)
            {
                return GetXNameForNamespace(name, type.Namespace);
            }
            else
            {
                return name;
            }
        }

        /// <param name="type">
        /// For properties the type must be the type that the property is part of, not the type of the property value.
        /// </param>
        public XName GetXNameForNamespace(string name, string dotNetNamespace)
        {
            string xmlNamespaceString = WCF_SOAP_NAMESPACE_START + dotNetNamespace;

            // System.Xml.Linq will ensure that the same namespace is the same XNamespace instance.
            XNamespace xnamespace = xmlNamespaceString;

            // Maintain a list of used namespaces so that the GetNamespaceDeclarationAttributes can work.
            if (!_xmlNamespaceStrings.Contains(xmlNamespaceString))
            {
                _xmlNamespaceStrings.Add(xmlNamespaceString);
            }

            return xnamespace + name;
        }

        // Helpers

        private string FormatCasing(string value, XmlCasingEnum casing)
        {
            switch (casing)
            {
                case XmlCasingEnum.UnmodifiedCase:
                    return value;

                case XmlCasingEnum.CamelCase:
                    return value.StartWithLowerCase();

                default:
                    throw new ValueNotSupportedException(casing);
            }
        }
    }
}
