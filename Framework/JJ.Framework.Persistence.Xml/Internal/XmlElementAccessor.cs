using JJ.Framework.Common;
using JJ.Framework.Net4;
using JJ.Framework.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace JJ.Framework.Persistence.Xml.Internal
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

        public XmlDocument Document { get; private set; }

        public XmlElementAccessor(string filePath, string rootElementName, string elementName)
        {
            if (Strings.IsNullOrWhiteSpace(rootElementName)) throw new Exception("rootElementName cannot be null or white space.");
            if (Strings.IsNullOrWhiteSpace(elementName)) throw new Exception("elementName cannot be null or white space.");

            _filePath = filePath;
            _rootElementName = rootElementName;
            _elementName = elementName;

            lock (_lock)
            {
                AutoCreateXmlFile();

                // TODO: Use lock() to prevent simultaneous reads and writes.
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
                        writer.WriteLine(String.Format("<{0}>", _rootElementName));
                        writer.WriteLine(String.Format("</{0}>", _rootElementName));
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
                throw new Exception(String.Format("XML element '{0}' with attribute {1} with value '{2}' not found.", _elementName, attributeName, attributeValue));
            }
            return element;
        }

        /// <summary>
        /// Mainly used to get the an element by identity value.
        /// </summary>
        public XmlElement TryGetElementByAttributeValue(string attributeName, string attributeValue)
        {
            XmlElement root = GetRoot(Document);
            string xpath = String.Format("{0}[@{1}='{2}']", _elementName, attributeName, attributeValue);
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
            if (attributeNames == null) throw new ArgumentNullException("attributeNames");

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

        public string GetAttributeValue(XmlElement element, string attributeName)
        {
            string xpath = "@" + attributeName;
            XmlAttribute xmlAttribute = (XmlAttribute)XmlHelper.SelectNode(element, xpath);
            return xmlAttribute.Value;
        }

        public void SetAttributeValue(XmlElement element, string attributeName, string value)
        {
            string xpath = "@" + attributeName;
            XmlAttribute xmlAttribute = (XmlAttribute)XmlHelper.SelectNode(element, xpath);
            xmlAttribute.Value = value;
        }

        /// <summary>
        /// Returns null if there are no elements.
        /// </summary>
        public string GetMaxAttributeValue(string attributeName)
        {
            string xpath = String.Format("{0}[not(@{1} > ../@{1})]", _elementName, attributeName);
            XmlElement elementWithMaxID = (XmlElement)XmlHelper.TrySelectNode(Document, xpath);
            if (elementWithMaxID != null)
            {
                return GetAttributeValue(elementWithMaxID, attributeName);
            }

            return null;
        }
    }
}
