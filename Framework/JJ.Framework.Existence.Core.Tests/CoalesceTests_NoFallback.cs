namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class CoalesceTests_NoFallback
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
        AreEqual(0,            NullNum.Coalesce());
        AreEqual(0,            Coalesce(NullNum));
        AreEqual(typeof(int?), CompileTimeType(NullNum));
        AreEqual(typeof(int),  CompileTimeType(NullNum.Coalesce()));
        AreEqual(typeof(int),  CompileTimeType(Coalesce(NullNum)));
        //IsType<int?>(NullNum);
        //IsType<int>(NullNum.Coalesce());
        //IsType<int>(Coalesce(NullNum));
        
        AreEqual(0,            Nully0);
        AreEqual(0,            Nully0.Coalesce());
        AreEqual(0,            Coalesce(Nully0));
        AreEqual(typeof(int?), CompileTimeType(Nully0));
        AreEqual(typeof(int),  CompileTimeType(Nully0.Coalesce()));
        AreEqual(typeof(int),  CompileTimeType(Coalesce(Nully0)));
        
        AreEqual(1,            Nully1);
        AreEqual(1,            Nully1.Coalesce());
        AreEqual(1,            Coalesce(Nully1));
        AreEqual(typeof(int?), CompileTimeType(Nully1));
        AreEqual(typeof(int),  CompileTimeType(Nully1.Coalesce()));
        AreEqual(typeof(int),  CompileTimeType(Coalesce(Nully1)));
    }
    
    [TestMethod]
    public void Coalesce_Structs_NotNullable_NoFallback()
    {
        int nonNull = 1;
        AreEqual(1,           nonNull);
        AreEqual(1,           nonNull.Coalesce());
        AreEqual(1,           Coalesce(nonNull));
        AreEqual(typeof(int), CompileTimeType(nonNull));
        AreEqual(typeof(int), CompileTimeType(nonNull.Coalesce()));
        AreEqual(typeof(int), CompileTimeType(Coalesce(nonNull)));
    }
    
    [TestMethod]
    public void Coalesce_Objects_NoFallback()
    {
        NotNull(NonNullObject);
        NotNull(Coalesce(NonNullObject));
        NotNull(NonNullObject.Coalesce());
        
        IsNull (NullObject);
        NotNull(Coalesce(NullObject));
        NotNull(NullObject.Coalesce());
    }
    
    [TestMethod]
    public void Coalesce_Collection_NoFallback()
    {
        List<string>? coll = null;
        List<string> result = Coalesce(coll);
        IsNull(coll);
        NotNull(result);
    }
}