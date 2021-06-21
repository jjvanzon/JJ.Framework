using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class EmbeddedResourceHelper_Obsolete_Tests
    {
        [TestMethod]
        public void Test_EmbeddedResourceHelper_Obsolete_GetEmbeddedResourceText_WithoutSubNameSpace_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EmbeddedResourceHelper_Obsolete_Accessor.GetEmbeddedResourceText(null, null),
                "Use EmbeddedResourceReader.GetText instead.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_Obsolete_GetEmbeddedResourceBytes_WithoutSubNameSpace_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EmbeddedResourceHelper_Obsolete_Accessor.GetEmbeddedResourceBytes(null, null),
                "Use EmbeddedResourceReader.GetBytes instead.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_Obsolete_GetEmbeddedResourceStream_WithoutSubNameSpace_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EmbeddedResourceHelper_Obsolete_Accessor.GetEmbeddedResourceStream(null, null),
                "Use EmbeddedResourceReader.GetStream instead.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_Obsolete_GetEmbeddedResourceName_WithoutSubNameSpace_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EmbeddedResourceHelper_Obsolete_Accessor.GetEmbeddedResourceName(null, null),
                "Use EmbeddedResourceReader.GetName instead.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_Obsolete_GetEmbeddedResourceText_WithSubNameSpace_ThrowsException()    
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EmbeddedResourceHelper_Obsolete_Accessor.GetEmbeddedResourceText(null, null, null),
                "Use EmbeddedResourceReader.GetText instead.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_Obsolete_GetEmbeddedResourceBytes_WithSubNameSpace_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EmbeddedResourceHelper_Obsolete_Accessor.GetEmbeddedResourceBytes(null, null, null),
                "Use EmbeddedResourceReader.GetBytes instead.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_Obsolete_GetEmbeddedResourceStream_WithSubNameSpace_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EmbeddedResourceHelper_Obsolete_Accessor.GetEmbeddedResourceStream(null, null, null),
                "Use EmbeddedResourceReader.GetStream instead.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_Obsolete_GetEmbeddedResourceName_WithSubNameSpace_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EmbeddedResourceHelper_Obsolete_Accessor.GetEmbeddedResourceName(null, null, null),
                "Use EmbeddedResourceReader.GetName instead.");
    }
}
