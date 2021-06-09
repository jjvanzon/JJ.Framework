using System;
using JJ.Framework.Reflection;

namespace JJ.Framework.Common.Tests
{
    internal static class DoubleHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(DoubleHelper));

        public static bool TryParse(string s, IFormatProvider provider, out double result)
        {
            result = default;
            return _accessor.InvokeMethod<bool, string, IFormatProvider, double>(nameof(TryParse), s, provider, ref result);
        }

        public static double? ParseNullable(string input) 
            => (double?)_accessor.InvokeMethod(nameof(ParseNullable), input);

        public static bool TryParse(string input, out double? output)
        {
            output = default;
            return _accessor.InvokeMethod<bool, string, double?>(nameof(TryParse), input, ref output);
        }
    }
}
