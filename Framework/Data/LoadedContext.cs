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
    [Obsolete("Not obsolete, but not finished either.")]
    public class LoadedContext<TUnderlyingContext> : ContextBase
        where TUnderlyingContext : IContext
    {
        protected LoadedContext(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(location, modelAssembly, mappingAssembly, dialect) { }

        public override TEntity TryGet<TEntity>(object id) => throw new NotImplementedException();

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