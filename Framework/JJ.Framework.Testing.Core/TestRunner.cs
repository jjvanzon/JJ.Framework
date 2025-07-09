// ReSharper disable VariableHidesOuterVariable

namespace JJ.Framework.Testing.Core;

/// <inheritdoc cref="_testrunner" />
public static class TestRunner
{
    //public static void RunTests()
    //{
    //    Assembly assembly = Assembly.GetExecutingAssembly();
    //    RunTests(assembly);
    //}

    //[NoTrim("Types might be removed")]
    //public static void RunTests(Assembly assembly)
    //{
    //    Type[] testClasses = GetTestClasses(assembly);
    //    RunTests(testClasses);
    //}

    //[NoTrim("Types might be removed")]
    //public static void RunTests(Type[] testClasses)
    //{
    //    foreach (Type testClass in testClasses)
    //    {
    //        RunTests(testClass);
    //    }
    //}

    [NoTrim("Types might be removed")]
    public static Type[] GetTestClasses(Assembly assembly)
    {
        ThrowIfNull(assembly);
        return assembly.GetTypes()
            .Where(x => x.GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestClasws")))
            .ToArray();
    }

    public static IList<string> RunTests<[Dyn(PublicMethods | DefaultCtor)] T>()
        => RunTests(typeof(T));

    public static IList<string> RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass)
    {
        ThrowIfNull(testClass);

        var messages = new List<string>();
        
        messages.Add($"Running tests in {testClass.Name}...");

        var methods = testClass.GetMethods(Public | Instance)
                               .Where(x => x.GetCustomAttributes().Any(x => x.GetType().Name.StartsWith("TestMethod")))
                               .ToArray();

        foreach (MethodInfo method in methods)
        {
            try
            {
                object? instance = Activator.CreateInstance(testClass);
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
}