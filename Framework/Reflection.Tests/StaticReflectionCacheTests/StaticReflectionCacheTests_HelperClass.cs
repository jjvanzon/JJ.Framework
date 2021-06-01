using System;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    public static class StaticReflectionCacheTests_BugMethodNotFound
    {
        public static bool Overload(string s, IFormatProvider provider, out double result)
            => throw new NotSupportedException();
    }
}
