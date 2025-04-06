using System.Globalization;

namespace JJ.Framework.PlatformCompatibility.Core.Tests
{
    [TestClass]
    public sealed class PlatformCompatibility_CultureInfo_Core_Tests
    {
        [TestMethod]
        public void PlatformCompatibility_CultureInfo_Core_Test()
        {
            foreach (string cultureName in new[] { "nl-NL", "en-US", "de-DE", "zh-CN" })
            {
                var cultureInfo1 = CultureInfo.GetCultureInfo(cultureName);
                var cultureInfo2 = new CultureInfo(cultureName);
                var cultureInfo3 = CultureInfo_PlatformSafe.GetCultureInfo(cultureName);
                var cultureInfo4 = PlatformHelper.GetCultureInfo_PlatformSafe(cultureName);
                
                IsNotNull(cultureInfo1);
                IsNotNull(cultureInfo2);
                IsNotNull(cultureInfo3);
                IsNotNull(cultureInfo4);
                
                AreEqual(cultureInfo1.Name, cultureInfo2.Name);
                AreEqual(cultureInfo2.Name, cultureInfo3.Name);
                AreEqual(cultureInfo3.Name, cultureInfo4.Name);
            }
        }
    }
}
