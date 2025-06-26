using System;
using System.Text;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedType.Global

namespace JJ.Framework.PlatformCompatibility.Legacy.Obsolete
{
    [Obsolete("Use PlatformHelper instead.", true)]
    public static class Encoding_PlatformSafe
    {
        [Obsolete("Use PlatformHelper.GetString_PlatformSafe instead.", true)]
        public static string GetString_PlatformSafe(this Encoding encoding, byte[] bytes)
            => throw new NotSupportedException("Use PlatformHelper.GetString_PlatformSafe instead.");
    }
}
