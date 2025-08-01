﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Reflection;

namespace JJ.Framework.Persistence.Legacy.NHibernate
{
    public class NHibernateContext : ContextBase
    {
        public ISession Session { get; private set; }

        private HashSet<object> _entitiesToSave = new HashSet<object>();
        private HashSet<object> _entitiesToDelete = new HashSet<object>();

        public NHibernateContext(string connectionString, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(connectionString, modelAssembly, mappingAssembly, dialect)
        {
            ISessionFactory sessionFactory = NHibernateSessionFactoryCache.GetSessionFactory(connectionString, modelAssembly, mappingAssembly, dialect);
            Session = sessionFactory.OpenSession();
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

        public override void Commit()
        {
            Flush();

            #pragma warning disable CS0618 // Obsolete: ISession.Transaction
            if (Session.Transaction.IsActive)
            {
                Session.Transaction.Commit();
            }
            #pragma warning restore CS0618

            _entitiesToDelete.Clear();
            _entitiesToSave.Clear();
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
        }

        public override void Dispose()
        {
            if (Session != null)
            {
                Session.Dispose();
            }
        }
    }
}
