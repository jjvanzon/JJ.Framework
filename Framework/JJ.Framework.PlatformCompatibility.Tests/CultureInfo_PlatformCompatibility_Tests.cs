using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [TestClass]
    public sealed class CultureInfo_PlatformCompatibility_Tests
    {
        [TestMethod]
        public void Test_CultureInfo_PlatformSafe()
        {
            foreach (string cultureName in new[] { "nl-NL", "en-US", "de-DE", "zh-CN" })
            {
                var cultureInfo1 = CultureInfo.GetCultureInfo(cultureName);
                var cultureInfo2 = new CultureInfo(cultureName);
                var cultureInfo3 = CultureInfo_PlatformSafe.GetCultureInfo(cultureName);
                
                IsNotNull(cultureInfo1);
                IsNotNull(cultureInfo2);
                IsNotNull(cultureInfo3);
                
                AreEqual(cultureInfo1.Name, cultureInfo2.Name);
                AreEqual(cultureInfo2.Name, cultureInfo3.Name);
            }
        }
        
        [TestMethod]
        public void Test_PlatformHelper_CultureInfo_GetCultureInfo_PlatformSafe()
        {
            foreach (string cultureName in new[] { "nl-NL", "en-US", "de-DE", "zh-CN" })
            {
                var cultureInfo1 = CultureInfo.GetCultureInfo(cultureName);
                var cultureInfo2 = new CultureInfo(cultureName);
                var cultureInfo3 = PlatformHelper.CultureInfo_GetCultureInfo_PlatformSafe(cultureName);
                
                IsNotNull(cultureInfo1);
                IsNotNull(cultureInfo2);
                IsNotNull(cultureInfo3);
                
                AreEqual(cultureInfo1.Name, cultureInfo2.Name);
                AreEqual(cultureInfo2.Name, cultureInfo3.Name);
            }
        }
    }
}
