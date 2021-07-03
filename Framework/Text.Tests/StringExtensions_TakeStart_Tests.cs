using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeStart_Tests
    {
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
    }
}
