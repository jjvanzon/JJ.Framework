namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_CaseOrSpaceMattersYesYes : TestBase
{
    // Yes / Yes
    
    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsFlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,                     true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],              true, spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: true,               true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              true, spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ],              true, spaceMatters: true));
        IsFalse("b"   .In( [ "A", "B", "C" ],              true, spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ],              true, spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              true,               true));
        IsFalse("B \t".In( [ "A", "B", "C" ],              true,               true));
        IsFalse("b"   .In( [ "A", "B", "C" ],              true,               true));
        IsFalse("b \t".In( [ "A", "B", "C" ],              true,               true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters      )); // Switch Flags
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,                    true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true, caseMatters      ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               true, caseMatters: true)); // Resolves ambiguously
      //IsFalse("B \t".In( [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse("b"   .In( [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               true, caseMatters: true));
      //IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,              true)); // Resolves ambiguously
      //IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,              true));
    }
    
    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticFlagsInBack()
    {
        // Static Syntax
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,                     true));
        IsTrue (In("B"   , [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],              true, spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true,               true));
        IsTrue (In("B"   , [ "A", "B", "C" ],              true, spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ],              true, spaceMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ],              true, spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ],              true, spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ],              true,               true));
        IsFalse(In("B \t", [ "A", "B", "C" ],              true,               true));
        IsFalse(In("b"   , [ "A", "B", "C" ],              true,               true));
        IsFalse(In("b \t", [ "A", "B", "C" ],              true,               true));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,       caseMatters      )); // Switch Flags
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,       caseMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters,       caseMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,       caseMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,                    true));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true, caseMatters      ));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,              true)); // Resolves ambiguously
      //IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse(In("B \t", [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse(In("b"   , [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               true, caseMatters: true));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsCollectionsFlagsInFront()
    {
        IsTrue ("B"   .In( caseMatters,        spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters,        spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters,        spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters,        spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters: true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters,        spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters,        spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters,        spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters,        spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters: true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: true,  spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters,                      true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters,                      true, [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters,                      true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters,                      true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In(              true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,  spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: true,                true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: true,                true, [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters: true,                true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: true,                true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(              true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,                true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(              true,                true, [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,                true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,                true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,       caseMatters,        [ "A", "B", "C" ])); // Switch Flags
        IsFalse("B \t".In( spaceMatters,       caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b"   .In( spaceMatters,       caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,       caseMatters,        [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: true, caseMatters: true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In( spaceMatters: true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In( spaceMatters: true, caseMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,       caseMatters: true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,       caseMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b"   .In( spaceMatters,       caseMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,       caseMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters: true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters: true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b"   .In( spaceMatters: true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters: true, caseMatters,        [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,                    true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,                    true,  [ "A", "B", "C" ]));
        IsFalse("b"   .In( spaceMatters,                    true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,                    true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("B \t".In(               true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b"   .In(               true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In(               true, caseMatters,        [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: true,              true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true,              true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In( spaceMatters: true,              true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In( spaceMatters: true,              true,  [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(               true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("B \t".In(               true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In(               true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(               true, caseMatters: true,  [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_ExtensionsVariadicFlagsInFront()
    {
        IsTrue ("B"   .In( caseMatters,        spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,        spaceMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,        spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,        spaceMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters: true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: true,  spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters,        spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,        spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,        spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,        spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters: true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: true,  spaceMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters,                      true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,                      true,   "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,                      true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,                      true,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In(              true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In(              true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In(              true,  spaceMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: true,                true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: true,                true,   "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters: true,                true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: true,                true,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("B \t".In(              true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b"   .In(              true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b \t".In(              true,  spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,                true,   "A", "B", "C"  ));
        IsFalse("B \t".In(              true,                true,   "A", "B", "C"  ));
        IsFalse("b"   .In(              true,                true,   "A", "B", "C"  ));
        IsFalse("b \t".In(              true,                true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,       caseMatters,          "A", "B", "C"  )); // Switch Flags
        IsFalse("B \t".In( spaceMatters,       caseMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters,       caseMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,       caseMatters,          "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true, caseMatters: true,    "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true, caseMatters: true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,       caseMatters: true,    "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,       caseMatters: true,    "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters,       caseMatters: true,    "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,       caseMatters: true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters: true, caseMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters: true, caseMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters: true, caseMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters: true, caseMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,                    true,    "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,                    true,    "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters,                    true,    "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,                    true,    "A", "B", "C"  ));
        IsTrue ("B"   .In(               true, caseMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In(               true, caseMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In(               true, caseMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In(               true, caseMatters,          "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,              true,    "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true,              true,    "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: true,              true,    "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,              true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("B \t".In(               true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("b"   .In(               true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("b \t".In(               true, caseMatters: true,    "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticCollectionsFlagsInFront()
    {
        // Static Syntax
        IsTrue (In("B"   , caseMatters,        spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,        spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,        spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,        spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,        spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,        spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,        spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,        spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                      true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t",              true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   ,              true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t",              true,  spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,                true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t",              true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   ,              true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",              true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t",              true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   ,              true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t",              true,                true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,       caseMatters,         [ "A", "B", "C" ])); // Switch Flags
        IsFalse(In("B \t", spaceMatters,       caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters,       caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,       caseMatters,         [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: true, caseMatters: true,   [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("b"   , spaceMatters: true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: true, caseMatters: true,   [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,       caseMatters: true,   [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,       caseMatters: true,   [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters,       caseMatters: true,   [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,       caseMatters: true,   [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters: true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,                    true,   [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,                    true,   [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters,                    true,   [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,                    true,   [ "A", "B", "C" ])); 
        IsTrue (In("B"   ,               true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true, caseMatters,         [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: true,              true,   [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true,              true,   [ "A", "B", "C" ]));
      //IsFalse(In("b"   , spaceMatters: true,              true,   [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: true,              true,   [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("B \t",               true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,               true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               true, caseMatters: true,   [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersYesYes_StaticVariadicFlagsInFront()
    {
        IsTrue (In("B"   , caseMatters,        spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,        spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,        spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,        spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,        spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,        spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,        spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,        spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                      true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,              true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t",              true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   ,              true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t",              true,  spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,                true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: true,                true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,                true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,                true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,              true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t",              true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b"   ,              true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t",              true,  spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,              true,                true,    "A", "B", "C"  ));
        IsFalse(In("B \t",              true,                true,    "A", "B", "C"  ));
        IsFalse(In("b"   ,              true,                true,    "A", "B", "C"  ));
        IsFalse(In("b \t",              true,                true,    "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,       caseMatters,           "A", "B", "C"  )); // Switch Flags
        IsFalse(In("B \t", spaceMatters,       caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters,       caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,       caseMatters,           "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true, caseMatters: true,     "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true, caseMatters: true,     "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,       caseMatters: true,     "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,       caseMatters: true,     "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters,       caseMatters: true,     "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,       caseMatters: true,     "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters: true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters: true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters: true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters: true, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,                    true,     "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,                    true,     "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters,                    true,     "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,                    true,     "A", "B", "C"  ));
        IsTrue (In("B"   ,               true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("B \t",               true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   ,               true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t",               true, caseMatters,           "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,              true,     "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true,              true,     "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: true,              true,     "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,              true,     "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("B \t",               true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("b"   ,               true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("b \t",               true, caseMatters: true,     "A", "B", "C"  ));
    }
}