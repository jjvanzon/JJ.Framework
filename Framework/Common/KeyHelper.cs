using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable PossibleMultipleEnumeration

namespace JJ.Framework.Common
{
    public static class KeyHelper
    {
        private static readonly string _separator = Guid.NewGuid().ToString();

        /// <summary>
        /// Turns several objects into a single string key.
        /// Only works if the objects' ToString() methods return something unique.
        /// </summary>
        public static string CreateKey<T>(IEnumerable<T> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            var strings = new string[values.Count()];

            var i = 0;

            foreach (T value in values)
            {
                strings[i] = Convert.ToString(value);
                i++;
            }

            string key = string.Join(_separator, strings);

            return key;
        }
    }
}