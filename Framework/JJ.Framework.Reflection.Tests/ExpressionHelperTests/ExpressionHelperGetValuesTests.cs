﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
    [TestClass]
    public class ExpressionHelperGetValuesTests
    {
        [TestMethod]
        public void Test_ExpressionHelpers_GetValues_ComplexExample()
        {
            ComplexItem item = new ComplexItem();
            Expression<Func<string>> expression = () =>
                item
                .Property
                .MethodWithParameter(1)
                .MethodWithParams(1, 2, 3)
                [4]
                .Property
                .MethodWithParameter(1)
                .MethodWithParams(1, 2, 3)
                [4]
                ._field;

            IList<object> values = ExpressionHelper.GetValues(expression);
        }
    }
}
