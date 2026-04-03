namespace JJ.Framework.Existence.Core.Values.Tests;

[TestClass]
public class Coalesce_2Args_Values_NoFlags : TestBase
{
    // Vals

    [TestMethod]
    public void Coalesce_2Args_Vals_VerifyInputs()
    {
        // Assert input states
        IsNull (   NullNum);
        NullRet(0, Nully0 );
        NullRet(1, Nully1 );
        NullRet(2, Nully2 );
        NoNullRet(0);
        NoNullRet(1);
        NoNullRet(2);
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_Static()
    {
        NoNullRet(0, Coalesce( NullNum, NullNum));
        NoNullRet(0, Coalesce(  Nully0, NullNum));
        NoNullRet(1, Coalesce(  Nully1, NullNum));
        NoNullRet(2, Coalesce(  Nully2, NullNum));
        NoNullRet(0, Coalesce(       0, NullNum));
        NoNullRet(1, Coalesce(       1, NullNum));
        NoNullRet(2, Coalesce(       2, NullNum));
        NoNullRet(0, Coalesce( NullNum,  Nully0));
        NoNullRet(0, Coalesce(  Nully0,  Nully0));
        NoNullRet(1, Coalesce(  Nully1,  Nully0));
        NoNullRet(2, Coalesce(  Nully2,  Nully0));
        NoNullRet(0, Coalesce(       0,  Nully0));
        NoNullRet(1, Coalesce(       1,  Nully0));
        NoNullRet(2, Coalesce(       2,  Nully0));
        NoNullRet(1, Coalesce( NullNum,  Nully1));
        NoNullRet(1, Coalesce(  Nully0,  Nully1));
        NoNullRet(1, Coalesce(  Nully1,  Nully1));
        NoNullRet(2, Coalesce(  Nully2,  Nully1));
        NoNullRet(1, Coalesce(       0,  Nully1));
        NoNullRet(1, Coalesce(       1,  Nully1));
        NoNullRet(2, Coalesce(       2,  Nully1));
        NoNullRet(2, Coalesce( NullNum,  Nully2));
        NoNullRet(2, Coalesce(  Nully0,  Nully2));
        NoNullRet(1, Coalesce(  Nully1,  Nully2));
        NoNullRet(2, Coalesce(  Nully2,  Nully2));
        NoNullRet(2, Coalesce(       0,  Nully2));
        NoNullRet(1, Coalesce(       1,  Nully2));
        NoNullRet(2, Coalesce(       2,  Nully2));
        NoNullRet(0, Coalesce( NullNum,       0));
        NoNullRet(0, Coalesce(  Nully0,       0));
        NoNullRet(1, Coalesce(  Nully1,       0));
        NoNullRet(2, Coalesce(  Nully2,       0));
        NoNullRet(0, Coalesce(       0,       0));
        NoNullRet(1, Coalesce(       1,       0));
        NoNullRet(2, Coalesce(       2,       0));
        NoNullRet(1, Coalesce( NullNum,       1));
        NoNullRet(1, Coalesce(  Nully0,       1));
        NoNullRet(1, Coalesce(  Nully1,       1));
        NoNullRet(2, Coalesce(  Nully2,       1));
        NoNullRet(1, Coalesce(       0,       1));
        NoNullRet(1, Coalesce(       1,       1));
        NoNullRet(2, Coalesce(       2,       1));
        NoNullRet(2, Coalesce( NullNum,       2));
        NoNullRet(2, Coalesce(  Nully0,       2));
        NoNullRet(1, Coalesce(  Nully1,       2));
        NoNullRet(2, Coalesce(  Nully2,       2));
        NoNullRet(2, Coalesce(       0,       2));
        NoNullRet(1, Coalesce(       1,       2));
        NoNullRet(2, Coalesce(       2,       2));
    }

    [TestMethod]
    public void Coalesce_2Args_Vals_Extensions()
    {
        NoNullRet(0,  NullNum.Coalesce( NullNum));
        NoNullRet(0,   Nully0.Coalesce( NullNum));
        NoNullRet(1,   Nully1.Coalesce( NullNum));
        NoNullRet(2,   Nully2.Coalesce( NullNum));
        NoNullRet(0,        0.Coalesce( NullNum));
        NoNullRet(1,        1.Coalesce( NullNum));
        NoNullRet(2,        2.Coalesce( NullNum));
        NoNullRet(0,  NullNum.Coalesce(  Nully0));
        NoNullRet(0,   Nully0.Coalesce(  Nully0));
        NoNullRet(1,   Nully1.Coalesce(  Nully0));
        NoNullRet(2,   Nully2.Coalesce(  Nully0));
        NoNullRet(0,        0.Coalesce(  Nully0));
        NoNullRet(1,        1.Coalesce(  Nully0));
        NoNullRet(2,        2.Coalesce(  Nully0));
        NoNullRet(1,  NullNum.Coalesce(  Nully1));
        NoNullRet(1,   Nully0.Coalesce(  Nully1));
        NoNullRet(1,   Nully1.Coalesce(  Nully1));
        NoNullRet(2,   Nully2.Coalesce(  Nully1));
        NoNullRet(1,        0.Coalesce(  Nully1));
        NoNullRet(1,        1.Coalesce(  Nully1));
        NoNullRet(2,        2.Coalesce(  Nully1));
        NoNullRet(2,  NullNum.Coalesce(  Nully2));
        NoNullRet(2,   Nully0.Coalesce(  Nully2));
        NoNullRet(1,   Nully1.Coalesce(  Nully2));
        NoNullRet(2,   Nully2.Coalesce(  Nully2));
        NoNullRet(2,        0.Coalesce(  Nully2));
        NoNullRet(1,        1.Coalesce(  Nully2));
        NoNullRet(2,        2.Coalesce(  Nully2));
        NoNullRet(0,  NullNum.Coalesce(       0));
        NoNullRet(0,   Nully0.Coalesce(       0));
        NoNullRet(1,   Nully1.Coalesce(       0));
        NoNullRet(2,   Nully2.Coalesce(       0));
        NoNullRet(0,        0.Coalesce(       0));
        NoNullRet(1,        1.Coalesce(       0));
        NoNullRet(2,        2.Coalesce(       0));
        NoNullRet(1,  NullNum.Coalesce(       1));
        NoNullRet(1,   Nully0.Coalesce(       1));
        NoNullRet(1,   Nully1.Coalesce(       1));
        NoNullRet(2,   Nully2.Coalesce(       1));
        NoNullRet(1,        0.Coalesce(       1));
        NoNullRet(1,        1.Coalesce(       1));
        NoNullRet(2,        2.Coalesce(       1));
        NoNullRet(2,  NullNum.Coalesce(       2));
        NoNullRet(2,   Nully0.Coalesce(       2));
        NoNullRet(1,   Nully1.Coalesce(       2));
        NoNullRet(2,   Nully2.Coalesce(       2));
        NoNullRet(2,        0.Coalesce(       2));
        NoNullRet(1,        1.Coalesce(       2));
        NoNullRet(2,        2.Coalesce(       2));
    }

    // Vals to Text

    [TestMethod]
    public void Coalesce_2Args_ValToText_NoNullies()
    {
        NoNullRet("",           Coalesce(0,  NullText ));
        NoNullRet("peekaboo",   Coalesce(0, "peekaboo"));
        NoNullRet("",         0.Coalesce(    NullText ));
        NoNullRet("peekaboo", 0.Coalesce(   "peekaboo"));
        NoNullRet("1",        1.Coalesce(    NullText ));
        NoNullRet("1",        1.Coalesce(   "peekaboo"));
    }

    [TestMethod]
    public void Coalesce_2Args_ValToText_WithNullies()
    {
        NoNullRet("",    Coalesce(NullNum,   NullText ));
        NoNullRet("boo", Coalesce(NullNum,  "boo"     ));
        NoNullRet("",    Coalesce(Nully0,    NullText ));
        NoNullRet("boo", Coalesce(Nully0,   "boo"     ));
        NoNullRet("1",   Coalesce(Nully1,    NullText ));
        NoNullRet("1",   Coalesce(Nully1,   "boo"     ));
        NoNullRet("",    NullNum.Coalesce(   NullText ));
        NoNullRet("boo", NullNum.Coalesce(  "boo"     ));
        NoNullRet("",    Nully0 .Coalesce(   NullText ));
        NoNullRet("boo", Nully0 .Coalesce(  "boo"     ));
        NoNullRet("1",   Nully1 .Coalesce(   NullText ));
        NoNullRet("1",   Nully1 .Coalesce(  "boo"     ));
    }
}