using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        // FromTill

        [TestMethod]
        public void Test_StringExtensions_FromTill()
            => AssertHelper.AreEqual("12345678", () => "0123456789".FromTill(1, 8));

        [TestMethod]
        public void Test_StringExtensions_FromTill_StartIndexAndEndIndex_0()
            => AssertHelper.AreEqual("0", () => "0123456789".FromTill(0, 0));

        [TestMethod]
        public void Test_StringExtensions_FromTill_StartIndexAndEndIndex_AreLastCharacter()
            => AssertHelper.AreEqual("9", () => "0123456789".FromTill(9, 9));

        [TestMethod]
        public void Test_StringExtensions_FromTill_StartIndex_Negative_ThrowsException()
            => AssertHelper.ThrowsException(() => "0123456789".FromTill(-1, 9),
                                            "startIndex of -1 is less than 0.");

        [TestMethod]
        public void Test_StringExtensions_FromTill_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => StringExtensions.FromTill(null, default, default),
                $"Value cannot be null.{Environment.NewLine}Parameter name: input");

        [TestMethod]
        public void Test_StringExtensions_FromTill_StartIndex_ExceedsLastCharacter_ThrowsException()
            => AssertHelper.ThrowsException(() => "0123456789".FromTill(10, 9),
                                            "startIndex of 10 exceeds last character. input.Length = 10");

        [TestMethod]
        public void Test_StringExtensions_FromTill_EndIndex_Negative_ThrowsException()
            => AssertHelper.ThrowsException(() => "0123456789".FromTill(0, -1), 
                                            "endIndex of -1 is less than 0.");

        [TestMethod]
        public void Test_StringExtensions_FromTill_EndIndex_ExceedsLastCharacter_ThrowsException()
            => AssertHelper.ThrowsException(() => "0123456789".FromTill(0, 10), 
                                            "endIndex of 10 exceeds last character. input.Length = 10");

        [TestMethod]
        public void Test_StringExtensions_FromTill_StartIndex_GreaterThan_EndIndex_ThrowsException()
            => AssertHelper.ThrowsException(() => "0123456789".FromTill(8, 1),
                                            "startIndex of 8 is greater than endIndex of 1.");

        // Other

        [TestMethod]
        public void Test_StringExtensions_Left_NotEnoughCharacters_ThrowsException() => AssertHelper.ThrowsException(() => "1234".Left(5));

        [TestMethod]
        public void Test_StringExtensions_Right_NotEnoughCharacters_ThrowsException() => AssertHelper.ThrowsException(() => "1234".Right(5));

        [TestMethod]
        public void Test_StringExtensions_TakeEnd()
        {
            string output = "12345".TakeEnd(4);
            AssertHelper.AreEqual("2345", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_NotEnoughCharacters_ReturnsLessCharacters()
        {
            string output = "1234".TakeEnd(5);
            AssertHelper.AreEqual("1234", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil()
        {
            string output = "12345".TakeEndUntil("3");
            AssertHelper.AreEqual("45", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_NegativeMatch_ReturnsNullOrEmpty()
        {
            string output = "12345".TakeEndUntil("6");
            AssertHelper.IsNullOrEmpty(() => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStart()
        {
            string output = "12345".TakeStart(4);
            AssertHelper.AreEqual("1234", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStart_NotEnoughCharacters_ReturnsLessCharacters()
        {
            string output = "1234".TakeStart(5);
            AssertHelper.AreEqual("1234", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil()
        {
            string output = "12345".TakeStartUntil("4");
            AssertHelper.AreEqual("123", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil_NegativeMatch_ReturnsNullOrEmpty()
        {
            string output = "12345".TakeStartUntil("6");
            AssertHelper.IsNullOrEmpty(() => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_MultipleOccurrences()
        {
            var input = "LalaBlaBlaBla";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_OneOccurrence()
        {
            var input = "LalaBla";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil()
        {
            var input = "abcdefg";
            string output = input.TrimEndUntil("de");
            Assert.AreEqual("abcde", output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimFirst()
        {
            var input = "BlaBlaLala";
            string output = input.TrimFirst("Bla");
            AssertHelper.AreEqual("BlaLala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimLast()
        {
            var input = "LalaBlaBla";
            string output = input.TrimLast("Bla");
            AssertHelper.AreEqual("LalaBla", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimStart_MultipleOccurrences()
        {
            var input = "BlaBlaBlaLala";
            string output = input.TrimStart("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimStart_OneOccurrence()
        {
            var input = "BlaLala";
            string output = input.TrimStart("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil()
        {
            var input = "abcdefg";
            string output = input.TrimStartUntil("de");
            Assert.AreEqual("defg", output);
        }
    }
}
