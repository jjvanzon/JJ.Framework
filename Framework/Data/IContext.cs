using System;
using System.Collections.Generic;

namespace JJ.Framework.Data
{
    public interface IContext : IDisposable
    {
        TEntity Get<TEntity>(object id) where TEntity : class, new();
        TEntity TryGet<TEntity>(object id) where TEntity : class, new();

        TEntity Create<TEntity>() where TEntity : class, new();
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);

        IEnumerable<TEntity> Query<TEntity>() where TEntity : class, new();

        void Commit();
        void Flush();

        string Location { get; }

        void Rollback();
    }
}
