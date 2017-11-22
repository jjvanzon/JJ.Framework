using JJ.Framework.Exceptions;
using System.Collections.Generic;
using System.Reflection;

namespace JJ.Framework.Data
{
	public abstract class ContextBase : IContext
	{
		public string Location { get; }
		protected Assembly ModelAssembly { get; }
		protected Assembly MappingAssembly { get; }
		protected string Dialect { get; }

		/// <param name="location">can be null or empty</param>
		/// <param name="modelAssembly">not nullable</param>
		/// <param name="mappingAssembly">nullable</param>
		/// <param name="dialect">can be null or empty</param>
		public ContextBase(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
		{
			Location = location;
			ModelAssembly = modelAssembly ?? throw new NullException(() => modelAssembly);
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