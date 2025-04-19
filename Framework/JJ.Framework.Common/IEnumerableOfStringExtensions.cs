using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    /// <inheritdoc cref="_collectionextensions" />
    public static class IEnumerableOfStringExtensions
    {
        /// <inheritdoc cref="_trimall" />
        public static string[] TrimAll(this IEnumerable<string> values, params char[] trimChars)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            return values.Select(x => x.Trim(trimChars)).ToArray();
        }
    }
}
