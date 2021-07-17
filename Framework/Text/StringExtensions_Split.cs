using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable S2589 // Boolean expressions should not be gratuitous

namespace JJ.Framework.Text
{
    public static class StringExtensions_Split
    {
        public static string[] Split(this string input, char separator, StringSplitOptions options)
            => input.Split(new[] { separator }, options);

        public static string[] Split(this string input, string separator, StringSplitOptions options)
            => input.Split(new[] { separator }, options);

        public static string[] Split(this string value, params string[] separators)
            => value.Split(separators, StringSplitOptions.None);

        [Obsolete("For a substitute to using StringSplitOptions: " +
                  "use SplitWithQuotation(...).Where(x => string.IsNullOrEmpty(x)).ToList() instead.",
                  true)]
        public static IList<string> SplitWithQuotation(this string input, string separator, StringSplitOptions options, char? quote)
            => throw new NotSupportedException(
                   "For a substitute to using StringSplitOptions: " +
                   "use SplitWithQuotation(...).Where(x => string.IsNullOrEmpty(x)).ToList() instead.");

        /// <summary>
        /// May split a CSV-like line of text into separate values.
        /// CSV means 'comma separated values'.
        /// An optional quote (") character might be provided, to allow a separator character to be part of a value,
        /// by putting quotes around the value, e.g. "123,456".
        /// </summary>
        public static IList<string> SplitWithQuotation(this string input, string separator, char quote)
        {
            if (string.IsNullOrEmpty(separator)) throw new ArgumentNullException(nameof(separator));

            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

            char previousChar = '\0';
            var tempChars = new char[input.Length];
            var values = new List<string>();
            bool inQuote = false;
            int j = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char chr = input[i];

                if (!inQuote)
                {
                    if (chr == quote)
                    {
                        if (previousChar == quote)
                        {
                            // Oh, no, still in quote.
                            inQuote = true;

                            // It was an escaped quote.
                            tempChars[j] = quote;
                            j++;
                        }
                        else
                        {
                            // Starting quote.
                            inQuote = true;
                        }
                    }
                    // Finding separator
                    else if (input.SubstringOrLess(i, separator.Length) == separator)
                    {
                        // Concluding a value
                        var value = new string(tempChars, 0, j);
                        values.Add(value);

                        // Starting over char counter.
                        j = 0;

                        // Skipping over separator.
                        i += separator.Length - 1;
                    }
                    else
                    {
                        // Value char found.
                        tempChars[j] = chr;
                        j++;
                    }
                }
                else // if (inQuote)
                {
                    if (chr == quote)
                    {
                        // End quote
                        inQuote = false;
                    }
                    else
                    {
                        // Value char found.
                        tempChars[j] = chr;
                        j++;
                    }
                }

                previousChar = chr;
            }

            // Concluding last value (which may not end with a separator).
            var lastValue = new string(tempChars, 0, j);
            values.Add(lastValue);

            return values;
        }
    }
}
