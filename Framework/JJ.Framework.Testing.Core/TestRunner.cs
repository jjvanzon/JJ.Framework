// ReSharper disable VariableHidesOuterVariable

namespace JJ.Framework.Testing.Core;

/// <inheritdoc cref="_testrunner" />
public static class TestRunner
{
    [NoTrim(TypesMising)]
    public static IList<string> RunTests() => RunTests(GetCallingAssembly());

    [NoTrim(TypesMising)]
    public static IList<string> RunTests(Assembly assembly) => RunTests(GetTestClasses(assembly));

    [NoTrim(TypesMising)]
    public static Type[] GetTestClasses(Assembly assembly) => NotNull(assembly).GetTypes().Where(IsTestClass).ToArray();

    [NoTrim(TypeArray)]
    public static IList<string> RunTests(Type[] testClasses) => RunTests(NotNull(testClasses), [ ]);

    [NoTrim(TypeArray)]
    private static IList<string> RunTests(Type[] testClasses, List<string> messages)
    {
        foreach (var testClass in testClasses)
        {
            RunTests(testClass, messages);
        }

        return messages;
    }

    public  static IList<string> RunTests<[Dyn(PublicMethods | DefaultCtor)] T>() => RunTests(typeof(T));
    public  static IList<string> RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass) => RunTests(NotNull(testClass), [ ]);
    private static IList<string> RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass, List<string> messages)
    {
        NotNull(testClass);

        messages.Add($"Running {testClass.Name}...");

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