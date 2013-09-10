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
        private ISession _nhibernateSession;

        public NHibernateContext(string connectionString, Assembly modelAssembly, Assembly mappingAssembly)
            : base (connectionString, modelAssembly)
        {
            ISessionFactory sessionFactory = SessionFactoryCache.GetSessionFactory(connectionString, modelAssembly, mappingAssembly);
            _nhibernateSession = sessionFactory.OpenSession();
        }

        public override EntityWrapper<TEntity> CreateEntity<TEntity>()
        {
            TEntity entity = new TEntity();
            var entityWrapper = new EntityWrapper<TEntity>(this, entity);
            return entityWrapper;
        }

        public override EntityWrapper<TEntity> GetEntity<TEntity>(object id) 
        {
            TEntity entity = _nhibernateSession.Get<TEntity>(id);
            var entityWrapper = new EntityWrapper<TEntity>(this, entity);
            return entityWrapper;
        }

        public override EntityWrapper<TEntity> Insert<TEntity>(TEntity entity)
        {
            var entityWrapper = new EntityWrapper<TEntity>(this, entity);
            _nhibernateSession.Save(entity);
            return entityWrapper;
        }

        public override EntityWrapper<TEntity> Update<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<EntityWrapper<TEntity>> Query<TEntity>()
        {
            return _nhibernateSession.Query<TEntity>().Select(x => new EntityWrapper<TEntity>(this, x));
        }

        public override void Commit()
        {
            _nhibernateSession.Flush();
        }

        public override void Dispose()
        {
            _nhibernateSession.Dispose();
        }
    }
}
