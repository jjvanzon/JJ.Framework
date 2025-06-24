
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
    public void Test_String_Is_SpaceMattersCaseMattersCombos_Extensions()
    {
        // CaseMatters/SpaceMatters No/No
        IsTrue ("  test  ".Is( "  test  "                                          ));
        IsTrue ("  test  ".Is( "\ttest\t"                                          ));
        IsTrue ("  test  ".Is( "  TEST  "                                          ));
        IsTrue ("  test  ".Is( "\tTEST\t"                                          ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false                     ));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  false                     ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false                     ));
        IsTrue ("  test  ".Is( "\tTEST\t", caseMatters:  false                     ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false, spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  false, spaceMatters: false));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false, spaceMatters: false));
        IsTrue ("  test  ".Is( "\tTEST\t", caseMatters:  false, spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ",                      spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t",                      spaceMatters: false));
        IsTrue ("  test  ".Is( "  TEST  ",                      spaceMatters: false));
        IsTrue ("  test  ".Is( "\tTEST\t",                      spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters:  false)); // Switch flags
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters:  false));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters:  false));
        IsTrue ("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters:  false));
        
        // CaseMatters/SpaceMatters Yes/No
        IsTrue ("  test  ".Is( "  test  ", caseMatters                             ));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters                             ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters                             ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters                             ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  true                      ));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  true                      ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters:  true                      ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  true                      ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  true,  spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  true,  spaceMatters: false));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters:  true,  spaceMatters: false));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  true,  spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ", caseMatters,         spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters,         spaceMatters: false));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters,         spaceMatters: false));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters,         spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters:  true )); // Switch flags
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters:  true ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters:  true ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters:  true ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters        ));
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters        ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters        ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters        ));
        
        // CaseMatters/SpaceMatters No/Yes
        IsTrue ("  test  ".Is( "  test  ", spaceMatters                            ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters                            ));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters                            ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters                            ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: true                      ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true                      ));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: true                      ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true                      ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: true,  caseMatters:  false));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true,  caseMatters:  false));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: true,  caseMatters:  false));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true,  caseMatters:  false));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,        caseMatters:  false));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters,        caseMatters:  false));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters,        caseMatters:  false));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters,        caseMatters:  false));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false, spaceMatters: true )); // Switch flags
        IsFalse("  test  ".Is( "\ttest\t", caseMatters:  false, spaceMatters: true ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false, spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  false, spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false, spaceMatters       ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters:  false, spaceMatters       ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false, spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  false, spaceMatters       ));
        
        // CaseMatters/SpaceMatters Yes/Yes
        IsTrue ("  test  ".Is( "  test  ", caseMatters,         spaceMatters       ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters,         spaceMatters       ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters,         spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters,         spaceMatters       ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters: true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters: true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters: true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters: true,   spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters: true,   spaceMatters       ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters: true,   spaceMatters       ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters: true,   spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters: true,   spaceMatters       ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters,         spaceMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters,         spaceMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters,         spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters,         spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,         caseMatters       )); // Switch flags
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters,         caseMatters       ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters,         caseMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters,         caseMatters       ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: true,   caseMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true,   caseMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: true,   caseMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true,   caseMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: true,   caseMatters       ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true,   caseMatters       ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: true,   caseMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true,   caseMatters       ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,         caseMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters,         caseMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters,         caseMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters,         caseMatters: true ));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersCombos_Static()
    {
        IsTrue (Is("  test  ", "\tTEST\t", caseMatters: false, spaceMatters: false));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters: false, spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters: true,  spaceMatters: false));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters: true,  spaceMatters: true ));
    }
}