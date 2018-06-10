using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Test_StringExtensions_Left_NotEnoughCharacters_ThrowsException() => AssertHelper.ThrowsException(() => "1234".Left(5));

        [TestMethod]
        public void Test_StringExtensions_Right_NotEnoughCharacters_ThrowsException() => AssertHelper.ThrowsException(() => "1234".Right(5));

        [TestMethod]
        public void Test_StringExtensions_TakeEnd()
        {
            string output = "12345".TakeEnd(4);
            AssertHelper.AreEqual("2345", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEnd_NotEnoughCharacters_ReturnsLessCharacters()
        {
            string output = "1234".TakeEnd(5);
            AssertHelper.AreEqual("1234", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil()
        {
            string output = "12345".TakeEndUntil("3");
            AssertHelper.AreEqual("45", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeEndUntil_NegativeMatch_ReturnsNullOrEmpty()
        {
            string output = "12345".TakeEndUntil("6");
            AssertHelper.IsNullOrEmpty(() => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStart()
        {
            string output = "12345".TakeStart(4);
            AssertHelper.AreEqual("1234", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStart_NotEnoughCharacters_ReturnsLessCharacters()
        {
            string output = "1234".TakeStart(5);
            AssertHelper.AreEqual("1234", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil()
        {
            string output = "12345".TakeStartUntil("4");
            AssertHelper.AreEqual("123", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TakeStartUntil_NegativeMatch_ReturnsNullOrEmpty()
        {
            string output = "12345".TakeStartUntil("6");
            AssertHelper.IsNullOrEmpty(() => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_MultipleOccurrences()
        {
            var input = "LalaBlaBlaBla";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_OneOccurrence()
        {
            var input = "LalaBla";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil()
        {
            var input = "abcdefg";
            string output = input.TrimEndUntil("de");
            Assert.AreEqual("abcde", output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimFirst()
        {
            var input = "BlaBlaLala";
            string output = input.TrimFirst("Bla");
            AssertHelper.AreEqual("BlaLala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimLast()
        {
            var input = "LalaBlaBla";
            string output = input.TrimLast("Bla");
            AssertHelper.AreEqual("LalaBla", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimStart_MultipleOccurrences()
        {
            var input = "BlaBlaBlaLala";
            string output = input.TrimStart("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimStart_OneOccurrence()
        {
            var input = "BlaLala";
            string output = input.TrimStart("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil()
        {
            var input = "abcdefg";
            string output = input.TrimStartUntil("de");
            Assert.AreEqual("defg", output);
        }
    }
}