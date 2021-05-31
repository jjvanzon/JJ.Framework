using JJ.Framework.Reflection;

namespace JJ.Framework.Common.Tests
{
    internal static class CultureHelper_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(CultureHelper));

        public static void SetThreadCultureName(string cultureName)
            => _accessor.InvokeMethod(nameof(SetThreadCultureName), cultureName);
    }
}
