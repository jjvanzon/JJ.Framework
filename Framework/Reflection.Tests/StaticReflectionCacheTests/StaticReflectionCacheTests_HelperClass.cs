using System;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    public static class StaticReflectionCacheTests_BugMethodNotFound
    {
        [Obsolete("", true)]
        public static bool Overload(string s, IFormatProvider provider, out double result)
            => throw new NotSupportedException();

        [Obsolete("", true)]
        public static bool Overload(string input, out double? output)
            => throw new NotSupportedException();
    }
}
