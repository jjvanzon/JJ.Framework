namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_ExtensionsCaseOrSpaceMattersYesYes : TestBase
{
    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsFlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,         spaceMatters        ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters,         spaceMatters        ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,         spaceMatters        ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,         spaceMatters        ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,         spaceMatters: true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters,         spaceMatters: true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,         spaceMatters: true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,         spaceMatters: true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,                       true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters,                       true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,                       true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,                       true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters        ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters        ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters        ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters        ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters:  true,                true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters:  true,                true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters:  true,                true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters:  true,                true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,  spaceMatters        ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true,  spaceMatters        ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,  spaceMatters        ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,  spaceMatters        ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,  spaceMatters: true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true,  spaceMatters: true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,  spaceMatters: true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,  spaceMatters: true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,                true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true,                true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,                true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,                true  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsFlagsInBackSwapped()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,        caseMatters         ));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,        caseMatters         ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters,        caseMatters         ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,        caseMatters         ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters         ));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters         ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters         ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters         ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,  caseMatters         ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true,  caseMatters         ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,  caseMatters         ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,  caseMatters         ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,        caseMatters:  true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,        caseMatters:  true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters,        caseMatters:  true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,        caseMatters:  true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true,  caseMatters:  true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true,  caseMatters:  true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true,  caseMatters:  true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true,  caseMatters:  true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,                      true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,                      true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters,                      true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,                      true  ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,                true  ));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,                true  ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: true,                true  ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,                true  ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               true,                true  )); // Not a swap
      //IsFalse("B \t".In( [ "A", "B", "C" ],               true,                true  ));
      //IsFalse("b"   .In( [ "A", "B", "C" ],               true,                true  ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               true,                true  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsCollectionsFlagsInFront()
    {
        IsFalse("B \t".In( caseMatters,         spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("b"   .In( caseMatters,         spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("b \t".In( caseMatters,         spaceMatters,        [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( caseMatters,         spaceMatters: true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In( caseMatters,         spaceMatters: true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In( caseMatters,         spaceMatters: true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In( caseMatters,         spaceMatters: true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( caseMatters,                       true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In( caseMatters,                       true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In( caseMatters,                       true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In( caseMatters,                       true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( caseMatters:  true,  spaceMatters: true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( caseMatters:  true,  spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("B \t".In( caseMatters:  true,  spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("b"   .In( caseMatters:  true,  spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("b \t".In( caseMatters:  true,  spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("B \t".In( caseMatters:  true,  spaceMatters: true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In( caseMatters:  true,  spaceMatters: true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In( caseMatters:  true,  spaceMatters: true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( caseMatters:  true,                true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In( caseMatters:  true,                true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In( caseMatters:  true,                true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In( caseMatters:  true,                true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In(               true,  spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("B \t".In(               true,  spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("b"   .In(               true,  spaceMatters,        [ "A", "B", "C" ] ));
        IsFalse("b \t".In(               true,  spaceMatters,        [ "A", "B", "C" ] ));
        IsTrue ("B"   .In(               true,  spaceMatters: true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In(               true,  spaceMatters: true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In(               true,  spaceMatters: true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In(               true,  spaceMatters: true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In(               true,                true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In(               true,                true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In(               true,                true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In(               true,                true,  [ "A", "B", "C" ] ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsCollectionsFlagsInFrontSwapped()
    {
        IsTrue ("B"   .In( spaceMatters,        caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("B \t".In( spaceMatters,        caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("b"   .In( spaceMatters,        caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("b \t".In( spaceMatters,        caseMatters,         [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( spaceMatters: true,  caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("B \t".In( spaceMatters: true,  caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("b"   .In( spaceMatters: true,  caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("b \t".In( spaceMatters: true,  caseMatters,         [ "A", "B", "C" ] ));
        IsTrue ("B"   .In(               true,  caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("B \t".In(               true,  caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("b"   .In(               true,  caseMatters,         [ "A", "B", "C" ] ));
        IsFalse("b \t".In(               true,  caseMatters,         [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( spaceMatters,        caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In( spaceMatters,        caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In( spaceMatters,        caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In( spaceMatters,        caseMatters:  true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( spaceMatters: true,  caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In( spaceMatters: true,  caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In( spaceMatters: true,  caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In( spaceMatters: true,  caseMatters:  true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In(               true,  caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In(               true,  caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In(               true,  caseMatters:  true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In(               true,  caseMatters:  true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( spaceMatters,                      true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In( spaceMatters,                      true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In( spaceMatters,                      true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In( spaceMatters,                      true,  [ "A", "B", "C" ] ));
        IsTrue ("B"   .In( spaceMatters: true,                true,  [ "A", "B", "C" ] ));
        IsFalse("B \t".In( spaceMatters: true,                true,  [ "A", "B", "C" ] ));
        IsFalse("b"   .In( spaceMatters: true,                true,  [ "A", "B", "C" ] ));
        IsFalse("b \t".In( spaceMatters: true,                true,  [ "A", "B", "C" ] ));
      //IsTrue ("B"   .In(               true,                true,  [ "A", "B", "C" ] )); // Not a swap
      //IsFalse("B \t".In(               true,                true,  [ "A", "B", "C" ] ));
      //IsFalse("b"   .In(               true,                true,  [ "A", "B", "C" ] ));
      //IsFalse("b \t".In(               true,                true,  [ "A", "B", "C" ] ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsVariadicFlagsInFront()
    {
        IsTrue ("B"   .In( caseMatters,         spaceMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,         spaceMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,         spaceMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,         spaceMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters,         spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,         spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,         spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,         spaceMatters: true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters,                       true,    "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,                       true,    "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,                       true,    "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,                       true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters:  true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters:  true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters:  true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters:  true,  spaceMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters:  true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters:  true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters:  true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters:  true,  spaceMatters: true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters:  true,                true,    "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters:  true,                true,    "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters:  true,                true,    "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters:  true,                true,    "A", "B", "C"  ));
        IsTrue ("B"   .In(               true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In(               true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In(               true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In(               true,  spaceMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In(               true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("B \t".In(               true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b"   .In(               true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b \t".In(               true,  spaceMatters: true,    "A", "B", "C"  ));
        IsTrue ("B"   .In(               true,                true,    "A", "B", "C"  ));
        IsFalse("B \t".In(               true,                true,    "A", "B", "C"  ));
        IsFalse("b"   .In(               true,                true,    "A", "B", "C"  ));
        IsFalse("b \t".In(               true,                true,    "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsVariadicFlagsInFrontSwapped()
    {
        IsTrue ("B"   .In( spaceMatters,        caseMatters,           "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,        caseMatters,           "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters,        caseMatters,           "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,        caseMatters,           "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters: true,  caseMatters,           "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters: true,  caseMatters,           "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters: true,  caseMatters,           "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters: true,  caseMatters,           "A", "B", "C"  ));
        IsTrue ("B"   .In(               true,  caseMatters,           "A", "B", "C"  ));
        IsFalse("B \t".In(               true,  caseMatters,           "A", "B", "C"  ));
        IsFalse("b"   .In(               true,  caseMatters,           "A", "B", "C"  ));
        IsFalse("b \t".In(               true,  caseMatters,           "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,        caseMatters:  true,    "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,        caseMatters:  true,    "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters,        caseMatters:  true,    "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,        caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,  caseMatters:  true,    "A", "B", "C"  )); // TODO: Does not work
      //IsFalse("B \t".In( spaceMatters: true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse("B \t".In(               true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse("b"   .In(               true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse("b \t".In(               true,  caseMatters:  true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,                      true,    "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,                      true,    "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters,                      true,    "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,                      true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,                true,    "A", "B", "C"  )); // TODO: Does not work
      //IsFalse("B \t".In( spaceMatters: true,                true,    "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: true,                true,    "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,                true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true,                true,    "A", "B", "C"  )); // Not a swap
      //IsFalse("B \t".In(               true,                true,    "A", "B", "C"  ));
      //IsFalse("b"   .In(               true,                true,    "A", "B", "C"  ));
      //IsFalse("b \t".In(               true,                true,    "A", "B", "C"  ));
    }
}