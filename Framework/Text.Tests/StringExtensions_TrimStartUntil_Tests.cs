using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimStartUntil_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil_MainCase()
            => AssertHelper.AreEqual("230123", () => "01230123".TrimStartUntil("23"));

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil_1stChar_ReturnsOriginalString()
            => AssertHelper.AreEqual("01230123", () => "01230123".TrimStartUntil("0"));

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil_2ndChar()
            => AssertHelper.AreEqual("1230123", () => "01230123".TrimStartUntil("1"));

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil_LastChar()
            => AssertHelper.AreEqual("8", () => "01235678".TrimStartUntil("8"));

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil_UntilStringNotFound_ReturnsOriginalString()
            => AssertHelper.AreEqual("01230123", () => "01230123".TrimStartUntil("45"));

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil_WithCharParameter()
            => AssertHelper.AreEqual("30123", () => "01230123".TrimStartUntil('3'));

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil_InputNull_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TrimStartUntil(null, "0"),
                "Object reference not set to an instance of an object.");

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil_UntilStringNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => "".TrimStartUntil(null),
                $"Value cannot be null.{NewLine}Parameter name: until");
    }
}
