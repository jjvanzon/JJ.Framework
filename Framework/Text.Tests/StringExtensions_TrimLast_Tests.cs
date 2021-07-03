using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local
// ReSharper disable StringLiteralTypo

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_TrimLast_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_TrimLast()
        {
            var input = "LalaBlaBla";
            string output = input.TrimLast("Bla");
            AssertHelper.AreEqual("LalaBla", () => output);
        }
    }
}
