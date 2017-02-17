using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Test_StringExtensions_CutRightUntil()
        {
            string input = "abcdefg";
            string output = input.TrimEndUntil("de");
            Assert.AreEqual("abcde", output);
        }

        [TestMethod]
        public void Test_StringExtensions_CutLeftUntil()
        {
            string input = "abcdefg";
            string output = input.TrimStartUntil("de");
            Assert.AreEqual("defg", output);
        }
    }
}
