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

public class MyResources;
