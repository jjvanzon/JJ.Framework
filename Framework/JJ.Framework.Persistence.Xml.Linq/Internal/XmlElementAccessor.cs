using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using JJ.Framework.Common;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence.Xml.Linq.Internal
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

        public XElement Document { get; private set; }

        public XmlElementAccessor(string filePath, string rootElementName, string elementName)
        {
            if (String_PlatformSupport.IsNullOrWhiteSpace(rootElementName)) throw new Exception("rootElementName cannot be null or white space.");
            if (String_PlatformSupport.IsNullOrWhiteSpace(elementName)) throw new Exception("elementName cannot be null or white space.");

            _filePath = filePath;
            _rootElementName = rootElementName;
            _elementName = elementName;

            lock (_lock)
            {
                AutoCreateXmlFile();

                Document = XElement.Load(_filePath);
            }
        }

        private void AutoCreateXmlFile()
        {
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
                Document.Save_PlatformSafe(_filePath);
            }
        }

        public IEnumerable<XElement> GetAllElements(string elementName)
        {
            return GetRoot().Elements(elementName);
        }

        /// <summary>
        /// Mainly used to get the an element by identity value.
        /// </summary>
        public XElement GetElementByAttributeValue(string attributeName, string attributeValue)
        {
            XElement element = TryGetElementByAttributeValue(attributeName, attributeValue);
            if (element == null)
            {
                throw new Exception(String.Format("XML element '{0}' with attribute {1} with value '{2}' not found.", _elementName, attributeName, attributeValue));
            }
            return element;
        }
        
        /// <summary>
        /// Mainly used to get the an element by identity value.
        /// </summary>
        public XElement TryGetElementByAttributeValue(string attributeName, string attributeValue)
        {
            // TODO: This does not look very fast.
            return GetRoot().Elements()
                            .Where(x => x.Attribute(attributeName) != null)
                            .Where(x => x.Attribute(attributeName).Value == attributeValue)
                            .SingleOrDefault();
        }

        public void DeleteElement(XElement element)
        {
            element.Remove();
        }

        public XElement CreateElement(IEnumerable<string> attributeNames)
        {
            if (attributeNames == null) throw new NullException(() => attributeNames);

            XElement root = GetRoot();
            XElement element = new XElement(_elementName);
            root.Add(element);

            foreach (string attributeName in attributeNames)
            {
                XAttribute attribute = new XAttribute(attributeName, "");
                element.Add(attribute);
            }

            return element;
        }

        private XElement GetRoot()
        {
            //return Document.Root;
            //return Document.Elements().Single();
            return Document;
        }
        
        public string GetAttributeValue(XElement element, string attributeName)
        {
            XAttribute attribute = element.Attribute(attributeName);
            if (attribute == null)
            {
                throw new Exception(String.Format("Attribute '{0}' does not exist in element '{1}'.", attributeName, element.Name.LocalName));
            }
            return attribute.Value;
        }

        public void SetAttributeValue(XElement element, string attributeName, string value)
        {
            XAttribute attribute = element.Attribute(attributeName);
            if (attribute == null)
            {
                throw new Exception(String.Format("Attribute '{0}' does not exist in element '{1}'.", attributeName, element.Name.LocalName));
            }
            attribute.Value = value;
        }

        /// <summary>
        /// Returns null if there are no elements.
        /// </summary>
        public string GetMaxAttributeValue(string attributeName)
        {
            // TODO: Performance of this is probably not very good.
            return GetRoot().Elements()
                            .Where(x => x.Attribute(attributeName) != null)
                            .Select(x => x.Value)
                            .OrderByDescending(x => x)
                            .FirstOrDefault();
        }
    }
}
