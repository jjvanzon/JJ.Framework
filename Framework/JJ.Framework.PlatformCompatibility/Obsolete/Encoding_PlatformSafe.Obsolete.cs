using System;
using System.Text;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedType.Global

namespace JJ.Framework.PlatformCompatibility.Legacy.Obsolete
{
    /// <inheritdoc cref="_encoding" />
    [Obsolete("Use PlatformHelper instead.", true)]
    public static class Encoding_PlatformSafe
    {
        /// <inheritdoc cref="_getstring" />
        [Obsolete("Use PlatformHelper.GetString_PlatformSafe instead.", true)]
        public static string GetString_PlatformSafe(this Encoding encoding, byte[] bytes)
            => throw new NotSupportedException("Use PlatformHelper.GetString_PlatformSafe instead.");
    }
}
