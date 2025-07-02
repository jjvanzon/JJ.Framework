using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.PlatformCompatibility.Legacy
{
    // TODO: Is the original Tuple type faster as a dictionary key?

    /// <summary>
    /// Net4 substitute
    /// </summary>
    /// <inheritdoc cref="_tuple" />
    public struct Tuple_PlatformSupport<T1, T2, T3>
    {
        /// <inheritdoc cref="_item" />
        private T1 _item1;
        /// <inheritdoc cref="_item" />
        private T2 _item2;
        /// <inheritdoc cref="_item" />
        private T3 _item3;

        /// <inheritdoc cref="_item" />
        public T1 Item1 { get { return _item1; } }
        /// <inheritdoc cref="_item" />
        public T2 Item2 { get { return _item2; } }
        /// <inheritdoc cref="_item" />
        public T3 Item3 { get { return _item3; } }

        /// <summary>
        /// Net4 substitute
        /// </summary>
        /// <inheritdoc cref="_tuple" />
        public Tuple_PlatformSupport(T1 item1, T2 item2, T3 item3)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
        }
    }
}

