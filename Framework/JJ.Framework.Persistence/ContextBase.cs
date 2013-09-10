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
        public ContextBase(string persistenceLocation, Assembly modelAssembly)
        { }

        public abstract EntityWrapper<TEntity> GetEntity<TEntity>(object id) where TEntity : new();
        public abstract EntityWrapper<TEntity> CreateEntity<TEntity>() where TEntity : new();
        public abstract EntityWrapper<TEntity> Insert<TEntity>(TEntity entity);
        public abstract EntityWrapper<TEntity> Update<TEntity>(TEntity entity);
        public abstract IEnumerable<EntityWrapper<TEntity>> Query<TEntity>();

        public abstract void Commit();

        public abstract void Dispose();
    }
}
