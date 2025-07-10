// ReSharper disable VariableHidesOuterVariable


namespace JJ.Framework.Testing.Core;

/// <inheritdoc cref="_testrunner" />
public static class TestRunner
{
    [NoTrim(TypesMising)] public static IResult RunTests() => RunTests(GetCallingAssembly());
    [NoTrim(TypesMising)] public static IResult RunTests(Assembly assembly) => RunTests(GetTestClasses(assembly));

    [NoTrim(TypesMising)]
    public static ICollection<Type> GetTestClasses(Assembly assembly) 
        => NotNull(assembly).GetExportedTypes().Where(IsTestClass).ToArray();
    
    public static bool IsTestClass(Type type)
        => NotNull(type).GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestClass"));

    [NoTrim(TypeCollection)] public static IResult RunTests(ICollection<Type> testClasses) => RunTests(testClasses, new Result());
    [NoTrim(TypeCollection)] public static IResult RunTests(ICollection<Type> testClasses, IResult result)
    {
        NotNull(testClasses).NotNull(result);
        testClasses.ForEach(x => RunTests(x, result));
        return result;
    }

    public static IResult RunTests<[Dyn(PublicMethods | DefaultCtor)] T>() => RunTests(typeof(T));
    public static IResult RunTests<[Dyn(PublicMethods | DefaultCtor)] T>(IResult result) => RunTests(typeof(T), result);
    public static IResult RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass) => RunTests(NotNull(testClass), new Result());
    public static IResult RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass, IResult result)
    {
        NotNull(testClass);
        NotNull(result);
        result.Messages.Add($"Running {testClass.Name}...");
        var methods = GetTestMethods(testClass);
        RunTests(methods, result);
        result.Messages.Add("");
        return result;
    }

    public static void RunTests(ICollection<MethodInfo> methods, IResult result)
        => NotNull(methods).ForEach(x => RunTest(x, result));

    public static ICollection<MethodInfo> GetTestMethods(Type testClass) 
        => NotNull(testClass).GetMethods(Public | Instance).Where(IsTestMethod).ToArray();

    public static bool IsTestMethod(MethodInfo method) 
        => NotNull(method).GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestMethod"));

    public static void RunTest(MethodInfo method, IResult result)
    {
        NotNull(method).NotNull(result);
        Type testClass = NotNull(method.DeclaringType);
        try
        {
            object? instance = CreateInstance(testClass);
            if (instance == null)
            {
                result.Success = false;
                result.Messages.Add($"{method.Name} failed: Could not create instance of {testClass.Name}.");
                return;
            }

            method.Invoke(instance, null);
            result.Messages.Add($"{method.Name} passed.");
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Messages.Add($"{method.Name} failed: {ex}");
        }
    }
}