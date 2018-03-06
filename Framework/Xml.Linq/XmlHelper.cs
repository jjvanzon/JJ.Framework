using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Xml.Linq
{
	public static class XmlHelper
	{
		// Elements

		/// <summary>
		/// Gets a child element with a given name.
		/// If the element is not unique or not found, an exception is thrown with a descriptive error message.
		/// </summary>
		public static XElement GetElement(XElement parentElement, string childElementName)
		{
			XElement childElement = TryGetElement(parentElement, childElementName);
			if (childElement == null)
			{
				throw new Exception($"Parent element '{parentElement.Name}' does not contain any element named '{childElementName}'.");
			}
			return childElement;
		}

		/// <summary>
		/// Tries to get a child element with a given name.
		/// Null is returned if the element is not found.
		/// If the element is not unique, an exception is thrown with a descriptive error message.
		/// </summary>
		public static XElement TryGetElement(XElement parentElement, string childElementName)
		{
			IList<XElement> childElements = GetElements(parentElement, childElementName);

			switch (childElements.Count)
			{
				case 0:
					return null;

				case 1:
					return childElements[0];

				default:
					throw new Exception($"Element '{childElementName}' was found multiple times inside '{parentElement.Name}'.");
			}
		}

		/// <summary>
		/// Gets the child elements with a given name.
		/// </summary>
		public static IList<XElement> GetElements(XElement parentElement, string childElementName)
		{
			if (parentElement == null) throw new NullException(() => parentElement);
			if (string.IsNullOrEmpty(childElementName)) throw new NullOrWhiteSpaceException(() => childElementName);

			// Ignore namespaces (might not be fast)
			//return parentElement.Elements(childElementName).ToArray();
			return parentElement.Elements().Where(x => x.Name.LocalName == childElementName).ToArray();
		}

		// Attributes

		/// <summary>
		/// Gets an attribute with a given name.
		/// If the attribute is not found, an exception is thrown with a descriptive error message.
		/// </summary>
		public static XAttribute GetAttribute(XElement element, string attributeName)
		{
			XAttribute attribute = TryGetAttribute(element, attributeName);
			if (attribute == null)
			{
				throw new Exception($"Element '{element.Name}' does not contain attribute '{attributeName}'.");
			}
			return attribute;
		}

		/// <summary>
		/// Tries to get an attribute with a given name.
		/// Null is returned if the attribute is not found.
		/// </summary>
		public static XAttribute TryGetAttribute(XElement element, string attributeName)
		{
			// Ignore namespaces (might not be fast)
			//XAttribute attribute = element.Attribute(attributeName);
			XAttribute attribute = element.Attributes().Where(x => x.Name.LocalName == attributeName).SingleOrDefault();
			return attribute;
		}

		/// <summary>
		/// Gets the value of an attribute with a given name.
		/// If the attribute is not found or the value is left empty,
		/// an exception is thrown with a descriptive error message.
		/// </summary>
		public static string GetAttributeValue(XElement element, string attributeName)
		{
			string attributeValue = TryGetAttributeValue(element, attributeName);
			if (string.IsNullOrEmpty(attributeValue))
			{
				throw new Exception($"Attribute '{attributeName}' of 'Element '{element.Name}' does not have a value.");
			}
			return attributeValue;
		}

		/// <summary>
		/// Tries to get the value of an attribute with a given name.
		/// Null or empty string is returned if the attribute is not present or no value is filled in.
		/// </summary>
		public static string TryGetAttributeValue(XElement element, string attributeName)
		{
			XAttribute attribute = TryGetAttribute(element, attributeName);
			return attribute != null ? attribute.Value : null;
		}

		public static void SetAttributeValue(XElement element, string attributeName, string value)
		{
			XAttribute attribute = element.Attribute(attributeName);
			if (attribute == null)
			{
				throw new Exception($"Attribute '{attributeName}' does not exist in element '{element.Name.LocalName}'.");
			}
			attribute.Value = value;
		}
	}
}
