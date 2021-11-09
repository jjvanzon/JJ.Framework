using System.Collections.Generic;

namespace JJ.Framework.Common
{
    /// <summary>
    /// Generating a single string dictionary key out of multiple disparate values.
    /// Only works if the objects' ToString() methods return something unique.
    /// </summary>
    public static class KeyHelper
    {
        private const string DEFAULT_SEPARATOR = "89765d597c724aa3832070f21446a543";

        /// <inheritdoc cref="KeyHelper" />
        public static string CreateKey(IEnumerable<object> values)
            => CreateKey<object>(values);

        /// <inheritdoc cref="KeyHelper" />
        public static string CreateKey<T>(IEnumerable<T> values) => string.Join(DEFAULT_SEPARATOR, values);

        /// <inheritdoc cref="KeyHelper" />
        public static string CreateKey(IEnumerable<object> values, string separator)
            => CreateKey<object>(values, separator);

        /// <inheritdoc cref="KeyHelper" />
        public static string CreateKey<T>(IEnumerable<T> values, string separator) => string.Join(separator, values);

    }
}
