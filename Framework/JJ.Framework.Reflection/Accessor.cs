using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.Legacy
{
    /// <summary>
    /// Allows easy access to members by name, public, private or protected.
    /// Limitation: private base members cannot be accessed.
    /// Use a separate Accessor object to access the private members of the base class.
    /// </summary>
    /// <inheritdoc cref="_accessor" />
    public class Accessor
    {
        private readonly object _object;

        [Dyn(PropsFieldsMethods)]
        private readonly Type _objectType;

        /// <summary> Use this constructor to access instance members. </summary>
        /// <inheritdoc cref="_accessor" />
        [NoTrim(ObjectGetType)]
        public Accessor(object obj)
        {
            if (obj == null) throw new NullException(() => obj);

            _object = obj;
            _objectType = obj.GetType();
        }

        /// <summary> Use this constructor to access static members. </summary>
        /// <inheritdoc cref="_accessor" />
        public Accessor([Dyn(PropsFieldsMethods)] Type objectType)
        {
            if (objectType == null) throw new NullException(() => objectType);

            _objectType = objectType;
        }

        /// <summary> Use this constructor to access members of the base class. </summary>
        /// <inheritdoc cref="_accessor" />
        public Accessor(object obj, [Dyn(PropsFieldsMethods)] Type objectType)
        {
            if (obj == null) throw new NullException(() => obj);
            if (objectType == null) throw new NullException(() => objectType);

            _object = obj;
            _objectType = objectType;
        }

        // Fields

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        /// <inheritdoc cref="_accessor" />
        public T GetFieldValue<T>(Expression<Func<T>> nameExpression)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return (T)GetFieldValue(name);
        }

        /// <inheritdoc cref="_accessor" />
        public object GetFieldValue(string name)
        {
            FieldInfo field = StaticReflectionCache.GetField(_objectType, name);
            return field.GetValue(_object);
        }

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        /// <inheritdoc cref="_accessor" />
        public void SetFieldValue<T>(Expression<Func<T>> nameExpression, object value)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            SetFieldValue(name, value);
        }

        /// <inheritdoc cref="_accessor" />
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
        /// <inheritdoc cref="_accessor" />
        public T GetPropertyValue<T>(Expression<Func<T>> nameExpression)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return (T)GetPropertyValue(name);
        }

        /// <inheritdoc cref="_accessor" />
        public object GetPropertyValue(string name)
        {
            PropertyInfo property = StaticReflectionCache.GetProperty(_objectType, name);
            return property.GetValue(_object, null);
        }

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        /// <inheritdoc cref="_accessor" />
        public void SetPropertyValue<T>(Expression<Func<T>> nameExpression, object value)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            SetPropertyValue(name, value);
        }

        /// <inheritdoc cref="_accessor" />
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
        /// <inheritdoc cref="_accessor" />
        public void InvokeMethod(Expression<Action> nameExpression, params object[] parameters)
        {
            InvokeMethod((LambdaExpression)nameExpression, parameters);
        }

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        /// <inheritdoc cref="_accessor" />
        public T InvokeMethod<T>(Expression<Func<T>> nameExpression, params object[] parameters)
        {
            return (T)InvokeMethod((LambdaExpression)nameExpression, parameters);
        }

        /// <param name="nameExpression">
        /// An expression from which the member name will be extracted. 
        /// Only the last name in the expression will be used, nothing else.
        /// </param>
        /// <inheritdoc cref="_accessor" />
        public object InvokeMethod(LambdaExpression nameExpression, params object[] parameters)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return InvokeMethod(name, parameters);
        }

        /// <inheritdoc cref="_accessor" />
        public object InvokeMethod(string name, params object[] parameters)
        {
            if (parameters == null) throw new NullException(() => parameters);
            Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
            return method.Invoke(_object, parameters);
        }

        // Indexers

        /// <inheritdoc cref="_accessor" />
        public object GetIndexerValue(params object[] parameters)
        {
            if (parameters == null) throw new NullException(() => parameters);
            if (parameters.Length < 1) throw new Exception("parameters.Length must be at least 1.");

            Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            PropertyInfo property = StaticReflectionCache.GetIndexer(_objectType, parameterTypes);
            return property.GetValue(_object, parameters);
        }

        /// <inheritdoc cref="_accessor" />
        public void SetIndexerValue(params object[] parametersAndValue)
        {
            if (parametersAndValue == null) throw new NullException(() => parametersAndValue);
            if (parametersAndValue.Length < 2) throw new Exception("parametersAndValue.Length must be at least 2");
            object[] parameters = parametersAndValue.Take(parametersAndValue.Length - 1).ToArray();
            object value = parametersAndValue.Last();
            Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            PropertyInfo property = StaticReflectionCache.GetIndexer(_objectType, parameterTypes);
            property.SetValue(_object, value, parameters);
        }
    }
}
