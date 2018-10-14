using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using JJ.Framework.Conversion;
using JJ.Framework.Reflection;
// ReSharper disable ConvertIfStatementToSwitchStatement
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace JJ.Framework.Xml.Linq.Internal
{
	internal static class ConversionHelper
	{
		/// <param name="formatProvider">
		/// Nullable. When null, standard XML / SOAP formatting will be used.
		/// </param>
		public static object ParseValue(string input, Type type, IFormatProvider formatProvider)
		{
			if (formatProvider == null)
			{
				return ParseValueWithStandardXmlFormatting(input, type);
			}
			else
			{
				return SimpleTypeConverter.ParseValue(input, type, formatProvider);
			}
		}

		// TODO: Not sure how well XmlConvert is supported on different (mobile) platforms.

		private static readonly Dictionary<Type, Func<string, object>> _xmlConvertFuncDictionary = new Dictionary<Type, Func<string, object>>
		{
			{ typeof(bool), x => XmlConvert.ToBoolean(x) },
			{ typeof(byte), x => XmlConvert.ToByte(x) },
			{ typeof(char), x => (char)Convert.ToInt32(x) }, // WCF expects chars to be numbers...
			{ typeof(decimal), x => XmlConvert.ToDecimal(x) },
			{ typeof(double), x => XmlConvert.ToDouble(x) },
			{ typeof(Guid), x => XmlConvert.ToGuid(x) },
			{ typeof(short), x => XmlConvert.ToInt16(x) },
			{ typeof(int), x => XmlConvert.ToInt32(x) },
			{ typeof(long), x => XmlConvert.ToInt64(x) },
			{ typeof(sbyte), x => XmlConvert.ToSByte(x) },
			{ typeof(float), x => XmlConvert.ToSingle(x) },
			{ typeof(TimeSpan), x => XmlConvert.ToTimeSpan(x) },
			{ typeof(ushort), x => XmlConvert.ToUInt16(x) },
			{ typeof(uint), x => XmlConvert.ToUInt32(x) },
			{ typeof(ulong), x => XmlConvert.ToUInt64(x) },
			{ typeof(string), x => x },

			// XML supports customization of the date time format, but here we only support the default format.
			{ typeof(DateTime), x => XmlConvert.ToDateTime(x, XmlDateTimeSerializationMode.Local) },
			{ typeof(DateTimeOffset), x => XmlConvert.ToDateTimeOffset(x) }
		};

		private static object ParseValueWithStandardXmlFormatting(string input, Type type)
		{
			if (type.IsNullableType())
			{
				if (string.IsNullOrEmpty(input))
				{
					return null;
				}

				type = type.GetUnderlyingNullableTypeFast();
			}

			if (type.IsEnum)
			{
				return Enum.Parse(type, input);
			}

			if (_xmlConvertFuncDictionary.TryGetValue(type, out Func<string, object> func))
			{
				return func(input);
			}

			throw new Exception($"Value '{input}' could not be converted to type '{type.Name}' ."); 
		}

		/// <param name="formatProvider">
		/// Nullable. When null, standard XML / SOAP formatting will be used.
		/// </param>
		public static object FormatValue(object input, IFormatProvider formatProvider = null)
		{
			if (formatProvider != null)
			{
				return Convert.ToString(input, formatProvider);
			}

			if (input == null)
			{
				return null;
			}

			// System.Linq.Xml will not format char as an int, even though WCF expects it.
			if (input is char c)
			{
				return (int)c;
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

			bool hasXmlAttributeAttribute = property.GetCustomAttribute<XmlAttributeAttribute>() != null;
			bool hasXmlElementAttribute = property.GetCustomAttribute<XmlElementAttribute>() != null;
			bool hasXmlArrayAttribute = property.GetCustomAttribute<XmlArrayAttribute>() != null;
			bool hasXmlArrayItemAttribute = property.GetCustomAttribute<XmlArrayItemAttribute>() != null;
			bool isCollectionType = IsSupportedCollectionType(property.PropertyType);

			if (isCollectionType)
			{
				bool isValid = !hasXmlAttributeAttribute && !hasXmlElementAttribute;
				if (!isValid)
				{
					throw new Exception($"Property '{property.Name}' is an Array or is List<T>-assignable and therefore cannot be marked with XmlAttribute or XmlElement. Use XmlArray and XmlArrayItem instead.");
				}
				return NodeTypeEnum.Array;
			}

			if (hasXmlAttributeAttribute)
			{
				bool isValid = !hasXmlElementAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
				if (!isValid)
				{
					throw new Exception($"Property '{property.Name}' is an XML attribute and therefore cannot be marked with XmlElement, XmlArray or XmlArrayItem.");
				}
				return NodeTypeEnum.Attribute;
			}

			// If it is not an array or attribute, then it is an element by default.
			bool isValidElement = !hasXmlAttributeAttribute && !hasXmlArrayAttribute && !hasXmlArrayItemAttribute;
			if (!isValidElement)
			{
				throw new Exception($"Property '{property.Name}' is an XML element and therefore cannot be marked with XmlAttribute, XmlArray or XmlArrayItem.");
			}
			return NodeTypeEnum.Element;
		}

		/// <summary>
		/// Returns whether the type should be handled as an XML Array.
		/// This means whether it is Array or List&lt;T&gt;-assignable.
		/// </summary>
		private static bool IsSupportedCollectionType(Type type)
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
		/// Returns whether a generic collection type is supported.
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
	}
}
