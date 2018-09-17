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
//        private readonly IEnumerable<object> _enumerable;
//        private readonly NestedEnumerator _deeperEnumerator;
//        private IEnumerator<object> _enumerator;

//        // Construction, Destruction

//        public NestedEnumerator(IEnumerable<object> enumerable, NestedEnumerator deeperEnumerator = null)
//        {
//            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
//            _deeperEnumerator = deeperEnumerator;

//            Current = new object[GetDepth()];
//            Reset();
//        }

//        private int GetDepth() => this.SelfAndAncestors(x => x._deeperEnumerator).Count();

//        ~NestedEnumerator() => Dispose();

//        public void Dispose()
//        {
//            _deeperEnumerator?.Dispose();
//            _enumerator?.Dispose();
//        }

//        // IEnumerable

//        public object[] Current { get; }

//        public void Reset()
//        {
//            _deeperEnumerator?.Reset();
//            // NOTE: _enumerator.Reset(); gave 'unsupported' exception at one point. Therefor we create a get a new enumerator here.
//            _enumerator = _enumerable.GetEnumerator();
//        }

//        public bool MoveNext()
//        {
//            // Case 1: There is no deeper enumerator.
//            if (_deeperEnumerator == null)
//            {
//                if (_enumerator.MoveNext())
//                {
//                    DeriveCurrent();
//                    return true;
//                }

//                return false;
//            }

//            // Case 2: Deeper enumerator can be advanced.
//            if (_deeperEnumerator.MoveNext())
//            {
//                DeriveCurrent();
//                return true;
//            }

//            // Case 3:
//            // Deeper enumerator is done.
//            // Reset deeper enumerator.
//            // Move next on deeper enumerator to set it to the first item.
//            // Advance this level's enumerator.
//            _deeperEnumerator.Reset();

//            if (_deeperEnumerator.MoveNext())
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
//            _deeperEnumerator?.Current.CopyTo(Current, 1);
//            Current[0] = _enumerator.Current;
//        }

//        // IEnumerator

//        public IEnumerator<object[]> GetEnumerator() => this;
//        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//        object IEnumerator.Current => Current;
//    }
//}