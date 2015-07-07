using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public static class IListExtensions
    {
        public static void AddRange<T>(this IList<T> collection, IEnumerable<T> items)
        {
            foreach (var x in items)
            {
                collection.Add(x);
            }
        }

        public static void Add<T>(this IList<T> collection, params T[] items)
        {
            foreach (var x in items)
            {
                collection.Add(x);
            }
        }

        /*public static void Add(this IList collection, params object[] items)
        {
            foreach (var x in items)
            {
                collection.Add(x);
            }
        }*/

        public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            where TResult : new()
        {
            if (!source.Any())
            {
                return new TResult();
            }

            return source.Max(selector);
        }
    }
}
