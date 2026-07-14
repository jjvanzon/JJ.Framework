
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

    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount()
    {
        AreEqual("100 bytes",  PrettyByteCount(   100                         ));
        AreEqual("1000 bytes", PrettyByteCount(  1000                         ));
        AreEqual("5119 bytes", PrettyByteCount(     5 *               1024 - 1));
        AreEqual("5 kB",       PrettyByteCount(     5 *               1024 + 1));
        AreEqual("10 kB",      PrettyByteCount(    10 *               1024    ));
        AreEqual("100 kB",     PrettyByteCount(   100 *               1024    ));
        AreEqual("1000 kB",    PrettyByteCount(  1000 *               1024    ));
        AreEqual("5120 kB",    PrettyByteCount(     5 *        1024 * 1024 - 1));
        AreEqual("5 MB",       PrettyByteCount(     5 *        1024 * 1024 + 1));
        AreEqual("100 MB",     PrettyByteCount(   100 *        1024 * 1024    ));
        AreEqual("1000 MB",    PrettyByteCount(  1000 *        1024 * 1024    ));
        AreEqual("5120 MB",    PrettyByteCount(    5L * 1024 * 1024 * 1024 - 1));
        AreEqual("5 GB",       PrettyByteCount(    5L * 1024 * 1024 * 1024 + 1));
        AreEqual("10 GB",      PrettyByteCount(   10L * 1024 * 1024 * 1024    ));
        AreEqual("100 GB",     PrettyByteCount(  100L * 1024 * 1024 * 1024    ));
        AreEqual("1000 GB",    PrettyByteCount( 1000L * 1024 * 1024 * 1024    ));
        AreEqual("10000 GB",   PrettyByteCount(10000L * 1024 * 1024 * 1024    ));
    }
    
    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount_Nullable()
    {
        AreEqual("0 bytes", PrettyByteCount(null)); // Arbitrary. Might have expected "", but ok.
        AreEqual("1000 bytes", PrettyByteCount(  1000                         ));
        AreEqual("10 kB",      PrettyByteCount(    10 *               1024    ));
        AreEqual("100 MB",     PrettyByteCount(   100 *        1024 * 1024    ));
        AreEqual("12345 GB",   PrettyByteCount(12345L * 1024 * 1024 * 1024    ));
    }

    [TestMethod]
    public void Test_StringHelperCore_PrettyByteCount_EdgeCases()
    {
        AreEqual("0 bytes",  PrettyByteCount(0));
        AreEqual("1 bytes",  PrettyByteCount(1));
        AreEqual("-1 bytes", PrettyByteCount(-1));
        AreEqual("-10 GB",   PrettyByteCount(-10L * 1024 * 1024 * 1024));
    }

    // TODO: Explore more cases

    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids_CommonFormats()
    {
        AreEqual("before - c - after",               "before - cf9ecb39-ad86-4a29-84c4-c0f79b9c59fa - after"      .WithShortGuids(1));
        AreEqual("before - 42 - after",              "before - {426f51a9186b4115af98cca1131b8dd4} - after"        .WithShortGuids(2));
        AreEqual("before - 07c - after",             "before - {07c75275-0150-4414-bbca-0081b021a0ea} - after"    .WithShortGuids(3));
        AreEqual("before - 9390 - after",            "before - 9390B28866D94C7BA32BFD2B12CA0AA7 - after"          .WithShortGuids(4));
        AreEqual("before - 155FE - after",           "before - 155FEB11-A3F4-486A-AE7A-CF2F8961DB10 - after"      .WithShortGuids(5));
        AreEqual("before - 3F0EC2 - after",          "before - {3F0EC22422DE4921A7A963C1FD222B33} - after"        .WithShortGuids(6));
        AreEqual("before - B5F8F33 - after",         "before - {B5F8F331-66B0-47F7-861D-9D849C7776C2} - after"    .WithShortGuids(7));
        AreEqual("before - cf9ecb39 - after",       @"before - ""cf9ecb39-ad86-4a29-84c4-c0f79b9c59fa"" - after"  .WithShortGuids(8));     
        AreEqual("before - 426f51a91 - after",      @"before - ""{426f51a9186b4115af98cca1131b8dd4}"" - after"    .WithShortGuids(9));      
        AreEqual("before - 07c7527501 - after",     @"before - ""{07c75275-0150-4414-bbca-0081b021a0ea}"" - after".WithShortGuids(10));          
        AreEqual("before - 9390B28866D - after",    @"before - ""9390B28866D94C7BA32BFD2B12CA0AA7"" - after"      .WithShortGuids(11));  
        AreEqual("before - 155FEB11A3F4 - after",   @"before - ""155FEB11-A3F4-486A-AE7A-CF2F8961DB10"" - after"  .WithShortGuids(12));      
        AreEqual("before - 3F0EC22422DE4 - after",  @"before - ""{3F0EC22422DE4921A7A963C1FD222B33}"" - after"    .WithShortGuids(13));      
        AreEqual("before - B5F8F33166B047 - after", @"before - ""{B5F8F331-66B0-47F7-861D-9D849C7776C2}"" - after".WithShortGuids(14));          
    }

    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids_ShortenTheShortened()
    {
        AreEqual("Hi - 61E6FA - Hello", "Hi - 61E6FA88-AE55-453F-E3BB27763720 - Hello".WithShortGuids(6));
        AreEqual("Hi - 61E6FA - Hello", "Hi - 61E6FA88AE55-453F-E3BB27763720 - Hello".WithShortGuids(6));
        AreEqual("Hi - abc1 - Hello",   "Hi - {abc123def456} - Hello".WithShortGuids(4));
    }

    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids_LengthUnder1Throws()
    {
        Throws(() => "61E6FA88-AE55-453F-8973-E3BB27763720".WithShortGuids(0), "length < 1");
        Throws(() => "61E6FA88-AE55-453F-8973-E3BB27763720".WithShortGuids(-1), "length < 1");
        Throws(() => "61E6FA88-AE55-453F-8973-E3BB27763720".WithShortGuids(-100), "length < 1");
    }

    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids_NullyText()
    {
        string? @null = null;

        AreEqual("", "".WithShortGuids(4));
        AreEqual(" ", " ".WithShortGuids(4));
        AreEqual("", @null.WithShortGuids(4));
    }

    [TestMethod]
    public void Test_StringHelperCore_WithShortGuids_EdgeCases()
    {
        // Spaces are not separators inside guids. But the different digit strings are shortened individually.
        AreEqual("61E AE5 453 897 E3B - Hello there", "61E6FA88 AE55 453F 8973 E3BB27763720 - Hello there".WithShortGuids(3)); 
        // The word "added" might be interepreted as hex value.
        AreEqual("Item added", "Item added".WithShortGuids(4)); 
        // TODO: Misplaced dashes
    }

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
