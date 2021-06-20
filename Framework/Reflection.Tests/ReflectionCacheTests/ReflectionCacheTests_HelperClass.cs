using System;

// ReSharper disable UnusedParameter.Global
#pragma warning disable IDE0060 // Remove unused parameter

namespace JJ.Framework.Reflection.Tests.ReflectionCacheTests
{
    public static class ReflectionCacheTests_HelperClass
    {
        public static bool Method_OutParameter(out double result)
            => throw new NotSupportedException();

        public static bool Method_NonRefParameter(int result)
            => throw new NotSupportedException();
    }
}
