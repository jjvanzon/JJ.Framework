namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_ExtensionsCaseOrSpaceMattersNoYes : TestBase
{
    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsFlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ],                      spaceMatters       ));
        IsFalse("B \t".In( [ "A", "B", "C" ],                      spaceMatters       ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                      spaceMatters       ));
        IsFalse("b \t".In( [ "A", "B", "C" ],                      spaceMatters       ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                      spaceMatters: true ));
        IsFalse("B \t".In( [ "A", "B", "C" ],                      spaceMatters: true ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                      spaceMatters: true ));
        IsFalse("b \t".In( [ "A", "B", "C" ],                      spaceMatters: true ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                                    true )); // Assigns wrong parameter
      //IsFalse("B \t".In( [ "A", "B", "C" ],                                    true ));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],                                    true ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],                                    true ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  false, spaceMatters       ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters:  false, spaceMatters       ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters:  false, spaceMatters       ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  false, spaceMatters       ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  false, spaceMatters: true ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters:  false, spaceMatters: true ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters:  false, spaceMatters: true ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  false, spaceMatters: true ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  false,               true ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters:  false,               true ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters:  false,               true ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  false,               true ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               false, spaceMatters       ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               false, spaceMatters       ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],               false, spaceMatters       ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               false, spaceMatters       ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               false, spaceMatters: true ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               false, spaceMatters: true ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],               false, spaceMatters: true ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               false, spaceMatters: true ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               false,               true ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               false,               true ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],               false,               true ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               false,               true ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsFlagsInBackSwapped()
    {
      //IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters                            )); // Not a swap
      //IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters                            ));
      //IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters                            ));
      //IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters                            ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true                      ));
      //IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true                      ));
      //IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: true                      ));
      //IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true                      ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               true                      ));
      //IsFalse("B \t".In( [ "A", "B", "C" ],               true                      ));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],               true                      ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               true                      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,        caseMatters:  false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,        caseMatters:  false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters,        caseMatters:  false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,        caseMatters:  false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,  caseMatters:  false));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true,  caseMatters:  false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],               true,  caseMatters:  false));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,  caseMatters:  false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,                      false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,                      false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters,                      false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,                      false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,                false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,                false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: true,                false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,                false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               true,                false)); // Assigns wrong parameter
      //IsFalse("B \t".In( [ "A", "B", "C" ],               true,                false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],               true,                false));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               true,                false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsCollectionsFlagsInFront()
    {
        IsTrue ("B"   .In(                      spaceMatters,        [ "A", "B", "C" ]));
        IsFalse("B \t".In(                      spaceMatters,        [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                      spaceMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In(                      spaceMatters,        [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                      spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In(                      spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                      spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In(                      spaceMatters: true,  [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                                    true,  [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsFalse("B \t".In(                                    true,  [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                                    true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(                                    true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters:  false, spaceMatters,        [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters:  false, spaceMatters,        [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters:  false, spaceMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters:  false, spaceMatters,        [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters:  false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters:  false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters:  false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters:  false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters:  false,               true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters:  false,               true,  [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters:  false,               true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters:  false,               true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               false, spaceMatters,        [ "A", "B", "C" ]));
        IsFalse("B \t".In(               false, spaceMatters,        [ "A", "B", "C" ]));
        IsTrue ("b"   .In(               false, spaceMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In(               false, spaceMatters,        [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In(               false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("b"   .In(               false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In(               false, spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               false,               true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In(               false,               true,  [ "A", "B", "C" ]));
        IsTrue ("b"   .In(               false,               true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In(               false,               true,  [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsCollectionsFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In( spaceMatters,                             [ "A", "B", "C" ])); // Not a swap
      //IsFalse("B \t".In( spaceMatters,                             [ "A", "B", "C" ]));
      //IsTrue ("b"   .In( spaceMatters,                             [ "A", "B", "C" ]));
      //IsFalse("b \t".In( spaceMatters,                             [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: true,                       [ "A", "B", "C" ]));
      //IsFalse("B \t".In( spaceMatters: true,                       [ "A", "B", "C" ]));
      //IsTrue ("b"   .In( spaceMatters: true,                       [ "A", "B", "C" ]));
      //IsFalse("b \t".In( spaceMatters: true,                       [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(               true,                       [ "A", "B", "C" ]));
      //IsFalse("B \t".In(               true,                       [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(               true,                       [ "A", "B", "C" ]));
      //IsFalse("b \t".In(               true,                       [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,        caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,        caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters,        caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,        caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters: true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters: true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters: true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters: true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse("B \t".In(               true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(               true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(               true,  caseMatters:  false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,                      false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,                      false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters,                      false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,                      false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters: true,                false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters: true,                false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters: true,                false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters: true,                false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(               true,                false, [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsFalse("B \t".In(               true,                false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(               true,                false, [ "A", "B", "C" ]));
      //IsFalse("b \t".In(               true,                false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsParamsFlagsInFront()
    {
        IsTrue ("B"   .In(                      spaceMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In(                      spaceMatters,          "A", "B", "C"  ));
        IsTrue ("b"   .In(                      spaceMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In(                      spaceMatters,          "A", "B", "C"  ));
      //IsTrue ("B"   .In(                      spaceMatters: true,    "A", "B", "C"  )); // TODO: Does not work
      //IsFalse("B \t".In(                      spaceMatters: true,    "A", "B", "C"  ));
      //IsTrue ("b"   .In(                      spaceMatters: true,    "A", "B", "C"  ));
      //IsFalse("b \t".In(                      spaceMatters: true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In(                                    true,    "A", "B", "C"  )); // Assigns wrong parameter
      //IsFalse("B \t".In(                                    true,    "A", "B", "C"  ));
      //IsTrue ("b"   .In(                                    true,    "A", "B", "C"  ));
      //IsFalse("b \t".In(                                    true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters:  false, spaceMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters:  false, spaceMatters,          "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters:  false, spaceMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters:  false, spaceMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters:  false, spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters:  false, spaceMatters: true,    "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters:  false, spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters:  false, spaceMatters: true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters:  false,               true,    "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters:  false,               true,    "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters:  false,               true,    "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters:  false,               true,    "A", "B", "C"  ));
        IsTrue ("B"   .In(               false, spaceMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In(               false, spaceMatters,          "A", "B", "C"  ));
        IsTrue ("b"   .In(               false, spaceMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In(               false, spaceMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In(               false, spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("B \t".In(               false, spaceMatters: true,    "A", "B", "C"  ));
        IsTrue ("b"   .In(               false, spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b \t".In(               false, spaceMatters: true,    "A", "B", "C"  ));
        IsTrue ("B"   .In(               false,               true,    "A", "B", "C"  ));
        IsFalse("B \t".In(               false,               true,    "A", "B", "C"  ));
        IsTrue ("b"   .In(               false,               true,    "A", "B", "C"  ));
        IsFalse("b \t".In(               false,               true,    "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsParamsFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In( spaceMatters,                               "A", "B", "C"  )); // Not a swap
      //IsFalse("B \t".In( spaceMatters,                               "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters,                               "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters,                               "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,                         "A", "B", "C"  ));
      //IsFalse("B \t".In( spaceMatters: true,                         "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: true,                         "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,                         "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true,                         "A", "B", "C"  ));
      //IsFalse("B \t".In(               true,                         "A", "B", "C"  ));
      //IsTrue ("b"   .In(               true,                         "A", "B", "C"  ));
      //IsFalse("b \t".In(               true,                         "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,        caseMatters:  false,   "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,        caseMatters:  false,   "A", "B", "C"  ));
        IsTrue ("b"   .In( spaceMatters,        caseMatters:  false,   "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,        caseMatters:  false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,  caseMatters:  false,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse("B \t".In( spaceMatters: true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsFalse("B \t".In(               true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(               true,  caseMatters:  false,   "A", "B", "C"  ));
      //IsFalse("b \t".In(               true,  caseMatters:  false,   "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,                      false,   "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,                      false,   "A", "B", "C"  ));
        IsTrue ("b"   .In( spaceMatters,                      false,   "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,                      false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,                false,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse("B \t".In( spaceMatters: true,                false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: true,                false,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,                false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true,                false,   "A", "B", "C"  )); // Assigns wrong parameter
      //IsFalse("B \t".In(               true,                false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(               true,                false,   "A", "B", "C"  ));
      //IsFalse("b \t".In(               true,                false,   "A", "B", "C"  ));
    }
}