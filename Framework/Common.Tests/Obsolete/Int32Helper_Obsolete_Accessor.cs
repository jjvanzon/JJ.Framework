using System;
using JJ.Framework.Reflection;

// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common.Tests.Obsolete
{
    internal static class Int32Helper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(Type.GetType( "JJ.Framework.Common.Int32Helper, JJ.Framework.Common"));

        public static bool TryParse(string s, IFormatProvider provider, out int result)
        {
            result = default;
            return _accessor.InvokeMethod<bool, string, IFormatProvider, int>(nameof(TryParse), s, provider, ref result);
        }

        public static int? ParseNullable(string input)
            => _accessor.InvokeMethod(() => ParseNullable(input));

        public static bool TryParse(string input, out int? output)
        {
            output = default;
            return _accessor.InvokeMethod<bool, string, int?>(nameof(TryParse), input, ref output);
        }
    }
}
