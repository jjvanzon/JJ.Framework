using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable ConvertToConstant.Local
// ReSharper disable StringLiteralTypo

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimEnd_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimEnd_OneOccurrence()
            => AssertHelper.AreEqual("BlaLaLa", () => "BlaLaLaBla".TrimEnd("Bla"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_MultipleOccurrences()
            => AssertHelper.AreEqual("BlaLa", () => "BlaLaBlaBlaBla".TrimEnd("Bla"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_NoOccurrences()
            => AssertHelper.AreEqual("BlaLaLaLa", () => "BlaLaLaLa".TrimEnd("Bla"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_EndStringWhiteSpace()
            => AssertHelper.AreEqual(" LaLaLa", () => " LaLaLa ".TrimEnd(" "));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_InputEmpty()
        {
            string dummyEndString = "Bla";
            AssertHelper.AreEqual("", () => "".TrimEnd(dummyEndString));
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_ClearingEntireString()
            => AssertHelper.AreEqual("", () => "LaLaLa".TrimEnd("La"));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_InputNull_ThrowsException()
        {
            string nullInput = null;
            string dummyEndString = "Bla";
            AssertHelper.ThrowsException<NullReferenceException>(
                () => nullInput.TrimEnd(dummyEndString),
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_EndStringNull_ThrowsException()
        {
            string dummyInput = "LaLaLa";
            string nullEndString = null;
            AssertHelper.ThrowsException(
                () => dummyInput.TrimEnd(nullEndString),
                "end is null or empty.");
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_EndStringEmpty_ThrowsException()
        {
            string dummyInput = "LaLaLa";
            AssertHelper.ThrowsException(
                () => dummyInput.TrimEnd(""),
                "end is null or empty.");
        }

        // With Length Parameter

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength()
            => AssertHelper.AreEqual("BlaL", () => "BlaLaLa".TrimEnd(3));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength_EmptyInput()
        {
            int dummyLength = 0;
            AssertHelper.AreEqual("", () => "".TrimEnd(dummyLength));
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength_ClearingEntireString() 
            => AssertHelper.AreEqual("", () => "BlaLaLa".TrimEnd("BlaLaLa".Length));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLengthZero()
            => Assert.AreEqual("Bla", "Bla".TrimEnd(0));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLengthLargerThanInput()
            => AssertHelper.AreEqual("", () => "Bla".TrimEnd(4));

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength_NullInput_ThrowsException()
        {
            string nullInput = null;
            int dummyLength = 0;
            AssertHelper.ThrowsException<NullReferenceException>(
                () => nullInput.TrimEnd(dummyLength),
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLengthNegative_ThrowsException()
        {
            string dummyInput = "Bla";
            AssertHelper.ThrowsException(
                () => dummyInput.TrimEnd(-1),
                "length of -1 is less than 0.");
        }
    }
}
