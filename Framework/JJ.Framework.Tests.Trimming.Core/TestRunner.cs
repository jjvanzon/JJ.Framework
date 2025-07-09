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

    public static void RunTests<[Dyn(PublicMethods | DefaultCtor)] T>()
        => RunTests(typeof(T));

    public static void RunTests([Dyn(PublicMethods | DefaultCtor)] Type testClass)
    {
        WriteLine($"Running tests in {testClass.Name}...");

        var methods = testClass.GetMethods(Public | Instance)
                               .Where(x => x.GetCustomAttribute<TestMethodAttribute>() != null)
                               .ToArray();

        foreach (MethodInfo method in methods)
        {
            try
            {
                object instance = Activator.CreateInstance(testClass);
                method.Invoke(instance, null);
                WriteLine($"{method.Name} passed.");
            }
            catch (Exception ex)
            {
                WriteLine($"{method.Name} failed: {ex}");
            }
        }
    }
}