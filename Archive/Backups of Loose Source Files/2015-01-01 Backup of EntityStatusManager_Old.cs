using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Business
{
    public class EntityStatusManager_Old
    {
        // TODO: Tuples as keys might not be fast.
        // TODO: Tuple has bad platform compatibility.

        private IDictionary<Tuple<Type, object>, EntityStatusEnum> _objectStatuses = new Dictionary<Tuple<Type, object>, EntityStatusEnum>();
        private IDictionary<Tuple<Type, object, string>, EntityStatusEnum> _propertyStatuses = new Dictionary<Tuple<Type, object, string>, EntityStatusEnum>();

        public EntityStatusEnum GetObjectStatus(object obj, object id)
        {
            if (obj == null) throw new NullException(() => obj);
            if (id == null) throw new NullException(() => id);

            var key = GetKey(obj, id);
            return _objectStatuses[key];
        }

        public void SetObjectStatus(object obj, object id, EntityStatusEnum objectStatus)
        {
            if (obj == null) throw new NullException(() => obj);
            if (id == null) throw new NullException(() => id);

            var key = GetKey(obj, id);
            _objectStatuses[key] = objectStatus;
        }

        private Tuple<Type, object> GetKey(object obj, object id)
        {
            return new Tuple<Type, object>(obj.GetType(), id);
        }

        // TODO: Use reflection to get both the object and the property from the expression.

        public EntityStatusEnum GetPropertyStatus(object obj, object id, Expression<Func<object>> propertyExpression)
        {
            if (obj == null) throw new NullException(() => obj);
            if (id == null) throw new NullException(() => id);

            string propertyName = ExpressionHelper.GetName(propertyExpression);
            return GetPropertyStatus(obj, id, propertyName);
        }

        private EntityStatusEnum GetPropertyStatus(object obj, object id, string propertyName)
        {
            var key = GetKey(obj, id, propertyName);
            return _propertyStatuses[key];
        }

        public void SetPropertyStatus(object obj, object id, Expression<Func<object>> propertyExpression, EntityStatusEnum propertyStatus)
        {
            if (obj == null) throw new NullException(() => obj);

            string propertyName = ExpressionHelper.GetName(propertyExpression);
            SetPropertyStatus(obj, id, propertyName, propertyStatus);
        }

        private void SetPropertyStatus(object obj, object id, string propertyName, EntityStatusEnum propertyStatus)
        {
            var key = GetKey(obj, id, propertyName);
            _propertyStatuses[key] = propertyStatus;
        }

        private Tuple<Type, object, string> GetKey(object obj, object id, string propertyName)
        {
            return new Tuple<Type, object, string>(obj.GetType(), id, propertyName);
        }
    }
}
