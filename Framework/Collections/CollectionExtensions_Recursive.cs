using System;
using System.Collections.Generic;

namespace JJ.Framework.Collections
{
    public static class CollectionExtensions_Recursive
    {
        // TODO: Maintain the recursive order as you traverse the tree and enumerate.

        // TODO: Make IList variation actually faster 
        // and better debuggable by preventing enumerator creation 
        // and privately adding to a single list.

        /// <summary> Does not include the collection it is executed upon in the result. <summary>
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> collection, Func<T, IEnumerable<T>> selector)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            foreach (T sourceItem in collection)
            {
                if (sourceItem != null)
                {
                    foreach (T destItem in sourceItem.SelectRecursive(selector))
                    {
                        yield return destItem;
                    }
                }
            }
        }

        /// <summary> Does not include the collection it is executed upon in the result. <summary>
        public static IEnumerable<T> SelectRecursive<T>(this IList<T> collection, Func<T, IList<T>> selector)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            for (int i = 0; i < collection.Count; i++)
            {
                T sourceItem = collection[i];

                if (sourceItem != null)
                {
                    foreach (T destItem in sourceItem.SelectRecursive(selector))
                    {
                        yield return destItem;
                    }
                }
            }
        }

        /// <summary> Does not include the item it is executed upon in the result. <summary>
        public static IEnumerable<T> SelectRecursive<T>(this T sourceItem, Func<T, IList<T>> selector)
        {
            if (sourceItem == null) throw new ArgumentNullException(nameof(sourceItem));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            IEnumerable<T> destItems = selector(sourceItem);

            foreach (T destItem in destItems.UnionRecursive(selector))
            {
                yield return destItem;
            }
        }

        /// <summary> Does not include the item it is executed upon in the result. <summary>
        public static IEnumerable<T> SelectRecursive<T>(this T sourceItem, Func<T, IEnumerable<T>> selector)
        {
            if (sourceItem == null) throw new ArgumentNullException(nameof(sourceItem));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            IEnumerable<T> destItems = selector(sourceItem);

            foreach (T destItem in destItems.UnionRecursive(selector))
            {
                yield return destItem;
            }
        }

        /// <summary> Includes the collection it is executed upon in the result. <summary>
        public static IEnumerable<T> UnionRecursive<T>(this IEnumerable<T> collection, Func<T, IEnumerable<T>> selector)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

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
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

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

        /// <summary> Includes the item it is executed upon in the result. <summary>
        public static IEnumerable<T> UnionRecursive<T>(this T sourceItem, Func<T, IList<T>> selector)
        {
            if (sourceItem == null) throw new ArgumentNullException(nameof(sourceItem));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            yield return sourceItem;

            foreach (T item in sourceItem.SelectRecursive(selector))
            {
                yield return item;
            }
        }

        /// <summary> Includes the item it is executed upon in the result. <summary>
        public static IEnumerable<T> UnionRecursive<T>(this T sourceItem, Func<T, IEnumerable<T>> selector)
        {
            if (sourceItem == null) throw new ArgumentNullException(nameof(sourceItem));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            yield return sourceItem;

            foreach (T item in sourceItem.SelectRecursive(selector))
            {
                yield return item;
            }
        }
    }
}
