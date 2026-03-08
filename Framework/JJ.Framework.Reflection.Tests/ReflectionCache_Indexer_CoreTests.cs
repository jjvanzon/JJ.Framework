namespace JJ.Framework.Reflection.Legacy.Tests;

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
public class ReflectionCache_Indexer_CoreTests
{
    [TestMethod]
    public void ReflectionCache_GetIndexer_Test_1Arg()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy2.GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
            () => StaticReflectionCache .GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy .TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy2.TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
            () => StaticReflectionCache .TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo indexer = func();
                AssertIndexer1(indexer);
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetIndexer_Test_2Arg()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);


        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => StaticReflectionCache .GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy .TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => StaticReflectionCache .TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo indexer2 = func();
                AssertIndexer2(indexer2);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetIndexer_NotFound_Throws()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetIndexer(typeof(ClassWithoutIndexer), typeof(int)),
            () => reflectionCacheLegacy .GetIndexer(typeof(ClassWithoutIndexer), typeof(int)),
            () => reflectionCacheLegacy2.GetIndexer(typeof(ClassWithoutIndexer), typeof(int)),
        ];

        foreach (var action in synonyms)
        {
            ThrowsExceptionContaining(action, "Indexer not found");
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetIndexer_NotFound_ReturnsNull()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetIndexer(typeof(ClassWithoutIndexer), typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.TryGetIndexer(typeof(ClassWithoutIndexer), typeof(int), typeof(string)),
            () => StaticReflectionCache .TryGetIndexer(typeof(ClassWithoutIndexer), typeof(int), typeof(string)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo indexer = func();
                IsNull(() => indexer);
            }
        }
    }

    private void AssertIndexer1(PropertyInfo indexer)
    {
        IsNotNull(() => indexer);
        AreEqual(typeof(int), () => indexer.PropertyType);
        
        ParameterInfo[] parameters = indexer.GetIndexParameters();
        IsNotNull(() => parameters);
        AreEqual(1, () => parameters.Length);
        IsNotNull(() => parameters[0]);
        AreEqual(typeof(int), () => parameters[0].ParameterType);
    }
    
    private void AssertIndexer2(PropertyInfo indexer)
    {
        IsNotNull(() => indexer);
        AreEqual(typeof(int), () => indexer.PropertyType);
        
        ParameterInfo[] parameters = indexer.GetIndexParameters();
        IsNotNull(() => parameters);
        AreEqual(2, () => parameters.Length);
        IsNotNull(() => parameters[0]);
        IsNotNull(() => parameters[1]);
        AreEqual(typeof(int),    () => parameters[0].ParameterType);
        AreEqual(typeof(string), () => parameters[1].ParameterType);
    }
    
    // Constructor Tests
    
}