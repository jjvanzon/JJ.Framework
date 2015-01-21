using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace JJ.Framework.Persistence.EntityFramework5
{
    public class EntityFramework5Context : ContextBase
    {
        private TransactionScope _transactionScope;
        //private IDbTransaction _transaction;

        public DbContext Context { get; private set; }

        public EntityFramework5Context(string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(persistenceLocation, modelAssembly, mappingAssembly, dialect)
        {
            _transactionScope = new TransactionScope();
            Context = UnderlyingEntityFramework5ContextFactory.CreateContext(persistenceLocation, modelAssembly, mappingAssembly);
            Context.Database.Connection.Open();
            //_transaction = Context.Database.Connection.BeginTransaction();
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            // EntityFramework will return an entity with ID 0 
            // if there is an uncommitted, non-flushed object,
            // which is inconsistent with other ORM's.
            // You would expect null to be returned.
            // TODO: Performance penalty?
            // TODO: I am not sure this is the right fix for this.
            if (id == null) throw new NullException(() => id);
            object defaultID = Activator.CreateInstance(id.GetType());
            if (Equals(id, defaultID))
            {
                return null;
            }

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

            //_transaction.Commit();

            _transactionScope.Complete();
            _transactionScope.Dispose();
            _transactionScope = new TransactionScope();
        }

        public override void Flush()
        {
            Context.SaveChanges();
        }

        public override void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }

            //if (_transaction != null)
            //{
            //    _transaction.Rollback();
            //}

            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
            }
        }
    }
}
