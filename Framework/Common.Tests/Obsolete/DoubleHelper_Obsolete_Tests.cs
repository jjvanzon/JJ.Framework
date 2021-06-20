using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests.Obsolete
{
    [TestClass]
    public class DoubleHelper_Obsolete_Tests
    {
        [TestMethod]
        public void Test_DoubleHelper_Obsolete_TryParse_WithIFormatProvider_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => DoubleHelper_Obsolete_Accessor.TryParse(null, null, out _),
                "Use JJ.Framework.Conversion.DoubleParser.TryParse instead.");

        [TestMethod]
        public void Test_DoubleHelper_Obsolete_ParseNullable_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => DoubleHelper_Obsolete_Accessor.ParseNullable(""),
                "Use JJ.Framework.Conversion.DoubleParser.ParseNullable instead.");

        [TestMethod]
        public void Test_DoubleHelper_Obsolete_TryParse_WithNullableOutParameter_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => DoubleHelper_Obsolete_Accessor.TryParse(null, out _),
                "Use JJ.Framework.Conversion.DoubleParser.TryParse instead.");
    }
}
