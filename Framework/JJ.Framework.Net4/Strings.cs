using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Net4
{
    /// <summary>
    /// Contains substitutes for static String methods that are not present in .NET versions lower than 4.0.
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            return String.Join(separator, values.Select(x => x.ToString()).ToArray());
        }

        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static bool IsNullOrWhiteSpace(string value)
        {
            if (value == null)
            {
                return true;
            }

            if (value == "")
            {
                return true;
            }

            if (value.Trim() == "")
            {
                return true;
            }

            return false;
        }
    }
}
