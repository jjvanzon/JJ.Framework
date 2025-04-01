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
        /// <summary>
        /// CultureInfo.GetCultureInfo is not supported on Windows Phone 8.
        /// Use 'new CultureInfo(string)' as an alternative or call this method instead.
        /// </summary>
        public static CultureInfo GetCultureInfo(string name)
        {
            return PlatformHelper.CultureInfo_GetCultureInfo_PlatformSafe(name);
        }
    }
}
