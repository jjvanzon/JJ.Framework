using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common.Legacy 
{
    /// <inheritdoc cref="_collectionextensions" />
    public static class IEnumerableOfTExtensions
    {
        private static string _separatorGuid;
        private static string _nullGuid;

        /// <inheritdoc cref="_collectionextensions" />
        static IEnumerableOfTExtensions()
        {
            _separatorGuid = Guid.NewGuid().ToString();
            _nullGuid = Guid.NewGuid().ToString();
        }

        /// <remarks>
        /// Does not include the collection it is executed upon in the result.
        /// </remarks>
        /// <inheritdoc cref="_selectrecursive" />
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> collection, Func<T, IEnumerable<T>> selector)
        {
            // TODO: Beware: nested enumerators.

            if (collection == null) throw new ArgumentNullException("collection");
            if (selector == null) throw new ArgumentNullException("selector");

            foreach (T item in collection)
            {
                // This method should not return source items, just dest items, but check well before you change the behavior.
                
                //yield return item;

                if (item != null)
                {
                    //foreach (T item2 in selector(item).SelectRecursive(selector))
                    foreach (T item2 in selector(item).UnionRecursive(selector))
                    {
                        yield return item2;
                    }
                }
            }
        }

        /// <remarks>
        /// Includes the collection it is executed upon in the result.
        /// </remarks>
        /// <inheritdoc cref="_unionrecursive" />
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

        /// <remarks>
        /// Does not include the collection it is executed upon in the result.
        /// </remarks>
        /// <inheritdoc cref="_selectrecursive" />
        public static IEnumerable<T> SelectRecursive<T>(this IList<T> collection, Func<T, IList<T>> selector)
        {
            // TODO: Beware: nested enumerators.

            if (collection == null) throw new ArgumentNullException("collection");
            if (selector == null) throw new ArgumentNullException("selector");

            for (int i = 0; i < collection.Count; i++)
            {
                T item = collection[i];

                // This method should not return source items, just dest items, but check well before you change the behavior.
                
                //yield return item;

                if (item != null)
                {
                    //foreach (T item2 in selector(item).SelectRecursive(selector))
                    foreach (T item2 in selector(item).UnionRecursive(selector))
                    {
                        yield return item2;
                    }
                }
            }
        }

        /// <remarks>
        /// Includes the collection it is executed upon in the result.
        /// </remarks>
        /// <inheritdoc cref="_unionrecursive" />
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

        /// <summary>
        /// Not all collection types have the ForEach method. Here you have an overload for IEnumerable&lt;T&gt; so you
        /// can use it for more collection types.
        /// </summary>
        /// <inheritdoc cref="_foreach" />
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (var x in enumerable)
            {
                action(x);
            }
        }

        /// <summary> An overload of Except that takes just a single item, e.g. myCollection.Except(myItem); </summary>
        /// <inheritdoc cref="_except" />
        public static IEnumerable<T> Except<T>(this IEnumerable<T> enumerable, T x)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            return enumerable.Except(new T[] { x });
        }

        /// <summary>
        /// Original Except from .NET automatically also does a distinct, which is something you do not always want.
        /// </summary>
        /// <inheritdoc cref="_except" />
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> input, bool distinct)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
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

        /// <inheritdoc cref="_union" />
        public static IEnumerable<T> Union<T>(this IEnumerable<T> enumerable, T x)
        {
            return enumerable.Union(new T[] { x });
        }

        /// <inheritdoc cref="_union" />
        public static IEnumerable<T> Union<T>(this T x, IEnumerable<T> enumerable)
        {
            return new T[] { x }.Union(enumerable);
        }

        // TODO: TKey is strange. You would think that the different elements of the key are not always of the same type.
        /// <inheritdoc cref="_distinct" />
        public static IEnumerable<TItem> Distinct<TItem, TKey>(this IEnumerable<TItem> enumerable, params Func<TItem, TKey>[] keys)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (keys == null) throw new ArgumentNullException(nameof(keys));
            if (keys.Contains(null)) throw new Exception("keys contains nulls.");
            
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

        /// <inheritdoc cref="_asenumerable" />
        public static IEnumerable<TItem> AsEnumerable<TItem>(this TItem item)
        {
            return new TItem[] { item };
        }
    }
}
