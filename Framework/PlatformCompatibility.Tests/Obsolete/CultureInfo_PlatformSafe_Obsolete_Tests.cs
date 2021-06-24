using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    [TestClass]
    public class CultureInfo_PlatformSafe_Obsolete_Tests
    {
        [TestMethod]
        public void Test_PlatformHelper_Obsolete_PlatformHelper_CultureInfo_GetCultureInfo_PlatformSafe_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformHelper_Accessor.CultureInfo_GetCultureInfo_PlatformSafe(default),
                "Use GetCultureInfo_PlatformSafe instead.");
    }
}
