namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class ReflectionCache_Constructor_CoreTests
{
    [TestMethod]
    public void ReflectionCache_GetConstructor_Single()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<ConstructorInfo>[] synonyms =
        [
            () => reflectionCache       .GetConstructor(typeof(TestClass)),
            () => reflectionCacheLegacy .GetConstructor(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetConstructor(typeof(TestClass)),
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
}