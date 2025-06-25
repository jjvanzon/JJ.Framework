using System;
using System.IO;
using System.Xml.Linq;
using JJ.Framework.Testing;
using JJ.Framework.Testing.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable IDE0034 // Simplify 'default' expression
// ReSharper disable RedundantTypeSpecificationInDefaultExpression

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    [TestClass]
    public class PlatformExtensions_Obsolete_Tests
    {
        [TestMethod]
        public void Test_PlatformExtensions_Obsolete_MemberInfo_MemberType_PlatformSafe_ThrowsException()
            => AssertHelperLegacy.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformExtensions_Accessor.MemberType_PlatformSafe(default),
                "Use PlatformHelper instead.");

        [TestMethod]
        public void Test_PlatformExtensions_Obsolete_Type_GetInterface_PlatformSafe_ThrowsException()
            => AssertHelperLegacy.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformExtensions_Accessor.GetInterface_PlatformSafe(default, default),
                "Use PlatformHelper instead.");

        [TestMethod]
        public void Test_PlatformExtensions_Obsolete_XDocument_Save_PlatformSafe_ThrowsException()
            => AssertHelperLegacy.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformExtensions_Accessor.Save_PlatformSafe(default(XDocument), default),
                "Use PlatformHelper instead.");

        [TestMethod]
        public void Test_PlatformExtensions_Obsolete_XElement_Save_PlatformSafe_WithFileName_ThrowsException()
            => AssertHelperLegacy.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformExtensions_Accessor.Save_PlatformSafe(default(XElement), default(string)),
                "Use PlatformHelper instead.");

        [TestMethod]
        public void Test_PlatformExtensions_Obsolete_XElement_Save_PlatformSafe_WithStream_ThrowsException()
            => AssertHelperLegacy.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformExtensions_Accessor.Save_PlatformSafe(default(XElement), default(Stream)),
                "Use PlatformHelper instead.");

        [TestMethod]
        public void Test_PlatformExtensions_Obsolete_PropertyInfo_GetValue_PlatformSafe_ThrowsException()
            => AssertHelperLegacy.ThrowsException_OrInnerException<NotSupportedException>(
                () => PlatformExtensions_Accessor.GetValue_PlatformSafe(default, default),
                "Use PlatformHelper instead.");
    }
}
