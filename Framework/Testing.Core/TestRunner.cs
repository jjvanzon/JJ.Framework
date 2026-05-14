// ReSharper disable VariableHidesOuterVariable


using static System.Console;
using static System.StringComparison;

// ReSharper disable AccessToModifiedClosure

namespace JJ.Framework.Testing.Core;

/// <inheritdoc cref="_testrunner" />
public static class TestRunner
{
    // Is
   
    public static bool IsTestClass(Type type)
        => NotNull(type).GetCustomAttributes().Any(x => x.GetType().Name.Equals("TestClassAttribute", Ordinal));

    public static bool IsTestMethod(MethodInfo method) 
        => NotNull(method).GetCustomAttributes().Any(x => x.GetType().Name.Equals("TestMethodAttribute", Ordinal));

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

        var loop = Parallel.ForEach(testClasses.ToArray(), testClass =>
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

        var opt = GetParallelOptions(testClass);

        var loop = Parallel.ForEach(methods.ToArray(), opt, method =>
        {
            success &= RunTest(testClass, method);
        });

        success &= loop.IsCompleted;

        return success;
    }

    private static bool RunTest([Dyn(New| PublicMethods)] Type testClass, MethodInfo method)
    {
        object? instance = null;
        try
        {
            NotNull(method);
            instance = CreateTestInstance(testClass);
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
        finally
        {
            CleanUpTestInstance(instance);
        }
    }

    private static object CreateTestInstance([Dyn(New)] Type testClass)
    {
        object? instance = CreateInstance(testClass);
        ThrowIfNull(instance);
        return instance;
    }

    private static void CleanUpTestInstance(object? instance) 
        => (instance as IDisposable)?.Dispose();

    /*
    private static void CleanUpTestInstance(object? instance)
    {
        if (instance is IDisposable disposable) disposable.Dispose();
    }
    */

    /*
    private static void CleanUpTestInstance(Type testClass, object? instance)
    {
        if (instance == null) return;

        if (testClass.IsAssignableTo(typeof(IDisposable)))
        {
           var disposable = (IDisposable)instance;
           disposable.Dispose();
        }
    }
    */

    // Parallelism

    private static ParallelOptions GetParallelOptions(Type type)
    {
        if (DoNotParallelize(type)) 
        {
            return new ParallelOptions { MaxDegreeOfParallelism = 1 };
        }

        return new();
    }

    private static bool DoNotParallelize(Assembly assembly)
        => NotNull(assembly).GetCustomAttributes().Any(x => x.GetType().Name.Equals("DoNotParallelizeAttribute", Ordinal));

    private static bool DoNotParallelize(Type type)
        => NotNull(type).GetCustomAttributes().Any(x => x.GetType().Name.Equals("DoNotParallelizeAttribute", Ordinal)) ||
           DoNotParallelize(type.Assembly);
}