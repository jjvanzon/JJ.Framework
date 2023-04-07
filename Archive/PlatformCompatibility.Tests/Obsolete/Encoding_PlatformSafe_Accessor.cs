using System;
using System.Text;
using JJ.Framework.Reflection;

// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    internal static class Encoding_PlatformSafe_Accessor
    {
        private static readonly Accessor _accessor
            = new Accessor(Type.GetType("JJ.Framework.PlatformCompatibility.Obsolete.Encoding_PlatformSafe, " +
                                        "JJ.Framework.PlatformCompatibility"));

        public static string GetString_PlatformSafe(this Encoding encoding, byte[] bytes)
            => _accessor.InvokeMethod(() => GetString_PlatformSafe(encoding, bytes));
    }
}
