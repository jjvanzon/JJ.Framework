//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace JJ.Framework.Collections
//{
//    internal class ArrayEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
//    {
//        public static ArrayEqualityComparer<T> Instance = new ArrayEqualityComparer<T>();

//        private ArrayEqualityComparer() { }

//        private static readonly EqualityComparer<T> _itemEqualityComparer = EqualityComparer<T>.Default;

//        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
//        {
//            if (x == null) throw new ArgumentNullException(nameof(x));
//            if (y == null) throw new ArgumentNullException(nameof(y));

//            bool result = x.Zip(y).All(z => _itemEqualityComparer.Equals(z.Item1, z.Item2));

//            return result;
//        }

//        public int GetHashCode(IEnumerable<T> obj) => obj.GetHashCode();
//    }
//}