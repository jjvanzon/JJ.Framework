namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_SpaceMatters : TestBase
{
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
}