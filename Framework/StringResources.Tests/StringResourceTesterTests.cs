// ReSharper disable RedundantTypeArgumentsOfMethod
#pragma warning disable IDE0090 // Preferred new-style
namespace JJ.Framework.StringResources.Legacy.Tests;

[TestClass]
public class StringResourceTesterTests
{
    // Parameter Counts / Static/Instance / Constructors

    [TestMethod]
    public void StringResourceTesters_ReturnText_WithArgsInResult()
    {
        StringResourceTester[] testers = ConstructTesters();
        foreach (var tester in testers)
        {
            string trace1 = CaptureTrace(tester.AssertAllMembers);
            NotNullOrWhiteSpace(trace1);

            string trace2 = CaptureTrace(tester.AssertUnknownCulture);
            NotNullOrWhiteSpace(trace2);
        }
    }

    [TestMethod]
    public void StringResourceTesters_ReturnText_WithArgsInResult_NoLog()
    {
        StringResourceTester[] testers = ConstructTestersNoLog();
        foreach (var tester in testers)
        {
            string trace1 = CaptureTrace(tester.AssertAllMembers);
            AreEqual("", trace1);

            string trace2 = CaptureTrace(tester.AssertUnknownCulture);
            AreEqual("", trace2);
        }
    }

    // Parameter Types

    [TestMethod]
    public void StringResourceTester_VariousArgTypes_AppearInResult_Static()
    {
        var testers = ConstructTesters(typeof(ResourceClass_VariousArgTypes_Static));
        foreach (var tester in testers)
        {
            tester.AssertAllMembers();
            //tester.AssertUnknownCulture(); // TODO: DateTime formatting differences
        }
    }

    [TestMethod]
    public void StringResourceTester_VariousArgTypes_AppearInResult_Instance()
    {
        var testers = ConstructTesters<ResourceClass_VariousArgTypes_Instance>(new());
        foreach (var tester in testers)
        {
            tester.AssertAllMembers();
            //tester.AssertUnknownCulture(); // TODO: DateTime formatting differences
        }
    }

    [TestMethod]
    public void StringResourceTester_VariousArgTypes_AppearInResult_StaticInstantiable()
    {
        {
            var testers = ConstructTesters<ResourceClass_VariousArgTypes_StaticInstantiable>();
            foreach (var tester in testers)
            {
                tester.AssertAllMembers();
                //tester.AssertUnknownCulture(); // TODO: DateTime formatting differences
            }
        }
        {
            var testers = ConstructTesters<ResourceClass_VariousArgTypes_StaticInstantiable>(new());
            foreach (var tester in testers)
            {
                tester.AssertAllMembers();
                //tester.AssertUnknownCulture(); // TODO: DateTime formatting differences
            }
        }
    }


    // Mixed Props and Methods

    [TestMethod]
    public void StringResourceTester_Instance_MixedMembersWork() 
        => CreateDefaultTester(typeof(ResourceClass_MixedMembers_StaticInstantiable)).AssertAllMembers();

    // Resource Object with Interface

