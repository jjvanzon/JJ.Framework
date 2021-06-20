using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class EnumHelper_Obsolete_Tests
    {
        private enum TestEnum { }

        [TestMethod]
        public void Test_EnumHelper_Obsolete_Parse_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => EnumHelper_Obsolete_Accessor.Parse<TestEnum>(null),
                "Use JJ.Framework.Conversion.EnumParser.Parse instead.");
    }
}
