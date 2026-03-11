using System;
using System.Linq;
using System.Reflection;
using JJ.Framework.Collections;
using JJ.Framework.Collections.Core;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Reflection.Legacy.Tests.ReflectionCacheLegacyTests
{
    [Suppress("Trimmer", "IL2077", Justification = TypeLoaded)]
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

            NotNull(method1);
            NotNull(method2);
            AreEqual(method1, method2);
        }

        [TestMethod]
        public void Test_ReflectionCache_GetMethod_OutParameter_Calling_MakeByRefType_Succeeds()
        {
            Type type = typeof(ReflectionCacheLegacyTests_HelperClass);
            string methodName = nameof(ReflectionCacheLegacyTests_HelperClass.Method_OutParameter);
            Type parameterType = typeof(double).MakeByRefType();

            MethodInfo method1 = _reflectionCache.GetMethod(type, methodName, parameterType);
            MethodInfo method2 = _reflectionCache.GetMethod(type, methodName, parameterType);

            NotNull(method1);
            NotNull(method2);
            AreEqual(method1, method2);
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

        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_ReturnsSomething()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            MethodInfo method1 = _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo method2 = _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments);

            NotNull(method1);
            NotNull(method2);
            AreEqual(method1, method2);
        }

        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_TryGetMethod_WithTypeArguments_ReturnsSomething()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            MethodInfo? method1 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo? method2 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);

            NotNull(method1);
            NotNull(method2);
            AreEqual(method1, method2);
        }

        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_ThrowsException_BecauseWrongName()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            methodName = "WrongName";

            string expectedMessage = FormatExpectedMessage_ForGetMethod_WithTypeArguments(type, methodName, parameterTypes, typeArguments);

            ThrowsException(
                () => _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments),
                expectedMessage);
        }

        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_TryGetMethod_WithTypeArguments_ReturnsNull_BecauseWrongName()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            methodName = "WrongName";

            MethodInfo? method1 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo? method2 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);

            IsNull(method1);
            IsNull(method2);
        }

        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_ThrowsException_BecauseWrongParameterTypes()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            parameterTypes[0] = typeof(Guid);

            string expectedMessage = FormatExpectedMessage_ForGetMethod_WithTypeArguments(type, methodName, parameterTypes, typeArguments);

            ThrowsException(
                () => _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments),
                expectedMessage);
        }

        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_TryGetMethod_WithTypeArguments_ReturnsNull_BecauseWrongParameterTypes()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            parameterTypes[0] = typeof(Guid);

            MethodInfo? method1 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo? method2 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);

            IsNull(method1);
            IsNull(method2);
        }

        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_ThrowsException_BecauseWrongNumberOfTypeArguments()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            typeArguments = typeArguments.Concat(typeof(Guid)).ToArray();

            string expectedMessage = FormatExpectedMessage_ForGetMethod_WithTypeArguments(type, methodName, parameterTypes, typeArguments);

            ThrowsException(
                () => _reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments),
                expectedMessage);
        }

        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_TryGetMethod_WithTypeArguments_ReturnsNull_BecauseWrongNumberOfTypeArguments()
        {
            (Type type, string methodName, Type[] parameterTypes, Type[] typeArguments) =
                GetTestParameters_ForGetMethod_WithTypeArguments();

            typeArguments = typeArguments.Concat(typeof(Guid)).ToArray();

            MethodInfo? method1 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);
            MethodInfo? method2 = _reflectionCache.TryGetMethod(type, methodName, parameterTypes, typeArguments);

            IsNull(method1);
            IsNull(method2);
        }
        
        [Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
        [Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
        [TestMethod]
        public void Test_ReflectionCache_GetMethod_WithTypeArguments_MultipleMatches_Throws()
        {
            var reflectionCache = new ReflectionCacheLegacy();

            Type type = typeof(AmbiguousHelper);
            string methodName = nameof(AmbiguousHelper.AmbiguousMethod);
            Type[] parameterTypes = { typeof(int) };
            Type[] typeArguments = { typeof(long) };

            ThrowsExceptionContaining(
                () => reflectionCache.GetMethod(type, methodName, parameterTypes, typeArguments),
                "multiple methods");
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

            // Preserve after Code Trimming
            var func = ReflectionCacheLegacyTests_HelperClass.Method_WithTypeArguments<long, float>;
             
            return (type, methodName, parameterTypes, typeArguments);
        }

        private string FormatExpectedMessage_ForGetMethod_WithTypeArguments(Type type, string name, Type[] parameterTypes, Type[] typeArguments)
            => $"Method '{name}' with {typeArguments.Length} type arguments not found " +
               $"with parameters ({Join(", ", parameterTypes.Select(x => $"{x.Name}"))}) " +
               $"in type '{type}'.";

        // ncrunch: no coverage start
        
        /// <summary>
        /// Helper for multiple generic methods with same parameter types but different arity
        /// to trigger the "multiple methods" error in TryResolveGenericMethod.
        /// </summary>
        private static class AmbiguousHelper
        {
            public static void AmbiguousMethod<T>(int a) { }
            public static void AmbiguousMethod<T, U>(int a) { }
        }

        // ncrunch: no coverage end
    }
}
