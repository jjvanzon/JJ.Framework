namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_CaseOrSpaceMattersNoYes : TestBase
{
    // No / Yes

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsFlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ],                     spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],                     spaceMatters      ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                     spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],                     spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                     spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ],                     spaceMatters: true));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                     spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ],                     spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false,               true));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: false,               true));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false,               true));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: false,               true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false, spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],              false, spaceMatters      ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false, spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],              false, spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false, spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ],              false, spaceMatters: true));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false, spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ],              false, spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false,               true));
        IsFalse("B \t".In( [ "A", "B", "C" ],              false,               true));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false,               true));
        IsFalse("b \t".In( [ "A", "B", "C" ],              false,               true));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsFlagsInBackSwapped()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,                    false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,                    false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters,                    false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,                    false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,              false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,              false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: true,              false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,              false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true, caseMatters: false));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true, caseMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],               true, caseMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true, caseMatters: false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticFlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ],                     spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],                     spaceMatters      ));
        IsTrue (In("b"   , [ "A", "B", "C" ],                     spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],                     spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ],                     spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ],                     spaceMatters: true));
        IsTrue (In("b"   , [ "A", "B", "C" ],                     spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ],                     spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false,               true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: false,               true));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false,               true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: false,               true));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],              false, spaceMatters      ));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],              false, spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false, spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ],              false, spaceMatters: true));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false, spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ],              false, spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false,               true));
        IsFalse(In("B \t", [ "A", "B", "C" ],              false,               true));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false,               true));
        IsFalse(In("b \t", [ "A", "B", "C" ],              false,               true));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticFlagsInBackSwapped()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,                    false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,                    false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters,                    false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,                    false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,              false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,              false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: true,              false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,              false));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true, caseMatters: false));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true, caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],               true, caseMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true, caseMatters: false));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsCollectionsFlagsInFront()
    {
        IsTrue ("B"   .In(                     spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In(                     spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                     spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In(                     spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                     spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(                     spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                     spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(                     spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false,               true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: false,               true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false,               true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: false,               true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In(              false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In(              false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(              false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(              false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false,               true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(              false,               true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false,               true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(              false,               true, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsCollectionsFlagsInFrontSwapped()
    {
        IsTrue ("B"   .In( spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,                    false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,                    false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters,                    false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,                    false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters: true,              false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters: true,              false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters: true,              false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters: true,              false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               true, caseMatters: false, [ "A", "B", "C" ]));
        IsFalse("B \t".In(               true, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(               true, caseMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(               true, caseMatters: false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsVariadicFlagsInFront()
    {
        IsTrue ("B"   .In(                     spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In(                     spaceMatters,         "A", "B", "C"  ));
        IsTrue ("b"   .In(                     spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In(                     spaceMatters,         "A", "B", "C"  ));
      //IsTrue ("B"   .In(                     spaceMatters: true,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse("B \t".In(                     spaceMatters: true,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                     spaceMatters: true,   "A", "B", "C"  ));
      //IsFalse("b \t".In(                     spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: false,               true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: false,               true,   "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters: false,               true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: false,               true,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              false, spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In(              false, spaceMatters,         "A", "B", "C"  ));
        IsTrue ("b"   .In(              false, spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In(              false, spaceMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In(              false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("B \t".In(              false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("b"   .In(              false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b \t".In(              false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              false,               true,   "A", "B", "C"  ));
        IsFalse("B \t".In(              false,               true,   "A", "B", "C"  ));
        IsTrue ("b"   .In(              false,               true,   "A", "B", "C"  ));
        IsFalse("b \t".In(              false,               true,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_ExtensionsVariadicFlagsInFrontSwapped()
    {
      //IsTrue ("B"   .In( spaceMatters: true, caseMatters: false,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse("B \t".In( spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsTrue ("b"   .In( spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,                    false,   "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,                    false,   "A", "B", "C"  ));
        IsTrue ("b"   .In( spaceMatters,                    false,   "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,                    false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,              false,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse("B \t".In( spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse("B \t".In(               true, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(               true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse("b \t".In(               true, caseMatters: false,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticCollectionsFlagsInFront()
    {
        IsTrue (In("B"   ,                     spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("B \t",                     spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                     spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("b \t",                     spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                     spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("B \t",                     spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                     spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("b \t",                     spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false,               true, [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: false,               true, [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false,               true, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: false,               true, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("B \t",              false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("b \t",              false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("B \t",              false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("b \t",              false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              false,               true, [ "A", "B", "C" ]));
        IsFalse(In("B \t",              false,               true, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,              false,               true, [ "A", "B", "C" ]));
        IsFalse(In("b \t",              false,               true, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticCollectionsFlagsInFrontSwapped()
    {
        IsTrue (In("B"   , spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,                    false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,                    false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters,                    false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,                    false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: true,              false, [ "A", "B", "C" ])); 
        IsFalse(In("B \t", spaceMatters: true,              false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters: true,              false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true,              false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true, caseMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,               true, caseMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true, caseMatters: false, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticVariadicFlagsInFront()
    {
        IsTrue (In("B"   ,                     spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("B \t",                     spaceMatters,         "A", "B", "C"  ));
        IsTrue (In("b"   ,                     spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("b \t",                     spaceMatters,         "A", "B", "C"  ));
      //IsTrue (In("B"   ,                     spaceMatters: true,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse(In("B \t",                     spaceMatters: true,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,                     spaceMatters: true,   "A", "B", "C"  ));
      //IsFalse(In("b \t",                     spaceMatters: true,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false,               true,   "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: false,               true,   "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false,               true,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: false,               true,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              false, spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("B \t",              false, spaceMatters,         "A", "B", "C"  ));
        IsTrue (In("b"   ,              false, spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("b \t",              false, spaceMatters,         "A", "B", "C"  ));
        IsTrue (In("B"   ,              false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse(In("B \t",              false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue (In("b"   ,              false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse(In("b \t",              false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              false,               true,   "A", "B", "C"  ));
        IsFalse(In("B \t",              false,               true,   "A", "B", "C"  ));
        IsTrue (In("b"   ,              false,               true,   "A", "B", "C"  ));
        IsFalse(In("b \t",              false,               true,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseOrSpaceMattersNoYes_StaticVariadicFlagsInFrontSwapped()
    {
      //IsTrue (In("B"   , spaceMatters: true, caseMatters: false,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse(In("B \t", spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   , spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,                    false,   "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,                    false,   "A", "B", "C"  ));
        IsTrue (In("b"   , spaceMatters,                    false,   "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,                    false,   "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,              false,   "A", "B", "C"  )); // TODO: Does not work
      //IsFalse(In("B \t", spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse(In("B \t",               true, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,               true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse(In("b \t",               true, caseMatters: false,   "A", "B", "C"  ));
    }
}