namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_SimpleType_Tests
{
    // From XmlToObjectConverter:
    // Recognized values are the .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr
    // the numeric types, their the signed and unsigned variations and
    // String, Guid, DateTime, TimeSpan and Enum types.
    
    // Newer .NETs probably have more.
    //
    // But let's start with a basic spread:
    //
    // - [ ] Enum
    // - [ ] Enum?
    // - [x] bool
    // - [ ] double

    [TestMethod]
    public void Has_Bool_Test()
    {
        bool @true = true;
        bool @false = false;
        bool? nullyTrue = true;
        bool? nullyFalse = false;
        bool? nullBool = null;

        // TODO: Extend and use NoNullRet. Or extend with NoNullTrue and NoNullFalse?
        AreEqual(true,  Has(true));
        AreEqual(false, Has(false));
        AreEqual(true,  Has(@true));
        AreEqual(false, Has(@false));
        AreEqual(false, Has(nullBool));
        AreEqual(true,  Has(nullyTrue));
        AreEqual(false, Has(nullyFalse));

        AreEqual(true,  FilledIn(true));
        AreEqual(false, FilledIn(false));
        AreEqual(true,  FilledIn(@true));
        AreEqual(false, FilledIn(@false));
        AreEqual(false, FilledIn(nullBool));
        AreEqual(true,  FilledIn(nullyTrue));
        AreEqual(false, FilledIn(nullyFalse));

        AreEqual(true,  true.FilledIn());
        AreEqual(false, false.FilledIn());
        AreEqual(true,  @true.FilledIn());
        AreEqual(false, @false.FilledIn());
        AreEqual(false, nullBool.FilledIn());
        AreEqual(true,  nullyTrue.FilledIn());
        AreEqual(false, nullyFalse.FilledIn());
    }
}