namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_CaseMatters : TestBase
{
    [TestMethod]
    public void In_Strings_CaseMatters_YesOrNo()
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
}