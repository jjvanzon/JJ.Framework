using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Common;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Test_StringExtensions_CutRightUntil()
        {
            string input = "abcdefg";
            string output = input.CutRightUntil("de");
            Assert.AreEqual("abcde", output);
        }

        [TestMethod]
        public void Test_StringExtensions_CutLeftUntil()
        {
            string input = "abcdefg";
            string output = input.CutLeftUntil("de");
            Assert.AreEqual("defg", output);
        }
    }
}
