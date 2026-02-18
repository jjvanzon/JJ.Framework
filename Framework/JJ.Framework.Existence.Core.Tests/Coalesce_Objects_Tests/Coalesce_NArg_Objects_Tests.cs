namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_NArg_Objects_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_NArg_Objects()
    {
        // Static params
        NoNullRet(NoNullObj,      Coalesce(NullObj, NoNullObj, NullyFilledObj));
        NoNullRet(NullyFilledObj, Coalesce(NullObj, NullyFilledObj, NoNullObj));
        // Static coll express
        NoNullRet(NoNullObj,      Coalesce([NullObj, NoNullObj, NullyFilledObj]));
        // Extension on coll
        NoNullRet(NullyFilledObj, new[] { NullObj, NullyFilledObj, NoNullObj }.Coalesce());
        // Extension params
        NoNullRet(NullyFilledObj, NullyFilledObj.Coalesce(NullObj, NullObj, NullObj));
        // Extension coll express
        NoNullRet(NullyFilledObj, NullyFilledObj.Coalesce([ NullObj, NullObj, NullObj ]));
    }
}