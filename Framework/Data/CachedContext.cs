using System;
using System.Collections.Generic;
using System.Linq;

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
    public class CachedContext : ContextBase
    {
        private readonly IContext _temporaryContext;
        private readonly IContext _underlyingContext;

        public CachedContext(IContext temporaryContext, IContext underlyingContext)
            : base(default, default, default, default)
        {
            _temporaryContext = temporaryContext ?? throw new ArgumentNullException(nameof(temporaryContext));
            _underlyingContext = underlyingContext ?? throw new ArgumentNullException(nameof(underlyingContext));
        }

        public override TEntity TryGet<TEntity>(object id)
            => _temporaryContext.TryGet<TEntity>(id) ??
               _underlyingContext.TryGet<TEntity>(id);

        public override TEntity Create<TEntity>() => _temporaryContext.Create<TEntity>();

        public override void Insert(object entity) => _temporaryContext.Insert(entity);

        public override void Update(object entity) => _temporaryContext.Update(entity);

        public override void Delete(object entity) => _temporaryContext.Delete(entity);

        public override IEnumerable<TEntity> Query<TEntity>()
            => _temporaryContext.Query<TEntity>().Union(_underlyingContext.Query<TEntity>());

        public override void Rollback()
        {
            // TODO: Clear the temporary context.
        }

        public override void Commit()
        {
            // TODO: transfer objects from temporary context to underlying context.
            // Whoops. Thinking error. It's not just loose objects you have to think about.
            // Graph changes should be cached too.
        }

        public override void Flush()
        {
            // No implementation needed.
        }

        /// <summary> Always rollback in the base class? </summary>
        public override void Dispose() => Rollback();
    }
}