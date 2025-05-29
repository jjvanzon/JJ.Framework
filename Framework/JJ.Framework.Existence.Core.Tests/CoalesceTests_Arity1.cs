namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class CoalesceTests_Arity1
{
    [TestMethod]
    public void Coalesce_Strings_NoFallback()
    {
        AreEqual(""   , NullText.Coalesce());
        AreEqual(""   , ""      .Coalesce());
        AreEqual("   ", "   "   .Coalesce());
        AreEqual("Hi" , "Hi"    .Coalesce());
        AreEqual(""   , Coalesce(NullText ));
        AreEqual(""   , Coalesce(""       ));
        AreEqual("   ", Coalesce("   "    ));
        AreEqual("Hi" , Coalesce("Hi"     ));
    }
    
    [TestMethod]
    public void Coalesce_Structs_Nullable_NoFallback()
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
    public void Coalesce_Structs_NotNullable_NoFallback()
    {
        int nonNull = 3;
        NoNullRet(3, nonNull);
        NoNullRet(3, nonNull.Coalesce());
        NoNullRet(3, Coalesce(nonNull) );
    }
    
    [TestMethod]
    public void Coalesce_Objects_NoFallback()
    {
        NoNullRet(NonNullObj);
        NoNullRet(Coalesce(NonNullObj));
        NoNullRet(NonNullObj.Coalesce());
        
        IsNull(NullObj);
        NoNullRet(Coalesce(NullObj));
        NoNullRet(NullObj.Coalesce());
    }
    
    [TestMethod]
    public void Coalesce_Collection_NoFallback()
    {
        List<string>? coll = null;
        List<string> result = Coalesce( [ coll ] );
        IsNull(coll);
        NoNullRet(Coalesce(coll));
    }
}