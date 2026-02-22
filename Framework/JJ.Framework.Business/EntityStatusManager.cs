using JJ.Framework.Reflection;
using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Business.Legacy
{
    /// <summary>
    /// Simple in-memory holder for small, useful pieces of state about objects
    /// (for example: New, Dirty, Deleted).
    ///
    /// The goal: let business code ask "does this object look new/dirty/deleted?"
    /// without depending on a database or a large persistence framework. You
    /// can fill this object from wherever is convenient (service code, UI, or
    /// persistence layer) and pass it around. Business rules can then react to
    /// those flags (for example: update LastModified) without being tied to
    /// how the data is stored. It's intentionally tiny and non-persistent:
    /// just a transient bag of status flags.
    /// </summary>
    public class EntityStatusManager
    {
        // TODO: Tuples as keys might not be fast.

        private IDictionary<object, EntityStatusEnum> _entityStatuses = new Dictionary<object, EntityStatusEnum>();
        private IDictionary<Tuple_PlatformSupport<object, string>, PropertyStatusEnum> _propertyStatuses = new Dictionary<Tuple_PlatformSupport<object, string>, PropertyStatusEnum>();
        /// <summary>
        /// Returns <c>true</c> when the entity was marked as "new".
        /// Business code can use this to treat freshly created objects differently.
        /// </summary>
        public bool IsNew(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.New;
        }

        /// <summary>
        /// Mark the entity as "new". Recording the state lets other code know the
        /// object was created during this workflow.
        /// </summary>
        public void SetIsNew(object entity)
        {
            SetStatus(entity, EntityStatusEnum.New);
        }

        /// <summary>
        /// Returns <c>true</c> when the entity was marked as "dirty".
        /// Business logic can check this to decide whether the object needs updating.
        /// </summary>
        public bool IsDirty(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.Dirty;
        }

        /// <summary>
        /// Mark the entity as dirty. This records that the object was changed so
        /// business code can react accordingly. Saving or validating the object
        /// is still the responsibility of other parts of the application.
        /// </summary>
        public void SetIsDirty(object entity)
        {
            SetStatus(entity, EntityStatusEnum.Dirty);
        }

        /// <summary>
        /// Returns <c>true</c> when the entity was marked as deleted. Use this to
        /// record deletion intent so business rules can respond appropriately.
        /// </summary>
        public bool IsDeleted(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.Deleted;
        }

        /// <summary>
        /// Mark the entity as deleted. The manager records the intent; performing
        /// the deletion is handled by other code.
        /// </summary>
        public void SetIsDeleted(object entity)
        {
            SetStatus(entity, EntityStatusEnum.Deleted);
        }

        /// <summary>
        /// Check whether a specific property is marked dirty. Example:
        /// <c>IsDirty(() =&gt; myEntity.SomeProperty)</c>. The expression identifies
        /// the entity instance and the property name to check.
        /// </summary>
        #if !NET9_0_OR_GREATER
        [NoTrim(ArrayInit)]
        #endif
        public bool IsDirty<T>(Expression<Func<T>> propertyExpression)
        {
            return GetStatus(propertyExpression) == PropertyStatusEnum.Dirty;
        }

        /// <summary>
        /// Mark a property as dirty using an expression like
        /// <c>SetIsDirty(() =&gt; myEntity.SomeProperty)</c>. The manager records
        /// which property on which entity instance is dirty so business code can
        /// act on that information.
        /// </summary>
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

        /// <summary>
        /// Removes all stored entity and property statuses.
        /// </summary>
        public void Clear()
        {
            _entityStatuses.Clear();
            _propertyStatuses.Clear();
        }
    }
}
