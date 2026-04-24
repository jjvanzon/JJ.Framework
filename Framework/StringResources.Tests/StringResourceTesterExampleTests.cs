namespace JJ.Framework.StringResources.Legacy.Tests;

[TestClass]
public class MyResourceTests() 
  : StringResourceTester(
    typeof(MyResources), 
    known: ["pl-PL", "nl-NL"], 
    unknown: "zh-CN", @default: "en-US")
{
    [TestMethod] 
    public void All() => AssertResourceMembers();
    
    [TestMethod] 
    public void Unknown() => AssertCultureFallback();
}

[TestClass]
public class MyResourceTests2
{
    [TestMethod]
    public void MyTestMethod()
    {
        var tester = new StringResourceTester<MyResources>(
            known: ["nl-NL", "pl-PL"],
            unknown: "de-DE",
            @default: "en-US");
        
        tester.AssertResourceMembers();
        tester.AssertCultureFallback();
    }
}

public class MyResources;
