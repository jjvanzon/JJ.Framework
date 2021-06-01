using System.Reflection;

namespace JJ.Framework.Reflection
{
    public partial class Accessor
    {
        // 1 Parameter

        public TRet InvokeMethod<TRet, TArg1>(string name, out TArg1 arg)
        {
            arg = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg, out object[] parameters);
            arg = (TArg1)parameters[0];
            return returnValue;
        }

        private object InternalInvokeMethod<TArg1>(string name, TArg1 arg, out object[] parameters)
        {
            MethodInfo method = StaticReflectionCache.GetMethod<TArg1>(_objectType, name);
            parameters = new object[] { arg };
            return method.Invoke(_object, parameters);
        }

        // 2 Parameters

        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, out TArg1 arg1, TArg2 arg2)
        {
            arg1 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, out object[] parameters);
            arg1 = (TArg1)parameters[0];
            return returnValue;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, TArg1 arg1, out TArg2 arg2)
        {
            arg2 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, out object[] parameters);
            arg2 = (TArg2)parameters[1];
            return returnValue;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2>(string name, out TArg1 arg1, out TArg2 arg2)
        {
            arg1 = default;
            arg2 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, out object[] parameters);
            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];
            return returnValue;
        }

        private object InternalInvokeMethod<TArg1, TArg2>(string name, TArg1 arg1, TArg2 arg2, out object[] parameters)
        {
            MethodInfo method = StaticReflectionCache.GetMethod<TArg1, TArg2>(_objectType, name);
            parameters = new object[] { arg1, arg2 };
            return method.Invoke(_object, parameters);
        }

        // 3 Parameters

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            arg1 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, arg3, out object[] parameters);
            arg1 = (TArg1)parameters[0];
            return returnValue;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, out TArg2 arg2, TArg3 arg3)
        {
            arg2 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, arg3, out object[] parameters);
            arg2 = (TArg2)parameters[1];
            return returnValue;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, out TArg2 arg2, TArg3 arg3)
        {
            arg1 = default;
            arg2 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, arg3, out object[] parameters);
            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];
            return returnValue;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, TArg2 arg2, out TArg3 arg3)
        {
            arg3 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, arg3, out object[] parameters);
            arg3 = (TArg3)parameters[2];
            return returnValue;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, TArg2 arg2, out TArg3 arg3)
        {
            arg1 = default;
            arg3 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, arg3, out object[] parameters);
            arg1 = (TArg1)parameters[0];
            arg3 = (TArg3)parameters[2];
            return returnValue;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, TArg1 arg1, out TArg2 arg2, out TArg3 arg3)
        {
            arg2 = default;
            arg3 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, arg3, out object[] parameters);
            arg2 = (TArg2)parameters[1];
            arg3 = (TArg3)parameters[2];
            return returnValue;
        }

        public TRet InvokeMethod<TRet, TArg1, TArg2, TArg3>(string name, out TArg1 arg1, out TArg2 arg2, out TArg3 arg3)
        {
            arg1 = default;
            arg2 = default;
            arg3 = default;
            var returnValue = (TRet)InternalInvokeMethod(name, arg1, arg2, arg3, out object[] parameters);
            arg1 = (TArg1)parameters[0];
            arg2 = (TArg2)parameters[1];
            arg3 = (TArg3)parameters[2];
            return returnValue;
        }

        private object InternalInvokeMethod<TArg1, TArg2, TArg3>
            (string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, out object[] parameters)
        {
            MethodInfo method = StaticReflectionCache.GetMethod<TArg1, TArg2, TArg3>(_objectType, name);
            parameters = new object[] { arg1, arg2, arg3 };
            return method.Invoke(_object, parameters);
        }
    }
}
