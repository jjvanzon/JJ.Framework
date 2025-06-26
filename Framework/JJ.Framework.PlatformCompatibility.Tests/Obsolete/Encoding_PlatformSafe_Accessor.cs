using System;
using System.Text;
using JJ.Framework.Reflection.Core;

// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    internal static class Encoding_PlatformSafe_Accessor
    {
        private static readonly AccessorCore _accessor
            = new AccessorCore(Type.GetType("JJ.Framework.PlatformCompatibility.Legacy.Obsolete.Encoding_PlatformSafe, " +
                                            "JJ.Framework.PlatformCompatibility.Legacy"));

        public static string GetString_PlatformSafe(this Encoding encoding, byte[] bytes)
            => _accessor.Call(() => GetString_PlatformSafe(encoding, bytes));
    }
}
