using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using JJ.Framework.Exceptions;
using JJ.Framework.Xml;

namespace JJ.Framework.Data.Xml.Internal
{
	/// <summary>
	/// Offers functions for retrieving and storing information from an XML file,
	/// that the XmlContext needs. There will be one XML file per entity.
	/// The file will be auto-created if it does not exist.
	/// </summary>
	internal class XmlElementAccessor
	{
		private string _filePath;
		private string _rootElementName;
		private string _elementName;
		private object _lock = new object();

		public XmlDocument Document { get; }

		public XmlElementAccessor(string filePath, string rootElementName, string elementName)
		{
			if (string.IsNullOrWhiteSpace(rootElementName)) throw new NullOrWhiteSpaceException(() => rootElementName);
			if (string.IsNullOrWhiteSpace(elementName)) throw new NullOrWhiteSpaceException(() => elementName);

			_filePath = filePath;
			_rootElementName = rootElementName;
			_elementName = elementName;

			lock (_lock)
			{
				AutoCreateXmlFile();

				Document = new XmlDocument();
				Document.Load(_filePath);
			}
		}

		private void AutoCreateXmlFile()
		{
			// Auto-create file
			if (!File.Exists(_filePath))
			{
				using (Stream stream = File.Create(_filePath))
				{
					using (var writer = new StreamWriter(stream))
					{
						writer.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
						writer.WriteLine(string.Format("<{0}>", _rootElementName));
						writer.WriteLine(string.Format("</{0}>", _rootElementName));
					}
				}
			}
		}

		public void SaveDocument()
		{
			lock (_lock)
			{
				Document.Save(_filePath);
			}
		}

		public List<XmlElement> GetAllElements(string elementName)
		{
			string xpath = elementName;
			var list = new List<XmlElement>();
			foreach (XmlNode node in Document.SelectNodes(xpath))
			{
				list.Add((XmlElement)node);
			}
			return list;
		}

		/// <summary>
		/// Mainly used to get the an element by identity value.
		/// </summary>
		public XmlElement GetElementByAttributeValue(string attributeName, string attributeValue)
		{
			XmlElement element = TryGetElementByAttributeValue(attributeName, attributeValue);
			if (element == null)
			{
				throw new Exception(string.Format("XML element '{0}' with attribute {1} with value '{2}' not found.", _elementName, attributeName, attributeValue));
			}
			return element;
		}

		/// <summary>
		/// Mainly used to get the an element by identity value.
		/// </summary>
		public XmlElement TryGetElementByAttributeValue(string attributeName, string attributeValue)
		{
			XmlElement root = GetRoot(Document);
			string xpath = string.Format("{0}[@{1}='{2}']", _elementName, attributeName, attributeValue);
			return (XmlElement)XmlHelper.TrySelectNode(root, xpath);
		}

		public void DeleteElement(XmlElement element)
		{
			Document.RemoveChild(element);
		}

		private XmlElement GetRoot(XmlDocument document)
		{
			// TODO: doc.DocumentElement would also get the root.

			string xpath = _rootElementName;
			XmlElement element = (XmlElement)XmlHelper.SelectNode(document, xpath);
			return element;
		}

		public XmlElement CreateElement(IEnumerable<string> attributeNames)
		{
			if (attributeNames == null) throw new NullException(() => attributeNames);

			XmlElement root = GetRoot(Document);

			XmlElement element = Document.CreateElement(_elementName);
			root.AppendChild(element);

			foreach (string attributeName in attributeNames)
			{
				XmlAttribute attribute = Document.CreateAttribute(attributeName);
				element.Attributes.Append(attribute);
			}

			return element;
		}

		/// <summary>
		/// Returns null if there are no elements.
		/// </summary>
		public string GetMaxAttributeValue(string attributeName)
		{
			string xpath = string.Format("{0}[not(@{1} > ../@{1})]", _elementName, attributeName);
			XmlElement elementWithMaxID = (XmlElement)XmlHelper.TrySelectNode(Document, xpath);
			if (elementWithMaxID != null)
			{
				return XmlHelper.GetAttributeValue(elementWithMaxID, attributeName);
			}

			return null;
		}
	}
}
