using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using JJ.Framework.Common.docs;

namespace JJ.Framework.Common
{
    public static partial class StringExtensions_Split
    {
        public static string[] Split(this string input, char separator, StringSplitOptions options)
        {
            return input.Split(new char[] { separator }, options);
        }

        public static string[] Split(this string input, string separator, StringSplitOptions options)
        {
            return input.Split(new string[] { separator }, options);
        }

        /// <inheritdoc cref="_splitwithquotation" />
        public static string[] SplitWithQuotation(this string input, string separator, char quote)
        {
            string[] values = input.SplitWithQuotation_WithoutUnescape(separator, quote);
            values = Unescape(values, quote);
            return values;
        }

        public static string[] Split(this string value, params string[] separators)
        {
            return value.Split(separators, StringSplitOptions.None);
        }

        /// <inheritdoc cref="_splitwithquotation" />
        public static string[] SplitWithQuotation(this string input, string separator, StringSplitOptions options, char? quote)
        {
            string[] values = SplitWithQuotation_WithoutUnescape(input, separator, options, quote);
            values = Unescape(values, quote);
            return values;
        }
        
        private static string[] Unescape(string[] values, char? quote)
        {
            if (quote == null) return values;

            return values.Select(value => (value ?? "")
                         .Replace($"{quote}{quote}", $"{quote}")
                         .Trim(quote.Value))
                         .ToArray();
        }
        
        /// <inheritdoc cref="_splitwithquotation" />
        private static string[] SplitWithQuotation_WithoutUnescape(this string input, string separator, char quote)
        {
            return input.SplitWithQuotation_WithoutUnescape(separator, StringSplitOptions.None, quote);
        }

        /// <inheritdoc cref="_splitwithquotation" />
        private static string[] SplitWithQuotation_WithoutUnescape(this string input, string separator, StringSplitOptions options, char? quote)
        {
            if (!quote.HasValue)
            {
                return input.Split(separator, options);
            }

            if (String.IsNullOrEmpty(separator))
            {
                throw new ArgumentNullException("separator");
            }

            if (String.IsNullOrEmpty(input))
            {
                return new string[0];
            }

            IList<string> values = new List<string>();

            bool inQuote = false;
            int startPos = 0;

            for (int pos = 0; pos < input.Length - separator.Length + 1; pos++)
            {
                char chr = input[pos];

                // Handle quotation
                if (chr == quote.Value)
                {
                    inQuote = !inQuote;
                }

                if (inQuote)
                {
                    continue;
                }

                // Detect separator
                if (input.Substring(pos, separator.Length) == separator)
                {
                    // An end-of-element was found.
                    string value = input.FromTill(startPos, pos - 1);

                    if (!String.IsNullOrEmpty(value) || options != StringSplitOptions.RemoveEmptyEntries)
                    {
                        values.Add(value);
                    }

                    // Next element is starting.
                    startPos = pos + separator.Length;
                }
            }

            // Add last element
            // (For the previous elements, the separator functions as an end-of-value, while the last value does hot have that.)
            string str2 = input.FromTill(startPos, input.Length - 1);
            if (!String.IsNullOrEmpty(str2) || options != StringSplitOptions.RemoveEmptyEntries)
            {
                values.Add(str2);
            }

            return values.ToArray();
        }
    }
}
