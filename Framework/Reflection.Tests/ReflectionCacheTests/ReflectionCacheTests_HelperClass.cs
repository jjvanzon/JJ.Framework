using System;
// ReSharper disable UnusedTypeParameter
// ReSharper disable UnusedParameter.Global
// ReSharper disable InconsistentNaming
#pragma warning disable IDE0060 // Remove unused parameter

namespace JJ.Framework.Reflection.Tests.ReflectionCacheTests
{
    public static class ReflectionCacheTests_HelperClass
    {
        public static bool Method_OutParameter(out double result)
            => throw new NotSupportedException();

        public static bool Method_NonRefParameter(int result)
            => throw new NotSupportedException();

        public static bool Method_WithTypeArguments<T, U>(int a, double b)
            => throw new NotSupportedException();
    }
}
