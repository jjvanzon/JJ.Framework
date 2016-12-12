using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static class CollectionExtensions_Recursive
    {
        /// <summary> Does not include the collection it is executed upon in the result. <summary>
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> collection, Func<T, IEnumerable<T>> selector)
        {
            // TODO: Beware: nested enumerators.

            if (collection == null) throw new ArgumentNullException("collection");
            if (selector == null) throw new ArgumentNullException("selector");

            foreach (T sourceItem in collection)
            {
                // TODO: This method should not return source items, just dest items, but check well before you change the behavior.
                yield return sourceItem;

                if (sourceItem != null)
                {
                    foreach (T destItem in selector(sourceItem).SelectRecursive(selector))
                    {
                        yield return destItem;
                    }
                }
            }
        }

        /// <summary> not include the collection it is executed upon in the result. <summary>
        public static IEnumerable<T> SelectRecursive<T>(this IList<T> collection, Func<T, IList<T>> selector)
        {
            // TODO: Beware: nested enumerators.

            if (collection == null) throw new ArgumentNullException("collection");
            if (selector == null) throw new ArgumentNullException("selector");

            for (int i = 0; i < collection.Count; i++)
            {
                T sourceItem = collection[i];

                // TODO: This method should not return source items, just dest items, but check well before you change the behavior.
                yield return sourceItem;

                if (sourceItem != null)
                {
                    foreach (T destItem in selector(sourceItem).SelectRecursive(selector))
                    {
                        yield return destItem;
                    }
                }
            }
        }
        /// <summary> the collection it is executed upon in the result. <summary>
        public static IEnumerable<T> UnionRecursive<T>(this IEnumerable<T> collection, Func<T, IEnumerable<T>> selector)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (selector == null) throw new ArgumentNullException("selector");

            foreach (T item in collection)
            {
                yield return item;
            }

            foreach (T item in collection.SelectRecursive(selector))
            {
                yield return item;
            }
        }

        /// <summary> Includes the collection it is executed upon in the result. <summary>
        public static IEnumerable<T> UnionRecursive<T>(this IList<T> collection, Func<T, IList<T>> selector)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (selector == null) throw new ArgumentNullException("selector");

            for (int i = 0; i < collection.Count; i++)
            {
                T item = collection[i];
                yield return item;
            }

            foreach (T item in collection.SelectRecursive(selector))
            {
                yield return item;
            }
        }
    }
}
