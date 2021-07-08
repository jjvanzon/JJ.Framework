using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        {
            int dummyLength = 3;
            AssertHelper.AreEqual("", () => "".TakeStart(dummyLength));
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStart_LengthZero_ReturnsEmptyString()
        {
            string dummyInput = "12345";
            AssertHelper.AreEqual("", () => dummyInput.TakeStart(0));
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStart_InputNull_ThrowsException()
        {
            string nullInput = null;
            int dummyLength = 3;
            AssertHelper.ThrowsException<NullReferenceException>(
                () => nullInput.TakeStart(dummyLength),
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStart_LengthNegative_ThrowsException()
        {
            string dummyInput = "12345";
            AssertHelper.ThrowsException<ArgumentOutOfRangeException>(
                () => dummyInput.TakeStart(-1),
                $"Length cannot be less than zero.{Environment.NewLine}Parameter name: length");
        }
    }
}
