using System.Globalization;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [TestClass]
    public class CultureInfo_PlatformSafe_Tests
    {
        [TestMethod]
        public void Test_CultureInfo_PlatformSafe_GetCultureInfo()
        {
            {
                CultureInfo cultureInfo = CultureInfo_PlatformSafe.GetCultureInfo("nl-NL");
                AssertHelper.IsNotNull(() => cultureInfo);
                AssertHelper.AreEqual("nl-NL", () => cultureInfo.Name);
            }
            {
                CultureInfo cultureInfo = CultureInfo_PlatformSafe.GetCultureInfo("de-DE");
                AssertHelper.IsNotNull(() => cultureInfo);
                AssertHelper.AreEqual("de-DE", () => cultureInfo.Name);
            }
        }

        [TestMethod]
        public void Test_PlatformHelper_GetCultureInfo_PlatformSafe()
        {
            {
                CultureInfo cultureInfo = PlatformHelper.GetCultureInfo_PlatformSafe("nl-NL");
                AssertHelper.IsNotNull(() => cultureInfo);
                AssertHelper.AreEqual("nl-NL", () => cultureInfo.Name);
            }
            {
                CultureInfo cultureInfo = PlatformHelper.GetCultureInfo_PlatformSafe("de-DE");
                AssertHelper.IsNotNull(() => cultureInfo);
                AssertHelper.AreEqual("de-DE", () => cultureInfo.Name);
            }
        }
    }
}
