namespace JJ.Framework.Tests.Trimming.Core;

internal static class TestRunner
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
    //        WriteLine($"Running tests in {testClass.Name}...");
    //        RunTests(testClass);
    //    }
    //}

    //[NoTrim("Types might be removed")]
    //public static Type[] GetTestClasses(Assembly assembly) 
    //    => assembly.GetTypes()
    //             //.Where(x => x.Name.EndsWith("Tests"))
    //               .Where(x => x.GetCustomAttribute<TestClassAttribute>() != null)
    //               .ToArray();

    // TODO: Move somewhere centrally.
    private const DynamicallyAccessedMemberTypes DefaultCtor = DynamicallyAccessedMemberTypes.PublicParameterlessConstructor;

    public static void RunTests<[Dyn(PublicMethods | DefaultCtor)] T>()
        => RunTests(typeof(T));

    public static void RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass)
    {
        var methods = testClass.GetMethods(Public | Instance)
                               .Where(x => x.GetCustomAttribute<TestMethodAttribute>() != null)
                               .ToArray();

        foreach (MethodInfo method in methods)
        {
            try
            {
                object instance = Activator.CreateInstance(testClass);
                method.Invoke(instance, null);
                WriteLine($"Test {method.Name} passed.");
            }
            catch (Exception ex)
            {
                WriteLine($"Test {method.Name} failed: {ex}");
            }
        }
    }
}