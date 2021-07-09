using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimStart_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimStart_MultipleOccurrences()
            => AssertHelper.AreEqual("[b][a]", () => "[a][a][a][b][a]".TrimStart("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_OneOccurrence()
            => AssertHelper.AreEqual("[b][b][a]", () => "[a][b][b][a]".TrimStart("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_NoOccurrences()
            => AssertHelper.AreEqual("[b][b][b][a]", () => "[b][b][b][a]".TrimStart("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_StartStringWhiteSpace()
            => AssertHelper.AreEqual("[a][a] ", () => " [a][a] ".TrimStart(" "));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_InputEmpty_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".TrimStart("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_ClearingEntireString()
            => AssertHelper.AreEqual("", () => "[a][a][a]".TrimStart("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_InputNull_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TrimStart(null, "[a]"),
                "Object reference not set to an instance of an object.");

        [TestMethod]
        public void Test_StringExtensions_TrimStart_StartStringNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => StringExtensions.TrimStart("[a]", null),
                "start is null or empty.");

        [TestMethod]
        public void Test_StringExtensions_TrimStart_StartStringEmpty_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "[a]".TrimStart(""),
                "start is null or empty.");

        // With Length Parameter

        [TestMethod]
        public void Test_StringExtensions_TrimStart_WithLength()
            => AssertHelper.AreEqual("][b][c]", () => "[a][b][c]".TrimStart(2));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_WithLength_EmptyInput_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".TrimStart(default));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_WithLength_ClearingEntireString()
        {
            string input = "[a][b][c]";
            AssertHelper.AreEqual("", () => input.TrimStart(input.Length));
        }

        [TestMethod]
        public void Test_StringExtensions_TrimStart_WithLengthZero()
            => AssertHelper.AreEqual("[a]", () => "[a]".TrimStart(0));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_WithLengthLargerThanInput()
            => AssertHelper.AreEqual("", () => "[a]".TrimStart(4));

        [TestMethod]
        public void Test_StringExtensions_TrimStart_WithLength_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TrimStart(null, 0),
                "Object reference not set to an instance of an object.");

        [TestMethod]
        public void Test_StringExtensions_TrimStart_WithLengthNegative_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "".TrimStart(-1),
                "length of -1 is less than 0.");
    }
}
