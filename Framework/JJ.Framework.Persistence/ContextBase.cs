using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence
{
    public abstract class ContextBase : IContext
    {
        public string Location { get; private set; }
        protected Assembly ModelAssembly { get; private set; }
        protected Assembly MappingAssembly { get; private set; }

        /// <param name="location"></param>
        /// <param name="modelAssembly">not nullable</param>
        /// <param name="mappingAssembly">nullable</param>
        public ContextBase(string location, Assembly modelAssembly, Assembly mappingAssembly)
        {
            if (modelAssembly == null) throw new ArgumentNullException("modelAssembly");

            Location = location;
            ModelAssembly = modelAssembly;
            MappingAssembly = mappingAssembly;
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
        public abstract void Insert<TEntity>(TEntity entity) where TEntity : class, new();
        public abstract void Update<TEntity>(TEntity entity) where TEntity : class, new();
        public abstract void Delete<TEntity>(TEntity entity) where TEntity : class, new();
        public abstract IEnumerable<TEntity> Query<TEntity>() where TEntity : class, new();
        public abstract void Commit();
        public abstract void Dispose();
    }
}