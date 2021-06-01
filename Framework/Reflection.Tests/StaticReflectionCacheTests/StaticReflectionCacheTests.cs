using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    [TestClass]
    public class StaticReflectionCacheTests
    {
        [TestMethod]
        public void Bug_StaticReflectionCache_MethodNotFound_Fails_ThreeParameters_OfWhichOnOutParameter()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_ThreeParameters_OfWhichOnOutParameter);
            string expectedMessage = $"Method '{methodName}' not found.";

            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod<string, IFormatProvider, double>(type, methodName),
                expectedMessage);
        }

        [TestMethod]
        public void Bug_StaticReflectionCache_MethodNotFound_Succeeds_ThreeParameters_NoOutParameter()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_ThreeParameters_NoOutParameter);

            StaticReflectionCache.GetMethod<string, IFormatProvider, int>(type, methodName);
        }
    }
}
