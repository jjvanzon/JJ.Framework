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
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, new();

        TEntity Create<TEntity>() where TEntity : class, new();
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        IEnumerable<TEntity> Query<TEntity>() where TEntity : class;

        void Commit();

        string Location { get; }
    }
}
