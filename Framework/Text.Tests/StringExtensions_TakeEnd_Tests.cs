using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeEnd_Tests
    {
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
    }
}
