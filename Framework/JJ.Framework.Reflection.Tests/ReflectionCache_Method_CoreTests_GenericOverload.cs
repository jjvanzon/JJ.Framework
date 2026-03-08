namespace JJ.Framework.Reflection.Legacy.Tests;

//[Suppress("Trimmer", "IL2077", Justification = TypeLoaded)]
//[Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
//[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
[TestClass]
public class ReflectionCache_Method_CoreTests_GenericOverload
{
    // ncrunch: no coverage start
    private static class HelperClass
    {
        public static bool Method_WithTypeArgs_1<T>() => throw new NotSupportedException();
        public static bool Method_WithTypeArgs_2<T, U>() => throw new NotSupportedException();
        public static bool Method_WithTypeArgs_3<T1, T2, T3>() => throw new NotSupportedException();
        public static bool Method_WithTypeArgs_4<T1, T2, T3, T4>() => throw new NotSupportedException();
        public static bool Method_WithTypeArgs_5<T1, T2, T3, T4, T5>() => throw new NotSupportedException();
        public static bool Method_WithTypeArgs_6<T1, T2, T3, T4, T5, T6>() => throw new NotSupportedException();
        public static bool Method_WithTypeArgs_7<T1, T2, T3, T4, T5, T6, T7>() => throw new NotSupportedException();
    }
    // ncrunch: no coverage end

    private static readonly ReflectionCacheLegacy _reflectionCacheLegacy = new();

    [TestMethod]
    public void Test_ReflectionCache_GetMethod_GenericOverload()
    {
        Type type = typeof(HelperClass);
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_1);
            MethodInfo method1 = _reflectionCacheLegacy.GetMethod<long>(type, name);
            MethodInfo method2 = _reflectionCacheLegacy.GetMethod<long>(type, name);
            NotNull(method1);
            NotNull(method2);
            AreEqual(method1, method2);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_2);
            MethodInfo method3 = _reflectionCacheLegacy.GetMethod<long, float>(type, name);
            MethodInfo method4 = _reflectionCacheLegacy.GetMethod<long, float>(type, name);
            NotNull(method3);
            NotNull(method4);
            AreEqual(method3, method4);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_3);
            MethodInfo method5 = _reflectionCacheLegacy.GetMethod<long, float, short>(type, name);
            MethodInfo method6 = _reflectionCacheLegacy.GetMethod<long, float, short>(type, name);
            NotNull(method5);
            NotNull(method6);
            AreEqual(method5, method6);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_4);
            MethodInfo method7 = _reflectionCacheLegacy.GetMethod<long, float, short, byte>(type, name);
            MethodInfo method8 = _reflectionCacheLegacy.GetMethod<long, float, short, byte>(type, name);
            NotNull(method7);
            NotNull(method8);
            AreEqual(method7, method8);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_5);
            MethodInfo method9 = _reflectionCacheLegacy.GetMethod<long, float, short, byte, char>(type, name);
            MethodInfo method10 = _reflectionCacheLegacy.GetMethod<long, float, short, byte, char>(type, name);
            NotNull(method9);
            NotNull(method10);
            AreEqual(method9, method10);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_6);
            MethodInfo method11 = _reflectionCacheLegacy.GetMethod<long, float, short, byte, char, decimal>(type, name);
            MethodInfo method12 = _reflectionCacheLegacy.GetMethod<long, float, short, byte, char, decimal>(type, name);
            NotNull(method11);
            NotNull(method12);
            AreEqual(method11, method12);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_7);
            MethodInfo method13 = _reflectionCacheLegacy.GetMethod<long, float, short, byte, char, decimal, bool>(type, name);
            MethodInfo method14 = _reflectionCacheLegacy.GetMethod<long, float, short, byte, char, decimal, bool>(type, name);
            NotNull(method13);
            NotNull(method14);
            AreEqual(method13, method14);
        }
    }

    [TestMethod]
    public void Test_ReflectionCache_TryGetMethod_GenericOverload()
    {
        Type type = typeof(HelperClass);
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_1);
            MethodInfo? method1 = _reflectionCacheLegacy.TryGetMethod<long>(type, name);
            MethodInfo? method2 = _reflectionCacheLegacy.TryGetMethod<long>(type, name);
            NotNull(method1);
            NotNull(method2);
            AreEqual(method1, method2);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_2);
            MethodInfo? method3 = _reflectionCacheLegacy.TryGetMethod<long, float>(type, name);
            MethodInfo? method4 = _reflectionCacheLegacy.TryGetMethod<long, float>(type, name);
            NotNull(method3);
            NotNull(method4);
            AreEqual(method3, method4);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_3);
            MethodInfo? method5 = _reflectionCacheLegacy.TryGetMethod<long, float, short>(type, name);
            MethodInfo? method6 = _reflectionCacheLegacy.TryGetMethod<long, float, short>(type, name);
            NotNull(method5);
            NotNull(method6);
            AreEqual(method5, method6);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_4);
            MethodInfo? method7 = _reflectionCacheLegacy.TryGetMethod<long, float, short, byte>(type, name);
            MethodInfo? method8 = _reflectionCacheLegacy.TryGetMethod<long, float, short, byte>(type, name);
            NotNull(method7);
            NotNull(method8);
            AreEqual(method7, method8);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_5);
            MethodInfo? method9 = _reflectionCacheLegacy.TryGetMethod<long, float, short, byte, char>(type, name);
            MethodInfo? method10 = _reflectionCacheLegacy.TryGetMethod<long, float, short, byte, char>(type, name);
            NotNull(method9);
            NotNull(method10);
            AreEqual(method9, method10);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_6);
            MethodInfo? method11 = _reflectionCacheLegacy.TryGetMethod<long, float, short, byte, char, decimal>(type, name);
            MethodInfo? method12 = _reflectionCacheLegacy.TryGetMethod<long, float, short, byte, char, decimal>(type, name);
            NotNull(method11);
            NotNull(method12);
            AreEqual(method11, method12);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_7);
            MethodInfo? method13 = _reflectionCacheLegacy.TryGetMethod<long, float, short, byte, char, decimal, bool>(type, name);
            MethodInfo? method14 = _reflectionCacheLegacy.TryGetMethod<long, float, short, byte, char, decimal, bool>(type, name);
            NotNull(method13);
            NotNull(method14);
            AreEqual(method13, method14);
        }
    }
}
