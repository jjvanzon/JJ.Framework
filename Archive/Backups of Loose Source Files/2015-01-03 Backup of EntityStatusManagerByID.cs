using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Business
{
    public class EntityStatusManagerByID
    {
        // TODO: Tuples as keys might not be fast.
        // TODO: Tuple has bad platform compatibility.

        private IDictionary<Tuple<Type, object>, EntityStatusEnum> _entityStatuses = new Dictionary<Tuple<Type, object>, EntityStatusEnum>();
        private IDictionary<Tuple<Type, object, string>, EntityStatusEnum> _propertyStatuses = new Dictionary<Tuple<Type, object, string>, EntityStatusEnum>();

        // IsDirty

        /// <summary> For entities. </summary>
        public bool IsDirty<TEntity>(object id)
        {
            return IsDirty(typeof(TEntity), id);
        }

        /// <summary> For entities. </summary>
        public bool IsDirty(Type entityType, object id)
        {
            return GetStatus(entityType, id) == EntityStatusEnum.Dirty;
        }

        /// <summary> For properties. </summary>
        public bool IsDirty<T>(object id, Expression<Func<T>> propertyExpression)
        {
            return GetStatus(id, propertyExpression) == EntityStatusEnum.Dirty;
        }

        // SetIsDirty

        /// <summary> For entities. </summary>
        public void SetIsDirty<TEntity>(object id)
        {
            SetIsDirty(typeof(TEntity), id);
        }

        /// <summary> For entities. </summary>
        public void SetIsDirty(Type entityType, object id)
        {
            SetStatus(entityType, id,  EntityStatusEnum.Dirty);
        }

        /// <summary> For properties. </summary>
        public void SetIsDirty<T>(object id, Expression<Func<T>> propertyExpression)
        {
            SetStatus(id, propertyExpression, EntityStatusEnum.Dirty);
        }

        // IsNew

        /// <summary> For entities. </summary>
        public bool IsNew<TEntity>(object id)
        {
            return IsNew(typeof(TEntity), id);
        }

        /// <summary> For entities. </summary>
        public bool IsNew(Type entityType, object id)
        {
            return GetStatus(entityType, id) == EntityStatusEnum.New;
        }

        /// <summary> For properties. </summary>
        public bool IsNew<T>(object id, Expression<Func<T>> propertyExpression)
        {
            return GetStatus(id, propertyExpression) == EntityStatusEnum.New;
        }

        // SetIsNew

        /// <summary> For entities. </summary>
        public void SetIsNew<TEntity>(object id)
        {
            SetIsNew(typeof(TEntity), id);
        }

        /// <summary> For entities. </summary>
        public void SetIsNew(Type entityType, object id)
        {
            SetStatus(entityType, id, EntityStatusEnum.Dirty);
        }

        /// <summary> For properties. </summary>
        public void SetIsNew<T>(object id, Expression<Func<T>> propertyExpression)
        {
            SetStatus(id, propertyExpression, EntityStatusEnum.New);
        }

        // Generalized methods

        // TODO: I am not happy about type argument T.
        // ExpressionHelper does not always work in case of <object>,
        // because it tries to optimize performance by saving some handling of ConvertExpressions.
        // But interface-wise I do not like it, and then performance gain might be trivial.

        /// <summary> For entities. </summary>
        private EntityStatusEnum GetStatus(Type entityType, object id)
        {
            var key = new Tuple<Type, object>(entityType, id);
            EntityStatusEnum entityStatus;
            _entityStatuses.TryGetValue(key, out entityStatus);
            return entityStatus;
        }

        /// <summary> For properties. </summary>
        private EntityStatusEnum GetStatus<T>(object id, Expression<Func<T>> propertyExpression)
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
            EntityStatusEnum entityStatus;
            _propertyStatuses.TryGetValue(key, out entityStatus);
            return entityStatus;
        }

        /// <summary> For entities. </summary>
        private void SetStatus(Type entityType, object id, EntityStatusEnum entityStatus)
        {
            var key = new Tuple<Type, object>(entityType, id);
            _entityStatuses[key] = entityStatus;
        }

        /// <summary> For properties. </summary>
        private void SetStatus<T>(object id, Expression<Func<T>> expression, EntityStatusEnum entityStatus)
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
