using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Persistence.Memory.Internal;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence.Memory
{
    public class MemoryContext : ContextBase
    {
        /// <param name="location">nullable</param>
        public MemoryContext(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect = null)
            : base(location, modelAssembly, mappingAssembly, dialect)
        {
            if (mappingAssembly == null) throw new NullException(() => mappingAssembly);
        }

        private object _lock = new object();
        private Dictionary<Type, EntityStore> _entityStoreDictionary = new Dictionary<Type, EntityStore>();

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
                    IMemoryMapping mapping = MappingResolver.GetMapping(entityType, MappingAssembly);
                    entityStore = new EntityStore(entityType, mapping);

                    _entityStoreDictionary[entityType] = entityStore;
                }

                return entityStore;
            }
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            EntityStore entityStore = GetEntityStore<TEntity>();
            return (TEntity)entityStore.TryGet(id);
        }

        public override TEntity Create<TEntity>()
        {
            EntityStore entityStore = GetEntityStore<TEntity>();
            return entityStore.Create<TEntity>();
        }

        public override void Insert(object entity)
        {
            if (entity == null) throw new NullException(() => entity);
            EntityStore entityStore = GetEntityStore(entity.GetType());
            entityStore.Insert(entity);
        }

        public override void Update(object entity)
        {
            // No code required.
        }

        public override void Delete(object entity)
        {
            if (entity == null) throw new NullException(() => entity);
            EntityStore entityStore = GetEntityStore(entity.GetType());
            entityStore.Delete(entity);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            EntityStore entityStore = GetEntityStore(typeof(TEntity));
            return entityStore.GetAll<TEntity>();
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            throw new NotSupportedException("MemoryContext does not support Query<TEntity>().");
        }

        public override void Commit()
        {
            // No code required.
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
