using System;

// ReSharper disable UnusedParameter.Global
#pragma warning disable IDE0060 // Remove unused parameter

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    public static class StaticReflectionCacheTests_BugMethodNotFound
    {
        public static bool Method_OneOutParameter(out double result)
            => throw new NotSupportedException();

        public static bool Method_OneParameter_NotOut(int result)
            => throw new NotSupportedException();
    }
}
