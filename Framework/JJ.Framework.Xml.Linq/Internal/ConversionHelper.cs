using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Xml.Serialization;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.PlatformCompatibility;
using System.Xml.Linq;
using System.Xml;

namespace JJ.Framework.Xml.Linq.Internal
{
    internal static class ConversionHelper
    {
        /// <param name="cultureInfo">
        /// Nullable. When null, standard XML / SOAP formatting will be used.
        /// </param>
        public static object ParseValue(string input, Type type, CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                return ParseValueWithStandardXmlFormatting(input, type);
            }
            else
            {
                if (type.IsNullableType())
                {
                    if (String.IsNullOrEmpty(input))
                    {
                        return null;
                    }

                    type = type.GetUnderlyingNullableType();
                }

                if (type.IsEnum)
                {
                    return Enum.Parse(type, input);
                }

                if (type == typeof(TimeSpan))
                {
                    return TimeSpan.Parse(input);
                }

                if (type == typeof(Guid))
                {
                    return new Guid(input);
                }

                if (type == typeof(IntPtr))
                {
                    int number = Int32.Parse(input);
                    return new IntPtr(number);
                }

                if (type == typeof(UIntPtr))
                {
                    uint number = UInt32.Parse(input);
                    return new UIntPtr(number);
                }

                return Convert.ChangeType(input, type, cultureInfo);
            }
        }

        // TODO: Not sure how well XmlConvert is supported on different (mobile) platforms.

        private static Dictionary<Type, Func<string, object>> _xmlConvertFuncDictionary = new Dictionary<Type, Func<string, object>>
        {
            { typeof(Boolean),        x => XmlConvert.ToBoolean(x) },
            { typeof(Byte),           x => XmlConvert.ToByte(x) },
            { typeof(Char),           x => (char)Convert.ToInt32(x) }, // WCF expects chars to be numbers...
            { typeof(Decimal),        x => XmlConvert.ToDecimal(x) },
            { typeof(Double),         x => XmlConvert.ToDouble(x) },
            { typeof(Guid),           x => XmlConvert.ToGuid(x) },
            { typeof(Int16),          x => XmlConvert.ToInt16(x) },
            { typeof(Int32),          x => XmlConvert.ToInt32(x) },
            { typeof(Int64),          x => XmlConvert.ToInt64(x) },
            { typeof(SByte),          x => XmlConvert.ToSByte(x) },
            { typeof(Single),         x => XmlConvert.ToSingle(x) },
            { typeof(TimeSpan),       x => XmlConvert.ToTimeSpan(x) },
            { typeof(UInt16),         x => XmlConvert.ToUInt16(x) },
            { typeof(UInt32),         x => XmlConvert.ToUInt32(x) },
            { typeof(UInt64),         x => XmlConvert.ToUInt64(x) },
            { typeof(String),         x => x },

            // XML supports customization of the date time format, but here we only support the default format.
            { typeof(DateTime),       x => XmlConvert.ToDateTime(x, XmlDateTimeSerializationMode.Local) },
            { typeof(DateTimeOffset), x => XmlConvert.ToDateTimeOffset(x) }
        };

        private static object ParseValueWithStandardXmlFormatting(string input, Type type)
        {
            if (type.IsNullableType())
            {
                if (String.IsNullOrEmpty(input))
                {
                    return null;
                }

                type = type.GetUnderlyingNullableType();
            }

            if (type.IsEnum)
            {
                return Enum.Parse(type, input);
            }

            Func<string, object> func;
            if (_xmlConvertFuncDictionary.TryGetValue(type, out func))
            {
                return func(input);
            }

            throw new Exception(String.Format("Value '{0}' could not be converted to type '{1}' .", input, type.Name)); 
        }

        /// <param name="cultureInfo">
        /// Nullable. When null, standard XML / SOAP formatting will be used.
        /// </param>
        public static object FormatValue(object input, CultureInfo cultureInfo = null)
        {
            if (cultureInfo != null)
            {
                return Convert.ToString(input, cultureInfo);
            }

            if (input == null)
            {
                return null;
            }

            // System.Linq.Xml will not format char as an int, even though WCF expects it.
            if (input.GetType() == typeof(char))
            {
                return (int)(char)input;
            }

