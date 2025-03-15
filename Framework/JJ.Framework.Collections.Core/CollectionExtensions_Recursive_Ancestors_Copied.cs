using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Collections.Core
{
    public static class CollectionExtensions_Recursive_Ancestors_Copied
    {
        public static IEnumerable<T> SelfAndAncestors<T>(this T sourceItem, Func<T, T> selector)
        {
            if (sourceItem == null) throw new ArgumentNullException(nameof(sourceItem));
            if (selector   == null) throw new ArgumentNullException(nameof(selector));
            
            var destHashSet = new HashSet<T> { sourceItem };
            
            SelectAncestors(sourceItem, selector, destHashSet);
            
            return destHashSet;
        }
        
        private static void SelectAncestors<T>(T sourceItem, Func<T, T> selector, HashSet<T> destHashSet)
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