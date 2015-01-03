using JJ.Framework.Common;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Persistence.Memory.Internal
{
    /// <summary>
    /// Gives access to a data store for a single entity type.
    /// </summary>
    internal class EntityStore
    {
        private IMemoryMapping _mapping;

        private Dictionary<object, object> _dictionary = new Dictionary<object, object>();
        private object _lock = new object();

        public EntityStore(Type entityType, IMemoryMapping mapping)
        {
            if (mapping == null) throw new NullException(() => mapping);
            _mapping = mapping;
        }

        public object TryGet(object id)
        {
            object entity;
            _dictionary.TryGetValue(id, out entity);
            return entity;
        }

        public TEntity Create<TEntity>()
            where TEntity : class, new()
        {
            var entity = new TEntity();
            object id = GetNewIdentity();
            SetIDOfEntity(entity, id);

            _dictionary.Add(id, entity);

            return entity;
        }

        public void Insert(object entity)
        {
            if (entity == null) throw new NullException(() => entity);

            lock (_lock)
            {
                object id = GetIDFromEntity(entity);
                _dictionary.Add(id, entity);
            }
        }

        public void Delete(object entity)
        {
            if (entity == null) throw new NullException(() => entity);

            lock (_lock)
            {
                object id = GetIDFromEntity(entity);
                _dictionary.Remove(id);
            }
        }

        public IEnumerable<TEntity> GetAll<TEntity>()
        {
            return _dictionary.Values.OfType<TEntity>();
        }

        // Identity

        private int _maxID = 0;

        private object GetIDFromEntity(object entity)
        {
            Type entityType = entity.GetType();
            PropertyInfo property = entityType.GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, entityType.Name));
            }
            return property.GetValue(entity, null);
        }

        private void SetIDOfEntity(object entity, object id)
        {
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

                default:
                    throw new ValueNotSupportedException(_mapping.IdentityType);
            }
        }
    }
}
