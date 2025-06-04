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

        // TODO: Extend with NoNullTrue and NoNullFalse?
        NoNullRet(true,  Has(true));
        NoNullRet(false, Has(false));
        NoNullRet(true,  Has(@true));
        NoNullRet(false, Has(@false));
        NoNullRet(false, Has(nullBool));
        NoNullRet(true,  Has(nullyTrue));
        NoNullRet(false, Has(nullyFalse));

        NoNullRet(true,  FilledIn(true));
        NoNullRet(false, FilledIn(false));
        NoNullRet(true,  FilledIn(@true));
        NoNullRet(false, FilledIn(@false));
        NoNullRet(false, FilledIn(nullBool));
        NoNullRet(true,  FilledIn(nullyTrue));
        NoNullRet(false, FilledIn(nullyFalse));

        NoNullRet(true,  true.FilledIn());
        NoNullRet(false, false.FilledIn());
        NoNullRet(true,  @true.FilledIn());
        NoNullRet(false, @false.FilledIn());
        NoNullRet(false, nullBool.FilledIn());
        NoNullRet(true,  nullyTrue.FilledIn());
        NoNullRet(false, nullyFalse.FilledIn());
    }
}