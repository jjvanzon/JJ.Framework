namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class ReflectionCache_Constructor_CoreTests
{
    [TestMethod]
    public void ReflectionCache_GetConstructor_PublicInstance_TestClass_NotThrows()
        => AssertGetConstructorNotThrows(typeof(TestClass), Public | Instance);

    [TestMethod]
    public void ReflectionCache_GetConstructor_BindingFlagsAll_TestClass_ThrowsMultiple()
        => AssertGetConstructorThrows(typeof(TestClass), BINDING_FLAGS_ALL, "Multiple constructors found");

    [TestMethod]
    public void ReflectionCache_GetConstructor_NonPublicInstance_TestClass_ThrowsNone()
        => AssertGetConstructorThrows(typeof(TestClass), NonPublic | Instance, "No constructor found");

    [TestMethod]
    public void ReflectionCache_GetConstructor_PublicInstance_SingleConstructorClass_NotThrows()
        => AssertGetConstructorNotThrows(typeof(SingleConstructorClass), Public | Instance);

    [TestMethod]
    public void ReflectionCache_GetConstructor_BindingFlagsAll_SingleConstructorClass_NotThrows()
        => AssertGetConstructorNotThrows(typeof(SingleConstructorClass), BINDING_FLAGS_ALL);

    [TestMethod]
    public void ReflectionCache_GetConstructor_NonPublicInstance_SingleConstructorClass_ThrowsNone()
        => AssertGetConstructorThrows(typeof(SingleConstructorClass), NonPublic | Instance, "No constructor found");

    [TestMethod]
    public void ReflectionCache_GetConstructor_PublicInstance_NoConstructorClass_ThrowsNone()
        => AssertGetConstructorThrows(typeof(NoConstructorClass), Public | Instance, "No constructor found");

    [TestMethod]
    public void ReflectionCache_GetConstructor_NonPublicInstance_NoConstructorClass_NotThrows()
        => AssertGetConstructorNotThrows(typeof(NoConstructorClass), NonPublic | Instance);

    [TestMethod]
    public void ReflectionCache_GetConstructor_PublicInstance_MultipleConstructorsClass_ThrowsMultiple()
        => AssertGetConstructorThrows(typeof(MultipleConstructorsClass), Public | Instance, "Multiple constructors found");

    [TestMethod]
    public void ReflectionCache_GetConstructor_BindingFlagsAll_MultipleConstructorsClass_ThrowsMultiple()
        => AssertGetConstructorThrows(typeof(MultipleConstructorsClass), BINDING_FLAGS_ALL, "Multiple constructors found");

    private static Func<ConstructorInfo>[] CreateGetConstructorFuncs([Dyn(AllConstructors)] Type type, BindingFlags flags)
    {
        var reflectionCache = new ReflectionCache(flags);
        var reflectionCacheLegacy = new ReflectionCacheLegacy(flags);

        if (flags == BINDING_FLAGS_ALL)
        {
            var reflectionCacheLegacyDefault = new ReflectionCacheLegacy();
            return
            [
                () => reflectionCache             .GetConstructor(type),
                () => reflectionCacheLegacy       .GetConstructor(type),
                () => reflectionCacheLegacyDefault.GetConstructor(type),
            ];
        }

        return
        [
            () => reflectionCache      .GetConstructor(type),
            () => reflectionCacheLegacy.GetConstructor(type),
        ];
    }

    private static void AssertGetConstructorNotThrows([Dyn(AllConstructors)] Type type, BindingFlags flags)
    {
        Func<ConstructorInfo>[] funcs = CreateGetConstructorFuncs(type, flags);

        foreach (var func in funcs)
        {
            for (int i = 0; i < Repeats; i++)
            {
                ConstructorInfo constructor = func();
                IsNotNull(() => constructor);
            }
        }
    }

    private static void AssertGetConstructorThrows([Dyn(AllConstructors)] Type type, BindingFlags flags, string expectedText)
    {
        Func<ConstructorInfo>[] funcs = CreateGetConstructorFuncs(type, flags);

        foreach (var func in funcs)
        {
            for (int i = 0; i < Repeats; i++)
            {
                ThrowsExceptionContaining(() => func(), expectedText);
            }
        }
    }
}