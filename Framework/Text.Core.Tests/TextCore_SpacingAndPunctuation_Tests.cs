#pragma warning disable IDE0200 // Convert to method group
#pragma warning disable IDE0002 // Simplify static call

namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class TextCore_SpacingAndPunctuation_Tests
{
    [TestMethod]
    public void Test_StringHelperCore_CountLines()
    {
        Func<string?, int>[] synonyms = 
        [
            x => x.CountLines(),
            x => CountLines(x),
            x => StringHelperCore.CountLines(x)
        ];

        foreach (var synonym in synonyms)
        {
            AreEqual(3, synonym("Line1\nLine2\nLine3"));
            AreEqual(3, synonym("Line1\r\nLine2\r\nLine3"));
        }
    }

    [TestMethod]
    public void Test_StringHelperCore_CountLines_LastEnterNotCounted()
    {
        const int expectedCount = 3;

        string[] texts =
        [
            "Line1\nLine2\nLine3\n",
            "Line1\nLine2\nLine3\r\n"
        ];

        foreach (string text in texts)
        {
            AreEqual(expectedCount, text.CountLines());
            AreEqual(expectedCount, CountLines(text));
            AreEqual(expectedCount, StringHelperCore.CountLines(text));
        }
    }

    [TestMethod]
    public void Test_StringHelperCore_CountLines_LastTwoEnters_CountAsOneExtraLine()
    {
        const int expectedCount = 4;
        string text = $"Line1{NewLine}Line2{NewLine}Line3\n\r\n";

        AreEqual(expectedCount, text.CountLines());
        AreEqual(expectedCount, CountLines(text));
        AreEqual(expectedCount, StringHelperCore.CountLines(text));
    }

    [TestMethod]
    public void Test_StringExtensionsCore_StartsWithBlankLine()
    {
        const string text = "\nHello";
        IsTrue(text.StartsWithBlankLine());
        IsTrue(StartsWithBlankLine(text));
        IsTrue(StringHelperCore.StartsWithBlankLine(text));
    }

    [TestMethod]
    public void Test_StringHelperCore_StartsWithBlankLine()
    {
        IsTrue (StringHelperCore.StartsWithBlankLine(  "\nHello"   ));
        IsTrue (StringHelperCore.StartsWithBlankLine("\r\nHello"   ));
        IsFalse(StringHelperCore.StartsWithBlankLine(   "Hello\n"  ));
        IsFalse(StringHelperCore.StartsWithBlankLine(   "Hello\r\n"));
        IsTrue (                 StartsWithBlankLine(  "\nHello"   ));
        IsTrue (                 StartsWithBlankLine("\r\nHello"   ));
        IsFalse(                 StartsWithBlankLine(   "Hello\n"  ));
        IsFalse(                 StartsWithBlankLine(   "Hello\r\n"));
        IsTrue (                                       "\nHello"   .StartsWithBlankLine());
        IsTrue (                                     "\r\nHello"   .StartsWithBlankLine());
        IsFalse(                                        "Hello\n"  .StartsWithBlankLine());
        IsFalse(                                        "Hello\r\n".StartsWithBlankLine());
    }

    [TestMethod]
    public void Test_StringHelperCore_StartsWithBlankLine_EmptyIsConsideredABlankLine()
    {
        IsTrue(StartsWithBlankLine(""));
        IsTrue(StartsWithBlankLine(" "));
    }

    [TestMethod]
    public void Test_StringExtensionsCore_EndsWithBlankLine() 
        => IsTrue("Hello\n".EndsWithBlankLine());

    [TestMethod]
    public void Test_StringHelperCore_EndsWithBlankLine()
    {
        IsTrue (EndsWithBlankLine("Hello\n"));
        IsFalse(EndsWithBlankLine("\nHello"));
    }
    
    [TestMethod]
    public void Test_StringHelperCore_EndsWithBlankLine_EmptyIsConsideredABlankLine()
    {
        IsTrue(EndsWithBlankLine(""));
        IsTrue(EndsWithBlankLine(" "));
    }

    [TestMethod]
    public void Test_StringHelperCore_EndsWithPunctuation()
    {
        IsTrue ("Hello.".EndsWithPunctuation());
        IsTrue ("Hello,".EndsWithPunctuation());
        IsTrue ("Hello;".EndsWithPunctuation());
        IsTrue ("Hello!".EndsWithPunctuation());
        IsTrue ("Hello?".EndsWithPunctuation());
        IsFalse("Hello" .EndsWithPunctuation());
        IsTrue ("."     .EndsWithPunctuation());
    }
    
    [TestMethod]
    public void Test_StringHelperCore_EndsWithPunctuation_EmptyIsTrue_BecauseRequiresNoPunctuationConcat()
    {
        // Because this is mostly used for concat purposes, 
        // an empty element is considered the beginning of a line, 
        // requiring no addition of punctuation.
        IsTrue("".EndsWithPunctuation()); 
    }

    [TestMethod]
    public void Test_StringExtensionsCore_RemoveAccents() 
        => AreEqual("cafe", "café".RemoveAccents());
}