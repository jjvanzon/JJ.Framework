using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimStart_Tests
    {
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
    }
}
