using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Business
{
    public static class EntityStatusHelper
    {
        /// <summary>
        /// Determines whether a list is dirty.
        /// This means that it checks whether items were removed,
        /// added or changed.
        /// 
        /// The changing of items does not mean that the entities themselves
        /// are dirty, it means that a list position now points to another object.
        /// </summary>
        public static bool GetListIsDirty<TViewModel, TEntity>(
            IList<TViewModel> list1, Func<TViewModel, object> getKey1,
            IList<TEntity> list2, Func<TEntity, object> getKey2,
            bool ignoreOrder = false)
        {
            if (list1 == null) throw new NullException(() => list1);
            if (getKey1 == null) throw new NullException(() => getKey1);
            if (list2 == null) throw new NullException(() => list2);
            if (getKey2 == null) throw new NullException(() => getKey2);

            if (list1.Count != list2.Count)
            {
                return true;
            }

            // If the order does not matter you have to sort the list and compare the sorted lists.
            if (ignoreOrder)
            {
                list1 = list1.OrderBy(getKey1).ToArray();
                list2 = list2.OrderBy(getKey2).ToArray();
            }

            for (int i = 0; i < list1.Count; i++)
            {
                object key1 = getKey1(list1[i]);
                object key2 = getKey2(list2[i]);

                if (!key1.Equals(key2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
