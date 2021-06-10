using JJ.Framework.Reflection;
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common.Tests
{
    internal static class CultureHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(CultureHelper));

        public static void SetThreadCultureName(string cultureName)
            => _accessor.InvokeMethod(() => SetThreadCultureName(cultureName));
    }
}
