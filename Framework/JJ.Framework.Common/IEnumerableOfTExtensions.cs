using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Common
{
    public static class IEnumerableOfTExtensions
    {
        private static string _separatorGuid;
        private static string _nullGuid;

        static IEnumerableOfTExtensions()
        {
            _separatorGuid = Guid.NewGuid().ToString();
            _nullGuid = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Does not include the collection it is executed upon in the result.
        /// </summary>
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

        /// <summary>
        /// Does not include the collection it is executed upon in the result.
        /// </summary>
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
        /// <summary>
        /// Includes the collection it is executed upon in the result.
        /// </summary>
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

        /// <summary>
        /// Includes the collection it is executed upon in the result.
        /// </summary>
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

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) throw new ArgumentNullException("enumerable");
            if (action == null) throw new ArgumentNullException("action");

            foreach (var x in enumerable)
            {
                action(x);
            }
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> enumerable, T x)
        {
            return enumerable.Except(new T[] { x });
        }

        /// <summary>
        /// The original Except() method from .NET automatically does a distinct, which is something you do not always want.
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> input, bool distinct)
        {
            if (distinct)
            {
                return source.Except(input);
            }
            else
            {
                return source.Where(x => !input.Contains(x));
            }
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<T> enumerable, T x)
        {
            return enumerable.Union(new T[] { x });
        }

        public static IEnumerable<T> Union<T>(this T x, IEnumerable<T> enumerable)
        {
            return new T[] { x }.Union(enumerable);
        }

        // TODO: TKey is strange. You would think that the different elements of the key are not always of the same type.
        public static IEnumerable<TItem> Distinct<TItem, TKey>(this IEnumerable<TItem> enumerable, Func<TItem, TKey>[] keys)
        {
            string separator = "";
            if (keys.Length > 1)
            {
                separator = _separatorGuid;
            }

            var hash = new HashSet<string>();

            foreach (var x in enumerable)
            {
                string keyString = "";
                foreach (var key in keys)
                {
                    string keyElementString;
                    if (key(x) == null)
                    {
                        keyElementString = _nullGuid;
                    }
                    else
                    {
                        keyElementString = key(x).ToString();
                    }

                    keyString += keyElementString + separator;
                }

                if (!hash.Contains(keyString))
                {
                    yield return x;
                    hash.Add(keyString);
                }
            }
        }

        public static IEnumerable<TItem> AsEnumerable<TItem>(this TItem item)
        {
            return new TItem[] { item };
        }

        public static Dictionary<TKey, IList<TItem>> ToNonUniqueDictionary<TKey, TItem>(this IEnumerable<TItem> sourceCollection, Func<TItem, TKey> keySelector)
        {
            if (sourceCollection == null) throw new ArgumentNullException("sourceCollection");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            var dictionary = new Dictionary<TKey, IList<TItem>>();

            foreach (TItem item in sourceCollection)
            {
                TKey key = keySelector(item);

                IList<TItem> itemsUnderKey;
                if (!dictionary.TryGetValue(key, out itemsUnderKey))
                {
                    itemsUnderKey = new List<TItem>();
                    dictionary.Add(key, itemsUnderKey);
                }
                itemsUnderKey.Add(item);
            }

            return dictionary;
        }

        public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            where TResult : new()
        {
            if (!source.Any())
            {
                return new TResult();
            }

            return source.Max(selector);
        }

        /// <summary>
        /// Returns the list index of the first item that matches the predicate.
        /// Does not check duplicates, because that would make it slower.
        /// </summary>
        public static int IndexOf<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate)
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
        /// Does not check duplicates, because that would make it slower.
        /// </summary>
        public static int? TryGetIndexOf<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (predicate == null) throw new ArgumentNullException("predicate");

            int i = 0;
            foreach (TSource item in collection)
            {
                if (predicate(item))
                {
                    return i;
                }

                i++;
            }

            return null;
        }
    }
}
