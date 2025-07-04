using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JJ.Framework.PlatformCompatibility.Legacy
{
    /// <summary>
    /// Contains substitutes for static Stream methods that are not present in some .NET versions.
    /// </summary>
    public static class Stream_PlatformSupport
    {
        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        /// <inheritdoc cref="_copyto" />
        public static void CopyTo(Stream source, Stream dest, int bufferSize = 8192)
        {
            PlatformHelperLegacy.Stream_CopyTo_PlatformSupport(source, dest, bufferSize);
        }
    }
}
