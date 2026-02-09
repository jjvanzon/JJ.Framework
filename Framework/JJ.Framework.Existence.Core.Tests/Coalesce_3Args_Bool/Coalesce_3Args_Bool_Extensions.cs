namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Bool_Extensions
{
    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch1()
    {
        NoNullRet(0, NullNum.Coalesce(NullNum, NullNum));
        NoNullRet(0, NullNum.Coalesce(NullNum, Nully0 ));
        NoNullRet(1, NullNum.Coalesce(NullNum, Nully1 ));
        NoNullRet(0, NullNum.Coalesce(NullNum, NoNull0));
        NoNullRet(1, NullNum.Coalesce(NullNum, NoNull1));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NullNum));
        NoNullRet(0, NullNum.Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, NullNum.Coalesce(Nully0,  Nully1 ));
        NoNullRet(0, NullNum.Coalesce(Nully0,  NoNull0));
        NoNullRet(1, NullNum.Coalesce(Nully0,  NoNull1));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NullNum));
        NoNullRet(1, NullNum.Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull0));
        NoNullRet(1, NullNum.Coalesce(Nully1,  NoNull1));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NullNum));
        NoNullRet(0, NullNum.Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, NullNum.Coalesce(NoNull0, Nully1 ));
        NoNullRet(0, NullNum.Coalesce(NoNull0, NoNull0));
        NoNullRet(1, NullNum.Coalesce(NoNull0, NoNull1));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NullNum));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NoNull0));
        NoNullRet(1, NullNum.Coalesce(NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch2()
    {
        NoNullRet(0, Nully0 .Coalesce(NullNum, NullNum));
        NoNullRet(0, Nully0 .Coalesce(NullNum, Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(NullNum, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(NullNum, NoNull0));
        NoNullRet(1, Nully0 .Coalesce(NullNum, NoNull1));
        NoNullRet(0, Nully0 .Coalesce(Nully0,  NullNum));
        NoNullRet(0, Nully0 .Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(Nully0,  Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(Nully0,  NoNull0));
        NoNullRet(1, Nully0 .Coalesce(Nully0,  NoNull1));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NullNum));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull0));
        NoNullRet(1, Nully0 .Coalesce(Nully1,  NoNull1));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NullNum));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(NoNull0, Nully1 ));
        NoNullRet(0, Nully0 .Coalesce(NoNull0, NoNull0));
        NoNullRet(1, Nully0 .Coalesce(NoNull0, NoNull1));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NullNum));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NoNull0));
        NoNullRet(1, Nully0 .Coalesce(NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch3()
    {
        NoNullRet(1, Nully1 .Coalesce(NullNum, NullNum));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(NullNum, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(Nully0,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  NullNum));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  NoNull0));
        NoNullRet(1, Nully1 .Coalesce(Nully1,  NoNull1));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NullNum));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(NoNull0, NoNull1));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NullNum));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull0));
        NoNullRet(1, Nully1 .Coalesce(NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch4()
    {
        NoNullRet(0, NoNull0.Coalesce(NullNum, NullNum));
        NoNullRet(0, NoNull0.Coalesce(NullNum, Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(NullNum, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(NullNum, NoNull0));
        NoNullRet(1, NoNull0.Coalesce(NullNum, NoNull1));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NullNum));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(Nully0,  Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(Nully0,  NoNull0));
        NoNullRet(1, NoNull0.Coalesce(Nully0,  NoNull1));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NullNum));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull0));
        NoNullRet(1, NoNull0.Coalesce(Nully1,  NoNull1));
        NoNullRet(0, NoNull0.Coalesce(NoNull0, NullNum));
        NoNullRet(0, NoNull0.Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(NoNull0, Nully1 ));
        NoNullRet(0, NoNull0.Coalesce(NoNull0, NoNull0));
        NoNullRet(1, NoNull0.Coalesce(NoNull0, NoNull1));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NullNum));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NoNull0));
        NoNullRet(1, NoNull0.Coalesce(NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Extensions_Batch5()
    {
        NoNullRet(1, NoNull1.Coalesce(NullNum, NullNum));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(NullNum, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(Nully0,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NullNum));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull0));
        NoNullRet(1, NoNull1.Coalesce(Nully1,  NoNull1));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NullNum));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(NoNull0, NoNull1));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, NullNum));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, Nully0 ));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, Nully1 ));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, NoNull0));
        NoNullRet(1, NoNull1.Coalesce(NoNull1, NoNull1));
    }
}