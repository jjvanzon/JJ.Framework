using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [TestClass]
    public sealed class PlatformCompatibilityTests
    {
        [TestMethod]
        public void Test_CultureInfo_PlatformSafe()
        {
            var cultureInfo1 = CultureInfo.GetCultureInfo("nl-NL");
            var cultureInfo2 = new CultureInfo("nl-NL");
            var cultureInfo3 = CultureInfo_PlatformSafe.GetCultureInfo("nl-NL");
            
            IsNotNull(cultureInfo1);
            IsNotNull(cultureInfo2);
            IsNotNull(cultureInfo3);
            
            AreEqual(cultureInfo1.Name, cultureInfo2.Name);
            AreEqual(cultureInfo2.Name, cultureInfo3.Name);
        }
    }
}
