using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Business
{
    // TODO: The type argument TID might not be a good plan. 
    // Now you cannot mix different types of identities.

    /// <summary>
    /// TODO: Rename so that it reflects that it is the state of multiple objects.
    /// </summary>
    public class ObjectStatusManager<TID>
    {
        // TODO: 'State' might not be the right term.
        // TODO: I also have to be able to clear the property state.

        // TODO: Tuples as keys might not be fast.
        // TODO: Tuple has bad platform compatibility.
        private IDictionary<Tuple<Type, TID>, ObjectStatusEnum> _objectStatuses = new Dictionary<Tuple<Type, TID>,ObjectStatusEnum>();
        private IDictionary<Tuple<Type, TID, string>, ObjectStatusEnum> _propertyStatuses = new Dictionary<Tuple<Type, TID, string>, ObjectStatusEnum>();

        public ObjectStatusEnum GetObjectStatus<T>(T obj, TID id, ObjectStatusEnum objectStatus)
        {
            var key = GetKey<T>(id);
            return _objectStatuses[key];
        }

        public void SetObjectStatus<T>(T obj, TID id, ObjectStatusEnum objectStatus)
        {
            var key = GetKey<T>(id);
            _objectStatuses[key] = objectStatus;
        }

        private Tuple<Type, TID> GetKey<T>(TID id)
        {
            var key = new Tuple<Type, TID>(typeof(T), id);
            return key;
        }

        // TODO: Do I need the T of object? Can I not just do Object.GetType()?
        // TODO: Use reflection to get both the object and the property from the expression.

        public ObjectStatusEnum GetPropertyStatus<T>(T obj, TID id, LambdaExpression propertyExpression)
        {
            string propertyName = ExpressionHelper.GetName(propertyExpression);
            return GetPropertyStatus(obj, id, propertyName);
        }

        private ObjectStatusEnum GetPropertyStatus<T>(T obj, TID id, string propertyName)
        {
            var key = GetKey<T>(id, propertyName);
            return _propertyStatuses[key];
        }

        public void SetPropertyStatus<T>(T obj, TID id, LambdaExpression propertyExpression, ObjectStatusEnum propertyStatus)
        {
            string propertyName = ExpressionHelper.GetName(propertyExpression);
            SetPropertyStatus(obj, id, propertyName, propertyStatus);
        }

        private void SetPropertyStatus<T>(T obj, TID id, string propertyName, ObjectStatusEnum propertyStatus)
        {
            var key = GetKey<T>(id, propertyName);
            _propertyStatuses[key] = propertyStatus;
        }

        private Tuple<Type, TID, string> GetKey<T>(TID id, string propertyName)
        {
            var key = new Tuple<Type, TID, string>(typeof(T), id, propertyName);
            return key;
        }
    }
}
