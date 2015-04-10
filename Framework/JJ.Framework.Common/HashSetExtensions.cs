using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static class HashSetExtensions
    {
        public static void AddRange<T>(this HashSet<T> dest, IEnumerable<T> source)
        {
            if (dest == null) throw new ArgumentNullException("dest");

            foreach (T item in source)
            {
                dest.Add(item);
            }
        }
    }
}
