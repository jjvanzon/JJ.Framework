using JJ.Framework.Exceptions;
using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Business
{
	/// <summary>
	/// Stores entity statuses such as IsDirty and IsNew.
	/// It is just a glorified set of dictionaries, really.
	/// </summary>
	[Obsolete("Use your own custom-programmed EntityStatusManager instead. " + 
			  "Then you can give it a more specific interface like: IsNew(Order) and NameIsDirty(Customer) " + 
			  "So writers and readers know what to do and what to expect.")]
	
	public class EntityStatusManager
	{
		// TODO: Tuples as keys might not be fast.

		private readonly Dictionary<object, EntityStatusEnum> _entityStatuses = new Dictionary<object, EntityStatusEnum>();
		private readonly Dictionary<Tuple_PlatformSupport<object, string>, PropertyStatusEnum> _propertyStatuses = new Dictionary<Tuple_PlatformSupport<object, string>, PropertyStatusEnum>();

		public bool IsNew(object entity)
		{
			return GetStatus(entity) == EntityStatusEnum.New;
		}

		public void SetIsNew(object entity)
		{
			SetStatus(entity, EntityStatusEnum.New);
		}

		public bool IsDirty(object entity)
		{
			return GetStatus(entity) == EntityStatusEnum.Dirty;
		}

		public void SetIsDirty(object entity)
		{
			SetStatus(entity, EntityStatusEnum.Dirty);
		}

		public bool IsDeleted(object entity)
		{
			return GetStatus(entity) == EntityStatusEnum.Deleted;
		}

		public void SetIsDeleted(object entity)
		{
			SetStatus(entity, EntityStatusEnum.Deleted);
		}

		/// <summary> For properties. </summary>
		public bool IsDirty<T>(Expression<Func<T>> propertyExpression)
		{
			return GetStatus(propertyExpression) == PropertyStatusEnum.Dirty;
		}

		/// <summary> For properties. </summary>
		public void SetIsDirty<T>(Expression<Func<T>> propertyExpression)
		{
			SetStatus(propertyExpression, PropertyStatusEnum.Dirty);
		}

		// TODO: I am not happy about type argument T.
		// ExpressionHelper does not always work in case of <object>,
		// because it tries to optimize performance by saving some handling of ConvertExpressions.
		// But interface-wise I do not like it, and then performance gain might be trivial.

		private EntityStatusEnum GetStatus(object entity)
		{
			EntityStatusEnum entityStatus;
			_entityStatuses.TryGetValue(entity, out entityStatus);
			return entityStatus;
		}

		/// <summary> For properties. </summary>
		private PropertyStatusEnum GetStatus<T>(Expression<Func<T>> propertyExpression)
		{
			if (propertyExpression == null) throw new NullException(() => propertyExpression);

			IList<object> values = ExpressionHelper.GetValues(propertyExpression);
			if (values.Count < 2)
			{
				throw new Exception("propertyExpression must have at least 2 elements.");
			}

			object entity = values[values.Count - 2];
			string propertyName = ExpressionHelper.GetName(propertyExpression);
			var key = new Tuple_PlatformSupport<object, string>(entity, propertyName);
			PropertyStatusEnum propertyStatus;
			_propertyStatuses.TryGetValue(key, out propertyStatus);
			return propertyStatus;
		}

		private void SetStatus(object entity, EntityStatusEnum entityStatus)
		{
			_entityStatuses[entity] = entityStatus;
		}

		/// <summary> For properties. </summary>
		private void SetStatus<T>(Expression<Func<T>> propertyExpression, PropertyStatusEnum propertyStatus)
		{
			if (propertyExpression == null) throw new NullException(() => propertyExpression);

			IList<object> values = ExpressionHelper.GetValues(propertyExpression);
			if (values.Count < 2)
			{
				throw new Exception("propertyExpression must have at least 2 elements.");
			}

			object entity = values[values.Count - 2];
			string propertyName = ExpressionHelper.GetName(propertyExpression);
			var key = new Tuple_PlatformSupport<object, string>(entity, propertyName);
			_propertyStatuses[key] = propertyStatus;
		}

		public void Clear()
		{
			_entityStatuses.Clear();
			_propertyStatuses.Clear();
		}
	}
}
