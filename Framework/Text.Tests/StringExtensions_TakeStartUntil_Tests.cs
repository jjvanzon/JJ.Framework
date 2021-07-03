using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TakeStartUntil_Tests
    {
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
    }
}
