﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JJ.Framework.PlatformCompatibility.Core;

namespace JJ.Framework.PlatformCompatibility
{
    /// <summary>
    /// Contains substitutes for static Stream methods that are not present in some .NET versions.
    /// </summary>
    public static class Stream_PlatformSupport
    {
        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static void CopyTo(Stream source, Stream dest, int bufferSize = 8192)
        {
            PlatformHelperLegacy.Stream_CopyTo_PlatformSupport(source, dest, bufferSize);
        }
    }
}
