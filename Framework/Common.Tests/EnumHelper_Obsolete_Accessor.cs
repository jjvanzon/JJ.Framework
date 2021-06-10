using JJ.Framework.Reflection;
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common.Tests
{
    internal static class EnumHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(EnumHelper));

        public static TEnum Parse<TEnum>(string value) 
            => _accessor.InvokeMethod(() => Parse<TEnum>(value));
    }
}
