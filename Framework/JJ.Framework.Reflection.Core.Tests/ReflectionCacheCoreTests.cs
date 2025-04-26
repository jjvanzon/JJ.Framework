// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantAssignment
// ReSharper disable ConvertToAutoProperty

//#pragma warning disable IDE0055 

using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionCacheCoreTests
{
    private class TestClass
    {
        private int    _testField;
        private string _testField2;
        public  int    TestProperty  { get => _testField;  set => _testField = value; } // ncrunch: no coverage
        public  string TestProperty2 { get => _testField2; set => _testField2 = value; } // ncrunch: no coverage
    }
    
    // NOTE: Tested methods are run twice to hit cache retrieval.
    
    [TestMethod]
    public void ReflectionCache_GetProperties()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        PropertyInfo[] properties;
        properties = reflectionCache.GetProperties(typeof(TestClass));
        properties = reflectionCache.GetProperties(typeof(TestClass));
        IsNotNull(  () => properties);
        AreEqual(2, () => properties.Length);
        IsNotNull(  () => properties[0]);
        IsNotNull(  () => properties[1]);
        AreEqual(typeof(int),     () => properties[0].PropertyType);
        AreEqual(typeof(string),  () => properties[1].PropertyType);
        AreEqual("TestProperty",  () => properties[0].Name);
        AreEqual("TestProperty2", () => properties[1].Name);
    }
    
    [TestMethod]
    public void ReflectionCache_GetPropertyDictionary()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        IDictionary<string, PropertyInfo> dictionary;
        dictionary = reflectionCache.GetPropertyDictionary(typeof(TestClass));
        dictionary = reflectionCache.GetPropertyDictionary(typeof(TestClass));
        IsNotNull(() => dictionary);
        AreEqual(2, () => dictionary.Count);
        IsTrue(() => dictionary.ContainsKey("TestProperty"));
        IsTrue(() => dictionary.ContainsKey("TestProperty2"));
        IsNotNull(() => dictionary["TestProperty"]);
        IsNotNull(() => dictionary["TestProperty2"]);
        AreEqual(typeof(int),    () => dictionary["TestProperty"].PropertyType);
        AreEqual(typeof(string), () => dictionary["TestProperty2"].PropertyType);
    }
    
    [TestMethod]
    public void ReflectionCache_GetFields()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        FieldInfo[] fields;
        fields = reflectionCache.GetFields(typeof(TestClass));
        fields = reflectionCache.GetFields(typeof(TestClass));
        IsNotNull(  () => fields);
        AreEqual(2, () => fields.Length);
        IsNotNull(  () => fields[0]);
        IsNotNull(  () => fields[1]);
        AreEqual(typeof(int),     () => fields[0].FieldType);
        AreEqual(typeof(string),  () => fields[1].FieldType);
        AreEqual("_testField",  () => fields[0].Name);
        AreEqual("_testField2", () => fields[1].Name);
    }
}
