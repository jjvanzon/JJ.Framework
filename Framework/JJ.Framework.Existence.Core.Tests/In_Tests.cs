namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests
{
    [TestMethod]
    public void In_Strings()
    {
        // Main Use
        IsTrue (In("GREEN" ,                        "Red", "Green", "Blue"                     ));
        IsTrue (   "GREEN" .In(                     "Red", "Green", "Blue"                     ));
        
        // Collection Expressions
        IsTrue (In("GREEN" ,                      [ "Red", "Green", "Blue" ]                   ));
        IsTrue (   "GREEN" .In(                   [ "Red", "Green", "Blue" ]                   ));
        
        // Ignore Case (default behavior)
        IsTrue (In("GREEN" ,   ignoreCase: true,    "Red", "Green", "Blue"                     ));
        IsTrue (   "GREEN" .In(ignoreCase: true,    "Red", "Green", "Blue"                     ));
        IsTrue (In("GREEN" ,   ignoreCase: true,  [ "Red", "Green", "Blue" ]                   ));
        IsTrue (   "GREEN" .In(ignoreCase: true,  [ "Red", "Green", "Blue" ]                   ));
        IsTrue (In("GREEN" ,                      [ "Red", "Green", "Blue" ], ignoreCase: true ));
        IsTrue (   "GREEN" .In(                   [ "Red", "Green", "Blue" ], ignoreCase: true ));
        
        // Match case
        IsFalse(In("GREEN" ,   ignoreCase: false,   "Red", "Green", "Blue"                     ));
        IsFalse(   "GREEN" .In(ignoreCase: false,   "Red", "Green", "Blue"                     ));
        IsFalse(In("GREEN" ,   ignoreCase: false, [ "Red", "Green", "Blue" ]                   ));
        IsFalse(   "GREEN" .In(ignoreCase: false, [ "Red", "Green", "Blue" ]                   ));
        IsFalse(In("GREEN" ,                      [ "Red", "Green", "Blue" ], ignoreCase: false));
        IsFalse(   "GREEN" .In(                   [ "Red", "Green", "Blue" ], ignoreCase: false));
        IsTrue (In("Green" ,   ignoreCase: false,   "Red", "Green", "Blue"                     ));
        IsTrue (   "Green" .In(ignoreCase: false,   "Red", "Green", "Blue"                     ));
        IsTrue (In("Green" ,   ignoreCase: false, [ "Red", "Green", "Blue" ]                   ));
        IsTrue (   "Green" .In(ignoreCase: false, [ "Red", "Green", "Blue" ]                   ));
        IsTrue (In("Green" ,                      [ "Red", "Green", "Blue" ], ignoreCase: false));
        IsTrue (   "Green" .In(                   [ "Red", "Green", "Blue" ], ignoreCase: false));
        
        // Negative match
        IsFalse(In("Yellow",                        "Red", "Green", "Blue"                     ));
        IsFalse(   "Yellow".In(                     "Red", "Green", "Blue"                     ));
        IsFalse(In("Yellow",                      [ "Red", "Green", "Blue" ]                   ));
        IsFalse(   "Yellow".In(                   [ "Red", "Green", "Blue" ]                   ));
        
        // TODO: Test nulls
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
        IsTrue (  In(a,   a, b, c  ));
        IsTrue (  In(b,   a, b, c  ));
        IsTrue (  In(a, [ a, b, c ]));
        IsTrue (  In(b, [ a, b, c ]));

        IsFalse(d.In(     a, b, c  ));
        IsFalse(d.In(   [ a, b, c ]));
        IsFalse(  In(d,   a, b, c  ));
        IsFalse(  In(d, [ a, b, c ]));
    }
    
    [TestMethod]
    public void In_Structs()
    {
        IsTrue (1.In(     1, 2, 3  ));
        IsTrue (2.In(     1, 2, 3  ));
        IsTrue (1.In(   [ 1, 2, 3 ]));
        IsTrue (2.In(   [ 1, 2, 3 ]));
        IsTrue (  In(1,   1, 2, 3  ));
        IsTrue (  In(2,   1, 2, 3  ));
        IsTrue (  In(1, [ 1, 2, 3 ]));
        IsTrue (  In(2, [ 1, 2, 3 ]));

        IsFalse(4.In(     1, 2, 3  ));
        IsFalse(4.In(   [ 1, 2, 3 ]));
        IsFalse(  In(4,   1, 2, 3  ));
        IsFalse(  In(4, [ 1, 2, 3 ]));
    }
    
    [TestMethod]
    public void In_Nully()
    {
        {
            StringBuilder a = new();
            StringBuilder b = new();
            object? _null = null;

            IsTrue (a    .In(a, b, _null));
            IsTrue (b    .In(a, b, _null));
            IsTrue (_null.In(a, b, _null));
            IsFalse(_null.In(a, b       ));
        }
        {
            int?[]? nullColl = null;
            int?[] emptyColl = [ ];
            
            IsTrue (      1.In(      1,      2,      3, NullNum));
            IsTrue (      2.In(      1,      2,      3, NullNum));
            IsTrue (      3.In(      1,      2,      3, NullNum));
            IsTrue ( Nully1.In(      1,      2,      3         ));
            IsTrue ( Nully2.In(      1,      2,      3         ));
            IsTrue ( Nully3.In(      1,      2,      3         ));
            IsTrue ( Nully1.In(      1,      2, Nully3         ));
            IsTrue ( Nully2.In(      1,      2, Nully3         ));
            IsTrue ( Nully3.In(      1,      2, Nully3         ));
            IsTrue (      1.In(      1,      2, Nully3         ));
            IsTrue (      2.In(      1,      2, Nully3         ));
            IsTrue (      3.In(      1,      2, Nully3         ));
            IsTrue (      1.In( Nully1, Nully2, Nully3         ));
            IsTrue (      2.In( Nully1, Nully2, Nully3         ));
            IsTrue (      3.In( Nully1, Nully2, Nully3         ));
            IsTrue ( Nully1.In( Nully1, Nully2, Nully3         ));
            IsTrue ( Nully2.In( Nully1, Nully2, Nully3         ));
            IsTrue ( Nully3.In( Nully1, Nully2, Nully3         ));
            IsTrue (NullNum.In(      1,      2,      3, NullNum));
            IsTrue (NullNum.In(      1,      2, Nully3, NullNum));
            IsTrue (NullNum.In( Nully1, Nully2, Nully3, NullNum));
            IsTrue (In(      1,      1,      2,      3, NullNum));
            IsTrue (In(      2,      1,      2,      3, NullNum));
            IsTrue (In(      3,      1,      2,      3, NullNum));
            IsTrue (In( Nully1,      1,      2,      3         ));
            IsTrue (In( Nully2,      1,      2,      3         ));
            IsTrue (In( Nully3,      1,      2,      3         ));
            IsTrue (In( Nully1,      1,      2, Nully3         ));
            IsTrue (In( Nully2,      1,      2, Nully3         ));
            IsTrue (In( Nully3,      1,      2, Nully3         ));
            IsTrue (In(      1,      1,      2, Nully3         ));
            IsTrue (In(      2,      1,      2, Nully3         ));
            IsTrue (In(      3,      1,      2, Nully3         ));
            IsTrue (In(      1, Nully1, Nully2, Nully3         ));
            IsTrue (In(      2, Nully1, Nully2, Nully3         ));
            IsTrue (In(      3, Nully1, Nully2, Nully3         ));
            IsTrue (In( Nully1, Nully1, Nully2, Nully3         ));
            IsTrue (In( Nully2, Nully1, Nully2, Nully3         ));
            IsTrue (In( Nully3, Nully1, Nully2, Nully3         ));
            IsTrue (In(NullNum,      1,      2,      3, NullNum));
            IsTrue (In(NullNum,      1,      2, Nully3, NullNum));
            IsTrue (In(NullNum, Nully1, Nully2, Nully3, NullNum));
            
            // Negative matches
            IsFalse(      4.In(      1,      2,      3, NullNum));
            IsFalse(      4.In(      1,      2, Nully3         ));
            IsFalse(      4.In( Nully1, Nully2, Nully3         ));
            IsFalse( Nully4.In(      1,      2,      3         ));
            IsFalse( Nully4.In(      1,      2, Nully3         ));
            IsFalse( Nully4.In( Nully1, Nully2, Nully3         ));
            IsFalse(NullNum.In(      1,      2,      3         ));
            IsFalse(NullNum.In(      1,      2, Nully3         ));
            IsFalse(NullNum.In( Nully1, Nully2, Nully3         ));
            IsFalse(In(     4,       1,      2,      3, NullNum));
            IsFalse(In(Nully4,       1,      2,      3         ));
            IsFalse(In(Nully4,       1,      2, Nully3         ));
            IsFalse(In(     4,       1,      2, Nully3         ));
            IsFalse(In(     4,  Nully1, Nully2, Nully3         ));
            IsFalse(In(Nully4,  Nully1, Nully2, Nully3         ));
            IsFalse(In(NullNum,      1,      2,      3         ));
            IsFalse(In(NullNum,      1,      2, Nully3         ));
            IsFalse(In(NullNum, Nully1, Nully2, Nully3         ));
            
            // Staring into the abyss
            IsFalse(   Nully1.In(nullColl));
            IsFalse(        1.In(NullNum  ));
            IsFalse(        1.In(nullColl));
            IsFalse(In(Nully1,   nullColl));
            IsFalse(In(     1,   NullNum  ));
            IsFalse(In(     1,   nullColl));
            
            // Very much null and empty
            IsTrue (   NullNum.In(NullNum   ));
            IsTrue (In(NullNum,   NullNum   ));
            IsFalse(   NullNum.In(emptyColl));
            IsFalse(In(NullNum,   emptyColl));
            IsFalse(   NullNum.In(nullColl ));
            IsFalse(In(NullNum,   nullColl ));
        }
    }
}