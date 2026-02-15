namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_StaticCaseOrSpaceMattersYesNo : TestBase
{
    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesNo_StaticFlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters                             ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters                             ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters                             ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters                             ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,                       false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters,                       false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,                       false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,                       false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true                      ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters:  true                      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true                      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true                      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true,                false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters:  true,                false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true,                false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true,                false));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true                      ));
        IsTrue (In("B \t", [ "A", "B", "C" ],               true                      ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true                      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true                      ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,                false));
        IsTrue (In("B \t", [ "A", "B", "C" ],               true,                false));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,                false));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,                false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesNo_StaticFlagsInBackSwapped()
    {
      //IsTrue (In("B"   , [ "A", "B", "C" ],                      caseMatters        )); // Not a swap
      //IsTrue (In("B \t", [ "A", "B", "C" ],                      caseMatters        ));
      //IsFalse(In("b"   , [ "A", "B", "C" ],                      caseMatters        ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],                      caseMatters        ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters        ));
        IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters        ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               false, caseMatters        ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               false, caseMatters        ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                      caseMatters:  true )); // Not a swap
      //IsTrue (In("B \t", [ "A", "B", "C" ],                      caseMatters:  true ));
      //IsFalse(In("b"   , [ "A", "B", "C" ],                      caseMatters:  true ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],                      caseMatters:  true ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters:  true ));
        IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters:  true ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               false, caseMatters:  true ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               false, caseMatters:  true ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                    true )); // Assigns wrong parameter
      //IsTrue (In("B \t", [ "A", "B", "C" ],                                    true ));
      //IsFalse(In("b"   , [ "A", "B", "C" ],                                    true ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],                                    true ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false,               true ));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false,               true ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false,               true ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false,               true ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               false,               true )); // Assigns wrong parameter
      //IsTrue (In("B \t", [ "A", "B", "C" ],               false,               true ));
      //IsFalse(In("b"   , [ "A", "B", "C" ],               false,               true ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               false,               true ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_StaticCollectionFlagsInFront()
    {
        IsTrue (In("B"   , caseMatters,                              [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,                              [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                              [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                              [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,                       false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,                       false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                       false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                       false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,                       [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters:  true,                       [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,                       [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,                       [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,                       [ "A", "B", "C" ]));
        IsTrue (In("B \t",               true,                       [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,                       [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,                       [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",               true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",               true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,                false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_StaticCollectionFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   ,                      caseMatters,         [ "A", "B", "C" ])); // Not a swap
      //IsTrue (In("B \t",                      caseMatters,         [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,                      caseMatters,         [ "A", "B", "C" ]));
      //IsFalse(In("b \t",                      caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B \t", spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B \t",               false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t",               false, caseMatters,         [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,                      caseMatters:  true,  [ "A", "B", "C" ])); // Not a swap
      //IsTrue (In("B \t",                      caseMatters:  true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,                      caseMatters:  true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t",                      caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue (In("B \t", spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue (In("B \t",               false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",               false, caseMatters:  true,  [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,                                    true,  [ "A", "B", "C" ])); // Not a swap
      //IsTrue (In("B \t",                                    true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,                                    true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t",                                    true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: false,               true,  [ "A", "B", "C" ]));
        IsTrue (In("B \t", spaceMatters: false,               true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: false,               true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: false,               true,  [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               false,               true,  [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsTrue (In("B \t",               false,               true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,               false,               true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               false,               true,  [ "A", "B", "C" ]));
    }                                                         

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_StaticParamsFlagsInFront()
    {
        IsTrue (In("B"   , caseMatters,                                "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,                                "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                                "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                                "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,                       false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,                       false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                       false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                       false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,                         "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters:  true,                         "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,                         "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,                         "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,                false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters:  true,                false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,                false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,                false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,                         "A", "B", "C"  ));
        IsTrue (In("B \t",               true,                         "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,                         "A", "B", "C"  ));
        IsFalse(In("b \t",               true,                         "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t",               true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t",               true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,                false,   "A", "B", "C"  ));
        IsTrue (In("B \t",               true,                false,   "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,                false,   "A", "B", "C"  ));
        IsFalse(In("b \t",               true,                false,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_StaticParamsFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   ,                      caseMatters,           "A", "B", "C"  )); // Not a swap
      //IsTrue (In("B \t",                      caseMatters,           "A", "B", "C"  ));
      //IsFalse(In("b"   ,                      caseMatters,           "A", "B", "C"  ));
      //IsFalse(In("b \t",                      caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters: false, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B \t", spaceMatters: false, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters: false, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters: false, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   ,               false, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B \t",               false, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   ,               false, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t",               false, caseMatters,           "A", "B", "C"  ));
      //IsTrue (In("B"   ,                      caseMatters:  true,    "A", "B", "C"  )); // Not a swap
      //IsTrue (In("B \t",                      caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b"   ,                      caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",                      caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false, caseMatters:  true,    "A", "B", "C"  )); // TODO: Does not work
      //IsTrue (In("B \t", spaceMatters: false, caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: false, caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: false, caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,               false, caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue (In("B \t",               false, caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b"   ,               false, caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",               false, caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,                                    true,    "A", "B", "C"  )); // Not a swap
      //IsTrue (In("B \t",                                    true,    "A", "B", "C"  ));
      //IsFalse(In("b"   ,                                    true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",                                    true,    "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false,               true,    "A", "B", "C"  )); // TODO: Does not work
      //IsTrue (In("B \t", spaceMatters: false,               true,    "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: false,               true,    "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: false,               true,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,               false,               true,    "A", "B", "C"  )); // Assigns wrong parameter
      //IsTrue (In("B \t",               false,               true,    "A", "B", "C"  ));
      //IsFalse(In("b"   ,               false,               true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",               false,               true,    "A", "B", "C"  ));
    }
}