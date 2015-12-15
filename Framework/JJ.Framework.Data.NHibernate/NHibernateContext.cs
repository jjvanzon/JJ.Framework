using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using System.Reflection;
using JJ.Framework.Reflection.Exceptions;
using NHibernate.Persister.Entity;

namespace JJ.Framework.Data.NHibernate
{
    public class NHibernateContext : ContextBase
    {
        public ISession Session { get; private set; }

        private ISessionFactory _sessionFactory;
        private HashSet<object> _entitiesToSave = new HashSet<object>();

        /// <summary>
        /// This EntityDictionary is invented to be able to get uncommitted, non-flushed entities by ID,
        /// without calling NHibernate 'Save',
        /// which takes a snapshot of the current state of the entity which ignores subsequent changes to the entity.
        /// </summary>
        private EntityDictionary _entityDictionary = new EntityDictionary();

        public NHibernateContext(string connectionString, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(connectionString, modelAssembly, mappingAssembly, dialect)
        {
            _sessionFactory = NHibernateSessionFactoryCache.GetSessionFactory(connectionString, modelAssembly, mappingAssembly, dialect);
            Session = OpenSession();
        }

        public override TEntity TryGet<TEntity>(object id)
        {
            TEntity entity = _entityDictionary.TryGet<TEntity>(id);
            if (entity != null)
            {
                return entity;
            }

            entity = Session.Get<TEntity>(id);

            _entityDictionary.AddOrReplaceIfNeeded<TEntity>(id, entity);

            return entity;
        }

        public override IList<TEntity> GetAll<TEntity>()
        {
            return Session.QueryOver<TEntity>().List();
        }

        public override TEntity Create<TEntity>()
        {
            TEntity entity = new TEntity();

            if (!_entitiesToSave.Contains(entity))
            {
                _entitiesToSave.Add(entity);
            }

            object id = GetID(entity);
            _entityDictionary.AddOrReplaceIfNeeded<TEntity>(id, entity);

            return entity;
        }

        public override void Insert(object entity)
        {
            if (!_entitiesToSave.Contains(entity))
            {
                _entitiesToSave.Add(entity);
            }

            object id = GetID(entity);
            _entityDictionary.AddOrReplaceIfNeeded(id, entity);
        }

        public override void Update(object entity)
        {
            // No code required.
        }

        public override void Delete(object entity)
        {
            Session.Delete(entity);

            if (!_entitiesToSave.Contains(entity))
            {
                _entitiesToSave.Remove(entity);
            }

            object id = GetID(entity);
            _entityDictionary.TryRemove(entity, id);
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
            foreach (object entity in _entitiesToSave)
            {
                Session.Save(entity);
            }

            Session.Flush();

            _entitiesToSave.Clear();
            _entityDictionary.Clear();
        }

        public override void Rollback()
        {
            _entitiesToSave.Clear();
            _entityDictionary.Clear();

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

        // Helpers

        private object GetID(object obj)
        {
            // TODO: Trying to use what happens here in NHibernte:
            //
            //      AbstractEntityTuplizer.GetIdentifier(...
            //      {
            //          ... entityMetamodel.IdentifierProperty
            //      }
            //
            // You could get use a PropertyInfo which is probably faster than the code below.

            // By the way: this is kind a hack to get to the Identity property using the mappings consumed by NHibernate. 
            // The code was based on debugging through NHibernate to see what I could tap into.

            if (obj == null) throw new NullException(() => obj);

            var sessionImplementor = Session as global::NHibernate.Engine.ISessionImplementor;
            if (sessionImplementor == null)
            {
                throw new Exception("Session is not an ISessionImplementor.");
            }

            string entityTypeName = GetEntityTypeName(obj);

            IEntityPersister entityPersister = sessionImplementor.GetEntityPersister(entityTypeName, obj);

            if (entityPersister == null)
            {
                throw new Exception("sessionImplementor.GetEntityPersister returned null.");
            }

            object id = entityPersister.GetIdentifier(obj, EntityMode.Poco);
            return id;
        }

        private string GetEntityTypeName(object obj)
        {
            // All very hacky. Internally NHibernate can resolve this better, 
            // but the entityName parameter is passed around so much and are determined in places that I find hard to reach / that I do not understand.
            Type type = obj.GetType();

            bool isProxy = obj is global::NHibernate.Proxy.INHibernateProxy;
            if (isProxy)
            {
                type = type.BaseType;
            }

            return type.FullName;
        }
    }
}
