using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Globalization.CharUnicodeInfo;
using static System.Globalization.UnicodeCategory;
using static System.Text.NormalizationForm;

namespace JJ.Framework.Common
{
    /// <inheritdoc cref="_stringextensions" />
    public static partial class StringExtensions
    {
        /// <returns>
        /// Returns the left part of a string.
        /// </returns>
        /// <inheritdoc cref="_leftright" />
        public static string Left(this string input, int length)
        {
            return input.Substring(0, length);
        }

        /// <returns>
        /// Returns the right part of a string.
        /// </returns>
        /// <inheritdoc cref="_leftright" />
        public static string Right(this string input, int length)
        {
            return input.Substring(input.Length - length, length);
        }

        /// <remarks>
        /// Cuts off the right part of a string and returns the string with a portion cut off.
        /// </remarks>
        /// <inheritdoc cref="_cutleftorright" />
        public static string CutRight(this string input, char chr)
        {
            return CutRight(input, chr.ToString());
        }

        /// <remarks>
        /// Cuts off the right part of a string and returns what remains with a portion cut off.
        /// </remarks>
        /// <inheritdoc cref="_cutleftorright" />
        public static string CutRight(this string input, string end)
        {
            if (input.EndsWith(end)) return input.CutRight(end.Length);
            return input;
        }

        /// <remarks>
        /// Cuts off the right part of a string and returns what remains with a portion cut off.
        /// </remarks>
        /// <inheritdoc cref="_cutleftorright" />
        public static string CutRight(this string input, int length)
        {
            return input.Left(input.Length - length);
        }

        /// <remarks>
        /// Cuts off the left part of a string and returns what remains with a portion cut off.
        /// </remarks>
        /// <inheritdoc cref="_cutleftorright" />
        public static string CutLeft(this string input, char chr)
        {
            return CutLeft(input, chr.ToString());
        }

        /// <remarks>
        /// Cuts off the left part of a string and returns what remains with a portion cut off.
        /// </remarks>
        /// <inheritdoc cref="_cutleftorright" />
        public static string CutLeft(this string input, string start)
        {
            if (input.StartsWith(start)) return input.CutLeft(start.Length);
            return input;
        }

        /// <remarks>
        /// Cuts off the left part of a string and returns what remains with a portion cut off.
        /// </remarks>
        /// <inheritdoc cref="_cutleftorright" />
        public static string CutLeft(this string input, int length)
        {
            return input.Right(input.Length - length);
        }

        /// <inheritdoc cref="_fromtill" />
        public static string FromTill(this string input, int startIndex, int endIndex)
        {
            if (endIndex < startIndex) throw new Exception("endIndex lies before startIndex.");
            return input.Substring(startIndex, endIndex - startIndex + 1);
        }

        /// <remarks>
        /// Cuts off the right part of a string until the specified delimiter and returns what remains with a portion cut off still including the delimiter itself.
        /// </remarks>
        /// <inheritdoc cref="_cutleftorrightuntil" />
        public static string CutRightUntil(this string input, string until)
        {   
            if (string.IsNullOrEmpty(until)) throw new Exception($"{nameof(until)} is null or empty.");
            int index = input.LastIndexOf(until);
            if (index == -1) return input;
            string output = input.Left(index + until.Length);
            return output;
        }

        /// <remarks>
        /// Cuts off the left part of a string until the specified delimiter and returns what remains with a portion cut off still including the delimiter itself.
        /// </remarks>
        /// <inheritdoc cref="_cutleftorrightuntil" />
        public static string CutLeftUntil(this string input, string until)
        {
            if (string.IsNullOrEmpty(until)) throw new Exception($"{nameof(until)} is null or empty.");
            int index = input.IndexOf(until);
            if (index == -1) return input;
            string output = input.Right(input.Length - index);
            return output;
        }

        /// <remarks>
        /// Trims and replaces sequences of two or more white space characters by a single space.
        /// </remarks>
        /// <inheritdoc cref="_removeexcessivewhitespace" />
        public static string RemoveExcessiveWhiteSpace(this string text)
        {
            text = text.Trim();

            // Replace two or more white space characters by a single space.
            Regex regex = new Regex(@"(\s{2,})");
            text = regex.Replace(text, " ");

            return text;
        }
        
        // TODO: Manual merge back to legacy branch.
        public static string RemoveAccents(this string input)
        {
            if (input == null)
                return "";
            string formD = input.Normalize(FormD);
            var stripped = formD.Where(x => GetUnicodeCategory(x) != NonSpacingMark);
            return new string(stripped.ToArray()).Normalize(FormC);
        }
    
    /// <inheritdoc cref="_replace" />
        public static string Replace(this string input, string oldValue, string newValue, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(input)) return input;
            if (string.IsNullOrEmpty(oldValue)) return input;
            newValue ??= "";

            RegexOptions options = default(RegexOptions);
            if (ignoreCase)
            {
                options = RegexOptions.IgnoreCase;
            }

            var regex = new Regex(Regex.Escape(oldValue), options);
            string output = regex.Replace(input, newValue);
            return output;
        }
    }
}
