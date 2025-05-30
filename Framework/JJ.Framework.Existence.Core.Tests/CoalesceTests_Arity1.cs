namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class CoalesceTests_Arity1
{
    [TestMethod]
    public void Coalesce_Arity1_Text()
    {
        NoNullRet(""   , NullText.Coalesce());
        NoNullRet(""   , ""      .Coalesce());
        NoNullRet("   ", "   "   .Coalesce());
        NoNullRet("Hi" , "Hi"    .Coalesce());
        NoNullRet(""   , Coalesce(NullText ));
        NoNullRet(""   , Coalesce(""       ));
        NoNullRet("   ", Coalesce("   "    ));
        NoNullRet("Hi" , Coalesce("Hi"     ));
    }
    
    [TestMethod]
    public void Coalesce_Arity1_NullyVals()
    {
        NullRet  (null, NullNum           );
        NoNullRet(0,    NullNum.Coalesce());
        NoNullRet(0,    Coalesce(NullNum) );
        NullRet  (0,    Nully0            );
        NoNullRet(0,    Nully0.Coalesce() );
        NoNullRet(0,    Coalesce(Nully0)  );
        NullRet  (1,    Nully1            );
        NoNullRet(1,    Nully1.Coalesce() );
        NoNullRet(1,    Coalesce(Nully1)  );
        NullRet  (2,    Nully2            );
        NoNullRet(2,    Nully2.Coalesce() );
        NoNullRet(2,    Coalesce(Nully2)  );
    }
    
    [TestMethod]
    public void Coalesce_Arity1_NonNulVals()
    {
        int nonNull = 3;
        NoNullRet(3, nonNull);
        NoNullRet(3, nonNull.Coalesce());
        NoNullRet(3, Coalesce(nonNull) );
    }
    
    [TestMethod]
    public void Coalesce_Arity1_Objects()
    {
        NoNullRet(NoNullObj);
        NoNullRet(Coalesce(NoNullObj));
        NoNullRet(NoNullObj.Coalesce());
        
        IsNull(NullObj);
        NoNullRet(Coalesce(NullObj));
        NoNullRet(NullObj.Coalesce());
    }
    
    [TestMethod]
    public void Coalesce_Arity1_Collections()
    {
        List<string>? coll = null;
        List<string> result = Coalesce( [ coll ] );
        IsNull(coll);
        NoNullRet(Coalesce(coll));
    }
}