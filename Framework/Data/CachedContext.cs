using System;
using System.Collections.Generic;
using System.Reflection;

namespace JJ.Framework.Data
{
    /// <summary>
    /// A Context implementation that can be utilized in specific cases.
    /// It uses a temporary storage that can be committed or discarded.
    /// This provides transactions where the underlying persistence technology does not.
    /// 
    /// In the app.config or web.config, you can reference the context type
    /// a little more easily if you derive from this class and give it your own name e.g. 'MyContext'.
    /// This saves you from using a full .NET type string, which gets messy in case of type arguments.
    /// </summary>
    [Obsolete("Not obsolete, but not finished either.")]
    public class CachedContext<TTemporaryContext, TUnderlyingContext> : ContextBase
        where TTemporaryContext : IContext
        where TUnderlyingContext : IContext
    {
        private TTemporaryContext _temporaryContext;
        private TUnderlyingContext _underlyingContext;

        public CachedContext(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(location, modelAssembly, mappingAssembly, dialect) { }

        public override TEntity TryGet<TEntity>(object id)
        {
            var entity = _temporaryContext.TryGet<TEntity>(id);

            if (entity == null)
            {
                entity = _underlyingContext.TryGet<TEntity>(id);
            }

            return entity;
        }

        public override TEntity Create<TEntity>() => throw new NotImplementedException();

        public override void Insert(object entity) => throw new NotImplementedException();

        public override void Update(object entity) => throw new NotImplementedException();

        public override void Delete(object entity) => throw new NotImplementedException();

        public override IEnumerable<TEntity> Query<TEntity>() => throw new NotImplementedException();

        public override void Commit() => throw new NotImplementedException();

        public override void Flush() => throw new NotImplementedException();

        public override void Dispose() => throw new NotImplementedException();

        public override void Rollback() => throw new NotImplementedException();
    }
}