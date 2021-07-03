using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable StringLiteralTypo
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimEndUntil_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimEndUntil()
        {
            var input = "abcdefg";
            string output = input.TrimEndUntil("de");
            Assert.AreEqual("abcde", output);
        }
    }
}
