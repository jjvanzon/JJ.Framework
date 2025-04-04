using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection.Core
{
    /// <summary>
    /// Attempts to make it easier to access members public, private or protected.
    /// To access base class members, a separate Accessor object might be instantiated compared to accessing derived class members.
    /// To access internal classes, maybe use a .NET Type string, GetType / or CreateInstance.
    /// A limitation is that it might not invoke private or internal constructors (yet).
    /// </summary>
    public partial class AccessorLegacy // Adapted
    {
        //private static readonly ReflectionCache _reflectionCache = new ReflectionCache();
        
        private readonly object _object;
        private readonly Type   _objectType;
        
        /// <summary> Use this constructor to access instance members of internal classes. </summary>
        public AccessorLegacy(string typeName, params object[] args)
        {
            _objectType = Type.GetType(typeName);
            
            if (_objectType == null)
            {
                throw new ArgumentException($"Type '{typeName}' not found.");
            }
            
            _object = Activator.CreateInstance(_objectType, args);
        }
        
        /// <summary> Use this constructor to access instance members. </summary>
        public AccessorLegacy(object obj)
        {
            _object     = obj ?? throw new ArgumentNullException(nameof(obj));
            _objectType = obj.GetType();
        }
        
        /// <summary> Use this constructor to access static members. </summary>
        public AccessorLegacy(Type objectType) => _objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
        
        /// <summary> Use this constructor to access members of the base class. </summary>
        public AccessorLegacy(object obj, Type objectType)
        {
            _object     = obj        ?? throw new ArgumentNullException(nameof(obj));
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
        public void SetFieldValue<T>(Expression<Func<T>> nameExpression, T value)
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
        public void SetPropertyValue<T>(Expression<Func<T>> nameExpression, T value)
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
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        /// <param name="callExpression">
        /// An expression from which the member name, parameter types and parameter values might be extracted.
        /// </param>
        public void InvokeMethod(Expression<Action> callExpression)
            => InvokeMethod((LambdaExpression)callExpression);
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        /// <param name="callExpression">
        /// An expression from which the member name, parameter types and parameter values might be extracted.
        /// </param>
        public T InvokeMethod<T>(Expression<Func<T>> callExpression)
            => (T)InvokeMethod((LambdaExpression)callExpression);
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        /// <param name="callExpression">
        /// An expression from which the member name, parameter types and parameter values might be extracted.
        /// </param>
        public object InvokeMethod(LambdaExpression callExpression)
        {
            MethodCallInfo methodCallInfo = ExpressionHelper.GetMethodCallInfo(callExpression);
            
            return InvokeMethod(
                methodCallInfo.Name,
                methodCallInfo.Parameters.Select(x => x.Value).ToArray(),
                methodCallInfo.Parameters.Select(x => x.ParameterType).ToArray());
        }
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod(string name, params object[] parameters)
        {
            MethodInfo method = null;
            
            // Try getting parameter types from calling methods
            // (assuming a wrapping accessor class with methods that define the signatures.)
            {
                //Type[] parameterTypes = new StackTrace().GetFrame(1)?.GetMethod().GetParameters().Select(x => x.ParameterType).ToArray();
                //method = StaticReflectionCache.TryGetMethod(_objectType, name, parameterTypes);
            }
            
            // Try getting parameter types from parameter values.
            if (method == null)
            {
                Type[] parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
                method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
            }
            
            return method.Invoke(_object, parameters);
        }
        
        /// <summary>
        /// <para>
        /// May call a method, that might not be accessible normally,
        /// but can be accessed through this Accessor class anyway.
        /// </para>
        /// 
        /// <para>
        /// The Accessor class may try to find the method to call,
        /// based on its name and parameter types.
        /// </para>
        ///
        /// <para>
        /// You might program a custom wrapper Accessor class,
        /// having methods that are like the ones that you try to call.
        /// </para>
        ///
        /// <para>
        /// The InvokeMethod overload that takes a lambda expression might be a first choice,
        /// because it may resolve the parameter types quite elegantly.
        /// </para>
        /// 
        /// <para>
        /// If that does not work, second in line might be, the InvokeMethod overloads,
        /// that takes a name and parameter objects.
        /// That overload attempts to guess the parameter types
        /// based on the signature of the calling method
        /// (which may work for custom Accessor classes).
        /// Otherwise it may try to guess parameter types based on the values that were passed
        /// (which however, may not always be specific enough).
        /// </para>
        ///
        /// <para>
        /// Last in line might be overloads, that specify parameter types explicitly.
        /// That can be done with an array of Types or with type arguments.
        /// Calls to these overloads may seem less elegant,
        /// but there may sometimes be no other option left.
        /// There is some lenience in leaving out certain parameter types (using null)
        /// that might be guessed based on the values.
        /// </para>
        ///
        /// <para>
        /// There may also be an overload to specify generic type arguments.
        /// </para>
        ///
        /// <para>
        /// In case of ref and out parameters, specifying the parameter types explicitly
        /// may be the only option. InvokeMethod may use ref parameters which may work for both ref and out parameters.
        /// </para>
        /// </summary>
        ///
        /// <param name="parameterTypes">
        /// Nullable. Some items can be left null. It can also have less items, than there are parameters.
        /// It may be complemented with the concrete types of the passed parameter values.
        /// </param>
        public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes)
        {
            parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
            return method.Invoke(_object, parameters);
        }
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod<TArg1>(string name, TArg1 parameter)
            => InvokeMethod(name, new object[] { parameter }, new Type[] { typeof(TArg1) });
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod<TArg1, TArg2>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2) });
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod<TArg1, TArg2, TArg3>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) });
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) });
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) });
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) });
        
        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters)
            => InvokeMethod(name, parameters, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) });
        
        ///// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        //public object InvokeMethod(string name, object[] parameters, Type[] parameterTypes, Type[] typeArguments)
        //{
        //    parameterTypes = ComplementParameterTypes(parameterTypes, parameters);
        //    MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes, typeArguments);
        //    return method.Invoke(_object, parameters);
        //}
        
        // Indexers
        
        public object GetIndexerValue(params object[] parameters)
        {
            if (parameters        == null) throw new ArgumentNullException(nameof(parameters));
            if (parameters.Length < 1) throw new Exception("parameters.Length must be at least 1.");
            
            Type[]       parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            PropertyInfo property       = StaticReflectionCache.GetIndexer(_objectType, parameterTypes);
            return property.GetValue(_object, parameters);
        }
        
        public void SetIndexerValue(params object[] parametersAndValue)
        {
            if (parametersAndValue        == null) throw new ArgumentNullException(nameof(parametersAndValue));
            if (parametersAndValue.Length < 2) throw new Exception("parametersAndValue.Length must be at least 2");
            object[]     parameters     = parametersAndValue.Take(parametersAndValue.Length - 1).ToArray();
            object       value          = parametersAndValue.Last();
            Type[]       parameterTypes = ReflectionHelper.TypesFromObjects(parameters);
            PropertyInfo property       = StaticReflectionCache.GetIndexer(_objectType, parameterTypes);
            property.SetValue(_object, value, parameters);
        }
        
        // Helpers
        
        /// <summary> Complement null parameter types with types from parameter values (concrete types). </summary>
        private static Type[] ComplementParameterTypes(Type[] parameterTypes, object[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            parameterTypes = parameterTypes ?? new Type[0];
            if (parameterTypes.Length > parameters.Length) throw new ArgumentException("parameterTypes.Length is greater than parameters.Length.");
            
            Type[] parameterTypesFromObjects = ReflectionHelper.TypesFromObjects(parameters);
            
            // Lenience for missing parameterTypes array elements.
            Array.Resize(ref parameterTypes, parameterTypesFromObjects.Length);
            
            parameterTypes = parameterTypes.Zip(parameterTypesFromObjects, (x, y) => x ?? y).ToArray();
            
            return parameterTypes;
        }
    }
}