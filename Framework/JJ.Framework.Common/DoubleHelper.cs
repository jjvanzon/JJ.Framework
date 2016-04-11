using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JJ.Framework.Common
{
    /// <summary>
    /// Static classes cannot get extension membrers.
    /// Instead we have the DoubleHelper class for extra static members.
    /// </summary>
    public static class DoubleHelper
    {
        public static bool TryParse(string s, IFormatProvider provider, out double result)
        {
            return Double.TryParse(s, NumberStyles.Any, provider, out result);
        }
    }
}
