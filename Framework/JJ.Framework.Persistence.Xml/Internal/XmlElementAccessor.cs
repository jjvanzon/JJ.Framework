using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JJ.Framework.Persistence.Xml.Internal
{
    internal class XmlElementAccessor
    {
        private string _filePath;
        private XmlDocument _document;

        private string _rootElementName;
        private string _elementName;

        public XmlElementAccessor(string filePath, string rootElementName, string elementName)
        {
            if (String.IsNullOrWhiteSpace(rootElementName)) throw new Exception("rootElementName cannot be null or white space.");
            if (String.IsNullOrWhiteSpace(elementName)) throw new Exception("elementName cannot be null or white space.");

            _rootElementName = rootElementName;
            _elementName = elementName;
            _filePath = filePath;
            _document = new XmlDocument();
            _document.Load(_filePath);
        }

        public List<XmlElement> GetAllElements(string elementName)
        {
            string xpath = elementName;
            var list = new List<XmlElement>();
            foreach (XmlNode node in _document.SelectNodes(xpath))
            {
                list.Add((XmlElement)node);
            }
            return list;
        }

        public XmlElement GetElementByAttributeValue(string attributeName, string attributeValue)
        {
            XmlElement element = TryGetElementByAttributeValue(attributeName, attributeValue);
            if (element == null)
            {
                throw new Exception(String.Format("XML element '{0}' with attribute {1} with value '{2}' not found.", _elementName, attributeName, attributeValue));
            }
            return element;
        }

        public XmlElement TryGetElementByAttributeValue(string attributeName, string attributeValue)
        {
            XmlElement root = GetRoot(_document);
            string xpath = String.Format("{0}[@{1}='{2}']", _elementName, attributeName, attributeValue);
            return (XmlElement)XmlHelper.TryGetNode(root, xpath);
        }

        public void DeleteElement(XmlElement element)
        {
            _document.RemoveChild(element);
        }

        private XmlElement GetRoot(XmlDocument document)
        {
            string xpath = _rootElementName;
            XmlElement element = (XmlElement)XmlHelper.GetNode(document, xpath);
            return element;
        }

        public void SaveDocument()
        {
            _document.Save(_filePath);
        }

        public XmlElement CreateElement(IEnumerable<string> attributeNames)
        {
            if (attributeNames == null) throw new ArgumentNullException("attributeNames");

            XmlElement root = GetRoot(_document);

            XmlElement element = _document.CreateElement(_elementName);
            root.AppendChild(element);

            foreach (string attributeName in attributeNames)
            {
                XmlAttribute attribute = _document.CreateAttribute(attributeName);
                element.Attributes.Append(attribute);
            }

            return element;
        }

        public string GetAttributeValue(XmlElement element, string attributeName)
        {
            string xpath = "@" + attributeName;
            XmlAttribute xmlAttribute = (XmlAttribute)XmlHelper.GetNode(element, xpath);
            return xmlAttribute.Value;
        }

        public void SetAttributeValue(XmlElement element, string attributeName, string value)
        {
            string xpath = "@" + attributeName;
            XmlAttribute xmlAttribute = (XmlAttribute)XmlHelper.GetNode(element, xpath);
            xmlAttribute.Value = value;
        }

        /// <summary>
        /// Returns null if there are no elements.
        /// </summary>
        public string GetMaxAttributeValue(string attributeName)
        {
            string xpath = String.Format("{0}[not(@{1} > ../@{1})]", _elementName, attributeName);
            XmlElement elementWithMaxID = (XmlElement)XmlHelper.TryGetNode(_document, xpath);
            if (elementWithMaxID != null)
            {
                return GetAttributeValue(elementWithMaxID, attributeName);
            }

            return null;
        }
    }
}
