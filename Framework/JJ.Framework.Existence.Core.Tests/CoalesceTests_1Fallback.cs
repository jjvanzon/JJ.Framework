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
    public void Coalesce_SingleFallback()
    {
        // Single Fallback String to String
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
        // Single Fallback Object to String
        {
            CultureInfo? nullCulture = null;
            CultureInfo  culture = GetCultureInfo("nl-NL");
            AreEqual("nl-NL", Coalesce(culture,     "None"));
            AreEqual("None" , Coalesce(nullCulture, "None"));
            AreEqual("nl-NL", culture    .Coalesce( "None"));
            AreEqual("None" , nullCulture.Coalesce( "None"));
        }
        // Single Fallback Structs to String
        // With T
        {
            AreEqual("",           Coalesce(0,  NullText ));
            AreEqual("",           Coalesce(0,  NullText ));
            AreEqual("peekaboo",   Coalesce(0, "peekaboo"));
            AreEqual("",         0.Coalesce(    NullText ));
            AreEqual("peekaboo", 0.Coalesce(   "peekaboo"));
            AreEqual("1",        1.Coalesce(    NullText ));
            AreEqual("1",        1.Coalesce(   "peekaboo"));
        }
        // With T?
        {
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
        // Single Fallback for Structs
        {
            AreEqual(0, Coalesce( NullNum, NullNum));
            AreEqual(0, Coalesce(  Nully0, NullNum));
            AreEqual(1, Coalesce(  Nully1, NullNum));
            AreEqual(2, Coalesce(  Nully2, NullNum));
            AreEqual(0, Coalesce(       0, NullNum));
            AreEqual(1, Coalesce(       1, NullNum));
            AreEqual(2, Coalesce(       2, NullNum));
            AreEqual(0, Coalesce( NullNum,  Nully0));
            AreEqual(0, Coalesce(  Nully0,  Nully0));
            AreEqual(1, Coalesce(  Nully1,  Nully0));
            AreEqual(2, Coalesce(  Nully2,  Nully0));
            AreEqual(0, Coalesce(       0,  Nully0));
            AreEqual(1, Coalesce(       1,  Nully0));
            AreEqual(2, Coalesce(       2,  Nully0));
            AreEqual(1, Coalesce( NullNum,  Nully1));
            AreEqual(1, Coalesce(  Nully0,  Nully1));
            AreEqual(1, Coalesce(  Nully1,  Nully1));
            AreEqual(2, Coalesce(  Nully2,  Nully1));
            AreEqual(1, Coalesce(       0,  Nully1));
            AreEqual(1, Coalesce(       1,  Nully1));
            AreEqual(2, Coalesce(       2,  Nully1));
            AreEqual(2, Coalesce( NullNum,  Nully2));
            AreEqual(2, Coalesce(  Nully0,  Nully2));
            AreEqual(1, Coalesce(  Nully1,  Nully2));
            AreEqual(2, Coalesce(  Nully2,  Nully2));
            AreEqual(2, Coalesce(       0,  Nully2));
            AreEqual(1, Coalesce(       1,  Nully2));
            AreEqual(2, Coalesce(       2,  Nully2));
            AreEqual(0, Coalesce( NullNum,       0));
            AreEqual(0, Coalesce(  Nully0,       0));
            AreEqual(1, Coalesce(  Nully1,       0));
            AreEqual(2, Coalesce(  Nully2,       0));
            AreEqual(0, Coalesce(       0,       0));
            AreEqual(1, Coalesce(       1,       0));
            AreEqual(2, Coalesce(       2,       0));
            AreEqual(1, Coalesce( NullNum,       1));
            AreEqual(1, Coalesce(  Nully0,       1));
            AreEqual(1, Coalesce(  Nully1,       1));
            AreEqual(2, Coalesce(  Nully2,       1));
            AreEqual(1, Coalesce(       0,       1));
            AreEqual(1, Coalesce(       1,       1));
            AreEqual(2, Coalesce(       2,       1));
            AreEqual(2, Coalesce( NullNum,       2));
            AreEqual(2, Coalesce(  Nully0,       2));
            AreEqual(1, Coalesce(  Nully1,       2));
            AreEqual(2, Coalesce(  Nully2,       2));
            AreEqual(2, Coalesce(       0,       2));
            AreEqual(1, Coalesce(       1,       2));
            AreEqual(2, Coalesce(       2,       2));
            AreEqual(0,  NullNum.Coalesce( NullNum));
            AreEqual(0,   Nully0.Coalesce( NullNum));
            AreEqual(1,   Nully1.Coalesce( NullNum));
            AreEqual(2,   Nully2.Coalesce( NullNum));
            AreEqual(0,        0.Coalesce( NullNum));
            AreEqual(1,        1.Coalesce( NullNum));
            AreEqual(2,        2.Coalesce( NullNum));
            AreEqual(0,  NullNum.Coalesce(  Nully0));
            AreEqual(0,   Nully0.Coalesce(  Nully0));
            AreEqual(1,   Nully1.Coalesce(  Nully0));
            AreEqual(2,   Nully2.Coalesce(  Nully0));
            AreEqual(0,        0.Coalesce(  Nully0));
            AreEqual(1,        1.Coalesce(  Nully0));
            AreEqual(2,        2.Coalesce(  Nully0));
            AreEqual(1,  NullNum.Coalesce(  Nully1));
            AreEqual(1,   Nully0.Coalesce(  Nully1));
            AreEqual(1,   Nully1.Coalesce(  Nully1));
            AreEqual(2,   Nully2.Coalesce(  Nully1));
            AreEqual(1,        0.Coalesce(  Nully1));
            AreEqual(1,        1.Coalesce(  Nully1));
            AreEqual(2,        2.Coalesce(  Nully1));
            AreEqual(2,  NullNum.Coalesce(  Nully2));
            AreEqual(2,   Nully0.Coalesce(  Nully2));
            AreEqual(1,   Nully1.Coalesce(  Nully2));
            AreEqual(2,   Nully2.Coalesce(  Nully2));
            AreEqual(2,        0.Coalesce(  Nully2));
            AreEqual(1,        1.Coalesce(  Nully2));
            AreEqual(2,        2.Coalesce(  Nully2));
            AreEqual(0,  NullNum.Coalesce(       0));
            AreEqual(0,   Nully0.Coalesce(       0));
            AreEqual(1,   Nully1.Coalesce(       0));
            AreEqual(2,   Nully2.Coalesce(       0));
            AreEqual(0,        0.Coalesce(       0));
            AreEqual(1,        1.Coalesce(       0));
            AreEqual(2,        2.Coalesce(       0));
            AreEqual(1,  NullNum.Coalesce(       1));
            AreEqual(1,   Nully0.Coalesce(       1));
            AreEqual(1,   Nully1.Coalesce(       1));
            AreEqual(2,   Nully2.Coalesce(       1));
            AreEqual(1,        0.Coalesce(       1));
            AreEqual(1,        1.Coalesce(       1));
            AreEqual(2,        2.Coalesce(       1));
            AreEqual(2,  NullNum.Coalesce(       2));
            AreEqual(2,   Nully0.Coalesce(       2));
            AreEqual(1,   Nully1.Coalesce(       2));
            AreEqual(2,   Nully2.Coalesce(       2));
            AreEqual(2,        0.Coalesce(       2));
            AreEqual(1,        1.Coalesce(       2));
            AreEqual(2,        2.Coalesce(       2));
            
        }
        // Single Fallback for Objects.
        {
            NotNull (                Coalesce(NullObject,     NullObject));
            AreEqual(NonNullObject,  Coalesce(NonNullObject,  NullObject));
            AreEqual(NullableFilled, Coalesce(NullableFilled, NullObject));
            AreEqual(NonNullObject,  Coalesce(NullObject,     NonNullObject));
            AreEqual(NonNullObject,  Coalesce(NonNullObject,  NonNullObject));
            AreEqual(NullableFilled, Coalesce(NullableFilled, NonNullObject));
            AreEqual(NullableFilled, Coalesce(NullObject,     NullableFilled));
            AreEqual(NonNullObject,  Coalesce(NonNullObject,  NullableFilled));
            AreEqual(NullableFilled, Coalesce(NullableFilled, NullableFilled));

            NotNull (                NullObject    .Coalesce(NullObject));
            AreEqual(NonNullObject,  NonNullObject .Coalesce(NullObject));
            AreEqual(NullableFilled, NullableFilled.Coalesce(NullObject));
            AreEqual(NonNullObject,  NullObject    .Coalesce(NonNullObject));
            AreEqual(NonNullObject,  NonNullObject .Coalesce(NonNullObject));
            AreEqual(NullableFilled, NullableFilled.Coalesce(NonNullObject));
            AreEqual(NullableFilled, NullObject    .Coalesce(NullableFilled));
            AreEqual(NonNullObject,  NonNullObject .Coalesce(NullableFilled));
            AreEqual(NullableFilled, NullableFilled.Coalesce(NullableFilled));
            
            // TODO: Check return types. After extending Testing.Core's helpers.
            //IsOfType<StringBuilder>(() => Coalesce(NullObject,           NullObject));
        }
        
        // TODO: Check for non-null return type. Also in the other tests.
        // TODO: Use more fields instead of local variables for better overview.
        // TODO: More tests
    }
}
