using JJ.Framework.Data.Xml.Linq.Internal;
using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace JJ.Framework.Data.Xml.Linq
{
	public class XmlContext : ContextBase
	{
		public XmlContext(string folderPath, Assembly modelAssembly, Assembly mappingAssembly, string dialect = null)
			: base(folderPath, modelAssembly, mappingAssembly, dialect)
		{
			if (mappingAssembly == null) throw new NullException(() => mappingAssembly);
		}

		private object _lock = new object();
		private Dictionary<Type, IEntityStore> _entityStoreDictionary = new Dictionary<Type, IEntityStore>();

		// Expose underlying persistence technology for specialized repository.
		public XElement GetDocument<TEntity>()
			where TEntity : class, new()
		{
			return GetEntityStore<TEntity>().Accessor.Document;
		}

		public XmlToEntityConverter GetConverter()
		{
			return new XmlToEntityConverter();
		}

		private EntityStore<TEntity> GetEntityStore<TEntity>()
			where TEntity : class, new()
		{
			return (EntityStore<TEntity>)GetEntityStore(typeof(TEntity));
		}

		private IEntityStore GetEntityStore(Type entityType)
		{
			if (entityType == null) throw new NullException(() => entityType);

			IEntityStore entityStore;

			lock (_lock)
			{
				if (!_entityStoreDictionary.TryGetValue(entityType, out entityStore))
				{
					string entityName = entityType.Name;
					string filePath = Path.Combine(Location, entityName) + ".xml";
					IXmlMapping xmlMapping = XmlMappingResolver.GetXmlMapping(entityType, MappingAssembly);

					Type entityStoreType = typeof(EntityStore<>).MakeGenericType(entityType);
					entityStore = (IEntityStore)Activator.CreateInstance(entityStoreType, filePath, xmlMapping);

					_entityStoreDictionary[entityType] = entityStore;
				}
			}

			return entityStore;
		}

		public override TEntity TryGet<TEntity>(object id)
		{
			EntityStore<TEntity> entityStore = GetEntityStore<TEntity>();
			return entityStore.TryGet(id);
		}

		public override TEntity Create<TEntity>()
		{
			EntityStore<TEntity> entityStore = GetEntityStore<TEntity>();
			return entityStore.Create();
		}

		public override void Insert(object entity)
		{
			IEntityStore entityStore = GetEntityStore(entity.GetType());
			entityStore.Insert(entity);
		}

		public override void Update(object entity)
		{
			IEntityStore entityStore = GetEntityStore(entity.GetType());
			entityStore.Update(entity);
		}

		public override void Delete(object entity)
		{
			IEntityStore entityStore = GetEntityStore(entity.GetType());
			entityStore.Delete(entity);
		}

		public override IEnumerable<TEntity> Query<TEntity>()
		{
			throw new NotSupportedException("XmlContext does not support Query<TEntity>().");
		}

		public override void Commit()
		{
			lock (_lock)
			{
				foreach (IEntityStore entityStore in _entityStoreDictionary.Values)
				{
					entityStore.Commit();
				}
			}
		}

		public override void Flush()
		{
			// No code required.
		}

		public override void Dispose()
		{
			// No code required.
		}

		public override void Rollback()
		{
			lock (_entityStoreDictionary)
			{
				_entityStoreDictionary.Clear();
			}
		}
	}
}
