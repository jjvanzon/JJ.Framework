using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeEndUntil_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil()
            => AssertHelper.AreEqual("45", () => "12345".TakeEndUntil("3"));

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_LastCharacter_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "12345".TakeEndUntil("5"));

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_FirstCharacter_ReturnsAllButFirstCharacter()
            => AssertHelper.AreEqual("2345", () => "12345".TakeEndUntil("1"));

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_NegativeMatch_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "12345".TakeEndUntil("6"));

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_NullInput_ThrowsException()
        {
            string input = null;
            AssertHelper.ThrowsException<NullReferenceException>(
                () => input.TakeEndUntil("3"), 
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_NullUntilString_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => "12345".TakeEndUntil(null),
                $"Value cannot be null.{Environment.NewLine}Parameter name: until");
    }
}
