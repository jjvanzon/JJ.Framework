namespace JJ.Framework.Reflection.Legacy.Tests;

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
public class ReflectionCache_Field_CoreTests
{
    // Field

    [TestMethod]
    public void ReflectionCache_GetField_Test()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<string, FieldInfo>[] synonyms = 
        [
            name => reflectionCacheLegacy .GetField   (typeof(TestClass), name),
            name => reflectionCacheLegacy2.GetField   (typeof(TestClass), name),
            name => StaticReflectionCache .GetField   (typeof(TestClass), name),
            name => reflectionCacheLegacy .TryGetField(typeof(TestClass), name),
            name => reflectionCacheLegacy2.TryGetField(typeof(TestClass), name),
            name => StaticReflectionCache .TryGetField(typeof(TestClass), name),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
            {
                FieldInfo field = func("_testField");
                IsNotNull(() => field);
                AreEqual("_testField", () => field.Name);
                AreEqual(typeof(int), () => field.FieldType);

                FieldInfo field2 = func("_testField2");
                IsNotNull(() => field2);
                AreEqual("_testField2", () => field2.Name);
                AreEqual(typeof(string), () => field2.FieldType);
            }
        }
    }

    // TODO: Remove duplicate?
    
    [TestMethod]
    public void ReflectionCache_TryGetField_Test()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<string, FieldInfo>[] synonyms = 
        [
            name => reflectionCacheLegacy .TryGetField(typeof(TestClass), name),
            name => reflectionCacheLegacy2.TryGetField(typeof(TestClass), name),
            name => StaticReflectionCache .TryGetField(typeof(TestClass), name),
            name => reflectionCacheLegacy .GetField   (typeof(TestClass), name),
            name => reflectionCacheLegacy2.GetField   (typeof(TestClass), name),
            name => StaticReflectionCache .GetField   (typeof(TestClass), name),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
            {
                FieldInfo field = func("_testField");
                IsNotNull(() => field);
                AreEqual("_testField", () => field.Name);
                AreEqual(typeof(int), () => field.FieldType);

                FieldInfo field2 = func("_testField2");
                IsNotNull(() => field2);
                AreEqual("_testField2", () => field2.Name);
                AreEqual(typeof(string), () => field2.FieldType);
            }
        }
    }
        
    [TestMethod]
    public void ReflectionCache_GetField_NotFound_Exception()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetField(typeof(TestClass), ReflectionCacheTestHelper.NonExistentName),
            () => reflectionCacheLegacy .GetField(typeof(TestClass), ReflectionCacheTestHelper.NonExistentName),
            () => reflectionCacheLegacy2.GetField(typeof(TestClass), ReflectionCacheTestHelper.NonExistentName),
        ];

        foreach (var action in synonyms)
        {
            ThrowsExceptionContaining(action, "Field", "not found");
        }
    }

    [TestMethod]
    public void ReflectionCache_TryGetField_NotFound_ReturnsNull()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<FieldInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetField(typeof(TestClass), ReflectionCacheTestHelper.NonExistentName),
            () => reflectionCacheLegacy2.TryGetField(typeof(TestClass), ReflectionCacheTestHelper.NonExistentName),
            () => StaticReflectionCache .TryGetField(typeof(TestClass), ReflectionCacheTestHelper.NonExistentName),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
            {
                FieldInfo field = func();
                IsNull(() => field);
            }
        }
    }
    
    // Fields
    
    [TestMethod]
    public void ReflectionCache_GetFields()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<FieldInfo[]>[] synonyms =
        [
            () => reflectionCache       .GetFields(typeof(TestClass)),
            () => reflectionCacheLegacy .GetFields(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetFields(typeof(TestClass)),
            //() => StaticReflectionCache .GetFields(typeof(TestClass)), // Only does public instance fields
            () => StaticReflectionCache .GetFields(typeof(TestClass), BINDING_FLAGS_ALL)
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < ReflectionCacheTestHelper.Repeats; i++)
            {
                FieldInfo[] fields = func();

                IsNotNull(  () => fields);
                AreEqual(2, () => fields.Length);
                IsNotNull(  () => fields[0]);
                IsNotNull(  () => fields[1]);
                AreEqual(typeof(int),    () => fields[0].FieldType);
                AreEqual(typeof(string), () => fields[1].FieldType);
                AreEqual("_testField",   () => fields[0].Name);
                AreEqual("_testField2",  () => fields[1].Name);
            }
        }
    }
}