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

        public override EntityWrapper<TEntity> CreateEntity<TEntity>()
        {
            TEntity entity = new TEntity();
            _session.Save(entity);
            return CreateWrapper(entity);
        }

        public override EntityWrapper<TEntity> GetEntity<TEntity>(object id) 
        {
            TEntity entity = _session.Get<TEntity>(id);
            return CreateWrapper(entity);
        }

        public override IEnumerable<EntityWrapper<TEntity>> GetEntities<TEntity>()
        {
            return _session.Query<TEntity>().Select(x => new EntityWrapper<TEntity>(this, x));
        }

        public override EntityWrapper<TEntity> Insert<TEntity>(TEntity entity)
        {
            _session.Save(entity);
            return CreateWrapper(entity);
        }

        public override EntityWrapper<TEntity> Update<TEntity>(TEntity entity)
        {
            _session.Update(entity);
            return CreateWrapper(entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            _session.Delete(entity);
        }

        public override IEnumerable<EntityWrapper<TEntity>> Query<TEntity>()
        {
            return _session.Query<TEntity>().Select(x => new EntityWrapper<TEntity>(this, x));
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

        private EntityWrapper<TEntity> CreateWrapper<TEntity>(TEntity entity)
        {
            var entityWrapper = new EntityWrapper<TEntity>(this, entity);
            return entityWrapper;
        }
    }
}
