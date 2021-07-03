using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimEnd_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimEnd_MultipleOccurrences()
        {
            var input = "LalaBlaBlaBla";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }

        [TestMethod]
        public void Test_StringExtensions_TrimEnd_OneOccurrence()
        {
            var input = "LalaBla";
            string output = input.TrimEnd("Bla");
            AssertHelper.AreEqual("Lala", () => output);
        }
    }
}
