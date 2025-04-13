namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class StringExtensionsCommonCoreTests
{
    // Left
    
    [TestMethod]
    public void Left_Core_Test() 
        => AreEqual("12", () => "1234".Left(2));

    [TestMethod]
    public void Left_NotEnoughCharacters_ThrowsException()
        => ThrowsException(() => "1234".Left(5));
    
    // Right
    
    [TestMethod]
    public void Right_Core_Test() 
        => AreEqual("34", () => "1234".Right(2));
    
    [TestMethod]
    public void Right_NotEnoughCharacters_ThrowsException()
        => ThrowsException(() => "1234".Right(5));

    // CutLeft
    
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
    public void CutLeft_Char_NoMatch() 
        => AreEqual("Lalalaa", () => "Lalalaa".CutLeft('a'));
    
    [TestMethod]
    public void CutLeft_Char_OneMatch() 
        => AreEqual("laLala", () => "BlaLala".CutLeft('B'));
    
    [TestMethod]
    public void CutLeft_Char_MoreMatches_TrimsOne() 
        => AreEqual("BlaLala", () => "BBlaLala".CutLeft('B'));
    
    // CutRight

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
    public void CutRight_Char_NoMatch() 
        => AreEqual("Lalala", () => "Lalala".CutRight('l'));
    
    [TestMethod]
    public void CutRight_Char_OneMatch() 
        => AreEqual("Lalal", () => "Lalala".CutRight('a'));
    
    [TestMethod]
    public void CutRight_Char_MoreMatches_TrimsOne() 
        => AreEqual("Lalala", () => "Lalalaa".CutRight('a'));
    
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
}