using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Reflection;

namespace JJ.Framework.Data.NHibernate
{
    public class NHibernateContext : ContextBase
    {
        public ISession Session { get; private set; }

        private ISessionFactory _sessionFactory;
        private HashSet<object> _entitiesToSave = new HashSet<object>();
        private HashSet<object> _entitiesToDelete = new HashSet<object>();

        public NHibernateContext(string connectionString, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(connectionString, modelAssembly, mappingAssembly, dialect)
        {
            _sessionFactory = NHibernateSessionFactoryCache.GetSessionFactory(connectionString, modelAssembly, mappingAssembly, dialect);
            Session = OpenSession();
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            return Session.Get<TEntity>(id);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            return Session.Query<TEntity>();
        }

        public override TEntity Create<TEntity>()
        {
            TEntity entity = new TEntity();
            if (!_entitiesToSave.Contains(entity))
            {
                _entitiesToSave.Add(entity);
            }

            return entity;
        }

        public override void Insert(object entity)
        {
            Session.Save(entity);
        }

        public override void Update(object entity)
        {
            Session.Update(entity);
        }

        public override void Delete(object entity)
        {
            Session.Delete(entity);
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            return Session.Query<TEntity>();
        }

        // Transactions

        private ISession OpenSession()
        {
            ISession session = _sessionFactory.OpenSession();

            // If you do not set flush mode and call BeginTransaction, 
            // data will be committed upon disposing the session.
            session.FlushMode = FlushMode.Commit;
            session.BeginTransaction();

            return session;
        }

        private void CloseSession(ISession session)
        {
            session.Dispose();
        }

        public override void Commit()
        {
            Flush();

            if (Session.Transaction.IsActive)
            {
                Session.Transaction.Commit();
            }

            CloseSession(Session);
            Session = OpenSession();
        }

        public override void Flush()
        {
            foreach (object entity in _entitiesToDelete)
            {
                Session.Delete(entity);
            }

            foreach (object entity in _entitiesToSave)
            {
                Session.Save(entity);
            }

            Session.Flush();

            _entitiesToDelete.Clear();
            _entitiesToSave.Clear();
        }

        public override void Rollback()
        {
            _entitiesToDelete.Clear();
            _entitiesToSave.Clear();

            CloseSession(Session);
            Session = OpenSession();
        }

        public override void Dispose()
        {
            if (Session != null)
            {
                CloseSession(Session);
            }
        }
    }
}
