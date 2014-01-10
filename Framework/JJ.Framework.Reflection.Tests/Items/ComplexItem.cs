using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.Items
{
    [DebuggerDisplay("Item {Name} [{Index}] = {Value}")]
    public class ComplexItem
    {
        public string Name;
        public int Index;

        public string Field = "FieldResult";

        public ComplexItem Property
        {
            get { return new ComplexItem { Name = "PropertyResult" }; }
        }

        public ComplexItem Method(int parameter)
        {
            return new ComplexItem { Name = "MethodResult" };
        }

        public ComplexItem MethodWithParams(params int[] array)
        {
            return new ComplexItem { Name = "MethodWithParamsResult" };
        }

        [IndexerName("Indexer")]
        public ComplexItem this[int index]
        {
            get { return new ComplexItem { Name = "IndexerResult" }; }
        }
    }
}
