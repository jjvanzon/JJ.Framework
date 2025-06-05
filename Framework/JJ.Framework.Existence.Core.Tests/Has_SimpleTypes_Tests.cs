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


    // Bools

    bool  True       => true ;
    bool  False      => false;
    bool? NullyTrue  => true ;
    bool? NullyFalse => false;
    bool? NullBool   => null ;

    [TestMethod]
    public void Bool_Existence_Test()
    {

        NoNullRet(Has(true));
        IsTrue   (Has(true));
        NoNullRet(Has(false));
        IsFalse  (Has(false));
        NoNullRet(Has(True));
        IsTrue   (Has(True));
        NoNullRet(Has(False));
        IsFalse  (Has(False));
        NoNullRet(Has(NullyTrue));
        IsTrue   (Has(NullyTrue));
        NoNullRet(Has(NullyFalse));
        IsFalse  (Has(NullyFalse));
        NoNullRet(Has(NullBool));
        IsFalse  (Has(NullBool));

        NoNullRet(FilledIn(true));
        IsTrue   (FilledIn(true));
        NoNullRet(FilledIn(false));
        IsFalse  (FilledIn(false));
        NoNullRet(FilledIn(True));
        IsTrue   (FilledIn(True));
        NoNullRet(FilledIn(False));
        IsFalse  (FilledIn(False));
        NoNullRet(FilledIn(NullyTrue));
        IsTrue   (FilledIn(NullyTrue));
        NoNullRet(FilledIn(NullyFalse));
        IsFalse  (FilledIn(NullyFalse));
        NoNullRet(FilledIn(NullBool));
        IsFalse  (FilledIn(NullBool));

        NoNullRet(true.FilledIn());
        IsTrue   (true.FilledIn());
        NoNullRet(false.FilledIn());
        IsFalse  (false.FilledIn());
        NoNullRet(True.FilledIn());
        IsTrue   (True.FilledIn());
        NoNullRet(False.FilledIn());
        IsFalse  (False.FilledIn());
        NoNullRet(NullyTrue.FilledIn());
        IsTrue   (NullyTrue.FilledIn());
        NoNullRet(NullyFalse.FilledIn());
        IsFalse  (NullyFalse.FilledIn());
        NoNullRet(NullBool.FilledIn());
        IsFalse  (NullBool.FilledIn());

        NoNullRet(Coalesce(False, NullyTrue, NullBool));
        IsTrue   (Coalesce(False, NullyTrue, NullBool));
        NoNullRet(NullyFalse.Coalesce(NullBool, NullyTrue));
        IsTrue   (NullyFalse.Coalesce(NullBool, NullyTrue));
        NoNullRet(NullyFalse.Coalesce(NullBool));
        IsFalse  (NullyFalse.Coalesce(NullBool));
    }

    // Enums
        
    enum EnumFirst0
    {
        First0 = 0,
        Last1 = 1
    }

    enum EnumFirst1
    {
        First1 = 1,
        Last2 = 2
    }

    EnumFirst0? First0Null         => null;
    EnumFirst0  First0Default      => default;
    EnumFirst0? First0DefaultNully => default;
    EnumFirst0  First0             => EnumFirst0.First0;
    EnumFirst0? First0Nully        => EnumFirst0.First0;
    EnumFirst0  Last1              => EnumFirst0.Last1;
    EnumFirst0? Last1Nully         => EnumFirst0.Last1;
    EnumFirst0  First0Invalid      => (EnumFirst0)(-1);
    EnumFirst0? First0InvalidNully => (EnumFirst0)(-1);
    EnumFirst1? First1Null         => null;
    EnumFirst1  First1Default      => default;
    EnumFirst1? First1DefaultNully => default;
    EnumFirst1  First1             => EnumFirst1.First1;
    EnumFirst1? First1Nully        => EnumFirst1.First1;
    EnumFirst1  Last2              => EnumFirst1.Last2;
    EnumFirst1? Last2Nully         => EnumFirst1.Last2;
    EnumFirst1  First1Invalid      => (EnumFirst1)(-1);
    EnumFirst1? First1InvalidNully => (EnumFirst1)(-1);

    [TestMethod]
    public void Enum_ExistenceTest()
    {
        // TODO: Add NoNullRet assertions.

        IsFalse(First0Null.FilledIn());
        IsFalse(First0Default.FilledIn());
        IsFalse(First0DefaultNully.FilledIn());
        IsFalse(First0.FilledIn());
        IsTrue (Last1.FilledIn());

        IsFalse(First1Null.FilledIn());
        IsFalse(First1Default.FilledIn());
        AreEqual((EnumFirst1)0, First1Default);

        // TODO: Detect enum values out of range eventually and see them as not filled in.
        // IsFalse(First0Invalid.FilledIn()); 
        // IsFalse(First0InvalidNully.FilledIn()); 
        IsTrue(First0Invalid.FilledIn());
        IsTrue(First0InvalidNully.FilledIn());
    }
}
