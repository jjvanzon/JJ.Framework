
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Is_Tests_StaticFlagsInBack
{
    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoNo_StaticFlagsInBack()
    {
        IsTrue (Is("  test  ", "  test  "                                          ));
        IsTrue (Is("  test  ", "\ttest\t"                                          ));
        IsTrue (Is("  test  ", "  TEST  "                                          ));
        IsTrue (Is("  test  ", "\tTEST\t"                                          ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false                     ));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  false                     ));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false                     ));
        IsTrue (Is("  test  ", "\tTEST\t", caseMatters:  false                     ));
        IsTrue (Is("  test  ", "  test  ",               false                     ));
        IsTrue (Is("  test  ", "\ttest\t",               false                     ));
        IsTrue (Is("  test  ", "  TEST  ",               false                     ));
        IsTrue (Is("  test  ", "\tTEST\t",               false                     ));
        IsTrue (Is("  test  ", "  test  ",                      spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t",                      spaceMatters: false));
        IsTrue (Is("  test  ", "  TEST  ",                      spaceMatters: false));
        IsTrue (Is("  test  ", "\tTEST\t",                      spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false, spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  false, spaceMatters: false));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false, spaceMatters: false));
        IsTrue (Is("  test  ", "\tTEST\t", caseMatters:  false, spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ",               false, spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t",               false, spaceMatters: false));
        IsTrue (Is("  test  ", "  TEST  ",               false, spaceMatters: false));
        IsTrue (Is("  test  ", "\tTEST\t",               false, spaceMatters: false));
      //IsTrue (Is("  test  ", "  test  ",                                    false)); // Sets wrong parameter
      //IsTrue (Is("  test  ", "\ttest\t",                                    false));
      //IsTrue (Is("  test  ", "  TEST  ",                                    false));
      //IsTrue (Is("  test  ", "\tTEST\t",                                    false));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false,               false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  false,               false));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false,               false));
        IsTrue (Is("  test  ", "\tTEST\t", caseMatters:  false,               false));
        IsTrue (Is("  test  ", "  test  ",               false,               false));
        IsTrue (Is("  test  ", "\ttest\t",               false,               false));
        IsTrue (Is("  test  ", "  TEST  ",               false,               false));
        IsTrue (Is("  test  ", "\tTEST\t",               false,               false));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoNo_StaticFlagsInBackSwapped()
    {
      //IsTrue (Is("  test  ", "  test  "                                          )); // Not a swap
      //IsTrue (Is("  test  ", "\ttest\t"                                          ));
      //IsTrue (Is("  test  ", "  TEST  "                                          ));
      //IsTrue (Is("  test  ", "\tTEST\t"                                          ));
      //IsTrue (Is("  test  ", "  test  ",                      caseMatters:  false));
      //IsTrue (Is("  test  ", "\ttest\t",                      caseMatters:  false));
      //IsTrue (Is("  test  ", "  TEST  ",                      caseMatters:  false));
      //IsTrue (Is("  test  ", "\tTEST\t",                      caseMatters:  false));
      //IsTrue (Is("  test  ", "  test  ",                                    false));
      //IsTrue (Is("  test  ", "\ttest\t",                                    false));
      //IsTrue (Is("  test  ", "  TEST  ",                                    false));
      //IsTrue (Is("  test  ", "\tTEST\t",                                    false));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: false                     ));
        IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false                     ));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters: false                     ));
        IsTrue (Is("  test  ", "\tTEST\t", spaceMatters: false                     ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: false, caseMatters:  false));
        IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false, caseMatters:  false));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters: false, caseMatters:  false));
        IsTrue (Is("  test  ", "\tTEST\t", spaceMatters: false, caseMatters:  false));
      //IsTrue (Is("  test  ", "  test  ", spaceMatters: false,               false)); // TODO: Does not work
      //IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false,               false));
      //IsTrue (Is("  test  ", "  TEST  ", spaceMatters: false,               false));
      //IsTrue (Is("  test  ", "\tTEST\t", spaceMatters: false,               false));
      //IsTrue (Is("  test  ", "  test  ",               false                     )); // Sets other parameter
      //IsTrue (Is("  test  ", "\ttest\t",               false                     ));
      //IsTrue (Is("  test  ", "  TEST  ",               false                     ));
      //IsTrue (Is("  test  ", "\tTEST\t",               false                     ));
      //IsTrue (Is("  test  ", "  test  ",               false, caseMatters:  false)); // TODO: Does not work
      //IsTrue (Is("  test  ", "\ttest\t",               false, caseMatters:  false));
      //IsTrue (Is("  test  ", "  TEST  ",               false, caseMatters:  false));
      //IsTrue (Is("  test  ", "\tTEST\t",               false, caseMatters:  false));
      //IsTrue (Is("  test  ", "  test  ",               false,               false)); // Not a swap
      //IsTrue (Is("  test  ", "\ttest\t",               false,               false));
      //IsTrue (Is("  test  ", "  TEST  ",               false,               false));
      //IsTrue (Is("  test  ", "\tTEST\t",               false,               false));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoYes_StaticFlagsInBack()
    {
        IsTrue (Is("  test  ", "  test  ",                      spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t",                      spaceMatters       ));
        IsTrue (Is("  test  ", "  TEST  ",                      spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t",                      spaceMatters       ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false, spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters:  false, spaceMatters       ));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false, spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  false, spaceMatters       ));
        IsTrue (Is("  test  ", "  test  ",               false, spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t",               false, spaceMatters       ));
        IsTrue (Is("  test  ", "  TEST  ",               false, spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t",               false, spaceMatters       ));
        IsTrue (Is("  test  ", "  test  ",                      spaceMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t",                      spaceMatters: true ));
        IsTrue (Is("  test  ", "  TEST  ",                      spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t",                      spaceMatters: true ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false, spaceMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters:  false, spaceMatters: true ));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false, spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  false, spaceMatters: true ));
        IsTrue (Is("  test  ", "  test  ",               false, spaceMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t",               false, spaceMatters: true ));
        IsTrue (Is("  test  ", "  TEST  ",               false, spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t",               false, spaceMatters: true ));
      //IsTrue (Is("  test  ", "  test  ",                                    true )); // Sets other parmeter
      //IsFalse(Is("  test  ", "\ttest\t",                                    true ));
      //IsTrue (Is("  test  ", "  TEST  ",                                    true ));
      //IsFalse(Is("  test  ", "\tTEST\t",                                    true ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  false,               true ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters:  false,               true ));
        IsTrue (Is("  test  ", "  TEST  ", caseMatters:  false,               true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  false,               true ));
        IsTrue (Is("  test  ", "  test  ",               false,               true ));
        IsFalse(Is("  test  ", "\ttest\t",               false,               true ));
        IsTrue (Is("  test  ", "  TEST  ",               false,               true ));
        IsFalse(Is("  test  ", "\tTEST\t",               false,               true ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoYes_StaticFlagsInBackSwapped()
    {
        IsTrue (Is("  test  ", "  test  ", spaceMatters                            ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters                            ));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters                            ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters                            ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters,        caseMatters:  false));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters,        caseMatters:  false));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters,        caseMatters:  false));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters,        caseMatters:  false));
        IsTrue (Is("  test  ", "  test  ", spaceMatters,                      false));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters,                      false));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters,                      false));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters,                      false));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: true                      ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true                      ));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters: true                      ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true                      ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: true,  caseMatters:  false));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true,  caseMatters:  false));
        IsTrue (Is("  test  ", "  TEST  ", spaceMatters: true,  caseMatters:  false));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true,  caseMatters:  false));
      //IsTrue (Is("  test  ", "  test  ", spaceMatters: true,                false)); // TODO: Does not work
      //IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true,                false));
      //IsTrue (Is("  test  ", "  TEST  ", spaceMatters: true,                false));
      //IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true,                false));
      //IsTrue (Is("  test  ", "  test  ",               true                      )); // Sets other parameter
      //IsFalse(Is("  test  ", "\ttest\t",               true                      ));
      //IsTrue (Is("  test  ", "  TEST  ",               true                      ));
      //IsFalse(Is("  test  ", "\tTEST\t",               true                      ));
      //IsTrue (Is("  test  ", "  test  ",               true,  caseMatters:  false)); // TODO: Does not work
      //IsFalse(Is("  test  ", "\ttest\t",               true,  caseMatters:  false));
      //IsTrue (Is("  test  ", "  TEST  ",               true,  caseMatters:  false));
      //IsFalse(Is("  test  ", "\tTEST\t",               true,  caseMatters:  false));
      //IsTrue (Is("  test  ", "  test  ",               true,                false)); // Not a swap
      //IsFalse(Is("  test  ", "\ttest\t",               true,                false));
      //IsTrue (Is("  test  ", "  TEST  ",               true,                false));
      //IsFalse(Is("  test  ", "\tTEST\t",               true,                false));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesNo_StaticFlagsInBack()
    {
        IsTrue (Is("  test  ", "  test  ", caseMatters,         spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters,         spaceMatters: false));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters,         spaceMatters: false));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters,         spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  true,  spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  true,  spaceMatters: false));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters:  true,  spaceMatters: false));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  true,  spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ",               true,  spaceMatters: false));
        IsTrue (Is("  test  ", "\ttest\t",               true,  spaceMatters: false));
        IsFalse(Is("  test  ", "  TEST  ",               true,  spaceMatters: false));
        IsFalse(Is("  test  ", "\tTEST\t",               true,  spaceMatters: false));
        IsTrue (Is("  test  ", "  test  ", caseMatters,                       false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters,                       false));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters,                       false));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters,                       false));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  true,                false));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  true,                false));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters:  true,                false));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  true,                false));
        IsTrue (Is("  test  ", "  test  ",               true,                false));
        IsTrue (Is("  test  ", "\ttest\t",               true,                false));
        IsFalse(Is("  test  ", "  TEST  ",               true,                false));
        IsFalse(Is("  test  ", "\tTEST\t",               true,                false));
        IsTrue (Is("  test  ", "  test  ", caseMatters                             ));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters                             ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters                             ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters                             ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  true                      ));
        IsTrue (Is("  test  ", "\ttest\t", caseMatters:  true                      ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters:  true                      ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  true                      ));
        IsTrue (Is("  test  ", "  test  ",               true                      ));
        IsTrue (Is("  test  ", "\ttest\t",               true                      ));
        IsFalse(Is("  test  ", "  TEST  ",               true                      ));
        IsFalse(Is("  test  ", "\tTEST\t",               true                      ));
    }
    
    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesNo_StaticFlagsInBackSwapped()
    {
        IsTrue (Is("  test  ", "  test  ", spaceMatters: false, caseMatters        ));
        IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false, caseMatters        ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters: false, caseMatters        ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: false, caseMatters        ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: false, caseMatters:  true ));
        IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false, caseMatters:  true ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters: false, caseMatters:  true ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: false, caseMatters:  true ));
      //IsTrue (Is("  test  ", "  test  ", spaceMatters: false,               true )); // TODO: Does not work
      //IsTrue (Is("  test  ", "\ttest\t", spaceMatters: false,               true ));
      //IsFalse(Is("  test  ", "  TEST  ", spaceMatters: false,               true ));
      //IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: false,               true ));
        IsTrue (Is("  test  ", "  test  ",               false, caseMatters        ));
        IsTrue (Is("  test  ", "\ttest\t",               false, caseMatters        ));
        IsFalse(Is("  test  ", "  TEST  ",               false, caseMatters        ));
        IsFalse(Is("  test  ", "\tTEST\t",               false, caseMatters        ));
      //IsTrue (Is("  test  ", "  test  ",               false, caseMatters:  true )); // TODO: Does not work
      //IsTrue (Is("  test  ", "\ttest\t",               false, caseMatters:  true ));
      //IsFalse(Is("  test  ", "  TEST  ",               false, caseMatters:  true ));
      //IsFalse(Is("  test  ", "\tTEST\t",               false, caseMatters:  true ));
      //IsTrue (Is("  test  ", "  test  ",               false,               true )); // Not a swap
      //IsTrue (Is("  test  ", "\ttest\t",               false,               true ));
      //IsFalse(Is("  test  ", "  TEST  ",               false,               true ));
      //IsFalse(Is("  test  ", "\tTEST\t",               false,               true ));
        IsTrue (Is("  test  ", "  test  ",                      caseMatters        ));
        IsTrue (Is("  test  ", "\ttest\t",                      caseMatters        ));
        IsFalse(Is("  test  ", "  TEST  ",                      caseMatters        ));
        IsFalse(Is("  test  ", "\tTEST\t",                      caseMatters        ));
        IsTrue (Is("  test  ", "  test  ",                      caseMatters:  true ));
        IsTrue (Is("  test  ", "\ttest\t",                      caseMatters:  true ));
        IsFalse(Is("  test  ", "  TEST  ",                      caseMatters:  true ));
        IsFalse(Is("  test  ", "\tTEST\t",                      caseMatters:  true ));
      //IsTrue (Is("  test  ", "  test  ",                                    true )); // Not a swap
      //IsTrue (Is("  test  ", "\ttest\t",                                    true )); 
      //IsFalse(Is("  test  ", "  TEST  ",                                    true )); 
      //IsFalse(Is("  test  ", "\tTEST\t",                                    true )); 
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesYes_StaticFlagsInBack()
    {
        IsTrue (Is("  test  ", "  test  ", caseMatters,         spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters,         spaceMatters       ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters,         spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters,         spaceMatters       ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  true,  spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters:  true,  spaceMatters       ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters:  true,  spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  true,  spaceMatters       ));
        IsTrue (Is("  test  ", "  test  ",               true,  spaceMatters       ));
        IsFalse(Is("  test  ", "\ttest\t",               true,  spaceMatters       ));
        IsFalse(Is("  test  ", "  TEST  ",               true,  spaceMatters       ));
        IsFalse(Is("  test  ", "\tTEST\t",               true,  spaceMatters       ));
        IsTrue (Is("  test  ", "  test  ", caseMatters,         spaceMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters,         spaceMatters: true ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters,         spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters,         spaceMatters: true ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  true,  spaceMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters:  true,  spaceMatters: true ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters:  true,  spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  true,  spaceMatters: true ));
        IsTrue (Is("  test  ", "  test  ",               true,  spaceMatters: true ));
        IsFalse(Is("  test  ", "\ttest\t",               true,  spaceMatters: true ));
        IsFalse(Is("  test  ", "  TEST  ",               true,  spaceMatters: true ));
        IsFalse(Is("  test  ", "\tTEST\t",               true,  spaceMatters: true ));
        IsTrue (Is("  test  ", "  test  ", caseMatters,                       true ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters,                       true ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters,                       true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters,                       true ));
        IsTrue (Is("  test  ", "  test  ", caseMatters:  true,                true ));
        IsFalse(Is("  test  ", "\ttest\t", caseMatters:  true,                true ));
        IsFalse(Is("  test  ", "  TEST  ", caseMatters:  true,                true ));
        IsFalse(Is("  test  ", "\tTEST\t", caseMatters:  true,                true ));
        IsTrue (Is("  test  ", "  test  ",               true,                true ));
        IsFalse(Is("  test  ", "\ttest\t",               true,                true ));
        IsFalse(Is("  test  ", "  TEST  ",               true,                true ));
        IsFalse(Is("  test  ", "\tTEST\t",               true,                true ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesYes_StaticFlagsInBackFlagsSwapped()
    {
        IsTrue (Is("  test  ", "  test  ", spaceMatters,        caseMatters        ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters,        caseMatters        ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters,        caseMatters        ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters,        caseMatters        ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters,        caseMatters:  true ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters,        caseMatters:  true ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters,        caseMatters:  true ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters,        caseMatters:  true ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters,                      true ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters,                      true ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters,                      true ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters,                      true ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: true,  caseMatters        ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true,  caseMatters        ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters: true,  caseMatters        ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true,  caseMatters        ));
        IsTrue (Is("  test  ", "  test  ", spaceMatters: true,  caseMatters:  true ));
        IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true,  caseMatters:  true ));
        IsFalse(Is("  test  ", "  TEST  ", spaceMatters: true,  caseMatters:  true ));
        IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true,  caseMatters:  true ));
      //IsTrue (Is("  test  ", "  test  ", spaceMatters: true,                true )); // TODO: Does not work
      //IsFalse(Is("  test  ", "\ttest\t", spaceMatters: true,                true ));
      //IsFalse(Is("  test  ", "  TEST  ", spaceMatters: true,                true ));
      //IsFalse(Is("  test  ", "\tTEST\t", spaceMatters: true,                true ));
        IsTrue (Is("  test  ", "  test  ",               true,  caseMatters        ));
        IsFalse(Is("  test  ", "\ttest\t",               true,  caseMatters        ));
        IsFalse(Is("  test  ", "  TEST  ",               true,  caseMatters        ));
        IsFalse(Is("  test  ", "\tTEST\t",               true,  caseMatters        ));
      //IsTrue (Is("  test  ", "  test  ",               true,  caseMatters:  true )); // TODO: Does not work
      //IsFalse(Is("  test  ", "\ttest\t",               true,  caseMatters:  true ));
      //IsFalse(Is("  test  ", "  TEST  ",               true,  caseMatters:  true ));
      //IsFalse(Is("  test  ", "\tTEST\t",               true,  caseMatters:  true ));
      //IsTrue (Is("  test  ", "  test  ",               true,                true )); // Not a swap
      //IsFalse(Is("  test  ", "\ttest\t",               true,                true ));
      //IsFalse(Is("  test  ", "  TEST  ",               true,                true ));
      //IsFalse(Is("  test  ", "\tTEST\t",               true,                true ));
    }
}