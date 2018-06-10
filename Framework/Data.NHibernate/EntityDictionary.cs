using System;
using System.Collections.Generic;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Data.NHibernate
{
	internal class EntityDictionary
	{
		/// <summary>
		/// Dictionary of dictionaries.
		/// The first level is the entity Type, second level's key is the entity ID.
		/// Value is the entity object.
		/// </summary>
		private readonly Dictionary<Type, Dictionary<object, object>> _entityDictionary = new Dictionary<Type, Dictionary<object, object>>();

		public TEntity TryGet<TEntity>(object id)
			where TEntity : class
		{
			if (!_entityDictionary.TryGetValue(typeof(TEntity), out Dictionary<object, object> nestedDictionary))
			{
				return null;
			}

			if (!nestedDictionary.TryGetValue(id, out object entityObject))
			{
				return null;
			}

			return (TEntity)entityObject;
		}

		/// <summary>
		/// 'IfNeeded' means: entity is not null, id is not default(TID).
		/// </summary>
		public void AddOrReplaceIfNeeded(object id, object entity)
		{
			if (entity == null) throw new NullException(() => entity);
			Type type = entity.GetType();

			AddOrReplaceIfNeeded(type, id, entity);
		}

		/// <summary>
		/// 'IfNeeded' means: entity is not null, id is not default(TID).
		/// </summary>
		public void AddOrReplaceIfNeeded<TEntity>(object id, TEntity entity) => AddOrReplaceIfNeeded(typeof(TEntity), id, entity);

	    /// <summary>
		/// 'IfNeeded' means: entity is not null, id is not default(TID).
		/// </summary>
		private void AddOrReplaceIfNeeded(Type type, object id, object entity)
		{
			if (entity == null)
			{
				return;
			}

			// If you naively add entities with no ID assigned (default(TID)), 
			// you will get a result from TryGet when you expect null.
			bool isDefault = Reflection.ReflectionHelper.IsDefault(id);
			if (isDefault)
			{
				return;
			}

			if (!_entityDictionary.TryGetValue(type, out Dictionary<object, object> nestedDictionary))
			{
				nestedDictionary = new Dictionary<object, object>();
				_entityDictionary.Add(type, nestedDictionary);
			}

			object dummy;
			if (!nestedDictionary.TryGetValue(id, out dummy))
			{
				nestedDictionary.Add(id, entity);
			}
			else
			{
				nestedDictionary[id] = entity;
			}
		}

		public void TryRemove(object entity, object id)
		{
			if (entity == null) throw new NullException(() => entity);

			Type type = entity.GetType();

			if (!_entityDictionary.TryGetValue(type, out Dictionary<object, object> nestedDictionary))
			{
				return;
			}

			nestedDictionary.Remove(id);
		}

		public void Clear() => _entityDictionary.Clear();
	}
}
