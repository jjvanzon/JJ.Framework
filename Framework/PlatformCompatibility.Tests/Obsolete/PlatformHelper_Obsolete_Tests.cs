using System;
using System.IO;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    [TestClass]
    public class PlatformHelper_Obsolete_Tests
    {
        [TestMethod]
        public void Test_PlatformHelper_Obsolete_MemberInfo_MemberType_PlatformSafe_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformHelper_Accessor.MemberInfo_MemberType_PlatformSafe(default),
                "Use MemberType_PlatformSafe instead.");

        [TestMethod]
        public void Test_PlatformHelper_Obsolete_Type_GetInterface_PlatformSafe_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformHelper_Accessor.Type_GetInterface_PlatformSafe(default, default),
                "Use GetInterface_PlatformSafe instead.");

        [TestMethod]
        public void Test_PlatformHelper_Obsolete_XDocument_Save_PlatformSafe_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformHelper_Accessor.XDocument_Save_PlatformSafe(default, default),
                "Use Save_PlatformSafe instead.");

        [TestMethod]
        public void Test_PlatformHelper_Obsolete_XElement_Save_PlatformSafe_WithFileName_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformHelper_Accessor.XElement_Save_PlatformSafe(default, default(string)),
                "Use Save_PlatformSafe instead.");

        [TestMethod]
        public void Test_PlatformHelper_Obsolete_XElement_Save_PlatformSafe_WithStream_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformHelper_Accessor.XElement_Save_PlatformSafe(default, default(Stream)),
                "Use Save_PlatformSafe instead.");

        [TestMethod]
        public void Test_PlatformHelper_Obsolete_PropertyInfo_GetValue_PlatformSafe_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformHelper_Accessor.PropertyInfo_GetValue_PlatformSafe(default, default),
                "Use GetValue_PlatformSafe instead.");
    }
}
