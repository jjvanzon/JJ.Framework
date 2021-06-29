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
            => AssertHelper.ThrowsException(
                () => "0123456789".FromTill(-1, 9), "startIndex of -1 is less than 0.");

        [TestMethod]
        public void Test_StringExtensions_FromTill_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => StringExtensions.FromTill(null, default, default),
                $"Value cannot be null.{Environment.NewLine}Parameter name: input");

        [TestMethod]
        public void Test_StringExtensions_FromTill_StartIndex_ExceedsLastCharacter_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "0123456789".FromTill(10, 9),
                "startIndex of 10 exceeds last character. input.Length = 10");

        [TestMethod]
        public void Test_StringExtensions_FromTill_EndIndex_Negative_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "0123456789".FromTill(0, -1),
                "endIndex of -1 is less than 0.");

        [TestMethod]
        public void Test_StringExtensions_FromTill_EndIndex_ExceedsLastCharacter_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "0123456789".FromTill(0, 10),
                "endIndex of 10 exceeds last character. input.Length = 10");

        [TestMethod]
        public void Test_StringExtensions_FromTill_StartIndex_GreaterThan_EndIndex_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "0123456789".FromTill(8, 1),
                "startIndex of 8 is greater than endIndex of 1.");

        // Left

        [TestMethod]
        public void Test_StringExtensions_Left()
            => AssertHelper.AreEqual("12", () => "1234".Left(2));

        [TestMethod]
        public void Test_StringExtensions_Left_LengthZero()
            => AssertHelper.AreEqual("", () => "1234".Left(0));

        [TestMethod]
        public void Test_StringExtensions_Left_EntireString()
            => AssertHelper.AreEqual("1234", () => "1234".Left(4));

        [TestMethod]
        public void Test_StringExtensions_Left_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => StringExtensions.Left(null, default),
                $"Value cannot be null.{Environment.NewLine}Parameter name: input");

        [TestMethod]
        public void Test_StringExtensions_Left_LengthNegative_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentOutOfRangeException>(
                () => "1234".Left(-1),
                $"Length cannot be less than zero.{Environment.NewLine}Parameter name: length");

        [TestMethod]
        public void Test_StringExtensions_Left_NotEnoughCharacters_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentOutOfRangeException>(
                () => "1234".Left(5),
                $"Index and length must refer to a location within the string.{Environment.NewLine}Parameter name: length");

        // RemoveExcessiveWhiteSpace

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

        // Repeat

        [TestMethod]
        public void Test_StringExtensions_Repeat_RepeatCount_Many()
            => AssertHelper.AreEqual("123412341234", () => "1234".Repeat(3));

        [TestMethod]
        public void Test_StringExtensions_Repeat_RepeatCount_One()
            => AssertHelper.AreEqual("321", () => "321".Repeat(1));

        [TestMethod]
        public void Test_StringExtensions_Repeat_RepeatCount_Zero_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "1234".Repeat(0));

        [TestMethod]
        public void Test_StringExtensions_Repeat_StringToRepeat_EmptyString_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".Repeat(3));

        [TestMethod]
        public void Test_StringExtensions_Repeat_RepeatCount_Negative_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "1234".Repeat(-1), 
                "repeatCount of -1 is less than 0.");

        [TestMethod]
        public void Test_StringExtensions_Repeat_StringToRepeat_Null_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => StringExtensions.Repeat(null, default), 
                $"Value cannot be null.{Environment.NewLine}Parameter name: stringToRepeat");

        // Right

        [TestMethod]
        public void Test_StringExtensions_Right()
            => AssertHelper.AreEqual("34", () => "1234".Right(2));

        [TestMethod]
        public void Test_StringExtensions_Right_LengthZero()
            => AssertHelper.AreEqual("", () => "1234".Right(0));

        [TestMethod]
        public void Test_StringExtensions_Right_EntireString()
            => AssertHelper.AreEqual("1234", () => "1234".Right(4));

        [TestMethod]
        public void Test_StringExtensions_Right_NullInput_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => StringExtensions.Right(null, default),
                $"Value cannot be null.{Environment.NewLine}Parameter name: input");

        [TestMethod]
        public void Test_StringExtensions_Right_LengthNegative_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "1234".Right(-1),
                "length of -1 is less than 0.");

        [TestMethod]
        public void Test_StringExtensions_Right_NotEnoughCharacters_ThrowsException()
            => AssertHelper.ThrowsException(
                () => "1234".Right(5),
                "length of 5 is greater than input.Length of 4.");

        // Other

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
