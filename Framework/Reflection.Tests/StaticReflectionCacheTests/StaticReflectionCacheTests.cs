using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    [TestClass]
    public class StaticReflectionCacheTests
    {
        [TestMethod]
        public void Bug_StaticReflectionCache_MethodNotFound_NotSolved()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Overload);
            string expectedMessage = $"Method '{methodName}' not found.";

            // For now I hope to reproduce...
            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod<string, IFormatProvider, double>(type, methodName),
                expectedMessage);

            //StaticReflectionCache.GetMethod<string, IFormatProvider, double>(type, methodName);
        }
    }
}
