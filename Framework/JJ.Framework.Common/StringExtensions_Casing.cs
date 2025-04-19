using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    /// <inheritdoc cref="_startwithcaporlowercase" />
    public static class StringExtensions_Casing
    {
        /// <inheritdoc cref="_startwithcaporlowercase" />
        public static string StartWithCap(this string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            return input.Left(1).ToUpper() + input.CutLeft(1);
        }

        /// <inheritdoc cref="_startwithcaporlowercase" />
        public static string StartWithLowerCase(this string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            return input.Left(1).ToLower() + input.CutLeft(1);
        }
    }
}
