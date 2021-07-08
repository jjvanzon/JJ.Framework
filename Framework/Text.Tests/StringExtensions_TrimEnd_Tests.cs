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
        {
            var input = "BlaLaLaBla";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("BlaLaLa", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_MultipleOccurrences()
        {
            var input = "BlaLaBlaBlaBla";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("BlaLa", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_NoOccurrences()
        {
            var input = "BlaLaLaLa";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("BlaLaLaLa", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_EndStringWhiteSpace()
        {
            string input = " LaLaLa ";
            string output = input.TrimEnd(" ");
            AssertHelper.AreEqual(" LaLaLa", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_InputEmpty()
        {
            string dummyEndString = "Bla";
            AssertHelper.AreEqual("", () => "".TrimEnd(dummyEndString));
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_ClearingEntireString()
        {
            var input = "LaLaLa";
            string output = input.TrimEnd("La");
            AssertHelper.AreEqual("", () => output);
        }

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
        {
            var input = "BlaLaLa";
            string output = input.TrimEnd(3);
            AssertHelper.AreEqual("BlaL", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength_EmptyInput()
        {
            int dummyLength = 0;
            AssertHelper.AreEqual("", () => "".TrimEnd(dummyLength));
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_WithLength_ClearingEntireString()
        {
            string input = "BlaLaLa";
            AssertHelper.AreEqual("", () => input.TrimEnd(input.Length));
        }

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