namespace JJ.Framework.Reflection.Legacy.Tests;

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
public class ReflectionCache_Type_CoreTests
{
    // GetTypeByShortName
    
    [TestMethod]
    public void ReflectionCache_GetTypeByShortName_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            Type type = reflectionCache.GetTypeByShortName("ReflectionCache_Type_CoreTests");
            IsNotNull(() => type);
            AreEqual(typeof(ReflectionCache_Type_CoreTests), () => type);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetTypeByShortName_NotFound_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetTypeByShortName(ReflectionCacheTestHelper.NonExistentName),
                "Type with short name", "not found");
        }
    }
        
    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            Type type = reflectionCache.TryGetTypeByShortName("ReflectionCache_Type_CoreTests");
            IsNotNull(() => type);
            AreEqual(typeof(ReflectionCache_Type_CoreTests), () => type);
        }
    }

    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_NotFound_ReturnsNull()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            Type type = reflectionCache.TryGetTypeByShortName(ReflectionCacheTestHelper.NonExistentName);
            IsNull(() => type);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_Multiple_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetTypeByShortName("DuplicateClass_13017ef1"),
                "Type with short name", "multiple");
        }
    }

    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_None()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            IList<Type> types = reflectionCache.GetTypesByShortName(ReflectionCacheTestHelper.NonExistentName);
            
            IsNotNull(() => types);
            AreEqual(0, () => types.Count);
        }
    }
        
    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_Single()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            IList<Type> types = reflectionCache.GetTypesByShortName("ReflectionCache_Type_CoreTests");
            
            IsNotNull(  () => types);
            AreEqual(1, () => types.Count);
            IsNotNull(  () => types[0]);
            AreEqual(typeof(ReflectionCache_Type_CoreTests), () => types[0]);
        }
    }
        
    
    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_Multiple()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            IList<Type> types = reflectionCache.GetTypesByShortName("DuplicateClass_13017ef1");

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