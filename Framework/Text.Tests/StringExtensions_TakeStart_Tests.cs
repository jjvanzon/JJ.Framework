using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeStart_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TakeStart()
            => AssertHelper.AreEqual("123", () => "12345".TakeStart(3));

        [TestMethod]
        public void Test_StringExtensions_TakeStart_NotEnoughCharacters_ReturnsLessCharacters()
            => AssertHelper.AreEqual("12345", () => "12345".TakeStart(6));

        [TestMethod]
        public void Test_StringExtensions_TakeStart_InputEmptyString_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "".TakeStart(3));

        [TestMethod]
        public void Test_StringExtensions_TakeStart_LengthZero_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "12345".TakeStart(0));

        [TestMethod]
        public void Test_StringExtensions_TakeStart_InputNull_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TakeStart(null, 3),
                "Object reference not set to an instance of an object.");

        [TestMethod]
        public void Test_StringExtensions_TakeStart_LengthNegative_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentOutOfRangeException>(
                () => "12345".TakeStart(-1),
                $"Length cannot be less than zero.{NewLine}Parameter name: length");
    }
}
