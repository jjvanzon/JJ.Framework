namespace JJ.Framework.Existence.Core.Bool.Tests;

[TestClass]
public class Coalesce_3Args_Bool_Extensions : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch1()
    {
        NoNullRet(false, NullBool  .Coalesce(NullBool,   NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(NullBool,   NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(NullBool,   NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(NullBool,   False     ));
        NoNullRet(true,  NullBool  .Coalesce(NullBool,   True      ));
        NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(NullyFalse, NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(NullyFalse, NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(NullyFalse, False     ));
        NoNullRet(true,  NullBool  .Coalesce(NullyFalse, True      ));
        NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  False     ));
        NoNullRet(true,  NullBool  .Coalesce(NullyTrue,  True      ));
        NoNullRet(false, NullBool  .Coalesce(False,      NullBool  ));
        NoNullRet(false, NullBool  .Coalesce(False,      NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(False,      NullyTrue ));
        NoNullRet(false, NullBool  .Coalesce(False,      False     ));
        NoNullRet(true,  NullBool  .Coalesce(False,      True      ));
        NoNullRet(true,  NullBool  .Coalesce(True,       NullBool  ));
        NoNullRet(true,  NullBool  .Coalesce(True,       NullyFalse));
        NoNullRet(true,  NullBool  .Coalesce(True,       NullyTrue ));
        NoNullRet(true,  NullBool  .Coalesce(True,       False     ));
        NoNullRet(true,  NullBool  .Coalesce(True,       True      ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch2()
    {
        NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(NullBool,   NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(NullBool,   NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(NullBool,   False     ));
        NoNullRet(true,  NullyFalse.Coalesce(NullBool,   True      ));
        NoNullRet(false, NullyFalse.Coalesce(NullyFalse, NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(NullyFalse, NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(NullyFalse, NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(NullyFalse, False     ));
        NoNullRet(true,  NullyFalse.Coalesce(NullyFalse, True      ));
        NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullBool  ));
        NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  False     ));
        NoNullRet(true,  NullyFalse.Coalesce(NullyTrue,  True      ));
        NoNullRet(false, NullyFalse.Coalesce(False,      NullBool  ));
        NoNullRet(false, NullyFalse.Coalesce(False,      NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(False,      NullyTrue ));
        NoNullRet(false, NullyFalse.Coalesce(False,      False     ));
        NoNullRet(true,  NullyFalse.Coalesce(False,      True      ));
        NoNullRet(true,  NullyFalse.Coalesce(True,       NullBool  ));
        NoNullRet(true,  NullyFalse.Coalesce(True,       NullyFalse));
        NoNullRet(true,  NullyFalse.Coalesce(True,       NullyTrue ));
        NoNullRet(true,  NullyFalse.Coalesce(True,       False     ));
        NoNullRet(true,  NullyFalse.Coalesce(True,       True      ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch3()
    {
        NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(NullBool,   NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(NullBool,   False     ));
        NoNullRet(true,  NullyTrue .Coalesce(NullBool,   True      ));
        NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, False     ));
        NoNullRet(true,  NullyTrue .Coalesce(NullyFalse, True      ));
        NoNullRet(true,  NullyTrue .Coalesce(NullyTrue,  NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(NullyTrue,  NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(NullyTrue,  NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(NullyTrue,  False     ));
        NoNullRet(true,  NullyTrue .Coalesce(NullyTrue,  True      ));
        NoNullRet(true,  NullyTrue .Coalesce(False,      NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(False,      NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(False,      NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(False,      False     ));
        NoNullRet(true,  NullyTrue .Coalesce(False,      True      ));
        NoNullRet(true,  NullyTrue .Coalesce(True,       NullBool  ));
        NoNullRet(true,  NullyTrue .Coalesce(True,       NullyFalse));
        NoNullRet(true,  NullyTrue .Coalesce(True,       NullyTrue ));
        NoNullRet(true,  NullyTrue .Coalesce(True,       False     ));
        NoNullRet(true,  NullyTrue .Coalesce(True,       True      ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch4()
    {
        NoNullRet(false, False     .Coalesce(NullBool,   NullBool  ));
        NoNullRet(false, False     .Coalesce(NullBool,   NullyFalse));
        NoNullRet(true,  False     .Coalesce(NullBool,   NullyTrue ));
        NoNullRet(false, False     .Coalesce(NullBool,   False     ));
        NoNullRet(true,  False     .Coalesce(NullBool,   True      ));
        NoNullRet(false, False     .Coalesce(NullyFalse, NullBool  ));
        NoNullRet(false, False     .Coalesce(NullyFalse, NullyFalse));
        NoNullRet(true,  False     .Coalesce(NullyFalse, NullyTrue ));
        NoNullRet(false, False     .Coalesce(NullyFalse, False     ));
        NoNullRet(true,  False     .Coalesce(NullyFalse, True      ));
        NoNullRet(true,  False     .Coalesce(NullyTrue,  NullBool  ));
        NoNullRet(true,  False     .Coalesce(NullyTrue,  NullyFalse));
        NoNullRet(true,  False     .Coalesce(NullyTrue,  NullyTrue ));
        NoNullRet(true,  False     .Coalesce(NullyTrue,  False     ));
        NoNullRet(true,  False     .Coalesce(NullyTrue,  True      ));
        NoNullRet(false, False     .Coalesce(False,      NullBool  ));
        NoNullRet(false, False     .Coalesce(False,      NullyFalse));
        NoNullRet(true,  False     .Coalesce(False,      NullyTrue ));
        NoNullRet(false, False     .Coalesce(False,      False     ));
        NoNullRet(true,  False     .Coalesce(False,      True      ));
        NoNullRet(true,  False     .Coalesce(True,       NullBool  ));
        NoNullRet(true,  False     .Coalesce(True,       NullyFalse));
        NoNullRet(true,  False     .Coalesce(True,       NullyTrue ));
        NoNullRet(true,  False     .Coalesce(True,       False     ));
        NoNullRet(true,  False     .Coalesce(True,       True      ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch5()
    {
        NoNullRet(true,  True      .Coalesce(NullBool,   NullBool  ));
        NoNullRet(true,  True      .Coalesce(NullBool,   NullyFalse));
        NoNullRet(true,  True      .Coalesce(NullBool,   NullyTrue ));
        NoNullRet(true,  True      .Coalesce(NullBool,   False     ));
        NoNullRet(true,  True      .Coalesce(NullBool,   True      ));
        NoNullRet(true,  True      .Coalesce(NullyFalse, NullBool  ));
        NoNullRet(true,  True      .Coalesce(NullyFalse, NullyFalse));
        NoNullRet(true,  True      .Coalesce(NullyFalse, NullyTrue ));
        NoNullRet(true,  True      .Coalesce(NullyFalse, False     ));
        NoNullRet(true,  True      .Coalesce(NullyFalse, True      ));
        NoNullRet(true,  True      .Coalesce(NullyTrue,  NullBool  ));
        NoNullRet(true,  True      .Coalesce(NullyTrue,  NullyFalse));
        NoNullRet(true,  True      .Coalesce(NullyTrue,  NullyTrue ));
        NoNullRet(true,  True      .Coalesce(NullyTrue,  False     ));
        NoNullRet(true,  True      .Coalesce(NullyTrue,  True      ));
        NoNullRet(true,  True      .Coalesce(False,      NullBool  ));
        NoNullRet(true,  True      .Coalesce(False,      NullyFalse));
        NoNullRet(true,  True      .Coalesce(False,      NullyTrue ));
        NoNullRet(true,  True      .Coalesce(False,      False     ));
        NoNullRet(true,  True      .Coalesce(False,      True      ));
        NoNullRet(true,  True      .Coalesce(True,       NullBool  ));
        NoNullRet(true,  True      .Coalesce(True,       NullyFalse));
        NoNullRet(true,  True      .Coalesce(True,       NullyTrue ));
        NoNullRet(true,  True      .Coalesce(True,       False     ));
        NoNullRet(true,  True      .Coalesce(True,       True      ));
    }
}