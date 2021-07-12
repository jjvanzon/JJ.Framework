using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local
// ReSharper disable StringLiteralTypo

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimLast_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimLast()
            => AssertHelper.AreEqual("[a][b][b][a]", () => "[a][b][b][a][a]".TrimLast("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimLast_NoOccurrences()
            => AssertHelper.AreEqual("[a][b][b]", () => "[a][b][b]".TrimLast("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimLast_EndStringWhiteSpace()
            => AssertHelper.AreEqual(" [a][a] ", () => " [a][a]  ".TrimLast(" "));

        [TestMethod]
        public void Test_StringExtensions_TrimLast_InputEmpty_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".TrimLast("[a]"));
        
        [TestMethod]
        public void Test_StringExtensions_TrimLast_ClearingEntireString()
           => AssertHelper.AreEqual("", () => "[a]".TrimLast("[a]"));
        
        [TestMethod]
        public void Test_StringExtensions_TrimLast_InputNull_ThrowsException()
          => AssertHelper.ThrowsException<NullReferenceException>(
              () => StringExtensions.TrimLast(null, "[a]"),
              "Object reference not set to an instance of an object.");
        
        [TestMethod]
        public void Test_StringExtensions_TrimLast_EndStringEmpty_ThrowsException()
          => AssertHelper.ThrowsException(
              () => "[a]".TrimLast(""),
              "end is null or empty.");
    }
}
