namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Arg_Bool_Examples : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Bool_Examples_ZeroMattersFlagsInBack()
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
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Examples_ZeroMattersFlagsInFront()
    {
             IsTrue (Coalesce(zeroMatters: false, False, NullyTrue, NullBool    ));
             IsTrue (Coalesce(             false, False, NullyTrue, NullBool    ));
             IsFalse(Coalesce(zeroMatters       , False, NullyTrue, NullBool    ));
             IsFalse(Coalesce(zeroMatters: true , False, NullyTrue, NullBool    ));
Throws(() => IsFalse(Coalesce(             true , False, NullyTrue, NullBool    )), "IsFalse failed"); // Not a flag
         
             IsTrue (NullyFalse.Coalesce(zeroMatters: false, NullBool, NullyTrue));
             IsTrue (NullyFalse.Coalesce(             false, NullBool, NullyTrue));
             IsFalse(NullyFalse.Coalesce(zeroMatters       , NullBool, NullyTrue));
             IsFalse(NullyFalse.Coalesce(zeroMatters: true , NullBool, NullyTrue));
Throws(() => IsFalse(NullyFalse.Coalesce(             true , NullBool, NullyTrue)), "IsFalse failed"); // Not a flag
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Examples_ZeroMattersFlagsInBack_NoNulls()
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
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Examples_ZeroMattersFlagsInFront_NoNulls()
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
    }
}