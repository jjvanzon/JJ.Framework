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
        IsTrue ("GREEN".In( caseMatters: false,   "Red", "Green", "Blue"  ));
        IsTrue ("GREEN".In( caseMatters: false, [ "Red", "Green", "Blue" ]));
        IsTrue (In("GREEN", [ "Red", "Green", "Blue" ], caseMatters: false));
        IsTrue ("GREEN".In( [ "Red", "Green", "Blue" ], caseMatters: false));
        
        // Match case
        IsFalse("GREEN".In( caseMatters,         "Red", "Green", "Blue"   ));
        IsFalse("GREEN".In( caseMatters: true,   "Red", "Green", "Blue"   ));
        IsFalse("GREEN".In( caseMatters,       [ "Red", "Green", "Blue" ] ));
        IsFalse("GREEN".In( caseMatters: true, [ "Red", "Green", "Blue" ] ));
        IsFalse(In("GREEN", [ "Red", "Green", "Blue" ], caseMatters       ));
        IsFalse(In("GREEN", [ "Red", "Green", "Blue" ], caseMatters: true ));
        IsFalse("GREEN".In( [ "Red", "Green", "Blue" ], caseMatters       ));
        IsFalse("GREEN".In( [ "Red", "Green", "Blue" ], caseMatters: true ));
        IsTrue ("Green" .In(caseMatters,          "Red", "Green", "Blue"  ));
        IsTrue ("Green" .In(caseMatters: true,    "Red", "Green", "Blue"  ));
        IsTrue ("Green" .In(caseMatters,        [ "Red", "Green", "Blue" ]));
        IsTrue ("Green" .In(caseMatters: true,  [ "Red", "Green", "Blue" ]));
        IsTrue (In("Green", [ "Red", "Green", "Blue" ], caseMatters       ));
        IsTrue (In("Green", [ "Red", "Green", "Blue" ], caseMatters: true ));
        IsTrue ("Green" .In([ "Red", "Green", "Blue" ], caseMatters       ));
        IsTrue ("Green" .In([ "Red", "Green", "Blue" ], caseMatters: true ));
        
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
    public void In_String_CaseMattersSpaceMatters_NoNo_FlagsInBack()
    {
        // Extension Syntax
        IsTrue ("B"   .In( [ "A", "B", "C" ]                                         ));
        IsTrue ("B \t".In( [ "A", "B", "C" ]                                         ));
        IsTrue ("b"   .In( [ "A", "B", "C" ]                                         ));
        IsTrue ("b \t".In( [ "A", "B", "C" ]                                         ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue ("b \t".In( [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false                     ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              false                     ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false                     ));
        IsTrue ("b \t".In( [ "A", "B", "C" ],              false                     ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              false,               false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              false,               false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],              false,               false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],              false,               false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ],                     spaceMatters: false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],                                   false)); // Resolves to caseMatters not spaceMatters.
      //IsTrue ("B \t".In( [ "A", "B", "C" ],                                   false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],                                   false));
      //IsTrue ("b \t".In( [ "A", "B", "C" ],                                   false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: false)); // Switch Flags
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue ("b \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false,              false)); // Resolves ambiguously
      //IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue ("b \t".In( [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue ("B \t".In( [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue ("b \t".In( [ "A", "B", "C" ],               false, caseMatters: false));

        // Static Syntax
        IsTrue (In("B"   , [ "A", "B", "C" ]                                         ));
        IsTrue (In("B \t", [ "A", "B", "C" ]                                         ));
        IsTrue (In("b"   , [ "A", "B", "C" ]                                         ));
        IsTrue (In("b \t", [ "A", "B", "C" ]                                         ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false                     ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("b \t", [ "A", "B", "C" ], caseMatters: false,               false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false                     ));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false                     ));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false                     ));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false                     ));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false, spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              false,               false));
        IsTrue (In("B \t", [ "A", "B", "C" ],              false,               false));
        IsTrue (In("b"   , [ "A", "B", "C" ],              false,               false));
        IsTrue (In("b \t", [ "A", "B", "C" ],              false,               false));
        IsTrue (In("B"   , [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ],                     spaceMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ],                     spaceMatters: false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                   false)); // Resolves to caseMatters not spaceMatters.
      //IsTrue (In("B \t", [ "A", "B", "C" ],                                   false)); 
      //IsTrue (In("b"   , [ "A", "B", "C" ],                                   false)); 
      //IsTrue (In("b \t", [ "A", "B", "C" ],                                   false)); 
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters: false)); // Switch Flags
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
        IsTrue (In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters: false));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false,              false)); // Resolves ambiguously
      //IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue (In("b \t", [ "A", "B", "C" ], spaceMatters: false,              false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],               false, caseMatters: false));
      //IsTrue (In("b \t", [ "A", "B", "C" ],               false, caseMatters: false));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoNo_FlagsInFront()
    {
        // Extension Syntax
        IsTrue ("B"   .In(                                          [ "A", "B", "C" ]));
        IsTrue ("B \t".In(                                          [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                                          [ "A", "B", "C" ]));
        IsTrue ("b \t".In(                                          [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue ("B \t".In( caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue ("b \t".In( caseMatters: false,                      [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In( caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In( caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In( caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In( caseMatters: false,               false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(              false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false,                      [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false,                      [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false,                      [ "A", "B", "C" ]));
        IsTrue ("b \t".In(              false,                      [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false,               false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false,               false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(              false,               false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(              false,               false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b \t".In(                     spaceMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(                                   false, [ "A", "B", "C" ])); // Resolves to caseMatters not spaceMatters.
      //IsTrue ("B \t".In(                                   false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                                   false, [ "A", "B", "C" ]));
      //IsTrue ("b \t".In(                                   false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: false, caseMatters: false, [ "A", "B", "C" ])); // Switch Flags // Resolves ambiguously
      //IsTrue ("B \t".In( spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In( spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b \t".In( spaceMatters: false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue ("B \t".In( spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In( spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue ("b \t".In( spaceMatters: false,              false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(               false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("B \t".In(               false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(               false, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b \t".In(               false, caseMatters: false, [ "A", "B", "C" ]));

        // Extension Syntax (Variadic)
        IsTrue ("B"   .In(                                            "A", "B", "C"  ));
        IsTrue ("B \t".In(                                            "A", "B", "C"  ));
        IsTrue ("b"   .In(                                            "A", "B", "C"  ));
        IsTrue ("b \t".In(                                            "A", "B", "C"  ));
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
        IsTrue ("B"   .In(              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("b"   .In(              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("b \t".In(              false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              false,               false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(              false,               false,   "A", "B", "C"  ));
        IsTrue ("b"   .In(              false,               false,   "A", "B", "C"  ));
        IsTrue ("b \t".In(              false,               false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              false,                        "A", "B", "C"  ));
        IsTrue ("B \t".In(              false,                        "A", "B", "C"  ));
        IsTrue ("b"   .In(              false,                        "A", "B", "C"  ));
        IsTrue ("b \t".In(              false,                        "A", "B", "C"  ));
      //IsTrue ("B"   .In(                     spaceMatters: false,   "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue ("B \t".In(                     spaceMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                     spaceMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(                     spaceMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(                                   false,   "A", "B", "C"  )); // Resolves to caseMatters not spaceMatters.
      //IsTrue ("B \t".In(                                   false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                                   false,   "A", "B", "C"  ));
      //IsTrue ("b \t".In(                                   false,   "A", "B", "C"  ));
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

        // Static Syntax
        IsTrue (In("B"   ,                                          [ "A", "B", "C" ]));
        IsTrue (In("B \t",                                          [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                                          [ "A", "B", "C" ]));
        IsTrue (In("b \t",                                          [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false                     , [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: false                     , [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false                     , [ "A", "B", "C" ]));
        IsTrue (In("b \t", caseMatters: false                     , [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t", caseMatters: false, spaceMatters: false, [ "A", "B", "C" ]));
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
        IsTrue (In("B"   ,                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                     spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b \t",                     spaceMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,                                   false, [ "A", "B", "C" ])); // Resolves to caseMatters not spaceMatters.
      //IsTrue (In("B \t",                                   false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,                                   false, [ "A", "B", "C" ]));
      //IsTrue (In("b \t",                                   false, [ "A", "B", "C" ]));
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

        // Static Syntax (Variadic)
      //IsTrue (In("B"   ,                                            "A", "B", "C"  )); // Not supported. Too ambiguous.
      //IsTrue (In("B \t",                                            "A", "B", "C"  ));
      //IsTrue (In("b"   ,                                            "A", "B", "C"  ));
      //IsTrue (In("b \t",                                            "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("b \t", caseMatters: false,                        "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b \t", caseMatters: false, spaceMatters: false,   "A", "B", "C"  ));
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
      //IsTrue (In("B"   ,                     spaceMatters: false,   "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue (In("B \t",                     spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("b"   ,                     spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("b \t",                     spaceMatters: false,   "A", "B", "C"  )); 
      //IsTrue (In("B"   ,                                   false,   "A", "B", "C"  )); // Resolves to caseMatters not spaceMatters.
      //IsTrue (In("B \t",                                   false,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,                                   false,   "A", "B", "C"  ));
      //IsTrue (In("b \t",                                   false,   "A", "B", "C"  ));
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

    // No / Yes

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoYes_FlagsInBack()
    {
        // Extension Syntax
        IsTrue ("B"   .In( [ "A", "B", "C" ],                     spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],                     spaceMatters      ));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                     spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],                     spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                     spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ],                     spaceMatters: true));
        IsTrue ("b"   .In( [ "A", "B", "C" ],                     spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ],                     spaceMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsTrue ("b"   .In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
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
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters: false)); // Switch Flags
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,                    false));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,                    false));
        IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters,                    false));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,                    false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,              false)); // Resolves ambiguously 
      //IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,              false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ], spaceMatters: true,              false));
      //IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,              false));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               true, caseMatters: false));
      //IsFalse("B \t".In( [ "A", "B", "C" ],               true, caseMatters: false));
      //IsTrue ("b"   .In( [ "A", "B", "C" ],               true, caseMatters: false));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               true, caseMatters: false));

        // Static Syntax
        IsTrue (In("B"   , [ "A", "B", "C" ],                     spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],                     spaceMatters      ));
        IsTrue (In("b"   , [ "A", "B", "C" ],                     spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],                     spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ],                     spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ],                     spaceMatters: true));
        IsTrue (In("b"   , [ "A", "B", "C" ],                     spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ],                     spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsTrue (In("b"   , [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: false, spaceMatters: true));
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
      //IsTrue (In("B"   , [ "A", "B", "C" ],                                   true)); // Resolves to caseMatters not spaceMatters.
      //IsFalse(In("B \t", [ "A", "B", "C" ],                                   true));
      //IsTrue (In("b"   , [ "A", "B", "C" ],                                   true));
      //IsFalse(In("b \t", [ "A", "B", "C" ],                                   true));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters                          )); // Switch Flags
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters                          ));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters                          ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters                          ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,       caseMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,                    false));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,                    false));
        IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters,                    false));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,                    false));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,              false)); // Resolves ambiguously
      //IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,              false));
      //IsTrue (In("b"   , [ "A", "B", "C" ], spaceMatters: true,              false));
      //IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,              false));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               true, caseMatters: false));
      //IsFalse(In("B \t", [ "A", "B", "C" ],               true, caseMatters: false));
      //IsTrue (In("b"   , [ "A", "B", "C" ],               true, caseMatters: false));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               true, caseMatters: false));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_NoYes_FlagsInFront()
    {
        // Extension Syntax
        IsTrue ("B"   .In(                     spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In(                     spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                     spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In(                     spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                     spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In(                     spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In(                     spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In(                     spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
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
      //IsTrue ("B"   .In(                                   true, [ "A", "B", "C" ])); // Resolves to caseMatters not spaceMatters.
      //IsFalse("B \t".In(                                   true, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(                                   true, [ "A", "B", "C" ]));
      //IsFalse("b \t".In(                                   true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,                           [ "A", "B", "C" ])); // Switch Flags
        IsFalse("B \t".In( spaceMatters,                           [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters,                           [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,                           [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,                    false, [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,                    false, [ "A", "B", "C" ]));
        IsTrue ("b"   .In( spaceMatters,                    false, [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,                    false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: true, caseMatters: false, [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In( spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
      //IsFalse("b \t".In( spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: true,              false, [ "A", "B", "C" ]));
      //IsFalse("B \t".In( spaceMatters: true,              false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In( spaceMatters: true,              false, [ "A", "B", "C" ]));
      //IsFalse("b \t".In( spaceMatters: true,              false, [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(               true, caseMatters: false, [ "A", "B", "C" ]));
      //IsFalse("B \t".In(               true, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue ("b"   .In(               true, caseMatters: false, [ "A", "B", "C" ]));
      //IsFalse("b \t".In(               true, caseMatters: false, [ "A", "B", "C" ]));

        // Extension Syntax (Variadic)
        IsTrue ("B"   .In(                     spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In(                     spaceMatters,         "A", "B", "C"  ));
        IsTrue ("b"   .In(                     spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In(                     spaceMatters,         "A", "B", "C"  ));
      //IsTrue ("B"   .In(                     spaceMatters: true,   "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse("B \t".In(                     spaceMatters: true,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                     spaceMatters: true,   "A", "B", "C"  ));
      //IsFalse("b \t".In(                     spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("b"   .In( caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
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
      //IsTrue ("B"   .In(                                   true,   "A", "B", "C"  )); // Resolves to caseMatters not spaceMatters.
      //IsFalse("B \t".In(                                   true,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(                                   true,   "A", "B", "C"  ));
      //IsFalse("b \t".In(                                   true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,                             "A", "B", "C"  )); // Switch Flags
        IsFalse("B \t".In( spaceMatters,                             "A", "B", "C"  ));
        IsTrue ("b"   .In( spaceMatters,                             "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,                             "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsTrue ("b"   .In( spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true, caseMatters: false,   "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,                    false,   "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,                    false,   "A", "B", "C"  ));
        IsTrue ("b"   .In( spaceMatters,                    false,   "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,                    false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,              false,   "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In( spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse("B \t".In(               true, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue ("b"   .In(               true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse("b \t".In(               true, caseMatters: false,   "A", "B", "C"  ));
      
        // Static Syntax
        IsTrue (In("B"   ,                     spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("B \t",                     spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                     spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("b \t",                     spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                     spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("B \t",                     spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("b"   ,                     spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("b \t",                     spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: false, spaceMatters,       [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: false, spaceMatters: true, [ "A", "B", "C" ]));
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
      //IsTrue (In("B"   ,                                   true, [ "A", "B", "C" ])); // Resolves to caseMatters not spaceMatters.
      //IsFalse(In("B \t",                                   true, [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,                                   true, [ "A", "B", "C" ]));
      //IsFalse(In("b \t",                                   true, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,                           [ "A", "B", "C" ])); // Switch Flags
        IsFalse(In("B \t", spaceMatters,                           [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters,                           [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,                           [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,       caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: true, caseMatters: false, [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   , spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: true, caseMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,                    false, [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,                    false, [ "A", "B", "C" ]));
        IsTrue (In("b"   , spaceMatters,                    false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,                    false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: true,              false, [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true,              false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   , spaceMatters: true,              false, [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: true,              false, [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               true, caseMatters: false, [ "A", "B", "C" ]));
      //IsFalse(In("B \t",               true, caseMatters: false, [ "A", "B", "C" ]));
      //IsTrue (In("b"   ,               true, caseMatters: false, [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               true, caseMatters: false, [ "A", "B", "C" ]));

        // Static Syntax (Variadic)
        IsTrue (In("B"   ,                     spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("B \t",                     spaceMatters,         "A", "B", "C"  ));
        IsTrue (In("b"   ,                     spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("b \t",                     spaceMatters,         "A", "B", "C"  ));
      //IsTrue (In("B"   ,                     spaceMatters: true,   "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse(In("B \t",                     spaceMatters: true,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,                     spaceMatters: true,   "A", "B", "C"  ));
      //IsFalse(In("b \t",                     spaceMatters: true,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: false, spaceMatters,         "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsTrue (In("b"   , caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: false, spaceMatters: true,   "A", "B", "C"  ));
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
      //IsTrue (In("B"   ,                                   true,   "A", "B", "C"  )); // Resolves to caseMatters not spaceMatters.
      //IsFalse(In("B \t",                                   true,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,                                   true,   "A", "B", "C"  ));
      //IsFalse(In("b \t",                                   true,   "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,                             "A", "B", "C"  )); // Switch Flags
        IsFalse(In("B \t", spaceMatters,                             "A", "B", "C"  ));
        IsTrue (In("b"   , spaceMatters,                             "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,                             "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsTrue (In("b"   , spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,       caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true, caseMatters: false,   "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true, caseMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,                    false,   "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,                    false,   "A", "B", "C"  ));
        IsTrue (In("b"   , spaceMatters,                    false,   "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,                    false,   "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,              false,   "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsTrue (In("b"   , spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,              false,   "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse(In("B \t",               true, caseMatters: false,   "A", "B", "C"  ));
      //IsTrue (In("b"   ,               true, caseMatters: false,   "A", "B", "C"  ));
      //IsFalse(In("b \t",               true, caseMatters: false,   "A", "B", "C"  ));
    }

    // Yes / No

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_YesNo_ExtensionSyntax_FlagsInBack()
    {
        // Extension Syntax
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters                            ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters                            ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters                            ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters                            ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: true                      ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: true                      ));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters: true                      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: true                      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,        spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters,        spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,        spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,        spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: true,  spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: true,  spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters: true,  spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: true,  spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters,                      false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters,                      false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters,                      false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters,                      false));
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: true,                false));
        IsTrue ("B \t".In( [ "A", "B", "C" ], caseMatters: true,                false));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters: true,                false));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: true,                false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              true,  spaceMatters: false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              true,  spaceMatters: false));
        IsFalse("b"   .In( [ "A", "B", "C" ],              true,  spaceMatters: false));
        IsFalse("b \t".In( [ "A", "B", "C" ],              true,  spaceMatters: false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              true,                false));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              true,                false));
        IsFalse("b"   .In( [ "A", "B", "C" ],              true,                false));
        IsFalse("b \t".In( [ "A", "B", "C" ],              true,                false));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              true                      ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],              true                      ));
        IsFalse("b"   .In( [ "A", "B", "C" ],              true                      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],              true                      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],                      caseMatters       )); // Switch Flags
        IsTrue ("B \t".In( [ "A", "B", "C" ],                      caseMatters       ));
        IsFalse("b"   .In( [ "A", "B", "C" ],                      caseMatters       ));
        IsFalse("b \t".In( [ "A", "B", "C" ],                      caseMatters       ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters       )); 
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters       ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters       ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters       ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: true ));
        IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: true ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: true ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false, caseMatters: true ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: false,              true ));// Resolves ambiguously
      //IsTrue ("B \t".In( [ "A", "B", "C" ], spaceMatters: false,              true ));
      //IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: false,              true ));
      //IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: false,              true ));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               false, caseMatters       ));
        IsTrue ("B \t".In( [ "A", "B", "C" ],               false, caseMatters       ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               false, caseMatters       ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               false, caseMatters       ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               false, caseMatters: true )); // Resolves ambiguously
      //IsTrue ("B \t".In( [ "A", "B", "C" ],               false, caseMatters: true ));
      //IsFalse("b"   .In( [ "A", "B", "C" ],               false, caseMatters: true ));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               false, caseMatters: true ));

        // Static Syntax
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters                            ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters                            ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters                            ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters                            ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true                      ));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: true                      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true                      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true                      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,        spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters,        spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,        spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,        spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true,  spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: true,  spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true,  spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true,  spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,                      false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters,                      false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,                      false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,                      false));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true,                false));
        IsTrue (In("B \t", [ "A", "B", "C" ], caseMatters: true,                false));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true,                false));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true,                false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              true,  spaceMatters: false));
        IsTrue (In("B \t", [ "A", "B", "C" ],              true,  spaceMatters: false));
        IsFalse(In("b"   , [ "A", "B", "C" ],              true,  spaceMatters: false));
        IsFalse(In("b \t", [ "A", "B", "C" ],              true,  spaceMatters: false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              true,                false));
        IsTrue (In("B \t", [ "A", "B", "C" ],              true,                false));
        IsFalse(In("b"   , [ "A", "B", "C" ],              true,                false));
        IsFalse(In("b \t", [ "A", "B", "C" ],              true,                false));
        IsTrue (In("B"   , [ "A", "B", "C" ],              true                      ));
        IsTrue (In("B \t", [ "A", "B", "C" ],              true                      ));
        IsFalse(In("b"   , [ "A", "B", "C" ],              true                      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],              true                      ));
        IsTrue (In("B"   , [ "A", "B", "C" ],                      caseMatters       )); // Switch Flags
        IsTrue (In("B \t", [ "A", "B", "C" ],                      caseMatters       ));
        IsFalse(In("b"   , [ "A", "B", "C" ],                      caseMatters       ));
        IsFalse(In("b \t", [ "A", "B", "C" ],                      caseMatters       ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters       ));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters       ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters       ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters       ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters: true ));
        IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters: true ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false, caseMatters: true ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false, caseMatters: true ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters       ));
        IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters       ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               false, caseMatters       ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               false, caseMatters       ));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               false, caseMatters: true )); // Resolves ambiguously
      //IsTrue (In("B \t", [ "A", "B", "C" ],               false, caseMatters: true ));
      //IsFalse(In("b"   , [ "A", "B", "C" ],               false, caseMatters: true ));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               false, caseMatters: true ));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: false,              true ));
      //IsTrue (In("B \t", [ "A", "B", "C" ], spaceMatters: false,              true ));
      //IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: false,              true ));
      //IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: false,              true ));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_YesNo_ExtensionSyntax_FlagsInFront()
    {
        // Extension Syntax
        IsTrue ("B"   .In(caseMatters,                             [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,                             [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,                             [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,                             [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters: true,                       [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters: true,                       [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters: true,                       [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters: true,                       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters,        spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,        spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,        spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,        spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters: true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters: true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters: true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters: true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters,                      false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters,                      false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters,                      false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters,                      false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(caseMatters: true,                false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(caseMatters: true,                false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(caseMatters: true,                false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(caseMatters: true,                false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(             true,                       [ "A", "B", "C" ]));
        IsTrue ("B \t".In(             true,                       [ "A", "B", "C" ]));
        IsFalse("b"   .In(             true,                       [ "A", "B", "C" ]));
        IsFalse("b \t".In(             true,                       [ "A", "B", "C" ]));
        IsTrue ("B"   .In(             true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(             true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(             true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(             true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(             true,                false, [ "A", "B", "C" ]));
        IsTrue ("B \t".In(             true,                false, [ "A", "B", "C" ]));
        IsFalse("b"   .In(             true,                false, [ "A", "B", "C" ]));
        IsFalse("b \t".In(             true,                false, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(                     caseMatters,        [ "A", "B", "C" ])); // Switch Flags 
        IsTrue ("B \t".In(                     caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b"   .In(                     caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In(                     caseMatters,        [ "A", "B", "C" ]));
        IsTrue ("B"   .In(spaceMatters: false, caseMatters,        [ "A", "B", "C" ]));
        IsTrue ("B \t".In(spaceMatters: false, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b"   .In(spaceMatters: false, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In(spaceMatters: false, caseMatters,        [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(spaceMatters: false, caseMatters: true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsTrue ("B \t".In(spaceMatters: false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In(spaceMatters: false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(spaceMatters: false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(spaceMatters: false,              true,  [ "A", "B", "C" ]));
      //IsTrue ("B \t".In(spaceMatters: false,              true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In(spaceMatters: false,              true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(spaceMatters: false,              true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              false, caseMatters,        [ "A", "B", "C" ]));
        IsTrue ("B \t".In(              false, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b"   .In(              false, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In(              false, caseMatters,        [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(              false, caseMatters: true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsTrue ("B \t".In(              false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In(              false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(              false, caseMatters: true,  [ "A", "B", "C" ]));
        
        // Extension Syntax (Variadic)
        IsTrue ("B"   .In(caseMatters,                               "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,                               "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,                               "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,                               "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters: true,                         "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters: true,                         "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters: true,                         "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters: true,                         "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters,        spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,        spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,        spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,        spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters,                      false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters,                      false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters,                      false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters,                      false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(caseMatters: true,                false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(caseMatters: true,                false,   "A", "B", "C"  ));
        IsFalse("b"   .In(caseMatters: true,                false,   "A", "B", "C"  ));
        IsFalse("b \t".In(caseMatters: true,                false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(             true,                         "A", "B", "C"  ));
        IsTrue ("B \t".In(             true,                         "A", "B", "C"  ));
        IsFalse("b"   .In(             true,                         "A", "B", "C"  ));
        IsFalse("b \t".In(             true,                         "A", "B", "C"  ));
        IsTrue ("B"   .In(             true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(             true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b"   .In(             true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse("b \t".In(             true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(             true,                false,   "A", "B", "C"  ));
        IsTrue ("B \t".In(             true,                false,   "A", "B", "C"  ));
        IsFalse("b"   .In(             true,                false,   "A", "B", "C"  ));
        IsFalse("b \t".In(             true,                false,   "A", "B", "C"  ));
        IsTrue ("B"   .In(                      caseMatters,         "A", "B", "C"  )); // Switch Flags
        IsTrue ("B \t".In(                      caseMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In(                      caseMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In(                      caseMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters: false, caseMatters,         "A", "B", "C"  ));
        IsTrue ("B \t".In( spaceMatters: false, caseMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters: false, caseMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters: false, caseMatters,         "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: false, caseMatters: true,   "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue ("B \t".In( spaceMatters: false, caseMatters: true,   "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: false, caseMatters: true,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: false, caseMatters: true,   "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: false,              true,   "A", "B", "C"  ));
      //IsTrue ("B \t".In( spaceMatters: false,              true,   "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: false,              true,   "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: false,              true,   "A", "B", "C"  ));
        IsTrue ("B"   .In(               false, caseMatters,         "A", "B", "C"  ));
        IsTrue ("B \t".In(               false, caseMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In(               false, caseMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In(               false, caseMatters,         "A", "B", "C"  ));
      //IsTrue ("B"   .In(               false, caseMatters: true,   "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue ("B \t".In(               false, caseMatters: true,   "A", "B", "C"  ));
      //IsFalse("b"   .In(               false, caseMatters: true,   "A", "B", "C"  ));
      //IsFalse("b \t".In(               false, caseMatters: true,   "A", "B", "C"  ));
                                                
        // Static Syntax
        IsTrue (In("B"   , caseMatters,                             [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,                             [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                             [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                             [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,                       [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: true,                       [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,                       [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,                       [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,        spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,        spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,        spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,        spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,                      false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters,                      false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                      false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                      false, [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B \t", caseMatters: true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b"   ,              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsFalse(In("b \t",              true,  spaceMatters: false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B \t",              true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b"   ,              true,                false, [ "A", "B", "C" ]));
        IsFalse(In("b \t",              true,                false, [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              true,                       [ "A", "B", "C" ]));
        IsTrue (In("B \t",              true,                       [ "A", "B", "C" ]));
        IsFalse(In("b"   ,              true,                       [ "A", "B", "C" ]));
        IsFalse(In("b \t",              true,                       [ "A", "B", "C" ]));
        IsTrue (In("B"   ,                      caseMatters,        [ "A", "B", "C" ])); // Switch Flags 
        IsTrue (In("B \t",                      caseMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   ,                      caseMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t",                      caseMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters: false, caseMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B \t", spaceMatters: false, caseMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: false, caseMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: false, caseMatters,        [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: false, caseMatters: true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsTrue (In("B \t", spaceMatters: false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   , spaceMatters: false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: false,              true,  [ "A", "B", "C" ])); 
      //IsTrue (In("B \t", spaceMatters: false,              true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   , spaceMatters: false,              true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: false,              true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               false, caseMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B \t",               false, caseMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               false, caseMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t",               false, caseMatters,        [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               false, caseMatters: true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsTrue (In("B \t",               false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,               false, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               false, caseMatters: true,  [ "A", "B", "C" ]));

        // Static Syntax (Variadic)
        IsTrue (In("B"   , caseMatters,                               "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,                               "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                               "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                               "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,                         "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: true,                         "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,                         "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,                         "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,        spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,        spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,        spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,        spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,                      false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters,                      false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                      false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                      false,   "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,                false,   "A", "B", "C"  ));
        IsTrue (In("B \t", caseMatters: true,                false,   "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,                false,   "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,                false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B \t",              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b"   ,              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsFalse(In("b \t",              true,  spaceMatters: false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              true,                false,   "A", "B", "C"  ));
        IsTrue (In("B \t",              true,                false,   "A", "B", "C"  ));
        IsFalse(In("b"   ,              true,                false,   "A", "B", "C"  ));
        IsFalse(In("b \t",              true,                false,   "A", "B", "C"  ));
        IsTrue (In("B"   ,              true,                         "A", "B", "C"  ));
        IsTrue (In("B \t",              true,                         "A", "B", "C"  ));
        IsFalse(In("b"   ,              true,                         "A", "B", "C"  ));
        IsFalse(In("b \t",              true,                         "A", "B", "C"  ));
        IsTrue (In("B"   ,                      caseMatters,          "A", "B", "C"  )); // Switch Flags 
        IsTrue (In("B \t",                      caseMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   ,                      caseMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t",                      caseMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters: false, caseMatters,          "A", "B", "C"  ));
        IsTrue (In("B \t", spaceMatters: false, caseMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters: false, caseMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters: false, caseMatters,          "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false, caseMatters: true,    "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue (In("B \t", spaceMatters: false, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: false, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: false, caseMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,               false, caseMatters,          "A", "B", "C"  ));
        IsTrue (In("B \t",               false, caseMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   ,               false, caseMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t",               false, caseMatters,          "A", "B", "C"  ));
      //IsTrue (In("B"   ,               false, caseMatters: true,    "A", "B", "C"  )); // Resolves ambiguously
      //IsTrue (In("B \t",               false, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse(In("b"   ,               false, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse(In("b \t",               false, caseMatters: true,    "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: false,              true,    "A", "B", "C"  ));
      //IsTrue (In("B \t", spaceMatters: false,              true,    "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: false,              true,    "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: false,              true,    "A", "B", "C"  ));
    }

    // Yes / Yes
    
    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_YesYes_FlagsInBack()
    {
        // Extension Syntax
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
        IsTrue ("B"   .In( [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse("B \t".In( [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse("b"   .In( [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse("b \t".In( [ "A", "B", "C" ], caseMatters: true,               true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],              true, spaceMatters      ));
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
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse("B \t".In( [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse("b"   .In( [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse("b \t".In( [ "A", "B", "C" ],               true, caseMatters      ));
      //IsTrue ("B"   .In( [ "A", "B", "C" ],               true, caseMatters: true)); // Resolves ambiguously
      //IsFalse("B \t".In( [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse("b"   .In( [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse("b \t".In( [ "A", "B", "C" ],               true, caseMatters: true));
        IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters,                    true));
      //IsTrue ("B"   .In( [ "A", "B", "C" ], spaceMatters: true,              true)); // Resolves ambiguously
      //IsFalse("B \t".In( [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsFalse("b"   .In( [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsFalse("b \t".In( [ "A", "B", "C" ], spaceMatters: true,              true));

        // Static Syntax
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,       spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,       spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters,                     true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters,                     true));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true, spaceMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true, spaceMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse(In("B \t", [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse(In("b"   , [ "A", "B", "C" ], caseMatters: true,               true));
        IsFalse(In("b \t", [ "A", "B", "C" ], caseMatters: true,               true));
        IsTrue (In("B"   , [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ],              true, spaceMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],              true, spaceMatters      ));
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
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse(In("B \t", [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse(In("b"   , [ "A", "B", "C" ],               true, caseMatters      ));
        IsFalse(In("b \t", [ "A", "B", "C" ],               true, caseMatters      ));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,       caseMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true, caseMatters: true));
      //IsTrue (In("B"   , [ "A", "B", "C" ],               true, caseMatters: true)); // Resolves ambiguously
      //IsFalse(In("B \t", [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse(In("b"   , [ "A", "B", "C" ],               true, caseMatters: true));
      //IsFalse(In("b \t", [ "A", "B", "C" ],               true, caseMatters: true));
        IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters,                    true));
        IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters,                    true));
      //IsTrue (In("B"   , [ "A", "B", "C" ], spaceMatters: true,              true)); // Resolves ambiguously
      //IsFalse(In("B \t", [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsFalse(In("b"   , [ "A", "B", "C" ], spaceMatters: true,              true));
      //IsFalse(In("b \t", [ "A", "B", "C" ], spaceMatters: true,              true));
    }

    [TestMethod]
    public void In_String_CaseMattersSpaceMatters_YesYes_FlagsInFront()
    {
        // Extension Syntax
        IsTrue ("B"   .In( caseMatters,        spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters,        spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters,        spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters,        spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters,        spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters,        spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters,        spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters,        spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters,                      true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters,                      true, [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters,                      true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters,                      true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters: true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: true,  spaceMatters,       [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters: true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: true,  spaceMatters: true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In( caseMatters: true,                true, [ "A", "B", "C" ]));
        IsFalse("B \t".In( caseMatters: true,                true, [ "A", "B", "C" ]));
        IsFalse("b"   .In( caseMatters: true,                true, [ "A", "B", "C" ]));
        IsFalse("b \t".In( caseMatters: true,                true, [ "A", "B", "C" ]));
        IsTrue ("B"   .In(              true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("B \t".In(              true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b"   .In(              true,  spaceMatters,       [ "A", "B", "C" ]));
        IsFalse("b \t".In(              true,  spaceMatters,       [ "A", "B", "C" ]));
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
        IsTrue ("B"   .In( spaceMatters: true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters: true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b"   .In( spaceMatters: true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters: true, caseMatters,        [ "A", "B", "C" ]));
        IsTrue ("B"   .In(               true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("B \t".In(               true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b"   .In(               true, caseMatters,        [ "A", "B", "C" ]));
        IsFalse("b \t".In(               true, caseMatters,        [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,       caseMatters: true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,       caseMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b"   .In( spaceMatters,       caseMatters: true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,       caseMatters: true,  [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: true, caseMatters: true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In( spaceMatters: true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In( spaceMatters: true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsTrue ("B"   .In(               true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("B \t".In(               true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In(               true, caseMatters: true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In(               true, caseMatters: true,  [ "A", "B", "C" ]));
        IsTrue ("B"   .In( spaceMatters,                    true,  [ "A", "B", "C" ]));
        IsFalse("B \t".In( spaceMatters,                    true,  [ "A", "B", "C" ]));
        IsFalse("b"   .In( spaceMatters,                    true,  [ "A", "B", "C" ]));
        IsFalse("b \t".In( spaceMatters,                    true,  [ "A", "B", "C" ]));
      //IsTrue ("B"   .In( spaceMatters: true,              true,  [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true,              true,  [ "A", "B", "C" ]));
      //IsFalse("b"   .In( spaceMatters: true,              true,  [ "A", "B", "C" ]));
      //IsFalse("b \t".In( spaceMatters: true,              true,  [ "A", "B", "C" ]));

        // Extension Syntax (Variadic)
        IsTrue ("B"   .In( caseMatters,        spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,        spaceMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,        spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,        spaceMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters,        spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,        spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,        spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,        spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters,                      true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters,                      true,   "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters,                      true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters,                      true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters: true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: true,  spaceMatters,         "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters: true,  spaceMatters: true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: true,  spaceMatters: true,   "A", "B", "C"  ));
        IsTrue ("B"   .In( caseMatters: true,                true,   "A", "B", "C"  ));
        IsFalse("B \t".In( caseMatters: true,                true,   "A", "B", "C"  ));
        IsFalse("b"   .In( caseMatters: true,                true,   "A", "B", "C"  ));
        IsFalse("b \t".In( caseMatters: true,                true,   "A", "B", "C"  ));
        IsTrue ("B"   .In(              true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("B \t".In(              true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("b"   .In(              true,  spaceMatters,         "A", "B", "C"  ));
        IsFalse("b \t".In(              true,  spaceMatters,         "A", "B", "C"  ));
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
        IsTrue ("B"   .In( spaceMatters: true, caseMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters: true, caseMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters: true, caseMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters: true, caseMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In(               true, caseMatters,          "A", "B", "C"  ));
        IsFalse("B \t".In(               true, caseMatters,          "A", "B", "C"  ));
        IsFalse("b"   .In(               true, caseMatters,          "A", "B", "C"  ));
        IsFalse("b \t".In(               true, caseMatters,          "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,       caseMatters: true,    "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,       caseMatters: true,    "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters,       caseMatters: true,    "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,       caseMatters: true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true, caseMatters: true,    "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true, caseMatters: true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In(               true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("B \t".In(               true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("b"   .In(               true, caseMatters: true,    "A", "B", "C"  ));
      //IsFalse("b \t".In(               true, caseMatters: true,    "A", "B", "C"  ));
        IsTrue ("B"   .In( spaceMatters,                    true,    "A", "B", "C"  ));
        IsFalse("B \t".In( spaceMatters,                    true,    "A", "B", "C"  ));
        IsFalse("b"   .In( spaceMatters,                    true,    "A", "B", "C"  ));
        IsFalse("b \t".In( spaceMatters,                    true,    "A", "B", "C"  ));
      //IsTrue ("B"   .In( spaceMatters: true,              true,    "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse("B \t".In( spaceMatters: true,              true,    "A", "B", "C"  ));
      //IsFalse("b"   .In( spaceMatters: true,              true,    "A", "B", "C"  ));
      //IsFalse("b \t".In( spaceMatters: true,              true,    "A", "B", "C"  ));

        // Static Syntax
        IsTrue (In("B"   , caseMatters,        spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,        spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,        spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,        spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,        spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,        spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,        spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,        spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters,                      true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters,                      true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters,        [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters: true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   , caseMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("B \t", caseMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b"   , caseMatters: true,                true,  [ "A", "B", "C" ]));
        IsFalse(In("b \t", caseMatters: true,                true,  [ "A", "B", "C" ]));
        IsTrue (In("B"   ,              true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("B \t",              true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b"   ,              true,  spaceMatters,        [ "A", "B", "C" ]));
        IsFalse(In("b \t",              true,  spaceMatters,        [ "A", "B", "C" ]));
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
        IsTrue (In("B"   , spaceMatters: true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters: true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters: true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters: true, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   ,               true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("B \t",               true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b"   ,               true, caseMatters,         [ "A", "B", "C" ]));
        IsFalse(In("b \t",               true, caseMatters,         [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,       caseMatters: true,   [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,       caseMatters: true,   [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters,       caseMatters: true,   [ "A", "B", "C" ]));
        IsFalse(In("b \t", spaceMatters,       caseMatters: true,   [ "A", "B", "C" ]));
      //IsTrue (In("B"   , spaceMatters: true, caseMatters: true,   [ "A", "B", "C" ])); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("b"   , spaceMatters: true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsTrue (In("B"   ,               true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("B \t",               true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("b"   ,               true, caseMatters: true,   [ "A", "B", "C" ]));
      //IsFalse(In("b \t",               true, caseMatters: true,   [ "A", "B", "C" ]));
        IsTrue (In("B"   , spaceMatters,                    true,   [ "A", "B", "C" ]));
        IsFalse(In("B \t", spaceMatters,                    true,   [ "A", "B", "C" ]));
        IsFalse(In("b"   , spaceMatters,                    true,   [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters,                    true,   [ "A", "B", "C" ])); // Resolves ambiguously
      //IsTrue (In("B"   , spaceMatters: true,              true,   [ "A", "B", "C" ]));
      //IsFalse(In("B \t", spaceMatters: true,              true,   [ "A", "B", "C" ]));
      //IsFalse(In("b"   , spaceMatters: true,              true,   [ "A", "B", "C" ]));
      //IsFalse(In("b \t", spaceMatters: true,              true,   [ "A", "B", "C" ]));

        // Static Syntax (Variadic)
        IsTrue (In("B"   , caseMatters,        spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,        spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,        spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,        spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,        spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,        spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,        spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,        spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters,                      true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters,                      true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters,          "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,  spaceMatters: true,    "A", "B", "C"  ));
        IsTrue (In("B"   , caseMatters: true,                true,    "A", "B", "C"  ));
        IsFalse(In("B \t", caseMatters: true,                true,    "A", "B", "C"  ));
        IsFalse(In("b"   , caseMatters: true,                true,    "A", "B", "C"  ));
        IsFalse(In("b \t", caseMatters: true,                true,    "A", "B", "C"  ));
        IsTrue (In("B"   ,              true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("B \t",              true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b"   ,              true,  spaceMatters,          "A", "B", "C"  ));
        IsFalse(In("b \t",              true,  spaceMatters,          "A", "B", "C"  ));
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
        IsTrue (In("B"   , spaceMatters: true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters: true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters: true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters: true, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   ,               true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("B \t",               true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b"   ,               true, caseMatters,           "A", "B", "C"  ));
        IsFalse(In("b \t",               true, caseMatters,           "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,       caseMatters: true,     "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,       caseMatters: true,     "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters,       caseMatters: true,     "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,       caseMatters: true,     "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true, caseMatters: true,     "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true, caseMatters: true,     "A", "B", "C"  ));
      //IsTrue (In("B"   ,               true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("B \t",               true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("b"   ,               true, caseMatters: true,     "A", "B", "C"  ));
      //IsFalse(In("b \t",               true, caseMatters: true,     "A", "B", "C"  ));
        IsTrue (In("B"   , spaceMatters,                    true,     "A", "B", "C"  ));
        IsFalse(In("B \t", spaceMatters,                    true,     "A", "B", "C"  ));
        IsFalse(In("b"   , spaceMatters,                    true,     "A", "B", "C"  ));
        IsFalse(In("b \t", spaceMatters,                    true,     "A", "B", "C"  ));
      //IsTrue (In("B"   , spaceMatters: true,              true,     "A", "B", "C"  )); // Resolves ambiguously
      //IsFalse(In("B \t", spaceMatters: true,              true,     "A", "B", "C"  ));
      //IsFalse(In("b"   , spaceMatters: true,              true,     "A", "B", "C"  ));
      //IsFalse(In("b \t", spaceMatters: true,              true,     "A", "B", "C"  ));
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