﻿using System.Runtime.CompilerServices;

namespace JJ.Framework.Common
{
    /// <summary>
    /// Static classes cannot get extension members.
    /// Instead we have the DoubleHelper class for extra static members.
    /// </summary>
    public static partial class DoubleHelper
    {
        /// <summary> Returns true if the value is NaN, PositiveInfinity or NegativeInfinity. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSpecialValue(double value) => double.IsNaN(value) || double.IsInfinity(value);
    }
}
