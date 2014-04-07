using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static class KeyHelper
    {
        private static string _separator = Guid.NewGuid().ToString();

        /// <summary>
        /// Turns several objects into a single string key.
        /// Only works if the objects' ToString() methods return something unique.
        /// </summary>
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
