using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace JJ.Framework.Persistence.Xml.Internal
{
    /// <summary>
    /// Gives access to a data store for a single entity type.
    /// </summary>
    internal class EntityStore
    {
        private const string ROOT_ELEMENT_NAME = "root";

        public XmlElementAccessor Accessor { get; private set; }
        public XmlToEntityConverter Converter { get; private set; }

        private readonly IXmlMapping _mapping;

        public EntityStore(Type type, string filePath, IXmlMapping mapping)
        {
            if (mapping == null) throw new NullException(() => mapping);
            _mapping = mapping;

            Accessor = new XmlElementAccessor(filePath, ROOT_ELEMENT_NAME, _mapping.ElementName);
            Converter = new XmlToEntityConverter();
        }

        public IEnumerable<TEntity> GetAll<TEntity>()
            where TEntity: new()
        {
            IList<XmlElement> sourceXmlElements = Accessor.GetAllElements(_mapping.ElementName);
            IList<TEntity> destEntities = sourceXmlElements.Select(x => Converter.ConvertXmlElementToEntity<TEntity>(x)).ToArray();
            return destEntities;
        }

        public TEntity TryGet<TEntity>(object id)
            where TEntity: class, new()
        {
            XmlElement sourceXmlElement = Accessor.TryGetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            if (sourceXmlElement == null)
            {
                return null;
            }
            TEntity destEntity = Converter.ConvertXmlElementToEntity<TEntity>(sourceXmlElement);
            return destEntity;
        }

        public TEntity Create<TEntity>()
            where TEntity: new()
        {
            // Create XML element
            IEnumerable<string> attributeNames = GetEntityPropertyNames(typeof(TEntity));
            XmlElement xmlElement = Accessor.CreateElement(attributeNames);

            // Set identity
            object id = GetNewIdentity();
            XmlHelper.SetAttributeValue(xmlElement, _mapping.IdentityPropertyName, Convert.ToString(id));

            TEntity entity = new TEntity();
            SetIDOfEntity(entity, id);
            return entity;
        }

        public void Insert(object sourceEntity)
        {
            if (sourceEntity == null) throw new NullException(() => sourceEntity);

            IEnumerable<string> attributeNames = GetEntityPropertyNames(sourceEntity.GetType());
            XmlElement destXmlElement = Accessor.CreateElement(attributeNames);
            Converter.ConvertEntityToXmlElement(sourceEntity, destXmlElement);
        }

        public void Update(object sourceEntity)
        {
            if (sourceEntity == null) throw new NullException(() => sourceEntity);
            object id = GetIDFromEntity(sourceEntity);
            XmlElement destXmlElement = Accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            Converter.ConvertEntityToXmlElement(sourceEntity, destXmlElement);
        }

        public void Delete(object sourceEntity)
        {
            if (sourceEntity == null) throw new NullException(() => sourceEntity);
            object id = GetIDFromEntity(sourceEntity);
            XmlElement destXmlElement = Accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            Accessor.DeleteElement(destXmlElement);
        }

        public void Commit()
        {
            Accessor.SaveDocument();
        }

        // Helpers

        private object GetIDFromEntity(object entity)
        {
            PropertyInfo property = entity.GetType().GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, entity.GetType().Name));
            }
            return property.GetValue(entity, null);
        }

        private void SetIDOfEntity(object entity, object id)
        {
            PropertyInfo property = entity.GetType().GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, entity.GetType().Name));
            }
            property.SetValue(entity, id, null);
        }

        private IEnumerable<string> GetEntityPropertyNames(Type entityType)
        {
            var list = new List<string>();
            foreach (PropertyInfo property in ReflectionCache.GetProperties(entityType))
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
