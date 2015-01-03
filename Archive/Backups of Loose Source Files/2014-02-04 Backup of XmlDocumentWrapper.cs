using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Persistence.Xml
{
    internal class XmlDocumentWrapper
    {
        private const string ROOT_NODE_NAME = "root";
        private const string ENTITY_ELEMENT_NAME = "x";
        private const string ID_PROPERTY_NAME = "ID"; // TODO: This should not be a constant.

        private string _filePath;
        public string FilePath { get { return _filePath; } }

        private XmlDocument _document;

        public XmlDocumentWrapper(string filePath)
        {
            _filePath = filePath;
            _document = new XmlDocument();
            _document.Load(_filePath);
        }

        public List<XmlElement> GetAllXmlElements()
        {
            string xpath = ENTITY_ELEMENT_NAME;
            var list = new List<XmlElement>();
            foreach (XmlNode node in _document.SelectNodes(xpath))
            {
                list.Add((XmlElement)node);
            }
            return list;
        }

        public XmlElement GetXmlElementByEntityID(object id)
        {
            XmlElement element = TryGetXmlElementByEntityID(id);
            if (element == null)
            {
                throw new Exception(String.Format("XML element '{0}' with ID '{1}' not found.", ENTITY_ELEMENT_NAME, id));
            }
            return element;
        }

        public XmlElement GetXmlElementByEntity(object entity)
        {
            object id = GetIDFromEntity(entity);
            return GetXmlElementByEntityID(id);
        }

        public XmlElement TryGetXmlElementByEntityID(object id)
        {
            XmlElement root = GetRoot(_document);
            string xpath = String.Format("{0}[@{1}='{2}']", ENTITY_ELEMENT_NAME, ID_PROPERTY_NAME, id);
            return (XmlElement)TryGetNode(root, xpath);
        }

        public XmlElement TryGetXmlElementByEntity(object entity)
        {
            object id = GetIDFromEntity(entity);
            return TryGetXmlElementByEntityID(id);
        }

        private object GetIDFromEntity(object entity)
        {
            Type type = entity.GetType();
            PropertyInfo property = type.GetProperty(ID_PROPERTY_NAME);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found in type '{1}'.", ID_PROPERTY_NAME, type.Name));
            }
            return property.GetValue(entity, null);
        }

        public XmlElement CreateXmlElement<TEntity>()
        {
            XmlElement root = GetRoot(_document);

            XmlElement element = _document.CreateElement("x");
            root.AppendChild(element);

            // TODO: Use reflection cache.
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                XmlAttribute xmlAttribute = _document.CreateAttribute(property.Name);
                element.Attributes.Append(xmlAttribute);
            }

            return element;
        }

        public TEntity ConvertXmlElementToEntity<TEntity>(XmlElement element)
            where TEntity : class, new()
        {
            TEntity entity = new TEntity();

            // TODO: Use reflection cache.
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                string xpath = "@" + property.Name;
                XmlAttribute xmlAttribute = (XmlAttribute)GetNode(element, xpath);
                object propertyValue = ConversionHelper.Convert(xmlAttribute.Value, property.PropertyType);
                property.SetValue(entity, propertyValue, null);
            }

            return entity;
        }

        public void UpdateXmlElement<TEntity>(XmlElement element, TEntity entity)
        {
            // TODO: Use reflection cache.
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                object propertyValue = property.GetValue(entity, null);
                string xpath = "@" + property.Name;
                XmlAttribute xmlAttribute = (XmlAttribute)GetNode(element, xpath);
                xmlAttribute.Value = Convert.ToString(propertyValue);
            }
        }

        public void DeleteXmlElementByEntity<TEntity>(TEntity entity)
        {
            XmlElement element = GetXmlElementByEntity(entity);
            _document.RemoveChild(element);
        }

        public void Save()
        {
            _document.Save(_filePath);
        }

        private XmlElement GetRoot(XmlDocument document)
        {
            string xpath = ROOT_NODE_NAME;
            XmlElement element = (XmlElement)GetNode(document, xpath);
            return element;
        }

        // GetNode

        private XmlNode GetNode(XmlNode parentNode, string xpath)
        {
            XmlNode node = TryGetNode(parentNode, xpath);
            if (node == null)
            {
                throw new Exception(String.Format("Node '{0}' does not exist in parent node '{1}'.", xpath, parentNode.Name));
            }
            return node;
        }

        private XmlNode TryGetNode(XmlNode parentNode, string xpath)
        {
            XmlNodeList nodes = parentNode.SelectNodes(xpath);
            switch (nodes.Count)
            {
                case 0:
                    return null;

                case 1:
                    return nodes[0];

                default:
                    throw new Exception(String.Format("Node '{0}' is not unique.", xpath));
            }
        }
    }
}
