using JJ.Framework.Reflection;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace JJ.Framework.Data.EntityFramework5
{
    public class EntityFramework5Context : ContextBase
    {
        private TransactionScope _transactionScope;
        //private IDbTransaction _transaction;

        public DbContext Context { get; private set; }

        public EntityFramework5Context(string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(persistenceLocation, modelAssembly, mappingAssembly, dialect)
        {
            Context = OpenContext();
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

            bool isDefault = ReflectionHelper.IsDefault(id);
            if (isDefault)
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

        // Transactions

        private DbContext OpenContext()
        {
            _transactionScope = new TransactionScope();

            DbContext context = UnderlyingEntityFramework5ContextFactory.CreateContext(Location, ModelAssembly, MappingAssembly);
            context.Database.Connection.Open();
            //_transaction = context.Database.Connection.BeginTransaction();
            return context;
        }

        // TODO:
        // Warning CA1801  Parameter 'underlyingContext' of 'EntityFramework5Context.CloseContext(DbContext)' is never used.Remove the parameter or use it in the method body.
        private void CloseContext(DbContext underlyingContext)
        {
            //if (_transaction != null)
            //{
            //    _transaction.Rollback();
            //}

            if (Context != null)
            {
                Context.Dispose();
            }

            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
            }

            Context = null;
            _transactionScope = null;
        }

        public override void Commit()
        {
            Flush();

            //_transaction.Commit();
            _transactionScope.Complete();

            CloseContext(Context);
            Context = OpenContext();
        }

        public override void Flush()
        {
            Context.SaveChanges();
        }

        public override void Rollback()
        {
            CloseContext(Context);
            Context = OpenContext();
        }

        public override void Dispose()
        {
            if (Context != null)
            {
                CloseContext(Context);
            }
        }
    }
}
