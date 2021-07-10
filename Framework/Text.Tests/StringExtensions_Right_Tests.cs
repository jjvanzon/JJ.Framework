using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Right_Tests
    {
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
                $"Value cannot be null.{NewLine}Parameter name: input");

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
    }
}
