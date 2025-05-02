using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

// ReSharper disable RedundantExplicitArrayCreation

namespace JJ.Framework.Reflection.Core
{
    /// <inheritdoc cref="_accessor" />
    public partial class AccessorLegacy
    {
        private static readonly ReflectionCacheLegacy _reflectionCache = new ReflectionCacheLegacy();

        private readonly object _object;
        private readonly Type _objectType;

        // Constructors
        
        /// <inheritdoc cref="_accessorconstructorwithtypename" />
        public AccessorLegacy(string typeName, params object[] args)
        {
            _objectType = Type.GetType(typeName);

            if (_objectType == null)
            {
                throw new ArgumentException($"Type '{typeName}' not found.");
            }

            _object = Activator.CreateInstance(_objectType, args);
        }

        /// <inheritdoc cref="_accessorconstructorwithobject" />
        public AccessorLegacy(object obj)
        {
            _object = obj ?? throw new ArgumentNullException(nameof(obj));
            _objectType = obj.GetType();
        }

        /// <inheritdoc cref="_accessorconstructorwithtype" />
        public AccessorLegacy(Type objectType) => _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));

        /// <inheritdoc cref="_accessorconstructorwithobjectandtype" />
        public AccessorLegacy(object obj, Type objectType)
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

        public T GetFieldValue<T>([CallerMemberName] string name = "")
            => (T)GetFieldValue(name);

        public object GetFieldValue([CallerMemberName] string name = "")
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

        public void SetFieldValue(object value, [CallerMemberName] string name = "")
            => SetFieldValue(name, value);

        public void SetFieldValue(string name, object value)
        {
            FieldInfo field = _reflectionCache.GetField(_objectType, name);
            field.SetValue(_object, value);
        }
        
        // Properties

        /// <inheritdoc cref="_nameexpression" />
        public T GetPropertyValue<T>(Expression<Func<T>> nameExpression)
            => (T)GetPropertyValue((LambdaExpression)nameExpression);

        public object GetPropertyValue(LambdaExpression nameExpression)
        {
            string name = ExpressionHelper.GetName(nameExpression);
            return GetPropertyValue(name);
        }
        
        public T GetPropertyValue<T>([CallerMemberName] string name = "")
            => (T)GetPropertyValue(name);

        public object GetPropertyValue([CallerMemberName] string name = "")
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

        public void SetPropertyValue(object value, [CallerMemberName] string name = "")
            => SetPropertyValue(name, value);

        public void SetPropertyValue(string name, object value)
        {
            PropertyInfo property = _reflectionCache.GetProperty(_objectType, name);
            property.SetValue(_object, value, null);
        }

        // Methods
        
        // With Lambdas

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
        
        // With params
        
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

            // Get parameter types from 2 stack frames up to accomodate layers of method delegation.
            if (method == null)
            {
                Type[] parameterTypes = new StackTrace().GetFrame(2)?.GetMethod().GetParameters().Select(x => x.ParameterType).ToArray();
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

        // With CallerMemberName

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod([CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, [ ]);
        
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1);
        
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, [CallerMemberName] string callerMemberName = null)
            => InvokeMethod(callerMemberName, param1, param2);
        
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1, param2, param3);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, object param4, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1, param2, param3, param4);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, object param4, object param5, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1, param2, param3, param4, param5);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, object param4, object param5, object param6, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1, param2, param3, param4, param5, param6);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, object param4, object param5, object param6, object param7, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1, param2, param3, param4, param5, param6, param7);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1, param2, param3, param4, param5, param6, param7, param8);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1, param2, param3, param4, param5, param6, param7, param8, param9);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
        
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object[] parameters, [CallerMemberName] string name = null)
            => InvokeMethod(name, parameters);

        // With Parameter Types
                
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object[] parameters, Type[] parameterTypes, [CallerMemberName] string callerMemberName = null) 
            => InvokeMethod(callerMemberName, parameters, parameterTypes);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes)
        {
            parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);
            return method.Invoke(_object, parameters);
        }
        
        // With Type Arguments
        
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments)
        {
            parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes, typeArguments);
            return method.Invoke(_object, parameters);
        }

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9) ]);

        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, [ ], typeArguments: [ typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10) ]);

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
        
        // With Parameter Types
        
        public object GetIndexerValue(object[] parameters, Type[] parameterTypes)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (parameters.Length < 1) throw new Exception("parameters.Length must be at least 1.");
            parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
            PropertyInfo property = _reflectionCache.GetIndexer(_objectType, parameterTypes);
            return property.GetValue(_object, parameters);
        }
        
        public void SetIndexerValue(object[] parameters, Type[] parameterTypes, object value)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (parameters.Length < 1) throw new Exception("parameters.Length must be at least 1.");
            parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
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
