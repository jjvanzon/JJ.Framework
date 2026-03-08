// ncrunch: no coverage start

namespace JJ.Framework.Reflection.Legacy.Tests.CoreTestHelpers;

internal class TestClass
{
    private int    _testField;
    private string _testField2 = "";
    public  int    TestProperty  { get => _testField;  set => _testField = value; } 
    public  string TestProperty2 { get => _testField2; set => _testField2 = value; }
    public int TestMethod() => 0;
    public string TestMethod2(int index, string text) => "";
}

// ncrunch: no coverage end
