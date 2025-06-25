using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace JJ.Framework.Common.Legacy 
{
    /// <inheritdoc cref="_culturehelper" />
    public static class CultureHelper
    {
        /// <inheritdoc cref="_culturehelper" />
        public static void SetThreadCulture(string cultureName)
        {
            CultureInfo cultureInfo = CultureInfo_PlatformSafe.GetCultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
