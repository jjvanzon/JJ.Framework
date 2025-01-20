using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Wishes.Text;

namespace JJ.Framework.Wishes.Collections
{
    public static class CollectionExtensionWishes
    {
        public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
        {
            if (timeSpans == null) throw new ArgumentNullException(nameof(timeSpans));
            return timeSpans.Aggregate((x, y) => x + y);
        }
        
        public static TimeSpan Sum<T>(this IEnumerable<T> source, Func<T, TimeSpan> selector)
        {
            return source.Select(selector).Sum();
        }
        
        public static bool Contains(this IList<string> source, string match, bool ignoreCase = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            StringComparison stringComparison = ignoreCase.ToStringComparison();
            
            return source.Any(x => (x ?? "").Equals(match, stringComparison));
        }
        
        /// <inheritdoc cref="docs._onebecomestwo" />
        public static IList<T> OneBecomesTwo<T>(this IList<T> list)
        {
            if (list       == null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 1) list = new List<T> { list[0], list[0] };
            return list;
        }
        
        /// <inheritdoc cref="docs._onebecomestwo" />
        public static T[] OneBecomesTwo<T>(this T[] list) => OneBecomesTwo((IList<T>)list).ToArray();
        
        /// <inheritdoc cref="docs._frameworkwishproduct" />
        public static double Product(this IEnumerable<double> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            
            var array = collection as double[] ?? collection.ToArray();
            
            if (!array.Any()) return 1;
            
            double product = array.FirstOrDefault();
            
            foreach (double value in array.Skip(1))
            {
                product *= value;
            }
            
            return product;
        }
        
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            int i = 0;
            foreach (var x in enumerable)
            {
                action(x, i++);
            }
        }
    }
}