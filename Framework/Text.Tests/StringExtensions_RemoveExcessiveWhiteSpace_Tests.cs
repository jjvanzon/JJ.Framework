using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_RemoveExcessiveWhiteSpace_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_ComplexExample()
            => AssertHelper.AreEqual("Test 123", () => $"\u2007 \r Test \u2008 \t\t{Environment.NewLine}\t  123 \n\n ".RemoveExcessiveWhiteSpace());

        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_Trims_WhiteSpace() 
            => AssertHelper.AreEqual("Test", () => $" {Environment.NewLine}Test\t".RemoveExcessiveWhiteSpace());

        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_ReplacesIntermediateWhiteSpace_BySingleSpace()
            => AssertHelper.AreEqual("Test 123", () => $"Test {Environment.NewLine}\t  123".RemoveExcessiveWhiteSpace());

        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_EmptyString_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".RemoveExcessiveWhiteSpace());

        [TestMethod]
        public void Test_StringExtensions_RemoveExcessiveWhiteSpace_Null_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => StringExtensions.RemoveExcessiveWhiteSpace(null), 
                $"Value cannot be null.{Environment.NewLine}Parameter name: text");
    }
}
