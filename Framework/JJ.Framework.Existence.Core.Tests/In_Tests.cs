namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests : TestBase
{
    [TestMethod]
    public void In_Strings_MatchCase_YesOrNo()
    {
        // Main Use
        IsTrue ("GREEN".In("Red", "Green", "Blue"));
        
        // Collection Expressions
        IsTrue (In("GREEN", [ "Red", "Green", "Blue" ]));
        IsTrue ("GREEN".In( [ "Red", "Green", "Blue" ]));
        
        // Ignore Case (default behavior)
        IsTrue ("GREEN".In( matchCase: false,   "Red", "Green", "Blue"  ));
        IsTrue ("GREEN".In( matchCase: false, [ "Red", "Green", "Blue" ]));
        IsTrue (In("GREEN", [ "Red", "Green", "Blue" ], matchCase: false));
        IsTrue ("GREEN".In( [ "Red", "Green", "Blue" ], matchCase: false));
        
        // Match case
        IsFalse("GREEN".In( matchCase,         "Red", "Green", "Blue"   ));
        IsFalse("GREEN".In( matchCase: true,   "Red", "Green", "Blue"   ));
        IsFalse("GREEN".In( matchCase,       [ "Red", "Green", "Blue" ] ));
        IsFalse("GREEN".In( matchCase: true, [ "Red", "Green", "Blue" ] ));
        IsFalse(In("GREEN", [ "Red", "Green", "Blue" ], matchCase       ));
        IsFalse(In("GREEN", [ "Red", "Green", "Blue" ], matchCase: true ));
        IsFalse("GREEN".In( [ "Red", "Green", "Blue" ], matchCase       ));
        IsFalse("GREEN".In( [ "Red", "Green", "Blue" ], matchCase: true ));
        IsTrue ("Green" .In(matchCase,          "Red", "Green", "Blue"  ));
        IsTrue ("Green" .In(matchCase: true,    "Red", "Green", "Blue"  ));
        IsTrue ("Green" .In(matchCase,        [ "Red", "Green", "Blue" ]));
        IsTrue ("Green" .In(matchCase: true,  [ "Red", "Green", "Blue" ]));
        IsTrue (In("Green", [ "Red", "Green", "Blue" ], matchCase       ));
        IsTrue (In("Green", [ "Red", "Green", "Blue" ], matchCase: true ));
        IsTrue ("Green" .In([ "Red", "Green", "Blue" ], matchCase       ));
        IsTrue ("Green" .In([ "Red", "Green", "Blue" ], matchCase: true ));
        
        // Negative match 
        IsFalse("Yellow".In(   "Red", "Green", "Blue"  ));
        IsFalse(In("Yellow", [ "Red", "Green", "Blue" ]));
        IsFalse("Yellow".In( [ "Red", "Green", "Blue" ]));
    }
    
    [TestMethod]
    public void In_Strings_SpaceMatters_YesOrNo()
    {
        // Without spaces
        IsTrue ("Green".In(   "Red",  "Green",  "Blue"                       ));
        IsTrue ("Green".In( [ "Red",  "Green",  "Blue" ]                     ));
        IsTrue ("Green".In( [ "Red",  "Green",  "Blue" ], spaceMatters: false));
        IsTrue ("Green".In( [ "Red",  "Green",  "Blue" ], spaceMatters: true ));
        IsTrue ("Green".In( [ "Red",  "Green",  "Blue" ], spaceMatters       ));
        IsTrue ("Green".In( spaceMatters,   "Red",  "Green",  "Blue"         ));
        IsTrue ("Green".In( spaceMatters, [ "Red",  "Green",  "Blue" ]       ));
        IsTrue (In("Green", [ "Red",  "Green",  "Blue" ]                     ));
        IsTrue (In("Green", [ "Red",  "Green",  "Blue" ], spaceMatters: false));
        IsTrue (In("Green", [ "Red",  "Green",  "Blue" ], spaceMatters: true ));
        IsTrue (In("Green", [ "Red",  "Green",  "Blue" ], spaceMatters       ));
        
        // Space in value
        IsTrue (" Green ".In(   "Red", "Green", "Blue"                       ));
        IsTrue (" Green ".In( [ "Red", "Green", "Blue" ]                     ));
        IsTrue (" Green ".In( [ "Red", "Green", "Blue" ], spaceMatters: false));
        IsFalse(" Green ".In( [ "Red", "Green", "Blue" ], spaceMatters: true ));
        IsFalse(" Green ".In( [ "Red", "Green", "Blue" ], spaceMatters       ));
        IsFalse(" Green ".In( spaceMatters,   "Red", "Green",   "Blue"       ));
        IsFalse(" Green ".In( spaceMatters, [ "Red", "Green",   "Blue" ]     ));
        IsTrue (In(" Green ", [ "Red", "Green", "Blue" ]                     ));
        IsTrue (In(" Green ", [ "Red", "Green", "Blue" ], spaceMatters: false));
        IsFalse(In(" Green ", [ "Red", "Green", "Blue" ], spaceMatters: true ));
        IsFalse(In(" Green ", [ "Red", "Green", "Blue" ], spaceMatters       ));

        // Space in collection
        IsTrue ("Green".In(   "Red", " Green ", "Blue"                       ));
        IsTrue ("Green".In( [ "Red", " Green ", "Blue" ]                     ));
        IsTrue ("Green".In( [ "Red", " Green ", "Blue" ], spaceMatters: false));
        IsFalse("Green".In( [ "Red", " Green ", "Blue" ], spaceMatters: true ));
        IsFalse("Green".In( [ "Red", " Green ", "Blue" ], spaceMatters       ));
        IsFalse("Green".In(spaceMatters,   "Red", " Green ", "Blue"          ));
        IsFalse("Green".In(spaceMatters, [ "Red", " Green ", "Blue" ]        ));
        IsTrue (In("Green", [ "Red", " Green ", "Blue" ]                     ));
        IsTrue (In("Green", [ "Red", " Green ", "Blue" ], spaceMatters: false));
        IsFalse(In("Green", [ "Red", " Green ", "Blue" ], spaceMatters: true ));
        IsFalse(In("Green", [ "Red", " Green ", "Blue" ], spaceMatters       ));
    }

    // No / No

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoNo_ExtensionSyntax_FlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], matchCase: false, spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], matchCase: false, spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], matchCase: false, spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], matchCase: false, spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], matchCase: false,               false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], matchCase: false,               false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], matchCase: false,               false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], matchCase: false,               false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], matchCase: false                     ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], matchCase: false                     ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], matchCase: false                     ));
        IsTrue ("b \t".In( [ "A", "B", "C" ], matchCase: false                     ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],            false, spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],            false, spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],            false, spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],            false, spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],            false,               false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],            false,               false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],            false,               false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],            false,               false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],            false                     ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],            false                     ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],            false                     ));
        IsTrue ("b \t".In( [ "A", "B", "C" ],            false                     ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                   spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],                   spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                   spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],                   spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                                 false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],                                 false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                                 false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],                                 false));
        IsTrue ("B"   .In( [ "A", "B", "C" ]                                       ));
        IsTrue ("B \t".In( [ "A", "B", "C" ]                                       ));
        IsTrue ("b"   .In( [ "A", "B", "C" ]                                       ));
        IsTrue ("b \t".In( [ "A", "B", "C" ]                                       ));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoNo_ExtensionSyntax_FlagsInFront()
    {
        IsTrue ("B"   .In(matchCase: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(matchCase: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(matchCase: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(matchCase: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(matchCase: false,               false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(matchCase: false,               false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(matchCase: false,               false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(matchCase: false,               false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(matchCase: false,                      [ "A", "B", "C" ]));
        IsTrue ("B \t".In(matchCase: false,                      [ "A", "B", "C" ]));
        IsTrue ("b"   .In(matchCase: false,                      [ "A", "B", "C" ]));
        IsTrue ("b \t".In(matchCase: false,                      [ "A", "B", "C" ]));
        IsTrue ("B"   .In(           false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(           false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(           false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(           false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(           false,               false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(           false,               false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(           false,               false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(           false,               false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(           false,                      [ "A", "B", "C" ]));
        IsTrue ("B \t".In(           false,                      [ "A", "B", "C" ]));
        IsTrue ("b"   .In(           false,                      [ "A", "B", "C" ]));
        IsTrue ("b \t".In(           false,                      [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                  spaceMatters: false, [ "A", "B", "C" ])); // Resolves ambiguously
      //IsTrue ("B \t".In(                  spaceMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                  spaceMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b \t".In(                  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                                false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(                                false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                                false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(                                false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                                       [ "A", "B", "C" ]));
        IsTrue ("B \t".In(                                       [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                                       [ "A", "B", "C" ]));
        IsTrue ("b \t".In(                                       [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoNo_ExtensionSyntax_FlagsInFront_Variadic()
    {
        IsTrue ("B"   .In(matchCase: false, spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("B \t".In(matchCase: false, spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("b"   .In(matchCase: false, spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("b \t".In(matchCase: false, spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("B"   .In(matchCase: false,               false,   "A", "B", "C"   ));
        IsTrue ("B \t".In(matchCase: false,               false,   "A", "B", "C"   ));
        IsTrue ("b"   .In(matchCase: false,               false,   "A", "B", "C"   ));
        IsTrue ("b \t".In(matchCase: false,               false,   "A", "B", "C"   ));
        IsTrue ("B"   .In(matchCase: false,                        "A", "B", "C"   ));
        IsTrue ("B \t".In(matchCase: false,                        "A", "B", "C"   ));
        IsTrue ("b"   .In(matchCase: false,                        "A", "B", "C"   ));
        IsTrue ("b \t".In(matchCase: false,                        "A", "B", "C"   ));
        IsTrue ("B"   .In(           false, spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("B \t".In(           false, spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("b"   .In(           false, spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("b \t".In(           false, spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("B"   .In(           false,               false,   "A", "B", "C"   ));
        IsTrue ("B \t".In(           false,               false,   "A", "B", "C"   ));
        IsTrue ("b"   .In(           false,               false,   "A", "B", "C"   ));
        IsTrue ("b \t".In(           false,               false,   "A", "B", "C"   ));
        IsTrue ("B"   .In(           false,                        "A", "B", "C"   ));
        IsTrue ("B \t".In(           false,                        "A", "B", "C"   ));
        IsTrue ("b"   .In(           false,                        "A", "B", "C"   ));
        IsTrue ("b \t".In(           false,                        "A", "B", "C"   ));
      //IsTrue ("B"   .In(                  spaceMatters: false,   "A", "B", "C"   )); // Resolves ambiguously
      //IsTrue ("B \t".In(                  spaceMatters: false,   "A", "B", "C"   ));
      //IsTrue ("b"   .In(                  spaceMatters: false,   "A", "B", "C"   ));
      //IsTrue ("b \t".In(                  spaceMatters: false,   "A", "B", "C"   ));
        IsTrue ("B"   .In(                                false,   "A", "B", "C"   ));
        IsTrue ("B \t".In(                                false,   "A", "B", "C"   ));
        IsTrue ("b"   .In(                                false,   "A", "B", "C"   ));
        IsTrue ("b \t".In(                                false,   "A", "B", "C"   ));
        IsTrue ("B"   .In(                                         "A", "B", "C"   ));
        IsTrue ("B \t".In(                                         "A", "B", "C"   ));
        IsTrue ("b"   .In(                                         "A", "B", "C"   ));
        IsTrue ("b \t".In(                                         "A", "B", "C"   ));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoNo_StaticSyntax_FlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ], matchCase: false, spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], matchCase: false, spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], matchCase: false, spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ], matchCase: false, spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], matchCase: false,               false));
        IsTrue (In("B \t", [ "A", "B", "C" ], matchCase: false,               false));
        IsTrue (In("b"   , [ "A", "B", "C" ], matchCase: false,               false));
        IsTrue (In("b \t", [ "A", "B", "C" ], matchCase: false,               false));
        IsTrue (In("B"   , [ "A", "B", "C" ], matchCase: false                     ));
        IsTrue (In("B \t", [ "A", "B", "C" ], matchCase: false                     ));
        IsTrue (In("b"   , [ "A", "B", "C" ], matchCase: false                     ));
        IsTrue (In("b \t", [ "A", "B", "C" ], matchCase: false                     ));
        IsTrue (In("B"   , [ "A", "B", "C" ],            false, spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],            false, spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],            false, spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],            false, spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ],            false,               false));
        IsTrue (In("B \t", [ "A", "B", "C" ],            false,               false));
        IsTrue (In("b"   , [ "A", "B", "C" ],            false,               false));
        IsTrue (In("b \t", [ "A", "B", "C" ],            false,               false));
        IsTrue (In("B"   , [ "A", "B", "C" ],            false                     ));
        IsTrue (In("B \t", [ "A", "B", "C" ],            false                     ));
        IsTrue (In("b"   , [ "A", "B", "C" ],            false                     ));
        IsTrue (In("b \t", [ "A", "B", "C" ],            false                     ));
        IsTrue (In("B"   , [ "A", "B", "C" ],                   spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],                   spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],                   spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],                   spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ],                                 false));
        IsTrue (In("B \t", [ "A", "B", "C" ],                                 false));
        IsTrue (In("b"   , [ "A", "B", "C" ],                                 false));
        IsTrue (In("b \t", [ "A", "B", "C" ],                                 false));
        IsTrue (In("B"   , [ "A", "B", "C" ]                                       ));
        IsTrue (In("B \t", [ "A", "B", "C" ]                                       ));
        IsTrue (In("b"   , [ "A", "B", "C" ]                                       ));
        IsTrue (In("b \t", [ "A", "B", "C" ]                                       ));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoNo_StaticSyntax_FlagsInFront()
    {
        IsTrue (In("B"   , matchCase: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", matchCase: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , matchCase: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", matchCase: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , matchCase: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", matchCase: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , matchCase: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", matchCase: false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , matchCase: false                     , [ "A", "B", "C" ]));
        IsTrue (In("B \t", matchCase: false                     , [ "A", "B", "C" ]));
        IsTrue (In("b"   , matchCase: false                     , [ "A", "B", "C" ]));
        IsTrue (In("b \t", matchCase: false                     , [ "A", "B", "C" ]));
        IsTrue (In("B"   ,            false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",            false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,            false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",            false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,            false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",            false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,            false,               false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",            false,               false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,            false                     , [ "A", "B", "C" ]));
        IsTrue (In("B \t",            false                     , [ "A", "B", "C" ]));
        IsTrue (In("b"   ,            false                     , [ "A", "B", "C" ]));
        IsTrue (In("b \t",            false                     , [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                   spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",                   spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                   spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",                   spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                                 false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",                                 false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                                 false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",                                 false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                                        [ "A", "B", "C" ]));
        IsTrue (In("B \t",                                        [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                                        [ "A", "B", "C" ]));
        IsTrue (In("b \t",                                        [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoNo_StaticSyntax_FlagsInFront_Variadic()
    {
        IsTrue (In("B"   , matchCase: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", matchCase: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   , matchCase: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b \t", matchCase: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , matchCase: false,               false,   "A", "B", "C"  ));
        IsTrue (In("B \t", matchCase: false,               false,   "A", "B", "C"  ));
        IsTrue (In("b"   , matchCase: false,               false,   "A", "B", "C"  ));
        IsTrue (In("b \t", matchCase: false,               false,   "A", "B", "C"  ));
        IsTrue (In("B"   , matchCase: false                     ,   "A", "B", "C"  ));
        IsTrue (In("B \t", matchCase: false                     ,   "A", "B", "C"  ));
        IsTrue (In("b"   , matchCase: false                     ,   "A", "B", "C"  ));
        IsTrue (In("b \t", matchCase: false                     ,   "A", "B", "C"  ));
        IsTrue (In("B"   ,            false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t",            false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   ,            false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b \t",            false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,            false,               false,   "A", "B", "C"  ));
        IsTrue (In("B \t",            false,               false,   "A", "B", "C"  ));
        IsTrue (In("b"   ,            false,               false,   "A", "B", "C"  ));
        IsTrue (In("b \t",            false,               false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,            false                     ,   "A", "B", "C"  ));
        IsTrue (In("B \t",            false                     ,   "A", "B", "C"  ));
        IsTrue (In("b"   ,            false                     ,   "A", "B", "C"  ));
        IsTrue (In("b \t",            false                     ,   "A", "B", "C"  ));
      //IsTrue (In("B"   ,                   spaceMatters: false,   "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue (In("B \t",                   spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("b"   ,                   spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("b \t",                   spaceMatters: false,   "A", "B", "C"  )); 
        IsTrue (In("B"   ,                                 false,   "A", "B", "C"  ));
        IsTrue (In("B \t",                                 false,   "A", "B", "C"  ));
        IsTrue (In("b"   ,                                 false,   "A", "B", "C"  ));
        IsTrue (In("b \t",                                 false,   "A", "B", "C"  ));
      //IsTrue (In("B"   ,                                          "A", "B", "C"  )); // Not supported. Too ambiguous.
      //IsTrue (In("B \t",                                          "A", "B", "C"  ));
      //IsTrue (In("b"   ,                                          "A", "B", "C"  ));
      //IsTrue (In("b \t",                                          "A", "B", "C"  ));
    }

    // No / Yes

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoYes_ExtensionSyntax_FlagsInBack()
    {
        IsTrue ("B"   .In( [ "A", "B", "C" ], matchCase: false, spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ], matchCase: false, spaceMatters      ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], matchCase: false, spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], matchCase: false, spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], matchCase: false, spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ], matchCase: false, spaceMatters: true));
        IsTrue ("b"   .In( [ "A", "B", "C" ], matchCase: false, spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ], matchCase: false, spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], matchCase: false,               true));
        IsFalse("B \t".In( [ "A", "B", "C" ], matchCase: false,               true));
        IsTrue ("b"   .In( [ "A", "B", "C" ], matchCase: false,               true));
        IsFalse("b \t".In( [ "A", "B", "C" ], matchCase: false,               true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],            false, spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],            false, spaceMatters      ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],            false, spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],            false, spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],            false, spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ],            false, spaceMatters: true));
        IsTrue ("b"   .In( [ "A", "B", "C" ],            false, spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ],            false, spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],            false,               true));
        IsFalse("B \t".In( [ "A", "B", "C" ],            false,               true));
        IsTrue ("b"   .In( [ "A", "B", "C" ],            false,               true));
        IsFalse("b \t".In( [ "A", "B", "C" ],            false,               true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                   spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],                   spaceMatters      ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                   spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],                   spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                   spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ],                   spaceMatters: true));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                   spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ],                   spaceMatters: true));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                                 true)); // Resolves to matchCase flag, not spaceMatters.
      //IsFalse("B \t".In( [ "A", "B", "C" ],                                 true));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],                                 true));
      //IsFalse("b \t".In( [ "A", "B", "C" ],                                 true));
    }
    
    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoYes_ExtensionSyntax_FlagsInFront()
    {
        IsTrue ("B"   .In(matchCase: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In(matchCase: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("b"   .In(matchCase: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In(matchCase: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(matchCase: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(matchCase: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(matchCase: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(matchCase: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(matchCase: false,               true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(matchCase: false,               true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(matchCase: false,               true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(matchCase: false,               true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(           false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In(           false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("b"   .In(           false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In(           false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(           false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(           false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(           false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(           false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(           false,               true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(           false,               true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(           false,               true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(           false,               true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In(                  spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In(                  spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(                  spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(                  spaceMatters: true, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                                true, [ "A", "B", "C" ])); // Resolves to matchCase flag, not spaceMatters.
      //IsFalse("B \t".In(                                true, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                                true, [ "A", "B", "C" ]));
      //IsFalse("b \t".In(                                true, [ "A", "B", "C" ]));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoYes_ExtensionSyntax_FlagsInFront_Variadic()
    {
        IsTrue ("B"   .In(matchCase: false, spaceMatters,       "A", "B", "C"));
        IsFalse("B \t".In(matchCase: false, spaceMatters,       "A", "B", "C"));
        IsTrue ("b"   .In(matchCase: false, spaceMatters,       "A", "B", "C"));
        IsFalse("b \t".In(matchCase: false, spaceMatters,       "A", "B", "C"));
        IsTrue ("B"   .In(matchCase: false, spaceMatters: true, "A", "B", "C"));
        IsFalse("B \t".In(matchCase: false, spaceMatters: true, "A", "B", "C"));
        IsTrue ("b"   .In(matchCase: false, spaceMatters: true, "A", "B", "C"));
        IsFalse("b \t".In(matchCase: false, spaceMatters: true, "A", "B", "C"));
        IsTrue ("B"   .In(matchCase: false,               true, "A", "B", "C"));
        IsFalse("B \t".In(matchCase: false,               true, "A", "B", "C"));
        IsTrue ("b"   .In(matchCase: false,               true, "A", "B", "C"));
        IsFalse("b \t".In(matchCase: false,               true, "A", "B", "C"));
        IsTrue ("B"   .In(           false, spaceMatters,       "A", "B", "C"));
        IsFalse("B \t".In(           false, spaceMatters,       "A", "B", "C"));
        IsTrue ("b"   .In(           false, spaceMatters,       "A", "B", "C"));
        IsFalse("b \t".In(           false, spaceMatters,       "A", "B", "C"));
        IsTrue ("B"   .In(           false, spaceMatters: true, "A", "B", "C"));
        IsFalse("B \t".In(           false, spaceMatters: true, "A", "B", "C"));
        IsTrue ("b"   .In(           false, spaceMatters: true, "A", "B", "C"));
        IsFalse("b \t".In(           false, spaceMatters: true, "A", "B", "C"));
        IsTrue ("B"   .In(           false,               true, "A", "B", "C"));
        IsFalse("B \t".In(           false,               true, "A", "B", "C"));
        IsTrue ("b"   .In(           false,               true, "A", "B", "C"));
        IsFalse("b \t".In(           false,               true, "A", "B", "C"));
        IsTrue ("B"   .In(                  spaceMatters,       "A", "B", "C"));
        IsFalse("B \t".In(                  spaceMatters,       "A", "B", "C"));
        IsTrue ("b"   .In(                  spaceMatters,       "A", "B", "C"));
        IsFalse("b \t".In(                  spaceMatters,       "A", "B", "C"));
      //IsTrue ("B"   .In(                  spaceMatters: true, "A", "B", "C")); // Resolves ambiguously
      //IsFalse("B \t".In(                  spaceMatters: true, "A", "B", "C"));
      //IsTrue ("b"   .In(                  spaceMatters: true, "A", "B", "C"));
      //IsFalse("b \t".In(                  spaceMatters: true, "A", "B", "C"));
      //IsTrue ("B"   .In(                                true, "A", "B", "C")); // Resolves to matchCase flag, not spaceMatters.
      //IsFalse("B \t".In(                                true, "A", "B", "C"));
      //IsTrue ("b"   .In(                                true, "A", "B", "C"));
      //IsFalse("b \t".In(                                true, "A", "B", "C"));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoYes_StaticSyntax_FlagsInBack()
    {
        IsTrue (In("B"   , [ "A", "B", "C" ], matchCase: false, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], matchCase: false, spaceMatters      ));
        IsTrue (In("b"   , [ "A", "B", "C" ], matchCase: false, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], matchCase: false, spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], matchCase: false, spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], matchCase: false, spaceMatters: true));
        IsTrue (In("b"   , [ "A", "B", "C" ], matchCase: false, spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], matchCase: false, spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], matchCase: false,               true));
        IsFalse(In("B \t", [ "A", "B", "C" ], matchCase: false,               true));
        IsTrue (In("b"   , [ "A", "B", "C" ], matchCase: false,               true));
        IsFalse(In("b \t", [ "A", "B", "C" ], matchCase: false,               true));
        IsTrue (In("B"   , [ "A", "B", "C" ],            false, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],            false, spaceMatters      ));
        IsTrue (In("b"   , [ "A", "B", "C" ],            false, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],            false, spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ],            false, spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ],            false, spaceMatters: true));
        IsTrue (In("b"   , [ "A", "B", "C" ],            false, spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ],            false, spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ],            false,               true));
        IsFalse(In("B \t", [ "A", "B", "C" ],            false,               true));
        IsTrue (In("b"   , [ "A", "B", "C" ],            false,               true));
        IsFalse(In("b \t", [ "A", "B", "C" ],            false,               true));
        IsTrue (In("B"   , [ "A", "B", "C" ],                   spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],                   spaceMatters      ));
        IsTrue (In("b"   , [ "A", "B", "C" ],                   spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],                   spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ],                   spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ],                   spaceMatters: true));
        IsTrue (In("b"   , [ "A", "B", "C" ],                   spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ],                   spaceMatters: true));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                 true)); // Resolves to matchCase flag, not spaceMatters.
      //IsFalse(In("B \t", [ "A", "B", "C" ],                                 true));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                                 true));
      //IsFalse(In("b \t", [ "A", "B", "C" ],                                 true));
    }

    // Yes / No

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_YesNo_ExtensionSyntax_FlagsInFront_Variadic()
    {
        IsTrue ("B"   .In(matchCase: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(matchCase: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(matchCase: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(matchCase: true,  spaceMatters: false,   "A", "B", "C"  ));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_YesNo_ExtensionSyntax_FlagsInBack()
    {
        IsTrue ("B"   .In([ "A", "B", "C" ], matchCase: true,  spaceMatters: false));
        IsTrue ("B \t".In([ "A", "B", "C" ], matchCase: true,  spaceMatters: false));
        IsFalse("b"   .In([ "A", "B", "C" ], matchCase: true,  spaceMatters: false));
        IsFalse("b \t".In([ "A", "B", "C" ], matchCase: true,  spaceMatters: false));
    }

    // Yes / Yes

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_YesYes()
    {
        IsTrue ("B"   .In(matchCase: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In(matchCase: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("B \t".In(matchCase: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In(matchCase: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b"   .In(matchCase: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b"   .In(matchCase: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse("b \t".In(matchCase: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In(matchCase: true,  spaceMatters: true,    "A", "B", "C"  ));

        // TODO: Extend with cases
    }

    [TestMethod]
    public void In_Strings_Nully()
    {
        string  a = "A";
        string  b = "B";

        // Nully in the middle

        IsTrue(a.In(     a, NullText,   b  ));
        IsTrue(a.In(   [ a, NullText,   b ]));
        IsTrue(  In(a, [ a, NullText,   b ]));
        IsTrue(b.In(     a, Empty,      b  ));
        IsTrue(b.In(   [ a, Empty,      b ]));
        IsTrue(  In(b, [ a, Empty,      b ]));
        IsTrue(a.In(     a, NullyEmpty, b  ));
        IsTrue(a.In(   [ a, NullyEmpty, b ]));
        IsTrue(  In(a, [ a, NullyEmpty, b ]));
        IsTrue(b.In(     a, Space,      b  ));
        IsTrue(b.In(   [ a, Space,      b ]));
        IsTrue(  In(b, [ a, Space,      b ]));
        IsTrue(a.In(     a, NullySpace, b  ));
        IsTrue(a.In(   [ a, NullySpace, b ]));
        IsTrue(  In(a, [ a, NullySpace, b ]));

        // Nully in the front

        IsTrue (NullText  .In(   a, b, NullText  ));
        IsTrue (Empty     .In(   a, b, NullText  ));
        IsTrue (Space     .In(   a, b, NullText  ));
        IsTrue (NullyEmpty.In(   a, b, NullText  ));
        IsTrue (NullySpace.In(   a, b, NullText  ));
        IsTrue (NullText  .In( [ a, b, NullText ]));
        IsTrue (Empty     .In( [ a, b, NullText ]));
        IsTrue (Space     .In( [ a, b, NullText ]));
        IsTrue (NullyEmpty.In( [ a, b, NullText ]));
        IsTrue (NullySpace.In( [ a, b, NullText ]));
        IsTrue (In(NullText,   [ a, b, NullText ]));
        IsTrue (In(Empty,      [ a, b, NullText ]));
        IsTrue (In(Space,      [ a, b, NullText ]));
        IsTrue (In(NullyEmpty, [ a, b, NullText ]));
        IsTrue (In(NullySpace, [ a, b, NullText ]));
        IsTrue (NullText  .In(   a, Empty, b  ));
        IsTrue (Empty     .In(   a, Empty, b  ));
        IsTrue (Space     .In(   a, Empty, b  ));
        IsTrue (NullyEmpty.In(   a, Empty, b  ));
        IsTrue (NullySpace.In(   a, Empty, b  ));
        IsTrue (NullText  .In( [ a, Empty, b ]));
        IsTrue (Empty     .In( [ a, Empty, b ]));
        IsTrue (Space     .In( [ a, Empty, b ]));
        IsTrue (NullyEmpty.In( [ a, Empty, b ]));
        IsTrue (NullySpace.In( [ a, Empty, b ]));
        IsTrue (In(NullText,   [ a, Empty, b ]));
        IsTrue (In(Empty,      [ a, Empty, b ]));
        IsTrue (In(Space,      [ a, Empty, b ]));
        IsTrue (In(NullyEmpty, [ a, Empty, b ]));
        IsTrue (In(NullySpace, [ a, Empty, b ]));
        IsTrue (NullText  .In(   a, NullyEmpty, b  ));
        IsTrue (Empty     .In(   a, NullyEmpty, b  ));
        IsTrue (Space     .In(   a, NullyEmpty, b  ));
        IsTrue (NullyEmpty.In(   a, NullyEmpty, b  ));
        IsTrue (NullySpace.In(   a, NullyEmpty, b  ));
        IsTrue (NullText  .In( [ a, NullyEmpty, b ]));
        IsTrue (Empty     .In( [ a, NullyEmpty, b ]));
        IsTrue (Space     .In( [ a, NullyEmpty, b ]));
        IsTrue (NullyEmpty.In( [ a, NullyEmpty, b ]));
        IsTrue (NullySpace.In( [ a, NullyEmpty, b ]));
        IsTrue (In(NullText,   [ a, NullyEmpty, b ]));
        IsTrue (In(Empty,      [ a, NullyEmpty, b ]));
        IsTrue (In(Space,      [ a, NullyEmpty, b ]));
        IsTrue (In(NullyEmpty, [ a, NullyEmpty, b ]));
        IsTrue (In(NullySpace, [ a, NullyEmpty, b ]));
        IsTrue (NullText  .In(   Space, a, b  ));
        IsTrue (Empty     .In(   Space, a, b  ));
        IsTrue (Space     .In(   Space, a, b  ));
        IsTrue (NullyEmpty.In(   Space, a, b  ));
        IsTrue (NullySpace.In(   Space, a, b  ));
        IsTrue (NullText  .In( [ Space, a, b ]));
        IsTrue (Empty     .In( [ Space, a, b ]));
        IsTrue (Space     .In( [ Space, a, b ]));
        IsTrue (NullyEmpty.In( [ Space, a, b ]));
        IsTrue (NullySpace.In( [ Space, a, b ]));
        IsTrue (In(NullText,   [ Space, a, b ]));
        IsTrue (In(Empty,      [ Space, a, b ]));
        IsTrue (In(Space,      [ Space, a, b ]));
        IsTrue (In(NullyEmpty, [ Space, a, b ]));
        IsTrue (In(NullySpace, [ Space, a, b ]));
        IsTrue (NullText  .In(   NullySpace, a, b  ));
        IsTrue (Empty     .In(   NullySpace, a, b  ));
        IsTrue (Space     .In(   NullySpace, a, b  ));
        IsTrue (NullyEmpty.In(   NullySpace, a, b  ));
        IsTrue (NullySpace.In(   NullySpace, a, b  ));
        IsTrue (NullText  .In( [ NullySpace, a, b ]));
        IsTrue (Empty     .In( [ NullySpace, a, b ]));
        IsTrue (Space     .In( [ NullySpace, a, b ]));
        IsTrue (NullyEmpty.In( [ NullySpace, a, b ]));
        IsTrue (NullySpace.In( [ NullySpace, a, b ]));
        IsTrue (In(NullText,   [ NullySpace, a, b ]));
        IsTrue (In(Empty,      [ NullySpace, a, b ]));
        IsTrue (In(Space,      [ NullySpace, a, b ]));
        IsTrue (In(NullyEmpty, [ NullySpace, a, b ]));
        IsTrue (In(NullySpace, [ NullySpace, a, b ]));
        
        // Negative matches
        IsFalse(NullText  .In(   a, b  ));
        IsFalse(Empty     .In(   a, b  ));
        IsFalse(NullyEmpty.In(   a, b  ));
        IsFalse(Space     .In(   a, b  ));
        IsFalse(NullySpace.In(   a, b  ));
        IsFalse(NullText  .In( [ a, b ]));
        IsFalse(Empty     .In( [ a, b ]));
        IsFalse(NullyEmpty.In( [ a, b ]));
        IsFalse(Space     .In( [ a, b ]));
        IsFalse(NullySpace.In( [ a, b ]));
        IsFalse(In(NullText,   [ a, b ]));
        IsFalse(In(Empty,      [ a, b ]));
        IsFalse(In(NullyEmpty, [ a, b ]));
        IsFalse(In(Space,      [ a, b ]));
        IsFalse(In(NullySpace, [ a, b ]));
    }

    [TestMethod]
    public void In_Objects()
    {
        StringBuilder a = new();
        StringBuilder b = new();
        StringBuilder c = new();
        StringBuilder d = new();
        
        IsTrue (a.In(     a, b, c  ));
        IsTrue (b.In(     a, b, c  ));
        IsTrue (a.In(   [ a, b, c ]));
        IsTrue (b.In(   [ a, b, c ]));
        IsTrue (  In(a, [ a, b, c ]));
        IsTrue (  In(b, [ a, b, c ]));

        IsFalse(d.In(     a, b, c  ));
        IsFalse(  In(d, [ a, b, c ]));
    }
        
    [TestMethod]
    public void In_Objects_Nully()
    {
        StringBuilder a = new();
        StringBuilder b = new();
        object? _null = null;

        IsTrue (a    .In(a, b, _null));
        IsTrue (b    .In(a, b, _null));
        IsTrue (_null.In(a, b, _null));
        IsFalse(_null.In(a, b       ));
    }

    [TestMethod]
    public void In_Structs()
    {
        IsTrue (1.In(     1, 2, 3  ));
        IsTrue (2.In(     1, 2, 3  ));
        IsTrue (1.In(   [ 1, 2, 3 ]));
        IsTrue (2.In(   [ 1, 2, 3 ]));
        IsTrue (  In(1, [ 1, 2, 3 ]));
        IsTrue (  In(2, [ 1, 2, 3 ]));

        IsFalse(4.In(     1, 2, 3  ));
        IsFalse(4.In(   [ 1, 2, 3 ]));
        IsFalse(  In(4, [ 1, 2, 3 ]));
    }

    [TestMethod]
    public void In_Struct_Nully()
    {
        int?[]? nullColl = null;
        int?[] emptyColl = [ ];
        
        IsTrue (      1.In(        1,      2,      3, NullNum  ));
        IsTrue (      2.In(        1,      2,      3, NullNum  ));
        IsTrue (      3.In(        1,      2,      3, NullNum  ));
        IsTrue ( Nully1.In(        1,      2,      3           ));
        IsTrue ( Nully2.In(        1,      2,      3           ));
        IsTrue ( Nully3.In(        1,      2,      3           ));
        IsTrue ( Nully1.In(        1,      2, Nully3           ));
        IsTrue ( Nully2.In(        1,      2, Nully3           ));
        IsTrue ( Nully3.In(        1,      2, Nully3           ));
        IsTrue (      1.In(        1,      2, Nully3           ));
        IsTrue (      2.In(        1,      2, Nully3           ));
        IsTrue (      3.In(        1,      2, Nully3           ));
        IsTrue (      1.In(   Nully1, Nully2, Nully3           ));
        IsTrue (      2.In(   Nully1, Nully2, Nully3           ));
        IsTrue (      3.In(   Nully1, Nully2, Nully3           ));
        IsTrue ( Nully1.In(   Nully1, Nully2, Nully3           ));
        IsTrue ( Nully2.In(   Nully1, Nully2, Nully3           ));
        IsTrue ( Nully3.In(   Nully1, Nully2, Nully3           ));
        IsTrue (NullNum.In(        1,      2,      3, NullNum  ));
        IsTrue (NullNum.In(        1,      2, Nully3, NullNum  ));
        IsTrue (NullNum.In(   Nully1, Nully2, Nully3, NullNum  ));
        IsTrue (In(      1, [      1,      2,      3, NullNum ]));
        IsTrue (In(      2, [      1,      2,      3, NullNum ]));
        IsTrue (In(      3, [      1,      2,      3, NullNum ]));
        IsTrue (In( Nully1, [      1,      2,      3          ]));
        IsTrue (In( Nully2, [      1,      2,      3          ]));
        IsTrue (In( Nully3, [      1,      2,      3          ]));
        IsTrue (In( Nully1, [      1,      2, Nully3          ]));
        IsTrue (In( Nully2, [      1,      2, Nully3          ]));
        IsTrue (In( Nully3, [      1,      2, Nully3          ]));
        IsTrue (In(      1, [      1,      2, Nully3          ]));
        IsTrue (In(      2, [      1,      2, Nully3          ]));
        IsTrue (In(      3, [      1,      2, Nully3          ]));
        IsTrue (In(      1, [ Nully1, Nully2, Nully3          ]));
        IsTrue (In(      2, [ Nully1, Nully2, Nully3          ]));
        IsTrue (In(      3, [ Nully1, Nully2, Nully3          ]));
        IsTrue (In( Nully1, [ Nully1, Nully2, Nully3          ]));
        IsTrue (In( Nully2, [ Nully1, Nully2, Nully3          ]));
        IsTrue (In( Nully3, [ Nully1, Nully2, Nully3          ]));
        IsTrue (In(NullNum, [      1,      2,      3, NullNum ]));
        IsTrue (In(NullNum, [      1,      2, Nully3, NullNum ]));
        IsTrue (In(NullNum, [ Nully1, Nully2, Nully3, NullNum ]));
        
        // Negative matches
        IsFalse(      4.In(        1,      2,      3, NullNum  ));
        IsFalse(      4.In(        1,      2, Nully3           ));
        IsFalse(      4.In(   Nully1, Nully2, Nully3           ));
        IsFalse( Nully4.In(        1,      2,      3           ));
        IsFalse( Nully4.In(        1,      2, Nully3           ));
        IsFalse( Nully4.In(   Nully1, Nully2, Nully3           ));
        IsFalse(NullNum.In(        1,      2,      3           ));
        IsFalse(NullNum.In(        1,      2, Nully3           ));
        IsFalse(NullNum.In(   Nully1, Nully2, Nully3           ));
        IsFalse(In(     4,  [      1,      2,      3, NullNum ]));
        IsFalse(In(Nully4,  [      1,      2,      3          ]));
        IsFalse(In(Nully4,  [      1,      2, Nully3          ]));
        IsFalse(In(     4,  [      1,      2, Nully3          ]));
        IsFalse(In(     4,  [ Nully1, Nully2, Nully3          ]));
        IsFalse(In(Nully4,  [ Nully1, Nully2, Nully3          ]));
        IsFalse(In(NullNum, [      1,      2,      3          ]));
        IsFalse(In(NullNum, [      1,      2, Nully3          ]));
        IsFalse(In(NullNum, [ Nully1, Nully2, Nully3          ]));
        
        // Staring into the abyss
        IsFalse(   Nully1.In(nullColl ));
        IsFalse(        1.In(NullNum  ));
        IsFalse(        1.In(nullColl ));
        IsFalse(In(Nully1,   nullColl ));
        IsFalse(In(     1, [ NullNum ]));
        IsFalse(In(     1,   nullColl ));
        
        // Very much null and empty
        IsTrue (   NullNum.In(NullNum  ));
        IsTrue (In(NullNum, [ NullNum ]));
        IsFalse(   NullNum.In(emptyColl));
        IsFalse(In(NullNum,   emptyColl));
        IsFalse(   NullNum.In(nullColl ));
        IsFalse(In(NullNum,   nullColl ));
}
}