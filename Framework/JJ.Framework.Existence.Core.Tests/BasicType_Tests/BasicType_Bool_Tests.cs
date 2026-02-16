namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class BasicType_Bool_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_3Arg_Bool_Examples()
    {
        IsTrue (Coalesce(False, NullyTrue, NullBool));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue));
    }
}