namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Is_Tests_ExtensionsFlagsInFront
{
    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoNo_ExtensionsFlagsInFront()
    {
        IsTrue ("  test  ".Is(                                          "  test  "));
        IsTrue ("  test  ".Is(                                          "\ttest\t"));
        IsTrue ("  test  ".Is(                                          "  TEST  "));
        IsTrue ("  test  ".Is(                                          "\tTEST\t"));
        IsTrue ("  test  ".Is(caseMatters:  false                     , "  test  "));
        IsTrue ("  test  ".Is(caseMatters:  false                     , "\ttest\t"));
        IsTrue ("  test  ".Is(caseMatters:  false                     , "  TEST  "));
        IsTrue ("  test  ".Is(caseMatters:  false                     , "\tTEST\t"));
        IsTrue ("  test  ".Is(              false                     , "  test  "));
        IsTrue ("  test  ".Is(              false                     , "\ttest\t"));
        IsTrue ("  test  ".Is(              false                     , "  TEST  "));
        IsTrue ("  test  ".Is(              false                     , "\tTEST\t"));
        IsTrue ("  test  ".Is(                     spaceMatters: false, "  test  "));
        IsTrue ("  test  ".Is(                     spaceMatters: false, "\ttest\t"));
        IsTrue ("  test  ".Is(                     spaceMatters: false, "  TEST  "));
        IsTrue ("  test  ".Is(                     spaceMatters: false, "\tTEST\t"));
        IsTrue ("  test  ".Is(caseMatters:  false, spaceMatters: false, "  test  "));
        IsTrue ("  test  ".Is(caseMatters:  false, spaceMatters: false, "\ttest\t"));
        IsTrue ("  test  ".Is(caseMatters:  false, spaceMatters: false, "  TEST  "));
        IsTrue ("  test  ".Is(caseMatters:  false, spaceMatters: false, "\tTEST\t"));
        IsTrue ("  test  ".Is(              false, spaceMatters: false, "  test  "));
        IsTrue ("  test  ".Is(              false, spaceMatters: false, "\ttest\t"));
        IsTrue ("  test  ".Is(              false, spaceMatters: false, "  TEST  "));
        IsTrue ("  test  ".Is(              false, spaceMatters: false, "\tTEST\t"));
        IsTrue ("  test  ".Is(                                   false, "  test  "));
        IsTrue ("  test  ".Is(                                   false, "\ttest\t"));
        IsTrue ("  test  ".Is(                                   false, "  TEST  "));
        IsTrue ("  test  ".Is(                                   false, "\tTEST\t"));
        IsTrue ("  test  ".Is(caseMatters:  false,               false, "  test  "));
        IsTrue ("  test  ".Is(caseMatters:  false,               false, "\ttest\t"));
        IsTrue ("  test  ".Is(caseMatters:  false,               false, "  TEST  "));
        IsTrue ("  test  ".Is(caseMatters:  false,               false, "\tTEST\t"));
        IsTrue ("  test  ".Is(              false,               false, "  test  "));
        IsTrue ("  test  ".Is(              false,               false, "\ttest\t"));
        IsTrue ("  test  ".Is(              false,               false, "  TEST  "));
        IsTrue ("  test  ".Is(              false,               false, "\tTEST\t"));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoNo_ExtensionsFlagsInFrontSwapped()
    {
      //IsTrue ("  test  ".Is(                                         , "  test  ")); // Not a swap
      //IsTrue ("  test  ".Is(                                         , "\ttest\t"));
      //IsTrue ("  test  ".Is(                                         , "  TEST  "));
      //IsTrue ("  test  ".Is(                                         , "\tTEST\t"));
      //IsTrue ("  test  ".Is(                      caseMatters:  false, "  test  "));
      //IsTrue ("  test  ".Is(                      caseMatters:  false, "\ttest\t"));
      //IsTrue ("  test  ".Is(                      caseMatters:  false, "  TEST  "));
      //IsTrue ("  test  ".Is(                      caseMatters:  false, "\tTEST\t"));
      //IsTrue ("  test  ".Is(                                    false, "  test  "));
      //IsTrue ("  test  ".Is(                                    false, "\ttest\t"));
      //IsTrue ("  test  ".Is(                                    false, "  TEST  "));
      //IsTrue ("  test  ".Is(                                    false, "\tTEST\t"));
        IsTrue ("  test  ".Is( spaceMatters: false                     , "  test  "));
        IsTrue ("  test  ".Is( spaceMatters: false                     , "\ttest\t"));
        IsTrue ("  test  ".Is( spaceMatters: false                     , "  TEST  "));
        IsTrue ("  test  ".Is( spaceMatters: false                     , "\tTEST\t"));
      //IsTrue ("  test  ".Is( spaceMatters: false, caseMatters:  false, "  test  ")); // TODO: Does not work
      //IsTrue ("  test  ".Is( spaceMatters: false, caseMatters:  false, "\ttest\t"));
      //IsTrue ("  test  ".Is( spaceMatters: false, caseMatters:  false, "  TEST  "));
      //IsTrue ("  test  ".Is( spaceMatters: false, caseMatters:  false, "\tTEST\t"));
        IsTrue ("  test  ".Is( spaceMatters: false,               false, "  test  "));
        IsTrue ("  test  ".Is( spaceMatters: false,               false, "\ttest\t"));
        IsTrue ("  test  ".Is( spaceMatters: false,               false, "  TEST  "));
        IsTrue ("  test  ".Is( spaceMatters: false,               false, "\tTEST\t"));
      //IsTrue ("  test  ".Is(               false                     , "  test  ")); // Not a swap
      //IsTrue ("  test  ".Is(               false                     , "\ttest\t"));
      //IsTrue ("  test  ".Is(               false                     , "  TEST  "));
      //IsTrue ("  test  ".Is(               false                     , "\tTEST\t"));
        IsTrue ("  test  ".Is(               false, caseMatters:  false, "  test  "));
        IsTrue ("  test  ".Is(               false, caseMatters:  false, "\ttest\t"));
        IsTrue ("  test  ".Is(               false, caseMatters:  false, "  TEST  "));
        IsTrue ("  test  ".Is(               false, caseMatters:  false, "\tTEST\t"));
      //IsTrue ("  test  ".Is(               false,               false, "  test  ")); // Not a swap
      //IsTrue ("  test  ".Is(               false,               false, "\ttest\t"));
      //IsTrue ("  test  ".Is(               false,               false, "  TEST  "));
      //IsTrue ("  test  ".Is(               false,               false, "\tTEST\t"));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesNo_ExtensionsFlagsInFront()
    {
        IsTrue ("  test  ".Is(caseMatters,         spaceMatters: false, "  test  " ));
        IsTrue ("  test  ".Is(caseMatters,         spaceMatters: false, "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters,         spaceMatters: false, "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters,         spaceMatters: false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters:  true,  spaceMatters: false, "  test  " ));
        IsTrue ("  test  ".Is(caseMatters:  true,  spaceMatters: false, "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters:  true,  spaceMatters: false, "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters:  true,  spaceMatters: false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(              true,  spaceMatters: false, "  test  " ));
        IsTrue ("  test  ".Is(              true,  spaceMatters: false, "\ttest\t" ));
        IsFalse("  test  ".Is(              true,  spaceMatters: false, "  TEST  " ));
        IsFalse("  test  ".Is(              true,  spaceMatters: false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters,                       false, "  test  " ));
        IsTrue ("  test  ".Is(caseMatters,                       false, "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters,                       false, "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters,                       false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters:  true,                false, "  test  " ));
        IsTrue ("  test  ".Is(caseMatters:  true,                false, "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters:  true,                false, "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters:  true,                false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(              true,                false, "  test  " ));
        IsTrue ("  test  ".Is(              true,                false, "\ttest\t" ));
        IsFalse("  test  ".Is(              true,                false, "  TEST  " ));
        IsFalse("  test  ".Is(              true,                false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters                             , "  test  " ));
        IsTrue ("  test  ".Is(caseMatters                             , "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters                             , "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters                             , "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters:  true                      , "  test  " ));
        IsTrue ("  test  ".Is(caseMatters:  true                      , "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters:  true                      , "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters:  true                      , "\tTEST\t" ));
        IsTrue ("  test  ".Is(              true                      , "  test  " ));
        IsTrue ("  test  ".Is(              true                      , "\ttest\t" ));
        IsFalse("  test  ".Is(              true                      , "  TEST  " ));
        IsFalse("  test  ".Is(              true                      , "\tTEST\t" ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesNo_ExtensionsFlagsInFrontSwapped()
    {
        IsTrue ("  test  ".Is( spaceMatters: false, caseMatters       , "  test  " ));
        IsTrue ("  test  ".Is( spaceMatters: false, caseMatters       , "\ttest\t" ));
        IsFalse("  test  ".Is( spaceMatters: false, caseMatters       , "  TEST  " ));
        IsFalse("  test  ".Is( spaceMatters: false, caseMatters       , "\tTEST\t" ));
      //IsTrue ("  test  ".Is( spaceMatters: false, caseMatters:  true, "  test  " )); // TODO: Does not work
      //IsTrue ("  test  ".Is( spaceMatters: false, caseMatters:  true, "\ttest\t" ));
      //IsFalse("  test  ".Is( spaceMatters: false, caseMatters:  true, "  TEST  " ));
      //IsFalse("  test  ".Is( spaceMatters: false, caseMatters:  true, "\tTEST\t" ));
        IsTrue ("  test  ".Is( spaceMatters: false,               true, "  test  " ));
        IsTrue ("  test  ".Is( spaceMatters: false,               true, "\ttest\t" ));
        IsFalse("  test  ".Is( spaceMatters: false,               true, "  TEST  " ));
        IsFalse("  test  ".Is( spaceMatters: false,               true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(               false, caseMatters       , "  test  " ));
        IsTrue ("  test  ".Is(               false, caseMatters       , "\ttest\t" ));
        IsFalse("  test  ".Is(               false, caseMatters       , "  TEST  " ));
        IsFalse("  test  ".Is(               false, caseMatters       , "\tTEST\t" ));
        IsTrue ("  test  ".Is(               false, caseMatters:  true, "  test  " ));
        IsTrue ("  test  ".Is(               false, caseMatters:  true, "\ttest\t" ));
        IsFalse("  test  ".Is(               false, caseMatters:  true, "  TEST  " ));
        IsFalse("  test  ".Is(               false, caseMatters:  true, "\tTEST\t" ));
      //IsTrue ("  test  ".Is(               false, caseMatters:  true, "  test  " )); // Not a swap
      //IsTrue ("  test  ".Is(               false,               true, "\ttest\t" ));
      //IsFalse("  test  ".Is(               false,               true, "  TEST  " ));
      //IsFalse("  test  ".Is(               false,               true, "\tTEST\t" ));
      //IsTrue ("  test  ".Is(                      caseMatters       , "  test  " ));
      //IsTrue ("  test  ".Is(                      caseMatters       , "\ttest\t" ));
      //IsFalse("  test  ".Is(                      caseMatters       , "  TEST  " ));
      //IsFalse("  test  ".Is(                      caseMatters       , "\tTEST\t" ));
      //IsTrue ("  test  ".Is(                      caseMatters:  true, "  test  " ));
      //IsTrue ("  test  ".Is(                      caseMatters:  true, "\ttest\t" ));
      //IsFalse("  test  ".Is(                      caseMatters:  true, "  TEST  " ));
      //IsFalse("  test  ".Is(                      caseMatters:  true, "\tTEST\t" ));
      //IsTrue ("  test  ".Is(                                    true, "  test  " ));
      //IsTrue ("  test  ".Is(                                    true, "\ttest\t" ));
      //IsFalse("  test  ".Is(                                    true, "  TEST  " ));
      //IsFalse("  test  ".Is(                                    true, "\tTEST\t" ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoYes_ExtensionsFlagsInFront()
    {
        IsTrue ("  test  ".Is(caseMatters:  false, spaceMatters      ,  "  test  " )); 
        IsFalse("  test  ".Is(caseMatters:  false, spaceMatters      ,  "\ttest\t" ));
        IsTrue ("  test  ".Is(caseMatters:  false, spaceMatters      ,  "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters:  false, spaceMatters      ,  "\tTEST\t" ));
        IsTrue ("  test  ".Is(              false, spaceMatters      ,  "  test  " )); 
        IsFalse("  test  ".Is(              false, spaceMatters      ,  "\ttest\t" ));
        IsTrue ("  test  ".Is(              false, spaceMatters      ,  "  TEST  " ));
        IsFalse("  test  ".Is(              false, spaceMatters      ,  "\tTEST\t" ));
        IsTrue ("  test  ".Is(                     spaceMatters      ,  "  test  " )); 
        IsFalse("  test  ".Is(                     spaceMatters      ,  "\ttest\t" ));
        IsTrue ("  test  ".Is(                     spaceMatters      ,  "  TEST  " ));
        IsFalse("  test  ".Is(                     spaceMatters      ,  "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters:  false, spaceMatters: true,  "  test  " )); 
        IsFalse("  test  ".Is(caseMatters:  false, spaceMatters: true,  "\ttest\t" ));
        IsTrue ("  test  ".Is(caseMatters:  false, spaceMatters: true,  "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters:  false, spaceMatters: true,  "\tTEST\t" ));
        IsTrue ("  test  ".Is(              false, spaceMatters: true,  "  test  " )); 
        IsFalse("  test  ".Is(              false, spaceMatters: true,  "\ttest\t" ));
        IsTrue ("  test  ".Is(              false, spaceMatters: true,  "  TEST  " ));
        IsFalse("  test  ".Is(              false, spaceMatters: true,  "\tTEST\t" ));
        IsTrue ("  test  ".Is(                     spaceMatters: true,  "  test  " )); 
        IsFalse("  test  ".Is(                     spaceMatters: true,  "\ttest\t" ));
        IsTrue ("  test  ".Is(                     spaceMatters: true,  "  TEST  " ));
        IsFalse("  test  ".Is(                     spaceMatters: true,  "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters:  false,               true,  "  test  " )); 
        IsFalse("  test  ".Is(caseMatters:  false,               true,  "\ttest\t" ));
        IsTrue ("  test  ".Is(caseMatters:  false,               true,  "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters:  false,               true,  "\tTEST\t" ));
        IsTrue ("  test  ".Is(              false,               true,  "  test  " )); 
        IsFalse("  test  ".Is(              false,               true,  "\ttest\t" ));
        IsTrue ("  test  ".Is(              false,               true,  "  TEST  " ));
        IsFalse("  test  ".Is(              false,               true,  "\tTEST\t" ));
      //IsTrue ("  test  ".Is(                                   true,  "  test  " )); // Assigns wrong parameter
      //IsFalse("  test  ".Is(                                   true,  "\ttest\t" ));
      //IsTrue ("  test  ".Is(                                   true,  "  TEST  " ));
      //IsFalse("  test  ".Is(                                   true,  "\tTEST\t" ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoYes_ExtensionsFlagsInFrontSwapped()
    {
        IsTrue ("  test  ".Is(spaceMatters,       caseMatters:  false, "  test  " )); 
        IsFalse("  test  ".Is(spaceMatters,       caseMatters:  false, "\ttest\t" ));
        IsTrue ("  test  ".Is(spaceMatters,       caseMatters:  false, "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters,       caseMatters:  false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(spaceMatters,                     false, "  test  " )); 
        IsFalse("  test  ".Is(spaceMatters,                     false, "\ttest\t" ));
        IsTrue ("  test  ".Is(spaceMatters,                     false, "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters,                     false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(spaceMatters                           , "  test  " )); 
        IsFalse("  test  ".Is(spaceMatters                           , "\ttest\t" ));
        IsTrue ("  test  ".Is(spaceMatters                           , "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters                           , "\tTEST\t" ));
      //IsTrue ("  test  ".Is(spaceMatters: true, caseMatters:  false, "  test  " )); // TODO: Does not work 
      //IsFalse("  test  ".Is(spaceMatters: true, caseMatters:  false, "\ttest\t" ));
      //IsTrue ("  test  ".Is(spaceMatters: true, caseMatters:  false, "  TEST  " ));
      //IsFalse("  test  ".Is(spaceMatters: true, caseMatters:  false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(spaceMatters: true,               false, "  test  " ));
        IsFalse("  test  ".Is(spaceMatters: true,               false, "\ttest\t" ));
        IsTrue ("  test  ".Is(spaceMatters: true,               false, "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters: true,               false, "\tTEST\t" ));
        IsTrue ("  test  ".Is(spaceMatters: true                     , "  test  " )); 
        IsFalse("  test  ".Is(spaceMatters: true                     , "\ttest\t" ));
        IsTrue ("  test  ".Is(spaceMatters: true                     , "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters: true                     , "\tTEST\t" ));
        IsTrue ("  test  ".Is(              true, caseMatters:  false, "  test  " ));
        IsFalse("  test  ".Is(              true, caseMatters:  false, "\ttest\t" ));
        IsTrue ("  test  ".Is(              true, caseMatters:  false, "  TEST  " ));
        IsFalse("  test  ".Is(              true, caseMatters:  false, "\tTEST\t" ));
      //IsTrue ("  test  ".Is(              true,               false, "  test  " )); // Not a swap
      //IsFalse("  test  ".Is(              true,               false, "\ttest\t" ));
      //IsTrue ("  test  ".Is(              true,               false, "  TEST  " ));
      //IsFalse("  test  ".Is(              true,               false, "\tTEST\t" ));
      //IsTrue ("  test  ".Is(              true,               false, "  test  " ));
      //IsFalse("  test  ".Is(              true,                    , "\ttest\t" ));
      //IsTrue ("  test  ".Is(              true,                    , "  TEST  " ));
      //IsFalse("  test  ".Is(              true,                    , "\tTEST\t" ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesYes_ExtensionsFlagsInFront()
    {
        IsTrue ("  test  ".Is(caseMatters,         spaceMatters      , "  test  " ));
        IsFalse("  test  ".Is(caseMatters,         spaceMatters      , "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters,         spaceMatters      , "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters,         spaceMatters      , "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters,         spaceMatters: true, "  test  " ));
        IsFalse("  test  ".Is(caseMatters,         spaceMatters: true, "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters,         spaceMatters: true, "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters,         spaceMatters: true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters,                       true, "  test  " ));
        IsFalse("  test  ".Is(caseMatters,                       true, "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters,                       true, "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters,                       true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters: true,   spaceMatters      , "  test  " ));
        IsFalse("  test  ".Is(caseMatters: true,   spaceMatters      , "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters: true,   spaceMatters      , "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters: true,   spaceMatters      , "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters: true,   spaceMatters: true, "  test  " ));
        IsFalse("  test  ".Is(caseMatters: true,   spaceMatters: true, "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters: true,   spaceMatters: true, "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters: true,   spaceMatters: true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(caseMatters: true,                 true, "  test  " ));
        IsFalse("  test  ".Is(caseMatters: true,                 true, "\ttest\t" ));
        IsFalse("  test  ".Is(caseMatters: true,                 true, "  TEST  " ));
        IsFalse("  test  ".Is(caseMatters: true,                 true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(             true,   spaceMatters      , "  test  " ));
        IsFalse("  test  ".Is(             true,   spaceMatters      , "\ttest\t" ));
        IsFalse("  test  ".Is(             true,   spaceMatters      , "  TEST  " ));
        IsFalse("  test  ".Is(             true,   spaceMatters      , "\tTEST\t" ));
        IsTrue ("  test  ".Is(             true,   spaceMatters: true, "  test  " ));
        IsFalse("  test  ".Is(             true,   spaceMatters: true, "\ttest\t" ));
        IsFalse("  test  ".Is(             true,   spaceMatters: true, "  TEST  " ));
        IsFalse("  test  ".Is(             true,   spaceMatters: true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(             true,                 true, "  test  " ));
        IsFalse("  test  ".Is(             true,                 true, "\ttest\t" ));
        IsFalse("  test  ".Is(             true,                 true, "  TEST  " ));
        IsFalse("  test  ".Is(             true,                 true, "\tTEST\t" ));
    }                                                   

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesYes_ExtensionsFlagsInFrontSwapped()
    {
        IsTrue ("  test  ".Is(spaceMatters,         caseMatters      , "  test  " )); 
        IsFalse("  test  ".Is(spaceMatters,         caseMatters      , "\ttest\t" ));
        IsFalse("  test  ".Is(spaceMatters,         caseMatters      , "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters,         caseMatters      , "\tTEST\t" ));
        IsTrue ("  test  ".Is(spaceMatters,         caseMatters: true, "  test  " ));
        IsFalse("  test  ".Is(spaceMatters,         caseMatters: true, "\ttest\t" ));
        IsFalse("  test  ".Is(spaceMatters,         caseMatters: true, "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters,         caseMatters: true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(spaceMatters,                      true, "  test  " ));
        IsFalse("  test  ".Is(spaceMatters,                      true, "\ttest\t" ));
        IsFalse("  test  ".Is(spaceMatters,                      true, "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters,                      true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(spaceMatters: true,   caseMatters      , "  test  " ));
        IsFalse("  test  ".Is(spaceMatters: true,   caseMatters      , "\ttest\t" ));
        IsFalse("  test  ".Is(spaceMatters: true,   caseMatters      , "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters: true,   caseMatters      , "\tTEST\t" ));
      //IsTrue ("  test  ".Is(spaceMatters: true,   caseMatters: true, "  test  " )); // TODO: Does not work
      //IsFalse("  test  ".Is(spaceMatters: true,   caseMatters: true, "\ttest\t" ));
      //IsFalse("  test  ".Is(spaceMatters: true,   caseMatters: true, "  TEST  " ));
      //IsFalse("  test  ".Is(spaceMatters: true,   caseMatters: true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(spaceMatters: true,                true, "  test  " ));
        IsFalse("  test  ".Is(spaceMatters: true,                true, "\ttest\t" ));
        IsFalse("  test  ".Is(spaceMatters: true,                true, "  TEST  " ));
        IsFalse("  test  ".Is(spaceMatters: true,                true, "\tTEST\t" ));
        IsTrue ("  test  ".Is(              true,   caseMatters      , "  test  " ));
        IsFalse("  test  ".Is(              true,   caseMatters      , "\ttest\t" ));
        IsFalse("  test  ".Is(              true,   caseMatters      , "  TEST  " ));
        IsFalse("  test  ".Is(              true,   caseMatters      , "\tTEST\t" ));
        IsTrue ("  test  ".Is(              true,   caseMatters: true, "  test  " ));
        IsFalse("  test  ".Is(              true,   caseMatters: true, "\ttest\t" ));
        IsFalse("  test  ".Is(              true,   caseMatters: true, "  TEST  " ));
        IsFalse("  test  ".Is(              true,   caseMatters: true, "\tTEST\t" ));
      //IsTrue ("  test  ".Is(              true,                true, "  test  " )); // Not a swap
      //IsFalse("  test  ".Is(              true,                true, "\ttest\t" ));
      //IsFalse("  test  ".Is(              true,                true, "  TEST  " ));
      //IsFalse("  test  ".Is(              true,                true, "\tTEST\t" ));
    }

}