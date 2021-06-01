using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    [TestClass]
    public class StaticReflectionCacheTests
    {
        [TestMethod]
        public void Test_StaticReflectionCache_Bug_MethodNotFound_NotSolved()
        {
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Overload);
            string expectedMessage = $"Method '{methodName}' not found.";
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);

            // For now I hope to reproduce...
            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod<string, IFormatProvider, double>(type, methodName), 
                expectedMessage);
        }
    }
}
