using System;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class Class_OutParameters_InstanceMethods_Accessor
    {
        private readonly Accessor _accessor;

        public Class_OutParameters_InstanceMethods_Accessor() => _accessor = new Accessor(new Class_OutParameters_InstanceMethods());

        // 1 Parameter

        public bool InstanceMethod_WithOneParameter(out int arg)
            => _accessor.InvokeMethod<bool, int>(nameof(InstanceMethod_WithOneParameter), out arg);

        // 2 Parameters

        public long InstanceMethod_WithTwoParameters(out float arg1, double arg2)
            => _accessor.InvokeMethod<long, float, double>(nameof(InstanceMethod_WithTwoParameters), out arg1, arg2);

        public DateTime InstanceMethod_WithTwoParameters(TimeSpan arg1, out string arg2)
            => _accessor.InvokeMethod<DateTime, TimeSpan, string>(nameof(InstanceMethod_WithTwoParameters), arg1, out arg2);

        public Guid InstanceMethod_WithTwoParameters(out string arg1, out TimeSpan arg2)
            => _accessor.InvokeMethod<Guid, string, TimeSpan>(nameof(InstanceMethod_WithTwoParameters), out arg1, out arg2);

        // 3 Parameters

        public DateTime InstanceMethod_WithThreeParameters(out double arg1, float arg2, long arg3)
            => _accessor.InvokeMethod<DateTime, double, float, long>(nameof(InstanceMethod_WithThreeParameters), out arg1, arg2, arg3);

        public int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, long arg3)
            => _accessor.InvokeMethod<int, bool, int, long>(nameof(InstanceMethod_WithThreeParameters), arg1, out arg2, arg3);

        public float InstanceMethod_WithThreeParameters(out double arg1, out DateTime arg2, TimeSpan arg3)
            => _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(InstanceMethod_WithThreeParameters), out arg1, out arg2, arg3);

        public string InstanceMethod_WithThreeParameters(Guid arg1, string arg2, out TimeSpan arg3)
            => _accessor.InvokeMethod<string, Guid, string, TimeSpan>(nameof(InstanceMethod_WithThreeParameters), arg1, arg2, out arg3);

        public DateTime InstanceMethod_WithThreeParameters(out double arg1, float arg2, out long arg3)
            => _accessor.InvokeMethod<DateTime, double, float, long>(nameof(InstanceMethod_WithThreeParameters), out arg1, arg2, out arg3);

        public int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, out long arg3)
            => _accessor.InvokeMethod<int, bool, int, long>(nameof(InstanceMethod_WithThreeParameters), arg1, out arg2, out arg3);

        public float InstanceMethod_WithThreeParameters(out double arg1, out DateTime arg2, out TimeSpan arg3)
            => _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(InstanceMethod_WithThreeParameters), out arg1, out arg2, out arg3);

        // Misc

        public void InstanceMethod_WithReturnTypeVoid(out DateTime arg)
            => _accessor.InvokeMethod<object, DateTime>(nameof(InstanceMethod_WithReturnTypeVoid), out arg);
    }
}
