using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Repeat_Tests
    {
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
    }
}
