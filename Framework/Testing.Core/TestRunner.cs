// ReSharper disable VariableHidesOuterVariable


using static System.Console;
// ReSharper disable AccessToModifiedClosure

namespace JJ.Framework.Testing.Core;

/// <inheritdoc cref="_testrunner" />
public static class TestRunner
{
    // Is
   
    public static bool IsTestClass(Type type)
        => NotNull(type).GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestClass"));

    public static bool IsTestMethod(MethodInfo method) 
        => NotNull(method).GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestMethod"));

    // TODO: Use this to stop parallelism, but also on assembly and method level, they can be defined.
    private static bool DoesNotParallelize(Type type)
        => NotNull(type).GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("DoNotParallelize"));

    // Get

    [TrimWarn(GetTypes)]
    public static ICollection<Type> GetTestClasses(Assembly assembly) 
        => NotNull(assembly).GetExportedTypes().Where(IsTestClass).ToArray();
        
    public static ICollection<MethodInfo> GetTestMethods([Dyn(PublicMethods)] Type testClass)
    {
        ThrowIfNull(testClass);
        return testClass.GetMethods(Public | Instance).Where(IsTestMethod).ToArray();
    }

    // Run

    [TrimWarn(GetTypes)] public static bool RunTests() => RunTests(GetCallingAssembly());
    [TrimWarn(GetTypes)] public static bool RunTests(Assembly assembly) => RunTests(GetTestClasses(assembly));
    [TrimWarn(TypeColl)] public static bool RunTests(ICollection<Type> testClasses)
    {
        bool success = true;
        NotNull(testClasses);

        var loop = Parallel.ForEach(testClasses, testClass =>
        {
            success &= RunTests(testClass);
        });

        success &= loop.IsCompleted;

        return success;
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

    private static bool RunTests([Dyn(New| PublicMethods)] Type testClass, ICollection<MethodInfo> methods)
    {
        bool success = true;
        ThrowIfNull(methods);

        var loop = Parallel.ForEach(methods, method =>
        {
            success &= RunTest(testClass, method);
        });

        success &= loop.IsCompleted;

        return success;
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