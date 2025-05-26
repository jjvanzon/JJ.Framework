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
        IsNull      (   NullNum           );
        IsType<int?>(   NullNum           );
        AreEqual    (0, NullNum.Coalesce());
        IsType<int> (   NullNum.Coalesce());
        AreEqual    (0, Coalesce(NullNum) );
        IsType<int> (   Coalesce(NullNum) );
        AreEqual    (0, Nully0            );
        IsType<int?>(   Nully0            );
        AreEqual    (0, Nully0 .Coalesce());
        IsType<int> (   Nully0 .Coalesce());
        AreEqual    (0, Coalesce(Nully0)  );
        IsType<int> (   Coalesce(Nully0)  );
        AreEqual    (1, Nully1            );
        IsType<int?>(   Nully1            );
        AreEqual    (1, Nully1 .Coalesce());
        IsType<int> (   Nully1 .Coalesce());
        AreEqual    (1, Coalesce(Nully1)  );
        IsType<int> (   Coalesce(Nully1)  );
    }
    
    [TestMethod]
    public void Coalesce_Structs_NotNullable_NoFallback()
    {
        int nonNull = 1;
        AreEqual   (1, nonNull           );
        IsType<int>(   nonNull           );
        AreEqual   (1, nonNull.Coalesce());
        IsType<int>(   nonNull.Coalesce());
        AreEqual   (1, Coalesce(nonNull) );
        IsType<int>(   Coalesce(nonNull) );
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