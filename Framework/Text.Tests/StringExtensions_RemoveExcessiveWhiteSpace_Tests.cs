using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_RemoveExcessiveWhiteSpace_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_ComplexExample()
            => AssertHelper.AreEqual("Test 123", () => $"\u2007 \r Test \u2008 \t\t{NewLine}\t  123 \n\n ".RemoveExcessiveWhiteSpace());

        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_Trims_WhiteSpace() 
            => AssertHelper.AreEqual("Test", () => $" {NewLine}Test\t".RemoveExcessiveWhiteSpace());

        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_ReplacesIntermediateWhiteSpace_BySingleSpace()
            => AssertHelper.AreEqual("Test 123", () => $"Test {NewLine}\t  123".RemoveExcessiveWhiteSpace());

        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_EmptyString_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".RemoveExcessiveWhiteSpace());

        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_Null_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => StringExtensions.RemoveExcessiveWhiteSpace(null), 
                $"Value cannot be null.{NewLine}Parameter name: text");
    }
}
