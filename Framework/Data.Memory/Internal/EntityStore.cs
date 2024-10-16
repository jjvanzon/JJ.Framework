﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.TypeChecking;
// ReSharper disable MemberCanBePrivate.Global

namespace JJ.Framework.Data.Memory.Internal
{
    // TODO: It might be simpler if you would create a different EntityStore class for each identity type.

    /// <summary>
    /// Gives access to a data store for a single entity type.
    /// </summary>
    internal class EntityStore<TEntity> : IEntityStore
        where TEntity : class, new()
    {
        private readonly IMemoryMapping _mapping;

        private readonly Dictionary<object, TEntity> _dictionary = new Dictionary<object, TEntity>();
        private readonly HashSet<TEntity> _hashSet = new HashSet<TEntity>();

        private readonly object _lock = new object();

        public EntityStore(IMemoryMapping mapping) => _mapping = mapping ?? throw new NullException(() => mapping);

        public TEntity TryGet(object id)
        {
            TEntity entity;

            lock (_lock)
            {
                _dictionary.TryGetValue(id, out entity);
            }

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

        public IList<TEntity> GetAll() => _hashSet.ToArray();

        // Identity

        private int _maxID;

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
                throw new Exception($"ID should not be automatically set for IdentityType '{_mapping.IdentityType}'.");
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

        void IEntityStore.Insert(object entity) => Insert((TEntity)entity);
        void IEntityStore.Delete(object entity) => Delete((TEntity)entity);
    }
}