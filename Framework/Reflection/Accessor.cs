using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using JJ.Framework.Reflection.docs;
// ReSharper disable RedundantExplicitArrayCreation

namespace JJ.Framework.Reflection
{
    /// <inheritdoc cref="_accessor" />
    [PublicAPI]
    public partial class Accessor
    {
        private static readonly ReflectionCache _reflectionCache = new ReflectionCache();

        private readonly object _object;
        private readonly Type _objectType;

        /// <inheritdoc cref="_accessorconstructorwithtypename" />
        public Accessor(string typeName, params object[] args)
        {
            _objectType = Type.GetType(typeName);

            if (_objectType == null)
            {
                throw new ArgumentException($"Type '{typeName}' not found.");
            }

            _object = Activator.CreateInstance(_objectType, args);
        }

        /// <inheritdoc cref="_accessorconstructorwithobject" />
        public Accessor(object obj)
        {
            _object = obj ?? throw new ArgumentNullException(nameof(obj));
            _objectType = obj.GetType();
        }

        /// <inheritdoc cref="_accessorconstructorwithtype" />
        public Accessor(Type objectType) => _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));

        /// <inheritdoc cref="_accessorconstructorwithobjectandtype" />
        public Accessor(object obj, Type objectType)
        {
            _object = obj ?? throw new ArgumentNullException(nameof(obj));
            _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
        }

        // Fields

        /// <inheritdoc cref="_nameexpression" />
        public T GetFieldValue<T>(Expression<Func<T>> nameExpression)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return (T)GetFieldValue(name);
        }

        public object GetFieldValue(string name)
        {
            FieldInfo field = _reflectionCache.GetField(_objectType, name);
            return field.GetValue(_object);
        }

        /// <inheritdoc cref="_nameexpression" />
        public void SetFieldValue<T>(Expression<Func<T>> nameExpression, T value)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            SetFieldValue(name, value);
        }

        public void SetFieldValue(string name, object value)
        {
            FieldInfo field = _reflectionCache.GetField(_objectType, name);
            field.SetValue(_object, value);
        }

        // Properties

        /// <inheritdoc cref="_nameexpression" />
        public T GetPropertyValue<T>(Expression<Func<T>> nameExpression)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return (T)GetPropertyValue(name);
        }

        public object GetPropertyValue(string name)
        {
            PropertyInfo property = _reflectionCache.GetProperty(_objectType, name);
            return property.GetValue(_object, null);
        }

        /// <inheritdoc cref="_nameexpression" />
        public void SetPropertyValue<T>(Expression<Func<T>> nameExpression, T value)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            SetPropertyValue(name, value);
        }

        public void SetPropertyValue(string name, object value)
        {
            PropertyInfo property = _reflectionCache.GetProperty(_objectType, name);
            property.SetValue(_object, value, null);
        }

        // Methods

        /// <inheritdoc cref="_invokemethod" />
        public void InvokeMethod(Expression<Action> callExpression) 
            => InvokeMethod((LambdaExpression)callExpression);

        /// <inheritdoc cref="_invokemethod" />
        public T InvokeMethod<T>(Expression<Func<T>> callExpression) 
            => (T)InvokeMethod((LambdaExpression)callExpression);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(LambdaExpression callExpression)
        {
            MethodCallInfo methodCallInfo = ExpressionHelper.GetMethodCallInfo(callExpression);

            return InvokeMethod(
                methodCallInfo.Name,
                methodCallInfo.Parameters.Select(x => x.Value).ToArray(),
                methodCallInfo.Parameters.Select(x => x.ParameterType).ToArray());
        }

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(string name, params object[] parameters)
        {
            MethodInfo method;

            // Try getting parameter types from calling methods
            // (assuming a wrapping accessor class with methods that define the signatures.)
            {
                Type[] parameterTypes = new StackTrace().GetFrame(1)?.GetMethod().GetParameters().Select(x => x.ParameterType).ToArray();
                method = _reflectionCache.TryGetMethod(_objectType, name, parameterTypes);
            }

            // Try getting parameter types from parameter values.
            if (method == null)
            {
                Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
                method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);
            }

            return method.Invoke(_object, parameters);
        }

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes)
        {
            parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);
            return method.Invoke(_object, parameters);
        }

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1>(string name, TArg1 parameter)
            => InvokeMethod(name, new object[] { parameter }, new Type[] { typeof(TArg1) });

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2) });

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) });

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) });

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) });

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) });

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) });

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments)
        {
            parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes, typeArguments);
            return method.Invoke(_object, parameters);
        }

        // Indexers

        public object GetIndexerValue(params object[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (parameters.Length < 1) throw new Exception("parameters.Length must be at least 1.");

            Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            PropertyInfo property = _reflectionCache.GetIndexer(_objectType, parameterTypes);
            return property.GetValue(_object, parameters);
        }

        public void SetIndexerValue(params object[] parametersAndValue)
        {
            if (parametersAndValue == null) throw new ArgumentNullException(nameof(parametersAndValue));
            if (parametersAndValue.Length < 2) throw new Exception("parametersAndValue.Length must be at least 2");
            object[] parameters = parametersAndValue.Take(parametersAndValue.Length - 1).ToArray();
            object value = parametersAndValue.Last();
            Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            PropertyInfo property = _reflectionCache.GetIndexer(_objectType, parameterTypes);
            property.SetValue(_object, value, parameters);
        }

        // Helpers

        /// <inheritdoc cref="_complementparametertypes" />
        private static Type[] ComplementParameterTypes(Type[] parameterTypes, object[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            parameterTypes ??= new Type[0];
            if (parameterTypes.Length > parameters.Length) throw new ArgumentException("parameterTypes.Length is greater than parameters.Length.");

            Type[] parameterTypesFromObjects = ReflectionHelper.TypesFromObjects(parameters);

            // Lenience for missing parameterTypes array elements.
            Array.Resize(ref parameterTypes, parameterTypesFromObjects.Length); 

            parameterTypes = parameterTypes.Zip(parameterTypesFromObjects, (x, y) => x ?? y).ToArray();

            return parameterTypes;
        }
    }
}
