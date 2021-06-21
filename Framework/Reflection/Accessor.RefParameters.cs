using System;
using System.Reflection;

namespace JJ.Framework.Reflection
{
    public partial class Accessor
    {
        // 1 Parameter

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1>(string name, ref TArg1 arg)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType() };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg = (TArg1)parameters[0];

            return ret;
        }

        // 2 Parameters

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, ref TArg1 arg1, TArg2 arg2)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2) };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];

            return ret;
        }

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, TArg1 arg1, ref TArg2 arg2)
        {
            Type[] parameterTypes = { typeof(TArg1), typeof(TArg2).MakeByRefType() };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg2 = (TArg2)parameters[1];

            return ret;
        }

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, ref TArg1 arg1, ref TArg2 arg2)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2).MakeByRefType() };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];

            return ret;
        }

        // 3 Parameters

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, ref TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2), typeof(TArg3) };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];

            return ret;
        }

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, ref TArg2 arg2, TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1), typeof(TArg2).MakeByRefType(), typeof(TArg3) };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg2 = (TArg2)parameters[1];

            return ret;
        }

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, ref TArg1 arg1, ref TArg2 arg2, TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2).MakeByRefType(), typeof(TArg3) };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];

            return ret;
        }

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, TArg2 arg2, ref TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1), typeof(TArg2), typeof(TArg3).MakeByRefType() };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg3 = (TArg3)parameters[2];

            return ret;
        }

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, ref TArg1 arg1, TArg2 arg2, ref TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2), typeof(TArg3).MakeByRefType() };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];
            arg3 = (TArg3)parameters[2];

            return ret;
        }

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1), typeof(TArg2).MakeByRefType(), typeof(TArg3).MakeByRefType() };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg2 = (TArg2)parameters[1];
            arg3 = (TArg3)parameters[2];

            return ret;
        }

        /// <inheritdoc cref="InvokeMethod(string, object[], Type[])" />
        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3)
        {
            Type[] parameterTypes = { typeof(TArg1).MakeByRefType(), typeof(TArg2).MakeByRefType(), typeof(TArg3).MakeByRefType() };
            MethodInfo method = _reflectionCache.GetMethod(_objectType, name, parameterTypes);

            var parameters = new object[] { arg1, arg2, arg3 };
            var ret = (TRet)method.Invoke(_object, parameters);

            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];
            arg3 = (TArg3)parameters[2];

            return ret;
        }
    }
}
