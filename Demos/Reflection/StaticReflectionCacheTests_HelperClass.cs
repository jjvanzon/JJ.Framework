using System;

// ReSharper disable UnusedParameter.Global
#pragma warning disable IDE0060 // Remove unused parameter

namespace JJ.Demos.Reflection
{
    public static class Demo_Type_GetMethod_OutParameter_Helper
    {
        public static bool Method_OutParameter(out double result)
            => throw new NotSupportedException();

        public static bool Method_NonRefParameter(int result)
            => throw new NotSupportedException();
    }
}
