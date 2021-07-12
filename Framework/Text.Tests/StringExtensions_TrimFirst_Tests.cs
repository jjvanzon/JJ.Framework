using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable StringLiteralTypo
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimFirst_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimFirst()
            => AssertHelper.AreEqual("[a][b][b][a]", () => "[a][a][b][b][a]".TrimFirst("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimFirst_NoOccurrences()
            => AssertHelper.AreEqual("[b][b][a]", () => "[b][b][a]".TrimFirst("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimFirst_StartStringWhiteSpace()
            => AssertHelper.AreEqual(" [a][a] ", () => "  [a][a] ".TrimFirst(" "));

        [TestMethod]
        public void Test_StringExtensions_TrimFirst_InputEmpty_ReturnsEmptyString() 
            => AssertHelper.AreEqual("", () => "".TrimFirst("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimFirst_ClearingEntireString()
            => AssertHelper.AreEqual("", () => "[a]".TrimFirst("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimFirst_InputNull_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TrimFirst(null, "[a]"),
                "Object reference not set to an instance of an object.");

        [TestMethod]
        public void Test_StringExtensions_TrimFirst_StartStringEmpty_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "[a]".TrimFirst(""),
                "start is null or empty.");
    }
}
