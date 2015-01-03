using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Persistence.Xml
{
    internal class XmlDocumentAcessor
    {
        private const string ROOT_ELEMENT_NAME = "root";

        private XmlDocument _document;
        private IXmlMapping _mapping;

        private string _filePath;
        public string FilePath { get { return _filePath; } }

        public XmlDocumentAcessor(string filePath, IXmlMapping mapping)
        {
            if (mapping == null) throw new ArgumentNullException("mapping");

            _mapping = mapping;
            _filePath = filePath;
            _document = new XmlDocument();
            _document.Load(_filePath);
        }

        public List<XmlElement> GetAllXmlElements()
        {
            string xpath = _mapping.ElementName;
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
                throw new Exception(String.Format("XML element '{0}' with {1} '{2}' not found.", _mapping.ElementName, _mapping.IdentityPropertyName, id));
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
            string xpath = String.Format("{0}[@{1}='{2}']", _mapping.ElementName, _mapping.IdentityPropertyName, id);
            return (XmlElement)XmlHelper.TryGetNode(root, xpath);
        }

        public XmlElement TryGetXmlElementByEntity(object entity)
        {
            object id = GetIDFromEntity(entity);
            return TryGetXmlElementByEntityID(id);
        }

        private object GetIDFromEntity(object entity)
        {
            Type type = entity.GetType();
            PropertyInfo property = type.GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found in type '{1}'.", _mapping.IdentityPropertyName, type.Name));
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

            // Set identity
            object id = GetNewID();
            SetAttributeValue(element, _mapping.IdentityPropertyName, id);

            return element;
        }

        public TEntity ConvertXmlElementToEntity<TEntity>(XmlElement element)
            where TEntity : class, new()
        {
            TEntity entity = new TEntity();

            // TODO: Use reflection cache.
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                object value = GetAttributeValue(element, property.Name, property.PropertyType);
                property.SetValue(entity, value, null);
            }

            return entity;
        }

        public void UpdateXmlElement<TEntity>(XmlElement element, TEntity entity)
        {
            // TODO: Use reflection cache.
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                object value = property.GetValue(entity, null);
                SetAttributeValue(element, property.Name, value);
            }
        }

        private TValue GetAttributeValue<TValue>(XmlElement element, string propertyName)
        {
            TValue value = (TValue)GetAttributeValue(element, propertyName, typeof(TValue));
            return value;
        }

        private void SetAttributeValue(XmlElement element, string propertyName, object value)
        {
            string xpath = "@" + propertyName;
            XmlAttribute xmlAttribute = (XmlAttribute)XmlHelper.GetNode(element, xpath);
            xmlAttribute.Value = Convert.ToString(value);
        }

        private object GetAttributeValue(XmlElement element, string propertyName, Type valueType)
        {
            string xpath = "@" + propertyName;
            XmlAttribute xmlAttribute = (XmlAttribute)XmlHelper.GetNode(element, xpath);
            object convertedValue = ConversionHelper.Convert(xmlAttribute.Value, valueType);
            return convertedValue;
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
            string xpath = ROOT_ELEMENT_NAME;
            XmlElement element = (XmlElement)XmlHelper.GetNode(document, xpath);
            return element;
        }

        // ID's

        public object GetNewID()
        {
            switch (_mapping.IdentityType)
            {
                case IdentityType.AutoIncrement:
                    _maxID = GetMaxID();
                    _maxID++;
                    return _maxID;

                default:
                    throw new ValueNotSupportedException(_mapping.IdentityType);
            }
        }

        private int _maxID = 0;

        private int GetMaxID()
        {
            if (_maxID != 0)
            {
                return _maxID;
            }

            string xpath = "entity[not(@id > ../@id)]";
            XmlElement elementWithMaxID = (XmlElement)XmlHelper.TryGetNode(_document, xpath);
            if (elementWithMaxID != null)
            {
                return GetAttributeValue<int>(elementWithMaxID, _mapping.IdentityPropertyName);

            }

            return 0;
        }
    }
}
