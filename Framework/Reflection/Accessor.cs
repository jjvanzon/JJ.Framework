using System;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection
{
    /// <summary>
    /// Allows easy access to members by name, public, private or protected.
    /// Limitation: private base members cannot be accessed.
    /// Use a separate Accessor object to access the private members of the base class.
    /// To access internal classes, use the GetType / or CreateInstance static methods.
    /// Another limitation is that it cannot invoke private or internal constructors for you (yet).
    /// </summary>
    public class Accessor
    {
        private readonly object _object;
        private readonly Type _objectType;

        /// <summary> Use this constructor to access instance members of internal classes. </summary>
        public Accessor(string typeName, params object[] args)
        {
            _objectType = Type.GetType(typeName);

            if (_objectType == null)
            {
                throw new Exception($"Type '{typeName}' not found.");
            }

            _object = Activator.CreateInstance(_objectType, args);
        }

        /// <summary> Use this constructor to access instance members. </summary>
        public Accessor(object obj)
        {
            _object = obj ?? throw new ArgumentNullException(nameof(obj));
            _objectType = obj.GetType();
        }

        /// <summary> Use this constructor to access static members. </summary>
        public Accessor(Type objectType)
        {
            _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
        }

        /// <summary> Use this constructor to access members of the base class. </summary>
        public Accessor(object obj, Type objectType)
        {
            _object = obj ?? throw new ArgumentNullException(nameof(obj));
            _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
        }

        // Fields

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        public T GetFieldValue<T>(Expression<Func<T>> nameExpression)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return (T)GetFieldValue(name);
        }

        public object GetFieldValue(string name)
        {
            FieldInfo field = StaticReflectionCache.GetField(_objectType, name);
            return field.GetValue(_object);
        }

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        public void SetFieldValue<T>(Expression<Func<T>> nameExpression, object value)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            SetFieldValue(name, value);
        }

        public void SetFieldValue(string name, object value)
        {
            FieldInfo field = StaticReflectionCache.GetField(_objectType, name);
            field.SetValue(_object, value);
        }

        // Properties

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        public T GetPropertyValue<T>(Expression<Func<T>> nameExpression)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return (T)GetPropertyValue(name);
        }

        public object GetPropertyValue(string name)
        {
            PropertyInfo property = StaticReflectionCache.GetProperty(_objectType, name);
            return property.GetValue(_object, null);
        }

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        public void SetPropertyValue<T>(Expression<Func<T>> nameExpression, object value)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            SetPropertyValue(name, value);
        }

        public void SetPropertyValue(string name, object value)
        {
            PropertyInfo property = StaticReflectionCache.GetProperty(_objectType, name);
            property.SetValue(_object, value, null);
        }

        // Methods

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        public void InvokeMethod(Expression<Action> nameExpression, params object[] parameters)
        {
            InvokeMethod((LambdaExpression)nameExpression, parameters);
        }

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        public T InvokeMethod<T>(Expression<Func<T>> nameExpression, params object[] parameters)
        {
            return (T)InvokeMethod((LambdaExpression)nameExpression, parameters);
        }

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        public object InvokeMethod(LambdaExpression nameExpression, params object[] parameters)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return InvokeMethod(name, parameters);
        }

        public object InvokeMethod(string name, params object[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
            return method.Invoke(_object, parameters);
        }

        // Indexers

        public object GetIndexerValue(params object[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (parameters.Length < 1) throw new Exception("parameters.Length must be at least 1.");

            Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            PropertyInfo property = StaticReflectionCache.GetIndexer(_objectType, parameterTypes);
            return property.GetValue(_object, parameters);
        }

        public void SetIndexerValue(params object[] parametersAndValue)
        {
            if (parametersAndValue == null) throw new ArgumentNullException(nameof(parametersAndValue));
            if (parametersAndValue.Length < 2) throw new Exception("parametersAndValue.Length must be at least 2");
            object[] parameters = parametersAndValue.Take(parametersAndValue.Length - 1).ToArray();
            object value = parametersAndValue.Last();
            Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            PropertyInfo property = StaticReflectionCache.GetIndexer(_objectType, parameterTypes);
            property.SetValue(_object, value, parameters);
        }
    }
}
