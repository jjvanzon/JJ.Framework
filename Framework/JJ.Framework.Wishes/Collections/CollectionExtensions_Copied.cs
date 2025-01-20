using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Wishes.Collections
{
    public static class CollectionExtensions_Copied
    {
        /// <inheritdoc cref="docs._frameworkwishproduct" />
        public static double Product<TSource>(this IEnumerable<TSource> collection, Func<TSource, double> selector)
            => collection.Select(selector).Product();
    
        /// <summary> AddRange is a member of List&lt;T&gt;. Here is an overload for HashSet&lt;T&gt;. </summary>
        public static void AddRange<T>(this HashSet<T> dest, IEnumerable<T> source)
        {
            if (dest == null) throw new ArgumentNullException(nameof(dest));
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (T item in source)
            {
                dest.Add(item);
            }
        }

        /// <summary>
        /// Distinct that takes a key selector that determines what makes an item unique, e.g. myItems.Distinct(x => x.LastName);
        /// For multi-part as keys, use `myItems.Distinct(x => new { x.FirstName, x.LastName });`
        /// </summary>
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
    
        /// <summary>
        /// Similar to OfType&lt;T&gt; but now taking a Type.
        /// This misses the advantage of automatically casting items to the desired type.
        /// Still this may be useful for certain cases.
        /// </summary>
        public static IEnumerable<TSource> OfType<TSource>(this IEnumerable<TSource> source, Type type)
            => source.Where(x => x.GetType() == type);
    }
}
