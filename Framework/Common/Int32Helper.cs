using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JJ.Framework.Common
{
    /// <summary>
    /// Static classes cannot get extension membrers.
    /// Instead we have the Int32Helper class for extra static members.
    /// </summary>
    public static class Int32Helper
    {
        public static bool TryParse(string s, IFormatProvider provider, out int result)
        {
            return Int32.TryParse(s, NumberStyles.Integer, provider, out result);
        }
    }
}
