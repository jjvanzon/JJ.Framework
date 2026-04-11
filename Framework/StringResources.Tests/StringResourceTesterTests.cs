// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.StringResources.Legacy.Tests;

[TestClass]
public class StringResourceTesterTests
{
    // Parameter Counts

    [TestMethod]
    public void StringResourceTester_Instance_0Args_ReturnsText() 
        => CreateDefaultTester(typeof(ResourceClass_ZeroParams)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_1Arg_AppearsInResult() 
        => CreateDefaultTester(typeof(ResourceClass_OneParam)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_2Args_AppearInResult() 
        => CreateDefaultTester(typeof(ResourceClass_TwoParams)).AssertAllMembers();

    [TestMethod]
    public void StringResourceTester_Instance_3Args_AppearInResult() 
        => CreateDefaultTester(typeof(ResourceClass_ThreeParams)).AssertAllMembers();

    // Parameter Types

    [TestMethod]
    public void StringResourceTester_Instance_VariousParamTypes_AppearInResult() 
        => CreateDefaultTester(typeof(ResourceClass_VariousTypes)).AssertAllMembers();

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
        => CreateDefaultTester(typeof(ResourceClass_ThreeParams)).AssertUnknownCulture();

    // Member Selection

    [TestMethod]
    public void StringResourceTester_Inheritance_MemberInclusion()
        => new InheritedTester_MemberInclusion().AssertAllMembers();

    // Custom Value Supplier/Formatter

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

    // NoLog Option

    [TestMethod]
    public void StringResourceTester_NoLog_SuppressesTraceOutput()
    {
        var testers = new StringResourceTester[]
        {
            new (typeof(ResourceClass_OneParam),                     
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
            new (typeof(ResourceClass_OneParam),                     
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true),
            new (typeof(InstanceResources), new InstanceResources(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog),
            new (typeof(InstanceResources), new InstanceResources(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: true)
        };

        foreach (var tester in testers)
        {
            string trace = CaptureTrace(tester.AssertAllMembers);
            AreEqual("", trace);
        }
    }

    [TestMethod]
    public void StringResourceTester_WithLog_ProducesTraceOutput()
    {
        var testers = new StringResourceTester[]
        {
            new (typeof(ResourceClass_OneParam),                     
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
            new (typeof(ResourceClass_OneParam),                    
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false),
            new (typeof(InstanceResources), new InstanceResources(),
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US"),
            new (typeof(InstanceResources), new InstanceResources(), 
                 known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog: false)
        };

        foreach (var tester in testers)
        {
            string trace = CaptureTrace(tester.AssertAllMembers);
            NotNullOrWhiteSpace(trace);
        }
    }

    // Generic StringResourceTester<T>

    [TestMethod]
    public void StringResourceTesterOfT_StaticMembers()
        => new StringResourceTester<GenericStub_OneParam>(
            known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US").AssertAllMembers();

    [TestMethod]
    public void StringResourceTesterOfT_MixedMembers()
        => new StringResourceTester<GenericStub_Mixed>(
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
            () => new StringResourceTester<GenericStub_OneParam>(
                known: ["nl-NL"], unknown: "de-DE", @default: "en-US", nolog).AssertAllMembers());

        AreEqual("", trace);
    }

    [TestMethod]
    public void StringResourceTesterOfT_UnknownCulture()
        => new StringResourceTester<GenericStub_ThreeParams>(
            known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US").AssertUnknownCulture();

    // Helpers

    private StringResourceTester CreateDefaultTester([Dyn(PubProps|PubMethods)] Type resourceClass)
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

    // Resource Classes

    private static class ResourceClass_ZeroParams
    {
        public static string Greet() => "Hello";
    }

    private static class ResourceClass_OneParam
    {
        public static string Greet(string name) => $"Hello {name}";
    }

    private static class ResourceClass_TwoParams
    {
        public static string Format(string label, int count) => $"{label}: {count}";
    }

    private static class ResourceClass_ThreeParams
    {
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    private static class ResourceClass_VariousTypes
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

    private static class ResourceClass_MixedMembers
    {
        public static string Title => "Title";
        public static string Greeting(string name) => "Hello " + name;
        public static string Message() => "A message";
    }

    private class InstanceResources : IResources
    {
        public string Title => "Title";
        public string Greeting(string name) => "Hello " + name;
    }

    private interface IResources
    {
        string Title { get; }
        string Greeting(string name);
    }

    // Non-static stubs for StringResourceTester<T> (static types can't be type arguments)

    private class GenericStub_OneParam
    {
        public static string Greet(string name) => $"Hello {name}";
    }

    private class GenericStub_Mixed
    {
        public static string Title => "Title";
        public static string Greeting(string name) => "Hello " + name;
        public static string Message() => "A message";
    }

    private class GenericStub_ThreeParams
    {
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
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

    private class CustomArgType(int id)
    {
        public override string ToString() => $"ID-{id}";
    }
}
