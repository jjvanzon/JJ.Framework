// ReSharper disable RedundantTypeArgumentsOfMethod
//#pragma warning disable IDE0090 // Preferred new-style

namespace JJ.Framework.StringResources.Legacy.Tests;

[TestClass]
public class StringResourceTesterTests
{
    private static readonly string[] _known = [ "", "nl-NL" ];
    private const string _unknow = "de-DE";
    private const string _default = "en-US";

    // Static / Instance

    [TestMethod]
    public void StringResourceTesters_ReturnText_WithArgsInResult()
    {
        StringResourceTester[] testers = 
        [
            new (typeof(ResourceClass_Static), _known, _unknow, _default),
            new (typeof(ResourceClass_Instance), new ResourceClass_Instance(), _known, _unknow, _default),
            new (typeof(ResourceClass_StaticInstantiable), _known, _unknow, _default),
            new (typeof(ResourceClass_StaticInstantiable), new ResourceClass_StaticInstantiable(), _known, _unknow, _default),
        ];

        foreach (var tester in testers)
        {
            tester.AssertAllMembers();
            tester.AssertUnknownCulture();
        }
    }

    // Generic Syntax


    [TestMethod]
    public void StringResourceTesters_Generic()
    {
        StringResourceTester[] testers = 
        [
            new StringResourceTester<ResourceClass_Instance>(new(), _known, _unknow, _default),
            new StringResourceTester<ResourceClass_StaticInstantiable>(_known, _unknow, _default),
            new StringResourceTester<ResourceClass_StaticInstantiable>(new(), _known, _unknow, _default),
        ];

        foreach (var tester in testers)
        {
            tester.AssertAllMembers();
            tester.AssertUnknownCulture();
        }
    }

    // Arg Types

    [TestMethod]
    public void StringResourceTester_VariousArgTypes_AppearInResult()
    {
        var tester = new StringResourceTester<ResourceClass_VariousArgTypes>(_known, _unknow, _default);
        tester.AssertAllMembers();
        //tester.AssertUnknownCulture(); // TODO: DateTime formatting differences
    }


    // Mixed Props and Methods

    [TestMethod]
    public void StringResourceTester_MixedMembersWork() 
        => new StringResourceTester<ResourceClass_MixedMembers>(_known, _unknow, _default).AssertAllMembers();

    // Resources behind Interfac

    [TestMethod]
    public void StringResourceTester_ResourceClass_WithInterface()
    {
        IResources obj = new ResourceClass_WithInterface();
        var tester = new StringResourceTester(typeof(ResourceClass_WithInterface), obj, _known, _unknow, _default);
        tester.AssertAllMembers();
    }

    // Customization

    [TestMethod]
    public void StringResourceTester_Inheritance_MemberExclusion()
    {
        new InheritedTester_ExcludesWrongType().AssertAllMembers();
        new InheritedTester_ExcludesEmpty().AssertAllMembers();
    }

    [TestMethod]
    public void StringResourceTester_Inheritance_CustomTestValue_AppearsInResult()
    {
        new InheritedTester_WithCustomGetArg().AssertAllMembers();
    }
    
    // Log / No Log Constructors

    [TestMethod]
    public void StringResourceTesters_NoLog()
    {
        StringResourceTester[] testers = 
        [
            new (typeof(ResourceClass_Static), _known, _unknow, _default, nolog),
            new (typeof(ResourceClass_Static), _known, _unknow, _default, nolog: true),
            new (typeof(ResourceClass_Instance), new ResourceClass_Instance(), _known, _unknow, _default, nolog),
            new (typeof(ResourceClass_Instance), new ResourceClass_Instance(), _known, _unknow, _default, nolog: true),
            new StringResourceTester<ResourceClass_Instance> (new(), _known, _unknow, _default, nolog),
            new StringResourceTester<ResourceClass_Instance> (new(), _known, _unknow, _default, nolog: true),
        ];

        foreach (var tester in testers)
        {
            string trace1 = CaptureTrace(tester.AssertAllMembers);
            AreEqual("", trace1);

            string trace2 = CaptureTrace(tester.AssertUnknownCulture);
            AreEqual("", trace2);
        }
    }

