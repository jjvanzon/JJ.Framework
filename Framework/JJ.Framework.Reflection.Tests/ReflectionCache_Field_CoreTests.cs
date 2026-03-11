
namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class ReflectionCache_Field_CoreTests
{
    // Field

    [TestMethod]
    public void ReflectionCache_GetField_Test()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(NonPublic | Instance);

        Func<string, FieldInfo>[] synonyms = 
        [
            name => reflectionCacheLegacy .GetField   (typeof(TestClass), name),
            name => reflectionCacheLegacy2.GetField   (typeof(TestClass), name),
            name => reflectionCacheLegacy3.GetField   (typeof(TestClass), name),
            name => StaticReflectionCache .GetField   (typeof(TestClass), name),
            name => reflectionCacheLegacy .TryGetField(typeof(TestClass), name),
            name => reflectionCacheLegacy2.TryGetField(typeof(TestClass), name),
            name => reflectionCacheLegacy3.TryGetField(typeof(TestClass), name),
            name => StaticReflectionCache .TryGetField(typeof(TestClass), name),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
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
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(NonPublic | Instance);

        Func<string, FieldInfo>[] synonyms = 
        [
            name => reflectionCacheLegacy .TryGetField(typeof(TestClass), name),
            name => reflectionCacheLegacy2.TryGetField(typeof(TestClass), name),
            name => reflectionCacheLegacy3.TryGetField(typeof(TestClass), name),
            name => StaticReflectionCache .TryGetField(typeof(TestClass), name),
            name => reflectionCacheLegacy .GetField   (typeof(TestClass), name),
            name => reflectionCacheLegacy2.GetField   (typeof(TestClass), name),
            name => reflectionCacheLegacy3.GetField   (typeof(TestClass), name),
            name => StaticReflectionCache .GetField   (typeof(TestClass), name),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
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
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(NonPublic | Instance);

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy .GetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.GetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy3.GetField(typeof(TestClass), NonExistentName),
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
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(NonPublic | Instance);

        Func<FieldInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.TryGetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy3.TryGetField(typeof(TestClass), NonExistentName),
            () => StaticReflectionCache .TryGetField(typeof(TestClass), NonExistentName),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
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
        var reflectionCache  = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCache3 = new ReflectionCache(NonPublic | Instance);
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(NonPublic | Instance);

        Func<FieldInfo[]>[] synonyms =
        [
            () => reflectionCache       .GetFields(typeof(TestClass)),
            () => reflectionCache3      .GetFields(typeof(TestClass)),
            () => reflectionCacheLegacy .GetFields(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetFields(typeof(TestClass)),
            () => reflectionCacheLegacy3.GetFields(typeof(TestClass)),
          //() => StaticReflectionCache .GetFields(typeof(TestClass)), // Only does public instance fields
            () => StaticReflectionCache .GetFields(typeof(TestClass), BINDING_FLAGS_ALL),
            () => StaticReflectionCache .GetFields(typeof(TestClass), NonPublic | Instance)
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
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