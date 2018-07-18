using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Transactions;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Reflection;

namespace JJ.Framework.Data.EntityFramework
{
    [UsedImplicitly]
    public class EntityFrameworkContext : ContextBase
    {
        private TransactionScope _transactionScope;
        //private IDbTransaction _transaction;

        public DbContext Context { get; private set; }

        public EntityFrameworkContext(string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(persistenceLocation, modelAssembly, mappingAssembly, dialect)
            => Context = OpenContext();

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
            Context.Entry(entity).State = EntityState.Modified;
        }

        public override void Delete(object entity)
        {
            if (entity == null) throw new NullException(() => entity);
            Context.Set(entity.GetType()).Remove(entity);
        }

        public override IEnumerable<TEntity> Query<TEntity>() => Context.Set<TEntity>();

        // Transactions

        private DbContext OpenContext()
        {
            _transactionScope = new TransactionScope();

            DbContext context = UnderlyingEntityFrameworkContextFactory.CreateContext(Location, MappingAssembly);
            context.Database.Connection.Open();
            //_transaction = context.Database.Connection.BeginTransaction();
            return context;
        }

        private void CloseContext(DbContext underlyingContext)
        {
            //if (_transaction != null)
            //{
            //	_transaction.Rollback();
            //}

            underlyingContext?.Dispose();

            _transactionScope?.Dispose();

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

        public override void Flush() => Context.SaveChanges();

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