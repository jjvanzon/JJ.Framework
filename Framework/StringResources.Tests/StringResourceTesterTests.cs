namespace JJ.Framework.StringResources.Legacy.Tests;

[TestClass]
public class StringResourceTesterTests
{
    [TestMethod]
    public void StringResourceTester_Tests()
    {
        StringResourceTester[] testers = CreateTesters();
        foreach (var tester in testers)
        {
            string trace1 = CaptureTrace(tester.AssertAllMembers);
            NotNullOrWhiteSpace(trace1);

            string trace2 = CaptureTrace(tester.AssertUnknownCulture);
            NotNullOrWhiteSpace(trace2);
        }
    }

    // Parameter Counts

    [TestMethod]
    public void StringResourceTester_Instance_0Args_ReturnsText() 
        => CreateDefaultTester(typeof(ResourceClass_0ArgMethod_Static)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_1Arg_AppearsInResult() 
        => CreateDefaultTester(typeof(ResourceClass_1Arg_StaticInstantiable)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_2Args_AppearInResult() 
        => CreateDefaultTester(typeof(ResourceClass_2Args)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_3Args_AppearInResult() 
        => CreateDefaultTester(typeof(ResourceClass_3Args)).AssertAllMembers();

    // Parameter Types

    [TestMethod]
    public void StringResourceTester_Instance_VariousParamTypes_AppearInResult() 
        => CreateDefaultTester(typeof(ResourceClass_VariousArgTypes)).AssertAllMembers();

    // Mixed Props and Methods

    [TestMethod]
    public void StringResourceTester_Instance_MixedMembersWork() 
        => CreateDefaultTester(typeof(ResourceClass_MixedMembers)).AssertAllMembers();

    // Instance Resource Object

    [TestMethod]
    public void StringResourceTester_InstanceResourceClass_WithInterface()
    {
        IResources resourceObject = new InstanceResources();

        StringResourceTester resourceTester = new (
            typeof(InstanceResources), resourceObject, 
            known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US");

        resourceTester.AssertAllMembers();
    }


    // Unknown Culture Fallback (param handling)

    [TestMethod]
    public void StringResourceTester_UnknownCulture_ParamHandling()
        => CreateDefaultTester(typeof(ResourceClass_3Args)).AssertUnknownCulture();

    // Customization

    [TestMethod]
    public void StringResourceTester_Inheritance_MemberInclusion()
        => new InheritedTester_MemberInclusion().AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Inheritance_CustomTestValue_AppearsInResult() 
        => new InheritedTester_WithCustomGetArg().AssertAllMembers();

    // Failure Cases

    [TestMethod]
    public void StringResourceTester_MissingArgVal_Throws()
        => Throws(() => CreateDefaultTester(typeof(ResourceClass_MissingParam)).AssertAllMembers(), "not found in result");

    [TestMethod]
    public void StringResourceTester_WithoutExclusion_ProblematicMember_Throws()
        => Throws(() => CreateDefaultTester(typeof(ResourceClass_WithProblematic)).AssertAllMembers(), "Problematic");

    [TestMethod]
    public void StringResourceTester_UnsupportedType_Throws() 
        => Throws(() => CreateDefaultTester(typeof(ResourceClass_CustomType)).AssertAllMembers(), "could not", "generate", "value for parameter");

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
            new (typeof(InstanceResources), new InstanceResources(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
            new (typeof(InstanceResources), new InstanceResources(), 
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
            new (typeof(InstanceResources), new InstanceResources(),
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
            new (typeof(InstanceResources), new InstanceResources(), 
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

    // Helpers

    private StringResourceTester CreateDefaultTester([Dyn(PubPropMethod)] Type resourceClass)
        => new(resourceClass, known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US");

    private static string CaptureTrace(Action action)
    {
        using var writer = new StringWriter();
        var listener = new TextWriterTraceListener(writer);
        Trace.Listeners.Add(listener);
        try
        {
            action();
            Trace.Flush();
            return writer.ToString().Trim();
        }
        finally
        {
            Trace.Listeners.Remove(listener);
        }
    }

    private StringResourceTester[] CreateTesters()
    {
        var list = new List<StringResourceTester>(32);

        //list.AddRange(CreateTesters_WithTypeArg    <ResourceClass_0Arg_StaticInstantiable>());
        //list.AddRange(CreateTesters_WithType(typeof(ResourceClass_0Arg_StaticInstantiable)));
        //list.AddRange(CreateTesters_WithTypeArgAndObj(new ResourceClass_0Arg_StaticInstantiable()));
        //list.AddRange(CreateTesters_WithTypeAndObj(typeof(ResourceClass_0Arg_StaticInstantiable), new ResourceClass_0Arg_StaticInstantiable()));
        //list.AddRange(CreateTesters_WithObj (new    ResourceClass_0Arg_StaticInstantiable()));

        list.AddRange(CreateTesters_WithTypeArg    <ResourceClass_0Arg_Instance>());
        //list.AddRange(CreateTesters_WithType(typeof(ResourceClass_0Arg_Instance)));
        //list.AddRange(CreateTesters_WithObj (new    ResourceClass_0Arg_Instance()));

        //list.AddRange(CreateTesters_WithTypeArg    <ResourceClass_1Arg_Instance>());
        //list.AddRange(CreateTesters_WithType(typeof(ResourceClass_1Arg_Instance)));
        //list.AddRange(CreateTesters_WithObj (new    ResourceClass_1Arg_Instance()));

        //list.AddRange(CreateTesters_WithType(typeof(ResourceClass_1Arg_Static)));

        //list.AddRange(CreateTesters_WithTypeArg    <ResourceClass_1Arg_StaticInstantiable>());
        //list.AddRange(CreateTesters_WithType(typeof(ResourceClass_1Arg_StaticInstantiable)));
        //list.AddRange(CreateTesters_WithObj (new    ResourceClass_1Arg_StaticInstantiable()));

        //list.AddRange(CreateTesters_WithType(typeof(ResourceClass_2Args)));
        return list.ToArray();
    }

    private StringResourceTester[] CreateTesters_WithType([Dyn(PubPropMethod)] Type type) =>
    [
        new (type,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),

        new (type, 
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
    ];

    private StringResourceTester[] CreateTesters_WithTypeArg<[Dyn(PubPropMethod)] TResourceClass>() =>
    [
        new StringResourceTester<TResourceClass>(
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),

        new StringResourceTester<TResourceClass>(
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
    ];

    /*
    private StringResourceTester[] CreateTesters_WithObj(object obj) =>
    [
        new (obj,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),

        new (obj,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
    ];
    */

    private StringResourceTester[] CreateTesters_WithTypeAndObj([Dyn(PubPropMethod)] Type type, object obj) =>
    [
        new (type, obj,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),

        new (type, obj,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
    ];

    private StringResourceTester[] CreateTesters_WithTypeArgAndObj<[Dyn(PubPropMethod)] TResourceClass>(TResourceClass obj) =>
    [
        new (typeof(TResourceClass), obj,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),

        new (typeof(TResourceClass), obj,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),

        new StringResourceTester<TResourceClass>(obj,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),

        new StringResourceTester<TResourceClass>(obj, 
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),

        new StringResourceTester<TResourceClass>(obj,
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),

        new StringResourceTester<TResourceClass>(obj, 
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false)
    ];
    
    private StringResourceTester[] CreateTesters_WithType_NoLog<[Dyn(PubPropMethod)] TResourceClass>() =>
    [
        new (typeof(TResourceClass),                     
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),

        new (typeof(TResourceClass),                    
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),

        new StringResourceTester<TResourceClass>(
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),

        new StringResourceTester<TResourceClass>(
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
    ];

    private StringResourceTester[] CreateTesters_WithObj_NoLog<[Dyn(PubPropMethod)] TResourceClass>() 
        where TResourceClass : new() =>
    [
        new (typeof(TResourceClass), new TResourceClass(),
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),

        new (typeof(TResourceClass), new TResourceClass(), 
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),

        new StringResourceTester<TResourceClass>(new(),
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),

        new StringResourceTester<TResourceClass>(new(), 
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),

        new StringResourceTester<TResourceClass>(new TResourceClass(),
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),

        new StringResourceTester<TResourceClass>(new TResourceClass(), 
            known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true)
    ];


    // Resource Classes

    public static class ResourceClass_0ArgMethod_Static
    {
        public static string Greet() => "Hello";
    }

    public class ResourceClass_0Arg_StaticInstantiable
    {
        public static string Greet() => "Hello";
    }

    public class ResourceClass_0Arg_Instance
    {
        public string Greet() => "Hello";
    }

    public static class ResourceClass_1Arg_Static
    {
        public static string Greet(string name) => $"Hello {name}";
    }

    public class ResourceClass_1Arg_Instance
    {
        public string Greet(string name) => $"Hello {name}";
    }

    //public class ResourceClass_1Arg_StaticMethod_InstanceClass
    public class ResourceClass_1Arg_StaticInstantiable
    {
        public static string Greet(string name) => $"Hello {name}";
    }

    public static class ResourceClass_2Args
    {
        public static string Format(string label, int count) => $"{label}: {count}";
    }

    public class ResourceClass_3Args
    {
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    public static class ResourceClass_VariousArgTypes
    {
        public static string WithString  (string   val) => $"Value:{val}";
        public static string WithInt     (int      val) => $"Value:{val}";
        public static string WithLong    (long     val) => $"Value:{val}";
        public static string WithShort   (short    val) => $"Value:{val}";
        public static string WithByte    (byte     val) => $"Value:{val}";
        public static string WithDecimal (decimal  val) => $"Value:{val}";
        public static string WithDouble  (double   val) => $"Value:{val}";
        public static string WithFloat   (float    val) => $"Value:{val}";
        public static string WithBool    (bool     val) => $"Value:{val}";
        public static string WithChar    (char     val) => $"Value:{val}";
        public static string WithDateTime(DateTime val) => $"Value:{val}";
        public static string WithSByte   (sbyte    val) => $"Value:{val}";
        public static string WithUInt16  (ushort   val) => $"Value:{val}";
        public static string WithUInt32  (uint     val) => $"Value:{val}";
        public static string WithUInt64  (ulong    val) => $"Value:{val}";
    }

    public static class ResourceClass_MissingParam
    {
        public static string Bad(string name) => "Static text";
    }

    public static class ResourceClass_WithProblematic
    {
        public static string Good() => "Hello";
        public static string Problematic() => "";
    }

    public static class ResourceClass_CustomType
    {
        public static string Format(CustomArgType id) => $"Value: {id}";
    }

    public class ResourceClass_MixedMembers
    {
        public static string Title => "Title";
        public static string Greeting(string name) => "Hello " + name;
        public static string Message() => "A message";
    }

    public class InstanceResources : IResources
    {
        public string Title => "Title";
        public string Greeting(string name) => "Hello " + name;
    }

    public interface IResources
    {
        string Title { get; }
        string Greeting(string name);
    }

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

    // Inherited Testers

    private class InheritedTester_MemberInclusion()
        : StringResourceTester(
            typeof(ResourceClass_WithProblematic), 
            known: ["nl-NL", ""], unknown: "de-DE", @default: "en-US")
    {
        protected override bool Include(MemberInfo memberToTest)
        {
            if (memberToTest.Name == "Problematic") return false;
            return base.Include(memberToTest);
        }
    }

    private class InheritedTester_WithCustomGetArg()
        : StringResourceTester(
            typeof(ResourceClass_CustomType), 
            known: ["nl-NL", ""], unknown: "de-DE", @default: "en-US")
    {
        protected override object GetArg(ParameterInfo param)
        {
            if (param.ParameterType == typeof(CustomArgType))
            {
                return new CustomArgType(42 + param.Position);
            }

            return base.GetArg(param);
        }
    }

    public class CustomArgType(int id)
    {
        public override string ToString() => $"ID-{id}";
    }
}
