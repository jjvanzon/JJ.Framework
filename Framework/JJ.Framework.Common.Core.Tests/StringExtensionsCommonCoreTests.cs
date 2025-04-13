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
    public void CutLeft_OneOccurrence()
    {
        string input = "BlaLala";
        string output = input.CutLeft("Bla");
        AreEqual("Lala", () => output);
    }

    [TestMethod]
    public void CutLeft_MultipleOccurrences_TrimsOne()
    {
        string input = "BlaBlaLala";
        string output = input.CutLeft("Bla");
        AreEqual("BlaLala", () => output);
    }
    
    [TestMethod]
    public void CutLeft_NoMatch()
    {
        string input  = "Lalalaa";
        string output = input.CutLeft("la");
        AreEqual("Lalalaa", () => output);
    }
    
    [TestMethod]
    public void CutLeft_Char_OneOccurrence()
    {
        string input  = "BlaLala";
        string output = input.CutLeft('B');
        AreEqual("laLala", () => output);
    }
    
    [TestMethod]
    public void CutLeft_Char_MultipleOccurrences_TrimsOne()
    {
        string input  = "BBlaLala";
        string output = input.CutLeft('B');
        AreEqual("BlaLala", () => output);
    }
    
    [TestMethod]
    public void CutLeft_NoMatch_Test()
    {
        string input  = "Lalalaa";
        string output = input.CutLeft("laa");
        AreEqual("Lalalaa", () => output);
    }
    
    // CutRight

    [TestMethod]
    public void CutRight_String_NoMatch()
    {
        string input  = "Lalalaa";
        string output = input.CutRight("la");
        AreEqual("Lalalaa", () => output);
    }

    [TestMethod]
    public void CutRight_String_OneOccurrence()
    {
        string input = "LalaBla";
        string output = input.CutRight("Bla");
        AreEqual("Lala", () => output);
    }
    
    [TestMethod]
    public void CutRight_String_MultipleOccurrences_TrimsOne()
    {
        string input = "LalaBlaBla";
        string output = input.CutRight("Bla");
        AreEqual("LalaBla", () => output);
    }
    
    [TestMethod]
    public void CutRight_Char_NoMatch()
    {
        string input  = "Lalala";
        string output = input.CutRight('l');
        AreEqual("Lalala", () => output);
    }
    
    [TestMethod]
    public void CutRight_Char_OneOccurrence()
    {
        string input  = "Lalala";
        string output = input.CutRight('a');
        AreEqual("Lalal", () => output);
    }
    
    [TestMethod]
    public void CutRight_Char_MultipleOccurrences_TrimsOne()
    {
        string input  = "Lalalaa";
        string output = input.CutRight('a');
        AreEqual("Lalala", () => output);
    }
    
    // FromTill
    
    [TestMethod]
    public void FromTill_Core_Test() 
        => AreEqual("34", () => "12345".FromTill(2, 3));
    
    [TestMethod]
    public void FromTill_FirstChar() 
        => AreEqual("1", () => "12345".FromTill(0, 0));
    
    [TestMethod]
    public void FromTill_StartIndexIsZero() 
        => AreEqual("12", () => "12345".FromTill(0, 1));
    
    [TestMethod]
    public void FromTill_StartIndexIsOne() 
        => AreEqual("23", () => "12345".FromTill(1, 2));
    
    [TestMethod]
    public void FromTill_EndIndexIsLast() 
        => AreEqual("12345", () => "12345".FromTill(0, 4));
    
    [TestMethod]
    public void FromTill_LastChar() 
        => AreEqual("5", () => "12345".FromTill(4, 4));
    
    [TestMethod]
    public void FromTill_OutsideLeftBound_ThrowsException() 
        => ThrowsException(() => "12345".FromTill(-1, 1));
    
    [TestMethod]
    public void FromTill_OutsideRightBound_ThrowsException() 
        => ThrowsException(() => "12345".FromTill(6, 8));
}