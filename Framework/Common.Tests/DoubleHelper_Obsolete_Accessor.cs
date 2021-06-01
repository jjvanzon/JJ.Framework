using System;
using JJ.Framework.Reflection;

namespace JJ.Framework.Common.Tests
{
    internal static class DoubleHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(DoubleHelper));

        public static bool TryParse(string s, IFormatProvider provider, out double result)
            => _accessor.InvokeMethod<bool, string, IFormatProvider, double>(nameof(TryParse), s, provider, out result);
    }
}
