using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    [TestClass]
    public class StaticReflectionCacheTests
    {
        [TestMethod]
        public void Bug_StaticReflectionCache_MethodNotFound_Fails_OneOutParameter()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneOutParameter);
            string expectedMessage = $"Method '{methodName}' not found.";

            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod<double>(type, methodName),
                expectedMessage);
        }

        [TestMethod]
        public void Bug_StaticReflectionCache_MethodNotFound_Succeeds_OneParameter_NotOut()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneParameter_NotOut);

            StaticReflectionCache.GetMethod<int>(type, methodName);
        }
    }
}
