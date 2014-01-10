using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Common
{
    public static class ICollectionExtensions
    {
        public static void Add<T>(this ICollection<T> collection, params T[] items)
        {
            foreach (var x in items)
            {
                collection.Add(x);
            }
        }

        public static void Add(this ICollection collection, params object[] items)
        {
            if (items.Length <= 1)
            {
                throw new Exception("This overload of Add can only be called with two or more items.");
            }

            foreach (var x in items)
            {
                collection.Add(x);
            }
        }
    }
}
