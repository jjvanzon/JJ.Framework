
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
        AreEqual("1.23 s",    PrettyDuration(sec: 1.23));
        AreEqual("500.00 ms", PrettyDuration(sec: 0.5));
        #if NET5_0_OR_GREATER
        AreEqual("500.00 μs", PrettyDuration(sec: 0.5 / 1000));
        AreEqual("0.50 μs",   PrettyDuration(sec: 0.5 / 1000 / 1000));
        #else
        // Less precision with .NET Framework
        AreEqual("1.00 ms",   PrettyDuration(sec: 0.5 / 1000));
        AreEqual("0.00 μs",   PrettyDuration(sec: 0.5 / 1000 / 1000));  
        #endif
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyDuration_Nullable()
    {
        AreEqual("",          PrettyDuration(sec: (double?)null));
        AreEqual("1.00 d",    PrettyDuration(sec: (double?)24 * 60 * 60));
        AreEqual("1.00 h",    PrettyDuration(sec: (double?)60 * 60));
        AreEqual("1.50 min",  PrettyDuration(sec: (double?)90));
        AreEqual("1.00 min",  PrettyDuration(sec: (double?)60));
        AreEqual("30.00 s",   PrettyDuration(sec: (double?)30));
        AreEqual("1.00 s",    PrettyDuration(sec: (double?)1));
        AreEqual("1.23 s",    PrettyDuration(sec: (double?)1.23));
        AreEqual("500.00 ms", PrettyDuration(sec: (double?)0.5));
        #if NET5_0_OR_GREATER
        AreEqual("500.00 μs", PrettyDuration(sec: (double?)0.5 / 1000));
        AreEqual("0.50 μs",   PrettyDuration(sec: (double?)0.5 / 1000 / 1000));
        #else
        // Less precision with .NET Framework
        AreEqual("1.00 ms",   PrettyDuration(sec: (double?)0.5 / 1000));
        AreEqual("0.00 μs",   PrettyDuration(sec: (double?)0.5 / 1000 / 1000));  
        #endif
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyTimeSpan()
    {
        AreEqual("2.50 d",   FromDays        (2.5).PrettyTimeSpan());
        AreEqual("2.50 h",   FromHours       (2.5).PrettyTimeSpan());
        AreEqual("2.50 min", FromMinutes     (2.5).PrettyTimeSpan());
        AreEqual("2.50 s",   FromSeconds     (2.5).PrettyTimeSpan());
        #if NET5_0_OR_GREATER
        AreEqual("2.50 ms",  FromMilliseconds(2.5).PrettyTimeSpan());
        #else
        // Less precision with .NET Framework
        AreEqual("3.00 ms",  FromMilliseconds(2.5).PrettyTimeSpan());
        #endif

        // FromMicroseconds is NET 7 and up.
        #if NET7_0_OR_GREATER
        AreEqual("2.50 μs",  FromMicroseconds(2.5).PrettyTimeSpan());
        #endif
    }

    // TODO: Explore more cases

    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount()
    {
        AreEqual("1000 GB", PrettyByteCount(1000L * 1024 * 1024 * 1024));
        AreEqual("1000 MB", PrettyByteCount(1000L * 1024 * 1024));
        AreEqual("1000 kB", PrettyByteCount(1000L * 1024));
        AreEqual("1000 bytes", PrettyByteCount(1000L));
    }

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
        => AreEqual(" Hello ", "!? Hello !?!?".Trim("!?"));

    [TestMethod]
    public void Test_StringHelperCore_EndsWithPunctuation()
    {
        IsTrue ("Hello!".EndsWithPunctuation());
        IsFalse("Hello" .EndsWithPunctuation());
    }

    [TestMethod]
    public void Test_StringHelperCore_StartsWithBlankLine()
    {
        IsTrue (StartsWithBlankLine("\nHello"));
        IsFalse(StartsWithBlankLine("Hello\n"));
    }

    [TestMethod]
    public void Test_StringHelperCore_EndsWithBlankLine()
    {
        IsTrue (EndsWithBlankLine("Hello\n"));
        IsFalse(EndsWithBlankLine("\nHello"));
    }

    [TestMethod]
    public void Test_StringHelperCore_Replace_CharWithString() 
        => AreEqual("HeLaLaLaLao", Replace("Hello", 'l', "LaLa"));

    [TestMethod]
    public void Test_StringHelperCore_Replace_StringWithChar() 
        => AreEqual("He*o", Replace("Hello", "ll", '*'));
}
