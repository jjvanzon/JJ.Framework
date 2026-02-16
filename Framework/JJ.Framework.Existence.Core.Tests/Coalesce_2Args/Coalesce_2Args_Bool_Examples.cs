namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_2Args_Bool_Examples : TestBase
{
    [TestMethod]
    public void Coalesce_2Arg_Bool_Examples()
    {
        IsFalse(NullyFalse.Coalesce(NullBool));
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_Examples_ZeroMattersFlagsInBack()
    {
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters: false));
      //IsFalse(NullyFalse.Coalesce(NullBool,                         false)); // Not a flag
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters       ));
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters: true ));
      //IsFalse(NullyFalse.Coalesce(NullBool,                         true )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_Examples_ZeroMattersFlagsInFront()
    {
             IsFalse(NullyFalse.Coalesce(zeroMatters: false, NullBool           ));
             IsFalse(NullyFalse.Coalesce(             false, NullBool           ));
             IsFalse(NullyFalse.Coalesce(zeroMatters       , NullBool           ));
             IsFalse(NullyFalse.Coalesce(zeroMatters: true , NullBool           ));
Throws(() => IsFalse(NullyFalse.Coalesce(             true , NullBool           )), "IsFalse failed"); // Not a flag
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_Examples_ZeroMattersFlagsInBack_NoNulls()
    {
        IsFalse(False.Coalesce(False,       zeroMatters: false));
        IsFalse(False.Coalesce(False,                    false));
        IsFalse(False.Coalesce(False,       zeroMatters       ));
        IsFalse(False.Coalesce(False,       zeroMatters: true ));
      //IsFalse(False.Coalesce(False,                    true )); // Not a flag
    }

    [TestMethod]
    public void Coalesce_2Args_Bool_Examples_ZeroMattersFlagsInFront_NoNulls()
    {
        IsFalse(False.Coalesce(zeroMatters: false, False      ));
      //IsFalse(False.Coalesce(             false, False      )); // Not a flag
        IsFalse(False.Coalesce(zeroMatters       , False      ));
        IsFalse(False.Coalesce(zeroMatters: true , False      ));
      //IsFalse(False.Coalesce(             true , False      )); // Not a flag
    }

}
