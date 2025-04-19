using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    /// <inheritdoc cref="_keyhelper" />
    public static class KeyHelper
    {
        private static string _separator = Guid.NewGuid().ToString();

        /// <remarks>
        /// Turns several objects into a single string key.
        /// Only works if the objects' ToString() methods return something unique.
        /// </remarks>
        /// <inheritdoc cref="_keyhelper" />
        public static string CreateKey(object[] values)
        {
            string[] strings = new string[values.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = Convert.ToString(values[i]);
            }

            string key = String.Join(_separator, strings);

            return key;
        }
    }
}
