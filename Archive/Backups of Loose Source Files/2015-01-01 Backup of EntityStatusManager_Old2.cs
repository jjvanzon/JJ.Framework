using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Business
{
    public class EntityStatusManager_Old2
    {
        // TODO: Tuples as keys might not be fast.
        // TODO: Tuple has bad platform compatibility.

        private IDictionary<object, EntityStatusEnum> _entityStatuses = new Dictionary<object, EntityStatusEnum>();
        private IDictionary<Tuple<object, string>, EntityStatusEnum> _propertyStatuses = new Dictionary<Tuple<object, string>, EntityStatusEnum>();

        private IDictionary<Tuple<Type, object>, EntityStatusEnum> _entityStatusesByID = new Dictionary<Tuple<Type, object>, EntityStatusEnum>();
        private IDictionary<Tuple<Type, object, string>, EntityStatusEnum> _propertyStatusesByID = new Dictionary<Tuple<Type, object, string>, EntityStatusEnum>();

        // TODO: I am not happy about type argument T.
        // ExpressionHelper does not always work in case of <object>,
        // because it tries to optimize performance by saving some handling of ConvertExpressions.

        public EntityStatusEnum GetStatus<T>(Expression<Func<T>> expression)
        {
            if (expression == null) throw new NullException(() => expression);

            IList<object> values = ExpressionHelper.GetValues(expression);

            switch (values.Count)
            {
                case 0:
                    throw new Exception("expression has no values.");

                case 1:
                {
                    // EntityStatus
                    object entity = values[0];
                    EntityStatusEnum entityStatus;
                    _entityStatuses.TryGetValue(entity, out entityStatus);
                    return entityStatus;
                }

                default:
                {
                    // PropertyStatus
                    object entity = values[values.Count - 2];
                    string propertyName = ExpressionHelper.GetName(expression);
                    var key = new Tuple<object, string>(entity, propertyName);
                    EntityStatusEnum entityStatus;
                    _propertyStatuses.TryGetValue(key, out entityStatus);
                    return entityStatus;
                }
            }
        }

        public void SetStatus<T>(Expression<Func<T>> expression, EntityStatusEnum entityStatus)
        {
            if (expression == null) throw new NullException(() => expression);

            IList<object> values = ExpressionHelper.GetValues(expression);

            switch (values.Count)
            {
                case 0:
                    throw new Exception("expression has no values.");

                case 1:
                {
                    // EntityStatus
                    object entity = values[0];
                    _entityStatuses[entity] = entityStatus;
                    break;
                }

                default:
                {
                    // PropertyStatus
                    object entity = values[values.Count - 2];
                    string propertyName = ExpressionHelper.GetName(expression);
                    var key = new Tuple<object, string>(entity, propertyName);
                    _propertyStatuses[key] = entityStatus;
                    break;
                }
            }
        }

        public bool IsDirty<T>(Expression<Func<T>> expression)
        {
            return GetStatus(expression) == EntityStatusEnum.Dirty;
        }

        public void SetIsDirty<T>(Expression<Func<T>> expression)
        {
            SetStatus(expression, EntityStatusEnum.Dirty);
        }

        public bool IsNew<T>(Expression<Func<T>> expression)
        {
            return GetStatus(expression) == EntityStatusEnum.New;
        }

        public void SetIsNew<T>(Expression<Func<T>> expression)
        {
            SetStatus(expression, EntityStatusEnum.New);
        }

        // ByIdentity

        public EntityStatusEnum GetStatus<T>(object id, Expression<Func<T>> expression)
        {
            if (expression == null) throw new NullException(() => expression);

            IList<object> values = ExpressionHelper.GetValues(expression);

            switch (values.Count)
            {
                case 0:
                    throw new Exception("expression has no values.");

                case 1:
                {
                    // EntityStatus
                    object entity = values[0];
                    var key = new Tuple<Type, object>(entity.GetType(), id);
                    EntityStatusEnum entityStatus;
                    _entityStatusesByID.TryGetValue(key, out entityStatus);
                    return entityStatus;
                }

                default:
                {
                    // PropertyStatus
                    object entity = values[values.Count - 2];
                    string propertyName = ExpressionHelper.GetName(expression);
                    var key = new Tuple<Type, object, string>(entity.GetType(), id, propertyName);
                    EntityStatusEnum entityStatus;
                    _propertyStatusesByID.TryGetValue(key, out entityStatus);
                    return entityStatus;
                }
            }
        }

        public void SetStatus<T>(object id, Expression<Func<T>> expression, EntityStatusEnum entityStatus)
        {
            if (expression == null) throw new NullException(() => expression);

            IList<object> values = ExpressionHelper.GetValues(expression);

            switch (values.Count)
            {
                case 0:
                    throw new Exception("expression has no values.");

                case 1:
                {
                    // EntityStatus
                    object entity = values[0];
                    var key = new Tuple<Type, object>(entity.GetType(), id);
                    _entityStatusesByID[key] = entityStatus;
                    break;
                }

                default:
                {
                    // PropertyStatus
                    object entity = values[values.Count - 2];
                    string propertyName = ExpressionHelper.GetName(expression);
                    var key = new Tuple<Type, object, string>(entity.GetType(), id, propertyName);
                    _propertyStatusesByID[key] = entityStatus;
                    break;
                }
            }
        }

        public bool IsDirty<T>(object id, Expression<Func<T>> expression)
        {
            return GetStatus(id, expression) == EntityStatusEnum.Dirty;
        }

        public void SetIsDirty<T>(object id, Expression<Func<T>> expression)
        {
            SetStatus(id, expression, EntityStatusEnum.Dirty);
        }

        public bool IsNew<T>(object id, Expression<Func<T>> expression)
        {
            return GetStatus(id, expression) == EntityStatusEnum.New;
        }

        public void SetIsNew<T>(object id, Expression<Func<T>> expression)
        {
            SetStatus(id, expression, EntityStatusEnum.New);
        }
    }
}
