using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static partial class StringExtensions
    {
        public static string[] Split(this string str, char separator, StringSplitOptions options)
        {
            return str.Split(new char[] { separator }, options);
        }

        public static string[] Split(this string str, string separator, StringSplitOptions options)
        {
            return str.Split(new string[] { separator }, options);
        }

        public static string[] Split(this string value, string separator, char quote)
        {
            return value.Split(separator, StringSplitOptions.None, quote);
        }

        public static string[] Split(this string value, params string[] separators)
        {
            return value.Split(separators, StringSplitOptions.None);
        }

        public static string[] Split(this string value, string separator, StringSplitOptions options, char? quote)
        {
            // TODO: Make code better understandable.

            if (!quote.HasValue)
            {
                return value.Split(separator, options);
            }

            if (String.IsNullOrEmpty(separator))
            {
                throw new ArgumentNullException("separator");
            }

            if (String.IsNullOrEmpty(value))
            {
                return new string[0];
            }

            var strings = new List<string>();

            bool inQuote = false;
            int startPos = 0;

            for (int pos = 0; pos < value.Length - separator.Length + 1; pos++)
            {
                char chr = value[pos];

                if (chr == quote.Value) inQuote = !inQuote;
                if (inQuote) continue;

                if (value.Substring(pos, separator.Length) == separator)
                {
                    string str = value.FromTill(startPos, pos - 1);

                    if (!String.IsNullOrEmpty(str) || options != StringSplitOptions.RemoveEmptyEntries)
                    {
                        strings.Add(str);
                    }

                    startPos = pos + separator.Length;
                }
            }

            string str2 = value.FromTill(startPos, value.Length - 1);
            if (!String.IsNullOrEmpty(str2) || options != StringSplitOptions.RemoveEmptyEntries)
            {
                strings.Add(str2);
            }

            return strings.TrimAll(quote.Value);
        }
    }
}
