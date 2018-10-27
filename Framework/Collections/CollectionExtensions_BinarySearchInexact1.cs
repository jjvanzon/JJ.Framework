

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace JJ.Framework.Collections
{
    [PublicAPI]
    public static class CollectionExtensions_BinarySearchInexact
    {
        /// <summary>
		/// Searches a sorted collection in an efficient way.
        /// Returns the value before and the value after
		/// if a value to search is in between two values in the list.
        /// Will only return a meaningful result if the collection is sorted.
        /// </summary>
        /// <param name="sortedCollection"> Not checked for null, for performance. </param>
        public static (double valueBefore, double valueAfter) BinarySearchInexact(this IEnumerable<double> sortedCollection, double input)
            => CollectionHelper.BinarySearchInexact(sortedCollection.ToArray(), input);

        /// <summary>
		/// Searches a sorted collection in an efficient way.
        /// Returns the value before and the value after
		/// if a value to search is in between two values in the list.
        /// Will only return a meaningful result if the collection is sorted.
        /// </summary>
        /// <param name="sortedCollection"> Not checked for null, for performance. </param>
        public static (double valueBefore, double valueAfter) BinarySearchInexact(this double[] sortedCollection, double input)
            => CollectionHelper.BinarySearchInexact(sortedCollection, input);

        /// <summary>
		/// Searches a sorted collection in an efficient way.
        /// Returns the value before and the value after
		/// if a value to search is in between two values in the list.
        /// Will only return a meaningful result if the collection is sorted.
        /// </summary>
        /// <param name="sortedCollection"> Not checked for null, for performance. </param>
        public static (double valueBefore, double valueAfter) BinarySearchInexact(
            this IEnumerable<double> sortedCollection,
            int halfCount,
            double min,
            double max,
            double input)
            => CollectionHelper.BinarySearchInexact(sortedCollection.ToArray(), halfCount, min, max, input);

        /// <summary>
		/// Searches a sorted collection in an efficient way.
        /// Returns the value before and the value after
		/// if a value to search is in between two values in the list.
        /// Will only return a meaningful result if the collection is sorted.
        /// </summary>
        /// <param name="sortedCollection"> Not checked for null, for performance. </param>
        public static (double valueBefore, double valueAfter) BinarySearchInexact(
            this double[] sortedCollection,
            int halfCount,
            double min,
            double max,
            double input)
            => CollectionHelper.BinarySearchInexact(sortedCollection, halfCount, min, max, input);
    }
}
