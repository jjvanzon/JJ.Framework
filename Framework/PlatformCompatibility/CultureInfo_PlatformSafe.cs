using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JJ.Framework.PlatformCompatibility
{
    /// <summary>
    /// Some parts of CultureInfo are not compatible with some platforms.
    /// This class offers alternatives.
    /// </summary>
    public static class CultureInfo_PlatformSafe
    {
        /// <inheritdoc cref="PlatformHelper.GetCultureInfo_PlatformSafe" />
        public static CultureInfo GetCultureInfo(string name) 
            => PlatformHelper.GetCultureInfo_PlatformSafe(name);
    }
}
