// ReSharper disable ConvertToExtensionBlock

namespace JJ.Framework.Collections.Legacy
{
    /// <inheritdoc cref="_collectionextensionsrecursiveancestors" />
    public static class CollectionExtensions_Recursive_Ancestors_Legacy
    {
        /// <inheritdoc cref="_selfandancestors" />
        public static IEnumerable<T> SelfAndAncestors<T>(this T sourceItem, Func<T, T?> selector)
        {
            if (sourceItem == null) throw new ArgumentNullException(nameof(sourceItem));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var destHashSet = new HashSet<T> { sourceItem };

            SelectAncestors(sourceItem, selector, destHashSet);

            return destHashSet;
        }

        /// <inheritdoc cref="_selectancestors" />
        public static IEnumerable<T> SelectAncestors<T>(this T sourceItem, Func<T, T?> selector)
        {
            if (sourceItem == null) throw new ArgumentNullException(nameof(sourceItem));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var destHashSet = new HashSet<T>();

            SelectAncestors(sourceItem, selector, destHashSet);

            return destHashSet;
        }

        /// <inheritdoc cref="_selectancestors" />
        private static void SelectAncestors<T>(T sourceItem, Func<T, T?> selector, HashSet<T> destHashSet)
        {
            T ancestor = sourceItem;
            while (true)
            {
                ancestor = selector(ancestor);

                if (ancestor == null)
                {
                    break;
                }

                if (!destHashSet.Add(ancestor))
                {
                    break;
                }
            }
        }
    }
}