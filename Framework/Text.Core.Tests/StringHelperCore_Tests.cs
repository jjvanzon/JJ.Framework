namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringHelperCore_Tests
{
    [TestMethod]
    public void CountLines_WithMultipleLines_ReturnsCorrectCount()
    {
        string text = "Line1\nLine2\nLine3";
        int result = text.CountLines();
        AreEqual(3, result);
    }

    [TestMethod]
    public void CountLines_WithNull_ReturnsZero()
    {
        string? text = null;
        int result = text.CountLines();
        AreEqual(0, result);
    }

    [TestMethod]
    public void Contains_StringWithIgnoreCaseTrue_ReturnsTrue()
    {
        string str = "Hello World";
        bool result = str.Contains("hello", ignoreCase: true);
        IsTrue(result);
    }

    [TestMethod]
    public void Contains_StringArrayWithMatch_ReturnsTrue()
    {
        string str = "The quick brown fox";
        string[] words = ["cat", "fox", "dog"];
        bool result = str.Contains(words);
        IsTrue(result);
    }

    [TestMethod]
    public void Contains_CharArrayWithMatch_ReturnsTrue()
    {
        string str = "Hello";
        char[] chars = ['x', 'e', 'z'];
        bool result = str.Contains(chars);
        IsTrue(result);
    }

    [TestMethod]
    public void ToStringComparison_WithTrue_ReturnsOrdinalIgnoreCase()
    {
        bool ignoreCase = true;
        StringComparison result = ignoreCase.ToStringComparison();
        AreEqual(StringComparison.OrdinalIgnoreCase, result);
    }

    [TestMethod]
    public void PrettyDuration_WithNullValue_ReturnsEmptyString()
    {
        double? durationInSeconds = null;
        string result = PrettyDuration(durationInSeconds);
        AreEqual("", result);
    }

    [TestMethod]
    public void PrettyDuration_With3600Seconds_ReturnsHourFormat()
    {
        double durationInSeconds = 3600;
        string result = PrettyDuration(durationInSeconds);
        IsTrue(result.Contains("h"));
    }

    [TestMethod]
    public void PrettyTimeSpan_WithDays_ReturnsDayFormat()
    {
        TimeSpan timeSpan = TimeSpan.FromDays(2.5);
        string result = timeSpan.PrettyTimeSpan();
        IsTrue(result.Contains("d"));
    }

    [TestMethod]
    public void PrettyByteCount_WithNullBytes_ReturnsZeroBytes()
    {
        byte[]? bytes = null;
        string result = PrettyByteCount(bytes);
        IsTrue(result.Contains("bytes"));
    }

    [TestMethod]
    public void PrettyByteCount_WithLargeByteCount_ReturnsGBFormat()
    {
        long byteCount = 1_500_000_000;
        string result = PrettyByteCount(byteCount);
        IsTrue(result.Contains("GB"));
    }

    [TestMethod]
    public void WithShortGuids_WithGuidLikeSequence_ShortenedCorrectly()
    {
        string input = "abc123def456";
        string result = input.WithShortGuids(4);
        AreEqual("abc1", result);
    }

    [TestMethod]
    public void PrettyTime_NoParams_ReturnsFormattedCurrentTime()
    {
        string result = PrettyTime();
        IsTrue(result.Length == 12); // HH:mm:ss.fff format
    }

    [TestMethod]
    public void PrettyTime_WithDateTime_ReturnsFormattedTime()
    {
        DateTime dateTime = new(2023, 5, 15, 14, 30, 45, 123);
        string result = PrettyTime(dateTime);
        AreEqual("14:30:45.123", result);
    }

    [TestMethod]
    public void Trim_WithTrimmableString_RemovedFromBothSides()
    {
        string text = "<<Hello>>";
        string result = text.Trim("<<>>");
        AreEqual("Hello", result);
    }

    [TestMethod]
    public void EndsWithPunctuation_WithPeriod_ReturnsTrue()
    {
        string text = "Hello.";
        bool result = text.EndsWithPunctuation();
        IsTrue(result);
    }

    [TestMethod]
    public void EndsWithPunctuation_WithNoPunctuation_ReturnsFalse()
    {
        string text = "Hello";
        bool result = text.EndsWithPunctuation();
        IsFalse(result);
    }

    [TestMethod]
    public void StartsWithBlankLine_WithTextStartingWithNewline_ReturnsTrue()
    {
        string text = "\nHello";
        bool result = StartsWithBlankLine(text);
        IsTrue(result);
    }

    [TestMethod]
    public void EndsWithBlankLine_WithTextEndingWithNewline_ReturnsTrue()
    {
        string text = "Hello\n";
        bool result = EndsWithBlankLine(text);
        IsTrue(result);
    }

    [TestMethod]
    public void Replace_StringOldCharNew_ReplacesCorrectly()
    {
        string text = "Hello";
        string result = Replace(text, 'l', "L");
        AreEqual("HeLLo", result);
    }

    [TestMethod]
    public void Replace_StringOldCharToNewChar_ReplacesCorrectly()
    {
        string text = "Hello";
        string result = Replace(text, "ll", '*');
        AreEqual("He*o", result);
    }
}
