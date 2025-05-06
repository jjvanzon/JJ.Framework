namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class Class_RefParameters_InstanceMethods_Accessor
    {
        private readonly Accessor _accessor;

        public Class_RefParameters_InstanceMethods_Accessor() => _accessor = new Accessor(new Class_RefParameters_InstanceMethods());

        // 1 Parameter

        public bool InstanceMethod_WithOneParameter(out int arg)
        {
            arg = default;
            return _accessor.InvokeMethod<bool, int>(nameof(InstanceMethod_WithOneParameter), ref arg);
        }

        // 2 Parameters

        public long InstanceMethod_WithTwoParameters(ref float arg1, double arg2) 
            => _accessor.InvokeMethod<long, float, double>(nameof(InstanceMethod_WithTwoParameters), ref arg1, arg2);

        public DateTime InstanceMethod_WithTwoParameters(TimeSpan arg1, out string arg2)
        {
            arg2 = default;
            return _accessor.InvokeMethod<DateTime, TimeSpan, string>(nameof(InstanceMethod_WithTwoParameters), arg1, ref arg2);
        }

        public Guid InstanceMethod_WithTwoParameters(ref string arg1, out TimeSpan arg2)
        {
            arg2 = default;
            return _accessor.InvokeMethod<Guid, string, TimeSpan>(nameof(InstanceMethod_WithTwoParameters), ref arg1, ref arg2);
        }

        // 3 Parameters

        public DateTime InstanceMethod_WithThreeParameters(ref double arg1, float arg2, long arg3)
            => _accessor.InvokeMethod<DateTime, double, float, long>(nameof(InstanceMethod_WithThreeParameters), ref arg1, arg2, arg3);

        public int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, long arg3)
        {
            arg2 = default;
            return _accessor.InvokeMethod<int, bool, int, long>(nameof(InstanceMethod_WithThreeParameters), arg1, ref arg2, arg3);
        }

        public float InstanceMethod_WithThreeParameters(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            arg2 = default;
            return _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(InstanceMethod_WithThreeParameters), ref arg1, ref arg2, arg3);
        }

        public string InstanceMethod_WithThreeParameters(Guid arg1, string arg2, ref TimeSpan arg3)
            => _accessor.InvokeMethod<string, Guid, string, TimeSpan>(nameof(InstanceMethod_WithThreeParameters), arg1, arg2, ref arg3);

        public DateTime InstanceMethod_WithThreeParameters(out double arg1, float arg2, ref long arg3)
        {
            arg1 = default;
            return _accessor.InvokeMethod<DateTime, double, float, long>(nameof(InstanceMethod_WithThreeParameters), ref arg1, arg2, ref arg3);
        }

        public int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, ref long arg3)
        {
            arg2 = default;
            return _accessor.InvokeMethod<int, bool, int, long>(nameof(InstanceMethod_WithThreeParameters), arg1, ref arg2, ref arg3);
        }

        public float InstanceMethod_WithThreeParameters(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = default;
            arg3 = default;
            return _accessor.InvokeMethod<float, double, DateTime, TimeSpan>(nameof(InstanceMethod_WithThreeParameters), ref arg1, ref arg2, ref arg3);
        }

        // Misc

        public void InstanceMethod_WithReturnTypeVoid(ref DateTime arg)
            => _accessor.InvokeMethod<object, DateTime>(nameof(InstanceMethod_WithReturnTypeVoid), ref arg);
    }
}
