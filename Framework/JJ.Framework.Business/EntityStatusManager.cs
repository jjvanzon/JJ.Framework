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
    /// Stores entity statuses such as IsDirty and IsNew.
    /// It is just a glorified set of dictionaries, really.
        /// </summary>
    public class EntityStatusManager
    {
        // TODO: Tuples as keys might not be fast.

        private IDictionary<object, EntityStatusEnum> _entityStatuses = new Dictionary<object, EntityStatusEnum>();
        private IDictionary<Tuple_PlatformSupport<object, string>, PropertyStatusEnum> _propertyStatuses = new Dictionary<Tuple_PlatformSupport<object, string>, PropertyStatusEnum>();

        /// <summary>
        /// Is this thing marked as "new"? Returns <c>true</c> when someone called <see cref="SetIsNew(object)"/> for it.
        /// Think of this as a tiny flag store — nothing clever, just a dictionary lookup.
        /// </summary>
        public bool IsNew(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.New;
        }

        /// <summary>
        /// Mark this entity as "new". We just stash the status in the internal dictionary.
        /// Useful when you want to remember that an object was created client-side and hasn't been persisted yet.
        /// </summary>
        public void SetIsNew(object entity)
        {
            SetStatus(entity, EntityStatusEnum.New);
        }

        /// <summary>
        /// Is this thing "dirty"? Returns <c>true</c> when someone marked it dirty with <see cref="SetIsDirty(object)"/>.
        /// Dirty means the object has changes that might need persisting — we don't enforce anything, we just remember the flag.
        /// </summary>
        public bool IsDirty(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.Dirty;
        }

        /// <summary>
        /// Mark this entity as dirty. We simply remember that someone called this — no persistence or validation happens here.
        /// </summary>
        public void SetIsDirty(object entity)
        {
            SetStatus(entity, EntityStatusEnum.Dirty);
        }

        /// <summary>
        /// Is this entity marked as deleted? Returns <c>true</c> when <see cref="SetIsDeleted(object)"/> was called.
        /// We treat deleted like any other flag — it's just a status in the toy dictionary.
        /// </summary>
        public bool IsDeleted(object entity)
        {
            return GetStatus(entity) == EntityStatusEnum.Deleted;
        }

        /// <summary>
        /// Mark the entity as deleted. This only records the intention — actual deletion must be handled elsewhere.
        /// </summary>
        public void SetIsDeleted(object entity)
        {
            SetStatus(entity, EntityStatusEnum.Deleted);
        }

        /// <summary> For properties. </summary>
        /// <remarks>
        /// Check whether a property (identified with a lambda expression) is marked dirty.
        /// Example: <c>IsDirty(() =&gt; myEntity.SomeProperty)</c>. Works by extracting the entity and property name from the expression.
        /// </remarks>
        #if !NET9_0_OR_GREATER
        [NoTrim(ArrayInit)]
        #endif
        public bool IsDirty<T>(Expression<Func<T>> propertyExpression)
        {
            return GetStatus(propertyExpression) == PropertyStatusEnum.Dirty;
        }

        /// <summary> For properties. </summary>
        /// <remarks>
        /// Mark a property as dirty using an expression like <c>SetIsDirty(() =&gt; myEntity.SomeProperty)</c>.
        /// The implementation will remember the property per-entity in an internal dictionary.
        /// </remarks>
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
