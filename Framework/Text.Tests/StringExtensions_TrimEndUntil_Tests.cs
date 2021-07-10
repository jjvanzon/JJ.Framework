using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Environment;

// ReSharper disable StringLiteralTypo
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimEndUntil_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_MainCase()
            => AssertHelper.AreEqual("abcde", () => "abcdefg".TrimEndUntil("de"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_LastChar_ReturnsOriginalString()
            => AssertHelper.AreEqual("abcdefg", () => "abcdefg".TrimEndUntil("g"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_SecondLastChar()
            => AssertHelper.AreEqual("abcdef", () => "abcdefg".TrimEndUntil("f"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_FirstChar()
            => AssertHelper.AreEqual("a", () => "abcdefg".TrimEndUntil("a"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_UntilStringNotFound_ReturnsOriginalString()
            => AssertHelper.AreEqual("abcdefg", () => "abcdefg".TrimEndUntil("hi"));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_WithCharParameter()
            => AssertHelper.AreEqual("abcd", () => "abcdefg".TrimEndUntil('d'));

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_InputNull_ThrowsException()
            => AssertHelper.ThrowsException<NullReferenceException>(
                () => StringExtensions.TrimEndUntil(null, "a"),
                "Object reference not set to an instance of an object.");
        
        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil_UntilStringNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => "".TrimEndUntil(null),
                $"Value cannot be null.{NewLine}Parameter name: until");
    }
}
