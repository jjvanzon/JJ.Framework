using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Reflection.Tests.Items;

namespace JJ.Framework.Reflection.Tests
{
    [TestClass]
    public class ExpressionHelpersGetStringSimpleTests
    {
        // There are separate test classes for the simple tests,
        // because in the past these tests were used to test multiple
        // candidate implementations of ExpressionHelper
        // that did not support the full set of features.

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_LocalVariable()
        {
            int variable = 1;
            Assert.AreEqual("variable", ExpressionHelper.GetString(() => variable));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_Field()
        {
            Item item = new Item { Field = 1 };
            Assert.AreEqual("item.Field", ExpressionHelper.GetString(() => item.Field));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_Property()
        {
            Item item = new Item { Property = 1 };
            Assert.AreEqual("item.Property", ExpressionHelper.GetString(() => item.Property));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_ArrayLength()
        {
            Item[] items = { null, null, null };
            Assert.AreEqual("items.Length", ExpressionHelper.GetString(() => items.Length));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_WithQualifier()
        {
            Item grandParentItem = new Item { Index = 10 };
            Item parentItem = new Item { Parent = grandParentItem };
            Item item = new Item { Parent = parentItem };

            Assert.AreEqual("item.Parent.Parent.Index", ExpressionHelper.GetString(() => item.Parent.Parent.Index));
        }
    }
}