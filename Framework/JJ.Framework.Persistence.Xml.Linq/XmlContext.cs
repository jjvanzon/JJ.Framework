using JJ.Framework.Persistence.Xml.Linq.Internal;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace JJ.Framework.Persistence.Xml.Linq
{
    public class XmlContext : ContextBase
    {
        public XmlContext(string folderPath, Assembly modelAssembly, Assembly mappingAssembly, string dialect = null)
            : base(folderPath, modelAssembly, mappingAssembly, dialect)
        {
            if (mappingAssembly == null) throw new NullException(() => mappingAssembly);
        }

        private object _lock = new object();
        private Dictionary<Type, EntityStore> _entityStoreDictionary = new Dictionary<Type, EntityStore>();

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

        private EntityStore GetEntityStore<TEntity>()
        {
            return GetEntityStore(typeof(TEntity));
        }

        private EntityStore GetEntityStore(Type entityType)
        {
            lock (_lock)
            {
                EntityStore entityStore;

                if (!_entityStoreDictionary.TryGetValue(entityType, out entityStore))
                {
                    string entityName = entityType.Name;
                    string filePath = Path.Combine(Location, entityName) + ".xml";
                    IXmlMapping xmlMapping = XmlMappingResolver.GetXmlMapping(entityType, MappingAssembly);

                    entityStore = new EntityStore(filePath, xmlMapping);

                    _entityStoreDictionary[entityType] = entityStore;
                }

                return entityStore;
            }
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            EntityStore entityStore = GetEntityStore<TEntity>();
            return entityStore.TryGet<TEntity>(id);
        }

        public override TEntity Create<TEntity>()
        {
            EntityStore entityStore = GetEntityStore<TEntity>();
            return entityStore.Create<TEntity>();
        }

        public override void Insert(object entity)
        {
            EntityStore entityStore = GetEntityStore(entity.GetType());
            entityStore.Insert(entity);
        }

        public override void Update(object entity)
        {
            EntityStore entityStore = GetEntityStore(entity.GetType());
            entityStore.Update(entity);
        }

        public override void Delete(object entity)
        {
            EntityStore entityStore = GetEntityStore(entity.GetType());
            entityStore.Delete(entity);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            EntityStore entityStore = GetEntityStore<TEntity>();
            return entityStore.GetAll<TEntity>();
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            throw new NotSupportedException("XmlContext does not support Query<TEntity>().");
        }

        public override void Commit()
        {
            lock (_lock)
            {
                foreach (EntityStore entityStore in _entityStoreDictionary.Values)
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
