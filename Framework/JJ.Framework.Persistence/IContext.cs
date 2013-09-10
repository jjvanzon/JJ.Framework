using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    public interface IContext : IDisposable
    {
        EntityWrapper<TEntity> GetEntity<TEntity>(object id) where TEntity : new();
        EntityWrapper<TEntity> CreateEntity<TEntity>() where TEntity : new();
        EntityWrapper<TEntity> Insert<TEntity>(TEntity entity);
        EntityWrapper<TEntity> Update<TEntity>(TEntity entity);
        IEnumerable<EntityWrapper<TEntity>> Query<TEntity>();

        void Commit();
    }
}
