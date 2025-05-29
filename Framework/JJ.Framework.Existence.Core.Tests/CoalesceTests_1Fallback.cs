namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class CoalesceTests_1Fallback
{
    // Should check:
    // - [x] int
    // - [x] int?
    // - [x] string
    // - [x] string?
    // - [x] Reference Types (StringBuilder)
    // - [x] Nullable reference types (StringBuilder?)
    // - [x] ~ Coalescing from collection to collection
    // - [x] Collection types
    // - [x] Trim tolerance
    // - [x] Static variant
    // - [x] Extension variant
    // - [ ] Enum
    // - [ ] Enum?
    // - [ ] double
    // - [ ] bool
    // - [ ] .. Coalesce arities
    
    [TestMethod]
    public void Coalesce_SingleFallback_Strings()
    {
        AreEqual("",         Coalesce(NullText,  NullText ));
        AreEqual("Fallback", Coalesce(NullText, "Fallback"));
        AreEqual("Fallback", Coalesce("",       "Fallback"));
        AreEqual("Fallback", Coalesce("   ",    "Fallback"));
        AreEqual("Fallback", Coalesce(NullText, "Fallback", trimSpace: true ));
        AreEqual("Fallback", Coalesce("",       "Fallback", trimSpace: true ));
        AreEqual("Fallback", Coalesce("   ",    "Fallback", trimSpace: true ));
        AreEqual("Fallback", Coalesce(NullText, "Fallback", trimSpace: false));
        AreEqual("Fallback", Coalesce("",       "Fallback", trimSpace: false));
        AreEqual("   ",      Coalesce("   ",    "Fallback", trimSpace: false));
        
        AreEqual("",         NullText.Coalesce( NullText ));
        AreEqual("Fallback", NullText.Coalesce("Fallback"));
        AreEqual("Fallback", ""      .Coalesce("Fallback"));
        AreEqual("Fallback", "   "   .Coalesce("Fallback"));
        AreEqual("Fallback", NullText.Coalesce("Fallback", trimSpace: true ));
        AreEqual("Fallback", ""      .Coalesce("Fallback", trimSpace: true ));
        AreEqual("Fallback", "   "   .Coalesce("Fallback", trimSpace: true ));
        AreEqual("Fallback", NullText.Coalesce("Fallback", trimSpace: false));
        AreEqual("Fallback", ""      .Coalesce("Fallback", trimSpace: false));
        AreEqual("   ",      "   "   .Coalesce("Fallback", trimSpace: false));
    }

    [TestMethod]
    public void Coalesce_SingleFallback_ObjectToString()
    {
        AreEqual("None",    Coalesce(NullObj,    "None"));
        AreEqual("NonNull", Coalesce(NonNullObj, "None"));
        AreEqual("Filled",  Coalesce(NullyFilled,   "None"));
        AreEqual("NonNull", NonNullObj.Coalesce( "None"));
        AreEqual("None",    NullObj   .Coalesce( "None"));
        AreEqual("Filled",  NullyFilled  .Coalesce( "None"));
    }

    [TestMethod]
    public void Coalesce_SingleFallback_StructToString()
    {
        // With T
        AreEqual("",           Coalesce(0,  NullText ));
        AreEqual("",           Coalesce(0,  NullText ));
        AreEqual("peekaboo",   Coalesce(0, "peekaboo"));
        AreEqual("",         0.Coalesce(    NullText ));
        AreEqual("peekaboo", 0.Coalesce(   "peekaboo"));
        AreEqual("1",        1.Coalesce(    NullText ));
        AreEqual("1",        1.Coalesce(   "peekaboo"));
        // With T?
        AreEqual("",    Coalesce(NullNum,  NullText));
        AreEqual("boo", Coalesce(NullNum, "boo"    ));
        AreEqual("",    Coalesce(Nully0,   NullText));
        AreEqual("boo", Coalesce(Nully0,  "boo"    ));
        AreEqual("1",   Coalesce(Nully1,   NullText));
        AreEqual("1",   Coalesce(Nully1,  "boo"    ));
        AreEqual("",    NullNum.Coalesce(  NullText));
        AreEqual("boo", NullNum.Coalesce( "boo"    ));
        AreEqual("",    Nully0 .Coalesce(  NullText));
        AreEqual("boo", Nully0 .Coalesce( "boo"    ));
        AreEqual("1",   Nully1 .Coalesce(  NullText));
        AreEqual("1",   Nully1 .Coalesce( "boo"    ));
    }

    [TestMethod]
    public void Coalesce_SingleFallback_Structs()
    {
        // Assert input state
        NullRet(null, NullNum);
        NullRet(0,    Nully0);
        NullRet(1,    Nully1);
        NullRet(2,    Nully2);
        NoNullRet(0);
        NoNullRet(1);
        NoNullRet(2);
        
        // Assert results
        NoNullRet(0, Coalesce( NullNum, NullNum));
        NoNullRet(0, Coalesce(  Nully0, NullNum));
        NoNullRet(1, Coalesce(  Nully1, NullNum));
        NoNullRet(2, Coalesce(  Nully2, NullNum));
        NoNullRet(0, Coalesce(       0, NullNum));
        NoNullRet(1, Coalesce(       1, NullNum));
        NoNullRet(2, Coalesce(       2, NullNum));
        NoNullRet(0, Coalesce( NullNum,  Nully0));
        NoNullRet(0, Coalesce(  Nully0,  Nully0));
        NoNullRet(1, Coalesce(  Nully1,  Nully0));
        NoNullRet(2, Coalesce(  Nully2,  Nully0));
        NoNullRet(0, Coalesce(       0,  Nully0));
        NoNullRet(1, Coalesce(       1,  Nully0));
        NoNullRet(2, Coalesce(       2,  Nully0));
        NoNullRet(1, Coalesce( NullNum,  Nully1));
        NoNullRet(1, Coalesce(  Nully0,  Nully1));
        NoNullRet(1, Coalesce(  Nully1,  Nully1));
        NoNullRet(2, Coalesce(  Nully2,  Nully1));
        NoNullRet(1, Coalesce(       0,  Nully1));
        NoNullRet(1, Coalesce(       1,  Nully1));
        NoNullRet(2, Coalesce(       2,  Nully1));
        NoNullRet(2, Coalesce( NullNum,  Nully2));
        NoNullRet(2, Coalesce(  Nully0,  Nully2));
        NoNullRet(1, Coalesce(  Nully1,  Nully2));
        NoNullRet(2, Coalesce(  Nully2,  Nully2));
        NoNullRet(2, Coalesce(       0,  Nully2));
        NoNullRet(1, Coalesce(       1,  Nully2));
        NoNullRet(2, Coalesce(       2,  Nully2));
        NoNullRet(0, Coalesce( NullNum,       0));
        NoNullRet(0, Coalesce(  Nully0,       0));
        NoNullRet(1, Coalesce(  Nully1,       0));
        NoNullRet(2, Coalesce(  Nully2,       0));
        NoNullRet(0, Coalesce(       0,       0));
        NoNullRet(1, Coalesce(       1,       0));
        NoNullRet(2, Coalesce(       2,       0));
        NoNullRet(1, Coalesce( NullNum,       1));
        NoNullRet(1, Coalesce(  Nully0,       1));
        NoNullRet(1, Coalesce(  Nully1,       1));
        NoNullRet(2, Coalesce(  Nully2,       1));
        NoNullRet(1, Coalesce(       0,       1));
        NoNullRet(1, Coalesce(       1,       1));
        NoNullRet(2, Coalesce(       2,       1));
        NoNullRet(2, Coalesce( NullNum,       2));
        NoNullRet(2, Coalesce(  Nully0,       2));
        NoNullRet(1, Coalesce(  Nully1,       2));
        NoNullRet(2, Coalesce(  Nully2,       2));
        NoNullRet(2, Coalesce(       0,       2));
        NoNullRet(1, Coalesce(       1,       2));
        NoNullRet(2, Coalesce(       2,       2));
        NoNullRet(0,  NullNum.Coalesce( NullNum));
        NoNullRet(0,   Nully0.Coalesce( NullNum));
        NoNullRet(1,   Nully1.Coalesce( NullNum));
        NoNullRet(2,   Nully2.Coalesce( NullNum));
        NoNullRet(0,        0.Coalesce( NullNum));
        NoNullRet(1,        1.Coalesce( NullNum));
        NoNullRet(2,        2.Coalesce( NullNum));
        NoNullRet(0,  NullNum.Coalesce(  Nully0));
        NoNullRet(0,   Nully0.Coalesce(  Nully0));
        NoNullRet(1,   Nully1.Coalesce(  Nully0));
        NoNullRet(2,   Nully2.Coalesce(  Nully0));
        NoNullRet(0,        0.Coalesce(  Nully0));
        NoNullRet(1,        1.Coalesce(  Nully0));
        NoNullRet(2,        2.Coalesce(  Nully0));
        NoNullRet(1,  NullNum.Coalesce(  Nully1));
        NoNullRet(1,   Nully0.Coalesce(  Nully1));
        NoNullRet(1,   Nully1.Coalesce(  Nully1));
        NoNullRet(2,   Nully2.Coalesce(  Nully1));
        NoNullRet(1,        0.Coalesce(  Nully1));
        NoNullRet(1,        1.Coalesce(  Nully1));
        NoNullRet(2,        2.Coalesce(  Nully1));
        NoNullRet(2,  NullNum.Coalesce(  Nully2));
        NoNullRet(2,   Nully0.Coalesce(  Nully2));
        NoNullRet(1,   Nully1.Coalesce(  Nully2));
        NoNullRet(2,   Nully2.Coalesce(  Nully2));
        NoNullRet(2,        0.Coalesce(  Nully2));
        NoNullRet(1,        1.Coalesce(  Nully2));
        NoNullRet(2,        2.Coalesce(  Nully2));
        NoNullRet(0,  NullNum.Coalesce(       0));
        NoNullRet(0,   Nully0.Coalesce(       0));
        NoNullRet(1,   Nully1.Coalesce(       0));
        NoNullRet(2,   Nully2.Coalesce(       0));
        NoNullRet(0,        0.Coalesce(       0));
        NoNullRet(1,        1.Coalesce(       0));
        NoNullRet(2,        2.Coalesce(       0));
        NoNullRet(1,  NullNum.Coalesce(       1));
        NoNullRet(1,   Nully0.Coalesce(       1));
        NoNullRet(1,   Nully1.Coalesce(       1));
        NoNullRet(2,   Nully2.Coalesce(       1));
        NoNullRet(1,        0.Coalesce(       1));
        NoNullRet(1,        1.Coalesce(       1));
        NoNullRet(2,        2.Coalesce(       1));
        NoNullRet(2,  NullNum.Coalesce(       2));
        NoNullRet(2,   Nully0.Coalesce(       2));
        NoNullRet(1,   Nully1.Coalesce(       2));
        NoNullRet(2,   Nully2.Coalesce(       2));
        NoNullRet(2,        0.Coalesce(       2));
        NoNullRet(1,        1.Coalesce(       2));
        NoNullRet(2,        2.Coalesce(       2));
    }

    [TestMethod]
    public void Coalesce_SingleFallback_Objects()
    {
        NoNullRet(              Coalesce(NullObj,     NullObj    ));
        NoNullRet(NonNullObj,   Coalesce(NonNullObj,  NullObj    ));
        NoNullRet(NonNullObj,   Coalesce(NonNullObj,  NullObj    ));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NullObj    ));
        NoNullRet(NonNullObj,   Coalesce(NullObj,     NonNullObj ));
        NoNullRet(NonNullObj,   Coalesce(NonNullObj,  NonNullObj ));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NonNullObj ));
        NoNullRet(NullyFilled!, Coalesce(NullObj,     NullyFilled));
        NoNullRet(NonNullObj,   Coalesce(NonNullObj,  NullyFilled));
        NoNullRet(NullyFilled!, Coalesce(NullyFilled, NullyFilled));
        NoNullRet(              NullObj    .Coalesce(NullObj     ));
        NoNullRet(NonNullObj,   NonNullObj .Coalesce(NullObj     ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NullObj     ));
        NoNullRet(NonNullObj,   NullObj    .Coalesce(NonNullObj  ));
        NoNullRet(NonNullObj,   NonNullObj .Coalesce(NonNullObj  ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NonNullObj  ));
        NoNullRet(NullyFilled!, NullObj    .Coalesce(NullyFilled ));
        NoNullRet(NonNullObj,   NonNullObj .Coalesce(NullyFilled ));
        NoNullRet(NullyFilled!, NullyFilled.Coalesce(NullyFilled ));
    }
}
