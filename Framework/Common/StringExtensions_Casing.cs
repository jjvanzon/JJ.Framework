using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static class StringExtensions_Casing
    {
        private static readonly HashSet<char> _decimalDigitChars = new HashSet<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
        };

        private static readonly HashSet<char> _allowedCamelCaseChars = new HashSet<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',

            'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S',
            'T', 'U', 'V',
            'W',
            'X', 'Y', 'Z',

            'a', 'b', 'c', 'd', 'e', 'f', 'g',
            'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's',
            't', 'u', 'v',
            'w',
            'x', 'y', 'z',
            '_'
        };

        public static string StartWithCap(this string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            return input.Left(1).ToUpper() + input.CutLeft(1);
        }

        public static string StartWithLowerCase(this string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            return input.Left(1).ToLower() + input.CutLeft(1);
        }

        /// <summary>
        /// A little more restrictive than actual C# camel case.
        /// Only latin accent-free characters, digits and _ will be kept in tact.
        /// Other characters will be escaped in the form "u" + hex unicode character code.
        /// </summary>
        public static string ToCamelCase(this string input)
        {
            input = input ?? "";

            var sb = new StringBuilder();

            char firstChar = input.FirstOrDefault();
            bool firstCharIsDecimalDigit = _decimalDigitChars.Contains(firstChar);
            if (firstCharIsDecimalDigit)
            {
                sb.Append('_');
            }

            int length = input.Length;
            for (int i = 0; i < length; i++)
            {
                char chr = input[i];

                // This makes it CamelCase.
                if (i == 0)
                {
                    chr = char.ToLower(chr);
                }

                if (_allowedCamelCaseChars.Contains(chr))
                {
                    sb.Append(chr);
                }
                else
                {
                    string charCodeToHex = ((int)chr).ToString("x");
                    string escapedChar = "u" + charCodeToHex;
                    sb.Append(escapedChar);
                }
            }

            return sb.ToString();
        }
    }
}
