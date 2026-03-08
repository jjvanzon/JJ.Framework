namespace JJ.Framework.Reflection.Legacy.Tests;

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
public class ReflectionCache_Constructor_CoreTests
{
    [TestMethod]
    public void ReflectionCache_GetConstructor_Single()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            ConstructorInfo constructor = reflectionCache.GetConstructor(typeof(TestClass));
            IsNotNull(() => constructor);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetConstructor_None_Throws()
    {
        var reflectionCache = new ReflectionCache(Public | Instance);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetConstructor(typeof(NoConstructorClass)), 
                "No constructor found");
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetConstructor_Multiple_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetConstructor(typeof(MultipleConstructorsClass)), 
                "Multiple constructors found");
        }
    }
}