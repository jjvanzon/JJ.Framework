using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Persistence.Memory.Internal
{
    internal class EntityStore<TEntity>
        where TEntity : class, new()
    {
        private IMemoryMapping _mapping;

        private Dictionary<object, TEntity> _dictionary = new Dictionary<object, TEntity>();
        private object _lock = new object();

        public EntityStore(IMemoryMapping mapping)
        {
            if (mapping == null) throw new ArgumentNullException("mapping");
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
            object id = GetNewIdentity();
            SetIDOfEntity(entity, id);

            _dictionary.Add(id, entity);

            return entity;
        }

        public void Insert(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            lock (_lock)
            {
                object id = GetIDFromEntity(entity);
                _dictionary.Add(id, entity);
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            lock (_lock)
            {
                object id = GetIDFromEntity(entity);
                _dictionary.Remove(id);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dictionary.Values;
        }

        // Identity

        private object GetIDFromEntity(TEntity entity)
        {
            PropertyInfo property = typeof(TEntity).GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, typeof(TEntity).Name));
            }
            return property.GetValue(entity, null);
        }

        private void SetIDOfEntity(TEntity entity, object id)
        {
            PropertyInfo property = typeof(TEntity).GetProperty(_mapping.IdentityPropertyName);
            if (property == null)
            {
                throw new Exception(String.Format("Property '{0}' not found on type '{1}'.", _mapping.IdentityPropertyName, typeof(TEntity).Name));
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

        private int _maxID = 0;
    }
}
