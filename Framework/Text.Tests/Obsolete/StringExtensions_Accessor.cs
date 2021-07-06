using JJ.Framework.Reflection;
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Text.Tests.Obsolete
{
    internal static class StringExtensions_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(StringExtensions));

        public static string TakeLeft(this string input, int length) 
            => _accessor.InvokeMethod(() => TakeLeft(input, length));

        public static string TakeRight(this string input, int length)
            => _accessor.InvokeMethod(() => TakeRight(input, length));
    }
}
