using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            foreach (T item in collection)
            {
                yield return item;

                if (item != null)
                {
                    foreach (T item2 in selector(item).SelectRecursive(selector))
                    {
                        yield return item2;
                    }
                }
            }
        }

        /// <summary>
        /// Includes the collection it is executed upon in the result.
        /// </summary>
        public static IEnumerable<T> AndRecursive<T>(this IEnumerable<T> collection, Func<T, IEnumerable<T>> selector)
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
        /// Does not include the collection it is executed upon in the result.
        /// </summary>
        public static IEnumerable<T> SelectRecursive<T>(this IList<T> collection, Func<T, IList<T>> selector)
        {
            // TODO: Beware: nested enumerators.

            if (collection == null) throw new ArgumentNullException("collection");
            if (selector == null) throw new ArgumentNullException("selector");

            for (int i = 0; i < collection.Count; i++)
            {
                T item = collection[i];

                yield return item;

                if (item != null)
                {
                    foreach (T item2 in selector(item).SelectRecursive(selector))
                    {
                        yield return item2;
                    }
                }
            }
        }

        /// <summary>
        /// Includes the collection it is executed upon in the result.
        /// </summary>
        public static IEnumerable<T> AndRecursive<T>(this IList<T> collection, Func<T, IList<T>> selector)
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
        /// Original Except from .NET automatically also does a distinct, which is something you do not always want.
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> input, bool distinct)
        {
            // 
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
    }
}
