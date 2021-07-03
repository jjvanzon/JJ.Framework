using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local
// ReSharper disable StringLiteralTypo

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimStartUntil_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimStartUntil()
        {
            var input = "abcdefg";
            string output = input.TrimStartUntil("de");
            Assert.AreEqual("defg", output);
        }
    }
}
