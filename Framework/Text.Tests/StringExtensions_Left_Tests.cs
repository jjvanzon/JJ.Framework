using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Left_Tests
    {
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
                $"Value cannot be null.{NewLine}Parameter name: input");

        [TestMethod]
        public void Test_StringExtensions_Left_LengthNegative_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentOutOfRangeException>(
                () => "1234".Left(-1),
                $"Length cannot be less than zero.{NewLine}Parameter name: length");

        [TestMethod]
        public void Test_StringExtensions_Left_NotEnoughCharacters_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentOutOfRangeException>(
                () => "1234".Left(5),
                $"Index and length must refer to a location within the string.{NewLine}Parameter name: length");
    }
}
