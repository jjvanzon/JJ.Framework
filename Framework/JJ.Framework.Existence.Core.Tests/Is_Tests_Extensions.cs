namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Is_Tests_Extensions
{
    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoNo_ExtensionsFlagsInBack()
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
    public void Test_String_Is_CaseOrSpaceMattersNoNo_ExtensionsFlagsInBackSwapped()
    {
      //IsTrue ("  test  ".Is( "  test  "                                          )); // Not a swap
      //IsTrue ("  test  ".Is( "\ttest\t"                                          ));
      //IsTrue ("  test  ".Is( "  TEST  "                                          ));
      //IsTrue ("  test  ".Is( "\tTEST\t"                                          ));
      //IsTrue ("  test  ".Is( "  test  ",                      caseMatters:  false));
      //IsTrue ("  test  ".Is( "\ttest\t",                      caseMatters:  false));
      //IsTrue ("  test  ".Is( "  TEST  ",                      caseMatters:  false));
      //IsTrue ("  test  ".Is( "\tTEST\t",                      caseMatters:  false));
      //IsTrue ("  test  ".Is( "  test  ",                                    false));
      //IsTrue ("  test  ".Is( "\ttest\t",                                    false));
      //IsTrue ("  test  ".Is( "  TEST  ",                                    false));
      //IsTrue ("  test  ".Is( "\tTEST\t",                                    false));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false                     ));
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false                     ));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: false                     ));
        IsTrue ("  test  ".Is( "\tTEST\t", spaceMatters: false                     ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters:  false));
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters:  false));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters:  false));
        IsTrue ("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters:  false));
      //IsTrue ("  test  ".Is( "  test  ", spaceMatters: false,               false)); // TODO: Does not work
      //IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false,               false));
      //IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: false,               false));
      //IsTrue ("  test  ".Is( "\tTEST\t", spaceMatters: false,               false));
      //IsTrue ("  test  ".Is( "  test  ",               false                     )); // Not a swap
      //IsTrue ("  test  ".Is( "\ttest\t",               false                     ));
      //IsTrue ("  test  ".Is( "  TEST  ",               false                     ));
      //IsTrue ("  test  ".Is( "\tTEST\t",               false                     ));
      //IsTrue ("  test  ".Is( "  test  ",               false, caseMatters:  false)); // TODO: Does not work
      //IsTrue ("  test  ".Is( "\ttest\t",               false, caseMatters:  false));
      //IsTrue ("  test  ".Is( "  TEST  ",               false, caseMatters:  false));
      //IsTrue ("  test  ".Is( "\tTEST\t",               false, caseMatters:  false));
      //IsTrue ("  test  ".Is( "  test  ",               false,               false)); // Not a swap
      //IsTrue ("  test  ".Is( "\ttest\t",               false,               false));
      //IsTrue ("  test  ".Is( "  TEST  ",               false,               false));
      //IsTrue ("  test  ".Is( "\tTEST\t",               false,               false));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesNo_ExtensionsFlagsInBack()
    {
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
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesNo_ExtensionsFlagsInBackSwapped()
    {
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters          ));
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters          ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters          ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters          ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: false, caseMatters:  true   ));
        IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false, caseMatters:  true   ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: false, caseMatters:  true   ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: false, caseMatters:  true   ));
      //IsTrue ("  test  ".Is( "  test  ", spaceMatters: false,               true   )); // TODO: Does not work
      //IsTrue ("  test  ".Is( "\ttest\t", spaceMatters: false,               true   ));
      //IsFalse("  test  ".Is( "  TEST  ", spaceMatters: false,               true   ));
      //IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: false,               true   ));
        IsTrue ("  test  ".Is( "  test  ",               false, caseMatters          ));
        IsTrue ("  test  ".Is( "\ttest\t",               false, caseMatters          ));
        IsFalse("  test  ".Is( "  TEST  ",               false, caseMatters          ));
        IsFalse("  test  ".Is( "\tTEST\t",               false, caseMatters          ));
      //IsTrue ("  test  ".Is( "  test  ",               false, caseMatters:  true   )); // TODO: Does not work
      //IsTrue ("  test  ".Is( "\ttest\t",               false, caseMatters:  true   ));
      //IsFalse("  test  ".Is( "  TEST  ",               false, caseMatters:  true   ));
      //IsFalse("  test  ".Is( "\tTEST\t",               false, caseMatters:  true   ));
      //IsTrue ("  test  ".Is( "  test  ",               false, caseMatters:  true   )); // Not a swap
      //IsTrue ("  test  ".Is( "\ttest\t",               false,               true   ));
      //IsFalse("  test  ".Is( "  TEST  ",               false,               true   ));
      //IsFalse("  test  ".Is( "\tTEST\t",               false,               true   ));
      //IsTrue ("  test  ".Is( "  test  ",                      caseMatters          ));
      //IsTrue ("  test  ".Is( "\ttest\t",                      caseMatters          ));
      //IsFalse("  test  ".Is( "  TEST  ",                      caseMatters          ));
      //IsFalse("  test  ".Is( "\tTEST\t",                      caseMatters          ));
      //IsTrue ("  test  ".Is( "  test  ",                      caseMatters:  true   ));
      //IsTrue ("  test  ".Is( "\ttest\t",                      caseMatters:  true   ));
      //IsFalse("  test  ".Is( "  TEST  ",                      caseMatters:  true   ));
      //IsFalse("  test  ".Is( "\tTEST\t",                      caseMatters:  true   ));
      //IsTrue ("  test  ".Is( "  test  ",                                    true   ));
      //IsTrue ("  test  ".Is( "\ttest\t",                                    true   ));
      //IsFalse("  test  ".Is( "  TEST  ",                                    true   ));
      //IsFalse("  test  ".Is( "\tTEST\t",                                    true   ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoYes_ExtensionsFlagsInBack()
    {
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false, spaceMatters       )); 
        IsFalse("  test  ".Is( "\ttest\t", caseMatters:  false, spaceMatters       ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false, spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  false, spaceMatters       ));
        IsTrue ("  test  ".Is( "  test  ",               false, spaceMatters       )); 
        IsFalse("  test  ".Is( "\ttest\t",               false, spaceMatters       ));
        IsTrue ("  test  ".Is( "  TEST  ",               false, spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t",               false, spaceMatters       ));
        IsTrue ("  test  ".Is( "  test  ",                      spaceMatters       )); 
        IsFalse("  test  ".Is( "\ttest\t",                      spaceMatters       ));
        IsTrue ("  test  ".Is( "  TEST  ",                      spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t",                      spaceMatters       ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false, spaceMatters: true )); 
        IsFalse("  test  ".Is( "\ttest\t", caseMatters:  false, spaceMatters: true ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false, spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  false, spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ",               false, spaceMatters: true )); 
        IsFalse("  test  ".Is( "\ttest\t",               false, spaceMatters: true ));
        IsTrue ("  test  ".Is( "  TEST  ",               false, spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t",               false, spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ",                      spaceMatters: true )); 
        IsFalse("  test  ".Is( "\ttest\t",                      spaceMatters: true ));
        IsTrue ("  test  ".Is( "  TEST  ",                      spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t",                      spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters:  false,               true )); 
        IsFalse("  test  ".Is( "\ttest\t", caseMatters:  false,               true ));
        IsTrue ("  test  ".Is( "  TEST  ", caseMatters:  false,               true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters:  false,               true ));
        IsTrue ("  test  ".Is( "  test  ",               false,               true )); 
        IsFalse("  test  ".Is( "\ttest\t",               false,               true ));
        IsTrue ("  test  ".Is( "  TEST  ",               false,               true ));
        IsFalse("  test  ".Is( "\tTEST\t",               false,               true ));
      //IsTrue ("  test  ".Is( "  test  ",                                    true )); // Assigns wrong parameter
      //IsFalse("  test  ".Is( "\ttest\t",                                    true ));
      //IsTrue ("  test  ".Is( "  TEST  ",                                    true ));
      //IsFalse("  test  ".Is( "\tTEST\t",                                    true ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoYes_ExtensionsFlagsInBackSwapped()
    {
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,       caseMatters:  false )); 
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters,       caseMatters:  false ));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters,       caseMatters:  false ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters,       caseMatters:  false ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,                     false )); 
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters,                     false ));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters,                     false ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters,                     false ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters                            )); 
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters                            ));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters                            ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters                            ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: true, caseMatters:  false )); 
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true, caseMatters:  false ));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: true, caseMatters:  false ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true, caseMatters:  false ));
      //IsTrue ("  test  ".Is( "  test  ", spaceMatters: true,               false )); // TODO: Does not work 
      //IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true,               false ));
      //IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: true,               false ));
      //IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true,               false ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: true                      )); 
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true                      ));
        IsTrue ("  test  ".Is( "  TEST  ", spaceMatters: true                      ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true                      ));
      //IsTrue ("  test  ".Is( "  test  ",               true, caseMatters:  false )); // TODO: Does not work
      //IsFalse("  test  ".Is( "\ttest\t",               true, caseMatters:  false ));
      //IsTrue ("  test  ".Is( "  TEST  ",               true, caseMatters:  false ));
      //IsFalse("  test  ".Is( "\tTEST\t",               true, caseMatters:  false ));
      //IsTrue ("  test  ".Is( "  test  ",               true,               false )); // Not a swap
      //IsFalse("  test  ".Is( "\ttest\t",               true,               false ));
      //IsTrue ("  test  ".Is( "  TEST  ",               true,               false ));
      //IsFalse("  test  ".Is( "\tTEST\t",               true,               false ));
      //IsTrue ("  test  ".Is( "  test  ",               true,               false ));
      //IsFalse("  test  ".Is( "\ttest\t",               true,                     ));
      //IsTrue ("  test  ".Is( "  TEST  ",               true,                     ));
      //IsFalse("  test  ".Is( "\tTEST\t",               true,                     ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesYes_ExtensionsFlagsInBack()
    {
        IsTrue ("  test  ".Is( "  test  ", caseMatters,         spaceMatters       ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters,         spaceMatters       ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters,         spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters,         spaceMatters       ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters,         spaceMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters,         spaceMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters,         spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters,         spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters,                       true ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters,                       true ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters,                       true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters,                       true ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters: true,   spaceMatters       ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters: true,   spaceMatters       ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters: true,   spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters: true,   spaceMatters       ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters: true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters: true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters: true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters: true,   spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", caseMatters: true,                 true ));
        IsFalse("  test  ".Is( "\ttest\t", caseMatters: true,                 true ));
        IsFalse("  test  ".Is( "  TEST  ", caseMatters: true,                 true ));
        IsFalse("  test  ".Is( "\tTEST\t", caseMatters: true,                 true ));
        IsTrue ("  test  ".Is( "  test  ",              true,   spaceMatters       ));
        IsFalse("  test  ".Is( "\ttest\t",              true,   spaceMatters       ));
        IsFalse("  test  ".Is( "  TEST  ",              true,   spaceMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t",              true,   spaceMatters       ));
        IsTrue ("  test  ".Is( "  test  ",              true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t",              true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ",              true,   spaceMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t",              true,   spaceMatters: true ));
        IsTrue ("  test  ".Is( "  test  ",              true,                 true ));
        IsFalse("  test  ".Is( "\ttest\t",              true,                 true ));
        IsFalse("  test  ".Is( "  TEST  ",              true,                 true ));
        IsFalse("  test  ".Is( "\tTEST\t",              true,                 true ));
    }                                                   

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesYes_ExtensionsFlagsInBackSwapped()
    {
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,         caseMatters       )); 
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters,         caseMatters       ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters,         caseMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters,         caseMatters       ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,         caseMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters,         caseMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters,         caseMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters,         caseMatters: true ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters,                      true ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters,                      true ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters,                      true ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters,                      true ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: true,   caseMatters       ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true,   caseMatters       ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: true,   caseMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true,   caseMatters       ));
        IsTrue ("  test  ".Is( "  test  ", spaceMatters: true,   caseMatters: true ));
        IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true,   caseMatters: true ));
        IsFalse("  test  ".Is( "  TEST  ", spaceMatters: true,   caseMatters: true ));
        IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true,   caseMatters: true ));
      //IsTrue ("  test  ".Is( "  test  ", spaceMatters: true,                true )); // TODO: Does not work
      //IsFalse("  test  ".Is( "\ttest\t", spaceMatters: true,                true ));
      //IsFalse("  test  ".Is( "  TEST  ", spaceMatters: true,                true ));
      //IsFalse("  test  ".Is( "\tTEST\t", spaceMatters: true,                true ));
        IsTrue ("  test  ".Is( "  test  ",               true,   caseMatters       ));
        IsFalse("  test  ".Is( "\ttest\t",               true,   caseMatters       ));
        IsFalse("  test  ".Is( "  TEST  ",               true,   caseMatters       ));
        IsFalse("  test  ".Is( "\tTEST\t",               true,   caseMatters       ));
      //IsTrue ("  test  ".Is( "  test  ",               true,   caseMatters: true )); // TODO: Does not work
      //IsFalse("  test  ".Is( "\ttest\t",               true,   caseMatters: true ));
      //IsFalse("  test  ".Is( "  TEST  ",               true,   caseMatters: true ));
      //IsFalse("  test  ".Is( "\tTEST\t",               true,   caseMatters: true ));
      //IsTrue ("  test  ".Is( "  test  ",               true,                true )); // Not a swap
      //IsFalse("  test  ".Is( "\ttest\t",               true,                true ));
      //IsFalse("  test  ".Is( "  TEST  ",               true,                true ));
      //IsFalse("  test  ".Is( "\tTEST\t",               true,                true ));
    }

}