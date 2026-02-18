namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_1Arg_Object_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_1Arg_Obj_Vars()
    {
        NoNullRet(NoNullObj);
        NoNullRet(Coalesce(NoNullObj));
        NoNullRet(NoNullObj.Coalesce());
        
        IsNull(NullObj);
        NoNullRet(Coalesce(NullObj));
        NoNullRet(NullObj.Coalesce());

        NotNull(NullyFilledObj);
        NoNullRet(Coalesce(NullyFilledObj));
        NoNullRet(NullyFilledObj.Coalesce());
    }
}