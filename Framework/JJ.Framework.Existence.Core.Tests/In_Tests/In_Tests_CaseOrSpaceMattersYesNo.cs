namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_CaseOrSpaceMattersYesNo : TestBase
{
    // Yes / No

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesNo_ExtensionsFlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters                             ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters                             ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters                             ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters                             ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true                      ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters:  true                      ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true                      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true                      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,                       false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters,                       false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,                       false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,                       false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true,                false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters:  true,                false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true,                false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true,                false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,                false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               true,                false));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,                false));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,                false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true                      ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               true                      ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true                      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true                      ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesNo_ExtensionsFlagsInBackSwapped()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true )); // Switch Flags 
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               false, caseMatters        ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               false, caseMatters        ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               false, caseMatters        ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               false, caseMatters        ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false,               true ));// Resolves ambiguously
      //IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false,               true ));
      //IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false,               true ));
      //IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false,               true ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               false, caseMatters:  true ));
      //IsTrue ("B \t".In( [ "A", "B", "C" ],               false, caseMatters:  true ));
      //IsFalse("b"   .In( [ "A", "B", "C" ],               false, caseMatters:  true ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               false, caseMatters:  true ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesNo_StaticFlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters                             ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters                             ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters                             ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters                             ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true                      ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters:  true                      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true                      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true                      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,         spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,                       false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters,                       false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,                       false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,                       false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true,                false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters:  true,                false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true,                false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true,                false));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,  spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,                false));
        IsTrue (In("B \t", [ "A", "B", "C" ],               true,                false));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,                false));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,                false));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true                      ));
        IsTrue (In("B \t", [ "A", "B", "C" ],               true                      ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true                      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true                      ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesNo_StaticFlagsInBackSwapped()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true )); // Switch Flags
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters:  true ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters        ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters        ));
        IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters        ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               false, caseMatters        ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               false, caseMatters        ));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false,               true )); // Resolves ambiguously
      //IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false,               true ));
      //IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false,               true ));
      //IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false,               true ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters:  true ));
      //IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters:  true ));
      //IsFalse(In("b"   , [ "A", "B", "C" ],               false, caseMatters:  true ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               false, caseMatters:  true ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_ExtensionsCollectionFlagsInFront()
    {
        IsTrue ("B"   .In(caseMatters,                              [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,                              [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,                              [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,                              [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters:  true,                       [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters:  true,                       [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters:  true,                       [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters:  true,                       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters,                       false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,                       false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,                       false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,                       false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,                false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              true,                false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,                false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,                false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,                       [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              true,                       [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,                       [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,                       [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_ExtensionsCollectionFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In(spaceMatters: false, caseMatters: true,   [ "A", "B", "C" ])); // Switch Flags // Resolves ambiguously
      //IsTrue ("B \t".In(spaceMatters: false, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse("b"   .In(spaceMatters: false, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse("b \t".In(spaceMatters: false, caseMatters: true,   [ "A", "B", "C" ]));
        IsTrue ("B"   .In(spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue ("B \t".In(spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse("b"   .In(spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse("b \t".In(spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse("b"   .In(              false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse("b \t".In(              false, caseMatters,         [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(spaceMatters: false,              true,   [ "A", "B", "C" ])); // Resolves ambiguously
      //IsTrue ("B \t".In(spaceMatters: false,              true,   [ "A", "B", "C" ]));
      //IsFalse("b"   .In(spaceMatters: false,              true,   [ "A", "B", "C" ]));
      //IsFalse("b \t".In(spaceMatters: false,              true,   [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(              false, caseMatters: true,   [ "A", "B", "C" ]));
      //IsTrue ("B \t".In(              false, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse("b"   .In(              false, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse("b \t".In(              false, caseMatters: true,   [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_ExtensionsVariadicFlagsInFront()
    {
        IsTrue ("B"   .In(caseMatters,                                "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,                                "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,                                "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,                                "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters:  true,                         "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters:  true,                         "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters:  true,                         "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters:  true,                         "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters,                       false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,                       false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,                       false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,                       false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters:  true,                false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters:  true,                false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters:  true,                false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters:  true,                false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,                false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(              true,                false,   "A", "B", "C"  ));
        IsFalse("b"   .In(              true,                false,   "A", "B", "C"  ));
        IsFalse("b \t".In(              true,                false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,                         "A", "B", "C"  ));
        IsTrue ("B \t".In(              true,                         "A", "B", "C"  ));
        IsFalse("b"   .In(              true,                         "A", "B", "C"  ));
        IsFalse("b \t".In(              true,                         "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_ExtensionsVariadicFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In( spaceMatters: false, caseMatters:  true,   "A", "B", "C"  )); // Switch Flags // Resolves ambiguously
      //IsTrue ("B \t".In( spaceMatters: false, caseMatters:  true,   "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: false, caseMatters:  true,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: false, caseMatters:  true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters: false, caseMatters,          "A", "B", "C"  ));
        IsTrue ("B \t".In( spaceMatters: false, caseMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters: false, caseMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters: false, caseMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In(               false, caseMatters,          "A", "B", "C"  ));
        IsTrue ("B \t".In(               false, caseMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In(               false, caseMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In(               false, caseMatters,          "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: false,               true,   "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue ("B \t".In( spaceMatters: false,               true,   "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: false,               true,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: false,               true,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(               false, caseMatters:  true,   "A", "B", "C"  ));
      //IsTrue ("B \t".In(               false, caseMatters:  true,   "A", "B", "C"  ));
      //IsFalse("b"   .In(               false, caseMatters:  true,   "A", "B", "C"  ));
      //IsFalse("b \t".In(               false, caseMatters:  true,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_StaticCollectionFlagsInFront()
    {
        IsTrue (In("B"   , caseMatters,                              [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,                              [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                              [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                              [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,                       [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters:  true,                       [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,                       [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,                       [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,         spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,                       false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,                       false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                       false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                       false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",               true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",               true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,                       [ "A", "B", "C" ]));
        IsTrue (In("B \t",               true,                       [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,                       [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,                       [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_StaticCollectionFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   , spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ])); // Switch Flags // Resolves ambiguously
      //IsTrue (In("B \t", spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   , spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: false, caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B \t", spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B \t",               false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               false, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t",               false, caseMatters,         [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: false,               true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsTrue (In("B \t", spaceMatters: false,               true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   , spaceMatters: false,               true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: false,               true,  [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               false, caseMatters:  true,  [ "A", "B", "C" ]));
      //IsTrue (In("B \t",               false, caseMatters:  true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,               false, caseMatters:  true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               false, caseMatters:  true,  [ "A", "B", "C" ]));
    }                                                         

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_StaticVariadicFlagsInFront()
    {
        IsTrue (In("B"   , caseMatters,                                "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,                                "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                                "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                                "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,                         "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters:  true,                         "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,                         "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,                         "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,         spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,                       false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,                       false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                       false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                       false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,                false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters:  true,                false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,                false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,                false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t",               true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t",               true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,                false,   "A", "B", "C"  ));
        IsTrue (In("B \t",               true,                false,   "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,                false,   "A", "B", "C"  ));
        IsFalse(In("b \t",               true,                false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,                         "A", "B", "C"  ));
        IsTrue (In("B \t",               true,                         "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,                         "A", "B", "C"  ));
        IsFalse(In("b \t",               true,                         "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMatters_YesNo_StaticVariadicFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   , spaceMatters: false, caseMatters:  true,    "A", "B", "C"  )); // Switch Flags // Resolves ambiguously
      //IsTrue (In("B \t", spaceMatters: false, caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: false, caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: false, caseMatters:  true,    "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters: false, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B \t", spaceMatters: false, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters: false, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters: false, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   ,               false, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B \t",               false, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   ,               false, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t",               false, caseMatters,           "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false,               true,    "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue (In("B \t", spaceMatters: false,               true,    "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: false,               true,    "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: false,               true,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,               false, caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue (In("B \t",               false, caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b"   ,               false, caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",               false, caseMatters:  true,    "A", "B", "C"  ));
    }
}