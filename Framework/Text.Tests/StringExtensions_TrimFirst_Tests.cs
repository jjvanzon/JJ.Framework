using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable StringLiteralTypo
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimFirst_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimFirst()
        {
            var input = "BlaBlaLala";
            string output = input.TrimFirst("Bla");
            AssertHelper.AreEqual("BlaLala", () => output);
        }
    }
}
