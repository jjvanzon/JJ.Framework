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
    internal class ComplexItem
    {
        public string Name;
        public int Index;

        public string _field = "FieldResult";

        public ComplexItem Property
        {
            get { return new ComplexItem { Name = "PropertyResult" }; }
        }

        public ComplexItem MethodWithParameter(int parameter)
        {
            return new ComplexItem { Name = "MethodWithParameterResult" };
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
