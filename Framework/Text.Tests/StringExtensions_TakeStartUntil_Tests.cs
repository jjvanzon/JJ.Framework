using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeStartUntil_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil() 
            => AssertHelper.AreEqual("123", () => "12345".TakeStartUntil("4"));

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil_FirstCharacter_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "12345".TakeStartUntil("1"));

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil_LastCharacter_ReturnsAllButLastCharacter()
            => AssertHelper.AreEqual("1234", () => "12345".TakeStartUntil("5"));

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil_NegativeMatch_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "12345".TakeStartUntil("6"));

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil_NullInput_ThrowsException()
        {
            string nullInput = null;
            string dummyUntilString = "3";

            AssertHelper.ThrowsException<NullReferenceException>(
                () => nullInput.TakeStartUntil(dummyUntilString),
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil_NullUntilString_ThrowsException()
        {
            string dummyInput = "12345";

            AssertHelper.ThrowsException<ArgumentNullException>(
                () => dummyInput.TakeStartUntil(null),
                $"Value cannot be null.{Environment.NewLine}Parameter name: until");
        }
    }
}
