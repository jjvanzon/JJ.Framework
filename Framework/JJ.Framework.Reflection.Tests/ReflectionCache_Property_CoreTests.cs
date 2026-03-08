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

        Func<string, PropertyInfo>[] synonyms = 
        [
            name => reflectionCacheLegacy .GetProperty   (typeof(TestClass), name),
            name => reflectionCacheLegacy2.GetProperty   (typeof(TestClass), name),
            name => StaticReflectionCache .GetProperty   (typeof(TestClass), name),
            name => StaticReflectionCache .GetProperty   (typeof(TestClass), name),
            name => reflectionCacheLegacy .TryGetProperty(typeof(TestClass), name),
            name => reflectionCacheLegacy2.TryGetProperty(typeof(TestClass), name),
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
    public void ReflectionCache_GetProperty_NotFound_Exception()
    {
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetProperty(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy .GetProperty(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.GetProperty(typeof(TestClass), NonExistentName)
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

        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetProperty(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.TryGetProperty(typeof(TestClass), NonExistentName),
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
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        
        Func<IList<PropertyInfo>>[] synonyms = 
        [
            () => reflectionCache       .GetProperties(typeof(TestClass)),
            () => reflectionCacheLegacy .GetProperties(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetProperties(typeof(TestClass)),
            () => StaticReflectionCache .GetProperties(typeof(TestClass)),
            () => StaticReflectionCache .GetProperties(typeof(TestClass), BINDING_FLAGS_ALL)
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                IList<PropertyInfo> properties = func();

                IsNotNull(  () => properties);
                AreEqual(2, () => properties.Count);
                IsNotNull(  () => properties[0]);
                IsNotNull(  () => properties[1]);
                AreEqual(typeof(int),     () => properties[0].PropertyType);
                AreEqual(typeof(string),  () => properties[1].PropertyType);
                AreEqual("TestProperty",  () => properties[0].Name);
                AreEqual("TestProperty2", () => properties[1].Name);
            }
        }
    }

    // PropertyDictionary
    
    [TestMethod]
    public void ReflectionCache_GetPropertyDictionary()
    {
        // TODO: Expand
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
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
                AreEqual(2, () => dictionary.Count);
                IsTrue(() => dictionary.ContainsKey("TestProperty"));
                IsTrue(() => dictionary.ContainsKey("TestProperty2"));
                IsNotNull(() => dictionary["TestProperty"]);
                IsNotNull(() => dictionary["TestProperty2"]);
                AreEqual(typeof(int),    () => dictionary["TestProperty"].PropertyType);
                AreEqual(typeof(string), () => dictionary["TestProperty2"].PropertyType);
            }
        }
    }
}