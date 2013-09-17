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

        public NHibernateContext(string connectionString, params Assembly[] modelAssemblies)
            : base(connectionString, modelAssemblies)
        {
            ISessionFactory sessionFactory = NHibernateSessionFactoryCache.GetSessionFactory(connectionString, modelAssemblies);
            _session = sessionFactory.OpenSession();
        }

        public override TEntity Get<TEntity>(object id)
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
            _session.Save(entity);
            return entity;
        }

        public override void Insert<TEntity>(TEntity entity)
        {
            _session.Save(entity);
        }

        public override void Update<TEntity>(TEntity entity)
        {
            _session.Update(entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            _session.Delete(entity);
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            return _session.Query<TEntity>();
        }

        public override void Commit()
        {
            _session.Flush();
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
