using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace JJ.Framework.Reflection.Core
{
    // TODO: Rename File

    public class AccessorCore : AccessorLegacy
    {
        public AccessorCore(string typeName, params object[] args) : base(typeName, args) { }
        public AccessorCore(object obj) : base(obj) { }
        public AccessorCore(Type objectType) : base(objectType) { }
        public AccessorCore(object obj, Type objectType) : base(obj, objectType) { }

        // Variations with CallerMemberName
        
        public object InvokeMethod([CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName);
        public object InvokeMethod<T>([CallerMemberName] string callerMemberName = null) => (T)base.InvokeMethod(callerMemberName);
        public object InvokeMethod(object param1, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, param1);
        public T InvokeMethod<T>(object param1, [CallerMemberName] string callerMemberName = null) => (T)base.InvokeMethod(callerMemberName, param1);
        public object InvokeMethod(object param1, object param2, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, param1, param2);
        public T InvokeMethod<T>(object param1, object param2, [CallerMemberName] string callerMemberName = null) => (T)base.InvokeMethod(callerMemberName, param1, param2);
        public object InvokeMethod(object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, param1, param2, param3);
        public T InvokeMethod<T>(object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) => (T)base.InvokeMethod(callerMemberName, param1, param2, param3);
        public new object GetPropertyValue([CallerMemberName] string callerMemberName = null) => base.GetPropertyValue(callerMemberName);
        public T GetPropertyValue<T>([CallerMemberName] string callerMemberName = null) => (T)base.GetPropertyValue(callerMemberName);

        // Redefine base members as new or worse-match overloads will be picked from this derived class.

        /// <inheritdoc cref="AccessorLegacy.GetFieldValue{T}(Expression{Func{T}})" />
        public new T GetFieldValue<T>(Expression<Func<T>> nameExpression) => base.GetFieldValue(nameExpression);
        /// <inheritdoc cref="AccessorLegacy.GetFieldValue(string)" />
        public new object GetFieldValue(string name) => base.GetFieldValue(name);
        /// <inheritdoc cref="AccessorLegacy.SetFieldValue{T}(Expression{Func{T}}, T)" />
        public new void SetFieldValue<T>(Expression<Func<T>> nameExpression, T value) => base.SetFieldValue(nameExpression, value);
        /// <inheritdoc cref="AccessorLegacy.SetFieldValue(string, object)" />
        public new void SetFieldValue(string name, object value) => base.SetFieldValue(name, value);
        /// <inheritdoc cref="AccessorLegacy.GetPropertyValue{T}(Expression{Func{T}})" />
        public new T GetPropertyValue<T>(Expression<Func<T>> nameExpression) => base.GetPropertyValue(nameExpression);
        /// <inheritdoc cref="AccessorLegacy.SetPropertyValue(string, object)" />
        public new void SetPropertyValue(string name, object value) => base.SetPropertyValue(name, value);
        /// <inheritdoc cref="AccessorLegacy.SetPropertyValue{T}(Expression{Action})" />
        public new void InvokeMethod(Expression<Action> callExpression) => base.InvokeMethod(callExpression);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod{T}(Expression{Func{T}})" />
        public new T InvokeMethod<T>(Expression<Func<T>> callExpression) => base.InvokeMethod(callExpression);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod(LambdaExpression)" />
        public new object InvokeMethod(LambdaExpression callExpression) => base.InvokeMethod(callExpression);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod(string, object[])" />
        public object InvokeMethod(object[] parameters, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, parameters);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod(string, object[])" />
        public new object InvokeMethod(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod(string, object[], Type[])" />
        public object InvokeMethod(object[] parameters, Type[] parameterTypes, [CallerMemberName] string callerMemberName = null) => base.InvokeMethod(callerMemberName, parameters, parameterTypes);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod(string, object[], Type[])" />
        public new object InvokeMethod(string name, object[] parameters, Type[] parameterTypes) => base.InvokeMethod(name, parameters, parameterTypes);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod{TArg1}(string, TArg1)" />
        public new object InvokeMethod<TArg1>(string name, TArg1 parameter) => base.InvokeMethod(name, parameter);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod{TArg1, TArg2}(string, TArg1, TArg2)" />
        public new object InvokeMethod<TArg1, TArg2>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod{TArg1, TArg2, TArg3}(string, TArg1, TArg2, TArg3)" />
        public new object InvokeMethod<TArg1, TArg2, TArg3>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod{TArg1, TArg2, TArg3, TArg4}(string, TArg1, TArg2, TArg3, TArg4)" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod{TArg1, TArg2, TArg3, TArg4, TArg5}(string, TArg1, TArg2, TArg3, TArg4, TArg5)" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}(string, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6)" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="AccessorLegacy.InvokeMethod{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}(string, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7)" />
        public new object InvokeMethod<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, params object[] parameters) => base.InvokeMethod(name, parameters);
        /// <inheritdoc cref="AccessorLegacy.GetIndexerValue" />
        public new object GetIndexerValue(params object[] parameters) => base.GetIndexerValue(parameters);
        /// <inheritdoc cref="AccessorLegacy.SetIndexerValue" />
        public new void SetIndexerValue(params object[] parametersAndValue) => base.SetIndexerValue(parametersAndValue);
    }
}
