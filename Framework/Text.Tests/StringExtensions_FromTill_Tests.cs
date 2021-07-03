using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_FromTill_Tests
    {
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
    }
}
