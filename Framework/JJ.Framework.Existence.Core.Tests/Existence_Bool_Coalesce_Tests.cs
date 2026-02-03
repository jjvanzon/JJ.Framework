namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Bool_Coalesce_Tests
{
    const    bool  True       = true ;
    const    bool  False      = false;
    readonly bool? NullyTrue  = true ;
    readonly bool? NullyFalse = false;
    readonly bool? NullBool   = null ;

    [TestMethod]
    public void Test_Bool_Coalesce_ZeroMattersFlagsInBack()
    {
        IsTrue (Coalesce(False, NullyTrue, NullBool,     zeroMatters: false));
      //IsTrue (Coalesce(False, NullyTrue, NullBool,                  false)); // Not a flag
        IsFalse(Coalesce(False, NullyTrue, NullBool,     zeroMatters       ));
        IsFalse(Coalesce(False, NullyTrue, NullBool,     zeroMatters: true ));
      //IsFalse(Coalesce(False, NullyTrue, NullBool,                  true )); // Not a flag

        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters: false));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue,              false));
        IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters       ));
        IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters: true ));
      //IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue,              true )); // Not a flag

        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters: false));
      //IsFalse(NullyFalse.Coalesce(NullBool,                         false)); // Not a flag
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters       ));
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters: true ));
      //IsFalse(NullyFalse.Coalesce(NullBool,                         true )); // Not a flag
    }

    [TestMethod]
    public void Test_Bool_Coalesce_ZeroMattersFlagsInFront()
    {
        IsTrue (Coalesce(zeroMatters: false, False, NullyTrue, NullBool     ));
        IsTrue (Coalesce(             false, False, NullyTrue, NullBool     ));
        IsFalse(Coalesce(zeroMatters       , False, NullyTrue, NullBool     ));
        IsFalse(Coalesce(zeroMatters: true , False, NullyTrue, NullBool     ));
        IsFalse(Coalesce(             true , False, NullyTrue, NullBool     ));

        IsTrue (NullyFalse.Coalesce(zeroMatters: false, NullBool, NullyTrue));
        IsTrue (NullyFalse.Coalesce(             false, NullBool, NullyTrue));
        IsFalse(NullyFalse.Coalesce(zeroMatters       , NullBool, NullyTrue));
        IsFalse(NullyFalse.Coalesce(zeroMatters: true , NullBool, NullyTrue));
        IsFalse(NullyFalse.Coalesce(             true , NullBool, NullyTrue));

        IsFalse(NullyFalse.Coalesce(zeroMatters: false, NullBool           ));
        IsFalse(NullyFalse.Coalesce(             false, NullBool           ));
        IsFalse(NullyFalse.Coalesce(zeroMatters       , NullBool           ));
        IsFalse(NullyFalse.Coalesce(zeroMatters: true , NullBool           ));
      //IsFalse(NullyFalse.Coalesce(             true , NullBool           )); // Not a flag
    }

    [TestMethod]
    public void Test_Bool_Coalesce_ZeroMattersFlagsInBackNoNulls()
    {
        IsTrue (Coalesce(False, True, False, zeroMatters: false));
      //IsTrue (Coalesce(False, True, False,              false)); // Not a flag
        IsFalse(Coalesce(False, True, False, zeroMatters       ));
        IsFalse(Coalesce(False, True, False, zeroMatters: true ));
      //IsFalse(Coalesce(False, True, False,              true )); // Not a flag

        IsTrue (False.Coalesce(False, True, zeroMatters: false));
        IsTrue (False.Coalesce(False, True,              false));
        IsFalse(False.Coalesce(False, True, zeroMatters       ));
        IsFalse(False.Coalesce(False, True, zeroMatters: true ));
      //IsFalse(False.Coalesce(False, True,              true )); // Not a flag

        IsFalse(False.Coalesce(False,       zeroMatters: false));
        IsFalse(False.Coalesce(False,                    false));
        IsFalse(False.Coalesce(False,       zeroMatters       ));
        IsFalse(False.Coalesce(False,       zeroMatters: true ));
      //IsFalse(False.Coalesce(False,                    true )); // Not a flag
    }

    [TestMethod]
    public void Test_Bool_Coalesce_ZeroMattersFlagsInFrontNoNulls()
    {
        IsTrue (Coalesce(zeroMatters: false, False, True, False     ));
      //IsTrue (Coalesce(             false, False, True, False     )); // Not a flag
        IsFalse(Coalesce(zeroMatters       , False, True, False     ));
        IsFalse(Coalesce(zeroMatters: true , False, True, False     ));
      //IsFalse(Coalesce(             true , False, True, False     )); // Not a flag

        IsTrue (False.Coalesce(zeroMatters: false, False, True));
      //IsTrue (False.Coalesce(             false, False, True)); // Not a flag
        IsFalse(False.Coalesce(zeroMatters       , False, True));
        IsFalse(False.Coalesce(zeroMatters: true , False, True));
      //IsFalse(False.Coalesce(             true , False, True)); // Not a flag

        IsFalse(False.Coalesce(zeroMatters: false, False      ));
      //IsFalse(False.Coalesce(             false, False      )); // Not a flag
        IsFalse(False.Coalesce(zeroMatters       , False      ));
        IsFalse(False.Coalesce(zeroMatters: true , False      ));
      //IsFalse(False.Coalesce(             true , False      )); // Not a flag
    }
}