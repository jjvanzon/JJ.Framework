namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Bool_Static
{
    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch1()
    {
        NoNullRet(0, Coalesce(NullNum, NullNum, NullNum));
        NoNullRet(0, Coalesce(NullNum, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(NullNum, NullNum, Nully1 ));
        NoNullRet(0, Coalesce(NullNum, NullNum, NoNull0));
        NoNullRet(1, Coalesce(NullNum, NullNum, NoNull1));
        NoNullRet(0, Coalesce(NullNum, Nully0,  NullNum));
        NoNullRet(0, Coalesce(NullNum, Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(NullNum, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(NullNum, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(NullNum, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(NullNum, Nully1,  NullNum));
        NoNullRet(1, Coalesce(NullNum, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(NullNum, Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(NullNum, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(NullNum, Nully1,  NoNull1));
        NoNullRet(0, Coalesce(NullNum, NoNull0, NullNum));
        NoNullRet(0, Coalesce(NullNum, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(NullNum, NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(NullNum, NoNull0, NoNull0));
        NoNullRet(1, Coalesce(NullNum, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(NullNum, NoNull1, NullNum));
        NoNullRet(1, Coalesce(NullNum, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(NullNum, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(NullNum, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(NullNum, NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch2()
    {
        NoNullRet(0, Coalesce(Nully0,  NullNum, NullNum));
        NoNullRet(0, Coalesce(Nully0,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  NullNum, Nully1 ));
        NoNullRet(0, Coalesce(Nully0,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(Nully0,  NullNum, NoNull1));
        NoNullRet(0, Coalesce(Nully0,  Nully0,  NullNum));
        NoNullRet(0, Coalesce(Nully0,  Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(Nully0,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(Nully0,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  NullNum));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  NoNull0));
        NoNullRet(1, Coalesce(Nully0,  Nully1,  NoNull1));
        NoNullRet(0, Coalesce(Nully0,  NoNull0, NullNum));
        NoNullRet(0, Coalesce(Nully0,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(Nully0,  NoNull0, NoNull0));
        NoNullRet(1, Coalesce(Nully0,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(Nully0,  NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch3()
    {
        NoNullRet(1, Coalesce(Nully1,  NullNum, NullNum));
        NoNullRet(1, Coalesce(Nully1,  NullNum, Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  NullNum, Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  NullNum, NoNull0));
        NoNullRet(1, Coalesce(Nully1,  NullNum, NoNull1));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  NullNum));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  NoNull0));
        NoNullRet(1, Coalesce(Nully1,  Nully0,  NoNull1));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  NullNum));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  NoNull0));
        NoNullRet(1, Coalesce(Nully1,  Nully1,  NoNull1));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, NullNum));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, NoNull0));
        NoNullRet(1, Coalesce(Nully1,  NoNull0, NoNull1));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, NullNum));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, NoNull0));
        NoNullRet(1, Coalesce(Nully1,  NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch4()
    {
        NoNullRet(0, Coalesce(NoNull0, NullNum, NullNum));
        NoNullRet(0, Coalesce(NoNull0, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, NullNum, Nully1 ));
        NoNullRet(0, Coalesce(NoNull0, NullNum, NoNull0));
        NoNullRet(1, Coalesce(NoNull0, NullNum, NoNull1));
        NoNullRet(0, Coalesce(NoNull0, Nully0,  NullNum));
        NoNullRet(0, Coalesce(NoNull0, Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, Nully0,  Nully1 ));
        NoNullRet(0, Coalesce(NoNull0, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(NoNull0, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  NullNum));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(NoNull0, Nully1,  NoNull1));
        NoNullRet(0, Coalesce(NoNull0, NoNull0, NullNum));
        NoNullRet(0, Coalesce(NoNull0, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, NoNull0, Nully1 ));
        NoNullRet(0, Coalesce(NoNull0, NoNull0, NoNull0));
        NoNullRet(1, Coalesce(NoNull0, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, NullNum));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(NoNull0, NoNull1, NoNull1));
    }

    [TestMethod]
    public void Coalesce_3Args_Bool_Static_Batch5()
    {
        NoNullRet(1, Coalesce(NoNull1, NullNum, NullNum));
        NoNullRet(1, Coalesce(NoNull1, NullNum, Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, NullNum, Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, NullNum, NoNull0));
        NoNullRet(1, Coalesce(NoNull1, NullNum, NoNull1));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  NullNum));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  NoNull0));
        NoNullRet(1, Coalesce(NoNull1, Nully0,  NoNull1));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  NullNum));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  NoNull0));
        NoNullRet(1, Coalesce(NoNull1, Nully1,  NoNull1));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, NullNum));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, NoNull0));
        NoNullRet(1, Coalesce(NoNull1, NoNull0, NoNull1));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, NullNum));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, Nully0 ));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, Nully1 ));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, NoNull0));
        NoNullRet(1, Coalesce(NoNull1, NoNull1, NoNull1));
    }
}