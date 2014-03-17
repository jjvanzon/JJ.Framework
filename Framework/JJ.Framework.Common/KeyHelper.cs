using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static class KeyHelper
    {
        private static string _separator;

        static KeyHelper()
        {
            _separator = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Turns several objects into a single string key.
        /// Only works if the objects' ToString() methods return something unique.
        /// </summary>
        public static string CreateKey(object[] values)
        {
            string key = "";
            foreach (object obj in values)
            {
                if (!String.IsNullOrEmpty(key))
                {
                    key += _separator;
                }

                key += (obj ?? "").ToString();
            }
            return key;
        }
    }
}
