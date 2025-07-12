using System;
using JJ.Framework.PlatformCompatibility.Core;
using JJ.Framework.PlatformCompatibility.Tests.Helpers;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [Suppress("Trimmer", "IL2026", Justification = ExpressionsWithArrays)]
    [TestClass]
    public class Type_GetInterface_PlatformSafe_Tests
    {
        private interface ITestInterface { }

        private class TestHelper : ITestInterface { }

        [TestMethod]
        public void Test_Type_GetInterface_PlatformSafe_CorrectNameCasing_ReturnsNotNull()
        {
            Type interfaceType = typeof(TestHelper).GetInterface_PlatformSafe(nameof(ITestInterface));
            AssertHelper.IsNotNull(() => interfaceType);
        }

        [TestMethod]
        public void Test_Type_GetInterface_PlatformSafe_WrongNNameCasing_ReturnsNull()
        {
            Type interfaceType = typeof(TestHelper).GetInterface_PlatformSafe(nameof(ITestInterface).ToLower());
            AssertHelper.IsNull(() => interfaceType);
        }

        [TestMethod]
        public void Test_Type_GetInterface_FromDotNet_CorrectNameCasing_ReturnsNotNull()
        {
            Type interfaceType = typeof(TestHelper).GetInterface(nameof(ITestInterface));
            AssertHelper.IsNotNull(() => interfaceType);
        }

        [TestMethod]
        public void Test_Type_GetInterface_FromDotNet_WrongNameCasing_ReturnsNull()
        {
            Type interfaceType = typeof(TestHelper).GetInterface(nameof(ITestInterface).ToLower());
            AssertHelper.IsNull(() => interfaceType);
        }
    }
}
