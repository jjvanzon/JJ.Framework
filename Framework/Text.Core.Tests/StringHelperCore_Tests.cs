namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringHelperCore_Tests
{
    [TestMethod]
    public void Test_StringHelperCore_CountLines() 
        => AreEqual(3, "Line1\nLine2\nLine3".CountLines());

    [TestMethod]
    public void Test_StringHelperCore_Contains_String() 
        => IsTrue("Hello World".Contains("hello", ignoreCase: true));

    [TestMethod]
    public void Test_StringHelperCore_Contains_StringArray() 
        => IsTrue("The quick brown fox".Contains(["cat", "fox", "dog"]));

    [TestMethod]
    public void Test_StringHelperCore_Contains_CharArray() 
        => IsTrue("Hello".Contains(['x', 'e', 'z']));

    [TestMethod]
    public void Test_StringHelperCore_ToStringComparison() 
        => AreEqual(StringComparison.OrdinalIgnoreCase, true.ToStringComparison());

    [TestMethod]
    public void Test_StringHelperCore_PrettyDuration() 
        => IsTrue(PrettyDuration(3600).Contains("h"));

    [TestMethod]
    public void Test_StringHelperCore_PrettyTimeSpan() 
        => IsTrue(TimeSpan.FromDays(2.5).PrettyTimeSpan().Contains("d"));

    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount() 
        => AreEqual("1000 MB", PrettyByteCount(1000 * 1024 * 1024));


    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids() 
        => AreEqual("abc1", "abc123def456".WithShortGuids(4));

    [TestMethod]
    public void Test_StringHelperCore_PrettyTime_NoParamReturnsNow()
    {
        string result = PrettyTime();
        IsTrue(result.Length == 12); // HH:mm:ss.fff format
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyTime() 
        => AreEqual("14:30:45.123", PrettyTime(new DateTime(2023, 5, 15, 14, 30, 45, 123)));

    [TestMethod]
    public void Test_StringHelperCore_Trim() 
        => AreEqual(" Hello ", "!? Hello !?".Trim("!?"));

    [TestMethod]
    public void Test_StringHelperCore_EndsWithPunctuation() 
        => IsTrue("Hello.".EndsWithPunctuation());

    [TestMethod]
    public void Test_StringHelperCore_StartsWithBlankLine() 
        => IsTrue(StartsWithBlankLine("\nHello"));

    [TestMethod]
    public void Test_StringHelperCore_EndsWithBlankLine() 
        => IsTrue(EndsWithBlankLine("Hello\n"));

    [TestMethod]
    public void Test_StringHelperCore_Replace_CharWithString() 
        => AreEqual("HeLLo", Replace("Hello", 'l', "L"));

    [TestMethod]
    public void Test_StringHelperCore_Replace_StringWithChar() 
        => AreEqual("He*o", Replace("Hello", "ll", '*'));
}
