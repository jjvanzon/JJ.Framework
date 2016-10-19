using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Analysis.Helpers
{
    internal class CaseHelper
    {
        public static bool StartsWithUpperCase(string value)
        {
            bool isUpper = IsUpper(value, 0);
            return isUpper;
        }

        public static bool StartsWithLowerCase(string value)
        {
            bool isLower = IsLower(value, 0);
            return isLower;
        }

        public static bool IsUnderscoredCamelCase(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return false;
            }

            if (!name.StartsWith('_'))
            {
                return false;
            }

            if (IsUpper(name, 1))
            {
                return false;
            }

            return true;
        }

        public static bool ExceedsMaxCapitalizedAbbreviationLength(string name, int maxAbbreviationLength, int firstIndex = 0)
        {
            // Abbreviation is followed by another capital,
            // for the next word, so maxCapitalsInARow is 1 more than maxAbbreviationLength.
            int maxCapitalsInARow = maxAbbreviationLength + 1;

            int capitalsInARow = 0;

            for (int i = firstIndex; i < name.Length; i++)
            {
                char chr = name[i];

                if (char.IsUpper(chr))
                {
                    capitalsInARow++;
                }
                else
                {
                    capitalsInARow = 0;
                }

                if (capitalsInARow > maxCapitalsInARow)
                {
                    return true;
                }
            }

            // Abbreviation casing is correct if e.g. 3 capitals in a row,
            // but not if it is the end of the string,
            // because then last cap cannot be a next word.
            if (capitalsInARow == maxCapitalsInARow)
            {
                return true;
            }

            // NOTE: two 2-letter abbreviations in a row are not allowed by this method,
            // but those are rare and badly readable anyway.

            return false;
        }

        private static bool IsLower(string name, int index)
        {
            if (index >= name.Length)
            {
                return false;
            }

            char chr = name[index];

            bool isLower = char.IsLower(chr);

            return isLower;
        }

        private static bool IsUpper(string name, int index)
        {
            if (index >= name.Length)
            {
                return false;
            }

            char chr = name[index];

            bool isUpper = char.IsUpper(chr);

            return isUpper;
        }
    }
}