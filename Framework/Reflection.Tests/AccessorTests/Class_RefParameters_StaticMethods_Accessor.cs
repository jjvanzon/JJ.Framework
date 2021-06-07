using System;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal static class Class_RefParameters_StaticMethods_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(Class_RefParameters_StaticMethods));

        // 1 Parameter

        public static bool StaticMethod_WithOneParameter(out int arg)
        {
            arg = default;
            return _accessor.InvokeMethod<bool, int>(nameof(StaticMethod_WithOneParameter), ref arg);
        }

        // 2 Parameters

        public static long StaticMethod_WithTwoParameters(ref float arg1, double arg2)
            => _accessor.InvokeMethod<long, float, double>(nameof(StaticMethod_WithTwoParameters), ref arg1, arg2);

        public static DateTime StaticMethod_WithTwoParameters(TimeSpan arg1, out string arg2)
        {
            arg2 = default;
            return _accessor.InvokeMethod<DateTime, TimeSpan, string>(nameof(StaticMethod_WithTwoParameters), arg1, ref arg2);
        }

        public static Guid StaticMethod_WithTwoParameters(ref string arg1, out TimeSpan arg2)
        {
            arg2 = default;
            return _accessor.InvokeMethod<Guid, string, TimeSpan>(nameof(StaticMethod_WithTwoParameters), ref arg1, ref arg2);
        }

        // 3 Parameters

        public static DateTime StaticMethod_WithThreeParameters(ref double arg1, float arg2, long arg3)
            => _accessor.InvokeMethod<DateTime, double, float, long>(nameof(StaticMethod_WithThreeParameters), ref arg1, arg2, arg3);

        public static int StaticMethod_WithThreeParameters(bool arg1, out int arg2, long arg3)
        {
            arg2 = default;
            return _accessor.InvokeMethod<int, bool, int, long>(nameof(StaticMethod_WithThreeParameters), arg1, ref arg2, arg3);
        }

        public static float StaticMethod_WithThreeParameters(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            arg2 = default;
            return _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(StaticMethod_WithThreeParameters), ref arg1, ref arg2, arg3);
        }

        public static string StaticMethod_WithThreeParameters(Guid arg1, string arg2, ref TimeSpan arg3)
            => _accessor.InvokeMethod<string, Guid, string, TimeSpan>(nameof(StaticMethod_WithThreeParameters), arg1, arg2, ref arg3);

        public static DateTime StaticMethod_WithThreeParameters(out double arg1, float arg2, ref long arg3)
        {
            arg1 = default;
            return _accessor.InvokeMethod<DateTime, double, float, long>(nameof(StaticMethod_WithThreeParameters), ref arg1, arg2, ref arg3);
        }

        public static int StaticMethod_WithThreeParameters(bool arg1, out int arg2, ref long arg3)
        {
            arg2 = default;
            return _accessor.InvokeMethod<int, bool, int, long>(nameof(StaticMethod_WithThreeParameters), arg1, ref arg2, ref arg3);
        }

        public static float StaticMethod_WithThreeParameters(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = default;
            arg3 = default;
            return _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(StaticMethod_WithThreeParameters), ref arg1, ref arg2, ref arg3);
        }

        // Misc

        public static void StaticMethod_WithReturnTypeVoid(ref DateTime arg)
            => _accessor.InvokeMethod<object, DateTime>(nameof(StaticMethod_WithReturnTypeVoid), ref arg);
    }
}
