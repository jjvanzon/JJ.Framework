using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static class Strings
    {
        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            return String.Join(separator, values.Select(x => x.ToString()).ToArray());
        }

        public static bool IsNullOrWhiteSpace(string value)
        {
            if (value == null)
            {
                return true;
            }

            if( value == "")
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
