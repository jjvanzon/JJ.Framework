using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace JJ.Framework.Reflection.Core
{
    public class AccessorCore : AccessorLegacy
    {
        /// <inheritdoc />
        public AccessorCore(string typeName, params object[] args) : base(typeName, args) { }
        /// <inheritdoc />
        public AccessorCore(object obj) : base(obj) { }
        /// <inheritdoc />
        public AccessorCore(Type objectType) : base(objectType) { }
        /// <inheritdoc />
        public AccessorCore(object obj, Type objectType) : base(obj, objectType) { }

        // Variations with CallerMemberName
        
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod([CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod<T>([CallerMemberName] string callerMemberName = null) => (T)base.InvokeMethod(callerMemberName);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, param1);
        /// <inheritdoc cref="_invokemethod" />
        public T InvokeMethod<T>(object param1, [CallerMemberName] string callerMemberName = null) => (T)base.InvokeMethod(callerMemberName, param1);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, param1, param2);
        /// <inheritdoc cref="_invokemethod" />
        public T InvokeMethod<T>(object param1, object param2, [CallerMemberName] string callerMemberName = null) => (T)base.InvokeMethod(callerMemberName, param1, param2);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, param1, param2, param3);
        /// <inheritdoc cref="_invokemethod" />
        public T InvokeMethod<T>(object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) => (T)base.InvokeMethod(callerMemberName, param1, param2, param3);
        /// <inheritdoc cref="_invokemethod" />
        public new object GetPropertyValue([CallerMemberName] string callerMemberName = null) => base.GetPropertyValue(callerMemberName);
        /// <inheritdoc cref="_invokemethod" />
        public T GetPropertyValue<T>([CallerMemberName] string callerMemberName = null) => (T)base.GetPropertyValue(callerMemberName);

        // Redefined all base members, to prevent overloads in derived class from shadowing better matches in the base class.

        /// <inheritdoc cref="_nameexpression" />
        public new T GetFieldValue<T>(Expression<Func<T>> nameExpression) => base.GetFieldValue(nameExpression);
        
        public new object GetFieldValue(string name) => base.GetFieldValue(name);
        
        /// <inheritdoc cref="_nameexpression" />
        public new void SetFieldValue<T>(Expression<Func<T>> nameExpression, T value) => base.SetFieldValue(nameExpression, value);
        
        public new void SetFieldValue(string name, object value) => base.SetFieldValue(name, value);
        
        /// <inheritdoc cref="_nameexpression" />
        public new T GetPropertyValue<T>(Expression<Func<T>> nameExpression) => base.GetPropertyValue(nameExpression);
        
        public new void SetPropertyValue(string name, object value) => base.SetPropertyValue(name, value);

        /// <inheritdoc cref="_invokemethod" />
        public new void InvokeMethod(Expression<Action> callExpression) => base.InvokeMethod(callExpression);
        /// <inheritdoc cref="_invokemethod" />
        public new T InvokeMethod<T>(Expression<Func<T>> callExpression) => base.InvokeMethod(callExpression);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod(LambdaExpression callExpression) => base.InvokeMethod(callExpression);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object[] parameters, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public object InvokeMethod(object[] parameters, Type[] parameterTypes, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, parameters, parameterTypes);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod(string name, object[] parameters, Type[] parameterTypes) => base.InvokeMethod(name, parameters, parameterTypes);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1>(string name, TArg1 parameter) => base.InvokeMethod(name, parameter);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="_invokemethod" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        
        public new object GetIndexerValue(params object[] parameters) => base.GetIndexerValue(parameters);
        public new void SetIndexerValue(params object[] parametersAndValue) => base.SetIndexerValue(parametersAndValue);
    }
}