            // System.Linq.Xml will take care of other standard XML formatting.
            return input;
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
        public static NodeTypeEnum DetermineNodeType(PropertyInfo property)
        {
            // TODO: Performance penalty: a lot of stuff is done, even for each and every simple int.
            // Even things that do not need to be called (e.g. IsSupportedCollectionType).
            // The only reason everything is called might be to check for conflicting .NET attributes,
            // but at a large performance cost.
            // TODO: Simply cache things to get rid of this performance problem?

            bool hasXmlAttributeAttribute = property.GetCustomAttribute_PlatformSupport<XmlAttributeAttribute>() != null;
            bool hasXmlElementAttribute = property.GetCustomAttribute_PlatformSupport<XmlElementAttribute>() != null;
            bool hasXmlArrayAttribute = property.GetCustomAttribute_PlatformSupport<XmlArrayAttribute>() != null;
            bool hasXmlArrayItemAttribute = property.GetCustomAttribute_PlatformSupport<XmlArrayItemAttribute>() != null;
            bool isCollectionType = IsSupportedCollectionType(property.PropertyType);

            if (isCollectionType)
            {
                bool isValid = !hasXmlAttributeAttribute && !hasXmlElementAttribute;
                if (!isValid)
                {
                    throw new Exception(String.Format("Property '{0}' is an Array or is List<T>-assignable and therefore cannot be marked with XmlAttribute or XmlElement. Use XmlArray and XmlArrayItem instead.", property.Name));
                }
                return NodeTypeEnum.Array;
            }

            if (hasXmlAttributeAttribute)
            {
                bool isValid = !hasXmlElementAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
                if (!isValid)
                {
                    throw new Exception(String.Format("Property '{0}' is an XML attribute and therefore cannot be marked with XmlElement, XmlArray or XmlArrayItem.", property.Name));
                }
                return NodeTypeEnum.Attribute;
            }

            // If it is not an array or attribute, then it is an element by default.
            bool isValidElement = !hasXmlAttributeAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
            if (!isValidElement)
            {
                throw new Exception(String.Format("Property '{0}' is an XML element and therefore cannot be marked with XmlAttribute, XmlArray or XmlArrayItem.", property.Name));
            }
            return NodeTypeEnum.Element;
        }

        /// <summary>
        /// Returns whether the type should be handled as an XML Array.
        /// This means whether it is Array or List&lt;T&gt;-assignable.
        /// </summary>
        public static bool IsSupportedCollectionType(Type type)
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
        /// Returns wheter a generic collection type is supported.
        /// The supported types are List&lt;T&gt;, IList&lt;T&gt;, ICollection&lt;T&gt; and IEnumerable&lt;T&gt;.
        /// </summary>
        public static bool IsSupportedGenericCollectionType(Type type)
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

        /// <summary>
        /// Determines whether a type is considered a single value without any child data members. 
        /// This includes the primitive types (Boolean, Char, Byte, the numeric types and their signed and unsigned variations),
        /// and other types such as String, Guid, DateTime, TimeSpan and Enum types.
        /// </summary>
        public static bool IsLeafType(Type type)
        {
            if (type.IsPrimitive ||
                type.IsEnum ||
                type == typeof(string) ||
                type == typeof(Guid) ||
                type == typeof(DateTime) ||
                type == typeof(TimeSpan))
            {
                return true;
            }

            if (type.IsNullableType())
            {
                Type underlyingType = type.GetUnderlyingNullableType();
                return IsLeafType(underlyingType);
            }

            return false;
        }

        // Names

        public static string FormatCasing(string value, XmlCasingEnum casing)
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

