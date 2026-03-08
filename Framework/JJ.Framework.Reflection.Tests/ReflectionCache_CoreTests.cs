// ReSharper disable UnusedMember.Local

using static JJ.Framework.Reflection.Legacy.Tests.ReflectionCacheTestHelper;

namespace JJ.Framework.Reflection.Legacy.Tests;

// ncrunch: no coverage start

internal class TestClass
{
    private int    _testField;
    private string _testField2 = "";
    public  int    TestProperty  { get => _testField;  set => _testField = value; } 
    public  string TestProperty2 { get => _testField2; set => _testField2 = value; }
    public int TestMethod() => 0;
    public string TestMethod2(int index, string text) => "";
}

internal class ClassWithIndexers
{
    public int this[int index] { get => default; set { } }
    public int this[int index, string text] { get => default; set { } }
}

internal class ClassWithoutIndexer;

internal class NoConstructorClass
{
    private NoConstructorClass() { }
}

internal class MultipleConstructorsClass
{
    public MultipleConstructorsClass() { }
    public MultipleConstructorsClass(int i) { }
}

// ncrunch: no coverage end

internal static class ReflectionCacheTestHelper
{
    /// <summary>
    /// NOTE: Tested methods are run twice to hit cache retrieval.
    /// </summary>
    public const int Repeats = 2;
    public static readonly string NonExistentName = Guid.NewGuid().ToString();
}

