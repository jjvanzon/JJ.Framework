using System;
using JJ.Framework.Logging;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class DoubleHelper_Obsolete_Tests
    {
        // TODO: Reusable methods for testing inner exceptions.

        [TestMethod]
        public void Test_DoubleHelper_Obsolete_TryParse_WithFormatProvider_ThrowsException()
        {
            try
            {
                DoubleHelper_Obsolete_Accessor.TryParse(null, null, out _);
            }
            catch (Exception ex)
            {
                ex = ex.GetInnermostException();
                Assert.IsInstanceOfType(ex, typeof(NotSupportedException));
                AssertHelper.AreEqual("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.", () => ex.Message);
            }
        }

        [TestMethod]
        public void Test_DoubleHelper_Obsolete_ParseNullable_ThrowsException()
        {
            try
            {
                DoubleHelper_Obsolete_Accessor.ParseNullable("");
            }
            catch (Exception ex)
            {
                ex = ex.GetInnermostException();
                Assert.IsInstanceOfType(ex, typeof(NotSupportedException));
                AssertHelper.AreEqual("Use JJ.Framework.Conversion.DoubleParser.ParseNullable instead.", () => ex.Message);
            }
        }

        [TestMethod]
        public void Test_DoubleHelper_Obsolete_TryParse_WithNullableParameter_ThrowsException()
        {
            try
            {
                DoubleHelper_Obsolete_Accessor.TryParse(null, out _);
            }
            catch (Exception ex)
            {
                ex = ex.GetInnermostException();
                Assert.IsInstanceOfType(ex, typeof(NotSupportedException));
                AssertHelper.AreEqual("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.", () => ex.Message);
            }
        }
    }
}
