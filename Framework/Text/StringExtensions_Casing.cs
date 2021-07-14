using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable RedundantJumpStatement
// ReSharper disable IdentifierTypo

namespace JJ.Framework.Text
{
    public static class StringExtensions_Casing
    {
        /// <summary>
        /// Turns the first character into a capital letter.
        /// </summary>
        public static string StartWithCap(this string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Turns the first character into a lower-case letter.
        /// </summary>
        public static string StartWithLowerCase(this string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            return input.Substring(0, 1).ToLower() + input.Substring(1, input.Length - 1);
        }

        private static readonly Dictionary<char, string> _decimalDigitToWordDictionary = new Dictionary<char, string>
        {
            { '0', "zero" },
            { '1', "one" },
            { '2', "two" },
            { '3', "three" },
            { '4', "four" },
            { '5', "five" },
            { '6', "six" },
            { '7', "seven" },
            { '8', "eight" },
            { '9', "nine" }
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

        /// <summary>
        /// <para>
        /// Converts e.g. "This is a sentence." to "thisIsASentence" so it can be used in code.
        /// Only latin accent-free characters, digits and _ may remain.
        /// </para>
        /// 
        /// <para>
        /// a) First character is made lower case.
        /// b) Other words are capitalized.
        /// c) Accents are removed.
        /// d) Punctuation characters and such are removed.
        /// e) A leading digit is converted into a word.
        /// f) Other characters will be escaped in the form "u" + hex unicode character code.
        /// </para>
        /// 
        /// <para>
        /// It may work in most cases, but it is not a full-proof way to generate a unique result.
        /// For instance an escaped character "u0021" may clash with the literal text "u0021".
        /// </para>
        /// </summary>
        public static string ToCamelCase(this string input)
        {
            input = input ?? "";

            // Remove accents
            input = input.RemoveAccents();

            var sb = new StringBuilder();

            bool isFirst = true;
            bool mustCapitalize = false;

            int length = input.Length;
            for (var i = 0; i < length; i++)
            {
                char chr = input[i];

                // Capitalize if needed
                if (mustCapitalize)
                {
                    chr = char.ToUpper(chr);
                    mustCapitalize = false;
                }

                // Special consideration for 'first' character.
                if (isFirst)
                {
                    isFirst = false;

                    // Start with lower case, making it camel case.
                    chr = char.ToLower(chr);

                    // Replace leading digit with word.
                    bool isDecimalDigit = _decimalDigitToWordDictionary.TryGetValue(chr, out string digitWord);
                    if (isDecimalDigit)
                    {
                        sb.Append(digitWord);
                        continue;
                    }
                }

                // Capitalize after under score.
                if (chr == '_')
                {
                    mustCapitalize = true;
                }

                // Include character
                if (_allowedCamelCaseChars.Contains(chr))
                {
                    sb.Append(chr);
                    continue;
                }

                // Omit character, but capitalize next.
                bool mustOmit = char.IsWhiteSpace(chr) ||
                                char.IsPunctuation(chr) ||
                                char.IsControl(chr) ||
                                char.IsSeparator(chr);
                if (mustOmit)
                {
                    mustCapitalize = true;
                    continue;
                }

                // Escape character
                string charCodeToHex = ((int)chr).ToString("x4");
                string escapedChar = "u" + charCodeToHex;
                sb.Append(escapedChar);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Inspired by: http://www.levibotelho.com/development/c-remove-diacritics-accents-from-a-string/
        /// </summary>
        public static string RemoveAccents(this string input)
        {
            // This may split character and accents into separate codes ('FormD').
            input = input.Normalize(NormalizationForm.FormD);
            // Removing accents from the string (classified as UnicodeCategory.NonSpacingMark).
            var str = new string(input.Where(x => CharUnicodeInfo.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark).ToArray());
            // This may compress the split characters and accents back into single characters.
            string renormalized = str.Normalize(NormalizationForm.FormC);
            return renormalized;
        }
    }
}
