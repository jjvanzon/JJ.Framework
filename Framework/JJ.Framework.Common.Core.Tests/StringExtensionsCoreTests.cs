namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class StringExtensionsCoreTests
{
    private static readonly string _null = null;

    // Left
    
    [TestMethod]
    public void Left_Core_Test() 
        => AreEqual("12", () => "1234".Left(2));

    [TestMethod]
    public void Left_NotEnoughCharacters_Exception()
        => ThrowsException(() => "1234".Left(5));

    [TestMethod]
    public void Left_ZeroLengthParameter() 
        => AreEqual("", () => "1234".Left(0));
    
    [TestMethod]
    public void Left_ZeroLengthInput() 
        => AreEqual("", () => "".Left(0));

    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void Left_NullException() 
        => ThrowsException(() => _null.Left(0));
    
    // Right
    
    [TestMethod]
    public void Right_Core_Test() 
        => AreEqual("34", () => "1234".Right(2));
    
    [TestMethod]
    public void Right_NotEnoughCharacters_Exception()
        => ThrowsException(() => "1234".Right(5));
    
    [TestMethod]
    public void Right_ZeroLengthParameter() 
        => AreEqual("", () => "1234".Right(0));

    [TestMethod]
    public void Right_ZeroLengthInput() 
        => AreEqual("", () => "".Right(0));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void Right_NullException() 
        => ThrowsException(() => _null.Right(0));

    // CutLeft String
    
    [TestMethod]
    public void CutLeft_String_NoMatch() 
        => AreEqual("Lalalaa", () => "Lalalaa".CutLeft("la"));
    
    [TestMethod]
    public void CutLeft_String_OneMatch() 
        => AreEqual("Lala", () => "BlaLala".CutLeft("Bla"));
    
    [TestMethod]
    public void CutLeft_String_MoreMatches_TrimsOne() 
        => AreEqual("BlaLala", () => "BlaBlaLala".CutLeft("Bla"));
        
    [TestMethod]
    public void CutLeft_String_EmptyInput() 
        => AreEqual("", () => "".CutLeft("Bla"));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void CutLeft_String_NullInputException()
        => ThrowsException(() => _null.CutLeft("Bla"));

    // CutLeft Char
    
    [TestMethod]
    public void CutLeft_Char_NoMatch() 
        => AreEqual("Lalalaa", () => "Lalalaa".CutLeft('a'));
    
    [TestMethod]
    public void CutLeft_Char_OneMatch() 
        => AreEqual("laLala", () => "BlaLala".CutLeft('B'));
    
    [TestMethod]
    public void CutLeft_Char_MoreMatches_TrimsOne() 
        => AreEqual("BlaLala", () => "BBlaLala".CutLeft('B'));
            
    [TestMethod]
    public void CutLeft_Char_EmptyInput() 
        => AreEqual("", () => "".CutLeft("a"));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void CutLeft_Char_NullInputException()
        => ThrowsException(() => _null.CutLeft("a"));

    // CutLeft Length
    
    [TestMethod]
    public void CutLeft_Length_Core_Test() 
        => AreEqual("34", () => "1234".CutLeft(2));
    
    [TestMethod]
    public void CutLeft_Length_Zero() 
        => AreEqual("1234", () => "1234".CutLeft(0));
    
    [TestMethod]
    public void CutLeft_Length_EmptyInput() 
        => AreEqual("", () => "".CutLeft(0));
    
    [TestMethod]
    public void CutLeft_Length_TooLong_Exception()
        => ThrowsException(() => "1234".CutLeft(5));
    
    [TestMethod]
    public void CutLeft_NegativeLength_Exception() 
        => ThrowsException(() => "1234".CutRight(-1));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void CutLeft_Length_NullInput_Exception() 
        => ThrowsException(() => _null.CutLeft(0));
    
    // CutRight String

    [TestMethod]
    public void CutRight_String_NoMatch() 
        => AreEqual("Lalalaa", () => "Lalalaa".CutRight("la"));
    
    [TestMethod]
    public void CutRight_String_OneMatch() 
        => AreEqual("Lala", () => "LalaBla".CutRight("Bla"));
    
    [TestMethod]
    public void CutRight_String_MoreMatches_TrimsOne() 
        => AreEqual("LalaBla", () => "LalaBlaBla".CutRight("Bla"));
        
    [TestMethod]
    public void CutRight_String_EmptyInput() 
        => AreEqual("", () => "".CutRight("Bla"));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void CutRight_String_NullInputException()
        => ThrowsException(() => _null.CutRight("Bla"));

    // CutRight Char
    
    [TestMethod]
    public void CutRight_Char_NoMatch() 
        => AreEqual("Lalala", () => "Lalala".CutRight('l'));
    
    [TestMethod]
    public void CutRight_Char_OneMatch() 
        => AreEqual("Lalal", () => "Lalala".CutRight('a'));
    
    [TestMethod]
    public void CutRight_Char_MoreMatches_TrimsOne() 
        => AreEqual("Lalala", () => "Lalalaa".CutRight('a'));
    
    [TestMethod]
    public void CutRight_Char_EmptyInput() 
        => AreEqual("", () => "".CutRight("a"));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void CutRight_Char_NullInputException()
        => ThrowsException(() => _null.CutRight("a"));
    
    // CutRight Length
    
    [TestMethod]
    public void CutRight_Length_Core_Test() 
        => AreEqual("12", () => "1234".CutRight(2));
    
    [TestMethod]
    public void CutRight_Length_Zero() 
        => AreEqual("1234", () => "1234".CutRight(0));
    
    [TestMethod]
    public void CutRight_Length_EmptyInput() 
        => AreEqual("", () => "".CutRight(0));
    
    [TestMethod]
    public void CutRight_Length_TooLong_Exception()
        => ThrowsException(() => "1234".CutRight(5));

    [TestMethod]
    public void CutRight_NegativeLength_Exception() 
        => ThrowsException(() => "1234".CutRight(-1));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void CutRight_Length_NullInput_Exception() 
        => ThrowsException(() => _null.CutRight(0));
    
    // FromTill
    
    [TestMethod]
    public void FromTill_Core_Test() 
        => AreEqual("34", () => "12345".FromTill(2, 3));
    
    [TestMethod]
    public void FromTill_FirstChar() 
        => AreEqual("1", () => "12345".FromTill(0, 0));
    
    [TestMethod]
    public void FromTill_StartIndex0() 
        => AreEqual("12", () => "12345".FromTill(0, 1));
    
    [TestMethod]
    public void FromTill_StartIndex1() 
        => AreEqual("23", () => "12345".FromTill(1, 2));
    
    [TestMethod]
    public void FromTill_EndIndexLast() 
        => AreEqual("12345", () => "12345".FromTill(0, 4));
    
    [TestMethod]
    public void FromTill_LastChar() 
        => AreEqual("5", () => "12345".FromTill(4, 4));
    
    [TestMethod]
    public void FromTill_OutsideBoundLeft_Exception() 
        => ThrowsException(() => "12345".FromTill(-1, 1));
    
    [TestMethod]
    public void FromTill_OutsideBoundRight_Exception() 
        => ThrowsException(() => "12345".FromTill(6, 8));
    
    [TestMethod]
    public void FromTill_EndBeforeStart_Exception()
    {
        ThrowsException(() => "12345".FromTill(3, 2), "endIndex lies before startIndex.");
        ThrowsException(() => "12345".FromTill(3, 1), "endIndex lies before startIndex.");
    }
    
    [TestMethod]
    public void FromTill_EmptyInput_Exception() 
        => ThrowsException(() => "".FromTill(0, 0));
    
    [TestMethod]
    public void FromTill_NullInput_Exception() 
        => ThrowsException(() => _null.FromTill(0, 0));
    
    // CutLeftUntil
    
    [TestMethod]
    public void CutLeftUntil_NoMatch() 
        => AreEqual("1234", () => "1234".CutLeftUntil("abc"));
    
    [TestMethod]
    public void CutLeftUntil_OneMatch()
        => AreEqual("abc 5678", () => "1234 abc 5678".CutLeftUntil("abc"));
    
    [TestMethod]
    public void CutLeftUntil_MoreMatches_StopsAtFirst() 
        => AreEqual("abc abc 5678", () => "1234 abc abc 5678".CutLeftUntil("abc"));
    
    [TestMethod]
    public void CutLeftUntil_UntilWhiteSpace_Succeeds() 
        => AreEqual(" abc", () => "1234 abc".CutLeftUntil(" "));
    
    [TestMethod]
    public void CutLeftUntil_UntilEmpty_Exception() 
        => ThrowsException(() => "1234".CutLeftUntil(""));
    
    [TestMethod]
    public void CutLeftUntil_UntilNull_Exception() 
        => ThrowsException(() => "1234".CutLeftUntil(null));
    
    [TestMethod]
    public void CutLeftUntil_EmptyInput() 
        => AreEqual("", () => "".CutLeftUntil("abc"));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void CutLeftUntil_NullInput_Exception() 
        => ThrowsException(() => _null.CutLeftUntil("abc"));
    
    // CutRightUntil
    
    [TestMethod]
    public void CutRightUntil_NoMatch() 
        => AreEqual("1234", () => "1234".CutRightUntil("abc"));
    
    [TestMethod]
    public void CutRightUntil_OneMatch()
        => AreEqual("1234 abc", () => "1234 abc 5678".CutRightUntil("abc"));
    
    [TestMethod]
    public void CutRightUntil_MoreMatches_StopsAtFirst() 
        => AreEqual("1234 abc abc", () => "1234 abc abc 5678".CutRightUntil("abc"));
    
    [TestMethod]
    public void CutRightUntil_UntilWhiteSpace_Succeeds() 
        => AreEqual("1234 ", () => "1234 abc".CutRightUntil(" "));
    
    [TestMethod]
    public void CutRightUntil_UntilEmpty_Exception() 
        => ThrowsException(() => "1234".CutRightUntil(""));
    
    [TestMethod]
    public void CutRightUntil_UntilNull_Exception() 
        => ThrowsException(() => "1234".CutRightUntil(null));
        
    [TestMethod]
    public void CutRightUntil_EmptyInput() 
        => AreEqual("", () => "".CutRightUntil("abc"));
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void CutRightUntil_NullInput_Exception() 
        => ThrowsException(() => _null.CutRightUntil("abc"));

    // RemoveExcessiveWhiteSpace
    
    [TestMethod]
    public void RemoveExcessiveWhiteSpace_Test() 
        => AreEqual("This is a test.", () => "\t\tThis \n is \r a   test. ".RemoveExcessiveWhiteSpace());
 
    [TestMethod]
    public void RemoveExcessiveWhiteSpace_NoWhiteSpace() 
        => AreEqual("Test", () => "Test".RemoveExcessiveWhiteSpace());
    
    [TestMethod]
    public void RemoveExcessiveWhiteSpace_AllWhiteSpace() 
        => AreEqual("", () => "   \t\r\n   ".RemoveExcessiveWhiteSpace());   
    
    [TestMethod]
    public void RemoveExcessiveWhiteSpace_Empty() 
        => AreEqual("", () => "".RemoveExcessiveWhiteSpace());
    
    [TestMethod]
    public void RemoveExcessiveWhiteSpace_WhiteSpace()
        => AreEqual("", () => " ".RemoveExcessiveWhiteSpace());
    
    /// <inheritdoc cref="_harshnullstringtest" />
    [TestMethod]
    public void RemoveExcessiveWhiteSpace_NullException()
        => ThrowsException(() => _null.RemoveExcessiveWhiteSpace());
    
    // Replace IgnoreCase
    
    [TestMethod]
    public void Replace_IgnoreCase() 
        => AreEqual("abcdef", "abcDEF".Replace("def", "def", ignoreCase: true));
    
    [TestMethod]
    public void Replace_CaseSensitive() 
        => AreEqual("abcDEF", "abcDEF".Replace("def", "def", ignoreCase: false));
    
    [TestMethod]
    public void Replace_CaseSensitive_Implied() 
        => AreEqual("abcDEF", () => "abcDEF".Replace("def", "def"));

    [TestMethod]
    public void Replace_NoMatch_Works() 
        => AreEqual("abc", () => "abc".Replace("def", "ghi", true));

    [TestMethod]
    public void Replace_EmptyInput_Works() 
        => AreEqual("", () => "".Replace("abc", "def", true));
    
    [TestMethod]
    public void Replace_EmptyOldValue_DoesNothing() 
        => AreEqual("abcdef", () => "abcdef".Replace("", "def", true));
    
    [TestMethod]
    public void Replace_NullOldValue_DoesNothing() 
        => AreEqual("abcdef", () => "abcdef".Replace(null, "def", true));

    [TestMethod]
    public void Replace_EmptyNewValue_RemovesMatches() 
        => AreEqual("def", () => "abcdef".Replace("abc", "", true));
        
    [TestMethod]
    public void Replace_NullNewValue_RemovesMatches() 
        => AreEqual("def", () => "abcdef".Replace("abc", null, true));

    [TestMethod]
    public void Replace_NullInput_ReturnsNullOrEmpty()
        => IsNullOrEmpty(() => _null.Replace("abc", "def", true));
}