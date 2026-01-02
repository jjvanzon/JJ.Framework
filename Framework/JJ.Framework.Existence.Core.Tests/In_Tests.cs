namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class In_Tests_Other : TestBase
{
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