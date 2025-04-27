// ReSharper disable UnusedMember.Local

using static System.Reflection.BindingFlags;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ReflectionCacheCoreTests
{
    private const int REPEATS = 2;
    private string _nonExistentName = Guid.NewGuid().ToString();

    // ncrunch: no coverage start
    
    private class TestClass
    {
        private int    _testField;
        private string _testField2;
        public  int    TestProperty  { get => _testField;  set => _testField = value; } 
        public  string TestProperty2 { get => _testField2; set => _testField2 = value; }
        public int TestMethod() => 0;
        public string TestMethod2(int index, string text) => "";
    }

    private class ClassWithIndexers
    {
        public int this[int index] { get => default; set { } }
        public int this[int index, string text] { get => default; set { } }
    }
    
    private class ClassWithoutIndexer;
    
    private class NoConstructorClass
    {
        private NoConstructorClass() { }
    }
    
    private class MultipleConstructorsClass
    {
        public MultipleConstructorsClass() { }
        public MultipleConstructorsClass(int i) { }
    }

    // ncrunch: no coverage end
    
    // NOTE: Tested methods are run twice to hit cache retrieval.
    
    // Properties

    [TestMethod]
    public void StaticReflectionCache_GetProperty_Core_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            PropertyInfo field = StaticReflectionCache.GetProperty(typeof(TestClass), "TestProperty");
            IsNotNull(() => field);
            AreEqual("TestProperty", () => field.Name);
            AreEqual(typeof(int), () => field.PropertyType);

            PropertyInfo field2 = StaticReflectionCache.GetProperty(typeof(TestClass), "TestProperty2");
            IsNotNull(() => field2);
            AreEqual("TestProperty2", () => field2.Name);
            AreEqual(typeof(string), () => field2.PropertyType);
        }
    }
    
    [TestMethod]
    public void StaticReflectionCache_TryGetProperty_Core_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            PropertyInfo field = StaticReflectionCache.TryGetProperty(typeof(TestClass), "TestProperty");
            IsNotNull(() => field);
            AreEqual("TestProperty", () => field.Name);
            AreEqual(typeof(int), () => field.PropertyType);

            PropertyInfo field2 = StaticReflectionCache.TryGetProperty(typeof(TestClass), "TestProperty2");
            IsNotNull(() => field2);
            AreEqual("TestProperty2", () => field2.Name);
            AreEqual(typeof(string), () => field2.PropertyType);
        }
    }
        
    [TestMethod]
    public void StaticReflectionCache_GetProperty_NotFound_Exception()
    {
        ThrowsExceptionContaining(
            () => StaticReflectionCache.GetProperty(typeof(TestClass), _nonExistentName), 
            "Property", "not found");
    }

    [TestMethod]
    public void StaticReflectionCache_TryGetProperty_NotFound_ReturnsNull()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            PropertyInfo field = StaticReflectionCache.TryGetProperty(typeof(TestClass), _nonExistentName);
            IsNull(() => field);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetProperties()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            IList<PropertyInfo> properties = reflectionCache.GetProperties(typeof(TestClass));
            AssertProperties(properties);
        }
    }
    
    [TestMethod]
    public void StaticReflectionCache_GetProperties()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            IList<PropertyInfo> properties = StaticReflectionCache.GetProperties(typeof(TestClass), BINDING_FLAGS_ALL);
            AssertProperties(properties);
        }
    }
    
    private void AssertProperties(IList<PropertyInfo> properties)
    {
        IsNotNull(  () => properties);
        AreEqual(2, () => properties.Count);
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
    
    // Fields

    [TestMethod]
    public void StaticReflectionCache_GetField_Core_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            FieldInfo field = StaticReflectionCache.GetField(typeof(TestClass), "_testField");
            IsNotNull(() => field);
            AreEqual("_testField", () => field.Name);
            AreEqual(typeof(int), () => field.FieldType);

            FieldInfo field2 = StaticReflectionCache.GetField(typeof(TestClass), "_testField2");
            IsNotNull(() => field2);
            AreEqual("_testField2", () => field2.Name);
            AreEqual(typeof(string), () => field2.FieldType);
        }
    }
    
    [TestMethod]
    public void StaticReflectionCache_TryGetField_Core_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            FieldInfo field = StaticReflectionCache.TryGetField(typeof(TestClass), "_testField");
            IsNotNull(() => field);
            AreEqual("_testField", () => field.Name);
            AreEqual(typeof(int), () => field.FieldType);

            FieldInfo field2 = StaticReflectionCache.TryGetField(typeof(TestClass), "_testField2");
            IsNotNull(() => field2);
            AreEqual("_testField2", () => field2.Name);
            AreEqual(typeof(string), () => field2.FieldType);
        }
    }
        
    [TestMethod]
    public void StaticReflectionCache_GetField_NotFound_Exception()
    {
        ThrowsExceptionContaining(
            () => StaticReflectionCache.GetField(typeof(TestClass), _nonExistentName), 
            "Field", "not found");
    }

    [TestMethod]
    public void StaticReflectionCache_TryGetField_NotFound_ReturnsNull()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            FieldInfo field = StaticReflectionCache.TryGetField(typeof(TestClass), _nonExistentName);
            IsNull(() => field);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetFields()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            FieldInfo[] fields = reflectionCache.GetFields(typeof(TestClass));
            AssertFields(fields);
        }
    }
    
    [TestMethod]
    public void StaticReflectionCache_GetFields()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            FieldInfo[] fields = StaticReflectionCache.GetFields(typeof(TestClass), BINDING_FLAGS_ALL);
            AssertFields(fields);
        }
    }
    
    private void AssertFields(FieldInfo[] fields)
    {
        IsNotNull(  () => fields);
        AreEqual(2, () => fields.Length);
        IsNotNull(  () => fields[0]);
        IsNotNull(  () => fields[1]);
        AreEqual(typeof(int),    () => fields[0].FieldType);
        AreEqual(typeof(string), () => fields[1].FieldType);
        AreEqual("_testField",   () => fields[0].Name);
        AreEqual("_testField2",  () => fields[1].Name);
    }
    
    // Methods
    
    [TestMethod]
    public void StaticReflectionCache_GetMethod_Core_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            MethodInfo method = StaticReflectionCache.GetMethod(typeof(TestClass), "TestMethod");
            AssertMethod(method);
            
            // NOTE: It's pretty strict you need to supply parameter types.
            MethodInfo method2 = StaticReflectionCache.GetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string));
            AssertMethod2(method2);
        }
    }
    
    [TestMethod]
    public void StaticReflectionCache_TryGetMethod_Core_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            MethodInfo method = StaticReflectionCache.TryGetMethod(typeof(TestClass), "TestMethod");
            AssertMethod(method);

            // NOTE: It's pretty strict you need to supply parameter types.
            MethodInfo method2 = StaticReflectionCache.TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string));
            AssertMethod2(method2);
        } 
     }
    
    [TestMethod]
    public void StaticReflectionCache_GetMethod_NotFound_Throws()
    {
        ThrowsExceptionContaining(
            () => StaticReflectionCache.GetMethod(typeof(TestClass), _nonExistentName), 
            "Method", "not found");
    }
    
    [TestMethod]
    public void StaticReflectionCache_TryGetMethod_NotFound_ReturnsNull()
    {
        MethodInfo method = StaticReflectionCache.TryGetMethod(typeof(TestClass), _nonExistentName);
        IsNull(() => method);
    }
    
    [TestMethod]
    public void StaticReflectionCache_GetMethods()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            IList<MethodInfo> methods = StaticReflectionCache.GetMethods(typeof(TestClass), BINDING_FLAGS_ALL);
            IsNotNull(() => methods);

            MethodInfo method = methods.FirstOrDefault(x => x.Name == "TestMethod");
            AssertMethod(method);
            
            MethodInfo method2 = methods.FirstOrDefault(x => x.Name == "TestMethod2");
            AssertMethod2(method2);
        }
    }
    
    private static void AssertMethod(MethodInfo method)
    {
        IsNotNull(() => method);
        AreEqual("TestMethod", () => method.Name);
        AreEqual(typeof(int),  () => method.ReturnType);
        
        var parameters = method.GetParameters();
        IsNotNull(() => parameters);
        AreEqual(0, () => parameters.Length);
    }
    
    private static void AssertMethod2(MethodInfo method2)
    {
        IsNotNull(() => method2);
        AreEqual("TestMethod2",  () => method2.Name);
        AreEqual(typeof(string), () => method2.ReturnType);
        
        var parameters = method2.GetParameters();
        AreEqual(2,              () => parameters.Length);
        AreEqual(typeof(int),    () => parameters[0].ParameterType);
        AreEqual(typeof(string), () => parameters[1].ParameterType);
    }
    
    // Indexers
    
    [TestMethod]
    public void StaticReflectionCache_GetIndexer_Core_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            PropertyInfo indexer = StaticReflectionCache.GetIndexer(typeof(ClassWithIndexers), typeof(int));
            AssertIndexer1(indexer);
             
            PropertyInfo indexer2 = StaticReflectionCache.GetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string));
            AssertIndexer2(indexer2);
        }
    }
    
    [TestMethod]
    public void StaticReflectionCache_TryGetIndexer_Core_Test()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            PropertyInfo indexer = StaticReflectionCache.TryGetIndexer(typeof(ClassWithIndexers), typeof(int));
            AssertIndexer1(indexer);
            
            PropertyInfo indexer2 = StaticReflectionCache.TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string));
            AssertIndexer2(indexer2);
        }
    }

    private void AssertIndexer1(PropertyInfo indexer)
    {
        IsNotNull(() => indexer);
        AreEqual(typeof(int), () => indexer.PropertyType);
        
        ParameterInfo[] parameters = indexer.GetIndexParameters();
        IsNotNull(() => parameters);
        AreEqual(1, () => parameters.Length);
        IsNotNull(() => parameters[0]);
        AreEqual(typeof(int), () => parameters[0].ParameterType);
    }
        
    private void AssertIndexer2(PropertyInfo indexer)
    {
        IsNotNull(() => indexer);
        AreEqual(typeof(int), () => indexer.PropertyType);
        
        ParameterInfo[] parameters = indexer.GetIndexParameters();
        IsNotNull(() => parameters);
        AreEqual(2, () => parameters.Length);
        IsNotNull(() => parameters[0]);
        IsNotNull(() => parameters[1]);
        AreEqual(typeof(int),    () => parameters[0].ParameterType);
        AreEqual(typeof(string), () => parameters[1].ParameterType);
    }
    
    [TestMethod]
    public void StaticReflectionCache_GetIndexer_NotFound_Throws()
    {
        ThrowsExceptionContaining(
            () => StaticReflectionCache.GetIndexer(typeof(ClassWithoutIndexer), typeof(int)), 
            "Indexer not found");
    }
    
    [TestMethod]
    public void StaticReflectionCache_TryGetIndexer_NotFound_ReturnsNull()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            PropertyInfo indexer = StaticReflectionCache.TryGetIndexer(typeof(ClassWithoutIndexer), typeof(int), typeof(string));
            IsNull(() => indexer);
        }
    }
    
    // Constructor Tests
    
    [TestMethod]
    public void ReflectionCache_GetConstructor_Single()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            ConstructorInfo constructor = reflectionCache.GetConstructor(typeof(TestClass));
            IsNotNull(() => constructor);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetConstructor_None_Throws()
    {
        var reflectionCache = new ReflectionCache(Public | Instance);
        
        for (int i = 0; i < REPEATS; i++)
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
        
        for (int i = 0; i < REPEATS; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetConstructor(typeof(MultipleConstructorsClass)), 
                "Multiple constructors found");
        }
    }
    
    // GetTypeByShortName
    
    [TestMethod]
    public void ReflectionCache_GetTypeByShortName_Core_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            Type type = reflectionCache.GetTypeByShortName("ReflectionCacheCoreTests");
            IsNotNull(() => type);
            AreEqual(typeof(ReflectionCacheCoreTests), () => type);
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
            Type type = reflectionCache.TryGetTypeByShortName("ReflectionCacheCoreTests");
            IsNotNull(() => type);
            AreEqual(typeof(ReflectionCacheCoreTests), () => type);
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
                () => reflectionCache.GetTypeByShortName("DuplicateClass_13017ef1"),
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
            IList<Type> types = reflectionCache.GetTypesByShortName("ReflectionCacheCoreTests");
            
            IsNotNull(  () => types);
            AreEqual(1, () => types.Count);
            IsNotNull(  () => types[0]);
            AreEqual(typeof(ReflectionCacheCoreTests), () => types[0]);
        }
    }
        
    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_Multiple()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < REPEATS; i++)
        {
            IList<Type> types = reflectionCache.GetTypesByShortName("DuplicateClass_13017ef1");

            IsNotNull(() => types);
            AreEqual(2, () => types.Count);
            IsNotNull(() => types[0]);
            IsNotNull(() => types[1]);
            NotEqual(types[0], () => types[1]);
            IsTrue(types.Any(x => x == typeof(Helpers.Namespace1.DuplicateClass_13017ef1)));
            IsTrue(types.Any(x => x == typeof(Helpers.Namespace2.DuplicateClass_13017ef1)));
        }
    }
}
