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
            foreach (var x in items)
            {
                collection.Add(x);
            }
        }

        public static void Add<T>(this IList<T> collection, params T[] items)
        {
            foreach (var x in items)
            {
                collection.Add(x);
            }
        }



        /// <summary>
        /// Returns the list index of the first item that matches the predicate.
        /// </summary>
        public static int IndexOf<TSource>(this IList<TSource> collection, Func<TSource, bool> predicate)
        {
            int? indexOf = TryGetIndexOf(collection, predicate);

            if (indexOf.HasValue)
            {
                return indexOf.Value;
            }

            throw new Exception("No item in the collection matches the predicate.");
        }

        /// <summary>
        /// Returns the list index of the first item that matches the predicate.
        /// </summary>
        public static int? TryGetIndexOf<TSource>(this IList<TSource> collection, Func<TSource, bool> predicate)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (predicate == null) throw new ArgumentNullException("predicate");

            for (int i = 0; i < collection.Count; i++)
            {
                TSource item = collection[i];

                if (predicate(item))
                {
                    return i;
                }
            }

            return null;
        }
    }
}
