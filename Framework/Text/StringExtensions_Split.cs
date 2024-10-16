﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Text
{
    public static class StringExtensions_Split
    {
        public static string[] Split(this string input, char separator, StringSplitOptions options)
            => input.Split(new[] { separator }, options);

        public static string[] Split(this string input, string separator, StringSplitOptions options)
            => input.Split(new[] { separator }, options);

        public static IList<string> SplitWithQuotation(this string input, string separator, char quote)
            => input.SplitWithQuotation(separator, StringSplitOptions.None, quote);

        public static string[] Split(this string value, params string[] separators)
            => value.Split(separators, StringSplitOptions.None);

        public static IList<string> SplitWithQuotation(this string input, string separator, StringSplitOptions options, char? quote)
        {
            IList<string> values = SplitWithQuotation_WithoutUnescape(input, separator, options, quote);

            if (quote.HasValue)
            {
                values = values.Select(x => x.Trim(quote.Value)).ToArray();
            }

            return values;
        }

        private static IList<string> SplitWithQuotation_WithoutUnescape(
            this string input,
            string separator,
            StringSplitOptions options,
            char? quote)
        {
            if (!quote.HasValue)
            {
                return input.Split(separator, options);
            }

            if (string.IsNullOrEmpty(separator))
            {
                throw new ArgumentNullException(nameof(separator));
            }

            if (string.IsNullOrEmpty(input))
            {
                return new string[0];
            }

            IList<string> values = new List<string>();

            var inQuote = false;
            var startPos = 0;

            int forEnd = input.Length - separator.Length;

            for (var pos = 0; pos <= forEnd; pos++)
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

                    if (!string.IsNullOrEmpty(value) || options != StringSplitOptions.RemoveEmptyEntries)
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
            if (!string.IsNullOrEmpty(str2) || options != StringSplitOptions.RemoveEmptyEntries)
            {
                values.Add(str2);
            }

            return values;
        }
    }
}