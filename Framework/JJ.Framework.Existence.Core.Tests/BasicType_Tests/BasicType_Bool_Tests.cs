namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class BasicType_Bool_Tests : TestBase
{
    [TestMethod]
    public void Test_Bool_Coalesce()
    {
        IsTrue (Coalesce(False, NullyTrue, NullBool));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue));
        IsFalse(NullyFalse.Coalesce(NullBool));
    }
}