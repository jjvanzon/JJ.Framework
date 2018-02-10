using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Xml;
using JJ.Framework.Exceptions;
using JJ.Framework.Xml;

namespace JJ.Framework.Configuration
{
	/// <summary>
	/// Reads out config sections. You have to program a mapping in the form of C# classes to strongly-typed read out the config section.
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
	public static class CustomConfigurationManager
	{
		private static readonly object _sectionDictionaryLock = new object();
		private static readonly Dictionary<string, object> _sectionDictionary = new Dictionary<string, object>();

		public static T GetSection<T>()
			where T : new()
		{
			Assembly assembly = typeof(T).Assembly;
			return GetSection<T>(assembly);
		}

		public static T TryGetSection<T>()
			where T : new()
		{
			Assembly assembly = typeof(T).Assembly;
			return TryGetSection<T>(assembly);
		}

		public static T GetSection<T>(Assembly assembly)
			where T : new()
		{
			if (assembly == null) throw new NullException(() => assembly);

			string sectionName = assembly.GetName().Name.ToLower();
			return GetSection<T>(sectionName);
		}

		public static T TryGetSection<T>(Assembly assembly)
			where T : new()
		{
			if (assembly == null) throw new NullException(() => assembly);

			string sectionName = assembly.GetName().Name.ToLower();
			return TryGetSection<T>(sectionName);
		}

		public static T GetSection<T>(string sectionName)
			where T : new()
		{
			var section = TryGetSection<T>(sectionName);

			bool sectionNotFound = Equals(section, default(T));
			if (sectionNotFound)
			{
				throw new Exception($"Configuration section '{sectionName}' not found.");
			}

			return section;
		}

		public static T TryGetSection<T>(string sectionName)
			where T : new()
		{
			lock (_sectionDictionaryLock)
			{
				if (!_sectionDictionary.TryGetValue(sectionName, out object section))
				{
					var sourceXmlElement = (XmlElement)ConfigurationManager.GetSection(sectionName);
					if (sourceXmlElement != null)
					{
						var converter = new XmlToObjectConverter<T>();
						section = converter.Convert(sourceXmlElement);
					}

					_sectionDictionary[sectionName] = section;
				}

				return (T)section;
			}
		}

		public static void RefreshSection(string sectionName)
		{
			lock (_sectionDictionary)
			{
				if (_sectionDictionary.ContainsKey(sectionName))
				{
					_sectionDictionary.Remove(sectionName);
				}
			}

			ConfigurationManager.RefreshSection(sectionName);
		}
	}
}
