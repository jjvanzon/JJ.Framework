// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local

namespace JJ.Framework.ResourceStrings.Legacy.Tests;

[TestClass]
public class ResourceStringTesterTests
{
    // Parameter Counts

    [TestMethod]
    public void ResourceStringTester_Instance_0Args_ReturnsText() 
        => CreateTester(typeof(ResourceClass_ZeroParams)).AssertAllMembers();

    [TestMethod]
    public void ResourceStringTester_Instance_1Arg_AppearsInResult() 
        => CreateTester(typeof(ResourceClass_OneParam)).AssertAllMembers();

    [TestMethod]
    public void ResourceStringTester_Instance_2Args_AppearInResult() 
        => CreateTester(typeof(ResourceClass_TwoParams)).AssertAllMembers();

    [TestMethod]
    public void ResourceStringTester_DirectInstance_3Args_AppearInResult() 
        => CreateTester(typeof(ResourceClass_ThreeParams)).AssertAllMembers();

    // Parameter Types

    [TestMethod]
    public void ResourceStringTester_DirectInstance_VariousParamTypes_AppearInResult() 
        => CreateTester(typeof(ResourceClass_VariousTypes)).AssertAllMembers();

    // Mixed Props and Methods

    [TestMethod]
    public void ResourceStringTester_DirectInstance_MixedMembersWork() 
        => CreateTester(typeof(ResourceClass_MixedMembers)).AssertAllMembers();

    // Unknown Culture Fallback (param handling)

    [TestMethod]
    public void ResourceStringTester_UnknownCulture_ParamHandling()
        => CreateTester(typeof(ResourceClass_ThreeParams)).AssertUnknownCulture();

    // Member Selection

    [TestMethod]
    public void ResourceStringTester_Inheritance_ExcludedMember_Skipped()
        => new InheritedTester_WithExclusion().AssertAllMembers();

    [TestMethod]
    public void ResourceStringTester_Inheritance_CustomSelection_SelectsSpecificMembers() 
        => new InheritedTester_WithCustomSelection().AssertAllMembers();

    // Custom Value Supplier/Formatter

    [TestMethod]
    public void ResourceStringTester_WithInheritance_CustomTestValue_AppearsInResult() 
        => new InheritedTester_WithCustomGetArg().AssertAllMembers();

    // Failure Cases
    
    [TestMethod]
    public void ResourceStringTester_MissingParam_Throws()
        => Throws(
            () => CreateTester(typeof(ResourceClass_MissingParam)).AssertAllMembers(),
            "not found in result");

    [TestMethod]
    public void ResourceStringTester_WithoutExclusion_ProblematicMember_Throws()
        => Throws(
            () => CreateTester(typeof(ResourceClass_WithProblematic)).AssertAllMembers(),
            "Problematic");
    
    // TODO: Oops, error hiding.
    [TestMethod]
    public void ResourceStringTester_UnsupportedType_SkipsContainmentCheck() 
        => CreateTester(typeof(ResourceClass_CustomType)).AssertAllMembers();

    // Helpers

    private ResourceStringTester CreateTester(Type resourceClass)
        => new(resourceClass, known: ["", "nl-NL"], unknown: "de-DE", @default: "en-US");

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
        public static string WithString (string  val) => $"V:{val}";
        public static string WithInt    (int     val) => $"V:{val}";
        public static string WithLong   (long    val) => $"V:{val}";
        public static string WithShort  (short   val) => $"V:{val}";
        public static string WithByte   (byte    val) => $"V:{val}";
        public static string WithDecimal(decimal val) => $"V:{val}";
        public static string WithDouble (double  val) => $"V:{val}";
        public static string WithFloat  (float   val) => $"V:{val}";
        public static string WithBool   (bool    val) => $"V:{val}";
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
        public static string GetGreeting(string name) => $"Hello {name}";
        public static string GetMessage() => "A message";
    }

    // Inherited Testers

    private class InheritedTester_WithExclusion()
        : ResourceStringTester(
            typeof(ResourceClass_WithProblematic), 
            known: ["nl-NL", ""], unknown: "de-DE", @default: "en-US")
    {
        protected override bool IsExcluded(MemberInfo memberToTest)
        {
            if (memberToTest.Name == "Problematic") return true;
            return base.IsExcluded(memberToTest);
        }
    }

    private class InheritedTester_WithCustomSelection()
        : ResourceStringTester(
            typeof(ResourceClass_WithProblematic), 
            known: ["nl-NL", ""], unknown: "de-DE", @default: "en-US")
    {
        protected override IList<MemberInfo> SelectMembersToTest(Type resourceClass)
            => base.SelectMembersToTest(resourceClass)
                   .Where(x => x.Name.StartsWith("Good"))
                   .ToArray();
    }

    private class InheritedTester_WithCustomGetArg()
        : ResourceStringTester(
            typeof(ResourceClass_CustomType), 
            known: ["nl-NL", ""], unknown: "de-DE", @default: "en-US")
    {
        protected override object GetArg(Type parameterType, int index)
        {
            if (parameterType == typeof(CustomArgType))
            {
                return new CustomArgType(42 + index);
            }

            return base.GetArg(parameterType, index);
        }
    }

    private class CustomArgType(int id)
    {
        public override string ToString() => $"ID-{id}";
    }
}
