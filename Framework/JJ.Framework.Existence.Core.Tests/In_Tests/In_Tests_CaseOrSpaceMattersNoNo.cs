namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_CaseOrSpaceMattersNoNo : TestBase
{
    // No / No

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_NoNo_ExtensionsFlagsInBack()
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
    public void In_String_CaseOrSpaceMatters_NoNo_ExtensionsFlagsInBackSwapped()
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
    public void In_String_CaseOrSpaceMatters_NoNo_StaticFlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ]                                         ));
        IsTrue (In("B \t", [ "A", "B", "C" ]                                         ));
        IsTrue (In("b"   , [ "A", "B", "C" ]                                         ));
        IsTrue (In("b \t", [ "A", "B", "C" ]                                         ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false                     ));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false                     ));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false                     ));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false                     ));
        IsTrue (In("B"   , [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false, spaceMatters: false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                   false)); // Assigns wrong parameter
      //IsTrue (In("B \t", [ "A", "B", "C" ],                                   false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                                   false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],                                   false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false,               false));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false,               false));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false,               false));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false,               false));
    }
        
    [TestMethod]
    public void In_String_CaseOrSpaceMatters_NoNo_StaticFlagsInBackSwapped()
    {
      //IsTrue (In("B"   , [ "A", "B", "C" ]                                         )); // Not a swap
      //IsTrue (In("B \t", [ "A", "B", "C" ]                                         ));
      //IsTrue (In("b"   , [ "A", "B", "C" ]                                         ));
      //IsTrue (In("b \t", [ "A", "B", "C" ]                                         ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue (In("B \t", [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],                      caseMatters: false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                   false));
      //IsTrue (In("B \t", [ "A", "B", "C" ],                                   false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                                   false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],                                   false));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false                    ));
      //IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false                    ));
      //IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: false                    ));
      //IsTrue (In("b \t", [ "A", "B", "C" ], spaceMatters: false                    ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: false,              false));
        IsTrue (In("b \t", [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               false                    )); // Assigns wrong parameter
      //IsTrue (In("B \t", [ "A", "B", "C" ],               false                    ));
      //IsTrue (In("b"   , [ "A", "B", "C" ],               false                    ));
      //IsTrue (In("b \t", [ "A", "B", "C" ],               false                    ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],               false, caseMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               false,              false)); // Not a swap
      //IsTrue (In("B \t", [ "A", "B", "C" ],               false,              false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],               false,              false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],               false,              false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_NoNo_ExtensionsCollectionFlagsInFront()
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
    public void In_String_CaseOrSpaceMatters_NoNo_ExtensionsCollectionFlagsInFrontSwapped()
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
    public void In_String_CaseOrSpaceMatters_NoNo_ExtensionsVariadicFlagsInFront()
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
    public void In_String_CaseOrSpaceMatters_NoNo_ExtensionsVariadicFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In( spaceMatters: false, caseMatters: false,   "A", "B", "C"  )); // Switch Flags // Resolves ambiguously
      //IsTrue ("B \t".In( spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In( spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue ("B \t".In( spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In( spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B \t".In(               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(               false, caseMatters: false,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_NoNo_StaticCollectionFlagsInFront()
    {
        IsTrue (In("B"   ,                                          [ "A", "B", "C" ]));
        IsTrue (In("B \t",                                          [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                                          [ "A", "B", "C" ]));
        IsTrue (In("b \t",                                          [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue (In("b \t", caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",              false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",              false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false,                      [ "A", "B", "C" ]));
        IsTrue (In("B \t",              false,                      [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false,                      [ "A", "B", "C" ]));
        IsTrue (In("b \t",              false,                      [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_NoNo_StaticCollectionFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   , spaceMatters: false, caseMatters: false, [ "A", "B", "C" ])); // Switch Flags // Resolves ambiguously
      //IsTrue (In("B \t", spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   , spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("b \t", spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue (In("B \t", spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   , spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue (In("b \t", spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("B \t",               false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,               false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("b \t",               false, caseMatters: false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_NoNo_StaticVariadicFlagsInFront()
    {
      //IsTrue (In("B"   ,                                            "A", "B", "C"  )); // Not supported. Too ambiguous.
      //IsTrue (In("B \t",                                            "A", "B", "C"  ));
      //IsTrue (In("b"   ,                                            "A", "B", "C"  ));
      //IsTrue (In("b \t",                                            "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b \t", caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("b \t", caseMatters: false,                        "A", "B", "C"  ));
      //IsTrue (In("B"   ,                     spaceMatters: false,   "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue (In("B \t",                     spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("b"   ,                     spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("b \t",                     spaceMatters: false,   "A", "B", "C"  )); 
        IsTrue (In("B"   , caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue (In("b \t", caseMatters: false,               false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t",              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   ,              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b \t",              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              false,               false,   "A", "B", "C"  ));
        IsTrue (In("B \t",              false,               false,   "A", "B", "C"  ));
        IsTrue (In("b"   ,              false,               false,   "A", "B", "C"  ));
        IsTrue (In("b \t",              false,               false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              false,                        "A", "B", "C"  ));
        IsTrue (In("B \t",              false,                        "A", "B", "C"  ));
        IsTrue (In("b"   ,              false,                        "A", "B", "C"  ));
        IsTrue (In("b \t",              false,                        "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_NoNo_StaticVariadicFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   , spaceMatters: false, caseMatters: false,   "A", "B", "C"  )); // Switch Flags // Resolves ambiguously
      //IsTrue (In("B \t", spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("b \t", spaceMatters: false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue (In("B \t", spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue (In("b \t", spaceMatters: false,              false,   "A", "B", "C"  ));
      //IsTrue (In("B"   ,               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("B \t",               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,               false, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("b \t",               false, caseMatters: false,   "A", "B", "C"  ));
    }
}