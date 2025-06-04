namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_SimpleTypes_Tests
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

        NoNullRet(Has(true));
        IsTrue   (Has(true));
        NoNullRet(Has(false));
        IsFalse  (Has(false));
        NoNullRet(Has(@true));
        IsTrue   (Has(@true));
        NoNullRet(Has(@false));
        IsFalse  (Has(@false));
        NoNullRet(Has(nullyTrue));
        IsTrue   (Has(nullyTrue));
        NoNullRet(Has(nullyFalse));
        IsFalse  (Has(nullyFalse));
        NoNullRet(Has(nullBool));
        IsFalse  (Has(nullBool));

        NoNullRet(FilledIn(true));
        IsTrue   (FilledIn(true));
        NoNullRet(FilledIn(false));
        IsFalse  (FilledIn(false));
        NoNullRet(FilledIn(@true));
        IsTrue   (FilledIn(@true));
        NoNullRet(FilledIn(@false));
        IsFalse  (FilledIn(@false));
        NoNullRet(FilledIn(nullyTrue));
        IsTrue   (FilledIn(nullyTrue));
        NoNullRet(FilledIn(nullyFalse));
        IsFalse  (FilledIn(nullyFalse));
        NoNullRet(FilledIn(nullBool));
        IsFalse  (FilledIn(nullBool));

        NoNullRet(true.FilledIn());
        IsTrue   (true.FilledIn());
        NoNullRet(false.FilledIn());
        IsFalse  (false.FilledIn());
        NoNullRet(@true.FilledIn());
        IsTrue   (@true.FilledIn());
        NoNullRet(@false.FilledIn());
        IsFalse  (@false.FilledIn());
        NoNullRet(nullyTrue.FilledIn());
        IsTrue   (nullyTrue.FilledIn());
        NoNullRet(nullyFalse.FilledIn());
        IsFalse  (nullyFalse.FilledIn());
        NoNullRet(nullBool.FilledIn());
        IsFalse  (nullBool.FilledIn());
    }
}