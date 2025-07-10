// ReSharper disable VariableHidesOuterVariable

namespace JJ.Framework.Testing.Core;

/// <inheritdoc cref="_testrunner" />
public static class TestRunner
{
    [NoTrim(TypesMising)]
    public static IResult RunTests() => RunTests(GetCallingAssembly());

    [NoTrim(TypesMising)]
    public static IResult RunTests(Assembly assembly) => RunTests(GetTestClasses(assembly));

    [NoTrim(TypesMising)]
    public static Type[] GetTestClasses(Assembly assembly) => NotNull(assembly).GetExportedTypes().Where(IsTestClass).ToArray();

    [NoTrim(TypeArray)]
    public static IResult RunTests(Type[] testClasses) => RunTests(testClasses, new Result());

    [NoTrim(TypeArray)]
    public static IResult RunTests(Type[] testClasses, IResult result)
    {
        NotNull(result);
        NotNull(testClasses);

        foreach (var testClass in testClasses)
        {
            RunTests(testClass, result);
        }

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

        MethodInfo[] methods = testClass.GetMethods(Public | Instance).Where(IsTestMethod).ToArray();
        foreach (MethodInfo method in methods)
        {
            try
            {
                object? instance = CreateInstance(testClass);
                if (instance == null)
                {
                    result.Success = false;
                    result.Messages.Add($"{method.Name} failed: Could not create instance of {testClass.Name}.");
                    continue;
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

        return result;
    }
    
    private static bool IsTestClass(Type x) => x.GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestClass"));
    private static bool IsTestMethod(MethodInfo x) => x.GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestMethod"));
}