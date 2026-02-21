using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
    [Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
    [Suppress("Trimmer", "IL3050", Justification = ArrayInit)]
    [TestClass]
    public class ExpressionHelperGetValuesTests
    {
        [TestMethod]
      //[Suppress("Trimmer", "IL3050", Justification = ArrayInit)]
        public void Test_ExpressionHelpers_GetValues_ComplexExample()
        {
            ComplexItem item = new ComplexItem();
            Expression<Func<string>> expression = () =>
                item
                .Property
                .Method(1)
                .MethodWithParams(1, 2, 3)
                [4]
                .Property
                .Method(1)
                .MethodWithParams(1, 2, 3)
                [4]
                ._field;

            IList<object> values = ExpressionHelper.GetValues(expression);
        }
    }
}
