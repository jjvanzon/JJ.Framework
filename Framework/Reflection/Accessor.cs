using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
// ReSharper disable RedundantExplicitArrayCreation

namespace JJ.Framework.Reflection
{
    /// <summary>
    /// Allows easy access to members by name, public, private or protected.
    /// Limitation: private base members cannot be accessed.
    /// Use a separate Accessor object to access the private members of the base class.
    /// To access internal classes, use the GetType / or CreateInstance static methods.
    /// Another limitation is that it cannot invoke private or internal constructors for you (yet).
    /// </summary>
    [PublicAPI]
    public partial class Accessor
    {
        private readonly object _object;
        private readonly Type _objectType;

        /// <summary> Use this constructor to access instance members of internal classes. </summary>
        public Accessor(string typeName, params object[] args)
        {
            _objectType = Type.GetType(typeName);

            if (_objectType == null)
            {
                throw new ArgumentException($"Type '{typeName}' not found.");
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
        public Accessor(Type objectType) => _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));

        /// <summary> Use this constructor to access members of the base class. </summary>
        public Accessor(object obj, Type objectType)
        {
            _object = obj ?? throw new ArgumentNullException(nameof(obj));
            _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
        }

        // Fields

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted.
        /// Only the last name in the expression might be used and possibly the return type.
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
        /// Only the last name in the expression might be used and possibly the return type.
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
        /// Only the last name in the expression might be used and possibly the return type.
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
        /// Only the last name in the expression might be used and possibly the return type.
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
        /// Only the last name in the expression might be used and possibly the return type.
        /// </param>
        public void InvokeMethod(Expression<Action> nameExpression, params object[] parameters) => InvokeMethod((LambdaExpression)nameExpression, parameters);

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted.
        /// Only the last name in the expression might be used and possibly the return type.
        /// </param>
        public T InvokeMethod<T>(Expression<Func<T>> nameExpression, params object[] parameters) => (T)InvokeMethod((LambdaExpression)nameExpression, parameters);

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted.
        /// Only the last name in the expression might be used.
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

        /// <param name="parameterTypes">
        /// Some can be left null, upon which the concrete type of the passed parameter value may be used.
        /// </param>
        public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes)
        {
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
            return method.Invoke(_object, parameters);
        }

        public object InvokeMethod<TArg1>(string name, TArg1 parameter)
            => InvokeMethod(name, new object[] { parameter }, new Type[] { typeof(TArg1) });

        public object InvokeMethod<TArg1, TArg2>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2) });

        public object InvokeMethod<TArg1, TArg2, TArg3>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) });

        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) });

        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) });

        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) });

        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) });

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
