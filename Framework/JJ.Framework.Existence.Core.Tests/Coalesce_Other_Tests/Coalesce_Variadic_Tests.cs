namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Variadic_Objects_Tests : TestBase
{
    // Objects

    [TestMethod]
    public void Coalesce_Variadic_Objects()
    {
        // Static params
        NoNullRet(NoNullObj,      Coalesce(NullObj, NoNullObj, NullyFilledObj));
        NoNullRet(NullyFilledObj, Coalesce(NullObj, NullyFilledObj, NoNullObj));
        // Static collection
        NoNullRet(NoNullObj,      Coalesce([NullObj, NoNullObj, NullyFilledObj]));
        // Extension on collection
        NoNullRet(NullyFilledObj, new[] { NullObj, NullyFilledObj, NoNullObj }.Coalesce());
        // Extension first + params
        NoNullRet(NullyFilledObj, NullyFilledObj.Coalesce(NullObj, NullObj, NullObj));
        // Extension first + coll
        NoNullRet(NullyFilledObj, NullyFilledObj.Coalesce(new[] { NullObj, NullObj, NullObj }));
    }
}