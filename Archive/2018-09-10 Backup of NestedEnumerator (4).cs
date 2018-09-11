//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//// ReSharper disable PossibleNullReferenceException
//// ReSharper disable InvertIf

//namespace JJ.Framework.Collections
//{
//    internal class NestedEnumerator : IEnumerable<object[]>, IEnumerator<object[]>
//    {
//        private readonly NestedEnumerator _deeperNestedEnumerator;
//        private readonly IEnumerator<object> _enumerator;

//        // Construction, Destruction

//        /// <param name="deeperNestedEnumerator">nullable</param>
//        public NestedEnumerator(IEnumerable<object> enumerable, NestedEnumerator deeperNestedEnumerator)
//        {
//            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
//            _deeperNestedEnumerator = deeperNestedEnumerator;
//            _enumerator = enumerable.GetEnumerator();
//            Current = new object[GetDepth()];
//            Reset();
//        }

//        private int GetDepth() => _deeperNestedEnumerator.SelfAndAncestors(x => x._deeperNestedEnumerator).Count();

//        ~NestedEnumerator() => Dispose();

//        public void Dispose()
//        {
//            _deeperNestedEnumerator?.Dispose();
//            _enumerator?.Dispose();
//        }

//        // IEnumerable

//        public object[] Current { get; }

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
//                if (_enumerator.MoveNext())
//                {
//                    DeriveCurrent();
//                    return true;
//                }

//                return false;
//            }

//            // Case 2: Deeper enumerator can be advanced.
//            if (_deeperNestedEnumerator.MoveNext())
//            {
//                DeriveCurrent();
//                return true;
//            }

//            // Case 3:
//            // Deeper enumerator is done.
//            // Reset deeper enumerator.
//            // Move next on deeper enumerator to set it to the first item.
//            // Advance this level's enumerator.
//            _deeperNestedEnumerator.Reset();

//            if (_deeperNestedEnumerator.MoveNext())
//            {
//                if (_enumerator.MoveNext())
//                {
//                    DeriveCurrent();
//                    return true;
//                }
//            }

//            // Case 4: This level's enumerator is done.
//            return false;
//        }

//        private void DeriveCurrent()
//        {
//            _deeperNestedEnumerator.Current.CopyTo(Current, 1);
//            Current[0] = _enumerator.Current;
//        }

//        // IEnumerator

//        public IEnumerator<object[]> GetEnumerator() => this;
//        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//        object IEnumerator.Current => Current;
//    }
//}