using JJ.Framework.Common;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Persistence.Xml.Internal
{
    internal class EntityStore<TEntity> : IEntityStore
        where TEntity : class, new()
    {
        private const string ROOT_ELEMENT_NAME = "root";

        public XmlElementAccessor Accessor { get; private set; }
        public XmlToEntityConverter<TEntity> Converter { get; private set; }

        private readonly IXmlMapping _mapping;

        public EntityStore(string filePath, IXmlMapping mapping)
        {
            if (mapping == null) throw new ArgumentNullException("mapping");
            _mapping = mapping;

            Accessor = new XmlElementAccessor(filePath, ROOT_ELEMENT_NAME, _mapping.ElementName);
            Converter = new XmlToEntityConverter<TEntity>(Accessor);
        }

        public IEnumerable<TEntity> GetAll()
        {
            IList<XmlElement> sourceXmlElements = Accessor.GetAllElements(_mapping.ElementName);
            IList<TEntity> destEntities = sourceXmlElements.Select(x => Converter.ConvertXmlElementToEntity(x)).ToArray();
            return destEntities;
        }

        public TEntity TryGet(object id)
        {
            XmlElement sourceXmlElement = Accessor.TryGetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            if (sourceXmlElement == null)
            {
                return null;
            }
            TEntity destEntity = Converter.ConvertXmlElementToEntity(sourceXmlElement);
            return destEntity;
        }

        public TEntity Get(object id)
        {
            XmlElement sourceXmlElement = Accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            TEntity destEntity = Converter.ConvertXmlElementToEntity(sourceXmlElement);
            return destEntity;
        }

        public TEntity Create()
        {
            // Create XML element
            IEnumerable<string> attributeNames = GetEntityPropertyNames();
            XmlElement xmlElement = Accessor.CreateElement(attributeNames);

            // Set identity
            object id = GetNewIdentity();
            Accessor.SetAttributeValue(xmlElement, _mapping.IdentityPropertyName, Convert.ToString(id));

            TEntity entity = new TEntity();
            SetIDOfEntity(entity, id);
            return entity;
        }

        public void Insert(TEntity sourceEntity)
        {
            if (sourceEntity == null) throw new ArgumentNullException("sourceEntity");

            IEnumerable<string> attributeNames = GetEntityPropertyNames();
            XmlElement destXmlElement = Accessor.CreateElement(attributeNames);
            Converter.ConvertEntityToXmlElement(sourceEntity, destXmlElement);
        }

        public void Update(TEntity sourceEntity)
        {
            if (sourceEntity == null) throw new ArgumentNullException("sourceEntity");
            object id = GetIDFromEntity(sourceEntity);
            XmlElement destXmlElement = Accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            Converter.ConvertEntityToXmlElement(sourceEntity, destXmlElement);
        }

        public void Delete(TEntity sourceEntity)
        {
            if (sourceEntity == null) throw new ArgumentNullException("sourceEntity");
            object id = GetIDFromEntity(sourceEntity);
            XmlElement destXmlElement = Accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            Accessor.DeleteElement(destXmlElement);
        }

        public void Commit()
        {
            Accessor.SaveDocument();
        }

        // Helpers

        private object GetIDFromEntity(TEntity entity)
        {
            PropertyInfo property = typeof(TEntity).GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, typeof(TEntity).Name));
            }
            return property.GetValue(entity, null);
        }

        private void SetIDOfEntity(TEntity entity, object id)
        {
            PropertyInfo property = typeof(TEntity).GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, typeof(TEntity).Name));
            }
            property.SetValue(entity, id, null);
        }

        private IEnumerable<string> GetEntityPropertyNames()
        {
            var list = new List<string>();
            foreach (PropertyInfo property in ReflectionCache.GetProperties(typeof(TEntity)))
            {
                list.Add(property.Name);
            }
            return list;
        }

        // Identity generation

        public object GetNewIdentity()
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
            // Cache the max value.
            if (_maxID != 0)
            {
                return _maxID;
            }

            string maxIDString = Accessor.GetMaxAttributeValue(_mapping.IdentityPropertyName);

            if (!String.IsNullOrEmpty(maxIDString))
            {
                _maxID = Int32.Parse(maxIDString);
            }
            else
            {
                _maxID = 0;
            }

            return _maxID;
        }
    }
}
