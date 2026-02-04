
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Is_Tests_StaticFlagsInFront
{
    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoNo_StaticFlagsInFront()
    {
        IsTrue (Is(                                          "  test  ", "  test  "));
        IsTrue (Is(                                          "  test  ", "\ttest\t"));
        IsTrue (Is(                                          "  test  ", "  TEST  "));
        IsTrue (Is(                                          "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  false,                      "  test  ", "  test  "));
        IsTrue (Is(caseMatters:  false,                      "  test  ", "\ttest\t"));
        IsTrue (Is(caseMatters:  false,                      "  test  ", "  TEST  "));
        IsTrue (Is(caseMatters:  false,                      "  test  ", "\tTEST\t"));
        IsTrue (Is(              false,                      "  test  ", "  test  "));
        IsTrue (Is(              false,                      "  test  ", "\ttest\t"));
        IsTrue (Is(              false,                      "  test  ", "  TEST  "));
        IsTrue (Is(              false,                      "  test  ", "\tTEST\t"));
        IsTrue (Is(                     spaceMatters: false, "  test  ", "  test  "));
        IsTrue (Is(                     spaceMatters: false, "  test  ", "\ttest\t"));
        IsTrue (Is(                     spaceMatters: false, "  test  ", "  TEST  "));
        IsTrue (Is(                     spaceMatters: false, "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  false, spaceMatters: false, "  test  ", "  test  "));
        IsTrue (Is(caseMatters:  false, spaceMatters: false, "  test  ", "\ttest\t"));
        IsTrue (Is(caseMatters:  false, spaceMatters: false, "  test  ", "  TEST  "));
        IsTrue (Is(caseMatters:  false, spaceMatters: false, "  test  ", "\tTEST\t"));
        IsTrue (Is(              false, spaceMatters: false, "  test  ", "  test  "));
        IsTrue (Is(              false, spaceMatters: false, "  test  ", "\ttest\t"));
        IsTrue (Is(              false, spaceMatters: false, "  test  ", "  TEST  "));
        IsTrue (Is(              false, spaceMatters: false, "  test  ", "\tTEST\t"));
      //IsTrue (Is(                                   false, "  test  ", "  test  ")); // Sets wrong parameter
      //IsTrue (Is(                                   false, "  test  ", "\ttest\t"));
      //IsTrue (Is(                                   false, "  test  ", "  TEST  "));
      //IsTrue (Is(                                   false, "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  false,               false, "  test  ", "  test  "));
        IsTrue (Is(caseMatters:  false,               false, "  test  ", "\ttest\t"));
        IsTrue (Is(caseMatters:  false,               false, "  test  ", "  TEST  "));
        IsTrue (Is(caseMatters:  false,               false, "  test  ", "\tTEST\t"));
        IsTrue (Is(              false,               false, "  test  ", "  test  "));
        IsTrue (Is(              false,               false, "  test  ", "\ttest\t"));
        IsTrue (Is(              false,               false, "  test  ", "  TEST  "));
        IsTrue (Is(              false,               false, "  test  ", "\tTEST\t"));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoNo_StaticFlagsInFrontSwapped()
    {
      //IsTrue (Is(                                          "  test  ", "  test  ")); // Not a swap
      //IsTrue (Is(                                          "  test  ", "\ttest\t"));
      //IsTrue (Is(                                          "  test  ", "  TEST  "));
      //IsTrue (Is(                                          "  test  ", "\tTEST\t"));
      //IsTrue (Is(                     caseMatters:  false, "  test  ", "  test  "));
      //IsTrue (Is(                     caseMatters:  false, "  test  ", "\ttest\t"));
      //IsTrue (Is(                     caseMatters:  false, "  test  ", "  TEST  "));
      //IsTrue (Is(                     caseMatters:  false, "  test  ", "\tTEST\t"));
      //IsTrue (Is(                                   false, "  test  ", "  test  "));
      //IsTrue (Is(                                   false, "  test  ", "\ttest\t"));
      //IsTrue (Is(                                   false, "  test  ", "  TEST  "));
      //IsTrue (Is(                                   false, "  test  ", "\tTEST\t"));
        IsTrue (Is(spaceMatters: false,                      "  test  ", "  test  "));
        IsTrue (Is(spaceMatters: false,                      "  test  ", "\ttest\t"));
        IsTrue (Is(spaceMatters: false,                      "  test  ", "  TEST  "));
        IsTrue (Is(spaceMatters: false,                      "  test  ", "\tTEST\t"));
      //IsTrue (Is(spaceMatters: false, caseMatters:  false, "  test  ", "  test  ")); // TODO: Does not work
      //IsTrue (Is(spaceMatters: false, caseMatters:  false, "  test  ", "\ttest\t"));
      //IsTrue (Is(spaceMatters: false, caseMatters:  false, "  test  ", "  TEST  "));
      //IsTrue (Is(spaceMatters: false, caseMatters:  false, "  test  ", "\tTEST\t"));
      //IsTrue (Is(spaceMatters: false,               false, "  test  ", "  test  "));
      //IsTrue (Is(spaceMatters: false,               false, "  test  ", "\ttest\t"));
      //IsTrue (Is(spaceMatters: false,               false, "  test  ", "  TEST  "));
      //IsTrue (Is(spaceMatters: false,               false, "  test  ", "\tTEST\t"));
      //IsTrue (Is(              false,                      "  test  ", "  test  ")); // Sets other parameter
      //IsTrue (Is(              false,                      "  test  ", "\ttest\t"));
      //IsTrue (Is(              false,                      "  test  ", "  TEST  "));
      //IsTrue (Is(              false,                      "  test  ", "\tTEST\t"));
      //IsTrue (Is(              false, caseMatters:  false, "  test  ", "  test  ")); // TODO: Does not work
      //IsTrue (Is(              false, caseMatters:  false, "  test  ", "\ttest\t"));
      //IsTrue (Is(              false, caseMatters:  false, "  test  ", "  TEST  "));
      //IsTrue (Is(              false, caseMatters:  false, "  test  ", "\tTEST\t"));
      //IsTrue (Is(              false,               false, "  test  ", "  test  ")); // Not a swap
      //IsTrue (Is(              false,               false, "  test  ", "\ttest\t"));
      //IsTrue (Is(              false,               false, "  test  ", "  TEST  "));
      //IsTrue (Is(              false,               false, "  test  ", "\tTEST\t"));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoYes_StaticFlagsInFront()
    {
        IsTrue (Is(                     spaceMatters,       "  test  ", "  test  " ));
        IsFalse(Is(                     spaceMatters,       "  test  ", "\ttest\t" ));
        IsTrue (Is(                     spaceMatters,       "  test  ", "  TEST  " ));
        IsFalse(Is(                     spaceMatters,       "  test  ", "\tTEST\t" ));
        IsTrue (Is(caseMatters:  false, spaceMatters,       "  test  ", "  test  " ));
        IsFalse(Is(caseMatters:  false, spaceMatters,       "  test  ", "\ttest\t" ));
        IsTrue (Is(caseMatters:  false, spaceMatters,       "  test  ", "  TEST  " ));
        IsFalse(Is(caseMatters:  false, spaceMatters,       "  test  ", "\tTEST\t" ));
        IsTrue (Is(              false, spaceMatters,       "  test  ", "  test  " ));
        IsFalse(Is(              false, spaceMatters,       "  test  ", "\ttest\t" ));
        IsTrue (Is(              false, spaceMatters,       "  test  ", "  TEST  " ));
        IsFalse(Is(              false, spaceMatters,       "  test  ", "\tTEST\t" ));
        IsTrue (Is(                     spaceMatters: true, "  test  ", "  test  " ));
        IsFalse(Is(                     spaceMatters: true, "  test  ", "\ttest\t" ));
        IsTrue (Is(                     spaceMatters: true, "  test  ", "  TEST  " ));
        IsFalse(Is(                     spaceMatters: true, "  test  ", "\tTEST\t" ));
        IsTrue (Is(caseMatters:  false, spaceMatters: true, "  test  ", "  test  " ));
        IsFalse(Is(caseMatters:  false, spaceMatters: true, "  test  ", "\ttest\t" ));
        IsTrue (Is(caseMatters:  false, spaceMatters: true, "  test  ", "  TEST  " ));
        IsFalse(Is(caseMatters:  false, spaceMatters: true, "  test  ", "\tTEST\t" ));
        IsTrue (Is(              false, spaceMatters: true, "  test  ", "  test  " ));
        IsFalse(Is(              false, spaceMatters: true, "  test  ", "\ttest\t" ));
        IsTrue (Is(              false, spaceMatters: true, "  test  ", "  TEST  " ));
        IsFalse(Is(              false, spaceMatters: true, "  test  ", "\tTEST\t" ));
      //IsTrue (Is(                                   true, "  test  ", "  test  " )); // Sets other parmeter
      //IsFalse(Is(                                   true, "  test  ", "\ttest\t" ));
      //IsTrue (Is(                                   true, "  test  ", "  TEST  " ));
      //IsFalse(Is(                                   true, "  test  ", "\tTEST\t" ));
        IsTrue (Is(caseMatters:  false,               true, "  test  ", "  test  " ));
        IsFalse(Is(caseMatters:  false,               true, "  test  ", "\ttest\t" ));
        IsTrue (Is(caseMatters:  false,               true, "  test  ", "  TEST  " ));
        IsFalse(Is(caseMatters:  false,               true, "  test  ", "\tTEST\t" ));
        IsTrue (Is(              false,               true, "  test  ", "  test  " ));
        IsFalse(Is(              false,               true, "  test  ", "\ttest\t" ));
        IsTrue (Is(              false,               true, "  test  ", "  TEST  " ));
        IsFalse(Is(              false,               true, "  test  ", "\tTEST\t" ));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersNoYes_StaticFlagsInFrontSwapped()
    {
        IsTrue (Is(spaceMatters,                             "  test  ", "  test  "));
        IsFalse(Is(spaceMatters,                             "  test  ", "\ttest\t"));
        IsTrue (Is(spaceMatters,                             "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters,                             "  test  ", "\tTEST\t"));
        IsTrue (Is(spaceMatters,        caseMatters:  false, "  test  ", "  test  "));
        IsFalse(Is(spaceMatters,        caseMatters:  false, "  test  ", "\ttest\t"));
        IsTrue (Is(spaceMatters,        caseMatters:  false, "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters,        caseMatters:  false, "  test  ", "\tTEST\t"));
        IsTrue (Is(spaceMatters,                      false, "  test  ", "  test  "));
        IsFalse(Is(spaceMatters,                      false, "  test  ", "\ttest\t"));
        IsTrue (Is(spaceMatters,                      false, "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters,                      false, "  test  ", "\tTEST\t"));
        IsTrue (Is(spaceMatters: true,                       "  test  ", "  test  "));
        IsFalse(Is(spaceMatters: true,                       "  test  ", "\ttest\t"));
        IsTrue (Is(spaceMatters: true,                       "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters: true,                       "  test  ", "\tTEST\t"));
      //IsTrue (Is(spaceMatters: true,  caseMatters:  false, "  test  ", "  test  ")); // TODO: Does not work
      //IsFalse(Is(spaceMatters: true,  caseMatters:  false, "  test  ", "\ttest\t"));
      //IsTrue (Is(spaceMatters: true,  caseMatters:  false, "  test  ", "  TEST  "));
      //IsFalse(Is(spaceMatters: true,  caseMatters:  false, "  test  ", "\tTEST\t"));
      //IsTrue (Is(spaceMatters: true,                false, "  test  ", "  test  "));
      //IsFalse(Is(spaceMatters: true,                false, "  test  ", "\ttest\t"));
      //IsTrue (Is(spaceMatters: true,                false, "  test  ", "  TEST  "));
      //IsFalse(Is(spaceMatters: true,                false, "  test  ", "\tTEST\t"));
      //IsTrue (Is(              true,                       "  test  ", "  test  ")); // Sets other parameter
      //IsFalse(Is(              true,                       "  test  ", "\ttest\t"));
      //IsTrue (Is(              true,                       "  test  ", "  TEST  "));
      //IsFalse(Is(              true,                       "  test  ", "\tTEST\t"));
      //IsTrue (Is(              true,  caseMatters:  false, "  test  ", "  test  ")); // TODO: Does not work
      //IsFalse(Is(              true,  caseMatters:  false, "  test  ", "\ttest\t"));
      //IsTrue (Is(              true,  caseMatters:  false, "  test  ", "  TEST  "));
      //IsFalse(Is(              true,  caseMatters:  false, "  test  ", "\tTEST\t"));
      //IsTrue (Is(              true,                false, "  test  ", "  test  ")); // Not a swap
      //IsFalse(Is(              true,                false, "  test  ", "\ttest\t"));
      //IsTrue (Is(              true,                false, "  test  ", "  TEST  "));
      //IsFalse(Is(              true,                false, "  test  ", "\tTEST\t"));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesNo_StaticFlagsInFront()
    {
        IsTrue (Is(caseMatters,         spaceMatters: false, "  test  ", "  test  "));
        IsTrue (Is(caseMatters,         spaceMatters: false, "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters,         spaceMatters: false, "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters,         spaceMatters: false, "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  true,  spaceMatters: false, "  test  ", "  test  "));
        IsTrue (Is(caseMatters:  true,  spaceMatters: false, "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters:  true,  spaceMatters: false, "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters:  true,  spaceMatters: false, "  test  ", "\tTEST\t"));
        IsTrue (Is(              true,  spaceMatters: false, "  test  ", "  test  "));
        IsTrue (Is(              true,  spaceMatters: false, "  test  ", "\ttest\t"));
        IsFalse(Is(              true,  spaceMatters: false, "  test  ", "  TEST  "));
        IsFalse(Is(              true,  spaceMatters: false, "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters,                       false, "  test  ", "  test  "));
        IsTrue (Is(caseMatters,                       false, "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters,                       false, "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters,                       false, "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  true,                false, "  test  ", "  test  "));
        IsTrue (Is(caseMatters:  true,                false, "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters:  true,                false, "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters:  true,                false, "  test  ", "\tTEST\t"));
        IsTrue (Is(              true,                false, "  test  ", "  test  "));
        IsTrue (Is(              true,                false, "  test  ", "\ttest\t"));
        IsFalse(Is(              true,                false, "  test  ", "  TEST  "));
        IsFalse(Is(              true,                false, "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters,                              "  test  ", "  test  "));
        IsTrue (Is(caseMatters,                              "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters,                              "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters,                              "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  true,                       "  test  ", "  test  "));
        IsTrue (Is(caseMatters:  true,                       "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters:  true,                       "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters:  true,                       "  test  ", "\tTEST\t"));
        IsTrue (Is(              true,                       "  test  ", "  test  "));
        IsTrue (Is(              true,                       "  test  ", "\ttest\t"));
        IsFalse(Is(              true,                       "  test  ", "  TEST  "));
        IsFalse(Is(              true,                       "  test  ", "\tTEST\t"));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesNo_StaticFlagsInFrontSwapped()
    {
        IsTrue (Is(spaceMatters: false, caseMatters,         "  test  ", "  test  "));
        IsTrue (Is(spaceMatters: false, caseMatters,         "  test  ", "\ttest\t"));
        IsFalse(Is(spaceMatters: false, caseMatters,         "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters: false, caseMatters,         "  test  ", "\tTEST\t"));
      //IsTrue (Is(spaceMatters: false, caseMatters:  true,  "  test  ", "  test  ")); // TODO: Does not work
      //IsTrue (Is(spaceMatters: false, caseMatters:  true,  "  test  ", "\ttest\t"));
      //IsFalse(Is(spaceMatters: false, caseMatters:  true,  "  test  ", "  TEST  "));
      //IsFalse(Is(spaceMatters: false, caseMatters:  true,  "  test  ", "\tTEST\t"));
      //IsTrue (Is(spaceMatters: false,               true,  "  test  ", "  test  "));
      //IsTrue (Is(spaceMatters: false,               true,  "  test  ", "\ttest\t"));
      //IsFalse(Is(spaceMatters: false,               true,  "  test  ", "  TEST  "));
      //IsFalse(Is(spaceMatters: false,               true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(              false, caseMatters,         "  test  ", "  test  "));
        IsTrue (Is(              false, caseMatters,         "  test  ", "\ttest\t"));
        IsFalse(Is(              false, caseMatters,         "  test  ", "  TEST  "));
        IsFalse(Is(              false, caseMatters,         "  test  ", "\tTEST\t"));
      //IsTrue (Is(              false, caseMatters:  true,  "  test  ", "  test  ")); // TODO: Does not work
      //IsTrue (Is(              false, caseMatters:  true,  "  test  ", "\ttest\t"));
      //IsFalse(Is(              false, caseMatters:  true,  "  test  ", "  TEST  "));
      //IsFalse(Is(              false, caseMatters:  true,  "  test  ", "\tTEST\t"));
      //IsTrue (Is(              false,               true,  "  test  ", "  test  ")); // Not a swap
      //IsTrue (Is(              false,               true,  "  test  ", "\ttest\t"));
      //IsFalse(Is(              false,               true,  "  test  ", "  TEST  "));
      //IsFalse(Is(              false,               true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(                     caseMatters,         "  test  ", "  test  "));
        IsTrue (Is(                     caseMatters,         "  test  ", "\ttest\t"));
        IsFalse(Is(                     caseMatters,         "  test  ", "  TEST  "));
        IsFalse(Is(                     caseMatters,         "  test  ", "\tTEST\t"));
        IsTrue (Is(                     caseMatters:  true,  "  test  ", "  test  "));
        IsTrue (Is(                     caseMatters:  true,  "  test  ", "\ttest\t"));
        IsFalse(Is(                     caseMatters:  true,  "  test  ", "  TEST  "));
        IsFalse(Is(                     caseMatters:  true,  "  test  ", "\tTEST\t"));
      //IsTrue (Is(                                   true,  "  test  ", "  test  ")); // Not a swap
      //IsTrue (Is(                                   true,  "  test  ", "\ttest\t")); 
      //IsFalse(Is(                                   true,  "  test  ", "  TEST  ")); 
      //IsFalse(Is(                                   true,  "  test  ", "\tTEST\t")); 
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesYes_StaticFlagsInFront()
    {
        IsTrue (Is(caseMatters,         spaceMatters,        "  test  ", "  test  "));
        IsFalse(Is(caseMatters,         spaceMatters,        "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters,         spaceMatters,        "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters,         spaceMatters,        "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  true,  spaceMatters,        "  test  ", "  test  "));
        IsFalse(Is(caseMatters:  true,  spaceMatters,        "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters:  true,  spaceMatters,        "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters:  true,  spaceMatters,        "  test  ", "\tTEST\t"));
        IsTrue (Is(              true,  spaceMatters,        "  test  ", "  test  "));
        IsFalse(Is(              true,  spaceMatters,        "  test  ", "\ttest\t"));
        IsFalse(Is(              true,  spaceMatters,        "  test  ", "  TEST  "));
        IsFalse(Is(              true,  spaceMatters,        "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters,         spaceMatters: true,  "  test  ", "  test  "));
        IsFalse(Is(caseMatters,         spaceMatters: true,  "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters,         spaceMatters: true,  "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters,         spaceMatters: true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  true,  spaceMatters: true,  "  test  ", "  test  "));
        IsFalse(Is(caseMatters:  true,  spaceMatters: true,  "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters:  true,  spaceMatters: true,  "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters:  true,  spaceMatters: true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(              true,  spaceMatters: true,  "  test  ", "  test  "));
        IsFalse(Is(              true,  spaceMatters: true,  "  test  ", "\ttest\t"));
        IsFalse(Is(              true,  spaceMatters: true,  "  test  ", "  TEST  "));
        IsFalse(Is(              true,  spaceMatters: true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters,                       true,  "  test  ", "  test  "));
        IsFalse(Is(caseMatters,                       true,  "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters,                       true,  "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters,                       true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(caseMatters:  true,                true,  "  test  ", "  test  "));
        IsFalse(Is(caseMatters:  true,                true,  "  test  ", "\ttest\t"));
        IsFalse(Is(caseMatters:  true,                true,  "  test  ", "  TEST  "));
        IsFalse(Is(caseMatters:  true,                true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(              true,                true,  "  test  ", "  test  "));
        IsFalse(Is(              true,                true,  "  test  ", "\ttest\t"));
        IsFalse(Is(              true,                true,  "  test  ", "  TEST  "));
        IsFalse(Is(              true,                true,  "  test  ", "\tTEST\t"));
    }

    [TestMethod]
    public void Test_String_Is_CaseOrSpaceMattersYesYes_StaticFlagsInFrontFlagsSwapped()
    {
        IsTrue (Is(spaceMatters,        caseMatters,         "  test  ", "  test  "));
        IsFalse(Is(spaceMatters,        caseMatters,         "  test  ", "\ttest\t"));
        IsFalse(Is(spaceMatters,        caseMatters,         "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters,        caseMatters,         "  test  ", "\tTEST\t"));
        IsTrue (Is(spaceMatters,        caseMatters:  true,  "  test  ", "  test  "));
        IsFalse(Is(spaceMatters,        caseMatters:  true,  "  test  ", "\ttest\t"));
        IsFalse(Is(spaceMatters,        caseMatters:  true,  "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters,        caseMatters:  true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(spaceMatters,                      true,  "  test  ", "  test  "));
        IsFalse(Is(spaceMatters,                      true,  "  test  ", "\ttest\t"));
        IsFalse(Is(spaceMatters,                      true,  "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters,                      true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(spaceMatters: true,  caseMatters,         "  test  ", "  test  "));
        IsFalse(Is(spaceMatters: true,  caseMatters,         "  test  ", "\ttest\t"));
        IsFalse(Is(spaceMatters: true,  caseMatters,         "  test  ", "  TEST  "));
        IsFalse(Is(spaceMatters: true,  caseMatters,         "  test  ", "\tTEST\t"));
      //IsTrue (Is(spaceMatters: true,  caseMatters:  true,  "  test  ", "  test  ")); // TODO: Does not work
      //IsFalse(Is(spaceMatters: true,  caseMatters:  true,  "  test  ", "\ttest\t"));
      //IsFalse(Is(spaceMatters: true,  caseMatters:  true,  "  test  ", "  TEST  "));
      //IsFalse(Is(spaceMatters: true,  caseMatters:  true,  "  test  ", "\tTEST\t"));
      //IsTrue (Is(spaceMatters: true,                true,  "  test  ", "  test  "));
      //IsFalse(Is(spaceMatters: true,                true,  "  test  ", "\ttest\t"));
      //IsFalse(Is(spaceMatters: true,                true,  "  test  ", "  TEST  "));
      //IsFalse(Is(spaceMatters: true,                true,  "  test  ", "\tTEST\t"));
        IsTrue (Is(              true,  caseMatters,         "  test  ", "  test  "));
        IsFalse(Is(              true,  caseMatters,         "  test  ", "\ttest\t"));
        IsFalse(Is(              true,  caseMatters,         "  test  ", "  TEST  "));
        IsFalse(Is(              true,  caseMatters,         "  test  ", "\tTEST\t"));
      //IsTrue (Is(              true,  caseMatters:  true,  "  test  ", "  test  ")); // TODO: Does not work
      //IsFalse(Is(              true,  caseMatters:  true,  "  test  ", "\ttest\t"));
      //IsFalse(Is(              true,  caseMatters:  true,  "  test  ", "  TEST  "));
      //IsFalse(Is(              true,  caseMatters:  true,  "  test  ", "\tTEST\t"));
      //IsTrue (Is(              true,                true,  "  test  ", "  test  ")); // Not a swap
      //IsFalse(Is(              true,                true,  "  test  ", "\ttest\t"));
      //IsFalse(Is(              true,                true,  "  test  ", "  TEST  "));
      //IsFalse(Is(              true,                true,  "  test  ", "\tTEST\t"));
    }
}