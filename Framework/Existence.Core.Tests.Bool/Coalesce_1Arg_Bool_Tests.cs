namespace JJ.Framework.Existence.Core.Bool.Tests;

[TestClass]
public class Coalesce_1Arg_Bool_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_1Arg_Bools()
    {
        NoNullRet(false, NullBool  .Coalesce());
        NoNullRet(true,  true      .Coalesce());
        NoNullRet(false, false     .Coalesce());
        NoNullRet(true,  True      .Coalesce());
        NoNullRet(false, False     .Coalesce());
        NoNullRet(true,  NullyTrue .Coalesce());
        NoNullRet(false, NullyFalse.Coalesce());

        NoNullRet(false, Coalesce(NullBool  ));
        NoNullRet(true,  Coalesce(true      ));
        NoNullRet(false, Coalesce(false     ));
        NoNullRet(true,  Coalesce(True      ));
        NoNullRet(false, Coalesce(False     ));
        NoNullRet(true,  Coalesce(NullyTrue ));
        NoNullRet(false, Coalesce(NullyFalse));
    }
}