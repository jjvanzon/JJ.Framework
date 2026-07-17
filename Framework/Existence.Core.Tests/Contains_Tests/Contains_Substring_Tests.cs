namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Contains_Substring_Tests
{
    // Contains Substring

    [TestMethod]
    public void Test_Contains_Substring_CaseMattersFalse() 
        => IsTrue("Hello World".Contains("WORLD", caseMatters: false));

    [TestMethod]
    public void Test_Contains_Substring_CaseMattersTrue()
    {
        IsFalse("Hello World".Contains("WORLD", caseMatters: true));
        IsTrue ("Hello World".Contains("World", caseMatters: true));
    }

    [TestMethod]
    public void Test_Contains_Substring_CaseMatters_MagicBool()
    {
        IsFalse("Hello World".Contains("WORLD", caseMatters));
        IsTrue ("Hello World".Contains("World", caseMatters));
    }

    [TestMethod]
    public void Test_Contains_Substring_NoCaseMattersFlag_DefaultsToDotNetStringContains_CaseSensitive()
    {
        IsFalse("Hello World".Contains("WORLD"));
        IsTrue("Hello World".Contains("World"));
    }

    // Contains Words/Chars

    [TestMethod]
    public void Test_Contains_Words_DefaultCaseIgnored()
    {
        IsTrue("The quick brown fox jumped".Contains(["cat", "fox", "dog"]));
        IsTrue("The quick brown fox jumped".Contains(["cat", "FOX", "dog"]));
        IsTrue("The quick brown FOX jumped".Contains(["cat", "fox", "dog"]));
    }

    [TestMethod]
    public void Test_Contains_Words_CaseMattersFalse()
    {
        IsTrue("The quick brown fox jumped".Contains(["cat", "fox", "dog"], caseMatters: false));
        IsTrue("The quick brown fox jumped".Contains(["cat", "fox", "dog"],              false));
        IsTrue("The quick brown fox jumped".Contains(["cat", "FOX", "dog"], caseMatters: false));
        IsTrue("The quick brown fox jumped".Contains(["cat", "FOX", "dog"],              false));
        IsTrue("The quick brown FOX jumped".Contains(["cat", "fox", "dog"], caseMatters: false));
        IsTrue("The quick brown FOX jumped".Contains(["cat", "fox", "dog"],              false));
    }

    [TestMethod]
    public void Test_Contains_Words_CaseMatters()
    {
        IsFalse("The quick brown FOX jumped".Contains(["cat", "fox", "dog"], caseMatters      ));
        IsFalse("The quick brown FOX jumped".Contains(["cat", "fox", "dog"], caseMatters: true));
        IsFalse("The quick brown FOX jumped".Contains(["cat", "fox", "dog"],              true));
        IsFalse("The quick brown fox jumped".Contains(["cat", "FOX", "dog"], caseMatters      ));
        IsFalse("The quick brown fox jumped".Contains(["cat", "FOX", "dog"], caseMatters: true));
        IsFalse("The quick brown fox jumped".Contains(["cat", "FOX", "dog"],              true));
        IsTrue ("The quick brown fox jumped".Contains(["cat", "fox", "dog"], caseMatters      ));
        IsTrue ("The quick brown fox jumped".Contains(["cat", "fox", "dog"], caseMatters: true));
        IsTrue ("The quick brown fox jumped".Contains(["cat", "fox", "dog"],              true));
    }

    [TestMethod]
    public void Test_Contains_Chars()
    {
        IsTrue ("Hello".Contains(['x', 'e', 'z']));
        IsFalse("Hello".Contains(['x', 'y', 'z']));
    }
}
