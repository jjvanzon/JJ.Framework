using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Persistence.EntityFramework5
{
    public class EntityFramework5Context : ContextBase
    {
        public DbContext Context { get; private set; }

        public EntityFramework5Context(string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(persistenceLocation, modelAssembly, mappingAssembly, dialect)
        {
            Context = UnderlyingEntityFramework5ContextFactory.CreateContext(persistenceLocation, modelAssembly, mappingAssembly);
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            return Context.Set<TEntity>();
        }

        public override TEntity Create<TEntity>()
        {
            var entity = new TEntity();
            Context.Set<TEntity>().Add(entity);
            return entity;
        }

        public override void Insert(object entity)
        {
            if (entity == null) throw new NullException(() => entity);
            Context.Set(entity.GetType()).Add(entity);
        }

        public override void Update(object entity)
        {
            if (entity == null) throw new NullException(() => entity);
            Context.Entry(entity.GetType()).State = EntityState.Modified;
        }

        public override void Delete(object entity)
        {
            if (entity == null) throw new NullException(() => entity);
            Context.Set(entity.GetType()).Remove(entity);
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            return Context.Set<TEntity>();
        }

        public override void Commit()
        {
            Context.SaveChanges();
        }

        public override void Flush()
        {
            // TODO: Is there an EntityFramework5 equivalent of an NHibernate Flush()?
        }

        public override void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
