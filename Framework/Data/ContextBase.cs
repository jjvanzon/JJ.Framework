using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection;
using JJ.Framework.Common;
using JJ.Framework.Common.Exceptions;

namespace JJ.Framework.Data
{
    public abstract class ContextBase : IContext
    {
        public string Location { get; private set; }
        protected Assembly ModelAssembly { get; private set; }
        protected Assembly MappingAssembly { get; private set; }
        protected string Dialect { get; private set; }

        /// <param name="location">can be null or empty</param>
        /// <param name="modelAssembly">not nullable</param>
        /// <param name="mappingAssembly">nullable</param>
        /// <param name="dialect">can be null or empty</param>
        public ContextBase(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
        {
            if (modelAssembly == null) throw new NullException(() => modelAssembly);

            Location = location;
            ModelAssembly = modelAssembly;
            MappingAssembly = mappingAssembly;
            Dialect = dialect;
        }

        public virtual TEntity Get<TEntity>(object id) where TEntity : class, new()
        {
            TEntity entity = TryGet<TEntity>(id);

            if (entity == null)
            {
                throw new NotFoundException<TEntity>(id);
            }

            return entity;
        }

        public abstract TEntity TryGet<TEntity>(object id) where TEntity : class, new();
        public abstract IList<TEntity> GetAll<TEntity>() where TEntity : class, new();
        public abstract TEntity Create<TEntity>() where TEntity : class, new();
        public abstract void Insert(object entity);
        public abstract void Update(object entity);
        public abstract void Delete(object entity);
        public abstract IEnumerable<TEntity> Query<TEntity>() where TEntity : class, new();
        public abstract void Commit();
        public abstract void Flush();
        public abstract void Dispose();
        public abstract void Rollback();
    }
}