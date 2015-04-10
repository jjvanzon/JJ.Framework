using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Persistence.Memory.Internal;
using JJ.Framework.Reflection.Exceptions;

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
        private Dictionary<Type, IEntityStore> _entityStoreDictionary = new Dictionary<Type, IEntityStore>();

        private EntityStore<TEntity> GetEntityStore<TEntity>()
            where TEntity : class, new()
        {
            return (EntityStore<TEntity>)GetEntityStore(typeof(TEntity));
        }

        private IEntityStore GetEntityStore(Type entityType)
        {
            lock (_lock)
            {
                IEntityStore entityStore;

                if (!_entityStoreDictionary.TryGetValue(entityType, out entityStore))
                {
                    string entityName = entityType.Name;
                    IMemoryMapping mapping = MappingResolver.GetMapping(entityType, MappingAssembly);

                    Type entityStoreType = typeof(EntityStore<>).MakeGenericType(entityType);
                    entityStore = (IEntityStore)Activator.CreateInstance(entityStoreType, mapping);

                    _entityStoreDictionary[entityType] = entityStore;
                }

                return entityStore;
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

        public override void Insert(object entity)
        {
            if (entity == null) throw new NullException(() => entity);
            IEntityStore entityStore = GetEntityStore(entity.GetType());
            entityStore.Insert(entity);
        }

        public override void Update(object entity)
        {
            // No code required.
        }

        public override void Delete(object entity)
        {
            if (entity == null) throw new NullException(() => entity);
            IEntityStore entityStore = GetEntityStore(entity.GetType());
            entityStore.Delete(entity);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            EntityStore<TEntity> entityStore = GetEntityStore < TEntity>();
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
