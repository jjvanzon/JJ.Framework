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

    // Helpers

    private static void AssertAllMembers(Type stubType)
    {
        var tester = CreateTester(stubType);
        tester.Assert_AllPublicStatics_ReturnText_ForKnownCultures();
    }

    private static ResourceStringTester CreateTester(Type stubType)
        => new(stubType, known: ["nl-NL"], unknown: "de-DE", @default: "en-US");

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
        public static string WithString(string p)    => $"V:{p}";
        public static string WithInt(int p)          => $"V:{p}";
        public static string WithLong(long p)        => $"V:{p}";
        public static string WithShort(short p)      => $"V:{p}";
        public static string WithByte(byte p)        => $"V:{p}";
        public static string WithDecimal(decimal p)  => $"V:{p}";
        public static string WithDouble(double p)    => $"V:{p}";
        public static string WithFloat(float p)      => $"V:{p}";
        public static string WithBool(bool p)        => $"V:{p}";
    }

    private static class Stub_MissingParam
    {
        public static string Bad(string name) => "Static text";
    }
}
