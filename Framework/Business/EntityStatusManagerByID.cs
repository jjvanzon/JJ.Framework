using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JJ.Framework.Exceptions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Business
{
	public class EntityStatusManagerByID
	{
		// TODO: Tuples as keys might not be fast.

		private readonly IDictionary<Tuple<Type, object>, EntityStatusEnum> _entityStatuses = new Dictionary<Tuple<Type, object>, EntityStatusEnum>();
		private readonly IDictionary<Tuple<Type, object, string>, PropertyStatusEnum> _propertyStatuses = new Dictionary<Tuple<Type, object, string>, PropertyStatusEnum>();

		// IsDirty

		public bool IsDirty<TEntity>(object id)
		{
			return IsDirty(typeof(TEntity), id);
		}

		public bool IsDirty(Type entityType, object id)
		{
			return GetStatus(entityType, id) == EntityStatusEnum.Dirty;
		}

		/// <summary> For properties. </summary>
		public bool IsDirty<T>(object id, Expression<Func<T>> propertyExpression)
		{
			return GetStatus(id, propertyExpression) == PropertyStatusEnum.Dirty;
		}

		// SetIsDirty

		public void SetIsDirty<TEntity>(object id)
		{
			SetIsDirty(typeof(TEntity), id);
		}

		public void SetIsDirty(Type entityType, object id)
		{
			SetStatus(entityType, id,  EntityStatusEnum.Dirty);
		}

		/// <summary> For properties. </summary>
		public void SetIsDirty<T>(object id, Expression<Func<T>> propertyExpression)
		{
			SetStatus(id, propertyExpression, PropertyStatusEnum.Dirty);
		}

		// IsNew

		public bool IsNew<TEntity>(object id)
		{
			return IsNew(typeof(TEntity), id);
		}

		public bool IsNew(Type entityType, object id)
		{
			return GetStatus(entityType, id) == EntityStatusEnum.New;
		}

		// SetIsNew

		public void SetIsNew<TEntity>(object id)
		{
			SetIsNew(typeof(TEntity), id);
		}

		public void SetIsNew(Type entityType, object id)
		{
			SetStatus(entityType, id, EntityStatusEnum.Dirty);
		}

		// IsDeleted

		public bool IsDeleted<TEntity>(object id)
		{
			return IsDeleted(typeof(TEntity), id);
		}

		public bool IsDeleted(Type entityType, object id)
		{
			return GetStatus(entityType, id) == EntityStatusEnum.Deleted;
		}

		// SetIsDeleted

		public void SetIsDeleted<TEntity>(object id)
		{
			SetIsDeleted(typeof(TEntity), id);
		}

		public void SetIsDeleted(Type entityType, object id)
		{
			SetStatus(entityType, id, EntityStatusEnum.Dirty);
		}

		// Generalized methods

		// TODO: I am not happy about type argument T.
		// ExpressionHelper does not always work in case of <object>,
		// because it tries to optimize performance by saving some handling of ConvertExpressions.
		// But interface-wise I do not like it, and then performance gain might be trivial.

		private EntityStatusEnum GetStatus(Type entityType, object id)
		{
			var key = new Tuple<Type, object>(entityType, id);
			_entityStatuses.TryGetValue(key, out EntityStatusEnum entityStatus);
			return entityStatus;
		}

		private PropertyStatusEnum GetStatus<T>(object id, Expression<Func<T>> propertyExpression)
		{
			if (propertyExpression == null) throw new NullException(() => propertyExpression);

			IList<object> values = ExpressionHelper.GetValues(propertyExpression);
			if (values.Count < 2)
			{
				throw new Exception("propertyExpression must have at least 2 elements.");
			}

			object entity = values[values.Count - 2];
			string propertyName = ExpressionHelper.GetName(propertyExpression);
			var key = new Tuple<Type, object, string>(entity.GetType(), id, propertyName);
			_propertyStatuses.TryGetValue(key, out PropertyStatusEnum propertyStatus);
			return propertyStatus;
		}

		private void SetStatus(Type entityType, object id, EntityStatusEnum entityStatus)
		{
			var key = new Tuple<Type, object>(entityType, id);
			_entityStatuses[key] = entityStatus;
		}

		/// <summary> For properties. </summary>
		private void SetStatus<T>(object id, Expression<Func<T>> expression, PropertyStatusEnum entityStatus)
		{
			if (expression == null) throw new NullException(() => expression);

			IList<object> values = ExpressionHelper.GetValues(expression);
			if (values.Count < 2)
			{
				throw new Exception("propertyExpression must have at least 2 elements.");
			}

			// PropertyStatus
			object entity = values[values.Count - 2];
			string propertyName = ExpressionHelper.GetName(expression);
			var key = new Tuple<Type, object, string>(entity.GetType(), id, propertyName);
			_propertyStatuses[key] = entityStatus;
		}
	}
}
