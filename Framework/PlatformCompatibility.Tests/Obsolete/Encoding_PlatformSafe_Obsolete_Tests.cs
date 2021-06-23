using System;
using JJ.Framework.Testing.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    [TestClass]
    public class Encoding_PlatformSafe_Obsolete_Tests
    {
        [TestMethod]
        public void Test_Encoding_PlatformSafe_Obsolete_GetString_PlatformSafe_ThrowsException()
            => AssertHelperLegacy.ThrowsException_OrInnerException<NotSupportedException>(
                () => Encoding_PlatformSafe_Accessor.GetString_PlatformSafe(default, default),
                "Use PlatformHelper.GetString_PlatformSafe instead.");
    }
}
