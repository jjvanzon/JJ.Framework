using System;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    public static class StaticReflectionCacheTests_BugMethodNotFound
    {
        public static bool Method_ThreeParameters_OfWhichOnOutParameter(string s, IFormatProvider provider, out double result)
            => throw new NotSupportedException();

        public static bool Method_OneOutParameter(out double result)
            => throw new NotSupportedException();

        public static bool Method_ThreeParameters_NoOutParameter(string s, IFormatProvider provider, int result)
            => throw new NotSupportedException();
    }
}
