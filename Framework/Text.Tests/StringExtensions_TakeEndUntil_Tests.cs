using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeEndUntil_Tests
    {
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
    }
}