    [TestMethod]
    public void StringResourceTester_InstanceResourceClass_WithInterface()
    {
        IResources resourceObject = new ResourceClass_WithInterface();

        StringResourceTester resourceTester = new (
            typeof(ResourceClass_WithInterface), resourceObject, 
            known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US");

        resourceTester.AssertAllMembers();
    }


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

    // Helpers

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
    
    private StringResourceTester CreateDefaultTester([Dyn(PubPropMethod)] Type resourceClass)
        => new(resourceClass, known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US");

    private StringResourceTester[] ConstructTesters()
    {
        var list = new List<StringResourceTester>(32);
        
        list.AddRange(ConstructTesters(typeof(ResourceClass_0Arg_Static)));
        list.AddRange(ConstructTesters(typeof(ResourceClass_1Arg_Static)));
        list.AddRange(ConstructTesters(typeof(ResourceClass_2Arg_Static)));
        list.AddRange(ConstructTesters(typeof(ResourceClass_3Arg_Static)));

        list.AddRange(ConstructTesters       <ResourceClass_0Arg_Instance> (new()));
        list.AddRange(ConstructTesters(typeof(ResourceClass_0Arg_Instance), new ResourceClass_0Arg_Instance()));

        list.AddRange(ConstructTesters       <ResourceClass_1Arg_Instance>(new()));
        list.AddRange(ConstructTesters(typeof(ResourceClass_1Arg_Instance), new ResourceClass_1Arg_Instance()));

        list.AddRange(ConstructTesters       <ResourceClass_2Arg_Instance>(new()));
        list.AddRange(ConstructTesters(typeof(ResourceClass_2Arg_Instance), new ResourceClass_2Arg_Instance()));

        list.AddRange(ConstructTesters       <ResourceClass_3Arg_Instance>(new()));
        list.AddRange(ConstructTesters(typeof(ResourceClass_3Arg_Instance), new ResourceClass_3Arg_Instance()));

        list.AddRange(ConstructTesters       <ResourceClass_0Arg_StaticInstantiable>());
        list.AddRange(ConstructTesters(typeof(ResourceClass_0Arg_StaticInstantiable)));
        list.AddRange(ConstructTesters       <ResourceClass_0Arg_StaticInstantiable> (new()));
        list.AddRange(ConstructTesters(typeof(ResourceClass_0Arg_StaticInstantiable), new ResourceClass_0Arg_StaticInstantiable()));

        list.AddRange(ConstructTesters       <ResourceClass_1Arg_StaticInstantiable>());
        list.AddRange(ConstructTesters(typeof(ResourceClass_1Arg_StaticInstantiable)));
        list.AddRange(ConstructTesters       <ResourceClass_1Arg_StaticInstantiable> (new()));
        list.AddRange(ConstructTesters(typeof(ResourceClass_1Arg_StaticInstantiable), new ResourceClass_1Arg_StaticInstantiable()));

        list.AddRange(ConstructTesters       <ResourceClass_2Arg_StaticInstantiable>());
        list.AddRange(ConstructTesters(typeof(ResourceClass_2Arg_StaticInstantiable)));
        list.AddRange(ConstructTesters       <ResourceClass_2Arg_StaticInstantiable> (new()));
        list.AddRange(ConstructTesters(typeof(ResourceClass_2Arg_StaticInstantiable), new ResourceClass_2Arg_StaticInstantiable()));

        list.AddRange(ConstructTesters       <ResourceClass_3Arg_StaticInstantiable>());
        list.AddRange(ConstructTesters(typeof(ResourceClass_3Arg_StaticInstantiable)));
        list.AddRange(ConstructTesters       <ResourceClass_3Arg_StaticInstantiable> (new()));
        list.AddRange(ConstructTesters(typeof(ResourceClass_3Arg_StaticInstantiable), new ResourceClass_3Arg_StaticInstantiable()));

        return list.ToArray();
    }

    private StringResourceTester[] ConstructTestersNoLog()
    {
        var list = new List<StringResourceTester>(32);
        
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_0Arg_Static)));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_1Arg_Static)));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_2Arg_Static)));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_3Arg_Static)));

        list.AddRange(ConstructTestersNoLog       <ResourceClass_0Arg_Instance> (new()));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_0Arg_Instance), new ResourceClass_0Arg_Instance()));

        list.AddRange(ConstructTestersNoLog       <ResourceClass_1Arg_Instance>(new()));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_1Arg_Instance), new ResourceClass_1Arg_Instance()));

        list.AddRange(ConstructTestersNoLog       <ResourceClass_3Arg_Instance>(new()));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_3Arg_Instance), new ResourceClass_3Arg_Instance()));

        list.AddRange(ConstructTestersNoLog       <ResourceClass_0Arg_StaticInstantiable>());
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_0Arg_StaticInstantiable)));
        list.AddRange(ConstructTestersNoLog       <ResourceClass_0Arg_StaticInstantiable> (new()));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_0Arg_StaticInstantiable), new ResourceClass_0Arg_StaticInstantiable()));

        list.AddRange(ConstructTestersNoLog       <ResourceClass_1Arg_StaticInstantiable>());
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_1Arg_StaticInstantiable)));
        list.AddRange(ConstructTestersNoLog       <ResourceClass_1Arg_StaticInstantiable> (new()));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_1Arg_StaticInstantiable), new ResourceClass_1Arg_StaticInstantiable()));

        list.AddRange(ConstructTestersNoLog       <ResourceClass_3Arg_StaticInstantiable>());
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_3Arg_StaticInstantiable)));
        list.AddRange(ConstructTestersNoLog       <ResourceClass_3Arg_StaticInstantiable> (new()));
        list.AddRange(ConstructTestersNoLog(typeof(ResourceClass_3Arg_StaticInstantiable), new ResourceClass_3Arg_StaticInstantiable()));

        return list.ToArray();
    }

    private StringResourceTester[] ConstructTesters([Dyn(PubPropMethod)] Type type) =>
    [
        new StringResourceTester(type, known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
        new StringResourceTester(type, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
    ];

    private StringResourceTester[] ConstructTesters<[Dyn(PubPropMethod)] TResourceClass>() =>
    [
        new StringResourceTester<TResourceClass>(known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
        new StringResourceTester<TResourceClass>(known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
    ];

    private StringResourceTester[] ConstructTesters([Dyn(PubPropMethod)] Type type, object obj) =>
    [
        new StringResourceTester(type, obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
        new StringResourceTester(type, obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
    ];

    private StringResourceTester[] ConstructTesters<[Dyn(PubPropMethod)] TResourceClass>(TResourceClass obj) =>
    [
        new StringResourceTester(typeof(TResourceClass), obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
        new StringResourceTester(typeof(TResourceClass), obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
        new StringResourceTester       <TResourceClass> (obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
        new StringResourceTester       <TResourceClass> (obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
        new StringResourceTester       <TResourceClass> (obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
        new StringResourceTester       <TResourceClass> (obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false)
    ];

    private StringResourceTester[] ConstructTestersNoLog([Dyn(PubPropMethod)] Type type) =>
    [
        new StringResourceTester(type, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
        new StringResourceTester(type, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
    ];

    private StringResourceTester[] ConstructTestersNoLog<[Dyn(PubPropMethod)] TResourceClass>() =>
    [
        new StringResourceTester<TResourceClass>(known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
        new StringResourceTester<TResourceClass>(known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
    ];

    private StringResourceTester[] ConstructTestersNoLog([Dyn(PubPropMethod)] Type type, object obj) =>
    [
        new StringResourceTester(type, obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
        new StringResourceTester(type, obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
    ];

    private StringResourceTester[] ConstructTestersNoLog<[Dyn(PubPropMethod)] TResourceClass>(TResourceClass obj) =>
    [
        new StringResourceTester(typeof(TResourceClass), obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
        new StringResourceTester(typeof(TResourceClass), obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
        new StringResourceTester       <TResourceClass> (obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
        new StringResourceTester       <TResourceClass> (obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
        new StringResourceTester       <TResourceClass> (obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
        new StringResourceTester       <TResourceClass> (obj, known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true)
    ];

    // Resource Classes

    private static class ResourceClass_0Arg_Static
    {
        public static string Greet() => "Hello";
    }

    private class ResourceClass_0Arg_Instance
    {
        public string Greet() => "Hello";
    }

    private class ResourceClass_0Arg_StaticInstantiable
    {
        public static string Greet() => "Hello";
    }

    private static class ResourceClass_1Arg_Static
    {
        public static string Greet(string name) => $"Hello {name}";
    }

    private class ResourceClass_1Arg_Instance
    {
        public string Greet(string name) => $"Hello {name}";
    }

    private class ResourceClass_1Arg_StaticInstantiable
    {
        public static string Greet(string name) => $"Hello {name}";
    }

    private static class ResourceClass_2Arg_Static
    {
        public static string Format(string label, int count) => $"{label}: {count}";
    }

    private class ResourceClass_2Arg_Instance
    {
        public string Format(string label, int count) => $"{label}: {count}";
    }

    private class ResourceClass_2Arg_StaticInstantiable
    {
        public static string Format(string label, int count) => $"{label}: {count}";
    }

    private static class ResourceClass_3Arg_Static
    {
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    private class ResourceClass_3Arg_Instance
    {
        public string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    private class ResourceClass_3Arg_StaticInstantiable
    {
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    private static class ResourceClass_VariousArgTypes_Static
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

    private class ResourceClass_VariousArgTypes_Instance
    {
        public string WithString  (string   val) => $"Value:{val}";
        public string WithInt     (int      val) => $"Value:{val}";
        public string WithLong    (long     val) => $"Value:{val}";
        public string WithShort   (short    val) => $"Value:{val}";
        public string WithByte    (byte     val) => $"Value:{val}";
        public string WithDecimal (decimal  val) => $"Value:{val}";
        public string WithDouble  (double   val) => $"Value:{val}";
        public string WithFloat   (float    val) => $"Value:{val}";
        public string WithBool    (bool     val) => $"Value:{val}";
        public string WithChar    (char     val) => $"Value:{val}";
        public string WithDateTime(DateTime val) => $"Value:{val}";
        public string WithSByte   (sbyte    val) => $"Value:{val}";
        public string WithUInt16  (ushort   val) => $"Value:{val}";
        public string WithUInt32  (uint     val) => $"Value:{val}";
        public string WithUInt64  (ulong    val) => $"Value:{val}";
    }

    private class ResourceClass_VariousArgTypes_StaticInstantiable
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

    private static class ResourceClass_MissingParam
    {
        public static string Bad(string name) => "Static text";
    }

    private static class ResourceClass_WithProblematic
    {
        public static string Good() => "Hello";
        public static string Problematic() => "";
    }

    private static class ResourceClass_CustomType
    {
        public static string Format(CustomArgType id) => $"Value: {id}";
    }

    private class ResourceClass_MixedMembers_StaticInstantiable
    {
        public static string Title => "Title";
        public static string Greeting(string name) => "Hello " + name;
        public static string Message() => "A message";
    }

    private class ResourceClass_WithInterface : IResources
    {
        public string Title => "Title";
        public string Greeting(string name) => "Hello " + name;
    }

    private interface IResources
    {
        string Title { get; }
        string Greeting(string name);
    }

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
