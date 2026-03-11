// ReSharper disable RedundantArgumentDefaultValue

namespace JJ.Framework.Reflection.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class ReflectionCache_Method_CoreTests
{
    // Method
    
    [TestMethod]
    public void ReflectionCache_GetMethod_Test()
    {
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(Public | Instance);

        Func<MethodInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetMethod   (typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy2.GetMethod   (typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy3.GetMethod   (typeof(TestClass), "TestMethod"),
            () => StaticReflectionCache .GetMethod   (typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy .TryGetMethod(typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy2.TryGetMethod(typeof(TestClass), "TestMethod"),
            () => reflectionCacheLegacy3.TryGetMethod(typeof(TestClass), "TestMethod"),
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
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(Public | Instance);

        // NOTE:It's pretty strict that you must supply parameter types.
        Func<MethodInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy3.GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => StaticReflectionCache .GetMethod   (typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy .TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy2.TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
            () => reflectionCacheLegacy3.TryGetMethod(typeof(TestClass), "TestMethod2", typeof(int), typeof(string)),
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
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(Public | Instance);

        Action[] synonyms =
        [
            () => StaticReflectionCache .GetMethod(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy .GetMethod(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.GetMethod(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy3.GetMethod(typeof(TestClass), NonExistentName),
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
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(Public | Instance);

        Func<MethodInfo>[] synonyms =
        [
            () => reflectionCacheLegacy .TryGetMethod(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy2.TryGetMethod(typeof(TestClass), NonExistentName),
            () => reflectionCacheLegacy3.TryGetMethod(typeof(TestClass), NonExistentName),
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
        var reflectionCacheLegacy  = new ReflectionCacheLegacy();
        var reflectionCacheLegacy2 = new ReflectionCacheLegacy(BINDING_FLAGS_ALL);
        var reflectionCacheLegacy3 = new ReflectionCacheLegacy(Public | Instance);

        Func<IList<MethodInfo>>[] synonyms =
        [
            () => reflectionCacheLegacy .GetMethods(typeof(TestClass)),
            () => reflectionCacheLegacy2.GetMethods(typeof(TestClass)),
            () => reflectionCacheLegacy3.GetMethods(typeof(TestClass)),
            () => StaticReflectionCache .GetMethods(typeof(TestClass), BINDING_FLAGS_ALL),
            () => StaticReflectionCache .GetMethods(typeof(TestClass), Public | Instance)
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