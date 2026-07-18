#pragma warning disable IDE0002 // Simplify static calls

namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class TextCore_PrettyTime_Tests
{
    // PrettyDuration

    [TestMethod]
    public void Test_TextCore_PrettyDuration()
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
    public void Test_TextCore_PrettyDuration_Nullable()
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
    public void Test_TextCore_PrettyDuration_StaticWithQualifier()
    {
        AreEqual("1.00 d", StringHelperCore.PrettyDuration(sec: 24 * 60 * 60));
        AreEqual("1.23 s", StringHelperCore.PrettyDuration(sec: (double?)1.23));
    }

    [TestMethod]
    public void Test_TextCore_PrettyDuration_ExtensionMethod()
    {
        AreEqual("1.00 d",     (24 * 60 * 60).PrettyDuration());
        AreEqual("500.00 ms",            0.5 .PrettyDuration());
        AreEqual("1.23 s",    ((double?)1.23).PrettyDuration());
    }

    // PrettyTimeSpan

    [TestMethod]
    public void Test_TextCore_PrettyTimeSpan()
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
    public void Test_TextCore_PrettyTimeSpan_StaticSyntax()
    {
        AreEqual("1.33 h", StringHelperCore.PrettyTimeSpan(FromHours(1.33)));
        AreEqual("3.14 d",                  PrettyTimeSpan(FromDays (3.14)));
    }
    
    // PrettyTime

    [TestMethod]
    public void Test_TextCore_PrettyTime_NoParamReturnsNow()
    {
        // HH:mm:ss.fff format 
        string prettyTime = PrettyTime();
        char[] digits  = [ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' ];
        IsTrue  (prettyTime.Length == 12); 
        IsTrue  (prettyTime[00].In(digits));
        IsTrue  (prettyTime[01].In(digits));
        AreEqual(prettyTime[02], ':');
        IsTrue  (prettyTime[03].In(digits));
        IsTrue  (prettyTime[04].In(digits));
        AreEqual(prettyTime[05], ':');
        IsTrue  (prettyTime[06].In(digits));
        IsTrue  (prettyTime[07].In(digits));
        AreEqual(prettyTime[08], '.');
        IsTrue  (prettyTime[09].In(digits));
        IsTrue  (prettyTime[10].In(digits));
        IsTrue  (prettyTime[11].In(digits));
    }

    [TestMethod]
    public void Test_TextCore_PrettyTime()
    {
        var input = DateTime.Parse("2023-05-15 14:30:45.123");
        AreEqual("14:30:45.123", StringHelperCore.PrettyTime(input));
        AreEqual("14:30:45.123", PrettyTime(input));
        AreEqual("14:30:45.123", input.PrettyTime());
    }
}