namespace JJ.Framework.Reflection.Legacy.Tests.ReflectionCacheLegacyTests;

//[Suppress("Trimmer", "IL2077", Justification = TypeLoaded)]
//[Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
//[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
[TestClass]
public class ReflectionCacheLegacy_GenericOverloads_CoreTests
{
    // Helper methods moved here so the tests are portable and self-contained.
    private static class HelperClass
    {
        public static bool Method_WithTypeArguments_NoParams_1<T>() => throw new NotSupportedException();
        public static bool Method_WithTypeArguments_NoParams_2<T, U>() => throw new NotSupportedException();
        public static bool Method_WithTypeArguments_NoParams_3<T1, T2, T3>() => throw new NotSupportedException();
        public static bool Method_WithTypeArguments_NoParams_4<T1, T2, T3, T4>() => throw new NotSupportedException();
        public static bool Method_WithTypeArguments_NoParams_5<T1, T2, T3, T4, T5>() => throw new NotSupportedException();
        public static bool Method_WithTypeArguments_NoParams_6<T1, T2, T3, T4, T5, T6>() => throw new NotSupportedException();
        public static bool Method_WithTypeArguments_NoParams_7<T1, T2, T3, T4, T5, T6, T7>() => throw new NotSupportedException();
    }

    private static readonly ReflectionCacheLegacy _reflectionCache = new ReflectionCacheLegacy();

    [TestMethod]
    public void Test_ReflectionCache_GetMethod_GenericOverload_NoParams_ReturnsSomething()
    {
        Type type = typeof(HelperClass);

        string methodName1 = nameof(HelperClass.Method_WithTypeArguments_NoParams_1);
        MethodInfo method1 = _reflectionCache.GetMethod<long>(type, methodName1);
        MethodInfo method2 = _reflectionCache.GetMethod<long>(type, methodName1);

        NotNull(method1);
        NotNull(method2);
        AreEqual(method1, method2);

        string methodName2 = nameof(HelperClass.Method_WithTypeArguments_NoParams_2);
        MethodInfo method3 = _reflectionCache.GetMethod<long, float>(type, methodName2);
        MethodInfo method4 = _reflectionCache.GetMethod<long, float>(type, methodName2);

        NotNull(method3);
        NotNull(method4);
        AreEqual(method3, method4);

        string methodName3 = nameof(HelperClass.Method_WithTypeArguments_NoParams_3);
        MethodInfo method5 = _reflectionCache.GetMethod<long, float, short>(type, methodName3);
        MethodInfo method6 = _reflectionCache.GetMethod<long, float, short>(type, methodName3);
        NotNull(method5);
        NotNull(method6);
        AreEqual(method5, method6);

        string methodName4 = nameof(HelperClass.Method_WithTypeArguments_NoParams_4);
        MethodInfo method7 = _reflectionCache.GetMethod<long, float, short, byte>(type, methodName4);
        MethodInfo method8 = _reflectionCache.GetMethod<long, float, short, byte>(type, methodName4);
        NotNull(method7);
        NotNull(method8);
        AreEqual(method7, method8);

        string methodName5 = nameof(HelperClass.Method_WithTypeArguments_NoParams_5);
        MethodInfo method9 = _reflectionCache.GetMethod<long, float, short, byte, char>(type, methodName5);
        MethodInfo method10 = _reflectionCache.GetMethod<long, float, short, byte, char>(type, methodName5);
        NotNull(method9);
        NotNull(method10);
        AreEqual(method9, method10);

        string methodName6 = nameof(HelperClass.Method_WithTypeArguments_NoParams_6);
        MethodInfo method11 = _reflectionCache.GetMethod<long, float, short, byte, char, decimal>(type, methodName6);
        MethodInfo method12 = _reflectionCache.GetMethod<long, float, short, byte, char, decimal>(type, methodName6);
        NotNull(method11);
        NotNull(method12);
        AreEqual(method11, method12);

        string methodName7 = nameof(HelperClass.Method_WithTypeArguments_NoParams_7);
        MethodInfo method13 = _reflectionCache.GetMethod<long, float, short, byte, char, decimal, bool>(type, methodName7);
        MethodInfo method14 = _reflectionCache.GetMethod<long, float, short, byte, char, decimal, bool>(type, methodName7);
        NotNull(method13);
        NotNull(method14);
        AreEqual(method13, method14);
    }

    [TestMethod]
    public void Test_ReflectionCache_TryGetMethod_GenericOverload_NoParams_ReturnsSomething()
    {
        Type type = typeof(HelperClass);

        string methodName1 = nameof(HelperClass.Method_WithTypeArguments_NoParams_1);
        MethodInfo? method1 = _reflectionCache.TryGetMethod<long>(type, methodName1);
        MethodInfo? method2 = _reflectionCache.TryGetMethod<long>(type, methodName1);

        NotNull(method1);
        NotNull(method2);
        AreEqual(method1, method2);

        string methodName2 = nameof(HelperClass.Method_WithTypeArguments_NoParams_2);
        MethodInfo? method3 = _reflectionCache.TryGetMethod<long, float>(type, methodName2);
        MethodInfo? method4 = _reflectionCache.TryGetMethod<long, float>(type, methodName2);

        NotNull(method3);
        NotNull(method4);
        AreEqual(method3, method4);

        string methodName3 = nameof(HelperClass.Method_WithTypeArguments_NoParams_3);
        MethodInfo? method5 = _reflectionCache.TryGetMethod<long, float, short>(type, methodName3);
        MethodInfo? method6 = _reflectionCache.TryGetMethod<long, float, short>(type, methodName3);
        NotNull(method5);
        NotNull(method6);
        AreEqual(method5, method6);

        string methodName4 = nameof(HelperClass.Method_WithTypeArguments_NoParams_4);
        MethodInfo? method7 = _reflectionCache.TryGetMethod<long, float, short, byte>(type, methodName4);
        MethodInfo? method8 = _reflectionCache.TryGetMethod<long, float, short, byte>(type, methodName4);
        NotNull(method7);
        NotNull(method8);
        AreEqual(method7, method8);

        string methodName5 = nameof(HelperClass.Method_WithTypeArguments_NoParams_5);
        MethodInfo? method9 = _reflectionCache.TryGetMethod<long, float, short, byte, char>(type, methodName5);
        MethodInfo? method10 = _reflectionCache.TryGetMethod<long, float, short, byte, char>(type, methodName5);
        NotNull(method9);
        NotNull(method10);
        AreEqual(method9, method10);

        string methodName6 = nameof(HelperClass.Method_WithTypeArguments_NoParams_6);
        MethodInfo? method11 = _reflectionCache.TryGetMethod<long, float, short, byte, char, decimal>(type, methodName6);
        MethodInfo? method12 = _reflectionCache.TryGetMethod<long, float, short, byte, char, decimal>(type, methodName6);
        NotNull(method11);
        NotNull(method12);
        AreEqual(method11, method12);

        string methodName7 = nameof(HelperClass.Method_WithTypeArguments_NoParams_7);
        MethodInfo? method13 = _reflectionCache.TryGetMethod<long, float, short, byte, char, decimal, bool>(type, methodName7);
        MethodInfo? method14 = _reflectionCache.TryGetMethod<long, float, short, byte, char, decimal, bool>(type, methodName7);
        NotNull(method13);
        NotNull(method14);
        AreEqual(method13, method14);
    }
}
