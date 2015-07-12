using JJ.Framework.Common;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Data.Memory.Internal
{
    // TODO: It might be simpler if you would create a different EntityStore class for each identity type.

    /// <summary>
    /// Gives access to a data store for a single entity type.
    /// </summary>
    internal class EntityStore<TEntity> : IEntityStore
        where TEntity : class, new()
    {
        private IMemoryMapping _mapping;

        private Dictionary<object, TEntity> _dictionary = new Dictionary<object, TEntity>();
        private HashSet<TEntity> _hashSet = new HashSet<TEntity>();

        private object _lock = new object();

        public EntityStore(IMemoryMapping mapping)
        {
            if (mapping == null) throw new NullException(() => mapping);
            _mapping = mapping;
        }

        public TEntity TryGet(object id)
        {
            TEntity entity;
            _dictionary.TryGetValue(id, out entity);
            return entity;
        }

        public TEntity Create()
        {
            var entity = new TEntity();

            object id = TryGetNewIdentity();
            if (id != null)
            {
                SetIDOfEntity(entity, id);
            }

            lock (_lock)
            {
                _hashSet.Add(entity);
                if (id != null)
                {
                    _dictionary.Add(id, entity);
                }
            }

            return entity;
        }

        /// <summary>
        /// This method might never have been tested. 
        /// </summary>
        public void Insert(TEntity entity)
        {
            if (entity == null) throw new NullException(() => entity);

            object id = TryGetIDFromEntity(entity);

            lock (_lock)
            {
                _hashSet.Add(entity);
                if (id != null)
                {
                    _dictionary.Add(id, entity);
                }
            }
        }

        /// <summary>
        /// This method might never have been tested. 
        /// </summary>
        public void Delete(TEntity entity)
        {
            if (entity == null) throw new NullException(() => entity);

            object id = TryGetIDFromEntity(entity);

            lock (_lock)
            {
                _hashSet.Remove(entity);
                if (id != null)
                {
                    _dictionary.Remove(id);
                }
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            foreach (TEntity entity in _hashSet)
            {
                yield return entity;
            }
        }

        // Identity

        private int _maxID = 0;

        /// <summary>
        /// This method might never have been tested. 
        /// </summary>
        private object TryGetIDFromEntity(TEntity entity)
        {
            if (_mapping.IdentityType == IdentityType.NoIDs)
            {
                return null;
            }

            PropertyInfo property = GetIdentityProperty(entity);
            return property.GetValue(entity, null);
        }

        private void SetIDOfEntity(TEntity entity, object id)
        {
            if (_mapping.IdentityType != IdentityType.AutoIncrement)
            {
                throw new Exception(String.Format("ID should no be automatically set for IdentityType '{0}'.", _mapping.IdentityType));
            }

            PropertyInfo property = GetIdentityProperty(entity);
            property.SetValue(entity, id, null);
        }

        public object TryGetNewIdentity()
        {
            if (_mapping.IdentityType != IdentityType.AutoIncrement)
            {
                return null;
            }

            return ++_maxID;
        }

        private PropertyInfo GetIdentityProperty(TEntity entity)
        {
            Type entityType = entity.GetType();

            PropertyInfo property = entityType.GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new PropertyNotFoundException(entityType, _mapping.IdentityPropertyName);
            }
            return property;
        }

        // IEntityStore

        void IEntityStore.Insert(object entity)
        {
            Insert((TEntity)entity);
        }

        void IEntityStore.Delete(object entity)
        {
            Delete((TEntity)entity);
        }
    }
}
