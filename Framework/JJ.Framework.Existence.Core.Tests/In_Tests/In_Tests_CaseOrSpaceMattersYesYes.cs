namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_StaticCaseOrSpaceMattersYesYes : TestBase
{
    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticFlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,         spaceMatters        ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,         spaceMatters        ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,         spaceMatters        ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,         spaceMatters        ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,         spaceMatters: true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,         spaceMatters: true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,         spaceMatters: true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,         spaceMatters: true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,                       true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,                       true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,                       true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,                       true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true,  spaceMatters        ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters:  true,  spaceMatters        ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true,  spaceMatters        ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true,  spaceMatters        ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true,  spaceMatters: true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters:  true,                true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters:  true,                true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters:  true,                true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters:  true,                true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,  spaceMatters        ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true,  spaceMatters        ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,  spaceMatters        ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,  spaceMatters        ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,  spaceMatters: true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true,  spaceMatters: true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,  spaceMatters: true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,  spaceMatters: true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,                true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true,                true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,                true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,                true  ));
    }
    
    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticFlagsInBackSwapped()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,        caseMatters         ));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,        caseMatters         ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters,        caseMatters         ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,        caseMatters         ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,        caseMatters:  true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,        caseMatters:  true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters,        caseMatters:  true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,        caseMatters:  true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,                      true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,                      true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters,                      true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,                      true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,  caseMatters         ));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,  caseMatters         ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true,  caseMatters         ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,  caseMatters         ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,  caseMatters:  true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,                true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,                true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true,                true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,                true  ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,  caseMatters         ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true,  caseMatters         ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,  caseMatters         ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,  caseMatters         ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true,  caseMatters:  true  ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true,  caseMatters:  true  ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true,  caseMatters:  true  ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true,  caseMatters:  true  ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               true,                true  )); // Not a swap
      //IsFalse(In("B \t", [ "A", "B", "C" ],               true,                true  ));
      //IsFalse(In("b"   , [ "A", "B", "C" ],               true,                true  ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               true,                true  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticCollectionsFlagsInFront()
    {
        IsTrue (In("B"   , caseMatters,         spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,         spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,         spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,         spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,         spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,         spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,         spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,         spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,                       true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,                       true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                       true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                       true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters:  true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,  spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters:  true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters:  true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters:  true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters:  true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters:  true,                true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,  spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,                true,  [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticCollectionsFlagsInFrontSwapped()
    {
        IsTrue (In("B"   , spaceMatters,        caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,        caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters,        caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,        caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: true,  caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters: true,  caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: true,  caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true,  caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,  caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true,  caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,  caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,  caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,        caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,        caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters,        caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,        caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: true,  caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters: true,  caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: true,  caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true,  caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true,  caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true,  caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true,  caseMatters:  true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true,  caseMatters:  true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,                      true,  [ "A", "B", "C" ])); 
        IsTrue (In("B"   , spaceMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true,                true,  [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               true,                true,  [ "A", "B", "C" ])); // Not a swap
      //IsFalse(In("B \t",               true,                true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,               true,                true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               true,                true,  [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticVariadicFlagsInFront()
    {
        IsTrue (In("B"   , caseMatters,         spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,         spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,         spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,         spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,         spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,         spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,         spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,         spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,                       true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,                       true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                       true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                       true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters:  true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,  spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters:  true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,  spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters:  true,                true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters:  true,                true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters:  true,                true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters:  true,                true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t",               true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t",               true,  spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t",               true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t",               true,  spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,                true,    "A", "B", "C"  ));
        IsFalse(In("B \t",               true,                true,    "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,                true,    "A", "B", "C"  ));
        IsFalse(In("b \t",               true,                true,    "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticVariadicFlagsInFrontSwapped()
    {
        IsTrue (In("B"   , spaceMatters,        caseMatters,           "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,        caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters,        caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,        caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters: true,  caseMatters,           "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters: true,  caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters: true,  caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters: true,  caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   ,               true,  caseMatters,           "A", "B", "C"  ));
        IsFalse(In("B \t",               true,  caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   ,               true,  caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t",               true,  caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,        caseMatters:  true,    "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,        caseMatters:  true,    "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters,        caseMatters:  true,    "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,        caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,  caseMatters:  true,    "A", "B", "C"  )); // TODO: Does not work
      //IsFalse(In("B \t", spaceMatters: true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("B \t",               true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b"   ,               true,  caseMatters:  true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",               true,  caseMatters:  true,    "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,                      true,    "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,                true,    "A", "B", "C"  )); // TODO: Does not work
      //IsFalse(In("B \t", spaceMatters: true,                true,    "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: true,                true,    "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,                true,    "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true,                true,    "A", "B", "C"  )); // Not a swap
      //IsFalse(In("B \t",               true,                true,    "A", "B", "C"  ));
      //IsFalse(In("b"   ,               true,                true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",               true,                true,    "A", "B", "C"  ));
    }
}