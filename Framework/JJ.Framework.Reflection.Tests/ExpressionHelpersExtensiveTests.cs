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
    public class ExpressionHelpersExtensiveTests
    {
        [TestMethod]
        public void Test_ExpressionHelpers_GetName_Field_Static()
        {
            Assert.AreEqual("StaticClass.Field", ExpressionHelper.GetString(() => StaticClass.Field));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(() => StaticClass.Field));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_Field_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Field", ExpressionHelper.GetString(() => StaticClass<Item>.Field));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(() => StaticClass<Item>.Field));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_Property_Static()
        {
            Assert.AreEqual("StaticClass.Property", ExpressionHelper.GetString(() => StaticClass.Property));
            Assert.AreEqual("PropertyResult", ExpressionHelper.GetValue(() => StaticClass.Property));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_Property_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Property", ExpressionHelper.GetString(() => StaticClass<Item>.Property));
            Assert.AreEqual("PropertyResult", ExpressionHelper.GetValue(() => StaticClass<Item>.Property));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_ArrayLength_Static()
        {
            Assert.AreEqual("StaticClass.Array.Length", ExpressionHelper.GetString(() => StaticClass.Array.Length));
            Assert.AreEqual(3, ExpressionHelper.GetValue(() => StaticClass.Array.Length));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_GetName_ArrayLength_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Array.Length", ExpressionHelper.GetString(() => StaticClass<Item>.Array.Length));
            Assert.AreEqual(3, ExpressionHelper.GetValue(() => StaticClass<Item>.Array.Length));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Constant()
        {
            Item item = new Item();

            Assert.AreEqual("1", ExpressionHelper.GetString(() => 1));
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => 1));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_StringConstant()
        {
            Assert.AreEqual(@"""Blah""", ExpressionHelper.GetString(() => "Blah"));
            Assert.AreEqual("Blah", ExpressionHelper.GetValue(() => "Blah"));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Conversion_Numeric()
        {
            int value = 1;
            Assert.AreEqual("value", ExpressionHelper.GetString(() => (long)value));
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => (long)value));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Conversion_DirectCast()
        {
            Item item = new Item();

            Assert.AreEqual("item", ExpressionHelper.GetString(() => (IItem)item));
            Assert.AreSame(item, ExpressionHelper.GetValue(() => (IItem)item));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_MethodCall()
        {
            Item item = new Item();

            Assert.AreEqual("item.Method(1)", ExpressionHelper.GetString(() => item.Method(1)));
            Assert.AreEqual("MethodResult", ExpressionHelper.GetValue(() => item.Method(1)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_MethodCall_Static()
        {
            Assert.AreEqual("StaticClass.Method(1)", ExpressionHelper.GetString(() => StaticClass.Method(1)));
            Assert.AreEqual("MethodResult", ExpressionHelper.GetValue(() => StaticClass.Method(1)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_MethodCall_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Method(1)", ExpressionHelper.GetString(() => StaticClass<Item>.Method(1)));
            Assert.AreEqual("MethodResult", ExpressionHelper.GetValue(() => StaticClass<Item>.Method(1)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Indexer()
        {
            Item item = new Item();

            Assert.AreEqual("item[1]", ExpressionHelper.GetString(() => item[1]));
            Assert.AreEqual("IndexerResult", ExpressionHelper.GetValue(() => item[1]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex()
        {
            int[] array = { 0, 1, 2, 3 };

            Assert.AreEqual("array[2]", ExpressionHelper.GetString(() => array[2]));
            Assert.AreEqual(2, ExpressionHelper.GetValue(() => array[2]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Static()
        {
            Assert.AreEqual("StaticClass.Array[1]", ExpressionHelper.GetString(() => StaticClass.Array[1]));
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => StaticClass.Array[1]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Array[1]", ExpressionHelper.GetString(() => StaticClass<Item>.Array[1]));
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => StaticClass<Item>.Array[1]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Variable()
        {
            int[] array = { 0, 1, 2 };
            int i = 2;
            Assert.AreEqual("array[i]", ExpressionHelper.GetString(() => array[i]));
            Assert.AreEqual(2, ExpressionHelper.GetValue(() => array[i]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Variable_ShowIndexerValues()
        {
            int[] array = { 0, 1, 2 };
            int i = 2;
            Assert.AreEqual("array[2]", ExpressionHelper.GetString(() => array[i], true));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Indexer_ShowIndexerValues()
        {
            var list = new List<int> { 0, 1, 2 };
            int i = 2;
            Assert.AreEqual("list[2]", ExpressionHelper.GetString(() => list[i], true));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayInit()
        {
            Item item = new Item();

            Assert.AreEqual("item.MethodWithParams(1, 2, 3)", ExpressionHelper.GetString(() => item.MethodWithParams(1, 2, 3)));
            Assert.AreEqual("MethodWithParamsResult", ExpressionHelper.GetValue(() => item.MethodWithParams(1, 2, 3)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayInit_Static()
        {
            Assert.AreEqual("StaticClass.MethodWithParams(1, 2, 3)", ExpressionHelper.GetString(() => StaticClass.MethodWithParams(1, 2, 3)));
            Assert.AreEqual("MethodWithParamsResult", ExpressionHelper.GetValue(() => StaticClass.MethodWithParams(1, 2, 3)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayInit_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.MethodWithParams(1, 2, 3)", ExpressionHelper.GetString(() => StaticClass<Item>.MethodWithParams(1, 2, 3)));
            Assert.AreEqual("MethodWithParamsResult", ExpressionHelper.GetValue(() => StaticClass<Item>.MethodWithParams(1, 2, 3)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ComplexExample()
        {
            ComplexItem item = new ComplexItem();
            Expression<Func<string>> expression = () =>
                item.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4].Field;

            Assert.AreEqual("item.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4].Field", ExpressionHelper.GetString(expression));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(expression));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ComplexExample_Static()
        {
            Expression<Func<string>> expression = () =>
                StaticClass.ComplexItem.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4].Field;

            Assert.AreEqual("StaticClass.ComplexItem.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4].Field", ExpressionHelper.GetString(expression));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(expression));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ComplexExample_Static_Generic()
        {
            Expression<Func<string>> expression = () =>
                StaticClass<Item>.ComplexItem.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4].Field;

            Assert.AreEqual("StaticClass`1.ComplexItem.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4].Field", ExpressionHelper.GetString(expression));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(expression));
        }
    }
}