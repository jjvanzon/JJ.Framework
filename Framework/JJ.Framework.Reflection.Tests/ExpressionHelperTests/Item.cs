using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
    [DebuggerDisplay("Item {Name} [{Index}]")]
    internal class Item : IItem
    {
        public string Name { get; set; }
        public int Index { get; set; }

        public Item Parent { get; set; }

        public int _field;

        public int Property { get; set; }

        [IndexerName("Indexer")]
        public string this[int index]
        {
            get { return "IndexerResult"; }
        }

        public string Method(int parameter)
        {
            return "MethodResult";
        }

        public string MethodWithParams(params int[] array)
        {
            return "MethodWithParamsResult";
        }
    }
}
