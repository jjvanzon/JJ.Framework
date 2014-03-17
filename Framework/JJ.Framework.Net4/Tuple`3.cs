using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Net4
{
    public struct Tuple<T1, T2, T3>
    {
        private T1 _item1;
        private T2 _item2;
        private T3 _item3;

        public T1 Item1 { get { return _item1; } }
        public T2 Item2 { get { return _item2; } }
        public T3 Item3 { get { return _item3; } }

        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
        }
    }
}

