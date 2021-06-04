using System;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal static class Class_OutParameters_StaticMethods_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(Class_OutParameters_StaticMethods));

        // 1 Parameter

        public static bool StaticMethod_WithOneParameter(out int arg)
            => _accessor.InvokeMethod<bool, int>(nameof(StaticMethod_WithOneParameter), out arg);

        // 2 Parameters

        public static long StaticMethod_WithTwoParameters(out float arg1, double arg2)
            => _accessor.InvokeMethod<long, float, double>(nameof(StaticMethod_WithTwoParameters), out arg1, arg2);

        public static DateTime StaticMethod_WithTwoParameters(TimeSpan arg1, out string arg2)
            => _accessor.InvokeMethod<DateTime, TimeSpan, string>(nameof(StaticMethod_WithTwoParameters), arg1, out arg2);

        public static Guid StaticMethod_WithTwoParameters(out string arg1, out TimeSpan arg2)
            => _accessor.InvokeMethod<Guid, string, TimeSpan>(nameof(StaticMethod_WithTwoParameters), out arg1, out arg2);

        // 3 Parameters

        public static DateTime StaticMethod_WithThreeParameters(out double arg1, float arg2, long arg3)
            => _accessor.InvokeMethod<DateTime, double, float, long>(nameof(StaticMethod_WithThreeParameters), out arg1, arg2, arg3);

        public static int StaticMethod_WithThreeParameters(bool arg1, out int arg2, long arg3)
            => _accessor.InvokeMethod<int, bool, int, long>(nameof(StaticMethod_WithThreeParameters), arg1, out arg2, arg3);

        public static float StaticMethod_WithThreeParameters(out double arg1, out DateTime arg2, TimeSpan arg3)
            => _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(StaticMethod_WithThreeParameters), out arg1, out arg2, arg3);

        public static string StaticMethod_WithThreeParameters(Guid arg1, string arg2, out TimeSpan arg3)
            => _accessor.InvokeMethod<string, Guid, string, TimeSpan>(nameof(StaticMethod_WithThreeParameters), arg1, arg2, out arg3);

        public static DateTime StaticMethod_WithThreeParameters(out double arg1, float arg2, out long arg3)
            => _accessor.InvokeMethod<DateTime, double, float, long>(nameof(StaticMethod_WithThreeParameters), out arg1, arg2, out arg3);

        public static int StaticMethod_WithThreeParameters(bool arg1, out int arg2, out long arg3)
            => _accessor.InvokeMethod<int, bool, int, long>(nameof(StaticMethod_WithThreeParameters), arg1, out arg2, out arg3);

        public static float StaticMethod_WithThreeParameters(out double arg1, out DateTime arg2, out TimeSpan arg3)
            => _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(StaticMethod_WithThreeParameters), out arg1, out arg2, out arg3);

        // Misc

        public static void StaticMethod_WithReturnTypeVoid(out DateTime arg)
            => _accessor.InvokeMethod<object, DateTime>(nameof(StaticMethod_WithReturnTypeVoid), out arg);
    }
}
