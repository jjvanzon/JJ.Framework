namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_StaticCaseOrSpaceMattersNoYes : TestBase
{
    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticFlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ],                      spaceMatters       ));
        IsFalse(In("B \t", [ "A", "B", "C" ],                      spaceMatters       ));
        IsTrue (In("b"   , [ "A", "B", "C" ],                      spaceMatters       ));
        IsFalse(In("b \t", [ "A", "B", "C" ],                      spaceMatters       ));
        IsTrue (In("B"   , [ "A", "B", "C" ],                      spaceMatters: true ));
        IsFalse(In("B \t", [ "A", "B", "C" ],                      spaceMatters: true ));
        IsTrue (In("b"   , [ "A", "B", "C" ],                      spaceMatters: true ));
        IsFalse(In("b \t", [ "A", "B", "C" ],                      spaceMatters: true ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                    true )); // Assigns wrong parameter
      //IsFalse(In("B \t", [ "A", "B", "C" ],                                    true ));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                                    true ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],                                    true ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  false, spaceMatters       ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters:  false, spaceMatters       ));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters:  false, spaceMatters       ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  false, spaceMatters       ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  false, spaceMatters: true ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters:  false, spaceMatters: true ));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters:  false, spaceMatters: true ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  false, spaceMatters: true ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  false,               true ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters:  false,               true ));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters:  false,               true ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  false,               true ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false, spaceMatters       ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               false, spaceMatters       ));
        IsTrue (In("b"   , [ "A", "B", "C" ],               false, spaceMatters       ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               false, spaceMatters       ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false, spaceMatters: true ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               false, spaceMatters: true ));
        IsTrue (In("b"   , [ "A", "B", "C" ],               false, spaceMatters: true ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               false, spaceMatters: true ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false,               true ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               false,               true ));
        IsTrue (In("b"   , [ "A", "B", "C" ],               false,               true ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               false,               true ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticFlagsInBackSwapped()
    {
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters                            )); // Not a swap
      //IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters                            ));
      //IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters                            ));
      //IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters                            ));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true                      ));
      //IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true                      ));
      //IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: true                      ));
      //IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true                      ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               true                      ));
      //IsFalse(In("B \t", [ "A", "B", "C" ],               true                      ));
      //IsTrue (In("b"   , [ "A", "B", "C" ],               true                      ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               true                      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,        caseMatters:  false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,        caseMatters:  false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters,        caseMatters:  false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,        caseMatters:  false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  false));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,  caseMatters:  false));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true,  caseMatters:  false));
        IsTrue (In("b"   , [ "A", "B", "C" ],               true,  caseMatters:  false));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,  caseMatters:  false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,                      false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,                      false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters,                      false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,                      false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,                false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,                false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: true,                false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,                false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               true,                false)); // Assigns wrong parameter
      //IsFalse(In("B \t", [ "A", "B", "C" ],               true,                false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],               true,                false));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               true,                false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticCollectionsFlagsInFront()
    {
        IsTrue (In("B"   ,                      spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t",                      spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                      spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t",                      spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                      spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t",                      spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                      spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",                      spaceMatters: true,  [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,                                    true,  [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsFalse(In("B \t",                                    true,  [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,                                    true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t",                                    true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters:  false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters:  false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  false, spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters:  false, spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters:  false, spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  false, spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  false,               true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters:  false,               true,  [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters:  false,               true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  false,               true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false, spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t",               false, spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("b"   ,               false, spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t",               false, spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t",               false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("b"   ,               false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",               false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false,               true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t",               false,               true,  [ "A", "B", "C" ]));
        IsTrue (In("b"   ,               false,               true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",               false,               true,  [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticCollectionsFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   , spaceMatters,                             [ "A", "B", "C" ])); // Not a swap
      //IsFalse(In("B \t", spaceMatters,                             [ "A", "B", "C" ]));
      //IsTrue (In("b"   , spaceMatters,                             [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters,                             [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: true,                       [ "A", "B", "C" ]));
      //IsFalse(In("B \t", spaceMatters: true,                       [ "A", "B", "C" ]));
      //IsTrue (In("b"   , spaceMatters: true,                       [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: true,                       [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               true,                       [ "A", "B", "C" ]));
      //IsFalse(In("B \t",               true,                       [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,               true,                       [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               true,                       [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters: true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters: true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,        caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,        caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters,        caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,        caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,               true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,                      false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,                      false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters,                      false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,                      false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: true,                false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters: true,                false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters: true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true,                false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               true,                false, [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsFalse(In("B \t",               true,                false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,               true,                false, [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               true,                false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticParamsFlagsInFront()
    {
        IsTrue (In("B"   ,                      spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t",                      spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("b"   ,                      spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t",                      spaceMatters,          "A", "B", "C"  ));
      //IsTrue (In("B"   ,                      spaceMatters: true,    "A", "B", "C"  )); // TODO: Does not work
      //IsFalse(In("B \t",                      spaceMatters: true,    "A", "B", "C"  ));
      //IsTrue (In("b"   ,                      spaceMatters: true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",                      spaceMatters: true,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,                                    true,    "A", "B", "C"  )); // Assigns wrong parameter
      //IsFalse(In("B \t",                                    true,    "A", "B", "C"  ));
      //IsTrue (In("b"   ,                                    true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",                                    true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  false, spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters:  false, spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters:  false, spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  false, spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  false, spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters:  false, spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters:  false, spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  false, spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  false,               true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters:  false,               true,    "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters:  false,               true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  false,               true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,               false, spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t",               false, spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("b"   ,               false, spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t",               false, spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   ,               false, spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t",               false, spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("b"   ,               false, spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t",               false, spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,               false,               true,    "A", "B", "C"  ));
        IsFalse(In("B \t",               false,               true,    "A", "B", "C"  ));
        IsTrue (In("b"   ,               false,               true,    "A", "B", "C"  ));
        IsFalse(In("b \t",               false,               true,    "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticParamsFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   , spaceMatters,                               "A", "B", "C"  )); // Not a swap
      //IsFalse(In("B \t", spaceMatters,                               "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters,                               "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters,                               "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,                         "A", "B", "C"  )); 
      //IsFalse(In("B \t", spaceMatters: true,                         "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: true,                         "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,                         "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true,                         "A", "B", "C"  )); 
      //IsFalse(In("B \t",               true,                         "A", "B", "C"  ));
      //IsTrue (In("b"   ,               true,                         "A", "B", "C"  ));
      //IsFalse(In("b \t",               true,                         "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,        caseMatters:  false,   "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,        caseMatters:  false,   "A", "B", "C"  ));
        IsTrue (In("b"   , spaceMatters,        caseMatters:  false,   "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,        caseMatters:  false,   "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,  caseMatters:  false,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse(In("B \t", spaceMatters: true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsFalse(In("B \t",               true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,               true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsFalse(In("b \t",               true,  caseMatters:  false,   "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,                      false,   "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,                      false,   "A", "B", "C"  ));
        IsTrue (In("b"   , spaceMatters,                      false,   "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,                      false,   "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,                false,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse(In("B \t", spaceMatters: true,                false,   "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: true,                false,   "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,                false,   "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true,                false,   "A", "B", "C"  )); // Sets wrong parameter
      //IsFalse(In("B \t",               true,                false,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,               true,                false,   "A", "B", "C"  ));
      //IsFalse(In("b \t",               true,                false,   "A", "B", "C"  ));
    }
}