        /// <summary>
        /// Gets the XML element name for a property.
        /// By default this is the property name converted to camel case 
        /// e.g. MyProperty -&gt; myProperty.
        /// You can also specify the expected XML element name explicity
        /// by marking the property with the XmlElement attribute and specifying the
        /// name with it e.g. [XmlElement("myElement")].
        /// </summary>
        public static string GetElementNameForProperty(PropertyInfo property, XmlCasingEnum casing)
        {
            // Try get element name from XmlElement attribute.
            string name = TryGetXmlElementNameFromAttribute(property);
            if (!String.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the property name converted to the expected casing (e.g. camel-case).
            name = ConversionHelper.FormatCasing(property.Name, casing);
            return name;
        }

        /// <summary>
        /// Tries to get an XML element name from the XmlElement attribute that the property is marked with,
        /// e.g. [XmlElement("myElement")]. If no name is specified there, returns null or empty string.
        /// </summary>
        private static string TryGetXmlElementNameFromAttribute(PropertyInfo property)
        {
            XmlElementAttribute xmlElementAttribute = property.GetCustomAttribute_PlatformSupport<XmlElementAttribute>();
            if (xmlElementAttribute != null)
            {
                return xmlElementAttribute.ElementName;
            }

            return null;
        }

        /// <summary>
        /// Gets the XML attribute name for a property.
        /// By default this is the property name converted to camel case 
        /// e.g. MyProperty -&gt; myProperty.
        /// You can also specify the expected XML element name explicity,
        /// by marking the property with the XmlAttribute attribute and specifying the
        /// name with it e.g. [XmlAttribute("myAttribute")].
        /// </summary>
        public static string GetAttributeNameForProperty(PropertyInfo property, XmlCasingEnum casing)
        {
            // Try get attribute name from XmlAttribute attribute.
            string name = TryGetAttributeNameFromAttribute(property);
            if (!String.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the property name converted to the expected casing (e.g. camel-case).
            name = ConversionHelper.FormatCasing(property.Name, casing);
            return name;
        }

        /// <summary>
        /// Get the XML attribute name from the XmlAttribute attribute that the property is marked with,
        /// e.g. [XmlAttribute("myAttribute")]. If no name is specified there, returns null or empty string.
        /// </summary>
        private static string TryGetAttributeNameFromAttribute(PropertyInfo property)
        {
            XmlAttributeAttribute xmlAttributeAttribute = property.GetCustomAttribute_PlatformSupport<XmlAttributeAttribute>();
            if (xmlAttributeAttribute != null)
            {
                return xmlAttributeAttribute.AttributeName;
            }

            return null;
        }

        /// <summary>
        /// Gets the Array XML element name for a collection property.
        /// By default this is the property name converted to camel case 
        /// e.g. MyCollection -&gt; myCollection.
        /// You can also specify the expected XML element name explicity,
        /// by marking the property with the XmlArray attribute and specifying the
        /// name with it e.g. [XmlArray("myCollection")].
        /// </summary>
        public static string GetXmlArrayNameForCollectionProperty(PropertyInfo collectionProperty, XmlCasingEnum casing)
        {
            // Try get element name from XmlArray attribute.
            string name = TryGetXmlArrayNameFromAttribute(collectionProperty);
            if (!String.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the property name converted to the expected casing (e.g. camel-case).
            name = ConversionHelper.FormatCasing(collectionProperty.Name, casing);
            return name;
        }

        /// <summary>
        /// Gets an Array XML element name from the XmlArray attribute that the property is marked with,
        /// e.g. [XmlArray("myArray")]. If no name is specified, null or empty string is returned.
        /// </summary>
        private static string TryGetXmlArrayNameFromAttribute(PropertyInfo collectionProperty)
        {
            XmlArrayAttribute xmlArrayAttribute = collectionProperty.GetCustomAttribute_PlatformSupport<XmlArrayAttribute>();
            if (xmlArrayAttribute != null)
            {
                return xmlArrayAttribute.ElementName;
            }

            return null;
        }

        /// <summary>
        /// Gets the XML element name for an array item for the given collection property.
        /// By default this is the collection property's item type name converted to camel case e.g. MyElementType -&gt; myElementType.
        /// You can also specify the expected XML element name explicity,
        /// by marking the collection property with the XmlArrayItem attribute and specifying the
        /// name with it e.g. [XmlArrayItem("myElementType")].
        /// </summary>
        public static string GetXmlArrayItemNameForCollectionProperty(PropertyInfo collectionProperty, XmlCasingEnum casing)
        {
            // Try get element name from XmlArrayItem attribute.
            string name = TryGetXmlArrayItemNameFromAttribute(collectionProperty);
            if (!String.IsNullOrEmpty(name))
            {
                return name;
            }

            // Otherwise the property type name converted to the expected casing (e.g. camel-case).
            Type itemType = collectionProperty.PropertyType.GetItemType();
            name = ConversionHelper.FormatCasing(itemType.Name, casing);
            return name;
        }

        /// <summary>
        /// Gets an XML element name from the XmlArrayItem attribute that the property is marked with.
        /// e.g. [XmlArrayItem("myItem")]. If no name is specified, null or empty string is returned.
        /// </summary>
        private static string TryGetXmlArrayItemNameFromAttribute(PropertyInfo collectionProperty)
        {
            XmlArrayItemAttribute xmlArrayItemAttribute = collectionProperty.GetCustomAttribute_PlatformSupport<XmlArrayItemAttribute>();
            if (xmlArrayItemAttribute != null)
            {
                return xmlArrayItemAttribute.ElementName;
            }

            return null;
        }
    }
}
