// ReSharper disable VariableHidesOuterVariable


using static System.Console;

namespace JJ.Framework.Testing.Core;

/// <inheritdoc cref="_testrunner" />
public static class TestRunner
{
    // Is
   
    public static bool IsTestClass(Type type)
        => NotNull(type).GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestClass"));

    public static bool IsTestMethod(MethodInfo method) 
        => NotNull(method).GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestMethod"));

    // Get

    [NoTrim(GetTypes)]
    public static ICollection<Type> GetTestClasses(Assembly assembly) 
        => NotNull(assembly).GetExportedTypes().Where(IsTestClass).ToArray();
        
    public static ICollection<MethodInfo> GetTestMethods([Dyn(PublicMethods)] Type testClass)
    {
        ThrowIfNull(testClass);
        return testClass.GetMethods(Public | Instance).Where(IsTestMethod).ToArray();
    }

    // Run

    [NoTrim(GetTypes)] public static bool RunTests() => RunTests(GetCallingAssembly());
    [NoTrim(GetTypes)] public static bool RunTests(Assembly assembly) => RunTests(GetTestClasses(assembly));

    [NoTrim(TypeColl)] public static bool RunTests(ICollection<Type> testClasses)
    {
        NotNull(testClasses);
        foreach (var testClass in testClasses)
        {
            if (!RunTests(testClass)) return false;
        }
        return true;
    }


    public static bool RunTests<[Dyn(New| PublicMethods)] T>() => RunTests(typeof(T));
    public static bool RunTests([Dyn(New| PublicMethods)] Type testClass)
    {
        ThrowIfNull(testClass);
        WriteLine($"Running {testClass.Name}...");
        ICollection<MethodInfo> methods = GetTestMethods(testClass);
        if (!RunTests(testClass, methods)) return false;
        WriteLine(""); // Blank line for pretty logs.
        return true;
    }

    //public static void RunTests(ICollection<MethodInfo> methods)
    //    => NotNull(methods).ForEach(x => RunTest(x, result));

    //public static void RunTest(MethodInfo method) 
    //    => RunTest(NotNull(method.DeclaringType), method, result);

    private static bool RunTests([Dyn(New| PublicMethods)] Type testClass, ICollection<MethodInfo> methods)
    {
        ThrowIfNull(methods);
        foreach (var method in methods)
        {
            if (!RunTest(testClass, method)) return false;
        }
        return true;
    }

    private static bool RunTest([Dyn(New| PublicMethods)] Type testClass, MethodInfo method)
    {
        try
        {
            NotNull(method);
            object instance = CreateTestInstance(testClass);
            method.Invoke(instance, null);
            WriteLine($"{method.Name} passed.");
            return true;
        }
        catch (Exception ex)
        {
            WriteLine();
            WriteLine($"{method.Name} failed: {ex}");
            WriteLine();
            return false;
        }
    }

    private static object CreateTestInstance([Dyn(New)] Type testClass)
    {
        object? instance = CreateInstance(testClass);
        ThrowIfNull(instance);
        return instance;
    }
}