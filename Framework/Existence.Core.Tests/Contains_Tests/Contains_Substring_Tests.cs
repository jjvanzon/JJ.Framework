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
    public void Test_Contains_Substring_NoCaseMattersFlag_DefaultsToDotNetStringContains()
    {
        IsFalse("Hello World".Contains("WORLD"));
        IsTrue("Hello World".Contains("World"));
    }

    // Contains Words/Chars

    // TODO: Test ignoreCase for Contains with (string, collection).

    [TestMethod]
    public void Test_StringHelperCore_Contains_Words() 
        => IsTrue("The quick brown fox".Contains(["cat", "fox", "dog"]));

    [TestMethod]
    public void Test_StringHelperCore_Contains_Chars() 
        => IsTrue("Hello".Contains(['x', 'e', 'z']));
}
