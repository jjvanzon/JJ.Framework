using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using System.Reflection;

namespace JJ.Framework.Persistence.NHibernate
{
    public class NHibernateContext : ContextBase
    {
        private ISession _session;
        private ITransaction _transaction;

        private HashSet<object> _entitiesToSave = new HashSet<object>();
        private HashSet<object> _entitiesToDelete = new HashSet<object>();

        public NHibernateContext(string connectionString, params Assembly[] modelAssemblies)
            : base(connectionString, modelAssemblies)
        {
            ISessionFactory sessionFactory = NHibernateSessionFactoryCache.GetSessionFactory(connectionString, modelAssemblies);
            _session = sessionFactory.OpenSession();
            //_transaction = _session.BeginTransaction();
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            return _session.Get<TEntity>(id);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            return _session.Query<TEntity>();
        }

        public override TEntity Create<TEntity>()
        {
            TEntity entity = new TEntity();
            //_session.Save(entity);
            if (!_entitiesToSave.Contains(entity))
            {
                _entitiesToSave.Add(entity);
            }
            return entity;
        }

        public override void Insert<TEntity>(TEntity entity)
        {
            _session.Save(entity);
            /*if (!_entitiesToSave.Contains(entity))
            {
                _entitiesToSave.Add(entity);
            }*/
        }

        public override void Update<TEntity>(TEntity entity)
        {
            _session.Update(entity);
            /*if (!_entitiesToSave.Contains(entity))
            {
                _entitiesToSave.Add(entity);
            }*/
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            _session.Delete(entity);
            /*if (!_entitiesToDelete.Contains(entity))
            {
                _entitiesToDelete.Add(entity);
            }*/
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            return _session.Query<TEntity>();
        }

        public override void Commit()
        {
            foreach (object entity in _entitiesToDelete)
            {
                _session.Delete(entity);
            }

            foreach (object entity in _entitiesToSave)
            {
                _session.Save(entity);
            }

            //_transaction.Commit();

            _session.Flush();

            _entitiesToDelete.Clear();
            _entitiesToSave.Clear();
        }

        public override void Dispose()
        {
            if (_session != null)
            {
                _session.Dispose();
            }
        }
    }
}
