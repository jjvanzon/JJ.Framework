using System;
using System.Collections.Generic;

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
        /// An optional quote (") might be provided, to allow a separator character to be part of a value,
        /// by putting quotes around the value, e.g. "123,456".
        /// </summary>
        public static IList<string> SplitWithQuotation(this string input, char separator, char quote)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

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
                        // Starting quote.
                        inQuote = true;
                    }
                    // Finding separator
                    else if (chr == separator)
                    {
                        // Concluding a value
                        var value = new string(tempChars, 0, j);
                        values.Add(value);

                        // Starting over char counter.
                        j = 0;
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
                    if (i != input.Length - 1 && chr == quote && input[i + 1] == quote)
                    {
                        // Escaped quote.
                        tempChars[j] = quote;
                        j++;

                        // Skipping over 2nd quote
                        i++;
                    }
                    else if (chr == quote)
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
            }

            // Concluding last value (which may not end with a separator).
            var lastValue = new string(tempChars, 0, j);
            values.Add(lastValue);

            return values;
        }

        /// <inheritdoc cref="SplitWithQuotation(string, char, char)" />
        public static IList<string> SplitWithQuotation(this string input, string separator, string quote)
        {
            if (string.IsNullOrEmpty(separator)) throw new ArgumentException($"{nameof(separator)} is null or empty.");

            if (string.IsNullOrEmpty(quote))
            {
                return input.Split(separator);
            }

            if (separator.Length == 1 && quote.Length == 1)
            {
                return SplitWithQuotation(input, separator[0], quote[0]);
            }

            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

            var tempChars = new char[input.Length];
            var values = new List<string>();
            string twoQuotes = $"{quote}{quote}";
            char[] quoteCharArray = quote.ToCharArray();
            bool inQuote = false;
            int j = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char chr = input[i];

                if (!inQuote)
                {
                    if (input.SubstringOrLess(i, quote.Length) == quote)
                    {
                        // Starting quote.
                        inQuote = true;

                        // Skipping over quote.
                        i += quote.Length - 1;
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
                    // Escaped quote.
                    if (input.SubstringOrLess(i, quote.Length * 2) == twoQuotes) 
                    {
                        // Write quote to temp chars
                        Array.Copy(quoteCharArray, 0, tempChars, j, quote.Length);

                        j += quote.Length;

                        // Skipping over quotes.
                        i += twoQuotes.Length - 1;
                    }
                    // End quote
                    else if (input.SubstringOrLess(i, quote.Length) == quote)
                    {
                        inQuote = false;

                        // Skipping over quote.
                        i += quote.Length - 1;
                    }
                    else
                    {
                        // Value char found.
                        tempChars[j] = chr;
                        j++;
                    }
                }
            }

            // Concluding last value (which may not end with a separator).
            var lastValue = new string(tempChars, 0, j);
            values.Add(lastValue);

            return values;
        }
    }
}
