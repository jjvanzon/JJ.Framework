using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Reflection.Tests.ExpressionHelperTestHelpers;

namespace JJ.Framework.Reflection.Tests
{
    [TestClass]
    public class ExpressionHelperGetValueSimpleTests
    {
        // There are separate test classes for the simple tests,
        // because in the past these tests were used to test multiple
        // candidate implementations of ExpressionHelper
        // that did not support the full set of features.

        [TestMethod]
        public void Test_ExpressionHelpers_GetValue_LocalVariable()
        {
            int variable = 1;
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => variable));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetValue_Field()
        {
            Item item = new Item { Field = 1 };
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => item.Field));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetValue_Property()
        {
            Item item = new Item { Property = 1 };
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => item.Property));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetValue_ArrayLength()
        {
            Item[] items = { null, null, null };
            Assert.AreEqual(3, ExpressionHelper.GetValue(() => items.Length));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetValue_WithQualifier()
        {
            Item grandParentItem = new Item { Index = 10 };
            Item parentItem = new Item { Parent = grandParentItem };
            Item item = new Item { Parent = parentItem };

            Assert.AreEqual(10, ExpressionHelper.GetValue(() => item.Parent.Parent.Index));
        }
    }
}