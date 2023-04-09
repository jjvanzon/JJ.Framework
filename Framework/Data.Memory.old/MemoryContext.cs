using System;
using System.Collections.Generic;
using System.Reflection;
using JJ.Framework.Data.Memory.Internal;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Data.Memory
{
    public class MemoryContext : ContextBase
    {
        /// <param name="location">nullable</param>
        public MemoryContext(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect = null)
            : base(location, modelAssembly, mappingAssembly, dialect)
        {
            if (mappingAssembly == null) throw new NullException(() => mappingAssembly);
        }

        private readonly object _lock = new object();
        private readonly Dictionary<Type, IEntityStore> _entityStoreDictionary = new Dictionary<Type, IEntityStore>();

        private EntityStore<TEntity> GetEntityStore<TEntity>() where TEntity : class, new()
            => (EntityStore<TEntity>)GetEntityStore(typeof(TEntity));

        private IEntityStore GetEntityStore(Type entityType)
        {
            lock (_lock)
            {
                if (!_entityStoreDictionary.TryGetValue(entityType, out IEntityStore entityStore))
                {
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

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            EntityStore<TEntity> entityStore = GetEntityStore<TEntity>();
            return entityStore.GetAll();
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

        public override void Rollback()
        {
            // No code required.
        }
    }
}