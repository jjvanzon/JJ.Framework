using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Common
{
    public static class IEnumerableOfTExtensions
    {
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> collection, Func<T, IEnumerable<T>> selector)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

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
    }
}
