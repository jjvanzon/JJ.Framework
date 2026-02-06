namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_ExtensionsCaseOrSpaceMattersNoNo : TestBase
{
    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_ExtensionsFlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ]                                         ));
        IsTrue ("B \t".In( [ "A", "B", "C" ]                                         ));
        IsTrue ("b"   .In( [ "A", "B", "C" ]                                         ));
        IsTrue ("b \t".In( [ "A", "B", "C" ]                                         ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue ("b \t".In( [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false                     ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              false                     ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false                     ));
        IsTrue ("b \t".In( [ "A", "B", "C" ],              false                     ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],              false, spaceMatters: false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                                   false)); // Assigns wrong parameter
      //IsTrue ("B \t".In( [ "A", "B", "C" ],                                   false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],                                   false));
      //IsTrue ("b \t".In( [ "A", "B", "C" ],                                   false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false,               false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              false,               false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false,               false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],              false,               false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_ExtensionsFlagsInBackSwapped()
    {
      //IsTrue ("B"   .In( [ "A", "B", "C" ]                                         )); // Not a swap
      //IsTrue ("B \t".In( [ "A", "B", "C" ]                                         ));
      //IsTrue ("b"   .In( [ "A", "B", "C" ]                                         ));
      //IsTrue ("b \t".In( [ "A", "B", "C" ]                                         ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue ("B \t".In( [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue ("b \t".In( [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                                   false));
      //IsTrue ("B \t".In( [ "A", "B", "C" ],                                   false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],                                   false));
      //IsTrue ("b \t".In( [ "A", "B", "C" ],                                   false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false                    ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false                    ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: false                    ));
        IsTrue ("b \t".In( [ "A", "B", "C" ], spaceMatters: false                    ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               false                    )); // Not a swap
      //IsTrue ("B \t".In( [ "A", "B", "C" ],               false                    ));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],               false                    ));
      //IsTrue ("b \t".In( [ "A", "B", "C" ],               false                    ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               false,              false)); // Not a swap
      //IsTrue ("B \t".In( [ "A", "B", "C" ],               false,              false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],               false,              false));
      //IsTrue ("b \t".In( [ "A", "B", "C" ],               false,              false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_ExtensionsCollectionFlagsInFront()
    {
        IsTrue ("B"   .In(                                          [ "A", "B", "C" ]));
        IsTrue ("B \t".In(                                          [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                                          [ "A", "B", "C" ]));
        IsTrue ("b \t".In(                                          [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue ("B \t".In( caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue ("b \t".In( caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false,                      [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false,                      [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false,                      [ "A", "B", "C" ]));
        IsTrue ("b \t".In(              false,                      [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In( caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In( caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(              false, spaceMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                                   false, [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsTrue ("B \t".In(                                   false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                                   false, [ "A", "B", "C" ]));
      //IsTrue ("b \t".In(                                   false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In( caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In( caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false,               false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false,               false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false,               false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(              false,               false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_ExtensionsCollectionFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In(                                          [ "A", "B", "C" ])); // Not a swap
      //IsTrue ("B \t".In(                                          [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                                          [ "A", "B", "C" ]));
      //IsTrue ("b \t".In(                                          [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                      caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("B \t".In(                      caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                      caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b \t".In(                      caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                                   false, [ "A", "B", "C" ]));
      //IsTrue ("B \t".In(                                   false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                                   false, [ "A", "B", "C" ]));
      //IsTrue ("b \t".In(                                   false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters: false,                     [ "A", "B", "C" ]));
        IsTrue ("B \t".In( spaceMatters: false,                     [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters: false,                     [ "A", "B", "C" ]));
        IsTrue ("b \t".In( spaceMatters: false,                     [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In( spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In( spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters: false,              false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In( spaceMatters: false,              false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters: false,              false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In( spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(               false,                     [ "A", "B", "C" ])); // Assigns wrong parameter
      //IsTrue ("B \t".In(               false,                     [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(               false,                     [ "A", "B", "C" ]));
      //IsTrue ("b \t".In(               false,                     [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(               false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(               false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(               false, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               false,              false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(               false,              false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(               false,              false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(               false,              false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_ExtensionsVariadicFlagsInFront()
    {
        IsTrue ("B"   .In(                                            "A", "B", "C"  ));
        IsTrue ("B \t".In(                                            "A", "B", "C"  ));
        IsTrue ("b"   .In(                                            "A", "B", "C"  ));
        IsTrue ("b \t".In(                                            "A", "B", "C"  ));
      //IsTrue ("B"   .In(                     spaceMatters: false,   "A", "B", "C"  )); // TODO: Does not work
      //IsTrue ("B \t".In(                     spaceMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                     spaceMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(                     spaceMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(                                   false,   "A", "B", "C"  )); // Assigns wrong parameter
      //IsTrue ("B \t".In(                                   false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                                   false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(                                   false,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: false,                        "A", "B", "C"  ));
        IsTrue ("B \t".In( caseMatters: false,                        "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters: false,                        "A", "B", "C"  ));
        IsTrue ("b \t".In( caseMatters: false,                        "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In( caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("b \t".In( caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue ("B \t".In( caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue ("b \t".In( caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              false,                        "A", "B", "C"  ));
        IsTrue ("B \t".In(              false,                        "A", "B", "C"  ));
        IsTrue ("b"   .In(              false,                        "A", "B", "C"  ));
        IsTrue ("b \t".In(              false,                        "A", "B", "C"  ));
        IsTrue ("B"   .In(              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("b"   .In(              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("b \t".In(              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              false,               false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(              false,               false,   "A", "B", "C"  ));
        IsTrue ("b"   .In(              false,               false,   "A", "B", "C"  ));
        IsTrue ("b \t".In(              false,               false,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoNo_ExtensionsVariadicFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In(                                            "A", "B", "C"  )); // Not a swap
      //IsTrue ("B \t".In(                                            "A", "B", "C"  ));
      //IsTrue ("b"   .In(                                            "A", "B", "C"  ));
      //IsTrue ("b \t".In(                                            "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: false,                       "A", "B", "C"  ));
      //IsTrue ("B \t".In( spaceMatters: false,                       "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: false,                       "A", "B", "C"  ));
      //IsTrue ("b \t".In( spaceMatters: false,                       "A", "B", "C"  ));
      //IsTrue ("B"   .In(               false,                       "A", "B", "C"  )); // Assigns wrong parameter
      //IsTrue ("B \t".In(               false,                       "A", "B", "C"  ));
      //IsTrue ("b"   .In(               false,                       "A", "B", "C"  ));
      //IsTrue ("b \t".In(               false,                       "A", "B", "C"  ));
      //IsTrue ("B"   .In(                      caseMatters: false,   "A", "B", "C"  )); // Not a swap
      //IsTrue ("B \t".In(                      caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                      caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(                      caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: false, caseMatters: false,   "A", "B", "C"  )); // TODO: Does not work
      //IsTrue ("B \t".In( spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In( spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B \t".In(               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(                                   false,   "A", "B", "C"  )); // Not a swap
      //IsTrue ("B \t".In(                                   false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                                   false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(                                   false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: false,              false,   "A", "B", "C"  )); // TODO: Does not work
      //IsTrue ("B \t".In( spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In( spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(               false,              false,   "A", "B", "C"  )); // Not a swap
      //IsTrue ("B \t".In(               false,              false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(               false,              false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(               false,              false,   "A", "B", "C"  ));
    }
}