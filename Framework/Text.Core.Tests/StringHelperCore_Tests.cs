
namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringHelperCore_Tests
{
    [TestMethod]
    public void Test_StringHelperCore_CountLines() 
        => AreEqual(3, "Line1\nLine2\nLine3".CountLines());

    [TestMethod]
    public void Test_StringHelperCore_Contains_String_IgnoreCase() 
        => IsTrue("Hello World".Contains("hello", ignoreCase: true));

    [TestMethod]
    public void Test_StringHelperCore_Contains_StringCollection() 
        => IsTrue("The quick brown fox".Contains(["cat", "fox", "dog"]));

    [TestMethod]
    public void Test_StringHelperCore_Contains_CharCollection() 
        => IsTrue("Hello".Contains(['x', 'e', 'z']));

    [TestMethod]
    public void Test_StringHelperCore_BoolIgnoreCase_True_ToStringComparison()
    {
        const bool ignoreCaseTrue = true;
        AreEqual(OrdinalIgnoreCase, ignoreCaseTrue.ToStringComparison());
    }

    [TestMethod]
    public void Test_StringHelperCore_BoolIgnoreCase_False_ToStringComparison()
    {
        const bool ignoreCaseTrue = false;
        AreEqual(Ordinal, ignoreCaseTrue.ToStringComparison());
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyDuration()
    {
        AreEqual("1.00 d",    PrettyDuration(sec: 24 * 60 * 60));
        AreEqual("1.00 h",    PrettyDuration(sec: 60 * 60));
        AreEqual("1.50 min",  PrettyDuration(sec: 90));
        AreEqual("1.00 min",  PrettyDuration(sec: 60));
        AreEqual("30.00 s",   PrettyDuration(sec: 30));
        AreEqual("1.00 s",    PrettyDuration(sec: 1));
        AreEqual("500.00 ms", PrettyDuration(sec: 0.5));
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyDuration_Nullable()
    {
        AreEqual("",          PrettyDuration(sec: null));
        AreEqual("1.00 h",    PrettyDuration(sec: (double?)3600));
        AreEqual("1.50 min",  PrettyDuration(sec: (double?)90));
        AreEqual("1.00 min",  PrettyDuration(sec: (double?)60));
        AreEqual("30.00 s",   PrettyDuration(sec: (double?)30));
        AreEqual("1.00 s",    PrettyDuration(sec: (double?)1));
        AreEqual("500.00 ms", PrettyDuration(sec: (double?)0.5));
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyTimeSpan() 
        => IsTrue(FromDays(2.5).PrettyTimeSpan().Contains("d")); // TODO: Check exact value, not just one letter.

    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount() 
        => AreEqual("1000 MB", PrettyByteCount(1000 * 1024 * 1024));


    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids() 
        => AreEqual("abc1 - Hello there", "abc123def456 - Hello there".WithShortGuids(4));

    [TestMethod]
    public void Test_StringHelperCore_PrettyTime_NoParamReturnsNow()
    {
        string result = PrettyTime(); 
        IsTrue(result.Length == 12); // HH:mm:ss.fff format // TODO: Check a little more than length.
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyTime() 
        => AreEqual("14:30:45.123", PrettyTime(new DateTime(2023, 5, 15, 14, 30, 45, 123))); // TODO: Use DateTime.Parse instead of new DateTime.

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
