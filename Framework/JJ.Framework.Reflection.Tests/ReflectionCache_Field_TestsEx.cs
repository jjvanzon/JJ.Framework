
namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class ReflectionCache_Field_TestsEx
{
    // Field

    [TestMethod]
    public void ReflectionCache_GetField_Test()
    {
        var reflectionCacheEx  = new ReflectionCacheEx();
        var reflectionCacheEx2 = new ReflectionCacheEx(BINDING_FLAGS_ALL);
        var reflectionCacheEx3 = new ReflectionCacheEx(NonPublic | Instance);

        Func<string, FieldInfo>[] synonyms = 
        [
            name => reflectionCacheEx    .GetField   (typeof(TestClass), name),
            name => reflectionCacheEx2   .GetField   (typeof(TestClass), name),
            name => reflectionCacheEx3   .GetField   (typeof(TestClass), name),
            name => StaticReflectionCache.GetField   (typeof(TestClass), name),
            name => reflectionCacheEx    .TryGetField(typeof(TestClass), name),
            name => reflectionCacheEx2   .TryGetField(typeof(TestClass), name),
            name => reflectionCacheEx3   .TryGetField(typeof(TestClass), name),
            name => StaticReflectionCache.TryGetField(typeof(TestClass), name),
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
        var reflectionCacheEx  = new ReflectionCacheEx();
        var reflectionCacheEx2 = new ReflectionCacheEx(BINDING_FLAGS_ALL);
        var reflectionCacheEx3 = new ReflectionCacheEx(NonPublic | Instance);

        Func<string, FieldInfo>[] synonyms = 
        [
            name => reflectionCacheEx    .TryGetField(typeof(TestClass), name),
            name => reflectionCacheEx2   .TryGetField(typeof(TestClass), name),
            name => reflectionCacheEx3   .TryGetField(typeof(TestClass), name),
            name => StaticReflectionCache.TryGetField(typeof(TestClass), name),
            name => reflectionCacheEx    .GetField   (typeof(TestClass), name),
            name => reflectionCacheEx2   .GetField   (typeof(TestClass), name),
            name => reflectionCacheEx3   .GetField   (typeof(TestClass), name),
            name => StaticReflectionCache.GetField   (typeof(TestClass), name),
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
        var reflectionCacheEx  = new ReflectionCacheEx();
        var reflectionCacheEx2 = new ReflectionCacheEx(BINDING_FLAGS_ALL);
        var reflectionCacheEx3 = new ReflectionCacheEx(NonPublic | Instance);

        Action[] synonyms =
        [
            () => StaticReflectionCache.GetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheEx    .GetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheEx2   .GetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheEx3   .GetField(typeof(TestClass), NonExistentName),
        ];

        foreach (var action in synonyms)
        {
            Throws(action, "Field", "not found");
        }
    }

    [TestMethod]
    public void ReflectionCache_TryGetField_NotFound_ReturnsNull()
    {
        var reflectionCacheEx  = new ReflectionCacheEx();
        var reflectionCacheEx2 = new ReflectionCacheEx(BINDING_FLAGS_ALL);
        var reflectionCacheEx3 = new ReflectionCacheEx(NonPublic | Instance);

        Func<FieldInfo>[] synonyms =
        [
            () => reflectionCacheEx    .TryGetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheEx2   .TryGetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheEx3   .TryGetField(typeof(TestClass), NonExistentName),
            () => StaticReflectionCache.TryGetField(typeof(TestClass), NonExistentName),
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
    public void ReflectionCache_GetFields_AllFlags()
    {
        var reflectionCache  = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheEx  = new ReflectionCacheEx();
        var reflectionCacheEx2 = new ReflectionCacheEx(BINDING_FLAGS_ALL);

        Func<FieldInfo[]>[] synonyms =
        [
            () => reflectionCache      .GetFields(typeof(TestClass)),
            () => reflectionCacheEx    .GetFields(typeof(TestClass)),
            () => reflectionCacheEx2   .GetFields(typeof(TestClass)),
            () => StaticReflectionCache.GetFields(typeof(TestClass), BINDING_FLAGS_ALL),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                FieldInfo[] fields = func();

                IsNotNull(  () => fields);
                AreEqual(5, () => fields.Length);
                IsTrue(fields.Any(x => x.Name == "_testField"         ));
                IsTrue(fields.Any(x => x.Name == "_testField2"        ));
                IsTrue(fields.Any(x => x.Name == "_staticTestProperty"));
                IsTrue(fields.Any(x => x.Name == "_publicTestField"    ));
                IsTrue(fields.Any(x => x.Name == "_publicStaticField"  ));
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetFields_NonPublicInstance()
    {
        var reflectionCache   = new ReflectionCache(NonPublic | Instance);
        var reflectionCacheEx = new ReflectionCacheEx(NonPublic | Instance);

        Func<FieldInfo[]>[] synonyms =
        [
            () => reflectionCache      .GetFields(typeof(TestClass)),
            () => reflectionCacheEx    .GetFields(typeof(TestClass)),
            () => StaticReflectionCache.GetFields(typeof(TestClass), NonPublic | Instance)
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                FieldInfo[] fields = func();

                IsNotNull(  () => fields);
                AreEqual(2, () => fields.Length);
                IsTrue(fields.Any(x => x.Name == "_testField" ));
                IsTrue(fields.Any(x => x.Name == "_testField2"));
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetFields_StaticReflectionCache_DefaultFlags_PublicInstanceOnly()
    {
        // NOTE: This is why StaticReflectionCache.GetFields(typeof(TestClass)) stayed outcommented in all-flags tests:
        // default flags are Public | Instance, so it intentionally returns only public instance fields.
        FieldInfo[] fields = StaticReflectionCache.GetFields(typeof(TestClass));

        IsNotNull(() => fields);
        AreEqual(1, () => fields.Length);
        IsTrue(fields.Any(x => x.Name == "_publicTestField"));
        IsTrue(!fields.Any(x => x.Name == "_publicStaticField"));
        IsTrue(!fields.Any(x => x.Name == "_testField"));
    }

    [TestMethod]
    public void ReflectionCache_GetFields_DifferentFlags()
    {
        FieldInfo[] nonPublicInstance = new ReflectionCacheEx(NonPublic | Instance).GetFields(typeof(TestClass));
        FieldInfo[] publicInstance    = new ReflectionCacheEx(Public    | Instance).GetFields(typeof(TestClass));
        FieldInfo[] publicStatic      = new ReflectionCacheEx(Public    | Static  ).GetFields(typeof(TestClass));
        FieldInfo[] nonPublicStatic   = new ReflectionCacheEx(NonPublic | Static  ).GetFields(typeof(TestClass));
        FieldInfo[] all               = new ReflectionCacheEx(BINDING_FLAGS_ALL   ).GetFields(typeof(TestClass));

        AreEqual(2, () => nonPublicInstance.Length);
        AreEqual(1, () => publicInstance   .Length);
        AreEqual(1, () => publicStatic     .Length);
        AreEqual(1, () => nonPublicStatic  .Length);
        AreEqual(5, () => all              .Length);

        IsTrue(nonPublicInstance.Any(x => x.Name == "_testField"         ));
        IsTrue(nonPublicInstance.Any(x => x.Name == "_testField2"        ));
        IsTrue(publicInstance   .Any(x => x.Name == "_publicTestField"    ));
        IsTrue(publicStatic     .Any(x => x.Name == "_publicStaticField"  ));
        IsTrue(nonPublicStatic  .Any(x => x.Name == "_staticTestProperty"));
    }
}