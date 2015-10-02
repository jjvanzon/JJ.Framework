using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Common
{
    public static class CollectionExtensions
    {
        private static string _separatorGuidString = GetSeparatorGuid();
        private static string _nullGuidString = GetNullGuid();

        private static string GetNullGuid()
        {
            return Guid.NewGuid().ToString();
        }

        private static string GetSeparatorGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static void AddRange<T>(this HashSet<T> dest, IEnumerable<T> source)
        {
            if (dest == null) throw new ArgumentNullException("dest");
            if (source == null) throw new ArgumentNullException("source");

            foreach (T item in source)
            {
                dest.Add(item);
            }
        }

        public static void AddRange<T>(this IList<T> collection, IEnumerable<T> items)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (items == null) throw new ArgumentNullException("items");

            foreach (var x in items)
            {
                collection.Add(x);
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
                separator = _separatorGuidString;
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
                        keyElementString = _nullGuidString;
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
        public static int IndexOf<TSource>(this IList<TSource> collection, Func<TSource, bool> predicate)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (predicate == null) throw new ArgumentNullException("predicate");

            int? index = TryGetIndexOf(collection, predicate);

            if (index.HasValue)
            {
                return index.Value;
            }

            throw new Exception("No item in the collection matches the predicate.");
        }

        /// <summary>
        /// Returns the list index of the first item that matches the predicate.
        /// Does not check duplicates, because that would make it slower.
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

        /// <summary>
        /// Removes the first occurrence that matches the predicate.
        /// Throws an exception no item matches the predicate.
        /// Does not check duplicates, which makes it faster if you are sure only one item is in it.
        /// </summary>
        public static void RemoveFirst<TSource>(this IList<TSource> collection, Func<TSource, bool> predicate)
        {
            int index = IndexOf(collection, predicate);
            collection.RemoveAt(index);
        }

        /// <summary>
        /// Removes the first occurrence that matches the predicate.
        /// Does nothing if no item matches the predicate.
        /// Does not check duplicates, which makes it faster if you are sure only one item is in it.
        /// Returns whether an item was actually removed from the collection.
        /// </summary>
        public static bool TryRemoveFirst<TSource>(this IList<TSource> collection, Func<TSource, bool> predicate)
        {
            int? index = TryGetIndexOf(collection, predicate);
            if (!index.HasValue)
            {
                return false;
            }

            collection.RemoveAt(index.Value);
            return true;
        }

        public static string[] TrimAll(this IEnumerable<string> values, params char[] trimChars)
        {
            return values.Select(x => x.Trim(trimChars)).ToArray();
        }

        public static void Add<T>(this IList<T> collection, params T[] items)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (items == null) throw new ArgumentNullException("items");

            foreach (var x in items)
            {
                collection.Add(x);
            }
        }
    }
}
