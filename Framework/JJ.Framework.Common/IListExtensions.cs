using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static class IListExtensions
    {
        public static void AddRange<T>(this IList<T> collection, IEnumerable<T> items)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (var x in items)
            {
                collection.Add(x);
            }
        }

        public static void Add<T>(this IList<T> collection, params T[] items)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (var x in items)
            {
                collection.Add(x);
            }
        }

        /*public static void Add(this IList collection, params object[] items)
        {
            foreach (var x in items)
            {
                collection.Add(x);
            }
        }*/
    }
}
