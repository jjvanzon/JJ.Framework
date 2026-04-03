namespace JJ.Framework.Collections.Core
{
    public static class CollectionExtensionsLegacy
    {
        /// <inheritdoc cref="_product" />
        public static double Product<TSource>(this IEnumerable<TSource> collection, Func<TSource, double> selector)
            => collection.Select(selector).Product();

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
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return source.Where(x => x?.GetType() == type);
        }

        /// <summary> Overload of Concat that takes a single item, e.g. myCollection.Concat(myItem); </summary>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, T second) => first.Concat(new[] { second });
        
        /// <summary>
        /// Overload of Concat that starts with a single item and then adds a collection to it e.g.
        /// myItem.Concat(myCollection);
        /// </summary>
        public static IEnumerable<T> Concat<T>(this T first, IEnumerable<T> second) => new[] { first }.Concat(second);

        /// <summary>
        /// An overload of Except that takes a predicate, e.g. myCollection.Except(x => string.Equals("Blah");
        /// (This is the same as a negated Where predicate, but if you are already thinking in terms of Except,
        /// this might express your intent clearer.)
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return source.Where(x => !predicate(x));
        }
    }
}
