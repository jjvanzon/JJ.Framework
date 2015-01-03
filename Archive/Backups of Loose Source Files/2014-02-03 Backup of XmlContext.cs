using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Persistence.Xml
{
    public class XmlContext : ContextBase
    {
        public XmlContext(string folderPath, params Assembly[] modelAssemblies)
            : base(folderPath, modelAssemblies)
        { }

        public override TEntity TryGet<TEntity>(object id)
        {
            XmlDocument document = GetXmlDocument<TEntity>();
            XmlElement element = TryGetXmlElementByEntityID(document, id);
            return ConvertXmlElementToEntity<TEntity>(element);
        }

        public override TEntity Create<TEntity>()
        {
            TEntity entity = new TEntity();
            XmlDocument document = GetXmlDocument<TEntity>();
            XmlElement element = CreateXmlElement<TEntity>(document);
            UpdateXmlElement(element, entity);
            return entity;
        }

        public override void Insert<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocument document = GetXmlDocument<TEntity>();
            XmlElement element = CreateXmlElement<TEntity>(document);
            UpdateXmlElement(element, entity);
        }

        public override void Update<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocument document = GetXmlDocument<TEntity>();
            XmlElement element = GetXmlElementByEntityID(document, entity.ID);
            UpdateXmlElement(element, entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocument document = GetXmlDocument<TEntity>();
            XmlElement element = GetXmlElementByEntityID(document, entity.ID);
            document.RemoveChild(element);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            throw new NotSupportedException("XmlContext does not support Query<TEntity>().");
        }

        public override void Commit()
        {
            lock (_documentDictionaryLock)
            {
                foreach (XmlDocument document in _documentDictionary.Values)
                {
                    // TODO: Make a class that wraps 1 XML document and remember the file path yourself.
                    document.Save(document.LocalName);
                }
            }
        }

        public override void Dispose()
        {
            // No code required.
        }

        // Helpers

        private object _documentDictionaryLock = new object();
        private Dictionary<string, XmlDocument> _documentDictionary = new Dictionary<string, XmlDocument>();

        private XmlDocument GetXmlDocument<TEntity>()
        {
            lock (_documentDictionaryLock)
            {
                string entityName = typeof(TEntity).Name;
                XmlDocument document;
                if (_documentDictionary.ContainsKey(entityName))
                {
                    document = _documentDictionary[entityName];
                }
                else
                {
                    string filePath = Path.Combine(Location, entityName) + ".xml";
                    document = new XmlDocument();
                    document.Load(filePath);
                    _documentDictionary[entityName] = document;
                }

                return _documentDictionary[entityName];
            }
        }

        private XmlElement GetXmlElementByEntityID(XmlDocument document, object id)
        {
            XmlElement element = TryGetXmlElementByEntityID(document, id);
            if (element == null)
            {
                throw new Exception(String.Format("XML element '{0}' with ID '{1}' not found.", "entity", id));
            }
            return element;
        }

        private XmlElement TryGetXmlElementByEntityID(XmlDocument document, object id)
        {
            XmlElement root = GetRoot(document);
            string xpath = String.Format("x[@id='{0}']", id);
            return (XmlElement)TryGetNode(root, xpath);
        }

        private XmlElement CreateXmlElement<TEntity>(XmlDocument document)
        {
            XmlElement root = GetRoot(document);

            XmlElement element = document.CreateElement("x");
            root.AppendChild(element);

            // TODO: Use reflection cache.
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                XmlAttribute xmlAttribute = document.CreateAttribute(property.Name);
                element.Attributes.Append(xmlAttribute);
            }

            return element;
        }

        private XmlElement GetRoot(XmlDocument document)
        {
            string xpath = "root";
            XmlElement element = (XmlElement)GetNode(document, xpath);
            return element;
        }

        private TEntity ConvertXmlElementToEntity<TEntity>(XmlElement element)
            where TEntity : class, new()
        {
            TEntity entity = new TEntity();

            // TODO: Use reflection cache.
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                string stringValue = GetXmlAttributeValue(element, property.Name);
                object value = ConversionHelper.Convert(stringValue, property.PropertyType);
                property.SetValue(entity, value, null);
            }

            return entity;
        }

        private void UpdateXmlElement<TEntity>(XmlElement element, TEntity entity)
        {
            // TODO: Use reflection cache.
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                object value = property.GetValue(entity, null);
                SetXmlValue(element, property.Name, value);
            }
        }

        private string GetXmlAttributeValue(XmlElement parentElement, string propertyName)
        {
            string xpath = "@" + propertyName;
            XmlAttribute attribute = (XmlAttribute)GetNode(parentElement, xpath);
            return attribute.Value;
        }

        private void SetXmlValue(XmlElement parentElement, string propertyName, object value)
        {
            string xpath = "@" + propertyName;
            XmlAttribute attribute = (XmlAttribute)GetNode(parentElement, xpath);
            attribute.Value = Convert.ToString(value);
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
