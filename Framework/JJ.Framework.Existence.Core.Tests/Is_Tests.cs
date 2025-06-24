
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Is_Tests
{

    [TestMethod]
    public void Test_String_Is()
    {
        // NullOrWhiteSpace
        IsTrue(Is(NullText,   NullText));
        IsTrue(Is(" "     ,   NullText));
        IsTrue(   " "     .Is(NullText));
        IsTrue(Is(""      ,   " "     ));
        IsTrue(   ""      .Is(" "     ));
        IsTrue(Is(""      ,   "  \t"  ));
        IsTrue(   ""      .Is("  \t"  ));
        
        // Ignore Case
        IsTrue(Is("test",   "test"));
        IsTrue(Is("test",   "test", caseMatters: false));
        IsTrue(   "test".Is("test"));
        IsTrue(   "test".Is("test", caseMatters: false));
        IsTrue(Is("test",   "TEST"));
        IsTrue(Is("test",   "TEST", caseMatters: false));
        IsTrue(   "test".Is("TEST"));
        IsTrue(   "test".Is("TEST", caseMatters: false));
        IsTrue(Is("TEST",   "test"));
        IsTrue(Is("TEST",   "test", caseMatters: false));
        IsTrue(   "TEST".Is("test"));
        IsTrue(   "TEST".Is("test", caseMatters: false));
        
        // Bunch of white space and case mismatch
        IsTrue(Is("test",   "\r\n \t TEST  \n"));
        IsTrue(Is("test",   "\r\n \t TEST  \n", caseMatters: false));
        IsTrue(   "test".Is("\r\n \t TEST  \n"));
        IsTrue(   "test".Is("\r\n \t TEST  \n", caseMatters: false));
        IsTrue(Is("\r\n \t TEST  \n",   "test"));
        IsTrue(Is("\r\n \t TEST  \n",   "test", caseMatters: false));
        IsTrue(   "\r\n \t TEST  \n".Is("test"));
        IsTrue(   "\r\n \t TEST  \n".Is("test", caseMatters: false));
        
        // Excess white space
        string a = "I am a STRING .  ";
        string b = "   i am a string    . \t";
        IsTrue(a.Is(b));
        IsTrue(a.Is(b,  caseMatters: false));
        IsTrue(Is(a, b));
        IsTrue(Is(a, b, caseMatters: false));
        
        // Case-sensitive
        IsFalse("TEST".Is( "test", caseMatters      ));
        IsFalse("TEST".Is( "test", caseMatters: true));
        IsFalse(Is("test", "Test", caseMatters      ));
        IsFalse(Is("test", "Test", caseMatters: true));

        // Negative match
        IsFalse("Plant".Is("Animal"));
        IsFalse(Is("Animal", "Plant"));

        // Diacritics
        string c = "   i ÂM ã string   . \t";
        IsTrue(a.Is(c));
        IsTrue(c.Is(a));
        IsTrue(Is(a, c));
        IsTrue(Is(c, a));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMatters()
    {
        IsTrue (Is("\t test \t",   "\r TEST \r"                     ));
        IsTrue (Is("\t test \t",   "\r TEST \r", spaceMatters: false));
        IsFalse(Is("\t test \t",   "\r TEST \r", spaceMatters: true ));
        IsFalse(Is("\t test \t",   "\r TEST \r", spaceMatters       ));
        IsTrue (Is("\t test \t",   "\t TEST \t", spaceMatters: true ));
        IsTrue (Is("\t test \t",   "\t TEST \t", spaceMatters       ));
        IsTrue (   "\t test \t".Is("\r TEST \r"));
        IsTrue (   "\t test \t".Is("\r TEST \r", spaceMatters: false));
        IsFalse(   "\t test \t".Is("\r TEST \r", spaceMatters: true ));
        IsFalse(   "\t test \t".Is("\r TEST \r", spaceMatters       ));
        IsTrue (   "\t test \t".Is("\t TEST \t", spaceMatters: true ));
        IsTrue (   "\t test \t".Is("\t TEST \t", spaceMatters       ));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersCombos()
    {
        // TODO: Add more cases

        // Extensions
        IsTrue ("\t test \t".Is( "\r TEST \r", caseMatters: false, spaceMatters: false));
        IsFalse("\t test \t".Is( "\r TEST \r", caseMatters: false, spaceMatters: true ));
        IsFalse("\t test \t".Is( "\r TEST \r", caseMatters: true,  spaceMatters: false));
        IsFalse("\t test \t".Is( "\r TEST \r", caseMatters: true,  spaceMatters: true ));

        // Static
        IsTrue (Is("\t test \t", "\r TEST \r", caseMatters: false, spaceMatters: false));
        IsFalse(Is("\t test \t", "\r TEST \r", caseMatters: false, spaceMatters: true ));
        IsFalse(Is("\t test \t", "\r TEST \r", caseMatters: true,  spaceMatters: false));
        IsFalse(Is("\t test \t", "\r TEST \r", caseMatters: true,  spaceMatters: true ));
        
    }
}