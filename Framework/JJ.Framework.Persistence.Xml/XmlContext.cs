using JJ.Framework.Persistence.Xml.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace JJ.Framework.Persistence.Xml
{
    public class XmlContext : ContextBase
    {
        public XmlContext(string folderPath, Assembly modelAssembly, Assembly mappingAssembly, string dialect = null)
            : base(folderPath, modelAssembly, mappingAssembly, dialect)
        {
            if (mappingAssembly == null) throw new ArgumentNullException("mappingAssembly");
        }

        private object _lock = new object();
        private Dictionary<Type, IEntityStore> _entityStoreDictionary = new Dictionary<Type, IEntityStore>();

        // Expose underlying persistence technology for specialized repository.
        public XmlDocument GetDocument<TEntity>()
            where TEntity : class, new()
        {
            return GetEntityStore<TEntity>().Accessor.Document;
        }

        public XmlToEntityConverter<TEntity> GetConverter<TEntity>()
            where TEntity : class, new()
        {
            return GetEntityStore<TEntity>().Converter;
        }

        private EntityStore<TEntity> GetEntityStore<TEntity>()
            where TEntity : class, new()
        {
            lock (_lock)
            {
                IEntityStore entityStore;
                Type entityType = typeof(TEntity);

                if (!_entityStoreDictionary.TryGetValue(entityType, out entityStore))
                {
                    string entityName = entityType.Name;
                    string filePath = Path.Combine(Location, entityName) + ".xml";
                    IXmlMapping xmlMapping = XmlMappingResolver.GetXmlMapping(entityType, MappingAssembly);
                    entityStore = new EntityStore<TEntity>(filePath, xmlMapping);

                    _entityStoreDictionary[entityType] = entityStore;
                }

                return (EntityStore<TEntity>)entityStore;
            }
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

        public override void Insert<TEntity>(TEntity entity)
        {
            EntityStore<TEntity> entityStore = GetEntityStore<TEntity>();
            entityStore.Insert(entity);
        }

        public override void Update<TEntity>(TEntity entity)
        {
            EntityStore<TEntity> entityStore = GetEntityStore<TEntity>();
            entityStore.Update(entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            EntityStore<TEntity> entityStore = GetEntityStore<TEntity>();
            entityStore.Delete(entity);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            EntityStore<TEntity> entityStore = GetEntityStore<TEntity>();
            return entityStore.GetAll();
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
    }
}
