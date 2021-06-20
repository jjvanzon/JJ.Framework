using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.ReflectionCacheTests
{
    [TestClass]
    public class ReflectionCacheTests
    {
        private static readonly ReflectionCache _reflectionCache = new ReflectionCache();

        [TestMethod]
        public void StaticReflectionCache_GetMethod_NonRefParameter_Succeeds()
        {
            Type type = typeof(ReflectionCacheTests_HelperClass);
            const string methodName = nameof(ReflectionCacheTests_HelperClass.Method_NonRefParameter);
            Type parameterType = typeof(int);
            _reflectionCache.GetMethod(type, methodName, parameterType);
        }

        [TestMethod]
        public void StaticReflectionCache_GetMethod_OutParameter_Calling_MakeByRefType_Succeeds()
        {
            Type type = typeof(ReflectionCacheTests_HelperClass);
            const string methodName = nameof(ReflectionCacheTests_HelperClass.Method_OutParameter);
            Type parameterType = typeof(double).MakeByRefType();
            _reflectionCache.GetMethod(type, methodName, parameterType);
        }

        [TestMethod]
        public void StaticReflectionCache_GetMethod_OutParameter_NotCalling_MakeByRefType_ThrowsException()
        {
            Type type = typeof(ReflectionCacheTests_HelperClass);
            const string methodName = nameof(ReflectionCacheTests_HelperClass.Method_OutParameter);
            string expectedMessage = $"Method '{methodName}' not found.";
            Type parameterType = typeof(double);

            AssertHelper.ThrowsException(
                () => _reflectionCache.GetMethod(type, methodName, parameterType),
                expectedMessage);
        }
    }
}
