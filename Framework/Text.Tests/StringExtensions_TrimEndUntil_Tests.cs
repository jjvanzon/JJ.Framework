using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimEndUntil_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil()
            => AssertHelper.AreEqual("012301", () => "01230123".TrimEndUntil("01"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_LastChar_ReturnsOriginalString()
            => AssertHelper.AreEqual("01230123", () => "01230123".TrimEndUntil("3"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_2ndLastChar()
            => AssertHelper.AreEqual("0123012", () => "01230123".TrimEndUntil("2"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_1stChar()
            => AssertHelper.AreEqual("0", () => "01235678".TrimEndUntil("0"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_UntilStringNotFound_ReturnsOriginalString()
            => AssertHelper.AreEqual("01230123", () => "01230123".TrimEndUntil("45"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_WithCharParameter()
            => AssertHelper.AreEqual("012301", () => "01230123".TrimEndUntil('1'));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_InputNull_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TrimEndUntil(null, "0"),
                "Object reference not set to an instance of an object.");
        
        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_UntilStringNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => "".TrimEndUntil(null),
                $"Value cannot be null.{NewLine}Parameter name: until");
    }
}
