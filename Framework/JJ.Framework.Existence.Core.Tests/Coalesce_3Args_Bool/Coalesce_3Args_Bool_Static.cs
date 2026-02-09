namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Bool_Static : TestBase
{
    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch1()
    {
        NoNullRet(false, Coalesce(NullBool,   NullBool,   NullBool  ));
        NoNullRet(false, Coalesce(NullBool,   NullBool,   NullyFalse));
        NoNullRet(true,  Coalesce(NullBool,   NullBool,   NullyTrue ));
        NoNullRet(false, Coalesce(NullBool,   NullBool,   False     ));
        NoNullRet(true,  Coalesce(NullBool,   NullBool,   True      ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullBool  ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, NullyFalse));
        NoNullRet(true,  Coalesce(NullBool,   NullyFalse, NullyTrue ));
        NoNullRet(false, Coalesce(NullBool,   NullyFalse, False     ));
        NoNullRet(true,  Coalesce(NullBool,   NullyFalse, True      ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  NullyTrue ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(NullBool,   NullyTrue,  True      ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullBool  ));
        NoNullRet(false, Coalesce(NullBool,   False,      NullyFalse));
        NoNullRet(true,  Coalesce(NullBool,   False,      NullyTrue ));
        NoNullRet(false, Coalesce(NullBool,   False,      False     ));
        NoNullRet(true,  Coalesce(NullBool,   False,      True      ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullBool  ));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyFalse));
        NoNullRet(true,  Coalesce(NullBool,   True,       NullyTrue ));
        NoNullRet(true,  Coalesce(NullBool,   True,       False     ));
        NoNullRet(true,  Coalesce(NullBool,   True,       True      ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch2()
    {
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullBool  ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   NullyFalse));
        NoNullRet(true,  Coalesce(NullyFalse, NullBool,   NullyTrue ));
        NoNullRet(false, Coalesce(NullyFalse, NullBool,   False     ));
        NoNullRet(true,  Coalesce(NullyFalse, NullBool,   True      ));
        NoNullRet(false, Coalesce(NullyFalse, NullyFalse, NullBool  ));
        NoNullRet(false, Coalesce(NullyFalse, NullyFalse, NullyFalse));
        NoNullRet(true,  Coalesce(NullyFalse, NullyFalse, NullyTrue ));
        NoNullRet(false, Coalesce(NullyFalse, NullyFalse, False     ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyFalse, True      ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  NullyTrue ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(NullyFalse, NullyTrue,  True      ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullBool  ));
        NoNullRet(false, Coalesce(NullyFalse, False,      NullyFalse));
        NoNullRet(true,  Coalesce(NullyFalse, False,      NullyTrue ));
        NoNullRet(false, Coalesce(NullyFalse, False,      False     ));
        NoNullRet(true,  Coalesce(NullyFalse, False,      True      ));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullBool  ));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullyFalse));
        NoNullRet(true,  Coalesce(NullyFalse, True,       NullyTrue ));
        NoNullRet(true,  Coalesce(NullyFalse, True,       False     ));
        NoNullRet(true,  Coalesce(NullyFalse, True,       True      ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch3()
    {
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullBool  ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyFalse));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   False     ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullBool,   True      ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullBool  ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullyFalse));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, NullyTrue ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, False     ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyFalse, True      ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyTrue,  NullyTrue ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(NullyTrue,  NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullBool  ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyFalse));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      NullyTrue ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      False     ));
        NoNullRet(true,  Coalesce(NullyTrue,  False,      True      ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullBool  ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyFalse));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       NullyTrue ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       False     ));
        NoNullRet(true,  Coalesce(NullyTrue,  True,       True      ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch4()
    {
        NoNullRet(false, Coalesce(False,      NullBool,   NullBool  ));
        NoNullRet(false, Coalesce(False,      NullBool,   NullyFalse));
        NoNullRet(true,  Coalesce(False,      NullBool,   NullyTrue ));
        NoNullRet(false, Coalesce(False,      NullBool,   False     ));
        NoNullRet(true,  Coalesce(False,      NullBool,   True      ));
        NoNullRet(false, Coalesce(False,      NullyFalse, NullBool  ));
        NoNullRet(false, Coalesce(False,      NullyFalse, NullyFalse));
        NoNullRet(true,  Coalesce(False,      NullyFalse, NullyTrue ));
        NoNullRet(false, Coalesce(False,      NullyFalse, False     ));
        NoNullRet(true,  Coalesce(False,      NullyFalse, True      ));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  NullyTrue ));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(False,      NullyTrue,  True      ));
        NoNullRet(false, Coalesce(False,      False,      NullBool  ));
        NoNullRet(false, Coalesce(False,      False,      NullyFalse));
        NoNullRet(true,  Coalesce(False,      False,      NullyTrue ));
        NoNullRet(false, Coalesce(False,      False,      False     ));
        NoNullRet(true,  Coalesce(False,      False,      True      ));
        NoNullRet(true,  Coalesce(False,      True,       NullBool  ));
        NoNullRet(true,  Coalesce(False,      True,       NullyFalse));
        NoNullRet(true,  Coalesce(False,      True,       NullyTrue ));
        NoNullRet(true,  Coalesce(False,      True,       False     ));
        NoNullRet(true,  Coalesce(False,      True,       True      ));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch5()
    {
        NoNullRet(true,  Coalesce(True,       NullBool,   NullBool  ));
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyFalse));
        NoNullRet(true,  Coalesce(True,       NullBool,   NullyTrue ));
        NoNullRet(true,  Coalesce(True,       NullBool,   False     ));
        NoNullRet(true,  Coalesce(True,       NullBool,   True      ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullBool  ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullyFalse));
        NoNullRet(true,  Coalesce(True,       NullyFalse, NullyTrue ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, False     ));
        NoNullRet(true,  Coalesce(True,       NullyFalse, True      ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullBool  ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullyFalse));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  NullyTrue ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  False     ));
        NoNullRet(true,  Coalesce(True,       NullyTrue,  True      ));
        NoNullRet(true,  Coalesce(True,       False,      NullBool  ));
        NoNullRet(true,  Coalesce(True,       False,      NullyFalse));
        NoNullRet(true,  Coalesce(True,       False,      NullyTrue ));
        NoNullRet(true,  Coalesce(True,       False,      False     ));
        NoNullRet(true,  Coalesce(True,       False,      True      ));
        NoNullRet(true,  Coalesce(True,       True,       NullBool  ));
        NoNullRet(true,  Coalesce(True,       True,       NullyFalse));
        NoNullRet(true,  Coalesce(True,       True,       NullyTrue ));
        NoNullRet(true,  Coalesce(True,       True,       False     ));
        NoNullRet(true,  Coalesce(True,       True,       True      ));
    }
}