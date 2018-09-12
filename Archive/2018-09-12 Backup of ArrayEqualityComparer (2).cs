//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace JJ.Framework.Collections
//{
//    internal class ArrayEqualityComparer<TEnumerable, TItem> : IEqualityComparer<TEnumerable>
//            where TEnumerable : IEnumerable<TItem>
//    {
//        public static ArrayEqualityComparer<TEnumerable, TItem> Instance = new ArrayEqualityComparer<TEnumerable, TItem>();

//        private ArrayEqualityComparer() { }

//        private static readonly EqualityComparer<TItem> _itemEqualityComparer = EqualityComparer<TItem>.Default;

//        public bool Equals(TEnumerable collection1, TEnumerable collection2)
//        {
//            if (collection1 == null) throw new ArgumentNullException(nameof(collection1));
//            if (collection2 == null) throw new ArgumentNullException(nameof(collection2));

//            //bool result = collection1.Zip(collection2).All(z => _itemEqualityComparer.Equals(z.Item1, z.Item2));
//            bool result = collection1.Zip(collection2).All(z => Equals(z.Item1, z.Item2));

//            return result;
//        }

//        public int GetHashCode(TEnumerable obj) => obj.GetHashCode();
//    }
//}