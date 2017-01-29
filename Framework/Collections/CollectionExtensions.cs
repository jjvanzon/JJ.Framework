using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Collections
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this HashSet<T> dest, IEnumerable<T> source)
        {
            if (dest == null) throw new ArgumentNullException(nameof(dest));
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (T item in source)
            {
                dest.Add(item);
            }
        }

        public static void AddRange<T>(this IList<T> collection, IEnumerable<T> items)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (var x in items)
            {
                collection.Add(x);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (T x in enumerable)
            {
                action(x);
            }
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> enumerable, T x)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            return enumerable.Except(new[] { x });
        }

        /// <summary>
        /// The original Except() method from .NET automatically does a distinct, which is something you do not always want.
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> input, bool distinct)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (input == null) throw new ArgumentNullException(nameof(input));

            if (distinct)
            {
                return source.Except(input);
            }
            else
            {
                return source.Where(x => !input.Contains(x));
            }
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return source.Where(x => !predicate(x));
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<T> enumerable, T x)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            return enumerable.Union(new[] { x });
        }

        public static IEnumerable<T> Union<T>(this T x, IEnumerable<T> enumerable)
        {
            return new[] { x }.Union(enumerable);
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> enumerable, T x)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            return enumerable.Concat(new[] { x });
        }

        public static IEnumerable<T> Concat<T>(this T x, IEnumerable<T> enumerable)
        {
            return new[] { x }.Concat(enumerable);
        }

        public static IEnumerable<TItem> Distinct<TItem, TKey>(this IEnumerable<TItem> enumerable, Func<TItem, TKey> keySelector)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var hashSet = new HashSet<TKey>();

            foreach (TItem item in enumerable)
            {
                TKey key = keySelector(item);

                if (hashSet.Add(key))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TItem> AsEnumerable<TItem>(this TItem item)
        {
            return new[] { item };
        }

        public static Dictionary<TKey, IList<TItem>> ToNonUniqueDictionary<TKey, TItem>(this IEnumerable<TItem> sourceCollection, Func<TItem, TKey> keySelector)
        {
            if (sourceCollection == null) throw new ArgumentNullException(nameof(sourceCollection));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return sourceCollection.ToNonUniqueDictionary(keySelector, x => x);
        }

        public static Dictionary<TKey, IList<TDestItem>> ToNonUniqueDictionary<TKey, TSourceItem, TDestItem>(
            this IEnumerable<TSourceItem> sourceCollection, 
            Func<TSourceItem, TKey> keySelector,
            Func<TSourceItem, TDestItem> elementSelector)
        {
            if (sourceCollection == null) throw new ArgumentNullException(nameof(sourceCollection));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));

            var dictionary = new Dictionary<TKey, IList<TDestItem>>();

            foreach (TSourceItem item in sourceCollection)
            {
                TKey key = keySelector(item);

                IList<TDestItem> elementsUnderKey;
                if (!dictionary.TryGetValue(key, out elementsUnderKey))
                {
                    elementsUnderKey = new List<TDestItem>();
                    dictionary.Add(key, elementsUnderKey);
                }

                TDestItem element = elementSelector(item);
                elementsUnderKey.Add(element);
            }

            return dictionary;
        }

        public static TSource MaxOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            // ReSharper disable once PossibleMultipleEnumeration
            if (!source.Any())
            {
                return default(TSource);
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return source.Max();
        }

        public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            // ReSharper disable once PossibleMultipleEnumeration
            if (!source.Any())
            {
                return default(TResult);
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return source.Max(selector);
        }

        public static TSource MinOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            // ReSharper disable once PossibleMultipleEnumeration
            if (!source.Any())
            {
                return default(TSource);
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return source.Min();
        }

        public static TResult MinOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            // ReSharper disable once PossibleMultipleEnumeration
            if (!source.Any())
            {
                return default(TResult);
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return source.Min(selector);
        }

        /// <summary>
        /// IList&lt;T&gt; has an IndexOf method natively. This overload provides one for IEnumerable&lt;T&gt;,
        /// for both syntactic sugar and it prevents full materialization of the collection.
        /// This method prefixed with 'TryGet' returns null if the item is not found.
        /// </summary>
        public static int? TryGetIndexOf<TItem>(this IEnumerable<TItem> collection, TItem item)
        {
            int i = 0;

            foreach (TItem item2 in collection)
            {
                if (object.Equals(item2, item))
                {
                    return i;
                }

                i++;
            }

            return null;
        }

        /// <summary>
        /// IList&lt;T&gt; has an IndexOf method natively. This overload provides one for IEnumerable&lt;T&gt;,
        /// for both syntactic sugar and it prevents full materialization of the collection.
        /// </summary>
        public static int IndexOf<TItem>(this IEnumerable<TItem> collection, TItem item)
        {
            int? i = TryGetIndexOf(collection, item);

            if (!i.HasValue)
            {
                throw new Exception($"{nameof(item)} not found.");
            }

            return i.Value;
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
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

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
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

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
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

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
            if (collection == null) throw new ArgumentNullException(nameof(collection));

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
            if (collection == null) throw new ArgumentNullException(nameof(collection));

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
            if (values == null) throw new ArgumentNullException(nameof(values));

            return values.Select(x => x.Trim(trimChars)).ToArray();
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

        public static double Product(this IEnumerable<double> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            // ReSharper disable once PossibleMultipleEnumeration
            double product = collection.FirstOrDefault();

            // ReSharper disable once PossibleMultipleEnumeration
            foreach (double value in collection.Skip(1))
            {
                product *= value;
            }

            return product;
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return new HashSet<T>(source);
        }
    }
}
