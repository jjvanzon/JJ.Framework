using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.AccessorTestHelpers
{
    public class MyClassWithNamedIndexerAccessor_UsingStrings
    {
        private MyClassWithNamedIndexer Object = new MyClassWithNamedIndexer();
        private Accessor Accessor;

        public MyClassWithNamedIndexerAccessor_UsingStrings()
        {
            Accessor = new Accessor(Object);
        }

        private int this[int index]
        {
            get { return (int)Accessor.GetIndexerValue(index); }
            set { Accessor.SetIndexerValue(index, value); }
        }
    }
}
