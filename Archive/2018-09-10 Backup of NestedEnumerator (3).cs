//using System;
//using System.Collections;
//using System.Collections.Generic;

//namespace JJ.Framework.Collections
//{
//    internal class NestedEnumerator : IEnumerable<object>, IEnumerator<object>
//    {
//        private readonly NestedEnumerator _deeperNestedEnumerator;
//        private readonly object[] _currentItems;
//        private readonly IEnumerator<object> _enumerator;

//        // Construtor

//        /// <param name="deeperNestedEnumerator">nullable</param>
//        public NestedEnumerator(IEnumerable<object> enumerable, NestedEnumerator deeperNestedEnumerator)
//        {
//            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
//            _deeperNestedEnumerator = deeperNestedEnumerator;
//            _enumerator = enumerable.GetEnumerator();
//            _currentItems = new object[GetDepth()];
//            Reset();
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

//        // IDispose

//        public void Dispose()
//        {
//            _deeperNestedEnumerator?.Dispose();
//            _enumerator?.Dispose();
//        }

//        // IEnumerable

//        public object Current => _currentItems;

//        public void Reset()
//        {
//            _deeperNestedEnumerator.Reset();
//            _enumerator.Reset();
//        }

//        public bool MoveNext()
//        {
//            // Case 1: There is no deeper enumerator.
//            if (_deeperNestedEnumerator == null)
//            {
//                return _enumerator.MoveNext();
//            }

//            // Case 2: Deeper enumerator can be advanced.
//            if (_deeperNestedEnumerator.MoveNext())
//            {
//                _deeperNestedEnumerator._currentItems.CopyTo(_currentItems, 1);
//                return true;
//            }

//            // Case 3:
//            // Deeper enumerator is done.
//            // Reset deeper enumerator.
//            // Move next on deeper enumerator to set it to the first item.
//            // Advance this level's enumerator.
//            _deeperNestedEnumerator.Reset();

//            if (_deeperNestedEnumerator.MoveNext() && _enumerator.MoveNext())
//            {
//                _deeperNestedEnumerator._currentItems.CopyTo(_currentItems, 1);
//                _currentItems[0] = _enumerator.Current;
//                return true;
//            }

//            // Case 4: This level's enumerator is done.
//            return false;
//        }

//        // IEnumerator

//        public IEnumerator<object> GetEnumerator() => this;
//        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//    }
//}