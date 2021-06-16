using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class Int32Helper_Obsolete_Tests
    {
        [TestMethod]
        public void Test_Int32Helper_Obsolete_TryParse_WithIFormatProvider_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => Int32Helper_Obsolete_Accessor.TryParse(null, null, out _),
                "Use JJ.Framework.Conversion.Int32Parser instead.");


        [TestMethod]
        public void Test_Int32Helper_Obsolete_ParseNullable_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => Int32Helper_Obsolete_Accessor.ParseNullable(""),
                "Use JJ.Framework.Conversion.Int32Parser instead.");

        [TestMethod]
        public void Test_Int32Helper_Obsolete_TryParse_WithNullableOutParameter_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => Int32Helper_Obsolete_Accessor.TryParse(null, out _),
                "Use JJ.Framework.Conversion.Int32Parser instead.");
    }
}
