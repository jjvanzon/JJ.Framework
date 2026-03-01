using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Reflection;

namespace JJ.Framework.Business
{
    /// <remarks>
    /// Stores entity statuses such as IsDirty and IsNew.
    /// It is just a glorified set of dictionaries, really.
    /// </remarks>
    /// <inheritdoc cref="_entitystatusmanager" />
    [Obsolete("Use your own custom-programmed EntityStatusManager instead. " +
              "Then you can give it a more specific interface like: IsNew(Order) and NameIsDirty(Customer) " +
              "So writers and readers know what to do and what to expect.")]
    public class EntityStatusManager
    {
        /// <inheritdoc cref="_entitystatusmanager" />
        public EntityStatusManager() { }

        // TODO: Tuples as keys might not be fast.

        private readonly Dictionary<object, EntityStatusEnum> _entityStatuses = new Dictionary<object, EntityStatusEnum>();
        private readonly Dictionary<Tuple<object, string>, PropertyStatusEnum> _propertyStatuses = new Dictionary<Tuple<object, string>, PropertyStatusEnum>();

        /// <inheritdoc cref="_isnew" />
        public bool IsNew(object entity) => GetStatus(entity) == EntityStatusEnum.New;

        /// <inheritdoc cref="_setisnew" />
        public void SetIsNew(object entity) => SetStatus(entity, EntityStatusEnum.New);

        /// <inheritdoc cref="_isdirty" />
        public bool IsDirty(object entity) => GetStatus(entity) == EntityStatusEnum.Dirty;

        /// <inheritdoc cref="_setisdirty" />
        public void SetIsDirty(object entity) => SetStatus(entity, EntityStatusEnum.Dirty);

        /// <inheritdoc cref="_isdeleted" />
        public bool IsDeleted(object entity) => GetStatus(entity) == EntityStatusEnum.Deleted;

        public void SetIsDeleted(object entity) => SetStatus(entity, EntityStatusEnum.Deleted);

        /// <inheritdoc cref="_isdirty_property" />
        /// <remarks> For properties. </remarks>
        public bool IsDirty<T>(Expression<Func<T>> propertyExpression) => GetStatus(propertyExpression) == PropertyStatusEnum.Dirty;

        /// <inheritdoc cref="_setisdirty_property" />
        /// <remarks> For properties. </remarks>
        public void SetIsDirty<T>(Expression<Func<T>> propertyExpression) => SetStatus(propertyExpression, PropertyStatusEnum.Dirty);

        // TODO: I am not happy about type argument T.
        // ExpressionHelper does not always work in case of <object>,
        // because it tries to optimize performance by saving some handling of ConvertExpressions.
        // But interface-wise I do not like it, and then performance gain might be trivial.

        private EntityStatusEnum GetStatus(object entity)
        {
            _entityStatuses.TryGetValue(entity, out EntityStatusEnum entityStatus);
            return entityStatus;
        }

        /// <summary> For properties. </summary>
        private PropertyStatusEnum GetStatus<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new NullException(() => propertyExpression);

            IList<object> values = ExpressionHelper.GetValues(propertyExpression);
            if (values.Count < 2)
            {
                throw new Exception("propertyExpression must have at least 2 elements.");
            }

            object entity = values[values.Count - 2];
            string propertyName = ExpressionHelper.GetName(propertyExpression);
            var key = new Tuple<object, string>(entity, propertyName);
            _propertyStatuses.TryGetValue(key, out PropertyStatusEnum propertyStatus);
            return propertyStatus;
        }

        private void SetStatus(object entity, EntityStatusEnum entityStatus) => _entityStatuses[entity] = entityStatus;

        /// <summary> For properties. </summary>
        private void SetStatus<T>(Expression<Func<T>> propertyExpression, PropertyStatusEnum propertyStatus)
        {
            if (propertyExpression == null)
                throw new NullException(() => propertyExpression);

            IList<object> values = ExpressionHelper.GetValues(propertyExpression);
            if (values.Count < 2)
            {
                throw new Exception("propertyExpression must have at least 2 elements.");
            }

            object entity = values[values.Count - 2];
            string propertyName = ExpressionHelper.GetName(propertyExpression);
            var key = new Tuple<object, string>(entity, propertyName);
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
