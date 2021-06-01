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
            Type parameterType = typeof(double);

            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod(type, methodName, parameterType),
                expectedMessage);
        }

        [TestMethod]
        public void Bug_StaticReflectionCache_GetMethod_OneParameter_NotOut_Succeeds()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneParameter_NotOut);
            Type parameterType = typeof(int);

            StaticReflectionCache.GetMethod(type, methodName, parameterType);
        }
        
        [TestMethod]
        public void Bug_Type_GetMethod_OneOutParameter_ReturnsNull()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneOutParameter);
            Type parameterType = typeof(double);

            MethodInfo method = 
                type.GetMethod(methodName, ReflectionHelper.BINDING_FLAGS_ALL, null, new[] { parameterType }, null);

            AssertHelper.IsNull(() => method);
        }

        [TestMethod]
        public void Bug_Type_GetMethod_OneParameter_NotOut_ReturnsNotNull()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OneParameter_NotOut);
            Type parameterType = typeof(int);

            MethodInfo method = 
                type.GetMethod(methodName, ReflectionHelper.BINDING_FLAGS_ALL, null, new[] { parameterType }, null);

            AssertHelper.IsNotNull(() => method);
        }
    }
}
