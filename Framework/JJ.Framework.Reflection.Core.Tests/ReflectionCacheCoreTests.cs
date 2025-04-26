// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantAssignment
// ReSharper disable ConvertToAutoProperty

using System.Xml.Linq;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionCacheCoreTests
{
    private const int REPEATS = 2;
    private string _nonExistentName = Guid.NewGuid().ToString();
   
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
        
        for (int i = 0; i < REPEATS; i++)
        {
            PropertyInfo[] properties = reflectionCache.GetProperties(typeof(TestClass));
            
            IsNotNull(  () => properties);
            AreEqual(2, () => properties.Length);
            IsNotNull(  () => properties[0]);
            IsNotNull(  () => properties[1]);
            AreEqual(typeof(int),     () => properties[0].PropertyType);
            AreEqual(typeof(string),  () => properties[1].PropertyType);
            AreEqual("TestProperty",  () => properties[0].Name);
            AreEqual("TestProperty2", () => properties[1].Name);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetPropertyDictionary()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            IDictionary<string, PropertyInfo> dictionary = reflectionCache.GetPropertyDictionary(typeof(TestClass));
            
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
    
    [TestMethod]
    public void ReflectionCache_GetFields()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            FieldInfo[] fields = reflectionCache.GetFields(typeof(TestClass));
            
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
    
    [TestMethod]
    public void ReflectionCache_GetTypeByShortName_Core_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            Type type = reflectionCache.GetTypeByShortName("ReflectionCache");
            IsNotNull(() => type);
            AreEqual(typeof(ReflectionCache), () => type);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetTypeByShortName_NotFound_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetTypeByShortName(_nonExistentName),
                "Type with short name", "not found");
        }
    }
        
    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_Core_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            Type type = reflectionCache.TryGetTypeByShortName("ReflectionCache");
            IsNotNull(() => type);
            AreEqual(typeof(ReflectionCache), () => type);
        }
    }

    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_NotFound_ReturnsNull()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            Type type = reflectionCache.TryGetTypeByShortName(_nonExistentName);
            IsNull(() => type);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_Multiple_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetTypeByShortName("Duplicate13017ef1"),
                "Type with short name", "multiple");
        }
    }

    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_None()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            IList<Type> types = reflectionCache.GetTypesByShortName(_nonExistentName);
            
            IsNotNull(() => types);
            AreEqual(0, () => types.Count);
        }
    }
        
    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_Single()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            IList<Type> types = reflectionCache.GetTypesByShortName("ReflectionCache");
            
            IsNotNull(  () => types);
            AreEqual(1, () => types.Count);
            IsNotNull(  () => types[0]);
            AreEqual(typeof(ReflectionCache), () => types[0]);
        }
    }
        
    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_Multiple()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            IList<Type> types = reflectionCache.GetTypesByShortName("Duplicate13017ef1");

            IsNotNull(() => types);
            AreEqual(2, () => types.Count);
            IsNotNull(() => types[0]);
            IsNotNull(() => types[1]);
            NotEqual(types[0], () => types[1]);
            IsTrue(types.Any(x => x == typeof(Namespace1.Duplicate13017ef1)));
            IsTrue(types.Any(x => x == typeof(Namespace2.Duplicate13017ef1)));
        }
    }
}
