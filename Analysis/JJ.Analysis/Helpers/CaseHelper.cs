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

        public static bool HasTooManyUpperCharsInARow(string name, int max)
        {
            int upperCharsInARow = 0;

            for (int i = 0; i < name.Length; i++)
            {
                char chr = name[i];

                if (char.IsUpper(chr))
                {
                    upperCharsInARow++;
                }
                else
                {
                    upperCharsInARow = 0;
                }

                if (upperCharsInARow > max)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsLower(string name, int index)
        {
            if (index >= name.Length)
            {
                return false;
            }

            char chr = name[index];

            bool isUpper = char.IsUpper(chr);

            return isUpper;
        }

        private static bool IsUpper(string name, int index)
        {
            if (index >= name.Length)
            {
                return false;
            }

            char chr = name[index];

            bool isLower = char.IsUpper(chr);

            return isLower;
        }
    }
}