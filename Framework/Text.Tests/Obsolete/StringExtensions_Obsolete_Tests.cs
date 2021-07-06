using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests.Obsolete
{
    [TestClass]
    public class StringExtensions_Obsolete_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_Obsolete_TakeLeft_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => StringExtensions_Accessor.TakeLeft(default, default),
                "Use TakeStart instead.");

        [TestMethod]
        public void Test_StringExtensions_Obsolete_TakeRight_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => StringExtensions_Accessor.TakeRight(default, default),
                "Use TakeEnd instead.");
    }
}
