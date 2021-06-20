using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable PossibleMultipleEnumeration

namespace JJ.Framework.Common
{
    /// <summary>
    /// Turns several objects into a single string key.
    /// Only works if the objects' ToString() methods return something unique.
    /// </summary>
    public static class KeyHelper
    {
        private const string SEPARATOR = "89765d597c724aa3832070f21446a543";

        /// <inheritdoc cref="KeyHelper" />
        public static string CreateKey(IEnumerable<object> values)
            => CreateKey<object>(values);

        /// <inheritdoc cref="KeyHelper" />
        public static string CreateKey<T>(IEnumerable<T> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            string key = string.Join(SEPARATOR, values);
            return key;
        }
    }
}