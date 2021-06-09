using JJ.Framework.Reflection;

namespace JJ.Framework.Common.Tests
{
    internal static class EnumHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(EnumHelper));

        public static TEnum Parse<TEnum>(string value) 
            => (TEnum)_accessor.InvokeMethod(nameof(Parse), value);
    }
}
