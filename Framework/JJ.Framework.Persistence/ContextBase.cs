using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    public abstract class ContextBase : IContext
    {
        public ContextBase(string persistenceLocation, params Assembly[] modelAssemblies)
        { }

        public abstract EntityWrapper<TEntity> GetEntity<TEntity>(object id) where TEntity : class, new();
        public abstract IEnumerable<EntityWrapper<TEntity>> GetEntities<TEntity>() where TEntity : class, new();

        public abstract EntityWrapper<TEntity> CreateEntity<TEntity>() where TEntity : class, new();
        public abstract EntityWrapper<TEntity> Insert<TEntity>(TEntity entity) where TEntity : class;
        public abstract EntityWrapper<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        public abstract void Delete<TEntity>(TEntity entity) where TEntity : class;

        public abstract IEnumerable<EntityWrapper<TEntity>> Query<TEntity>() where TEntity : class;

        public abstract void Commit();

        public abstract void Dispose();
    }
}
