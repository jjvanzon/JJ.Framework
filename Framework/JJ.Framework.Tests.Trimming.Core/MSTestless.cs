// ReSharper disable once CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    internal class TestClassAttribute : Attribute;
    internal class TestMethodAttribute : Attribute;

    internal static class Assert
    {
        public static void AreEqual<T>(T expected, T actual)
            => AssertCore.AreEqual(expected, actual);
    }
}

internal static class MSTestlessRunner
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

    public static void RunTests([Dyn(PublicMethods | PublicParameterlessConstructor)] Type testClass)
    {
        var methods = testClass.GetMethods(Public | Instance)
                               .Where(x => x.GetCustomAttribute<TestMethodAttribute>() != null)
                               .ToArray();

        foreach (MethodInfo method in methods)
        {
            try
            {
                object? instance = Activator.CreateInstance(testClass);
                method.Invoke(instance, null);
                WriteLine($"Test {testClass.Name}.{method.Name} passed.");
            }
            catch (Exception ex)
            {
                WriteLine($"Test {testClass.Name}.{method.Name} failed: {ex.Message}");
            }
        }
    }
}