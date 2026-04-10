// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local

namespace JJ.Framework.ResourceStrings.Legacy.Tests;

[TestClass]
public class ResourceStringTesterTests
{
    // Parameter Counts

    [TestMethod]
    public void ResourceStringTester_ZeroParams_ReturnsText()
        => AssertAllMembers(typeof(Stub_ZeroParams));

    [TestMethod]
    public void ResourceStringTester_OneParam_AppearsInResult()
        => AssertAllMembers(typeof(Stub_OneParam));

    [TestMethod]
    public void ResourceStringTester_TwoMixedParams_AppearInResult()
        => AssertAllMembers(typeof(Stub_TwoParams));

    [TestMethod]
    public void ResourceStringTester_ThreeParams_AppearInResult()
        => AssertAllMembers(typeof(Stub_ThreeParams));

    // Parameter Types

    [TestMethod]
    public void ResourceStringTester_VariousParamTypes_AppearInResult()
        => AssertAllMembers(typeof(Stub_VariousTypes));

    // Containment Failure

    [TestMethod]
    public void ResourceStringTester_MissingParam_Throws()
        => Throws(
            () => AssertAllMembers(typeof(Stub_MissingParam)),
            "not found in result");

    // Unknown Culture Fallback (with parameters)

    [TestMethod]
    public void ResourceStringTester_UnknownCulture_WithParams()
    {
        var tester = CreateTester(typeof(Stub_ThreeParams));
        tester.Assert_UnknownCulture_UsesDefaultCulture();
    }

    // Member Exclusion (IsExcluded)

    [TestMethod]
    public void ResourceStringTester_ExcludedMember_Skipped()
    {
        var tester = new Tester_WithExclusion(typeof(Stub_WithProblematic));
        tester.Assert_AllPublicStatics_ReturnText_ForKnownCultures();
    }

    [TestMethod]
    public void ResourceStringTester_WithoutExclusion_ProblematicMember_Throws()
        => Throws(
            () => AssertAllMembers(typeof(Stub_WithProblematic)),
            "Problematic");

    // Member Selection (SelectMembersToTest)

    [TestMethod]
    public void ResourceStringTester_CustomSelection_SelectsSpecificMembers()
    {
        var tester = new Tester_WithCustomSelection(typeof(Stub_WithProblematic));
        tester.Assert_AllPublicStatics_ReturnText_ForKnownCultures();
    }

    // Custom Test Values (CreateTestValue)

    [TestMethod]
    public void ResourceStringTester_CustomTestValue_AppearsInResult()
    {
        var tester = new Tester_WithCustomTestValue(typeof(Stub_CustomType));
        tester.Assert_AllPublicStatics_ReturnText_ForKnownCultures();
    }

    [TestMethod]
    public void ResourceStringTester_UnsupportedType_SkipsContainmentCheck()
        => AssertAllMembers(typeof(Stub_CustomType));

    // Helpers

    private static void AssertAllMembers(Type stubType)
    {
        var tester = CreateTester(stubType);
        tester.Assert_AllPublicStatics_ReturnText_ForKnownCultures();
    }

    private static ResourceStringTester CreateTester(Type stubType)
        => new(stubType, known: ["nl-NL"], unknown: "de-DE", @default: "en-US");

    // Tester Subclasses

    private class Tester_WithExclusion(Type type)
        : ResourceStringTester(type, known: ["nl-NL"], unknown: "de-DE", @default: "en-US")
    {
        protected override bool IsExcluded(MemberInfo memberToTest)
            => memberToTest.Name == "Problematic" || base.IsExcluded(memberToTest);
    }

    private class Tester_WithCustomSelection(Type type)
        : ResourceStringTester(type, known: ["nl-NL"], unknown: "de-DE", @default: "en-US")
    {
        protected override IList<MemberInfo> SelectMembersToTest(Type resourceClass)
            => base.SelectMembersToTest(resourceClass)
                   .Where(x => x.Name.StartsWith("Good"))
                   .ToArray();
    }

    private class Tester_WithCustomTestValue(Type type)
        : ResourceStringTester(type, known: ["nl-NL"], unknown: "de-DE", @default: "en-US")
    {
        protected override object CreateTestValue(Type parameterType, int index)
            => parameterType == typeof(CustomId)
                ? new CustomId(42 + index)
                : base.CreateTestValue(parameterType, index);
    }

    // Custom Type

    private class CustomId(int value)
    {
        public override string ToString() => $"ID-{value}";
    }

    // Stubs

    private static class Stub_ZeroParams
    {
        public static string Greet() => "Hello";
    }

    private static class Stub_OneParam
    {
        public static string Greet(string name) => $"Hello {name}";
    }

    private static class Stub_TwoParams
    {
        public static string Format(string label, int count) => $"{label}: {count}";
    }

    private static class Stub_ThreeParams
    {
        public static string Format(string label, int count, decimal rate) => $"{label}: {count} @ {rate}";
    }

    private static class Stub_VariousTypes
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

    private static class Stub_MissingParam
    {
        public static string Bad(string name) => "Static text";
    }

    private static class Stub_WithProblematic
    {
        public static string Good() => "Hello";
        public static string Problematic() => "";
    }

    private static class Stub_CustomType
    {
        public static string Format(CustomId id) => $"Value: {id}";
    }
}
