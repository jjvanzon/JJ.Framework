namespace JJ.Framework.StringResources.Legacy.Tests;

[TestClass]
public class MyResourceTests() 
  : StringResourceTester(
    typeof(MyResources), 
    known: ["pl-PL", "nl-NL"], 
    unknown: "zh-CN", @default: "en-US")
{
    [TestMethod] 
    public void All() => AssertAllMembers();
    
    [TestMethod] 
    public void Unknown() => AssertUnknownCulture();
}

public class MyResources
{
}
