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

        /// <summary>
        /// Flush might execute all pending (insert, update) statements to the datastore,
        /// without actually committing the transaction.
        /// ALWAYS add comment explaining why you flush, for instance: Need datastore generated ID's for reason x,
        /// or: LINQ query later must retrieve stuff by alternative keys that were changed.
        /// </summary>
        void Flush();

        string Location { get; }

        void Rollback();
    }
}
