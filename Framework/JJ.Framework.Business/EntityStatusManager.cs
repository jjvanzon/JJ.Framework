using JJ.Framework.Reflection;
using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Business.Legacy
{
    /// <remarks>
    /// Stores entity statuses such as IsDirty and IsNew.
    /// It is just a glorified set of dictionaries, really.
    /// </remarks>
    /// <inheritdoc cref="_entitystatusmanager" />
    public class EntityStatusManager
    {
        /// <inheritdoc cref="_entitystatusmanager" />
        public EntityStatusManager() { }

        // TODO: Tuples as keys might not be fast.

        private IDictionary<object, EntityStatusEnum> _entityStatuses = new Dictionary<object, EntityStatusEnum>();
        private IDictionary<Tuple_PlatformSupport<object, string>, PropertyStatusEnum> _propertyStatuses = new Dictionary<Tuple_PlatformSupport<object, string>, PropertyStatusEnum>();
        /// <inheritdoc cref="_isnew" />
        public bool IsNew(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.New;
        }

        /// <inheritdoc cref="_setisnew" />
        public void SetIsNew(object entity)
        {
            SetStatus(entity, EntityStatusEnum.New);
        }

        /// <inheritdoc cref="_isdirty" />
        public bool IsDirty(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.Dirty;
        }

        /// <inheritdoc cref="_setisdirty" />
        public void SetIsDirty(object entity)
        {
            SetStatus(entity, EntityStatusEnum.Dirty);
        }

        /// <inheritdoc cref="_isdeleted" />
        public bool IsDeleted(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.Deleted;
        }

        /// <inheritdoc cref="_setisdeleted" />
        public void SetIsDeleted(object entity)
        {
            SetStatus(entity, EntityStatusEnum.Deleted);
        }

        /// <inheritdoc cref="_isdirty_property" />
        #if !NET9_0_OR_GREATER
        [NoTrim(ArrayInit)]
        #endif
        public bool IsDirty<T>(Expression<Func<T>> propertyExpression)
        {
            return GetStatus(propertyExpression) == PropertyStatusEnum.Dirty;
        }

        /// <inheritdoc cref="_setisdirty_property" />
        #if !NET9_0_OR_GREATER
        [NoTrim(ArrayInit)]
        #endif
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
        #if !NET9_0_OR_GREATER
        [NoTrim(ArrayInit)]
        #endif
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
        #if !NET9_0_OR_GREATER
        [NoTrim(ArrayInit)]
        #endif
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

        /// <inheritdoc cref="_clear" />
        public void Clear()
        {
            _entityStatuses.Clear();
            _propertyStatuses.Clear();
        }
    }
}
