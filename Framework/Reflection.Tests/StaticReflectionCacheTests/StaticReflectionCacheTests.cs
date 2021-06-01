using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    [TestClass]
    public class StaticReflectionCacheTests
    {
        [TestMethod]
        public void Bug_StaticReflectionCache_GetMethod_Generic_OneOutParameter_ThrowsException_MethodNotFound()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneOutParameter);
            string expectedMessage = $"Method '{methodName}' not found.";

            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod<double>(type, methodName),
                expectedMessage);
        }

        [TestMethod]
        public void Bug_StaticReflectionCache_GetMethod_Generic_One_OneParameter_NotOut_Succeeds()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneParameter_NotOut);

            StaticReflectionCache.GetMethod<int>(type, methodName);
        }
    }
}
