using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedVariable
// ReSharper disable ConvertToConstant.Local
// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Replace_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_Replace_IgnoreCase_True_WithMatch()
        {
            var input = "<a><b><b>";
            string actual = input.Replace("<B>", "<c>", ignoreCase: true);
            string expected = "<a><c><c>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_IgnoreCase_True_NoMatch()
        {
            var input = "<a><b><b>";
            string actual = input.Replace("<d>", "<c>", ignoreCase: true);
            string expected = "<a><b><b>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_IgnoreCase_False_WithMatch()
        {
            var input = "<a><b><b>";
            string actual = input.Replace("<b>", "<c>", ignoreCase: false);
            string expected = "<a><c><c>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_WithMatch()
        {
            var input = "<a><b><b>";
            string actual = input.Replace("<b>", "<c>");
            string expected = "<a><c><c>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_IgnoreCase_False_NoMatch()
        {
            var input = "<a><b><b>";
            string actual = input.Replace("<B>", "<c>", ignoreCase: false);
            string expected = "<a><b><b>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_NoMatch()
        {
            var input = "<a><b><b>";
            string actual = input.Replace("<B>", "<c>");
            string expected = "<a><b><b>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_WithIgnoreCase_InputNull_ThrowsException()
        {
            string input = null;
            AssertHelper.ThrowsException<ArgumentNullException>(
                () => input.Replace("<b>", "<c>", default),
                $"Value cannot be null.{Environment.NewLine}Parameter name: input");
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_InputNull_ThrowsException()
        {
            string input = null;
            AssertHelper.ThrowsException<NullReferenceException>(
                () => input.Replace("<b>", "<c>"),
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_WithIgnoreCase_OldValueNull_ThrowsException()
        {
            var input = "<a><b><b>";
            AssertHelper.ThrowsException<ArgumentNullException>(
                () => input.Replace(null, "<c>", default),
                $"Value cannot be null.{Environment.NewLine}Parameter name: oldValue");
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_OldValueNull_ThrowsException()
        {
            var input = "<a><b><b>";
            AssertHelper.ThrowsException<ArgumentNullException>(
                () => input.Replace(null, "<c>"),
                $"Value cannot be null.{Environment.NewLine}Parameter name: oldValue");
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_WithIgnoreCase_NewValueNull_Succeeds()
        {
            var input = "<a><b><b>";
            string actual = input.Replace("<b>", null, default);
            string expected = "<a>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_NewValueNull_Succeeds()
        {
            var input = "<a><b><b>";
            string actual = input.Replace("<b>", null);
            string expected = "<a>";
            Assert.AreEqual(expected, actual);
        }
    }
}

