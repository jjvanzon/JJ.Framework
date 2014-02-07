using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    public interface IContext : IDisposable
    {
        TEntity Get<TEntity>(object id) where TEntity : class, new();
        TEntity TryGet<TEntity>(object id) where TEntity : class, new();

        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, new();

        TEntity Create<TEntity>() where TEntity : class, new();
        void Insert<TEntity>(TEntity entity) where TEntity : class, new();
        void Update<TEntity>(TEntity entity) where TEntity : class, new();
        void Delete<TEntity>(TEntity entity) where TEntity : class, new();

        IEnumerable<TEntity> Query<TEntity>() where TEntity : class, new();

        void Commit();

        string Location { get; }
    }
}
