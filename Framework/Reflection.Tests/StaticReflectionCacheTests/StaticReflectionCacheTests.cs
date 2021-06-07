using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.StaticReflectionCacheTests
{
    [TestClass]
    public class StaticReflectionCacheTests
    {
        [TestMethod]
        public void StaticReflectionCache_GetMethod_NonRefParameter_Succeeds()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_NonRefParameter);
            Type parameterType = typeof(int);
            StaticReflectionCache.GetMethod(type, methodName, parameterType);
        }

        [TestMethod]
        public void StaticReflectionCache_GetMethod_OutParameter_Calling_MakeByRefType_Succeeds()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OutParameter);
            Type parameterType = typeof(double).MakeByRefType();
            StaticReflectionCache.GetMethod(type, methodName, parameterType);
        }

        [TestMethod]
        public void StaticReflectionCache_GetMethod_OutParameter_NotCalling_MakeByRefType_ThrowsException()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OutParameter);
            string expectedMessage = $"Method '{methodName}' not found.";
            Type parameterType = typeof(double);

            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod(type, methodName, parameterType),
                expectedMessage);
        }
    }
}
