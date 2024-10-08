﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
    [TestClass]
    public class ExpressionHelperGetTextSimpleTests
    {
        // There are separate test classes for the simple tests,
        // because in the past these tests were used to test multiple
        // candidate implementations of ExpressionHelper
        // that did not support the full set of features.

        [TestMethod]
        public void Test_ExpressionHelpers_GetText_LocalVariable()
        {
            // ReSharper disable once ConvertToConstant.Local
            var variable = 1;
            Assert.AreEqual("variable", ExpressionHelper.GetText(() => variable));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetText_Field()
        {
            var item = new Item { _field = 1 };
            Assert.AreEqual("item._field", ExpressionHelper.GetText(() => item._field));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetText_Property()
        {
            var item = new Item { Property = 1 };
            Assert.AreEqual("item.Property", ExpressionHelper.GetText(() => item.Property));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetText_ArrayLength()
        {
            Item[] items = { null, null, null };
            Assert.AreEqual("items.Length", ExpressionHelper.GetText(() => items.Length));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetText_WithQualifier()
        {
            var grandParentItem = new Item { Index = 10 };
            var parentItem = new Item { Parent = grandParentItem };
            var item = new Item { Parent = parentItem };

            Assert.AreEqual("item.Parent.Parent.Index", ExpressionHelper.GetText(() => item.Parent.Parent.Index));
        }
    }
}