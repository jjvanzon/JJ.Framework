using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimEnd_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimEnd_MultipleOccurrences()
            => AssertHelper.AreEqual("[a][b]", () => "[a][b][a][a][a]".TrimEnd("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_OneOccurrence()
            => AssertHelper.AreEqual("[a][b][b]", () => "[a][b][b][a]".TrimEnd("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_NoOccurrences()
            => AssertHelper.AreEqual("[a][b][b][b]", () => "[a][b][b][b]".TrimEnd("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_EndStringWhiteSpace()
            => AssertHelper.AreEqual(" [a][a]", () => " [a][a] ".TrimEnd(" "));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_InputEmpty_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".TrimEnd("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_ClearingEntireString()
            => AssertHelper.AreEqual("", () => "[a][a][a]".TrimEnd("[a]"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_InputNull_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TrimEnd(null, "[a]"),
                "Object reference not set to an instance of an object.");

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_EndStringNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => StringExtensions.TrimEnd("[a]", null),
                "end is null or empty.");

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_EndStringEmpty_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "[a]".TrimEnd(""),
                "end is null or empty.");

        // With Length Parameter

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength()
            => AssertHelper.AreEqual("[a][b][", () => "[a][b][c]".TrimEnd(2));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength_EmptyInput_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".TrimEnd(default));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength_ClearingEntireString()
        {
            string input = "[a][b][c]";
            AssertHelper.AreEqual("", () => input.TrimEnd(input.Length));
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLengthZero()
            => AssertHelper.AreEqual("[a]", () => "[a]".TrimEnd(0));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLengthLargerThanInput()
            => AssertHelper.AreEqual("", () => "[a]".TrimEnd(4));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TrimEnd(null, 0),
                "Object reference not set to an instance of an object.");

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLengthNegative_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "[a]".TrimEnd(-1),
                "length of -1 is less than 0.");
    }
}
