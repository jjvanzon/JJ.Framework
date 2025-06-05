using static System.DateTime;
using static System.Double;
using static System.Guid;

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_BasicType_Tests
{
    // TODO:
    // Char, Byte, IntPtr, UIntPtr
    // the numeric types, their the signed and unsigned variations and TimeSpan.
    // Newer .NETs probably have more.
    // But let's start with a basic spread:
    // - [x] Enum/Enum?
    // - [x] bool
    // - [x] double
    // - [x] Guid
    // - [x] DateTime
    // - [x] Char
    // - [ ] Decimal

    bool True       = true ;
    bool  False      = false;
    bool? NullyTrue  = true ;
    bool? NullyFalse = false;
    bool? NullBool   = null ;

    [TestMethod]
    public void Bool_Existence_Test()
    {
        IsTrue (Has(true));
        IsFalse(Has(false));
        IsTrue (Has(True));
        IsFalse(Has(False));
        IsTrue (Has(NullyTrue));
        IsFalse(Has(NullyFalse));
        IsFalse(Has(NullBool));

        IsTrue (FilledIn(true));
        IsFalse(FilledIn(false));
        IsTrue (FilledIn(True));
        IsFalse(FilledIn(False));
        IsTrue (FilledIn(NullyTrue));
        IsFalse(FilledIn(NullyFalse));
        IsFalse(FilledIn(NullBool));

        IsTrue (true.FilledIn());
        IsFalse(false.FilledIn());
        IsTrue (True.FilledIn());
        IsFalse(False.FilledIn());
        IsTrue (NullyTrue.FilledIn());
        IsFalse(NullyFalse.FilledIn());
        IsFalse(NullBool.FilledIn());

        IsTrue (Coalesce(False, NullyTrue, NullBool));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue));
        IsFalse(NullyFalse.Coalesce(NullBool));
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

    EnumFirst0? First0Null         = null;
    EnumFirst0  First0Default      = default;
    EnumFirst0? First0DefaultNully = default;
    EnumFirst0  First0             = EnumFirst0.First0;
    EnumFirst0? First0Nully        = EnumFirst0.First0;
    EnumFirst0  Last1              = EnumFirst0.Last1;
    EnumFirst0? Last1Nully         = EnumFirst0.Last1;
    EnumFirst0  First0Invalid      = (EnumFirst0)(-1);
    EnumFirst0? First0InvalidNully = (EnumFirst0)(-1);
    EnumFirst1? First1Null         = null;
    EnumFirst1  First1Default      = default;
    EnumFirst1? First1DefaultNully = default;
    EnumFirst1  First1             = EnumFirst1.First1;
    EnumFirst1? First1Nully        = EnumFirst1.First1;
    EnumFirst1  Last2              = EnumFirst1.Last2;
    EnumFirst1? Last2Nully         = EnumFirst1.Last2;
    EnumFirst1  First1Invalid      = (EnumFirst1)(-1);
    EnumFirst1? First1InvalidNully = (EnumFirst1)(-1);

    [TestMethod]
    public void Enum_FilledIn_Test()
    {
        IsFalse (First0Null        .FilledIn());
        IsFalse (First0Default     .FilledIn());
        IsFalse (First0DefaultNully.FilledIn());
        IsFalse (First0            .FilledIn());
        IsFalse (First0Nully       .FilledIn());
        IsTrue  (Last1             .FilledIn());
        IsTrue  (Last1Nully        .FilledIn());

        IsFalse (First1Null        .FilledIn());
        IsFalse (First1Default     .FilledIn());
        IsFalse (First1DefaultNully.FilledIn());
        IsTrue  (First1            .FilledIn());
        IsTrue  (First1Nully       .FilledIn());
        IsTrue  (Last2             .FilledIn());
        IsTrue  (Last2Nully        .FilledIn());
        AreEqual((EnumFirst1)0, First1Default);
    }

    [TestMethod]
    public void Enum_FilledIn_UnspecifiedValues_Test()
    {
      // TODO: Detect enum values out of range eventually and see them as not filled in.
      // IsFalse (First0Invalid.FilledIn()); 
      // IsFalse (First0InvalidNully.FilledIn()); 
      // IsFalse (First1Invalid.FilledIn()); 
      // IsFalse (First1InvalidNully.FilledIn()); 
        IsTrue  (First0Invalid     .FilledIn());
        IsTrue  (First0InvalidNully.FilledIn());
        IsTrue  (First1Invalid     .FilledIn());
        IsTrue  (First1InvalidNully.FilledIn());
    }

    [TestMethod]
    public void Enum_Coalesce_Test()
    {
        NoNullRet(Last1,   Coalesce(First0Default, First0Null, Last1, First0Nully));
        NoNullRet("Last1", Coalesce(First0Default, First0Null).Coalesce(Last1).Coalesce("Never"));
        NoNullRet(First1,  First1Default.Coalesce(First1Null, First1, Last2));
    }

    double? NullDouble            = null;
    double  ZeroDouble            = 0.0;
    double  OneDouble             = 1.0;
    double  TwoDouble             = 2.0;
    double? NullyZeroDouble       = 0.0;
    double? NullyOneDouble        = 1.0;
    double? NullyTwoDouble        = 2.0;
    double? NullyNaN              = NaN;
    double? NullyNegativeInfinity = NegativeInfinity;
    double? NullyPositiveInfinity = PositiveInfinity;
    #if NET7_0_OR_GREATER
    double? NullyNegativeZero     = NegativeZero;
    #endif

    [TestMethod]
    public void Double_FilledIn_Tests()
    {
        IsFalse(Has(NullDouble));
        IsFalse(Has(ZeroDouble));
        IsTrue (Has(OneDouble));
        IsTrue (Has(TwoDouble));
        IsFalse(Has(NullyZeroDouble));
        IsTrue (Has(NullyOneDouble));
        IsTrue (Has(NullyTwoDouble));
        IsFalse(FilledIn(NullDouble));
        IsFalse(FilledIn(ZeroDouble));
        IsTrue (FilledIn(OneDouble));
        IsTrue (FilledIn(TwoDouble));
        IsFalse(FilledIn(NullyZeroDouble));
        IsTrue (FilledIn(NullyOneDouble));
        IsTrue (FilledIn(NullyTwoDouble));
        IsFalse(ZeroDouble.FilledIn());
        IsTrue (OneDouble.FilledIn());
        IsTrue (TwoDouble.FilledIn());
        IsFalse(NullyZeroDouble.FilledIn());
        IsTrue (NullyOneDouble.FilledIn());
        IsTrue (NullyTwoDouble.FilledIn());
    }

    [TestMethod]
    public void Double_Coalesce_Tests()
    {
        NoNullRet(OneDouble, Coalesce(NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(TwoDouble, Coalesce(NullDouble, ZeroDouble).Coalesce(TwoDouble).Coalesce(NullyOneDouble));
        NoNullRet(OneDouble, NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble));
    }

    [TestMethod]
    public void Double_SpecialValue_Tests()
    {
      // TODO: Make these special values count as not filled in.
      //IsFalse  (Has(NaN));
      //IsFalse  (Has(NullyNaN));
      //IsFalse  (Has(PositiveInfinity));
      //IsFalse  (Has(NullyPositiveInfinity));
      //IsFalse  (Has(NegativeInfinity));
      //IsFalse  (Has(NullyNegativeInfinity));
      //NoNullRet(1, Coalesce(NaN, PositiveInfinity, NegativeInfinity, NegativeZero, ZeroDouble, OneDouble, TwoDouble));
        IsTrue   (Has(NaN));
        IsTrue   (Has(NullyNaN));
        IsTrue   (Has(PositiveInfinity));
        IsTrue   (Has(NullyPositiveInfinity));
        IsTrue   (Has(NegativeInfinity));
        IsTrue   (Has(NullyNegativeInfinity));
        IsFalse  (Has(ZeroDouble));
        IsFalse  (Has(NullyZeroDouble));
        IsFalse  (Has(0.0));
        NoNullRet(NaN, Coalesce(NaN, PositiveInfinity, NegativeInfinity, ZeroDouble, OneDouble, TwoDouble));
        #if NET7_0_OR_GREATER
        IsFalse(Has(NegativeZero));
        IsFalse(Has(NullyNegativeZero));
        #endif
    }

    // Guid

    Guid? NullGuid = null;
    Guid  EmptyGuid = Guid.Empty;
    Guid? EmptyNullyGuid = Guid.Empty;
    Guid  ZeroGuid = new("00000000-0000-0000-0000-000000000000");
    Guid? ZeroNullyGuid = new("00000000-0000-0000-0000-000000000000");
    Guid  OneGuid = new("00000000-0000-0000-0000-000000000001");
    Guid? OneNullyGuid = new("00000000-0000-0000-0000-000000000001");
    Guid  RandomGuid = NewGuid();
    Guid? RandomNullyGuid = NewGuid();

    [TestMethod]
    public void Test_Guid_FilledIn_Tests()
    {
        IsFalse(Has(NullGuid));
        IsFalse(Has(EmptyGuid));
        IsFalse(Has(EmptyNullyGuid));
        IsFalse(Has(ZeroGuid));
        IsFalse(Has(ZeroNullyGuid));
        IsTrue (Has(OneGuid));
        IsTrue (Has(OneNullyGuid));
        IsTrue (Has(RandomGuid));
        IsTrue (Has(RandomNullyGuid));
        IsFalse(FilledIn(NullGuid));
        IsFalse(FilledIn(EmptyGuid));
        IsFalse(FilledIn(EmptyNullyGuid));
        IsFalse(FilledIn(ZeroGuid));
        IsFalse(FilledIn(ZeroNullyGuid));
        IsTrue (FilledIn(OneGuid));
        IsTrue (FilledIn(OneNullyGuid));
        IsTrue (FilledIn(RandomGuid));
        IsTrue (FilledIn(RandomNullyGuid));
        IsFalse(NullGuid.FilledIn());
        IsFalse(EmptyGuid.FilledIn());
        IsFalse(EmptyNullyGuid.FilledIn());
        IsFalse(ZeroGuid.FilledIn());
        IsFalse(ZeroNullyGuid.FilledIn());
        IsTrue (OneGuid.FilledIn());
        IsTrue (OneNullyGuid.FilledIn());
        IsTrue (RandomGuid.FilledIn());
        IsTrue (RandomNullyGuid.FilledIn());
        IsTrue (IsNully(NullGuid));
        IsTrue (IsNully(EmptyGuid));
        IsTrue (IsNully(EmptyNullyGuid));
        IsTrue (IsNully(ZeroGuid));
        IsTrue (IsNully(ZeroNullyGuid));
        IsFalse(IsNully(OneGuid));
        IsFalse(IsNully(OneNullyGuid));
        IsFalse(IsNully(RandomGuid));
        IsFalse(IsNully(RandomNullyGuid));
        IsTrue (NullGuid.IsNully());
        IsTrue (EmptyGuid.IsNully());
        IsTrue (EmptyNullyGuid.IsNully());
        IsTrue (ZeroGuid.IsNully());
        IsTrue (ZeroNullyGuid.IsNully());
        IsFalse(OneGuid.IsNully());
        IsFalse(OneNullyGuid.IsNully());
        IsFalse(RandomGuid.IsNully());
        IsFalse(RandomNullyGuid.IsNully());
        NoNullRet(OneGuid, Coalesce(NullGuid, EmptyGuid).Coalesce(ZeroGuid, OneGuid, RandomGuid));
    }

    // DateTime

    DateTime? NullDateTime         = null;
    DateTime  DefaultDateTime      = default;
    DateTime? DefaultNullyDateTime = default;
    DateTime  NewDateTime          = new();
    DateTime? NewNullyDateTime     = new();
    DateTime  MinDateTime          = DateTime.MinValue;
    DateTime? MinNullyDateTime     = DateTime.MinValue; 
    DateTime  MaxDateTime          = DateTime.MaxValue;
    DateTime? MaxNullyDateTime     = DateTime.MaxValue;
    DateTime  NowDateTime          = Now;
    DateTime? NowNullyDateTime     = Now;
    DateTime  SomeDateTime         = new(2023, 10, 1, 12, 10, 23);
    DateTime? SomeNullyDateTime    = new(2023, 10, 1, 12, 10, 23);
                                   
    [TestMethod]
    public void Test_DateTime_FilledIn_Tests()
    {
        IsFalse(Has(NullDateTime));
        IsFalse(Has(DefaultDateTime));
        IsFalse(Has(DefaultNullyDateTime));
        IsFalse(Has(NewDateTime));
        IsFalse(Has(NewNullyDateTime));
        IsFalse(Has(MinDateTime));
        IsFalse(Has(MinNullyDateTime));
        IsTrue (Has(MaxDateTime));
        IsTrue (Has(MaxNullyDateTime));
        IsTrue (Has(NowDateTime));
        IsTrue (Has(NowNullyDateTime));
        IsTrue (Has(SomeDateTime));
        IsTrue (Has(SomeNullyDateTime));
        NoNullRet(SomeDateTime, Coalesce(NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
    }

    // Char

    char? NullChar              = null;
    char  DefaultChar           = default;
    char? DefaultNullyChar      = default;
    char  NewChar               = new();
    char? NewNullyChar          = new();
    char  ZeroValueChar         = '\0';
    char? ZeroValueNullyChar    = '\0';
    char  ZeroDigitChar         = '0';
    char? ZeroDigitNullyChar    = '0';
    char  SpaceChar             = ' ';
    char? NullySpaceChar        = '\t';
    char  ControlChar           = '\u0001';
    char? NullyControlChar      = '\u0001';
    char  SpecialSpace          = '\u2003';
    char? NullySpecialSpace     = '\u2003';
    char  ZeroWidthSpace        = '\u200B';
    char? NullyZeroWidthSpace   = '\u200B';
    char  NonBreakingSpace      = '\u00A0';
    char? NullyNonBreakingSpace = '\u00A0';
    char  HighSurrogate         = '\uD83D'; // Special char used in UTF-16 to help encode values outside the UTF-16 range.
    char? NullyHighSurrogate    = '\uD83D'; // Special char used in UTF-16 to help encode values outside the UTF-16 range.
    char  FilledChar             = 'a';
    char? NullyFilledChar        = 'a';

    [TestMethod]
    public void Char_Existence_Tests()
    {
        // Abviously not filled
        IsFalse(Has(NullChar));
        IsFalse(Has(DefaultChar));
        IsFalse(Has(DefaultNullyChar));
        IsFalse(Has(NewChar));
        IsFalse(Has(NewNullyChar));
        IsFalse(Has(ZeroValueChar));
        IsFalse(Has(ZeroValueNullyChar));

        // Filled
        IsTrue (Has(ZeroDigitChar));
        IsTrue (Has(ZeroDigitNullyChar));
        IsTrue (Has(FilledChar));
        IsTrue (Has(NullyFilledChar));
        NoNullRet('a', Coalesce(NullChar, ZeroValueChar, NullyFilledChar, 'b'));

        // TODO: These should be false
        IsTrue (Has(SpaceChar));
        IsTrue (Has(NullySpaceChar));
        IsTrue (Has(ControlChar));
        IsTrue (Has(NullyControlChar));
        IsTrue (Has(SpecialSpace));
        IsTrue (Has(NullySpecialSpace));
        IsTrue (Has(ZeroWidthSpace));
        IsTrue (Has(NullyZeroWidthSpace));
        IsTrue (Has(NonBreakingSpace));
        IsTrue (Has(NullyNonBreakingSpace));
        IsTrue (Has(HighSurrogate));
        IsTrue (Has(NullyHighSurrogate));
    }
}

