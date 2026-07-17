#pragma warning disable IDE0200 // Convert to method group
#pragma warning disable IDE0002 // Simplify static call

namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class TextCore_SpacingAndPunctuation_Tests
{
    private static readonly string? Null = null;

    [TestMethod]
    public void Test_TextCore_CountLines()
    {
        AreEqual(3, StringHelperCore.CountLines("Line1\nLine2\nLine3"                ));
        AreEqual(3,                  CountLines("Line1\nLine2\nLine3"                ));
        AreEqual(3,                             "Line1\nLine2\nLine3"    .CountLines());
        AreEqual(3, StringHelperCore.CountLines("Line1\r\nLine2\r\nLine3"            ));
        AreEqual(3,                  CountLines("Line1\r\nLine2\r\nLine3"            ));
        AreEqual(3,                             "Line1\r\nLine2\r\nLine3".CountLines());
    }

    [TestMethod]
    public void Test_TextCore_CountLines_LastEnterNotCounted()
    {
        AreEqual(3, StringHelperCore.CountLines("Line1\nLine2\nLine3\n"              ));
        AreEqual(3,                  CountLines("Line1\nLine2\nLine3\n"              ));
        AreEqual(3,                             "Line1\nLine2\nLine3\n"  .CountLines());
        AreEqual(3, StringHelperCore.CountLines("Line1\nLine2\nLine3\r\n"            ));
        AreEqual(3,                  CountLines("Line1\nLine2\nLine3\r\n"            ));
        AreEqual(3,                             "Line1\nLine2\nLine3\r\n".CountLines());
    }

    [TestMethod]
    public void Test_TextCore_CountLines_LastTwoEnters_CountAsOneExtraLine()
    {
        AreEqual(4, StringHelperCore.CountLines($"Line1{NewLine}Line2{NewLine}Line3\n\r\n"            ));
        AreEqual(4,                  CountLines($"Line1{NewLine}Line2{NewLine}Line3\n\r\n"            ));
        AreEqual(4,                             $"Line1{NewLine}Line2{NewLine}Line3\n\r\n".CountLines());
    }

    [TestMethod]
    public void Test_TextCore_StartsWithBlankLine()
    {
        IsTrue (StringHelperCore.StartsWithBlankLine(  "\nHello"                        ));
        IsTrue (StringHelperCore.StartsWithBlankLine("\r\nHello"                        ));
        IsFalse(StringHelperCore.StartsWithBlankLine(   "Hello\n"                       ));
        IsFalse(StringHelperCore.StartsWithBlankLine(   "Hello\r\n"                     ));
        IsTrue (                 StartsWithBlankLine(  "\nHello"                        ));
        IsTrue (                 StartsWithBlankLine("\r\nHello"                        ));
        IsFalse(                 StartsWithBlankLine(   "Hello\n"                       ));
        IsFalse(                 StartsWithBlankLine(   "Hello\r\n"                     ));
        IsTrue (                                       "\nHello"   .StartsWithBlankLine());
        IsTrue (                                     "\r\nHello"   .StartsWithBlankLine());
        IsFalse(                                        "Hello\n"  .StartsWithBlankLine());
        IsFalse(                                        "Hello\r\n".StartsWithBlankLine());
    }

    [TestMethod]
    public void Test_TextCore_StartsWithBlankLine_EmptyIsConsideredABlankLine()
    {
        IsTrue(StringHelperCore.StartsWithBlankLine(null                     ));
        IsTrue(StringHelperCore.StartsWithBlankLine(""                       ));
        IsTrue(StringHelperCore.StartsWithBlankLine(" "                      ));
        IsTrue(StringHelperCore.StartsWithBlankLine("\t"                     ));
        IsTrue(                 StartsWithBlankLine(null                     ));
        IsTrue(                 StartsWithBlankLine(""                       ));
        IsTrue(                 StartsWithBlankLine(" "                      ));
        IsTrue(                 StartsWithBlankLine("\t"                     ));
        IsTrue(                                     Null.StartsWithBlankLine());
        IsTrue(                                     ""  .StartsWithBlankLine());
        IsTrue(                                     " " .StartsWithBlankLine());
        IsTrue(                                     "\t".StartsWithBlankLine());
    }

    [TestMethod]
    public void Test_TextCore_EndsWithBlankLine()
    {
        IsTrue (StringHelperCore.EndsWithBlankLine(    "Hello\n"                     ));
        IsTrue (StringHelperCore.EndsWithBlankLine(    "Hello\r\n"                   ));
        IsFalse(StringHelperCore.EndsWithBlankLine(  "\nHello"                       ));
        IsFalse(StringHelperCore.EndsWithBlankLine("\r\nHello"                       ));
        IsTrue (                 EndsWithBlankLine(    "Hello\n"                     ));
        IsTrue (                 EndsWithBlankLine(    "Hello\r\n"                   ));
        IsFalse(                 EndsWithBlankLine(  "\nHello"                       ));
        IsFalse(                 EndsWithBlankLine("\r\nHello"                       ));
        IsTrue (                                       "Hello\n"  .EndsWithBlankLine());
        IsTrue (                                       "Hello\r\n".EndsWithBlankLine());
        IsFalse(                                     "\nHello"    .EndsWithBlankLine());
        IsFalse(                                   "\r\nHello"    .EndsWithBlankLine());
    }
    
    [TestMethod]
    public void Test_TextCore_EndsWithBlankLine_EmptyIsConsideredABlankLine()
    {
        IsTrue(StringHelperCore.EndsWithBlankLine(null));
        IsTrue(StringHelperCore.EndsWithBlankLine(""  ));
        IsTrue(StringHelperCore.EndsWithBlankLine(" " ));
        IsTrue(StringHelperCore.EndsWithBlankLine("\t"));
        IsTrue(                 EndsWithBlankLine(null));
        IsTrue(                 EndsWithBlankLine(""  ));
        IsTrue(                 EndsWithBlankLine(" " ));
        IsTrue(                 EndsWithBlankLine("\t"));
        IsTrue(                                   Null.EndsWithBlankLine());
        IsTrue(                                   ""  .EndsWithBlankLine());
        IsTrue(                                   " " .EndsWithBlankLine());
        IsTrue(                                   "\t".EndsWithBlankLine());
    }

    [TestMethod]
    public void Test_TextCore_EndsWithPunctuation()
    {
        IsTrue (StringHelperCore.EndsWithPunctuation("Hello."                     ));
        IsTrue (StringHelperCore.EndsWithPunctuation("Hello,"                     ));
        IsTrue (StringHelperCore.EndsWithPunctuation("Hello;"                     ));
        IsTrue (StringHelperCore.EndsWithPunctuation("Hello!"                     ));
        IsTrue (StringHelperCore.EndsWithPunctuation("Hello?"                     ));
        IsFalse(StringHelperCore.EndsWithPunctuation("Hello"                      ));
        IsTrue (StringHelperCore.EndsWithPunctuation("."                          ));
        IsTrue (                 EndsWithPunctuation("Hello."                     ));
        IsTrue (                 EndsWithPunctuation("Hello,"                     ));
        IsTrue (                 EndsWithPunctuation("Hello;"                     ));
        IsTrue (                 EndsWithPunctuation("Hello!"                     ));
        IsTrue (                 EndsWithPunctuation("Hello?"                     ));
        IsFalse(                 EndsWithPunctuation("Hello"                      ));
        IsTrue (                 EndsWithPunctuation("."                          ));
        IsTrue (                                     "Hello.".EndsWithPunctuation());
        IsTrue (                                     "Hello,".EndsWithPunctuation());
        IsTrue (                                     "Hello;".EndsWithPunctuation());
        IsTrue (                                     "Hello!".EndsWithPunctuation());
        IsTrue (                                     "Hello?".EndsWithPunctuation());
        IsFalse(                                     "Hello" .EndsWithPunctuation());
        IsTrue (                                     "."     .EndsWithPunctuation());
    }
    
    [TestMethod]
    public void Test_TextCore_EndsWithPunctuation_EmptyIsTrue_BecauseRequiresNoPunctuationConcat()
    {
        // Because this is mostly used for concat purposes, 
        // an empty element is considered the beginning of a line, 
        // requiring no addition of punctuation.
        IsTrue(StringHelperCore.EndsWithPunctuation(null                     )); 
        IsTrue(StringHelperCore.EndsWithPunctuation(""                       )); 
        IsTrue(StringHelperCore.EndsWithPunctuation(" "                      )); 
        IsTrue(StringHelperCore.EndsWithPunctuation("\t"                     )); 
        IsTrue(                 EndsWithPunctuation(null                     )); 
        IsTrue(                 EndsWithPunctuation(""                       )); 
        IsTrue(                 EndsWithPunctuation(" "                      )); 
        IsTrue(                 EndsWithPunctuation("\t"                     )); 
        IsTrue(                                     Null.EndsWithPunctuation()); 
        IsTrue(                                     ""  .EndsWithPunctuation()); 
        IsTrue(                                     " " .EndsWithPunctuation()); 
        IsTrue(                                     "\t".EndsWithPunctuation()); 
    }

    [TestMethod]
    public void Test_StringExtensionsCore_RemoveAccents()
    {
        
        AreEqual("cafe",        StringHelperCore.RemoveAccents("café"                      ));
        AreEqual("cafe",                         RemoveAccents("café"                      ));
        AreEqual("cafe",                                       "café"       .RemoveAccents());
        AreEqual("Cafe",        StringHelperCore.RemoveAccents("Café"                      ));
        AreEqual("Cafe",                         RemoveAccents("Café"                      ));
        AreEqual("Cafe",                                       "Café"       .RemoveAccents());
        AreEqual("CAFE",        StringHelperCore.RemoveAccents("CAFÉ"                      ));
        AreEqual("CAFE",                         RemoveAccents("CAFÉ"                      ));
        AreEqual("CAFE",                                       "CAFÉ"       .RemoveAccents());
        AreEqual(" cafe ",      StringHelperCore.RemoveAccents(" café "                    ));
        AreEqual(" cafe ",                       RemoveAccents(" café "                    ));
        AreEqual(" cafe ",                                     " café "     .RemoveAccents());
        AreEqual("Tete-a-tete", StringHelperCore.RemoveAccents("Tête-à-tête"               ));
        AreEqual("Tete-a-tete",                  RemoveAccents("Tête-à-tête"               ));
        AreEqual("Tete-a-tete",                                "Tête-à-tête".RemoveAccents());
        AreEqual("ωτινι",       StringHelperCore.RemoveAccents("ᾧτινι"                     ));
        AreEqual("ωτινι",                        RemoveAccents("ᾧτινι"                     ));
        AreEqual("ωτινι",                                      "ᾧτινι"      .RemoveAccents());
     }

    [TestMethod]
    public void Test_StringExtensionsCore_RemoveAccents_Nullies()
    {
        AreEqual("",   StringHelperCore.RemoveAccents(Null               ));
        AreEqual("",   StringHelperCore.RemoveAccents(""                 ));
        AreEqual(" ",  StringHelperCore.RemoveAccents(" "                ));
        AreEqual("\t", StringHelperCore.RemoveAccents("\t"               ));
        AreEqual("\n", StringHelperCore.RemoveAccents("\n"               ));
        AreEqual("",                    RemoveAccents(Null               ));
        AreEqual("",                    RemoveAccents(""                 ));
        AreEqual(" ",                   RemoveAccents(" "                ));
        AreEqual("\t",                  RemoveAccents("\t"               ));
        AreEqual("\n",                  RemoveAccents("\n"               ));
        AreEqual("",                                  Null.RemoveAccents());
        AreEqual("",                                  ""  .RemoveAccents());
        AreEqual(" ",                                 " " .RemoveAccents());
        AreEqual("\t",                                "\t".RemoveAccents());
        AreEqual("\n",                                "\n".RemoveAccents());
    }
}