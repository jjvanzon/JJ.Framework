using Microsoft.VisualStudio.TestTools.UnitTesting;

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
