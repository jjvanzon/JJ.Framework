namespace JJ.Framework.Text.Core.Tests;

[TestClass]
public class StringHelperCore_SpacingAndPunctuation_Tests
{
    [TestMethod]
    public void Test_StringHelperCore_CountLines()
    {
        AreEqual(3, "Line1\nLine2\nLine3".CountLines());
        AreEqual(3, "Line1\r\nLine2\r\nLine3".CountLines());
    }

    [TestMethod]
    public void Test_StringHelperCore_CountLines_LastEnterNotCounted()
    {
        AreEqual(3, "Line1\nLine2\nLine3\n".CountLines());
        AreEqual(3, "Line1\nLine2\nLine3\r\n".CountLines());
    }

    [TestMethod]
    public void Test_StringHelperCore_CountLines_LastTwoEnters_CountAsOneExtraLine()
    {
        AreEqual(4, $"Line1{NewLine}Line2{NewLine}Line3\n\r\n".CountLines());
    }

    [TestMethod]
    public void Test_StringHelperCore_StartsWithBlankLine()
    {
        IsTrue (StartsWithBlankLine("\nHello"));
        IsFalse(StartsWithBlankLine("Hello\n"));
    }

    [TestMethod]
    public void Test_StringHelperCore_StartsWithBlankLine_EmptyIsConsideredABlankLine()
    {
        IsTrue(StartsWithBlankLine(""));
        IsTrue(StartsWithBlankLine(" "));
    }

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
}