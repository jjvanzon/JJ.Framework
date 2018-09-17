//using System;
//using System.Collections;

//namespace JJ.Framework.Collections
//{
//    internal class NestedEnumerator
//    {
//        private readonly IEnumerable _enumerable;
//        private readonly NestedEnumerator _deeperEnumerable;

//        private readonly object[] _currentItems;

//        private Action<object[]> Callback { get; set; }

//        /// <param name="deeperEnumerable">nullable</param>
//        public NestedEnumerator(IEnumerable enumerable, NestedEnumerator deeperEnumerable)
//        {
//            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
//            _deeperEnumerable = deeperEnumerable;

//            if (_deeperEnumerable != null)
//            {
//                _deeperEnumerable.Callback = deeperCurrenteItems =>
//                {
//                    deeperCurrenteItems.CopyTo(_currentItems, 1);
//                    Callback(deeperCurrenteItems);
//                };
//            }

//            _currentItems = new object[GetDepth()];
//        }

//        public void Enumerate()
//        {
//            foreach (object item in _enumerable)
//            {
//                _currentItems[0] = item;

//                _deeperEnumerable?.Enumerate();
//            }
//        }

//        private int GetDepth()
//        {
//            var depth = 1;
//            NestedEnumerator tempDeeperEnumerable = _deeperEnumerable;

//            while (tempDeeperEnumerable != null)
//            {
//                tempDeeperEnumerable = tempDeeperEnumerable._deeperEnumerable;
//                depth++;
//            }

//            return depth;
//        }
//    }
//}