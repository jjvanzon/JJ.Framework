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

```xml
    <type fullname="JJ.Framework.ResourceStrings.Legacy.Tests.Untrimmer" preserve="all">
      <method name="Untrim" />
    </type>
```

```cs
namespace JJ.Framework.ResourceStrings.Legacy.Tests;

internal class Untrimmer
{
    public static void Untrim()
    {
        
    }
}


    [TestMethod]
    public void StringResourceTester_Inheritance_CustomSelection_SelectsSpecificMembers() 
        => new InheritedTester_WithCustomSelection().AssertAllMembers();

    private class InheritedTester_WithCustomSelection()
        : StringResourceTester(
            typeof(ResourceClass_WithProblematic), 
            known: ["nl-NL", ""], unknown: "de-DE", @default: "en-US")
    {
        protected override IList<MemberInfo> SelectMembersToTest([Dyn(PubProps|PubMethods)] Type resourceClass)
            => base.SelectMembersToTest(resourceClass)
                   .Where(x => x.Name.StartsWith("Good"))
                   .ToArray();
    }


    if (string.Equals(memberToTest.Name, "Equals", OrdinalIgnoreCase))
    {
        return false;
    }

    /// <inheritdoc cref="_portedstubs" />
    public static object GetValue(this PropertyInfo prop)
    {
        return prop.GetValue(null);
    }

    /// <inheritdoc cref="_portedstubs" />
    public static object Invoke(this MethodBase method, object[] parameters)
    {
        return method.Invoke(null, parameters);
    }


    [TestMethod]
    public void StringResourceTester_NoLog_WithResourceObject_SuppressesTraceOutput()
    {
        IResources resourceObject = new InstanceResources();

        var tester = new StringResourceTester(
            typeof(InstanceResources), resourceObject,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog);

        string trace = CaptureTrace(tester.AssertAllMembers);

        AreEqual("", trace);
    }
```


```cs

    // Generic StringResourceTester<T>

    [TestMethod]
    public void StringResourceTesterOfT_StaticMembers()
        => new StringResourceTester<ResourceClass_OneParam>(
            known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US").AssertAllMembers();

    [TestMethod]
    public void StringResourceTesterOfT_MixedMembers()
        => new StringResourceTester<ResourceClass_MixedMembers>(
            known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US").AssertAllMembers();

    [TestMethod]
    public void StringResourceTesterOfT_WithResourceObject()
    {
        var resourceObject = new InstanceResources();

        new StringResourceTester<InstanceResources>(
            resourceObject,
            known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US").AssertAllMembers();
    }

    [TestMethod]
    public void StringResourceTesterOfT_NoLog_SuppressesTraceOutput()
    {
        string trace = CaptureTrace(
            () => new StringResourceTester<ResourceClass_OneParam>(
                known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog).AssertAllMembers());

        AreEqual("", trace);
    }

    [TestMethod]
    public void StringResourceTesterOfT_UnknownCulture()
        => new StringResourceTester<ResourceClass_ThreeParams>(
            known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US").AssertUnknownCulture();
```


```cs

        [Suppress("Trimmer", "IL2070", Justification = "Constructor optional")]
        private static bool TypeIsStatic(Type type) 
            => type.IsAbstract && 
               type.IsSealed &&
               type.GetConstructors().Length == 0;


    // Non-static stubs for StringResourceTester<T> (static types can't be type arguments)

    /*
    public class GenericStub_1Arg
    {
        public static string Greet(string name) => $"Hello {name}";
    }

    public class GenericStub_Mixed
    {
        public static string Title => "Title";
        public static string Greeting(string name) => "Hello " + name;
        public static string Message() => "A message";
    }

    public class GenericStub_3Args
    {
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }
    */


    // Constructors, Generic and NoLog Options

    [TestMethod]
    public void StringResourceTester_Constructor_Syntaxes_NoLog_SuppressesTraceOutput()
    {
        var testers = new StringResourceTester[]
        {
            new (typeof(ResourceClass_1Arg_StaticInstantiable),                     
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
            new (typeof(ResourceClass_1Arg_StaticInstantiable),                     
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
            new (typeof(ResourceClass_InstanceWithInterface), new ResourceClass_InstanceWithInterface(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
            new (typeof(ResourceClass_InstanceWithInterface), new ResourceClass_InstanceWithInterface(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>( 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>( 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(new(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(new(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(new ResourceClass_1Arg_StaticInstantiable(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(new ResourceClass_1Arg_StaticInstantiable(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true)
        };

        foreach (var tester in testers)
        {
            string trace = CaptureTrace(tester.AssertAllMembers);
            AreEqual("", trace);
        }
    }

    [TestMethod]
    public void StringResourceTester_Constructor_Syntaxes_WithLog_ProducesTraceOutput()
    {
        var testers = new StringResourceTester[]
        {
            new (typeof(ResourceClass_1Arg_StaticInstantiable),                     
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
            new (typeof(ResourceClass_1Arg_StaticInstantiable),                    
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
            new (typeof(ResourceClass_InstanceWithInterface), new ResourceClass_InstanceWithInterface(),
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
            new (typeof(ResourceClass_InstanceWithInterface), new ResourceClass_InstanceWithInterface(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(new(),
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(new(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(new ResourceClass_1Arg_StaticInstantiable(),
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
            new StringResourceTester<ResourceClass_1Arg_StaticInstantiable>(new ResourceClass_1Arg_StaticInstantiable(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false)
        };

        foreach (var tester in testers)
        {
            string trace = CaptureTrace(tester.AssertAllMembers);
            NotNullOrWhiteSpace(trace);
        }
    }

    // Parameter Counts

    [TestMethod]
    public void StringResourceTester_Instance_0Args_ReturnsText() 
        => CreateDefaultTester(typeof(ResourceClass_0Arg_Static)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_1Arg_AppearsInResult() 
        => CreateDefaultTester(typeof(ResourceClass_1Arg_StaticInstantiable)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_2Args_AppearInResult() 
        => CreateDefaultTester(typeof(ResourceClass_2Arg_Static)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_3Args_AppearInResult() 
        => CreateDefaultTester(typeof(ResourceClass_3Arg_StaticInstantiable)).AssertAllMembers();


    // Unknown Culture Fallback (param handling)

    [TestMethod]
    public void StringResourceTester_UnknownCulture_ParamHandling()
        => CreateDefaultTester(typeof(ResourceClass_3Arg_StaticInstantiable)).AssertUnknownCulture();
```