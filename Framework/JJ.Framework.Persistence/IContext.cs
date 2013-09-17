using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    public interface IContext : IDisposable
    {
        EntityWrapper<TEntity> GetEntity<TEntity>(object id) where TEntity : class, new();
        IEnumerable<EntityWrapper<TEntity>> GetEntities<TEntity>() where TEntity : class, new();

        EntityWrapper<TEntity> CreateEntity<TEntity>() where TEntity : class, new();
        EntityWrapper<TEntity> Insert<TEntity>(TEntity entity) where TEntity : class;
        EntityWrapper<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        IEnumerable<EntityWrapper<TEntity>> Query<TEntity>() where TEntity : class;

        void Commit();
    }
}
