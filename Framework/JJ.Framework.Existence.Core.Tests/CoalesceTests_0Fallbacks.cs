namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class CoalesceTests_0Fallbacks
{
    [TestMethod]
    public void Plain_Coalesce()
    {
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
        {
            AreEqual(0,            NullNum.Coalesce());
            AreEqual(0,            Coalesce(NullNum));
            AreEqual(typeof(int?), CompileTimeType(NullNum));
            AreEqual(typeof(int),  CompileTimeType(NullNum.Coalesce()));
            AreEqual(typeof(int),  CompileTimeType(Coalesce(NullNum)));
            
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
        {
            int nonNull = 1;
            AreEqual(1,           nonNull);
            AreEqual(1,           nonNull.Coalesce());
            AreEqual(1,           Coalesce(nonNull));
            AreEqual(typeof(int), CompileTimeType(nonNull));
            AreEqual(typeof(int), CompileTimeType(nonNull.Coalesce()));
            AreEqual(typeof(int), CompileTimeType(Coalesce(nonNull)));
        }
        {
            NotNull(NonNullObject);
            NotNull(Coalesce(NonNullObject));
            NotNull(NonNullObject.Coalesce());
            
            IsNull (NullObject);
            NotNull(Coalesce(NullObject));
            NotNull(NullObject.Coalesce());
        }
        {
            List<string>? coll = null;
            List<string> result = Coalesce(coll);
            IsNull(coll);
            NotNull(result);
        }
    }
}