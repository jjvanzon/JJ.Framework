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
        public void Bug_StaticReflectionCache_GetMethod_OutParameter_ThrowsException_MethodNotFound()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OutParameter);
            string expectedMessage = $"Method '{methodName}' not found.";
            Type parameterType = typeof(double);

            AssertHelper.ThrowsException(
                () => StaticReflectionCache.GetMethod(type, methodName, parameterType),
                expectedMessage);
        }

        [TestMethod]
        public void Bug_StaticReflectionCache_GetMethod_NonRefParameter_Succeeds()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_NonRefParameter);
            Type parameterType = typeof(int);

            StaticReflectionCache.GetMethod(type, methodName, parameterType);
        }

        [TestMethod]
        public void Bug_Type_GetMethod_OutParameter_WithCalling_MakeByRefType_ReturnsNotNull()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OutParameter);
            Type parameterType = typeof(double).MakeByRefType();

            MethodInfo method =
                type.GetMethod(methodName, ReflectionHelper.BINDING_FLAGS_ALL, null, new[] { parameterType }, null);

            AssertHelper.IsNotNull(() => method);
        }

        [TestMethod]
        public void Bug_Type_GetMethod_OutParameter_WithoutCalling_MakeByRefType_ReturnsNull()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_OutParameter);
            Type parameterType = typeof(double);

            MethodInfo method =
                type.GetMethod(methodName, ReflectionHelper.BINDING_FLAGS_ALL, null, new[] { parameterType }, null);

            AssertHelper.IsNull(() => method);
        }

        [TestMethod]
        public void Bug_Type_GetMethod_NonRefParameter_ReturnsNotNull()
        {
            Type type = typeof(StaticReflectionCacheTests_BugMethodNotFound);
            const string methodName = nameof(StaticReflectionCacheTests_BugMethodNotFound.Method_NonRefParameter);
            Type parameterType = typeof(int);

            MethodInfo method = 
                type.GetMethod(methodName, ReflectionHelper.BINDING_FLAGS_ALL, null, new[] { parameterType }, null);

            AssertHelper.IsNotNull(() => method);
        }
    }
}
