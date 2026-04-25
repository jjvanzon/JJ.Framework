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

  public class MyResources;
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

    public class MyResources;
}


[TestClass]
public class MyResourceTests3
{
    [TestMethod]
    public void MyTestMethod()
    {

var tester = new StringResourceTester<MyResourceFormatter>(
    known: ["nl-NL", "pl-PL"],
    unknown: "de-DE",
    @default: "en-US");

tester.AssertResourceMembers();
tester.AssertCultureFallback();

    }

class MyResourceFormatter
{
    public static string Greet(string name) => string.Format(MyResources.Greet, name);
}

public class MyResources
{
    public static string Greet => "Hello {0}";
}
}