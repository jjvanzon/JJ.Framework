using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class MyClassWithNamedIndexerAccessor
    {
        private Accessor _accessor;

        public MyClassWithNamedIndexerAccessor(MyClassWithNamedIndexer obj)
        {
            _accessor = new Accessor(obj);
        }

        public int this[int index]
        {
            get { return (int)_accessor.GetIndexerValue(index); }
            set { _accessor.SetIndexerValue(index, value); }
        }
    }
}
