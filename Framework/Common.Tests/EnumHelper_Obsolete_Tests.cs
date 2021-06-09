using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class EnumHelper_Obsolete_Tests
    {
        [TestMethod]
        public void Test_EnumHelper_Obsolete_Parse_ThrowsException()
        {
            Assert.Inconclusive("Test may not be performed, because of problems getting MethodInfo with type arguments.");

            AssertHelper.ThrowsException<NotSupportedException>(
                () => EnumHelper_Obsolete_Accessor.Parse<object>(""),
                "JJ.Framework.Conversion.EnumParser.Parse instead.");
        }
    }
}
