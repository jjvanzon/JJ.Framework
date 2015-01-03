using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Persistence
{
    public abstract class ContextBaseWithoutEntityStatusManagement : IContext
    {
        public string Location { get; private set; }
        protected Assembly ModelAssembly { get; private set; }
        protected Assembly MappingAssembly { get; private set; }
        protected string Dialect { get; private set; }

        /// <param name="location">can be null or empty</param>
        /// <param name="modelAssembly">not nullable</param>
        /// <param name="mappingAssembly">nullable</param>
        /// <param name="dialect">can be null or empty</param>
        public ContextBaseWithoutEntityStatusManagement(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
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
                throw new Exception(String.Format("Entity of type '{0}' with ID '{1}' not found.", typeof(TEntity).Name, id));
            }

            return entity;
        }

        public abstract TEntity TryGet<TEntity>(object id) where TEntity : class, new();
        public abstract IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, new();
        public abstract TEntity Create<TEntity>() where TEntity : class, new();
        public abstract void Insert(object entity);
        public abstract void Update(object entity);
        public abstract void Delete(object entity);
        public abstract IEnumerable<TEntity> Query<TEntity>() where TEntity : class, new();
        public abstract void Commit();
        public abstract void Flush();
        public abstract void Dispose();

        public abstract bool IsDirty(object entity);
        public abstract bool IsNew(object entity);
        public abstract bool IsDeleted(object entity);
        public abstract bool PropertyIsDirty<T>(Expression<Func<T>> propertyExpression);

        public abstract void SetPropertyIsDirty<T>(Expression<Func<T>> propertyExpression);
        public virtual bool PropertyIsDirtyIsSetAutomatically { get { return false; } }
        public virtual bool IsNewIsSetAutomatically { get { return false; } }
        public abstract void SetIsNew(object entity);
    }
}