using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JJ.Framework.Common
{
    public static partial class StringExtensions
    {
        public static string Left(this string input, int length)
        {
            return input.Substring(0, length);
        }

        public static string Right(this string input, int length)
        {
            return input.Substring(input.Length - length, length);
        }

        public static string CutRight(this string input, char chr)
        {
            return CutRight(input, chr.ToString());
        }

        public static string CutRight(this string input, string end)
        {
            if (input.EndsWith(end)) return input.CutRight(end.Length);
            return input;
        }

        public static string CutRight(this string input, int length)
        {
            return input.Left(input.Length - length);
        }

        public static string CutLeft(this string input, char chr)
        {
            return CutLeft(input, chr.ToString());
        }

        public static string CutLeft(this string input, string start)
        {
            if (input.StartsWith(start)) return input.CutLeft(start.Length);
            return input;
        }

        public static string CutLeft(this string input, int length)
        {
            return input.Right(input.Length - length);
        }

        public static string FromTill(this string input, int startIndex, int endIndex)
        {
            return input.Substring(startIndex, endIndex - startIndex + 1);
        }

        public static string CutRightUntil(this string input, string until)
        {
            if (until == null) throw new ArgumentNullException("until");
            int index = input.LastIndexOf(until);
            if (index == -1) return input;
            string output = input.Left(index + until.Length);
            return output;
        }

        public static string CutLeftUntil(this string input, string until)
        {
            if (until == null) throw new ArgumentNullException("until");
            int index = input.IndexOf(until);
            if (index == -1) return input;
            string output = input.Right(input.Length - index);
            return output;
        }

        /// <summary>
        /// Trims and replaces sequences of two or more white space characters by a single space.
        /// </summary>
        public static string RemoveExcessiveWhiteSpace(this string text)
        {
            text = text.Trim();

            // Replace two or more white space characters by a single space.
            Regex regex = new Regex(@"(\s{2,})");
            text = regex.Replace(text, " ");

            return text;
        }

        public static string StartWithCap(this string input)
        {
            if (input.Length == 0)
            {
                return input;
            }

            return input.Left(1).ToUpper() + input.CutLeft(1);
        }

        public static string Replace(this string input, string oldValue, string newValue, bool ignoreCase)
        {
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
