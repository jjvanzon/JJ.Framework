using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.PlatformCompatibility
{
    /// <summary>
    /// Contains substitutes for static String methods that are not present in some .NET versions.
    /// </summary>
    public static class String_PlatformSupport
    {
        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            return PlatformHelper.String_Join_PlatformSupport(separator, values);
        }

        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static bool IsNullOrWhiteSpace(string value)
        {
            return PlatformHelper.String_IsNullOrWhiteSpace_PlatformSupport(value);
        }
    }
}
