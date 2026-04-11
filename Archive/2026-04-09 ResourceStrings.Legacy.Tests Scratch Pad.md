```cs

        /*
        ThrowIfNull(objFunc);
        object obj = objFunc();
        ThrowIfNull(obj);
        Type actual = obj.GetType();
        */

        //Type actual = objFunc?.Invoke()?.GetType();
        //ThrowIfNull(prop);
        //ThrowIfNull(method);
        //ThrowIfNull(parameters);
        //ThrowIfNull(method);
        //ThrowIfNull(method.Name);
        //string typeName = func?.Invoke()?.GetType().Name ?? "<null>";

        /*
        private static void LogEmptyLine()
        { 
            Trace.WriteLine("");
        }
        */
            //Trace.WriteLine(@$"Prop {prop.Name} = ""{text}""");
            //Trace.WriteLine(@$"Prop {prop.Name} = ""{text}""");


    // Direct Instantiation (Base Class Usage Without Inheritance)

    /*
    [TestMethod]
    public void ResourceStringTester_DirectInstance_MethodsWork()
    {
        var tester = new ResourceStringTester(typeof(Stub_ZeroParams), known: ["nl-NL"], unknown: "de-DE", @default: "en-US");
        tester.AssertAllMembers();
    }

    [TestMethod]
    public void ResourceStringTester_DirectInstance_WithParameters_ContainmentWorks()
    {
        var tester = new ResourceStringTester(typeof(Stub_OneParam), known: ["nl-NL"], unknown: "de-DE", @default: "en-US");
        tester.AssertAllMembers();
    }

    [TestMethod]
    public void ResourceStringTester_DirectInstance_ExcludesDefaultMembers()
    {
        var tester = new ResourceStringTester(typeof(Stub_PropertyBased), known: ["nl-NL"], unknown: "de-DE", @default: "en-US");
        tester.AssertAllMembers();
    }

    [TestMethod]
    public void ResourceStringTester_DirectInstance_MixedMembersWork()
    {
        var tester = new ResourceStringTester(typeof(Stub_MixedMembers), known: ["nl-NL"], unknown: "de-DE", @default: "en-US");
        tester.AssertAllMembers();
    }
    */

    private static class Stub_PropertyBased
    {
        public static string Title { get; } = "Main Title";
        public static string Description { get; } = "A description";
    }
```