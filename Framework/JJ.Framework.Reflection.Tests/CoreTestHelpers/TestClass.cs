// ncrunch: no coverage start

namespace JJ.Framework.Reflection.Legacy.Tests.CoreTestHelpers;

internal class TestClass
{
    private int _testField;
    private string _testField2 = "";
    private static string _staticTestProperty = "";
    public int _publicTestField;
    public static int _publicStaticField;
    public int TestProperty { get => _testField; set => _testField = value; }
    public string TestProperty2 { get => _testField2; set => _testField2 = value; }
    public static string StaticTestProperty { get => _staticTestProperty; set => _staticTestProperty = value; }
    public int TestMethod() => 0;
    public string TestMethod2(int index, string text) => "";
    public static int StaticTestMethod() => 0;
}

// ncrunch: no coverage end
