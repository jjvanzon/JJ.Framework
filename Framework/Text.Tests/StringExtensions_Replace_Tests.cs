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
            var input = "<d><e><e>";
            string actual = input.Replace("<_>", "<f>", ignoreCase: true);
            string expected = "<d><e><e>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_IgnoreCase_False_WithMatch()
        {
            var input = "<g><h><h>";
            string actual = input.Replace("<h>", "<i>", ignoreCase: false);
            string expected = "<g><i><i>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_WithMatch()
        {
            var input = "<j><k><k>";
            string actual = input.Replace("<k>", "<l>");
            string expected = "<j><l><l>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_IgnoreCase_False_NoMatch()
        {
            var input = "<m><n><n>";
            string actual = input.Replace("<N>", "<o>", ignoreCase: false);
            string expected = "<m><n><n>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_NoMatch()
        {
            var input = "<p><q><q>";
            string actual = input.Replace("<Q>", "<r>");
            string expected = "<p><q><q>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_WithIgnoreCase_InputNull_ThrowsException()
        {
            string input = null;
            AssertHelper.ThrowsException<ArgumentNullException>(
                () => input.Replace("<s>", "<t>", default),
                $"Value cannot be null.{Environment.NewLine}Parameter name: input");
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_InputNull_ThrowsException()
        {
            string input = null;
            AssertHelper.ThrowsException<NullReferenceException>(
                () => input.Replace("<u>", "<v>"),
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_WithIgnoreCase_OldValueNull_ThrowsException()
        {
            var input = "<w><x><x>";
            AssertHelper.ThrowsException<ArgumentNullException>(
                () => input.Replace(null, "<y>", default),
                $"Value cannot be null.{Environment.NewLine}Parameter name: oldValue");
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_OldValueNull_ThrowsException()
        {
            var input = "<z><aa><aa>";
            AssertHelper.ThrowsException<ArgumentNullException>(
                () => input.Replace(null, "<ab>"),
                $"Value cannot be null.{Environment.NewLine}Parameter name: oldValue");
        }

        [TestMethod]
        public void Test_StringExtensions_Replace_WithIgnoreCase_NewValueNull_Succeeds()
        {
            var input = "<ac><ad><ad>";
            string actual = input.Replace("<ad>", null, default);
            string expected = "<ac>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_String_Replace_FromDotNet_NewValueNull_Succeeds()
        {
            var input = "<ae><af><af>";
            string actual = input.Replace("<af>", null);
            string expected = "<ae>";
            Assert.AreEqual(expected, actual);
        }
    }
}