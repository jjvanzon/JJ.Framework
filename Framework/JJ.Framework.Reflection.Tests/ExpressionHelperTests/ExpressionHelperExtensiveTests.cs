﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
    [Suppress("Trimmer", "IL2026", Justification = ExpressionsWithArrays)]
    [Suppress("Trimmer", "IL3050", Justification = ExpressionsWithArrays)]
    [TestClass]
    public class ExpressionHelperExtensiveTests
    {
        [TestMethod]
        public void Test_ExpressionHelpers_Field_Static()
        {
            Assert.AreEqual("StaticClass._field", ExpressionHelper.GetText(() => StaticClass._field));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(() => StaticClass._field));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Field_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1._field", ExpressionHelper.GetText(() => StaticClass<Item>._field));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(() => StaticClass<Item>._field));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Property_Static()
        {
            Assert.AreEqual("StaticClass.Property", ExpressionHelper.GetText(() => StaticClass.Property));
            Assert.AreEqual("PropertyResult", ExpressionHelper.GetValue(() => StaticClass.Property));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Property_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Property", ExpressionHelper.GetText(() => StaticClass<Item>.Property));
            Assert.AreEqual("PropertyResult", ExpressionHelper.GetValue(() => StaticClass<Item>.Property));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayLength_Static()
        {
            Assert.AreEqual("StaticClass.Array.Length", ExpressionHelper.GetText(() => StaticClass.Array.Length));
            Assert.AreEqual(3, ExpressionHelper.GetValue(() => StaticClass.Array.Length));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayLength_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Array.Length", ExpressionHelper.GetText(() => StaticClass<Item>.Array.Length));
            Assert.AreEqual(3, ExpressionHelper.GetValue(() => StaticClass<Item>.Array.Length));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Constant()
        {
            Item item = new Item();

            Assert.AreEqual("1", ExpressionHelper.GetText(() => 1));
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => 1));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_StringConstant()
        {
            Assert.AreEqual(@"""Blah""", ExpressionHelper.GetText(() => "Blah"));
            Assert.AreEqual("Blah", ExpressionHelper.GetValue(() => "Blah"));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Conversion_Numeric()
        {
            int value = 1;
            Assert.AreEqual("value", ExpressionHelper.GetText(() => (long)value));
            Assert.AreEqual(1, ExpressionHelper.GetValue(() => (long)value));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Conversion_DirectCast()
        {
            Item item = new Item();

            Assert.AreEqual("item", ExpressionHelper.GetText(() => (IItem)item));
            Assert.AreSame(item, ExpressionHelper.GetValue(() => (IItem)item));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_MethodCall()
        {
            Item item = new Item();

            Assert.AreEqual("item.Method(1)", ExpressionHelper.GetText(() => item.Method(1)));
            Assert.AreEqual("MethodResult", ExpressionHelper.GetValue(() => item.Method(1)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_MethodCall_Static()
        {
            Assert.AreEqual("StaticClass.Method(1)", ExpressionHelper.GetText(() => StaticClass.Method(1)));
            Assert.AreEqual("MethodResult", ExpressionHelper.GetValue(() => StaticClass.Method(1)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_MethodCall_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Method(1)", ExpressionHelper.GetText(() => StaticClass<Item>.Method(1)));
            Assert.AreEqual("MethodResult", ExpressionHelper.GetValue(() => StaticClass<Item>.Method(1)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Indexer()
        {
            Item item = new Item();

            Assert.AreEqual("item[1]", ExpressionHelper.GetText(() => item[1]));
            Assert.AreEqual("IndexerResult", ExpressionHelper.GetValue(() => item[1]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex()
        {
            int[] array = { 10, 11, 12, 13 };

            Assert.AreEqual("array[2]", ExpressionHelper.GetText(() => array[2]));
            Assert.AreEqual(12, ExpressionHelper.GetValue(() => array[2]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Static()
        {
            Assert.AreEqual("StaticClass.Array[1]", ExpressionHelper.GetText(() => StaticClass.Array[1]));
            Assert.AreEqual(11, ExpressionHelper.GetValue(() => StaticClass.Array[1]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.Array[1]", ExpressionHelper.GetText(() => StaticClass<Item>.Array[1]));
            Assert.AreEqual(11, ExpressionHelper.GetValue(() => StaticClass<Item>.Array[1]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Variable()
        {
            int[] array = { 10, 11, 12 };
            int i = 2;
            Assert.AreEqual("array[i]", ExpressionHelper.GetText(() => array[i]));
            Assert.AreEqual(12, ExpressionHelper.GetValue(() => array[i]));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Variable_ShowIndexerValues()
        {
            int[] array = { 10, 11, 12 };
            int i = 2;
            Assert.AreEqual("array[2]", ExpressionHelper.GetText(() => array[i], true));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_Indexer_ShowIndexerValues()
        {
            var list = new List<int> { 10, 11, 12 };
            int i = 2;
            Assert.AreEqual("list[2]", ExpressionHelper.GetText(() => list[i], true));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayInit()
        {
            Item item = new Item();

            Assert.AreEqual("item.MethodWithParams(1, 2, 3)", ExpressionHelper.GetText(() => item.MethodWithParams(1, 2, 3)));
            Assert.AreEqual("MethodWithParamsResult", ExpressionHelper.GetValue(() => item.MethodWithParams(1, 2, 3)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayInit_Static()
        {
            Assert.AreEqual("StaticClass.MethodWithParams(1, 2, 3)", ExpressionHelper.GetText(() => StaticClass.MethodWithParams(1, 2, 3)));
            Assert.AreEqual("MethodWithParamsResult", ExpressionHelper.GetValue(() => StaticClass.MethodWithParams(1, 2, 3)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayInit_Static_Generic()
        {
            Assert.AreEqual("StaticClass`1.MethodWithParams(1, 2, 3)", ExpressionHelper.GetText(() => StaticClass<Item>.MethodWithParams(1, 2, 3)));
            Assert.AreEqual("MethodWithParamsResult", ExpressionHelper.GetValue(() => StaticClass<Item>.MethodWithParams(1, 2, 3)));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ComplexExample()
        {
            ComplexItem item = new ComplexItem();
            Expression<Func<string>> expression = () =>
                item.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4]._field;

            Assert.AreEqual("item.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4]._field", ExpressionHelper.GetText(expression));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(expression));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ComplexExample_Static()
        {
            Expression<Func<string>> expression = () =>
                StaticClass.ComplexItem.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4]._field;

            Assert.AreEqual("StaticClass.ComplexItem.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4]._field", ExpressionHelper.GetText(expression));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(expression));
        }

        [TestMethod]
        public void Test_ExpressionHelpers_ComplexExample_Static_Generic()
        {
            Expression<Func<string>> expression = () =>
                StaticClass<Item>.ComplexItem.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4]._field;

            Assert.AreEqual("StaticClass`1.ComplexItem.Property.Method(1).MethodWithParams(1, 2, 3)[4].Property.Method(1).MethodWithParams(1, 2, 3)[4]._field", ExpressionHelper.GetText(expression));
            Assert.AreEqual("FieldResult", ExpressionHelper.GetValue(expression));
        }

        // Newer (2015-03-05)

        public int ArrayIndex { get; set; }

        [TestMethod]
        public void Test_ExpressionHelpers_ArrayIndex_Property()
        {
            int[] array = { 0, 1, 2 };
            ArrayIndex = 2;
            Assert.AreEqual("array[ArrayIndex]", ExpressionHelper.GetText(() => array[ArrayIndex]));
            Assert.AreEqual(2, ExpressionHelper.GetValue(() => array[ArrayIndex]));
        }

        [TestMethod]
        public void Bug_ExpressionHelpers_GetValue_Crash_Property_AfterArrayIndex()
        {
            Item[] items = 
            { 
                new Item { Name = "Item1" }, 
                new Item { Name = "Item2" }, 
                new Item { Name = "Item3" }, 
            };

            int i = 1;
            Assert.AreEqual("Item2", ExpressionHelper.GetValue(() => items[i].Name));
        }

        [TestMethod]
        public void Bug_ExpressionHelpers_GetValue_Crash_Property_AfterIndexerCall()
        {
            var complexItem = new ComplexItem();
            int i = 0;
            ExpressionHelper.GetValue(() => complexItem[i].Name);
        }
    }
}