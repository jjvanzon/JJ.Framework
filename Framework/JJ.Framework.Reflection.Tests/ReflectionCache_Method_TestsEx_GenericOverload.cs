namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
[TestClass]
public class ReflectionCache_Method_TestsEx_GenericOverload
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

    /// <summary>
    /// Statically reference all the closed generic methods we're getting with reflection for the linker to pass.
    /// </summary>
    internal static void Untrim()
    {
        var func1 = HelperClass.Method_WithTypeArgs_1<long>;
        var func2 = HelperClass.Method_WithTypeArgs_2<long, float>;
        var func3 = HelperClass.Method_WithTypeArgs_3<long, float, short>;
        var func4 = HelperClass.Method_WithTypeArgs_4<long, float, short, byte>;
        var func5 = HelperClass.Method_WithTypeArgs_5<long, float, short, byte, char>;
        var func6 = HelperClass.Method_WithTypeArgs_6<long, float, short, byte, char, decimal>;
        var func7 = HelperClass.Method_WithTypeArgs_7<long, float, short, byte, char, decimal, bool>;
    }
    
    // ncrunch: no coverage end

    private static readonly ReflectionCacheEx _reflectionCacheEx = new();

    [TestMethod]
    public void Test_ReflectionCache_GetMethod_GenericOverload()
    {
        Type type = typeof(HelperClass);
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_1);
            MethodInfo method1 = _reflectionCacheEx.GetMethod<long>(type, name);
            MethodInfo method2 = _reflectionCacheEx.GetMethod<long>(type, name);
            NotNull(method1);
            NotNull(method2);
            AreEqual(method1, method2);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_2);
            MethodInfo method3 = _reflectionCacheEx.GetMethod<long, float>(type, name);
            MethodInfo method4 = _reflectionCacheEx.GetMethod<long, float>(type, name);
            NotNull(method3);
            NotNull(method4);
            AreEqual(method3, method4);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_3);
            MethodInfo method5 = _reflectionCacheEx.GetMethod<long, float, short>(type, name);
            MethodInfo method6 = _reflectionCacheEx.GetMethod<long, float, short>(type, name);
            NotNull(method5);
            NotNull(method6);
            AreEqual(method5, method6);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_4);
            MethodInfo method7 = _reflectionCacheEx.GetMethod<long, float, short, byte>(type, name);
            MethodInfo method8 = _reflectionCacheEx.GetMethod<long, float, short, byte>(type, name);
            NotNull(method7);
            NotNull(method8);
            AreEqual(method7, method8);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_5);
            MethodInfo method9 = _reflectionCacheEx.GetMethod<long, float, short, byte, char>(type, name);
            MethodInfo method10 = _reflectionCacheEx.GetMethod<long, float, short, byte, char>(type, name);
            NotNull(method9);
            NotNull(method10);
            AreEqual(method9, method10);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_6);
            MethodInfo method11 = _reflectionCacheEx.GetMethod<long, float, short, byte, char, decimal>(type, name);
            MethodInfo method12 = _reflectionCacheEx.GetMethod<long, float, short, byte, char, decimal>(type, name);
            NotNull(method11);
            NotNull(method12);
            AreEqual(method11, method12);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_7);
            MethodInfo method13 = _reflectionCacheEx.GetMethod<long, float, short, byte, char, decimal, bool>(type, name);
            MethodInfo method14 = _reflectionCacheEx.GetMethod<long, float, short, byte, char, decimal, bool>(type, name);
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
            MethodInfo? method1 = _reflectionCacheEx.TryGetMethod<long>(type, name);
            MethodInfo? method2 = _reflectionCacheEx.TryGetMethod<long>(type, name);
            NotNull(method1);
            NotNull(method2);
            AreEqual(method1, method2);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_2);
            MethodInfo? method3 = _reflectionCacheEx.TryGetMethod<long, float>(type, name);
            MethodInfo? method4 = _reflectionCacheEx.TryGetMethod<long, float>(type, name);
            NotNull(method3);
            NotNull(method4);
            AreEqual(method3, method4);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_3);
            MethodInfo? method5 = _reflectionCacheEx.TryGetMethod<long, float, short>(type, name);
            MethodInfo? method6 = _reflectionCacheEx.TryGetMethod<long, float, short>(type, name);
            NotNull(method5);
            NotNull(method6);
            AreEqual(method5, method6);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_4);
            MethodInfo? method7 = _reflectionCacheEx.TryGetMethod<long, float, short, byte>(type, name);
            MethodInfo? method8 = _reflectionCacheEx.TryGetMethod<long, float, short, byte>(type, name);
            NotNull(method7);
            NotNull(method8);
            AreEqual(method7, method8);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_5);
            MethodInfo? method9 = _reflectionCacheEx.TryGetMethod<long, float, short, byte, char>(type, name);
            MethodInfo? method10 = _reflectionCacheEx.TryGetMethod<long, float, short, byte, char>(type, name);
            NotNull(method9);
            NotNull(method10);
            AreEqual(method9, method10);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_6);
            MethodInfo? method11 = _reflectionCacheEx.TryGetMethod<long, float, short, byte, char, decimal>(type, name);
            MethodInfo? method12 = _reflectionCacheEx.TryGetMethod<long, float, short, byte, char, decimal>(type, name);
            NotNull(method11);
            NotNull(method12);
            AreEqual(method11, method12);
        }
        {
            string name = nameof(HelperClass.Method_WithTypeArgs_7);
            MethodInfo? method13 = _reflectionCacheEx.TryGetMethod<long, float, short, byte, char, decimal, bool>(type, name);
            MethodInfo? method14 = _reflectionCacheEx.TryGetMethod<long, float, short, byte, char, decimal, bool>(type, name);
            NotNull(method13);
            NotNull(method14);
            AreEqual(method13, method14);
        }
    }
}
