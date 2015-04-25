using JJ.Framework.Common;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Data.Memory.Internal
{
    /// <summary>
    /// Gives access to a data store for a single entity type.
    /// </summary>
    internal class EntityStore<TEntity> : IEntityStore
        where TEntity : class, new()
    {
        private IMemoryMapping _mapping;

        private Dictionary<object, TEntity> _dictionary = new Dictionary<object, TEntity>();
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
            TEntity entity = new TEntity();
            object id = GetNewIdentity();
            SetIDOfEntity(entity, id);

            _dictionary.Add(id, entity);

            return entity;
        }

        public void Insert(TEntity entity)
        {
            if (entity == null) throw new NullException(() => entity);

            lock (_lock)
            {
                object id = GetIDFromEntity(entity);
                _dictionary.Add(id, entity);
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new NullException(() => entity);

            lock (_lock)
            {
                object id = GetIDFromEntity(entity);
                _dictionary.Remove(id);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dictionary.Values.OfType<TEntity>();
        }

        // Identity

        private int _maxID = 0;

        private object GetIDFromEntity(TEntity entity)
        {
            if (_mapping.IdentityType == IdentityType.NoIDs)
            {
                return null;
            }

            Type entityType = entity.GetType();
            PropertyInfo property = entityType.GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, entityType.Name));
            }
            return property.GetValue(entity, null);
        }

        private void SetIDOfEntity(TEntity entity, object id)
        {
            if (_mapping.IdentityType == IdentityType.NoIDs)
            {
                return;
            }

            Type entityType = entity.GetType();

            PropertyInfo property = entityType.GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, entityType.Name));
            }
            property.SetValue(entity, id, null);
        }

        public object GetNewIdentity()
        {
            switch (_mapping.IdentityType)
            {
                case IdentityType.AutoIncrement:
                    _maxID++;
                    return _maxID;

                case IdentityType.NoIDs:
                    // Auto-increment anyway, otherwise the entity dictionaries will not work.
                    _maxID++;
                    return _maxID;

                default:
                    throw new ValueNotSupportedException(_mapping.IdentityType);
            }
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
