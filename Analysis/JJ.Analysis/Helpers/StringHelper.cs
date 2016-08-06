using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Analysis.Helpers
{
    internal class StringHelper
    {
        public static bool StartsWithUpperCase(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            char firstChar = value[0];
            char firstCharToUpper = firstChar.ToString().ToUpper()[0];

            bool startsWithUpperCase = firstChar == firstCharToUpper;
            return startsWithUpperCase;
        }
    }
}
