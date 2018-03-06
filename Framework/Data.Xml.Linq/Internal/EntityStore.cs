using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.Misc;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Xml.Linq;

namespace JJ.Framework.Data.Xml.Linq.Internal
{
	/// <summary>
	/// Gives access to a data store for a single entity type.
	/// </summary>
	internal class EntityStore<TEntity> : IEntityStore
		where TEntity: class, new()
	{
		private const string ROOT_ELEMENT_NAME = "root";

		public XmlElementAccessor Accessor { get; }
		public XmlToEntityConverter Converter { get; }

		private readonly IXmlMapping _mapping;

		public EntityStore(string filePath, IXmlMapping mapping)
		{
			if (mapping == null) throw new NullException(() => mapping);
			_mapping = mapping;

			Accessor = new XmlElementAccessor(filePath, ROOT_ELEMENT_NAME, _mapping.ElementName);
			Converter = new XmlToEntityConverter();
		}

		public IList<TEntity> GetAll()
		{
			IEnumerable<XElement> sourceXmlElements = Accessor.GetAllElements(_mapping.ElementName);
			IList<TEntity> destEntities = sourceXmlElements.Select(x => Converter.ConvertXmlElementToEntity<TEntity>(x)).ToArray();
			return destEntities;
		}

		public TEntity TryGet(object id)
		{
			XElement sourceXmlElement = Accessor.TryGetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
			if (sourceXmlElement == null)
			{
				return null;
			}
			TEntity destEntity = Converter.ConvertXmlElementToEntity<TEntity>(sourceXmlElement);
			return destEntity;
		}

		public TEntity Create()
		{
			// Create XML element
			IEnumerable<string> attributeNames = GetEntityPropertyNames();
			XElement element = Accessor.CreateElement(attributeNames);

			// Set identity
			object id = GetNewIdentity();
			XmlHelper.SetAttributeValue(element, _mapping.IdentityPropertyName, Convert.ToString(id));

			TEntity entity = new TEntity();
			SetIDOfEntity(entity, id);
			return entity;
		}

		public void Insert(TEntity sourceEntity)
		{
			if (sourceEntity == null) throw new NullException(() => sourceEntity);

			IEnumerable<string> attributeNames = GetEntityPropertyNames();
			XElement destXmlElement = Accessor.CreateElement(attributeNames);
			Converter.ConvertEntityToXmlElement(sourceEntity, destXmlElement);
		}

		public void Update(TEntity sourceEntity)
		{
			if (sourceEntity == null) throw new NullException(() => sourceEntity);
			object id = GetIDFromEntity(sourceEntity);
			XElement destXmlElement = Accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
			Converter.ConvertEntityToXmlElement(sourceEntity, destXmlElement);
		}

		public void Delete(TEntity sourceEntity)
		{
			if (sourceEntity == null) throw new NullException(() => sourceEntity);
			object id = GetIDFromEntity(sourceEntity);
			XElement destXmlElement = Accessor.GetElementByAttributeValue(_mapping.IdentityPropertyName, Convert.ToString(id));
			Accessor.DeleteElement(destXmlElement);
		}

		public void Commit()
		{
			Accessor.SaveDocument();
		}

		// Helpers

		private object GetIDFromEntity(TEntity entity)
		{
			PropertyInfo property = entity.GetType().GetProperty(_mapping.IdentityPropertyName);
			if (property == null)
			{
				throw new Exception(string.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, entity.GetType().Name));
			}

			return property.GetValue_PlatformSafe(entity);
		}

		private void SetIDOfEntity(TEntity entity, object id)
		{
			PropertyInfo property = entity.GetType().GetProperty(_mapping.IdentityPropertyName);
			if (property == null)
			{
				throw new Exception(string.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, entity.GetType().Name));
			}
			property.SetValue(entity, id, null);
		}

		private IEnumerable<string> GetEntityPropertyNames()
		{
			var list = new List<string>();
			foreach (PropertyInfo property in ReflectionCacheWrapper.ReflectionCache.GetProperties(typeof(TEntity)))
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

			if (!string.IsNullOrEmpty(maxIDString))
			{
				_maxID = Int32.Parse(maxIDString);
			}
			else
			{
				_maxID = 0;
			}

			return _maxID;
		}

		// IEntityStore

		void IEntityStore.Commit()
		{
			Commit();
		}

		void IEntityStore.Insert(object entity)
		{
			Insert((TEntity)entity);
		}

		void IEntityStore.Update(object entity)
		{
			Update((TEntity)entity);
		}

		void IEntityStore.Delete(object entity)
		{
			Delete((TEntity)entity);
		}
	}
}
