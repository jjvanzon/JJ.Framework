using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.PlatformCompatibility;

namespace JJ.Framework.Data.Xml.Linq.Internal
{
    /// <summary>
    /// Offers functions for retrieving and storing information from an XML file,
    /// that the XmlContext needs. There will be one XML file per entity.
    /// The file will be auto-created if it does not exist.
    /// </summary>
    internal class XmlElementAccessor
    {
        private readonly string _filePath;
        private readonly string _rootElementName;
        private readonly string _elementName;
        private readonly object _lock = new object();

        public XElement Document { get; }

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
                        writer.WriteLine($"<{_rootElementName}>");
                        writer.WriteLine($"</{_rootElementName}>");
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

        public IEnumerable<XElement> GetAllElements(string elementName) => GetRoot().Elements(elementName);

        /// <summary>
        /// Mainly used to get the an element by identity value.
        /// </summary>
        public XElement GetElementByAttributeValue(string attributeName, string attributeValue)
        {
            XElement element = TryGetElementByAttributeValue(attributeName, attributeValue);

            if (element == null)
            {
                throw new Exception($"XML element '{_elementName}' with attribute {attributeName} with value '{attributeValue}' not found.");
            }

            return element;
        }

        /// <summary>
        /// Mainly used to get the an element by identity value.
        /// </summary>
        public XElement TryGetElementByAttributeValue(string attributeName, string attributeValue)
            =>
                // TODO: This does not look very fast.
                GetRoot()
                    .Elements()
                    .Where(x => string.Equals(x.Attribute(attributeName)?.Value, attributeValue))
                    .SingleOrDefault();

        public void DeleteElement(XElement element) => element.Remove();

        public XElement CreateElement(IEnumerable<string> attributeNames)
        {
            if (attributeNames == null) throw new NullException(() => attributeNames);

            XElement root = GetRoot();
            var element = new XElement(_elementName);
            root.Add(element);

            foreach (string attributeName in attributeNames)
            {
                var attribute = new XAttribute(attributeName, "");
                element.Add(attribute);
            }

            return element;
        }

        private XElement GetRoot()
            =>
                //return Document.Root;
                //return Document.Elements().Single();
                Document;

        /// <summary>
        /// Returns null if there are no elements.
        /// </summary>
        public string GetMaxAttributeValue(string attributeName)
            =>
                // TODO: Performance of this is probably not very good.
                GetRoot()
                    .Elements()
                    .Where(x => x.Attribute(attributeName) != null)
                    .Select(x => x.Value)
                    .OrderByDescending(x => x)
                    .FirstOrDefault();
    }
}