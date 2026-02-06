namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_ExtensionsCaseOrSpaceMattersYesNo : TestBase
{
    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesNo_ExtensionsFlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters                             ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters                             ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters                             ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters                             ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,                       false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters,                       false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,                       false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,                       false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true                      ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters:  true                      ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true                      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true                      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true,                false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters:  true,                false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true,                false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true,                false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true                      ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               true                      ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true                      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true                      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,                false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               true,                false));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,                false));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,                false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesNo_ExtensionsFlagsInBackSwapped()
    {
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                      caseMatters         )); // Not a swap
      //IsTrue ("B \t".In( [ "A", "B", "C" ],                      caseMatters         ));
      //IsFalse("b"   .In( [ "A", "B", "C" ],                      caseMatters         ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],                      caseMatters         ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters         ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters         ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters         ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters         ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               false, caseMatters         ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               false, caseMatters         ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               false, caseMatters         ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               false, caseMatters         ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                      caseMatters:  true  )); // Not a swap
      //IsTrue ("B \t".In( [ "A", "B", "C" ],                      caseMatters:  true  ));
      //IsFalse("b"   .In( [ "A", "B", "C" ],                      caseMatters:  true  ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],                      caseMatters:  true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true  ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               false, caseMatters:  true  ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               false, caseMatters:  true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               false, caseMatters:  true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               false, caseMatters:  true  ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                                    true  )); // Assigns wrong parameter
      //IsTrue ("B \t".In( [ "A", "B", "C" ],                                    true  ));
      //IsFalse("b"   .In( [ "A", "B", "C" ],                                    true  ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],                                    true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false,               true  ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false,               true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false,               true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false,               true  ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               false,               true  )); // Assigns wrong parameter
      //IsTrue ("B \t".In( [ "A", "B", "C" ],               false,               true  ));
      //IsFalse("b"   .In( [ "A", "B", "C" ],               false,               true  ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               false,               true  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_ExtensionsCollectionFlagsInFront()
    {
        IsTrue ("B"   .In(caseMatters,                              [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,                              [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,                              [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,                              [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters,                       false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,                       false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,                       false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,                       false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters:  true,                       [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters:  true,                       [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters:  true,                       [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters:  true,                       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,                       [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              true,                       [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,                       [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,                       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,                false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              true,                false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,                false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,                false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_ExtensionsCollectionFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In(                     caseMatters,         [ "A", "B", "C" ])); // Not a swap
      //IsTrue ("B \t".In(                     caseMatters,         [ "A", "B", "C" ]));
      //IsFalse("b"   .In(                     caseMatters,         [ "A", "B", "C" ]));
      //IsFalse("b \t".In(                     caseMatters,         [ "A", "B", "C" ]));
        IsTrue ("B"   .In(spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue ("B \t".In(spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse("b"   .In(spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse("b \t".In(spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse("b"   .In(              false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse("b \t".In(              false, caseMatters,         [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                     caseMatters:  true,  [ "A", "B", "C" ])); // Not a swap
      //IsTrue ("B \t".In(                     caseMatters:  true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In(                     caseMatters:  true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(                     caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In(spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue ("B \t".In(spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse("b"   .In(spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In(spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse("b"   .In(              false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In(              false, caseMatters:  true,  [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                                   true,  [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsTrue ("B \t".In(                                   true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In(                                   true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(                                   true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In(spaceMatters: false,               true,  [ "A", "B", "C" ]));
        IsTrue ("B \t".In(spaceMatters: false,               true,  [ "A", "B", "C" ]));
        IsFalse("b"   .In(spaceMatters: false,               true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In(spaceMatters: false,               true,  [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(              false,               true,  [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsTrue ("B \t".In(              false,               true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In(              false,               true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(              false,               true,  [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_ExtensionsVariadicFlagsInFront()
    {
        IsTrue ("B"   .In(caseMatters,                                "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,                                "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,                                "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,                                "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters,                       false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,                       false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,                       false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,                       false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters:  true,                         "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters:  true,                         "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters:  true,                         "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters:  true,                         "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters:  true,                false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters:  true,                false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters:  true,                false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters:  true,                false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,                         "A", "B", "C"  ));
        IsTrue ("B \t".In(              true,                         "A", "B", "C"  ));
        IsFalse("b"   .In(              true,                         "A", "B", "C"  ));
        IsFalse("b \t".In(              true,                         "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,                false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(              true,                false,   "A", "B", "C"  ));
        IsFalse("b"   .In(              true,                false,   "A", "B", "C"  ));
        IsFalse("b \t".In(              true,                false,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_ExtensionsVariadicFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In(                     caseMatters,            "A", "B", "C"  )); // Not a swap
      //IsTrue ("B \t".In(                     caseMatters,            "A", "B", "C"  ));
      //IsFalse("b"   .In(                     caseMatters,            "A", "B", "C"  ));
      //IsFalse("b \t".In(                     caseMatters,            "A", "B", "C"  ));
        IsTrue ("B"   .In(spaceMatters: false, caseMatters,            "A", "B", "C"  ));
        IsTrue ("B \t".In(spaceMatters: false, caseMatters,            "A", "B", "C"  ));
        IsFalse("b"   .In(spaceMatters: false, caseMatters,            "A", "B", "C"  ));
        IsFalse("b \t".In(spaceMatters: false, caseMatters,            "A", "B", "C"  ));
        IsTrue ("B"   .In(              false, caseMatters,            "A", "B", "C"  ));
        IsTrue ("B \t".In(              false, caseMatters,            "A", "B", "C"  ));
        IsFalse("b"   .In(              false, caseMatters,            "A", "B", "C"  ));
        IsFalse("b \t".In(              false, caseMatters,            "A", "B", "C"  ));
      //IsTrue ("B"   .In(                     caseMatters:  true,     "A", "B", "C"  )); // Not a swap
      //IsTrue ("B \t".In(                     caseMatters:  true,     "A", "B", "C"  ));
      //IsFalse("b"   .In(                     caseMatters:  true,     "A", "B", "C"  ));
      //IsFalse("b \t".In(                     caseMatters:  true,     "A", "B", "C"  ));
      //IsTrue ("B"   .In(spaceMatters: false, caseMatters:  true,     "A", "B", "C"  )); // TODO: Does not work
      //IsTrue ("B \t".In(spaceMatters: false, caseMatters:  true,     "A", "B", "C"  ));
      //IsFalse("b"   .In(spaceMatters: false, caseMatters:  true,     "A", "B", "C"  ));
      //IsFalse("b \t".In(spaceMatters: false, caseMatters:  true,     "A", "B", "C"  ));
      //IsTrue ("B"   .In(              false, caseMatters:  true,     "A", "B", "C"  ));
      //IsTrue ("B \t".In(              false, caseMatters:  true,     "A", "B", "C"  ));
      //IsFalse("b"   .In(              false, caseMatters:  true,     "A", "B", "C"  ));
      //IsFalse("b \t".In(              false, caseMatters:  true,     "A", "B", "C"  ));
      //IsTrue ("B"   .In(                                   true,     "A", "B", "C"  )); // Not a swap
      //IsTrue ("B \t".In(                                   true,     "A", "B", "C"  ));
      //IsFalse("b"   .In(                                   true,     "A", "B", "C"  ));
      //IsFalse("b \t".In(                                   true,     "A", "B", "C"  ));
      //IsTrue ("B"   .In(spaceMatters: false,               true,     "A", "B", "C"  )); // TODO: Does not work
      //IsTrue ("B \t".In(spaceMatters: false,               true,     "A", "B", "C"  ));
      //IsFalse("b"   .In(spaceMatters: false,               true,     "A", "B", "C"  ));
      //IsFalse("b \t".In(spaceMatters: false,               true,     "A", "B", "C"  ));
      //IsTrue ("B"   .In(              false,               true,     "A", "B", "C"  )); // Assigns wrong parameter
      //IsTrue ("B \t".In(              false,               true,     "A", "B", "C"  ));
      //IsFalse("b"   .In(              false,               true,     "A", "B", "C"  ));
      //IsFalse("b \t".In(              false,               true,     "A", "B", "C"  ));
    }
}