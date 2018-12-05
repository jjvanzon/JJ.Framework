using System;
using System.Collections.Generic;
using System.Reflection;

namespace JJ.Framework.Data
{
    /// <summary>
    /// A Context implementation that can be utilized in specific cases.
    /// It allows you to specify a procedure that is supposed to load a context completely with data,
    /// for instance by deserializing object structures from data stores,
    /// or fully indexing entities from the data store into dictionaries.
    /// </summary>
    public class LoadedContext : ContextBase
    {
        private readonly IContext _underlyingContext;
        private readonly Action _loadDelegate;

        public LoadedContext(IContext underlyingContext, Action loadDelegate)
            : base(default, default, default, default)
        {
            _underlyingContext = underlyingContext ?? throw new ArgumentNullException(nameof(underlyingContext));
            _loadDelegate = loadDelegate ?? throw new ArgumentNullException(nameof(loadDelegate));

            _loadDelegate();
        }

        public override TEntity TryGet<TEntity>(object id) => _underlyingContext.TryGet<TEntity>(id);

        public override TEntity Create<TEntity>() => _underlyingContext.Create<TEntity>();

        public override void Insert(object entity) => _underlyingContext.Insert(entity);

        public override void Update(object entity) => _underlyingContext.Update(entity);

        public override void Delete(object entity) => _underlyingContext.Delete(entity);

        public override IEnumerable<TEntity> Query<TEntity>() => _underlyingContext.Query<TEntity>();

        public override void Commit()
        {
            _underlyingContext.Commit();

            // TODO: SaveDelegate?
        }

        public override void Flush() { }

        public override void Rollback() => throw new NotImplementedException();

        public override void Dispose() => Rollback();
    }
}