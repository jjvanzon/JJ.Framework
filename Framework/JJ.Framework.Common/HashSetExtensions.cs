using System;
using System.Collections.Generic;

namespace JJ.Framework.Common
{
    public static class HashSetExtensions
    {
        public static void AddRange<T>(this HashSet<T> dest, IEnumerable<T> source)
        {
            if (dest == null) throw new ArgumentNullException("dest");
            if (source == null) throw new ArgumentNullException("source");

            foreach (T item in source)
            {
                dest.Add(item);
            }
        }
    }
}
