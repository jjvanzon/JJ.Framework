using JJ.Framework.Reflection;
using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Persistence
{
    /// <summary>
    /// Stores entity statuses such as IsDirty and IsNew.
    /// It is just a glorified set of dictionaries, really.
    /// </summary>
    internal class EntityStatusManager
    {
        // TODO: Tuples as keys might not be fast.

        private IDictionary<object, EntityStatusEnum> _entityStatuses = new Dictionary<object, EntityStatusEnum>();
        private IDictionary<Tuple_PlatformSupport<object, string>, EntityStatusEnum> _propertyStatuses = new Dictionary<Tuple_PlatformSupport<object, string>, EntityStatusEnum>();

        /// <summary> For entities. </summary>
        public bool IsDirty(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.Dirty;
        }

        /// <summary> For properties. </summary>
        public bool IsDirty<T>(Expression<Func<T>> propertyExpression)
        {
            return GetStatus(propertyExpression) == EntityStatusEnum.Dirty;
        }

        /// <summary> For entities. </summary>
        public void SetIsDirty(object entity)
        {
            SetStatus(entity, EntityStatusEnum.Dirty);
        }

        /// <summary> For properties. </summary>
        public void SetIsDirty<T>(Expression<Func<T>> propertyExpression)
        {
            SetStatus(propertyExpression, EntityStatusEnum.Dirty);
        }

        /// <summary> For entities. </summary>
        public bool IsNew(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.New;
        }

        /// <summary> For properties. </summary>
        public bool IsNew<T>(Expression<Func<T>> propertyExpression)
        {
            return GetStatus(propertyExpression) == EntityStatusEnum.New;
        }

        /// <summary> For entities. </summary>
        public void SetIsNew(object entity)
        {
            SetStatus(entity, EntityStatusEnum.New);
        }

        /// <summary> For properties. </summary>
        public void SetIsNew<T>(Expression<Func<T>> propertyExpression)
        {
            SetStatus(propertyExpression, EntityStatusEnum.New);
        }

        // TODO: I am not happy about type argument T.
        // ExpressionHelper does not always work in case of <object>,
        // because it tries to optimize performance by saving some handling of ConvertExpressions.
        // But interface-wise I do not like it, and then performance gain might be trivial.

        /// <summary> For entities. </summary>
        private EntityStatusEnum GetStatus(object entity)
        {
            EntityStatusEnum entityStatus;
            _entityStatuses.TryGetValue(entity, out entityStatus);
            return entityStatus;
        }

        /// <summary> For properties. </summary>
        private EntityStatusEnum GetStatus<T>(Expression<Func<T>> propertyExpression)
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
            EntityStatusEnum entityStatus;
            _propertyStatuses.TryGetValue(key, out entityStatus);
            return entityStatus;
        }

        /// <summary> For entities. </summary>
        public void SetStatus(object entity, EntityStatusEnum entityStatus)
        {
            _entityStatuses[entity] = entityStatus;
        }

        /// <summary> For properties. </summary>
        public void SetStatus<T>(Expression<Func<T>> propertyExpression, EntityStatusEnum entityStatus)
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
            _propertyStatuses[key] = entityStatus;
        }

        public void Clear()
        {
            _entityStatuses.Clear();
            _propertyStatuses.Clear();
        }
    }
}
