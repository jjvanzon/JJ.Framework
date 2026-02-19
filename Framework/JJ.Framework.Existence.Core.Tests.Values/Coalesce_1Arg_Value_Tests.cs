namespace JJ.Framework.Existence.Core.Values.Tests;

[TestClass]
public class Coalesce_1Arg_Value_Tests : TestBase
{
    [TestMethod]
    public void Coalesce_1Arg_Vals_Literals()
    {
        NoNullRet(0, 0.Coalesce());
        NoNullRet(0, Coalesce(0) );
        NoNullRet(1, 1.Coalesce());
        NoNullRet(1, Coalesce(1) );
        NoNullRet(2, 2.Coalesce());
        NoNullRet(2, Coalesce(2) );
    }

    [TestMethod]
    public void Coalesce_1Arg_Vals_Nully_Vars()
    {
        IsNull   (         NullNum           );
        NullRet  (0,       Nully0            );
        NullRet  (1,       Nully1            );
        NullRet  (2,       Nully2            );
        NoNullRet(0,       NoNull0           );
        NoNullRet(1,       NoNull1           );
        NoNullRet(2,       NoNull2           );

        NoNullRet(NoNull0, NullNum.Coalesce());
        NoNullRet(NoNull0, Coalesce(NullNum) );
        NullRet  (NoNull0, Nully0            );
        NoNullRet(NoNull0, Nully0.Coalesce() );
        NoNullRet(NoNull0, Coalesce(Nully0)  );
        NullRet  (NoNull1, Nully1            );
        NoNullRet(NoNull1, Nully1.Coalesce() );
        NoNullRet(NoNull1, Coalesce(Nully1)  );
        NullRet  (NoNull2, Nully2            );
        NoNullRet(NoNull2, Nully2.Coalesce() );
        NoNullRet(NoNull2, Coalesce(Nully2)  );
    }
        
    [TestMethod]
    public void Coalesce_1Arg_Vals_NoNull_Vars()
    {
        NoNullRet(0, NoNull0           );
        NoNullRet(0, NoNull0.Coalesce());
        NoNullRet(0, Coalesce(NoNull0) );
        NoNullRet(3, NoNull3           );
        NoNullRet(3, NoNull3.Coalesce());
        NoNullRet(3, Coalesce(NoNull3) );
    }
}