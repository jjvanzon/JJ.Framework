using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [TestClass]
    public sealed class Encoding_PlatformCompatibility_Tests
    {
        [TestMethod]
        public void Test_Encoding_PlatformSafe()
        {
            foreach (var encoding in new [] { Encoding.UTF8/*, Encoding.Unicode, Encoding.UTF32*/ })
            {
                string expected = "Test Encoding";
                byte[] bytes = encoding.GetBytes(expected);
                string actual1 = Encoding_PlatformSafe.GetString_PlatformSafe(encoding, bytes);
                string actual2 = encoding.GetString(bytes);
            }
        }
    }
}
