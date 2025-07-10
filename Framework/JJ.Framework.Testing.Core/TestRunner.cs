// ReSharper disable VariableHidesOuterVariable

namespace JJ.Framework.Testing.Core;

/// <inheritdoc cref="_testrunner" />
public static class TestRunner
{
    [NoTrim(MisingTypes)]
    public static IList<string> RunTests() => RunTests(GetExecutingAssembly());

    [NoTrim(MisingTypes)]
    public static IList<string> RunTests(Assembly assembly) => RunTests(GetTestClasses(assembly));

    [NoTrim(MisingTypes)]
    public static Type[] GetTestClasses(Assembly assembly)
    {
        ThrowIfNull(assembly);
        return assembly.GetTypes().Where(IsTestClass).ToArray();
    }

    [NoTrim(TypeArray)]
    public static IList<string> RunTests(Type[] testClasses)
    {
        ThrowIfNull(testClasses);
        return RunTests(testClasses, [ ]);
    }

    [NoTrim(TypeArray)]
    private static IList<string> RunTests(Type[] testClasses, List<string> messages)
    {
        foreach (Type testClass in testClasses)
        {
            ThrowIfNull(testClass);
            RunTests(testClass, messages);
        }

        return messages;
    }

    public static IList<string> RunTests<[Dyn(PublicMethods | DefaultCtor)] T>() => RunTests(typeof(T));

    public static IList<string> RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass)
    {
        ThrowIfNull(testClass);
        return RunTests(testClass, [ ]);
    }

    private static IList<string> RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass, List<string> messages)
    {
        messages.Add($"Running tests in {testClass.Name}...");

        var methods = testClass.GetMethods(Public | Instance).Where(IsTestMethod).ToArray();
        
        foreach (MethodInfo method in methods)
        {
            try
            {
                object? instance = CreateInstance(testClass);
                if (instance == null)
                {
                    messages.Add($"{method.Name} failed: Could not create instance of {testClass.Name}.");
                    continue;
                }
                method.Invoke(instance, null);
                messages.Add($"{method.Name} passed.");
            }
            catch (Exception ex)
            {
                messages.Add($"{method.Name} failed: {ex}");
            }
        }

        return messages;
    }
    
    private static bool IsTestClass(Type x) => x.GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestClass"));

    private static bool IsTestMethod(MethodInfo x) => x.GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestMethod"));
}