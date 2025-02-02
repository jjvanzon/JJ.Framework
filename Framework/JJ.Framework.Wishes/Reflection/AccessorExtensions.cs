using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using JJ.Framework.Reflection;

namespace JJ.Framework.Wishes.Reflection
{
    public static class AccessorExtensions
    {
        // Leverage CallerMemberName, though uncombinable with params[].

        public static object InvokeMethod(this Accessor_Adapted accessor, [CallerMemberName] string callerMemberName = null) => accessor.InvokeMethod(callerMemberName);
        public static object InvokeMethod(this Accessor accessor, [CallerMemberName] string callerMemberName = null) => accessor.InvokeMethod(callerMemberName);

        public static object InvokeMethod<T>(this Accessor_Adapted accessor, [CallerMemberName] string callerMemberName = null) => (T)accessor.InvokeMethod(callerMemberName);
        public static object InvokeMethod<T>(this Accessor accessor, [CallerMemberName] string callerMemberName = null) => (T)accessor.InvokeMethod(callerMemberName);

        public static object InvokeMethod(this Accessor_Adapted accessor, object param1, [CallerMemberName] string callerMemberName = null) => accessor.InvokeMethod(callerMemberName, param1);
        public static object InvokeMethod(this Accessor accessor, object param1, [CallerMemberName] string callerMemberName = null) => accessor.InvokeMethod(callerMemberName, param1);

        public static T InvokeMethod<T>(this Accessor_Adapted accessor, object param1, [CallerMemberName] string callerMemberName = null) => (T)accessor.InvokeMethod(callerMemberName, param1);
        public static T InvokeMethod<T>(this Accessor accessor, object param1, [CallerMemberName] string callerMemberName = null) => (T)accessor.InvokeMethod(callerMemberName, param1);

        public static object InvokeMethod(this Accessor_Adapted accessor, object param1, object param2, [CallerMemberName] string callerMemberName = null) => accessor.InvokeMethod(callerMemberName, param1, param2);
        public static object InvokeMethod(this Accessor accessor, object param1, object param2, [CallerMemberName] string callerMemberName = null) => accessor.InvokeMethod(callerMemberName, param1, param2);

        public static T InvokeMethod<T>(this Accessor_Adapted accessor, object param1, object param2, [CallerMemberName] string callerMemberName = null) => (T)accessor.InvokeMethod(callerMemberName, param1, param2);
        public static T InvokeMethod<T>(this Accessor accessor, object param1, object param2, [CallerMemberName] string callerMemberName = null) => (T)accessor.InvokeMethod(callerMemberName, param1, param2);

        public static object InvokeMethod(this Accessor_Adapted accessor, object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) => accessor.InvokeMethod(callerMemberName, param1, param2, param3);
        public static object InvokeMethod(this Accessor accessor, object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) => accessor.InvokeMethod(callerMemberName, param1, param2, param3);

        public static T InvokeMethod<T>(this Accessor_Adapted accessor, object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) => (T)accessor.InvokeMethod(callerMemberName, param1, param2, param3);
        public static T InvokeMethod<T>(this Accessor accessor, object param1, object param2, object param3, [CallerMemberName] string callerMemberName = null) => (T)accessor.InvokeMethod(callerMemberName, param1, param2, param3);
    }
}
