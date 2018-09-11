//using System;
//using System.Collections;

//namespace JJ.Framework.Collections
//{
//    internal class NestedEnumerator
//    {
//        private readonly IEnumerable _enumerable;
//        private readonly NestedEnumerator _deeperNestedEnumerator;

//        private readonly object[] _currentItems;

//        public Action<object[]> Callback { get; set; }

//        /// <param name="deeperNestedEnumerator">nullable</param>
//        public NestedEnumerator(IEnumerable enumerable, NestedEnumerator deeperNestedEnumerator)
//        {
//            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
//            _deeperNestedEnumerator = deeperNestedEnumerator;

//            if (_deeperNestedEnumerator != null)
//            {
//                _deeperNestedEnumerator.Callback = DeeperCallback;
//            }

//            _currentItems = new object[GetDepth()];
//        }

//        public void Enumerate()
//        {
//            foreach (object item in _enumerable)
//            {
//                _currentItems[0] = item;

//                _deeperNestedEnumerator?.Enumerate();
//            }
//        }

//        private void DeeperCallback(object[] currentItems)
//        {
//            currentItems.CopyTo(_currentItems, 1);
//            Callback(currentItems);
//        }

//        private int GetDepth()
//        {
//            var depth = 1;
//            NestedEnumerator tempDeeperEnumerable = _deeperNestedEnumerator;

//            while (tempDeeperEnumerable != null)
//            {
//                tempDeeperEnumerable = tempDeeperEnumerable._deeperNestedEnumerator;
//                depth++;
//            }

//            return depth;
//        }
//    }
//}