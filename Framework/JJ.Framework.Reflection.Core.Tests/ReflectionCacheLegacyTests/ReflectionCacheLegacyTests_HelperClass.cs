using System;

namespace JJ.Framework.Reflection.Core.Tests.ReflectionCacheLegacyTests
{
    public static class ReflectionCacheLegacyTests_HelperClass
    {
        public static bool Method_OutParameter(out double result)
            => throw new NotSupportedException();

        public static bool Method_NonRefParameter(int result)
            => throw new NotSupportedException();

        public static bool Method_WithTypeArguments<T, U>(int a, double b)
            => throw new NotSupportedException();
    }
}
