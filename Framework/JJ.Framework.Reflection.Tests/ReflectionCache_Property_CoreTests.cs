// ReSharper disable SimplifyLinqExpressionUseAll

namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class ReflectionCache_Property_CoreTests
{
    // Property

    [TestMethod]
    public void ReflectionCache_GetProperty_Test()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(Public | Instance);

        Func<string, PropertyInfo>[] synonyms = 
        [
            name => reflectionCacheLegacy .GetProperty   (typeof(TestClass), name),
            name => reflectionCacheLegacy2.GetProperty   (typeof(TestClass), name),
            name => reflectionCacheLegacy3.GetProperty   (typeof(TestClass), name),
            name => StaticReflectionCache .GetProperty   (typeof(TestClass), name),
            name => StaticReflectionCache .GetProperty   (typeof(TestClass), name),
            name => reflectionCacheLegacy .TryGetProperty(typeof(TestClass), name),
            name => reflectionCacheLegacy2.TryGetProperty(typeof(TestClass), name),
            name => reflectionCacheLegacy3.TryGetProperty(typeof(TestClass), name),
            name => StaticReflectionCache .TryGetProperty(typeof(TestClass), name),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo prop = func("TestProperty");
                IsNotNull(() => prop);
                AreEqual("TestProperty", () => prop.Name);
                AreEqual(typeof(int), () => prop.PropertyType);

                PropertyInfo prop2 = func("TestProperty2");
                IsNotNull(() => prop2);
                AreEqual("TestProperty2", () => prop2.Name);
                AreEqual(typeof(string), () => prop2.PropertyType);
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetProperty_PublicInstance_TestProperty_NotThrows()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy(Public | Instance);
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(Public | Instance);

        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetProperty(typeof(TestClass), "TestProperty"),
            () => reflectionCacheLegacy2.GetProperty(typeof(TestClass), "TestProperty"),
            () => StaticReflectionCache  .GetProperty(typeof(TestClass), "TestProperty")
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo prop = func();
                IsNotNull(() => prop);
                AreEqual("TestProperty", () => prop.Name);
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetProperty_PublicStatic_StaticTestProperty_NotThrows()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy(Public | Static);
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(Public | Static);

        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetProperty(typeof(TestClass), "StaticTestProperty"),
            () => reflectionCacheLegacy2.GetProperty(typeof(TestClass), "StaticTestProperty"),
            () => StaticReflectionCache  .GetProperty(typeof(TestClass), "StaticTestProperty")
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo prop = func();
                IsNotNull(() => prop);
                AreEqual("StaticTestProperty", () => prop.Name);
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetProperty_FlagsMismatch_Throws()
    {
        // Flags that don't match the property visibility should cause not found.
        Action[] actions =
        [
            () => new ReflectionCacheLegacy(NonPublic | Instance).GetProperty(typeof(TestClass), "TestProperty"),
            () => new ReflectionCacheLegacy(Public | Instance).GetProperty(typeof(TestClass), "StaticTestProperty"),
            () => new ReflectionCacheLegacy(NonPublic | Static).GetProperty(typeof(TestClass), "StaticTestProperty")
        ];

        foreach (var action in actions)
        {
            ThrowsExceptionContaining(action, "Property", "not found");
        }
    }
        
    [TestMethod]
    public void ReflectionCache_GetProperty_NotFound_Exception()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(Public | Instance);

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetProperty(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy .GetProperty(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.GetProperty(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy3.GetProperty(typeof(TestClass), NonExistentName)
        ];

        foreach (var action in synonyms)
        {
            ThrowsExceptionContaining(action, "Property", "not found");
        }
    }

    [TestMethod]
    public void ReflectionCache_TryGetProperty_NotFound_ReturnsNull()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(Public | Instance);

        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetProperty(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.TryGetProperty(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy3.TryGetProperty(typeof(TestClass), NonExistentName),
            () => StaticReflectionCache .TryGetProperty(typeof(TestClass), NonExistentName)
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo prop = func();
                IsNull(() => prop);
            }
        }
    }
    
    // Properties
    
    [TestMethod]
    public void ReflectionCache_GetProperties()
    {
        var reflectionCache  = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<IList<PropertyInfo>>[] synonyms = 
        [
            () => reflectionCache       .GetProperties(typeof(TestClass)),
            () => reflectionCacheLegacy .GetProperties(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetProperties(typeof(TestClass)),
            () => StaticReflectionCache .GetProperties(typeof(TestClass), BINDING_FLAGS_ALL),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                IList<PropertyInfo> properties = func();

                IsNotNull(  () => properties);
                AreEqual(3, () => properties.Count);
                IsTrue(properties.Any(x => x.Name == "TestProperty"));
                IsTrue(properties.Any(x => x.Name == "TestProperty2"));
                IsTrue(properties.Any(x => x.Name == "StaticTestProperty"));
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetProperties_DifferentFlags()
    {
        IList<PropertyInfo> instanceProps = new ReflectionCacheLegacy(Public | Instance).GetProperties(typeof(TestClass));
        IList<PropertyInfo> staticProps   = new ReflectionCacheLegacy(Public | Static  ).GetProperties(typeof(TestClass));
        IList<PropertyInfo> allProps      = new ReflectionCacheLegacy(BINDING_FLAGS_ALL ).GetProperties(typeof(TestClass));

        AreEqual(2, () => instanceProps.Count);
        AreEqual(1, () => staticProps  .Count);
        AreEqual(3, () => allProps     .Count);

        IsTrue( instanceProps.Any(x => x.Name == "TestProperty"      ));
        IsTrue( instanceProps.Any(x => x.Name == "TestProperty2"     ));
        IsTrue(!instanceProps.Any(x => x.Name == "StaticTestProperty"));
        IsTrue( staticProps  .Any(x => x.Name == "StaticTestProperty"));
        IsTrue(!staticProps  .Any(x => x.Name == "TestProperty"      ));
    }

    // PropertyDictionary
    
    [TestMethod]
    public void ReflectionCache_GetPropertyDictionary()
    {
        var reflectionCache  = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<IDictionary<string, PropertyInfo>>[] synonyms = 
        [
            () => reflectionCache       .GetPropertyDictionary(typeof(TestClass)),
            () => reflectionCacheLegacy .GetPropertyDictionary(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetPropertyDictionary(typeof(TestClass)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                IDictionary<string, PropertyInfo> dictionary = func();
                
                IsNotNull(() => dictionary);
                AreEqual(3, () => dictionary.Count);
                IsTrue(() => dictionary.ContainsKey("TestProperty"));
                IsTrue(() => dictionary.ContainsKey("TestProperty2"));
                IsTrue(() => dictionary.ContainsKey("StaticTestProperty"));
                IsNotNull(() => dictionary["TestProperty"]);
                IsNotNull(() => dictionary["TestProperty2"]);
                IsNotNull(() => dictionary["StaticTestProperty"]);
                AreEqual(typeof(int),    () => dictionary["TestProperty"].PropertyType);
                AreEqual(typeof(string), () => dictionary["TestProperty2"].PropertyType);
                AreEqual(typeof(string), () => dictionary["StaticTestProperty"].PropertyType);
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetPropertyDictionary_DifferentFlags()
    {
        var instanceDict = new ReflectionCacheLegacy(Public | Instance).GetPropertyDictionary(typeof(TestClass));
        var staticDict   = new ReflectionCacheLegacy(Public | Static  ).GetPropertyDictionary(typeof(TestClass));
        var allDict      = new ReflectionCacheLegacy(BINDING_FLAGS_ALL).GetPropertyDictionary(typeof(TestClass));

        AreEqual(2, () => instanceDict.Count);
        AreEqual(1, () => staticDict.Count);
        AreEqual(3, () => allDict.Count);

        IsTrue( instanceDict.ContainsKey("TestProperty"));
        IsTrue( instanceDict.ContainsKey("TestProperty2"));
        IsTrue(!instanceDict.ContainsKey("StaticTestProperty"));
        IsTrue( staticDict  .ContainsKey("StaticTestProperty"));
        IsTrue(!staticDict  .ContainsKey("TestProperty"));
    }
}