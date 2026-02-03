
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
        const string a = "I am a STRING .  ";
        const string b = "   i am a string    . \t";
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
        const string c = "   i ÂM ã string   . \t";
        IsTrue(a.Is(c));
        IsTrue(c.Is(a));
        IsTrue(Is(a, c));
        IsTrue(Is(c, a));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMatters()
    {
        IsTrue (Is("\t test \t",   "\r TEST \r"                      ));
        IsTrue (Is("\t test \t",   "\r TEST \r", spaceMatters: false ));
        IsFalse(Is("\t test \t",   "\r TEST \r", spaceMatters: true  ));
        IsFalse(Is("\t test \t",   "\r TEST \r", spaceMatters        ));
        IsTrue (Is("\t test \t",   "\t TEST \t", spaceMatters: true  ));
        IsTrue (Is("\t test \t",   "\t TEST \t", spaceMatters        ));
        IsTrue (   "\t test \t".Is("\r TEST \r"                      ));
        IsTrue (   "\t test \t".Is("\r TEST \r", spaceMatters: false ));
        IsFalse(   "\t test \t".Is("\r TEST \r", spaceMatters: true  ));
        IsFalse(   "\t test \t".Is("\r TEST \r", spaceMatters        ));
        IsTrue (   "\t test \t".Is("\t TEST \t", spaceMatters: true  ));
        IsTrue (   "\t test \t".Is("\t TEST \t", spaceMatters        ));
        IsTrue (Is(spaceMatters: false, "\t test \t",   "\r TEST \r" ));
        IsFalse(Is(spaceMatters: true , "\t test \t",   "\r TEST \r" ));
        IsFalse(Is(spaceMatters       , "\t test \t",   "\r TEST \r" ));
        IsTrue (Is(spaceMatters: true , "\t test \t",   "\t TEST \t" ));
        IsTrue (Is(spaceMatters       , "\t test \t",   "\t TEST \t" ));
        IsTrue (   "\t test \t".Is(spaceMatters: false, "\r TEST \r" ));
        IsFalse(   "\t test \t".Is(spaceMatters: true , "\r TEST \r" ));
        IsFalse(   "\t test \t".Is(spaceMatters       , "\r TEST \r" ));
        IsTrue (   "\t test \t".Is(spaceMatters: true , "\t TEST \t" ));
        IsTrue (   "\t test \t".Is(spaceMatters       , "\t TEST \t" ));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersNoNo_ExtensionsFlagsInFront()
    {
        IsTrue ("  test  ".Is( "  test  "                                          ));
        IsTrue ("  test  ".Is( "\ttest\t"                                          ));
        IsTrue ("  test  ".Is( "  TEST  "                                          ));
        IsTrue ("  test  ".Is( "\tTEST\t"                                          ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false                     ));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  false                     ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false                     ));
        IsTrue ("  test  ".Is( "\tTEST\t", caseMatters:  false                     ));
        IsTrue ("  test  ".Is( "  test  ",               false                     ));
        IsTrue ("  test  ".Is( "\ttest\t",               false                     ));
        IsTrue ("  test  ".Is( "  TEST  ",               false                     ));
        IsTrue ("  test  ".Is( "\tTEST\t",               false                     ));
        IsTrue ("  test  ".Is( "  test  ",                      spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t",                      spaceMatters: false));
        IsTrue ("  test  ".Is( "  TEST  ",                      spaceMatters: false));
        IsTrue ("  test  ".Is( "\tTEST\t",                      spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false, spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  false, spaceMatters: false));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false, spaceMatters: false));
        IsTrue ("  test  ".Is( "\tTEST\t", caseMatters:  false, spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ",               false, spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t",               false, spaceMatters: false));
        IsTrue ("  test  ".Is( "  TEST  ",               false, spaceMatters: false));
        IsTrue ("  test  ".Is( "\tTEST\t",               false, spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ",                                    false));
        IsTrue ("  test  ".Is( "\ttest\t",                                    false));
        IsTrue ("  test  ".Is( "  TEST  ",                                    false));
        IsTrue ("  test  ".Is( "\tTEST\t",                                    false));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false,               false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  false,               false));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false,               false));
        IsTrue ("  test  ".Is( "\tTEST\t", caseMatters:  false,               false));
        IsTrue ("  test  ".Is( "  test  ",               false,               false));
        IsTrue ("  test  ".Is( "\ttest\t",               false,               false));
        IsTrue ("  test  ".Is( "  TEST  ",               false,               false));
        IsTrue ("  test  ".Is( "\tTEST\t",               false,               false));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersNoNo_ExtensionsFlagsInFrontSwapped()
    {
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters:  false));
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters:  false));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters:  false));
        IsTrue ("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters:  false));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersYesNo_ExtensionsFlagsInFront()
    {
        IsTrue ("  test  ".Is( "  test  ", caseMatters                             ));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters                             ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters                             ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters                             ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  true                      ));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  true                      ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters:  true                      ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  true                      ));
        IsTrue ("  test  ".Is( "  test  ",               true                      ));
        IsTrue ("  test  ".Is( "\ttest\t",               true                      ));
        IsFalse("  test  ".Is( "  TEST  ",               true                      ));
        IsFalse("  test  ".Is( "\tTEST\t",               true                      ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters,         spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters,         spaceMatters: false));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters,         spaceMatters: false));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters,         spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  true,  spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  true,  spaceMatters: false));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters:  true,  spaceMatters: false));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  true,  spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ",               true,  spaceMatters: false));
        IsTrue ("  test  ".Is( "\ttest\t",               true,  spaceMatters: false));
        IsFalse("  test  ".Is( "  TEST  ",               true,  spaceMatters: false));
        IsFalse("  test  ".Is( "\tTEST\t",               true,  spaceMatters: false));
        IsTrue ("  test  ".Is( "  test  ", caseMatters,                       false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters,                       false));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters,                       false));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters,                       false));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  true,                false));
        IsTrue ("  test  ".Is( "\ttest\t", caseMatters:  true,                false));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters:  true,                false));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  true,                false));
        IsTrue ("  test  ".Is( "  test  ",               true,                false));
        IsTrue ("  test  ".Is( "\ttest\t",               true,                false));
        IsFalse("  test  ".Is( "  TEST  ",               true,                false));
        IsFalse("  test  ".Is( "\tTEST\t",               true,                false));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersYesNo_ExtensionsFlagsInFrontSwapped()
    {
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters:  true ));
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters:  true ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters:  true ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters:  true ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters        ));
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters        )); 
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters        ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters        ));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersNoYes_Extensions()
    {
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
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false, spaceMatters: true )); // Swap flags
        IsFalse("  test  ".Is( "\ttest\t", caseMatters:  false, spaceMatters: true ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false, spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  false, spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false, spaceMatters       ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters:  false, spaceMatters       ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false, spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  false, spaceMatters       ));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersYesYes_Extensions()
    {
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
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,         caseMatters       )); // Swap flags
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
    public void Test_String_Is_SpaceMattersCaseMattersNoNo_Static()
    {
        IsTrue (Is("  test  ", "  test  "                                          ));
        IsTrue (Is("  test  ", "\ttest\t"                                          ));
        IsTrue (Is("  test  ", "  TEST  "                                          ));
        IsTrue (Is("  test  ", "\tTEST\t"                                          ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false                     ));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  false                     ));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false                     ));
        IsTrue (Is("  test  ", "\tTEST\t", caseMatters:  false                     ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false, spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  false, spaceMatters: false));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false, spaceMatters: false));
        IsTrue (Is("  test  ", "\tTEST\t", caseMatters:  false, spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ",                      spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t",                      spaceMatters: false));
        IsTrue (Is("  test  ", "  TEST  ",                      spaceMatters: false));
        IsTrue (Is("  test  ", "\tTEST\t",                      spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: false, caseMatters:  false)); // SSwap flags
        IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false, caseMatters:  false));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters: false, caseMatters:  false));
        IsTrue (Is("  test  ", "\tTEST\t", spaceMatters: false, caseMatters:  false));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersYesNo_Static()
    {
        IsTrue (Is("  test  ", "  test  ", caseMatters                             ));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters                             ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters                             ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters                             ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  true                      ));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  true                      ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters:  true                      ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  true                      ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  true,  spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  true,  spaceMatters: false));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters:  true,  spaceMatters: false));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  true,  spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ", caseMatters,         spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters,         spaceMatters: false));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters,         spaceMatters: false));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters,         spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: false, caseMatters:  true )); // Swap flags
        IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false, caseMatters:  true ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters: false, caseMatters:  true ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: false, caseMatters:  true ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: false, caseMatters        ));
        IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false, caseMatters        ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters: false, caseMatters        ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: false, caseMatters        ));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersNoYes_Static()
    {
        IsTrue (Is("  test  ", "  test  ", spaceMatters                            ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters                            ));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters                            ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters                            ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: true                      ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true                      ));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters: true                      ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true                      ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: true,  caseMatters:  false));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true,  caseMatters:  false));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters: true,  caseMatters:  false));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true,  caseMatters:  false));
        IsTrue (Is("  test  ", "  test  ", spaceMatters,        caseMatters:  false));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters,        caseMatters:  false));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters,        caseMatters:  false));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters,        caseMatters:  false));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false, spaceMatters: true )); // Swap flags
        IsFalse(Is("  test  ", "\ttest\t", caseMatters:  false, spaceMatters: true ));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false, spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  false, spaceMatters: true ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false, spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters:  false, spaceMatters       ));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false, spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  false, spaceMatters       ));
    }

    [TestMethod]
    public void Test_String_Is_SpaceMattersCaseMattersYesYes_Static()
    {
        IsTrue (Is("  test  ", "  test  ", caseMatters,         spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters,         spaceMatters       ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters,         spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters,         spaceMatters       ));
        IsTrue (Is("  test  ", "  test  ", caseMatters: true,   spaceMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters: true,   spaceMatters: true ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters: true,   spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters: true,   spaceMatters: true ));
        IsTrue (Is("  test  ", "  test  ", caseMatters: true,   spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters: true,   spaceMatters       ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters: true,   spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters: true,   spaceMatters       ));
        IsTrue (Is("  test  ", "  test  ", caseMatters,         spaceMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters,         spaceMatters: true ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters,         spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters,         spaceMatters: true ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters,         caseMatters       )); // Swap flags
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters,         caseMatters       ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters,         caseMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters,         caseMatters       ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: true,   caseMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true,   caseMatters: true ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters: true,   caseMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true,   caseMatters: true ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: true,   caseMatters       ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true,   caseMatters       ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters: true,   caseMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true,   caseMatters       ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters,         caseMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters,         caseMatters: true ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters,         caseMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters,         caseMatters: true ));
    }
}