using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeEndUntil_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil()
            => AssertHelper.AreEqual("45", () => "12345".TakeEndUntil("23"));

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_LastCharacters_ReturnsEmptyString()
            => AssertHelper.AreEqual("", () => "12345".TakeEndUntil("45"));

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_FirstCharacters_ReturnsAllButFirstCharacters()
            => AssertHelper.AreEqual("345", () => "12345".TakeEndUntil("12"));

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_NegativeMatch_ReturnsEmptyString()
        {
            string nonExistingString = "-10";
            AssertHelper.AreEqual("", () => "12345".TakeEndUntil(nonExistingString));
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_OverloadWithChar()
            => AssertHelper.AreEqual("45", () => "12345".TakeEndUntil('3'));

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_NullInput_ThrowsException()
        {
            string nullInput = null;
            string dummyUntilString = "3";

            AssertHelper.ThrowsException<NullReferenceException>(
                () => nullInput.TakeEndUntil(dummyUntilString), 
                "Object reference not set to an instance of an object.");
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_NullUntilString_ThrowsException()
        {
            string dummyInput = "12345";

            AssertHelper.ThrowsException<ArgumentNullException>(
                () => dummyInput.TakeEndUntil(null),
                $"Value cannot be null.{Environment.NewLine}Parameter name: until");
        }
    }
}
