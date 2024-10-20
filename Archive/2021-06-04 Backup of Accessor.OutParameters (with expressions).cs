﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace JJ.Framework.Reflection
{
    public partial class Accessor
    {
        // 1 Parameter

        public TRet InvokeMethod<TRet, TArg1>(Expression<Func<TRet>> nameExpression, out TArg1 arg) 
            => InvokeMethod<TRet, TArg1>(ExpressionHelper.GetName(nameExpression), out arg);

        public TRet InvokeMethod<TRet, TArg1>(string name, out TArg1 arg)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType() };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { null };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg = (TArg1)parameters[0];

            return ret;
        }

        // 2 Parameters

        public TRet InvokeMethod<TRet, TArg1, TArg2>(Expression<Func<TRet>> nameExpression, out TArg1 arg1, TArg2 arg2)
            => InvokeMethod<TRet, TArg1, TArg2>(ExpressionHelper.GetName(nameExpression), out arg1, arg2);

        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, out TArg1 arg1, TArg2 arg2)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2) };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { null, arg2 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];

            return ret;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2>(Expression<Func<TRet>> nameExpression, TArg1 arg1, out TArg2 arg2)
            => InvokeMethod<TRet, TArg1, TArg2>(ExpressionHelper.GetName(nameExpression), arg1, out arg2);

        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, TArg1 arg1, out TArg2 arg2)
        {
            Type[] parameterTypes = { typeof(TArg1), typeof(TArg2).MakeByRefType() };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, null };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg2 = (TArg2)parameters[1];

            return ret;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2>(Expression<Func<TRet>> nameExpression, out TArg1 arg1, out TArg2 arg2)
            => InvokeMethod<TRet, TArg1, TArg2>(ExpressionHelper.GetName(nameExpression), out arg1, out arg2);

        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, out TArg1 arg1, out TArg2 arg2)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2).MakeByRefType() };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);
            
            var parameters = new object[] { null, null};
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];

            return ret;
        }

        // 3 Parameters


        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(Expression<Func<TRet>> nameExpression, out TArg1 arg1, TArg2 arg2, TArg3 arg3)
            => InvokeMethod<TRet, TArg1, TArg2, TArg3>(ExpressionHelper.GetName(nameExpression), out arg1, arg2, arg3);

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2), typeof(TArg3) };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { null, arg2, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];

            return ret;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(Expression<Func<TRet>> nameExpression, TArg1 arg1, out TArg2 arg2, TArg3 arg3)
            => InvokeMethod<TRet, TArg1, TArg2, TArg3>(ExpressionHelper.GetName(nameExpression), arg1, out arg2, arg3);

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, out TArg2 arg2, TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1), typeof(TArg2).MakeByRefType(), typeof(TArg3) };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, null, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg2 = (TArg2)parameters[1];

            return ret;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(Expression<Func<TRet>> nameExpression, out TArg1 arg1, out TArg2 arg2, TArg3 arg3)
            => InvokeMethod<TRet, TArg1, TArg2, TArg3>(ExpressionHelper.GetName(nameExpression), out arg1, out arg2, arg3);

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, out TArg2 arg2, TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2).MakeByRefType(), typeof(TArg3) };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { null, null, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];

            return ret;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(Expression<Func<TRet>> nameExpression, TArg1 arg1, TArg2 arg2, out TArg3 arg3)
            => InvokeMethod<TRet, TArg1, TArg2, TArg3>(ExpressionHelper.GetName(nameExpression), arg1, arg2, out arg3);

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, TArg2 arg2, out TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1), typeof(TArg2), typeof(TArg3).MakeByRefType() };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2, null };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg3 = (TArg3)parameters[2];

            return ret;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(Expression<Func<TRet>> nameExpression, out TArg1 arg1, TArg2 arg2, out TArg3 arg3)
            => InvokeMethod<TRet, TArg1, TArg2, TArg3>(ExpressionHelper.GetName(nameExpression), out arg1, arg2, out arg3);

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, TArg2 arg2, out TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2), typeof(TArg3).MakeByRefType() };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { null, arg2, null };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];
            arg3 = (TArg3)parameters[2];

            return ret;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(Expression<Func<TRet>> nameExpression, TArg1 arg1, out TArg2 arg2, out TArg3 arg3)
            => InvokeMethod<TRet, TArg1, TArg2, TArg3>(ExpressionHelper.GetName(nameExpression), arg1, out arg2, out arg3);

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, out TArg2 arg2, out TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1), typeof(TArg2).MakeByRefType(), typeof(TArg3).MakeByRefType() };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, null, null };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg2 = (TArg2)parameters[1];
            arg3 = (TArg3)parameters[2];

            return ret;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(Expression<Func<TRet>> nameExpression, out TArg1 arg1, out TArg2 arg2, out TArg3 arg3)
            => InvokeMethod<TRet, TArg1, TArg2, TArg3>(ExpressionHelper.GetName(nameExpression), out arg1, out arg2, out arg3);

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, out TArg2 arg2, out TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2).MakeByRefType(), typeof(TArg3).MakeByRefType() };
            MethodInfo method = StaticReflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { null, null, null };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];
            arg3 = (TArg3)parameters[2];

            return ret;
        }
    }
}
