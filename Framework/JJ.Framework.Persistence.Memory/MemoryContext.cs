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
        private Dictionary<Type, object> _entityStoreDictionary = new Dictionary<Type, object>();

        private EntityStore<TEntity> GetEntityStore<TEntity>()
            where TEntity : class, new()
        {
            lock (_lock)
            {
                object entityStore;
                Type entityType = typeof(TEntity);

                if (!_entityStoreDictionary.TryGetValue(entityType, out entityStore))
                {
                    string entityName = entityType.Name;
                    IMemoryMapping mapping = MappingResolver.GetMapping(entityType, MappingAssembly);
                    entityStore = new EntityStore<TEntity>(mapping);

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
            // No code required.
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
