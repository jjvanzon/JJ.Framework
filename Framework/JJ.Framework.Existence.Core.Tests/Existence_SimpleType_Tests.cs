namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_SimpleType_Tests
{
    // From XmlToObjectConverter:
    // Recognized values are the .NET primitive types: Boolean, Char, Byte, IntPtr, UIntPtr
    // the numeric types, their the signed and unsigned variations and
    // String, Guid, DateTime, TimeSpan and Enum types.
    
    // Newer .NETs probably have more.
    //
    // But let's start with a basic spread:
    //
    // - [x] Enum/Enum?
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

        IsTrue   (Has(true));
        NoNullRet(Has(true));
        IsFalse  (Has(false));
        NoNullRet(Has(false));
        IsTrue   (Has(True));
        NoNullRet(Has(True));
        IsFalse  (Has(False));
        NoNullRet(Has(False));
        IsTrue   (Has(NullyTrue));
        NoNullRet(Has(NullyTrue));
        IsFalse  (Has(NullyFalse));
        NoNullRet(Has(NullyFalse));
        IsFalse  (Has(NullBool));
        NoNullRet(Has(NullBool));

        IsTrue   (FilledIn(true));
        NoNullRet(FilledIn(true));
        IsFalse  (FilledIn(false));
        NoNullRet(FilledIn(false));
        IsTrue   (FilledIn(True));
        NoNullRet(FilledIn(True));
        IsFalse  (FilledIn(False));
        NoNullRet(FilledIn(False));
        IsTrue   (FilledIn(NullyTrue));
        NoNullRet(FilledIn(NullyTrue));
        IsFalse  (FilledIn(NullyFalse));
        NoNullRet(FilledIn(NullyFalse));
        IsFalse  (FilledIn(NullBool));
        NoNullRet(FilledIn(NullBool));

        IsTrue   (true.FilledIn());
        NoNullRet(true.FilledIn());
        IsFalse  (false.FilledIn());
        NoNullRet(false.FilledIn());
        IsTrue   (True.FilledIn());
        NoNullRet(True.FilledIn());
        IsFalse  (False.FilledIn());
        NoNullRet(False.FilledIn());
        IsTrue   (NullyTrue.FilledIn());
        NoNullRet(NullyTrue.FilledIn());
        IsFalse  (NullyFalse.FilledIn());
        NoNullRet(NullyFalse.FilledIn());
        IsFalse  (NullBool.FilledIn());
        NoNullRet(NullBool.FilledIn());

        IsTrue   (Coalesce(False, NullyTrue, NullBool));
        NoNullRet(Coalesce(False, NullyTrue, NullBool));
        IsTrue   (NullyFalse.Coalesce(NullBool, NullyTrue));
        NoNullRet(NullyFalse.Coalesce(NullBool, NullyTrue));
        IsFalse  (NullyFalse.Coalesce(NullBool));
        NoNullRet(NullyFalse.Coalesce(NullBool));
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
    public void Enum_FilledIn_Test()
    {
        IsFalse  (First0Null        .FilledIn());
        NoNullRet(First0Null        .FilledIn());
        IsFalse  (First0Default     .FilledIn());
        NoNullRet(First0Default     .FilledIn());
        IsFalse  (First0DefaultNully.FilledIn());
        NoNullRet(First0DefaultNully.FilledIn());
        IsFalse  (First0            .FilledIn());
        NoNullRet(First0            .FilledIn());
        IsFalse  (First0Nully       .FilledIn());
        NoNullRet(First0Nully       .FilledIn());
        IsTrue   (Last1             .FilledIn());
        NoNullRet(Last1             .FilledIn());
        IsTrue   (Last1Nully        .FilledIn());
        NoNullRet(Last1Nully        .FilledIn());

        IsFalse  (First1Null        .FilledIn());
        NoNullRet(First1Null        .FilledIn());
        IsFalse  (First1Default     .FilledIn());
        NoNullRet(First1Default     .FilledIn());
        IsFalse  (First1DefaultNully.FilledIn());
        NoNullRet(First1DefaultNully.FilledIn());
        IsTrue   (First1            .FilledIn());
        NoNullRet(First1            .FilledIn());
        IsTrue   (First1Nully       .FilledIn());
        NoNullRet(First1Nully       .FilledIn());
        IsTrue   (Last2             .FilledIn());
        NoNullRet(Last2             .FilledIn());
        IsTrue   (Last2Nully        .FilledIn());
        NoNullRet(Last2Nully        .FilledIn());
        AreEqual ((EnumFirst1)0, First1Default);
    }

    [TestMethod]
    public void Enum_FilledIn_UnspecifiedValues_Test()
    {
      // TODO: Detect enum values out of range eventually and see them as not filled in.
      // IsFalse  (First0Invalid.FilledIn()); 
      // NoNullRet(First0Invalid.FilledIn()); 
      // IsFalse  (First0InvalidNully.FilledIn()); 
      // NoNullRet(First0InvalidNully.FilledIn()); 
      // IsFalse  (First1Invalid.FilledIn()); 
      // NoNullRet(First1Invalid.FilledIn()); 
      // IsFalse  (First1InvalidNully.FilledIn()); 
      // NoNullRet(First1InvalidNully.FilledIn()); 
        IsTrue   (First0Invalid     .FilledIn());
        NoNullRet(First0Invalid     .FilledIn());
        IsTrue   (First0InvalidNully.FilledIn());
        NoNullRet(First0InvalidNully.FilledIn());
        IsTrue   (First1Invalid     .FilledIn());
        NoNullRet(First1Invalid     .FilledIn());
        IsTrue   (First1InvalidNully.FilledIn());
        NoNullRet(First1InvalidNully.FilledIn());
    }

    [TestMethod]
    public void Enum_Coalesce_Test()
    {
        AreEqual (Last1,   Coalesce(First0Default, First0Null, Last1, First0Nully));
        NoNullRet(         Coalesce(First0Default, First0Null, Last1, First0Nully));
        AreEqual ("Last1", Coalesce(First0Default, First0Null).Coalesce(Last1).Coalesce("Never"));
        NoNullRet(         Coalesce(First0Default, First0Null).Coalesce(Last1).Coalesce("Never"));
        AreEqual (First1,  First1Default.Coalesce(First1Null, First1, Last2));
        NoNullRet(         First1Default.Coalesce(First1Null, First1, Last2));
    }

    double? NullDouble      = null;
    double  ZeroDouble      = 0.0;
    double  OneDouble       = 1.0;
    double  TwoDouble       = 2.0;
    double? NullyZeroDouble = 0.0;
    double? NullyOneDouble  = 1.0;
    double? NullyTwoDouble  = 2.0;

    [TestMethod]
    public void Double_FilledIn_Tests()
    {
        IsFalse  (Has(NullDouble));
        NoNullRet(Has(NullDouble));
        IsFalse  (Has(ZeroDouble));
        NoNullRet(Has(ZeroDouble));
        IsTrue   (Has(OneDouble));
        NoNullRet(Has(OneDouble));
        IsTrue   (Has(TwoDouble));
        NoNullRet(Has(TwoDouble));
        IsFalse  (Has(NullyZeroDouble));
        NoNullRet(Has(NullyZeroDouble));
        IsTrue   (Has(NullyOneDouble));
        NoNullRet(Has(NullyOneDouble));
        IsTrue   (Has(NullyTwoDouble));
        NoNullRet(Has(NullyTwoDouble));
        IsFalse  (FilledIn(NullDouble));
        NoNullRet(FilledIn(NullDouble));
        IsFalse  (FilledIn(ZeroDouble));
        NoNullRet(FilledIn(ZeroDouble));
        IsTrue   (FilledIn(OneDouble));
        NoNullRet(FilledIn(OneDouble));
        IsTrue   (FilledIn(TwoDouble));
        NoNullRet(FilledIn(TwoDouble));
        IsFalse  (FilledIn(NullyZeroDouble));
        NoNullRet(FilledIn(NullyZeroDouble));
        IsTrue   (FilledIn(NullyOneDouble));
        NoNullRet(FilledIn(NullyOneDouble));
        IsTrue   (FilledIn(NullyTwoDouble));
        NoNullRet(FilledIn(NullyTwoDouble));
        IsFalse  (ZeroDouble.FilledIn());
        NoNullRet(ZeroDouble.FilledIn());
        IsTrue   (OneDouble.FilledIn());
        NoNullRet(OneDouble.FilledIn());
        IsTrue   (TwoDouble.FilledIn());
        NoNullRet(TwoDouble.FilledIn());
        IsFalse  (NullyZeroDouble.FilledIn());
        NoNullRet(NullyZeroDouble.FilledIn());
        IsTrue   (NullyOneDouble.FilledIn());
        NoNullRet(NullyOneDouble.FilledIn());
        IsTrue   (NullyTwoDouble.FilledIn());
        NoNullRet(NullyTwoDouble.FilledIn());
    }

    [TestMethod]
    public void Double_Coalesce_Tests()
    {
        AreEqual (OneDouble, Coalesce(NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(           Coalesce(NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        AreEqual (TwoDouble, Coalesce(NullDouble, ZeroDouble).Coalesce(TwoDouble).Coalesce(NullyOneDouble));
        NoNullRet(           Coalesce(NullDouble, ZeroDouble).Coalesce(TwoDouble).Coalesce(NullyOneDouble));
        AreEqual (OneDouble, NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble));
        NoNullRet(           NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble));
    }

    [TestMethod]
    public void Double_SpecialValue_Tests()
    {
       // TODO: Implement
    }
}