    [TestMethod]
    public void StringResourceTesters_HaveLogs()
    {

        StringResourceTester[] testers =
        [
            new (typeof(ResourceClass_Static), _known, _unknow, _default),
            new (typeof(ResourceClass_Static), _known, _unknow, _default, nolog: false),
            new (typeof(ResourceClass_Instance), new ResourceClass_Instance(), _known, _unknow, _default),
            new (typeof(ResourceClass_Instance), new ResourceClass_Instance(), _known, _unknow, _default, nolog: false),
            new StringResourceTester<ResourceClass_Instance>(new(), _known, _unknow, _default),
            new StringResourceTester<ResourceClass_Instance>(new(), _known, _unknow, _default, nolog: false),
        ];

        foreach (var tester in testers)
        {
            string trace1 = CaptureTrace(tester.AssertAllMembers);
            NotNullOrWhiteSpace(trace1);

            string trace2 = CaptureTrace(tester.AssertUnknownCulture);
            NotNullOrWhiteSpace(trace2);
        }

    }

    // Failure Cases

    [TestMethod]
    public void StringResourceTester_MissingArgVal_Throws()
    {
        var tester = new StringResourceTester<ResourceClass_MissingParam>(_known, _unknow, _default);
        Throws(() => tester.AssertAllMembers(), "not found in result");
    }

    [TestMethod]
    public void StringResourceTester_WithoutExclusion_WrongTypeMember_Throws()
    {
        var tester = new StringResourceTester<ResourceClass_WithWrongType>(_known, _unknow, _default);
        Throws(() => tester.AssertAllMembers(), "WrongType", "IsOfType assertion failed");
    }

    [TestMethod]
    public void StringResourceTester_WithoutExclusion_EmptyString_Throws()
    {
        var tester = new StringResourceTester<ResourceClass_WithEmpty>(_known, _unknow, _default);
        Throws(() => tester.AssertAllMembers(), "IsEmpty", "NotNullOrWhiteSpace assertion failed");
    }

    [TestMethod]
    public void StringResourceTester_UnsupportedType_Throws()
    {
        var tester = new StringResourceTester<ResourceClass_CustomType>(_known, _unknow, _default);
        Throws(() => tester.AssertAllMembers(), "could not", "generate", "value for parameter");
    }

    // Helpers

    private static string CaptureTrace(Action action)
    {
        using var writer = new StringWriter();
        using var listener = new TextWriterTraceListener(writer);
        Trace.Listeners.Add(listener);
        try
        {
            action();
            Trace.Flush();
        }
        finally
        {
            Trace.Listeners.Remove(listener);
        }

        return writer.ToString().Trim();
    }

    // Resource Classes

    private static class ResourceClass_Static
    {
        public static string Greet() => "Hello";
        public static string Greet(string name) => $"Hello {name}";
        public static string Format(string label, int count) => $"{label}: {count}";
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    private class ResourceClass_Instance
    {
        public string Greet() => "Hello";
        public string Greet(string name) => $"Hello {name}";
        public string Format(string label, int count) => $"{label}: {count}";
        public string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    private class ResourceClass_StaticInstantiable
    {
        public static string Greet() => "Hello";
        public static string Greet(string name) => $"Hello {name}";
        public static string Format(string label, int count) => $"{label}: {count}";
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    private class ResourceClass_VariousArgTypes
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

    private class ResourceClass_MissingParam
    {
        public static string Bad(string name) => "Static text";
    }

    private class ResourceClass_WithWrongType
    {
        public static string Good() => "Hello";
        public static int WrongType() => 0;
    }

    private class ResourceClass_WithEmpty
    {
        public static string Good() => "Hello";
        public static string IsEmpty() => "";
    }

    private class ResourceClass_CustomType
    {
        public static string Format(CustomArgType id) => $"Value: {id}";
    }

    private class ResourceClass_MixedMembers
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

    private class InheritedTester_ExcludesWrongType()
        : StringResourceTester(typeof(ResourceClass_WithWrongType), _known, _unknow, _default)
    {
        protected override bool Include(MemberInfo memberToTest)
        {
            if (memberToTest.Name == "WrongType")
            {
                return false;
            }

            return base.Include(memberToTest);
        }
    }

    private class InheritedTester_ExcludesEmpty()
        : StringResourceTester(typeof(ResourceClass_WithEmpty), _known, _unknow, _default)
    {
        protected override bool Include(MemberInfo memberToTest)
        {
            if (memberToTest.Name == "IsEmpty")
            {
                return false;
            }

            return base.Include(memberToTest);
        }
    }

    private class InheritedTester_WithCustomGetArg()
        : StringResourceTester(typeof(ResourceClass_CustomType), _known, _unknow, _default)
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
