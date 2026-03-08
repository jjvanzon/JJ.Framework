namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = GetTypes)]
[TestClass]
public class ReflectionCache_Type_CoreTests
{
    // GetTypeByShortName
    
    [TestMethod]
    public void ReflectionCache_GetTypeByShortName_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<Type>[] synonyms =
        [
            () => reflectionCache       .GetTypeByShortName("ReflectionCache_Type_CoreTests"),
            () => reflectionCacheLegacy .GetTypeByShortName("ReflectionCache_Type_CoreTests"),
            () => reflectionCacheLegacy2.GetTypeByShortName("ReflectionCache_Type_CoreTests"),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                Type type = func();
                IsNotNull(() => type);
                AreEqual(typeof(ReflectionCache_Type_CoreTests), () => type);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetTypeByShortName_NotFound_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => reflectionCache       .GetTypeByShortName(NonExistentName),
            () => reflectionCacheLegacy .GetTypeByShortName(NonExistentName),
            () => reflectionCacheLegacy2.GetTypeByShortName(NonExistentName),
        ];

        foreach (var action in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                ThrowsExceptionContaining(action, "Type with short name", "not found");
            }
        }
    }
        
    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<Type>[] synonyms =
        [
            () => reflectionCache       .TryGetTypeByShortName("ReflectionCache_Type_CoreTests"),
            () => reflectionCacheLegacy .TryGetTypeByShortName("ReflectionCache_Type_CoreTests"),
            () => reflectionCacheLegacy2.TryGetTypeByShortName("ReflectionCache_Type_CoreTests"),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                Type type = func();
                IsNotNull(() => type);
                AreEqual(typeof(ReflectionCache_Type_CoreTests), () => type);
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_NotFound_ReturnsNull()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<Type>[] synonyms =
        [
            () => reflectionCache       .TryGetTypeByShortName(NonExistentName),
            () => reflectionCacheLegacy .TryGetTypeByShortName(NonExistentName),
            () => reflectionCacheLegacy2.TryGetTypeByShortName(NonExistentName),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                Type type = func();
                IsNull(() => type);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_Multiple_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => reflectionCache       .GetTypeByShortName("DuplicateClass_13017ef1"),
            () => reflectionCacheLegacy .GetTypeByShortName("DuplicateClass_13017ef1"),
            () => reflectionCacheLegacy2.GetTypeByShortName("DuplicateClass_13017ef1"),
        ];

        foreach (var action in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                ThrowsExceptionContaining(action, "Type with short name", "multiple");
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_None()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<IList<Type>>[] synonyms =
        [
            () => reflectionCache       .GetTypesByShortName(NonExistentName),
            () => reflectionCacheLegacy .GetTypesByShortName(NonExistentName),
            () => reflectionCacheLegacy2.GetTypesByShortName(NonExistentName),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                IList<Type> types = func();

                IsNotNull(() => types);
                AreEqual(0, () => types.Count);
            }
        }
    }
        
    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_Single()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<IList<Type>>[] synonyms =
        [
            () => reflectionCache       .GetTypesByShortName("ReflectionCache_Type_CoreTests"),
            () => reflectionCacheLegacy .GetTypesByShortName("ReflectionCache_Type_CoreTests"),
            () => reflectionCacheLegacy2.GetTypesByShortName("ReflectionCache_Type_CoreTests"),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                IList<Type> types = func();

                IsNotNull(  () => types);
                AreEqual(1, () => types.Count);
                IsNotNull(  () => types[0]);
                AreEqual(typeof(ReflectionCache_Type_CoreTests), () => types[0]);
            }
        }
    }
        
    
    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_Multiple()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<IList<Type>>[] synonyms =
        [
            () => reflectionCache       .GetTypesByShortName("DuplicateClass_13017ef1"),
            () => reflectionCacheLegacy .GetTypesByShortName("DuplicateClass_13017ef1"),
            () => reflectionCacheLegacy2.GetTypesByShortName("DuplicateClass_13017ef1"),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                IList<Type> types = func();

                IsNotNull(() => types);
                AreEqual(2, () => types.Count);
                IsNotNull(() => types[0]);
                IsNotNull(() => types[1]);
                NotEqual(types[0], () => types[1]);
                IsTrue(types.Any(x => x == typeof(CoreTestHelpers.Namespace1.DuplicateClass_13017ef1)));
                IsTrue(types.Any(x => x == typeof(CoreTestHelpers.Namespace2.DuplicateClass_13017ef1)));
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_NullOrWhiteSpace_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => reflectionCache       .GetTypesByShortName(null),
            () => reflectionCacheLegacy .GetTypesByShortName(null),
            () => reflectionCacheLegacy2.GetTypesByShortName(null),
            () => reflectionCache       .GetTypesByShortName("\t\n"),
            () => reflectionCacheLegacy .GetTypesByShortName("\t\n"),
            () => reflectionCacheLegacy2.GetTypesByShortName("\t\n"),
        ];

        foreach (var action in synonyms)
        {
            ThrowsExceptionContaining(action, "null");
        }
    }
}