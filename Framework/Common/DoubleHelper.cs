using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Common
{
    /// <summary>
    /// Static classes cannot get extension membrers.
    /// Instead we have the DoubleHelper class for extra static members.
    /// </summary>
    public static class DoubleHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse(string s, IFormatProvider provider, out double result)
        {
            return Double.TryParse(s, NumberStyles.Any, provider, out result);
        }

        /// <summary> Returns true if the value is NaN, PositiveInfinity or NegativeInfinity. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSpecialValue(double value)
        {
            return Double.IsNaN(value) || Double.IsInfinity(value);
        }
    }
}
