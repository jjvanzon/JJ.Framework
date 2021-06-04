using System;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal static class OutParametersAccessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(OutParametersClass));

        // 1 Parameter

        public static bool Method_WithOneParameter(out int arg)
            => _accessor.InvokeMethod<bool, int>(nameof(Method_WithOneParameter), out arg);

        // 2 Parameters

        public static long Method_WithTwoParameters(out float arg1, double arg2)
            => _accessor.InvokeMethod<long, float, double>(nameof(Method_WithTwoParameters), out arg1, arg2);

        public static DateTime Method_WithTwoParameters(TimeSpan arg1, out string arg2)
            => _accessor.InvokeMethod<DateTime, TimeSpan, string>(nameof(Method_WithTwoParameters), arg1, out arg2);

        public static Guid Method_WithTwoParameters(out string arg1, out TimeSpan arg2)
            => _accessor.InvokeMethod<Guid, string, TimeSpan>(nameof(Method_WithTwoParameters), out arg1, out arg2);

        // 3 Parameters

        public static DateTime Method_WithThreeParameters(out double arg1, float arg2, long arg3)
            => _accessor.InvokeMethod<DateTime, double, float, long>(nameof(Method_WithThreeParameters), out arg1, arg2, arg3);

        public static int Method_WithThreeParameters(bool arg1, out int arg2, long arg3)
            => _accessor.InvokeMethod<int, bool, int, long>(nameof(Method_WithThreeParameters), arg1, out arg2, arg3);

        public static float Method_WithThreeParameters(out double arg1, out DateTime arg2, TimeSpan arg3)
            => _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(Method_WithThreeParameters), out arg1, out arg2, arg3);

        public static string Method_WithThreeParameters(Guid arg1, string arg2, out TimeSpan arg3)
            => _accessor.InvokeMethod<string, Guid, string, TimeSpan>(nameof(Method_WithThreeParameters), arg1, arg2, out arg3);

        public static DateTime Method_WithThreeParameters(out double arg1, float arg2, out long arg3)
            => _accessor.InvokeMethod<DateTime, double, float, long>(nameof(Method_WithThreeParameters), out arg1, arg2, out arg3);

        public static int Method_WithThreeParameters(bool arg1, out int arg2, out long arg3)
            => _accessor.InvokeMethod<int, bool, int, long>(nameof(Method_WithThreeParameters), arg1, out arg2, out arg3);

        public static float Method_WithThreeParameters(out double arg1, out DateTime arg2, out TimeSpan arg3)
            => _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(Method_WithThreeParameters), out arg1, out arg2, out arg3);
    }
}
