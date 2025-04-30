using System;
using System.Linq;
using System.Reflection;
using JJ.Framework.Collections;
using JJ.Framework.Collections.Core;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Reflection.Core.Tests.ReflectionCacheLegacyTests
{
    [TestClass]
    public class ReflectionCacheLegacyTests
    {
        private static readonly ReflectionCacheLegacy _reflectionCache = new ReflectionCacheLegacy();

        // NOTE: Executing a member twice to debug caching flow.

        [TestMethod]
        public void Test_ReflectionCache_GetMethod_NonRefParameter_Succeeds()
        {
            Type type = typeof(ReflectionCacheLegacyTests_HelperClass);
            string methodName = nameof(ReflectionCacheLegacyTests_HelperClass.Method_NonRefParameter);
            Type parameterType = typeof(int);

            MethodInfo method1 = _reflectionCache.GetMethod(type, methodName, parameterType);
            MethodInfo method2 = _reflectionCache.GetMethod(type, methodName, parameterType);

            AssertHelper.IsNotNull(() => method1);
            AssertHelper.IsNotNull(() => method2);
            AssertHelper.AreEqual(method1, () => method2);
        }

        [TestMethod]
        public void Test_ReflectionCache_GetMethod_OutParameter_Calling_MakeByRefType_Succeeds()
        {
            Type type = typeof(ReflectionCacheLegacyTests_HelperClass);
            string methodName = nameof(ReflectionCacheLegacyTests_HelperClass.Method_OutParameter);
            Type parameterType = typeof(double).MakeByRefType();

            MethodInfo method1 = _reflectionCache.GetMethod(type, methodName, parameterType);
            MethodInfo method2 = _reflectionCache.GetMethod(type, methodName, parameterType);

            AssertHelper.IsNotNull(() => method1);
            AssertHelper.IsNotNull(() => method2);
            AssertHelper.AreEqual(method1, () => method2);
        }

        [TestMethod]
        public void Test_ReflectionCache_GetMethod_OutParameter_NotCalling_MakeByRefType_ThrowsException()
        {
            Type type = typeof(ReflectionCacheLegacyTests_HelperClass);
            string methodName = nameof(ReflectionCacheLegacyTests_HelperClass.Method_OutParameter);
            string expectedMessage = $"Method '{methodName}' not found.";
            Type parameterType = typeof(double);

            AssertHelper.ThrowsException(
                () => _reflectionCache.GetMethod(type, methodName, parameterType),
                expectedMessage);
        }

        // GetMethod (With Type Arguments)

        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_ReturnsSomething()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            MethodInfo method1 = _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo method2 = _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments);

            AssertHelper.IsNotNull(() => method1);
            AssertHelper.IsNotNull(() => method2);
            AssertHelper.AreEqual(method1, () => method2);
        }

        [TestMethod]
        public void Test_ReflectionCache_TryGetMethod_WithTypeArguments_ReturnsSomething()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            MethodInfo method1 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo method2 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);

            AssertHelper.IsNotNull(() => method1);
            AssertHelper.IsNotNull(() => method2);
            AssertHelper.AreEqual(method1, () => method2);
        }

        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_ThrowsException_BecauseWrongName()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            methodName = "WrongName";

            string expectedMessage = FormatExpectedMessage_ForGetMethod_WithTypeArguments(type, methodName, parameterTypes, typeArguments);

            AssertHelper.ThrowsException(
                () => _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments),
                expectedMessage);
        }

        [TestMethod]
        public void Test_ReflectionCache_TryGetMethod_WithTypeArguments_ReturnsNull_BecauseWrongName()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            methodName = "WrongName";

            MethodInfo method1 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo method2 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);

            AssertHelper.IsNull(() => method1);
            AssertHelper.IsNull(() => method2);
        }

        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_ThrowsException_BecauseWrongParameterTypes()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            parameterTypes[0] = typeof(Guid);

            string expectedMessage = FormatExpectedMessage_ForGetMethod_WithTypeArguments(type, methodName, parameterTypes, typeArguments);

            AssertHelper.ThrowsException(
                () => _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments),
                expectedMessage);
        }

        [TestMethod]
        public void Test_ReflectionCache_TryGetMethod_WithTypeArguments_ReturnsNull_BecauseWrongParameterTypes()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            parameterTypes[0] = typeof(Guid);

            MethodInfo method1 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo method2 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);

            AssertHelper.IsNull(() => method1);
            AssertHelper.IsNull(() => method2);
        }

        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_ThrowsException_BecauseWrongNumberOfTypeArguments()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            typeArguments = typeArguments.Concat(typeof(Guid)).ToArray();

            string expectedMessage = FormatExpectedMessage_ForGetMethod_WithTypeArguments(type, methodName, parameterTypes, typeArguments);

            AssertHelper.ThrowsException(
                () => _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments),
                expectedMessage);
        }

        [TestMethod]
        public void Test_ReflectionCache_TryGetMethod_WithTypeArguments_ReturnsNull_BecauseWrongNumberOfTypeArguments()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            typeArguments = typeArguments.Concat(typeof(Guid)).ToArray();

            MethodInfo method1 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo method2 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);

            AssertHelper.IsNull(() => method1);
            AssertHelper.IsNull(() => method2);
        }

        // Helpers

        private
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments)
            GetTestParameters_ForGetMethod_WithTypeArguments()
        {
            Type type = typeof(ReflectionCacheLegacyTests_HelperClass);
            string methodName = nameof(ReflectionCacheLegacyTests_HelperClass.Method_WithTypeArguments);
            Type[] parameterTypes = { typeof(int), typeof(double) };
            Type[] typeArguments = { typeof(long), typeof(float) };

            return (type, methodName, parameterTypes, typeArguments);
        }

        private string FormatExpectedMessage_ForGetMethod_WithTypeArguments(Type type, string name, Type[] parameterTypes, Type[] typeArguments)
            => $"Method '{name}' with {typeArguments.Length} type arguments not found " +
               $"with parameters ({string.Join(", ", parameterTypes.Select(x => $"{x.Name}"))}) " +
               $"in type '{type}'.";

    }
}
