namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringHelperCore_Tests
{
    [TestMethod]
    public void Test_StringHelperCore_CountLines()
    {
        const string text = "Line1\nLine2\nLine3";
        int result = text.CountLines();
        AreEqual(3, result);
    }

    [TestMethod]
    public void Test_StringHelperCore_Contains_String()
    {
        const string str = "Hello World";
        bool result = str.Contains("hello", ignoreCase: true);
        IsTrue(result);
    }

    [TestMethod]
    public void Test_StringHelperCore_Contains_StringArray()
    {
        const string str = "The quick brown fox";
        string[] words = ["cat", "fox", "dog"];
        bool result = str.Contains(words);
        IsTrue(result);
    }

    [TestMethod]
    public void Test_StringHelperCore_Contains_CharArray()
    {
        const string str = "Hello";
        char[] chars = ['x', 'e', 'z'];
        bool result = str.Contains(chars);
        IsTrue(result);
    }

    [TestMethod]
    public void Test_StringHelperCore_ToStringComparison()
    {
        const bool ignoreCase = true;
        StringComparison result = ignoreCase.ToStringComparison();
        AreEqual(StringComparison.OrdinalIgnoreCase, result);
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyDuration()
    {
        const double durationInSeconds = 3600;
        string result = PrettyDuration(durationInSeconds);
        IsTrue(result.Contains("h"));
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyTimeSpan()
    {
        TimeSpan timeSpan = TimeSpan.FromDays(2.5);
        string result = timeSpan.PrettyTimeSpan();
        IsTrue(result.Contains("d"));
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount()
    {
        const long byteCount = 1000 * 1024 * 1024;
        AreEqual("1000 MB", PrettyByteCount(byteCount));
    }


    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids()
    {
        const string input = "abc123def456";
        string result = input.WithShortGuids(4);
        AreEqual("abc1", result);
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyTime_NoParamReturnsNow()
    {
        string result = PrettyTime();
        IsTrue(result.Length == 12); // HH:mm:ss.fff format
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyTime()
    {
        DateTime dateTime = new(2023, 5, 15, 14, 30, 45, 123);
        string result = PrettyTime(dateTime);
        AreEqual("14:30:45.123", result);
    }

    [TestMethod]
    public void Test_StringHelperCore_Trim()
    {
        const string text = "!? Hello !?";
        string result = text.Trim("!?");
        AreEqual(" Hello ", result);
    }

    [TestMethod]
    public void Test_StringHelperCore_EndsWithPunctuation()
    {
        const string text = "Hello.";
        bool result = text.EndsWithPunctuation();
        IsTrue(result);
    }

    [TestMethod]
    public void Test_StringHelperCore_StartsWithBlankLine()
    {
        const string text = "\nHello";
        bool result = StartsWithBlankLine(text);
        IsTrue(result);
    }

    [TestMethod]
    public void Test_StringHelperCore_EndsWithBlankLine()
    {
        const string text = "Hello\n";
        bool result = EndsWithBlankLine(text);
        IsTrue(result);
    }

    [TestMethod]
    public void Test_StringHelperCore_Replace_CharWithString()
    {
        const string text = "Hello";
        string result = Replace(text, 'l', "L");
        AreEqual("HeLLo", result);
    }

    [TestMethod]
    public void Test_StringHelperCore_Replace_StringWithChar()
    {
        const string text = "Hello";
        string result = Replace(text, "ll", '*');
        AreEqual("He*o", result);
    }
}