// TODO: Vary BindingFlags in tests

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
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

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy .GetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.GetField(typeof(TestClass), NonExistentName),
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
            () => reflectionCacheLegacy .TryGetField(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.TryGetField(typeof(TestClass), NonExistentName),
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

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
public class ReflectionCache_Methopd_CoreTests
{
    // Method
    
    [TestMethod]
    public void ReflectionCache_GetMethod_Test()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<MethodInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetMethod   (typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy2.GetMethod   (typeof(TestClass), "TestMethod"),
            () => StaticReflectionCache .GetMethod   (typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy .TryGetMethod(typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy2.TryGetMethod(typeof(TestClass), "TestMethod"),
            () => StaticReflectionCache .TryGetMethod(typeof(TestClass), "TestMethod")
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                MethodInfo method = func();
                AssertMethod(method);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetMethod_Test_WithArgTypes()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        // NOTE:It's pretty strict that you must supply parameter types.
        Func<MethodInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => StaticReflectionCache .GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy .TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => StaticReflectionCache .TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                MethodInfo method2 = func();
                AssertMethod2(method2);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetMethod_NotFound_Throws()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetMethod(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy .GetMethod(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.GetMethod(typeof(TestClass), NonExistentName),
        ];

        foreach (var action in synonyms)
        {
            ThrowsExceptionContaining(action, "Method", "not found");
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetMethod_NotFound_ReturnsNull()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<MethodInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetMethod(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.TryGetMethod(typeof(TestClass), NonExistentName),
            () => StaticReflectionCache .TryGetMethod(typeof(TestClass), NonExistentName),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                MethodInfo method = func();
                IsNull(() => method);
            }
        }
    }
    
    // Methods

    [TestMethod]
    public void ReflectionCache_GetMethods()
    {
        var reflectionCacheLegacy = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<IList<MethodInfo>>[] synonyms =
        [
            () => reflectionCacheLegacy .GetMethods(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetMethods(typeof(TestClass)),
            () => StaticReflectionCache .GetMethods(typeof(TestClass), BINDING_FLAGS_ALL)
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                IList<MethodInfo> methods = func();
                IsNotNull(() => methods);

                MethodInfo? method = methods.FirstOrDefault(x => x.Name == "TestMethod");
                AssertMethod(method);
                
                MethodInfo? method2 = methods.FirstOrDefault(x => x.Name == "TestMethod2");
                AssertMethod2(method2);
            }
        }
    }
    
    // Method Assertion

    private static void AssertMethod(MethodInfo? method)
    {
        NotNull(method);
        AreEqual("TestMethod", method.Name);
        AreEqual(typeof(int),  method.ReturnType);
        
        var parameters = method.GetParameters();
        IsNotNull(() => parameters);
        AreEqual(0, () => parameters.Length);
    }
    
    private static void AssertMethod2(MethodInfo? method2)
    {
        NotNull(method2);
        AreEqual("TestMethod2",  method2.Name);
        AreEqual(typeof(string), method2.ReturnType);
        
        var parameters = method2.GetParameters();
        AreEqual(2,              () => parameters.Length);
        AreEqual(typeof(int),    () => parameters[0].ParameterType);
        AreEqual(typeof(string), () => parameters[1].ParameterType);
    }
}

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
public class ReflectionCache_IndexerCoreTests
{
    [TestMethod]
    public void ReflectionCache_GetIndexer_Test_1Arg()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy2.GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
            () => StaticReflectionCache .GetIndexer   (typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy .TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
            () => reflectionCacheLegacy2.TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
            () => StaticReflectionCache .TryGetIndexer(typeof(ClassWithIndexers), typeof(int)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo indexer = func();
                AssertIndexer1(indexer);
            }
        }
    }

    [TestMethod]
    public void ReflectionCache_GetIndexer_Test_2Arg()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);


        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => StaticReflectionCache .GetIndexer   (typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy .TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
            () => StaticReflectionCache .TryGetIndexer(typeof(ClassWithIndexers), typeof(int), typeof(string)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo indexer2 = func();
                AssertIndexer2(indexer2);
            }
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetIndexer_NotFound_Throws()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetIndexer(typeof(ClassWithoutIndexer), typeof(int)),
            () => reflectionCacheLegacy .GetIndexer(typeof(ClassWithoutIndexer), typeof(int)),
            () => reflectionCacheLegacy2.GetIndexer(typeof(ClassWithoutIndexer), typeof(int)),
        ];

        foreach (var action in synonyms)
        {
            ThrowsExceptionContaining(action, "Indexer not found");
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetIndexer_NotFound_ReturnsNull()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);

        Func<PropertyInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetIndexer(typeof(ClassWithoutIndexer), typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.TryGetIndexer(typeof(ClassWithoutIndexer), typeof(int), typeof(string)),
            () => StaticReflectionCache .TryGetIndexer(typeof(ClassWithoutIndexer), typeof(int), typeof(string)),
        ];

        foreach (var func in synonyms)
        {
            for (int i = 0; i < Repeats; i++)
            {
                PropertyInfo indexer = func();
                IsNull(() => indexer);
            }
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
    
    // Constructor Tests
    
}

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
public class ReflectionCache_Constructor_CoreTests
{
    [TestMethod]
    public void ReflectionCache_GetConstructor_Single()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < Repeats; i++)
        {
            ConstructorInfo constructor = reflectionCache.GetConstructor(typeof(TestClass));
            IsNotNull(() => constructor);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_GetConstructor_None_Throws()
    {
        var reflectionCache = new ReflectionCache(Public | Instance);
        
        for (int i = 0; i < Repeats; i++)
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
        
        for (int i = 0; i < Repeats; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetConstructor(typeof(MultipleConstructorsClass)), 
                "Multiple constructors found");
        }
    }
}

[TestClass]
[Suppress("Trimmer", "IL2026", Justification = GetTypes + " " + ArrayInit)]
public class ReflectionCache_Type_CoreTests
{
    // GetTypeByShortName
    
    [TestMethod]
    public void ReflectionCache_GetTypeByShortName_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < Repeats; i++)
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
        
        for (int i = 0; i < Repeats; i++)
        {
            ThrowsExceptionContaining(
                () => reflectionCache.GetTypeByShortName(NonExistentName),
                "Type with short name", "not found");
        }
    }
        
    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_Test()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < Repeats; i++)
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
        
        for (int i = 0; i < Repeats; i++)
        {
            Type type = reflectionCache.TryGetTypeByShortName(NonExistentName);
            IsNull(() => type);
        }
    }
    
    [TestMethod]
    public void ReflectionCache_TryGetTypeByShortName_Multiple_Throws()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < Repeats; i++)
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
        
        for (int i = 0; i < Repeats; i++)
        {
            IList<Type> types = reflectionCache.GetTypesByShortName(NonExistentName);
            
            IsNotNull(() => types);
            AreEqual(0, () => types.Count);
        }
    }
        
    [TestMethod]
    public void ReflectionCache_GetTypesByShortName_Single()
    {
        var reflectionCache = new ReflectionCache(BINDING_FLAGS_ALL);
        
        for (int i = 0; i < Repeats; i++)
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
        
        for (int i = 0; i < Repeats; i++)
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
