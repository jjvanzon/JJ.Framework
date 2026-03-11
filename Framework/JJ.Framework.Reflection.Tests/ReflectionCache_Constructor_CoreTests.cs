namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class ReflectionCache_Constructor_CoreTests
{
    [TestMethod]
    public void ReflectionCache_GetConstructor_SinglePublicInstance()
    {
        // Use explicit flags to select the instance constructor only.
        var reflectionCache = new ReflectionCache(Public | Instance);
        var reflectionCacheLegacy = new ReflectionCacheLegacy(Public | Instance);
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(Public | Instance);

        Func<ConstructorInfo>[] synonyms =
        [
            () => reflectionCache       .GetConstructor(typeof(TestClass)),
            () => reflectionCacheLegacy .GetConstructor(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetConstructor(typeof(TestClass)),
            () => reflectionCache       .GetConstructor(typeof(SingleConstructorClass)),
            () => reflectionCacheLegacy .GetConstructor(typeof(SingleConstructorClass)),
            () => reflectionCacheLegacy2.GetConstructor(typeof(SingleConstructorClass)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                ConstructorInfo constructor = func();
                IsNotNull(() => constructor);
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetConstructor_AllFlags_MultipleConstructors_Throws()
    {
        // When using all flags, the type initializer (static constructor) is visible and
        // the cache may find multiple constructors. Ensure that the appropriate exception is thrown.
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => reflectionCache       .GetConstructor(typeof(TestClass)),
            () => reflectionCacheLegacy .GetConstructor(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetConstructor(typeof(TestClass)),
        ];

        foreach (var action in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                ThrowsExceptionContaining(action, "Multiple constructors found");
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetConstructor_None_Throws()
    {
        // NOTE: Specific BindingFlags or it'l always finds the default constructor.
        var reflectionCache = new ReflectionCache(Public | Instance);
        var reflectionCacheLegacy = new ReflectionCacheLegacy(Public | Instance);

        Action[] synonyms =
        [
            () => reflectionCache       .GetConstructor(typeof(NoConstructorClass)),
            () => reflectionCacheLegacy .GetConstructor(typeof(NoConstructorClass)),
        ];

        foreach (var action in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                ThrowsExceptionContaining(action, "No constructor found");
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetConstructor_Multiple_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => reflectionCache       .GetConstructor(typeof(MultipleConstructorsClass)),
            () => reflectionCacheLegacy .GetConstructor(typeof(MultipleConstructorsClass)),
            () => reflectionCacheLegacy2.GetConstructor(typeof(MultipleConstructorsClass)),
        ];

        foreach (var action in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                ThrowsExceptionContaining(action, "Multiple constructors found");
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetConstructor_DifferentFlags()
    {
        // Public|Instance: finds the one public instance constructor
        var publicInstance = new ReflectionCacheLegacy(Public    | Instance);
        IsNotNull(() => publicInstance.GetConstructor(typeof(SingleConstructorClass)));

        // BINDING_FLAGS_ALL: still finds only one — SingleConstructorClass has no static constructor
        var allFlags = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        IsNotNull(() => allFlags.GetConstructor(typeof(SingleConstructorClass)));

        // NonPublic|Instance: no non-public constructor on SingleConstructorClass → throws
        ThrowsExceptionContaining(
            () => new ReflectionCacheLegacy(NonPublic | Instance).GetConstructor(typeof(SingleConstructorClass)),
            "No constructor found");

        // NonPublic|Instance: finds the private constructor on NoConstructorClass
        var nonPublicInstance = new ReflectionCacheLegacy(NonPublic | Instance);
        IsNotNull(() => nonPublicInstance.GetConstructor(typeof(NoConstructorClass)));
    }
}