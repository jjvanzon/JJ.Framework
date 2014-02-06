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

        private readonly XmlElementAccessor _accessor;
        private readonly XmlToEntityConverter<TEntity> _converter;
        private readonly IXmlMapping _mapping;

        public EntityStore(string filePath, IXmlMapping mapping)
        {
            if (mapping == null) throw new ArgumentNullException("mapping");
            _mapping = mapping;

            _accessor = new XmlElementAccessor(filePath, ROOT_ELEMENT_NAME, _mapping.ElementName);
            _converter = new XmlToEntityConverter<TEntity>(_accessor);
        }

        public IEnumerable<TEntity> GetAll()
        {
            IList<XmlElement> sourceXmlElements = _accessor.GetAllElements(_mapping.ElementName);
            IList<TEntity> destEntities = sourceXmlElements.Select(x => _converter.ConvertXmlElementToEntity(x)).ToArray();
            return destEntities;
        }

        public TEntity TryGet(object id)
        {
            XmlElement sourceXmlElement = _accessor.TryGetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            if (sourceXmlElement == null)
            {
                return null;
            }
            TEntity destEntity = _converter.ConvertXmlElementToEntity(sourceXmlElement);
            return destEntity;
        }

        public TEntity Get(object id)
        {
            XmlElement sourceXmlElement = _accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            TEntity destEntity = _converter.ConvertXmlElementToEntity(sourceXmlElement);
            return destEntity;
        }

        public TEntity Create()
        {
            // Create XML element
            IEnumerable<string> attributeNames = GetEntityPropertyNames();
            XmlElement xmlElement = _accessor.CreateElement(attributeNames);

            // Set identity
            object id = GetNewIdentity();
            _accessor.SetAttributeValue(xmlElement, _mapping.IdentityPropertyName, Convert.ToString(id));

            TEntity entity = new TEntity();
            SetIDOfEntity(entity, id);
            return entity;
        }

        public void Insert(TEntity sourceEntity)
        {
            if (sourceEntity == null) throw new ArgumentNullException("sourceEntity");

            IEnumerable<string> attributeNames = GetEntityPropertyNames();
            XmlElement destXmlElement = _accessor.CreateElement(attributeNames);
            _converter.ConvertEntityToXmlElement(sourceEntity, destXmlElement);
        }

        public void Update(TEntity sourceEntity)
        {
            if (sourceEntity == null) throw new ArgumentNullException("sourceEntity");
            object id = GetIDFromEntity(sourceEntity);
            XmlElement destXmlElement = _accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            _converter.ConvertEntityToXmlElement(sourceEntity, destXmlElement);
        }

        public void Delete(TEntity sourceEntity)
        {
            if (sourceEntity == null) throw new ArgumentNullException("sourceEntity");
            object id = GetIDFromEntity(sourceEntity);
            XmlElement destXmlElement = _accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
            _accessor.DeleteElement(destXmlElement);
        }

        public void Commit()
        {
            _accessor.SaveDocument();
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

            string maxIDString = _accessor.GetMaxAttributeValue(_mapping.IdentityPropertyName);

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
