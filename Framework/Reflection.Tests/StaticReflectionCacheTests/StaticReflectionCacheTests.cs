using System;
using System.Reflection;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    [TestClass]
    public class StaticReflectionCacheTests
    {
        [TestMethod]
        public void Bug_StaticReflectionCache_GetMethod_OneOutParameter_ThrowsException_MethodNotFound()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneOutParameter);
            string expectedMessage = $"Method '{methodName}' not found.";

            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod(type, methodName, typeof(double)),
                expectedMessage);
        }

        [TestMethod]
        public void Bug_StaticReflectionCache_GetMethod_OneParameter_NotOut_Succeeds()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneParameter_NotOut);

            StaticReflectionCache.GetMethod(type, methodName, typeof(int));
        }
    }
}
