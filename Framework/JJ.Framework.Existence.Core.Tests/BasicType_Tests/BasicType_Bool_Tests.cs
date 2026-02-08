namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class BasicType_Bool_Tests : TestBase
{
    [TestMethod]
    public void Test_Bool_IsNully()
    {
        IsFalse(IsNully (true));
        IsTrue (IsNully (false));
        IsFalse(IsNully (True));
        IsTrue (IsNully (False));
        IsFalse(IsNully (NullyTrue));
        IsTrue (IsNully (NullyFalse));
        IsTrue (IsNully (NullBool));

        IsFalse(true.IsNully ());
        IsTrue (false.IsNully ());
        IsFalse(True.IsNully ());
        IsTrue (False.IsNully ());
        IsFalse(NullyTrue.IsNully ());
        IsTrue (NullyFalse.IsNully ());
        IsTrue (NullBool.IsNully ());
    }

    [TestMethod]
    public void Test_Bool_Coalesce()
    {
        IsTrue (Coalesce(False, NullyTrue, NullBool));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue));
        IsFalse(NullyFalse.Coalesce(NullBool));
    }
}