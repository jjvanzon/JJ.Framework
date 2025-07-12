// ReSharper disable VariableHidesOuterVariable


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

    [NoTrim(GetTypes)] public static IResult RunTests() => RunTests(GetCallingAssembly());
    [NoTrim(GetTypes)] public static IResult RunTests(Assembly assembly) => RunTests(GetTestClasses(assembly));

    [NoTrim(TypeCollection)] public static IResult RunTests(ICollection<Type> testClasses) => RunTests(testClasses, new Result());
    [NoTrim(TypeCollection)] public static IResult RunTests(ICollection<Type> testClasses, IResult result)
    {
        NotNull(testClasses).NotNull(result);
        testClasses.ForEach(x => RunTests(x, result));
        return result;
    }


    public static IResult RunTests<[Dyn(New| PublicMethods)] T>() => RunTests(typeof(T));
    public static IResult RunTests<[Dyn(New| PublicMethods)] T>(IResult result) => RunTests(typeof(T), result);
    public static IResult RunTests([Dyn(New| PublicMethods)] Type testClass) => RunTests(NotNull(testClass), new Result());
    public static IResult RunTests([Dyn(New| PublicMethods)] Type testClass, IResult result)
    {
        ThrowIfNull(testClass);
        ThrowIfNull(result);
        result.Messages.Add($"Running {testClass.Name}...");
        ICollection<MethodInfo> methods = GetTestMethods(testClass);
        RunTests(testClass, methods, result);
        result.Messages.Add(""); // Blank line for pretty logs.
        return result;
    }

    //public static void RunTests(ICollection<MethodInfo> methods, IResult result)
    //    => NotNull(methods).ForEach(x => RunTest(x, result));

    //public static void RunTest(MethodInfo method, IResult result) 
    //    => RunTest(NotNull(method.DeclaringType), method, result);

    private static void RunTests([Dyn(New| PublicMethods)] Type testClass, ICollection<MethodInfo> methods, IResult result)
        => NotNull(methods).ForEach(x => RunTest(testClass, x, result));

    private static void RunTest([Dyn(New| PublicMethods)] Type testClass, MethodInfo method, IResult result)
    {
        try
        {
            NotNull(method).NotNull(result);
            object instance = CreateTestInstance(testClass);
            method.Invoke(instance, null);
            result.Messages.Add($"{method.Name} passed.");
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Messages.Add($"{method.Name} failed: {ex}");
        }
    }

    private static object CreateTestInstance([Dyn(New)] Type testClass)
    {
        object? instance = CreateInstance(testClass);
        ThrowIfNull(instance);
        return instance;
    }
}