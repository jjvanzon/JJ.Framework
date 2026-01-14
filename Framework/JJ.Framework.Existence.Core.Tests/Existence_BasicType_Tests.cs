using static System.DateTime;
using static System.Double;
using static System.Guid;

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_BasicType_Tests
{
    // TODO:
    // Char (does not behave well yet), Byte, IntPtr, UIntPtr
    // the numeric types, their signed and unsigned variations and TimeSpan.
    // Newer .NETs probably have more.
    // But let's start with a basic spread:
    // - [x] Enum/Enum?
    // - [x] bool
    // - [x] double
    // - [x] Guid
    // - [x] DateTime
    // - [x] Char
    // - [ ] ~ Decimal

    bool  True       = true ;
    bool  False      = false;
    bool? NullyTrue  = true ;
    bool? NullyFalse = false;
    bool? NullBool   = null ;

    [TestMethod]
    public void Bool_FilledIn_Test()
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
    }

    [TestMethod]
    public void Bool_Coalesce_Test()
    {
        IsTrue (Coalesce(False, NullyTrue, NullBool));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue));
        IsFalse(NullyFalse.Coalesce(NullBool));
    }

    [TestMethod]
    public void Bool_FilledIn_ZeroMatters_Test()
    {
        IsTrue (Has     (true                          ));
        IsTrue (Has     (true,       zeroMatters: false));
        IsTrue (Has     (true,                    false));
        IsTrue (Has     (true,       zeroMatters       ));
        IsTrue (Has     (true,       zeroMatters: true ));
        IsTrue (Has     (true,                    true ));
        IsFalse(Has     (false                         ));
        IsFalse(Has     (false,      zeroMatters: false));
        IsFalse(Has     (false,                   false));
        IsTrue (Has     (false,      zeroMatters       ));
        IsTrue (Has     (false,      zeroMatters: true ));
        IsTrue (Has     (false,                   true ));
        IsTrue (Has     (True                          ));
        IsTrue (Has     (True,       zeroMatters: false));
        IsTrue (Has     (True,                    false));
        IsTrue (Has     (True,       zeroMatters       ));
        IsTrue (Has     (True,       zeroMatters: true ));
        IsTrue (Has     (True,                    true ));
        IsFalse(Has     (False                         ));
        IsFalse(Has     (False,      zeroMatters: false));
        IsFalse(Has     (False,                   false));
        IsTrue (Has     (False,      zeroMatters       ));
        IsTrue (Has     (False,      zeroMatters: true ));
        IsTrue (Has     (False,                   true ));
        IsTrue (Has     (NullyTrue                     ));
        IsTrue (Has     (NullyTrue,  zeroMatters: false));
        IsTrue (Has     (NullyTrue,               false));
        IsTrue (Has     (NullyTrue,  zeroMatters       ));
        IsTrue (Has     (NullyTrue,  zeroMatters: true ));
        IsTrue (Has     (NullyTrue,               true ));
        IsFalse(Has     (NullyFalse                    ));
        IsFalse(Has     (NullyFalse, zeroMatters: false));
        IsFalse(Has     (NullyFalse,              false));
        IsTrue (Has     (NullyFalse, zeroMatters       ));
        IsTrue (Has     (NullyFalse, zeroMatters: true ));
        IsTrue (Has     (NullyFalse,              true ));
        IsFalse(Has     (NullBool                      ));
        IsFalse(Has     (NullBool,   zeroMatters: false));
        IsFalse(Has     (NullBool,                false));
        IsFalse(Has     (NullBool,   zeroMatters       ));
        IsFalse(Has     (NullBool,   zeroMatters: true ));
        IsFalse(Has     (NullBool,                true ));

        IsTrue (FilledIn(true                          ));
        IsTrue (FilledIn(true,       zeroMatters: false));
        IsTrue (FilledIn(true,                    false));
        IsTrue (FilledIn(true,       zeroMatters       ));
        IsTrue (FilledIn(true,       zeroMatters: true ));
        IsTrue (FilledIn(true,                    true ));
        IsFalse(FilledIn(false                         ));
        IsFalse(FilledIn(false,      zeroMatters: false));
        IsFalse(FilledIn(false,                   false));
        IsTrue (FilledIn(false,      zeroMatters       ));
        IsTrue (FilledIn(false,      zeroMatters: true ));
        IsTrue (FilledIn(false,                   true ));
        IsTrue (FilledIn(True                          ));
        IsTrue (FilledIn(True,       zeroMatters: false));
        IsTrue (FilledIn(True,                    false));
        IsTrue (FilledIn(True,       zeroMatters       ));
        IsTrue (FilledIn(True,       zeroMatters: true ));
        IsTrue (FilledIn(True,                    true ));
        IsFalse(FilledIn(False                         ));
        IsFalse(FilledIn(False,      zeroMatters: false));
        IsFalse(FilledIn(False,                   false));
        IsTrue (FilledIn(False,      zeroMatters       ));
        IsTrue (FilledIn(False,      zeroMatters: true ));
        IsTrue (FilledIn(False,                   true ));
        IsTrue (FilledIn(NullyTrue                     ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: false));
        IsTrue (FilledIn(NullyTrue,               false));
        IsTrue (FilledIn(NullyTrue,  zeroMatters       ));
        IsTrue (FilledIn(NullyTrue,  zeroMatters: true ));
        IsTrue (FilledIn(NullyTrue,               true ));
        IsFalse(FilledIn(NullyFalse                    ));
        IsFalse(FilledIn(NullyFalse, zeroMatters: false));
        IsFalse(FilledIn(NullyFalse,              false));
        IsTrue (FilledIn(NullyFalse, zeroMatters       ));
        IsTrue (FilledIn(NullyFalse, zeroMatters: true ));
        IsTrue (FilledIn(NullyFalse,              true ));
        IsFalse(FilledIn(NullBool                      ));
        IsFalse(FilledIn(NullBool,   zeroMatters: false));
        IsFalse(FilledIn(NullBool,                false));
        IsFalse(FilledIn(NullBool,   zeroMatters       ));
        IsFalse(FilledIn(NullBool,   zeroMatters: true ));
        IsFalse(FilledIn(NullBool,                true ));

        IsTrue (true      .FilledIn(                   ));
        IsTrue (true      .FilledIn( zeroMatters: false));
        IsTrue (true      .FilledIn(              false));
        IsTrue (true      .FilledIn( zeroMatters       ));
        IsTrue (true      .FilledIn( zeroMatters: true ));
        IsTrue (true      .FilledIn(              true ));
        IsFalse(false     .FilledIn(                   ));
        IsFalse(false     .FilledIn( zeroMatters: false));
        IsFalse(false     .FilledIn(              false));
        IsTrue (false     .FilledIn( zeroMatters       ));
        IsTrue (false     .FilledIn( zeroMatters: true ));
        IsTrue (false     .FilledIn(              true ));
        IsTrue (True      .FilledIn(                   ));
        IsTrue (True      .FilledIn( zeroMatters: false));
        IsTrue (True      .FilledIn(              false));
        IsTrue (True      .FilledIn( zeroMatters       ));
        IsTrue (True      .FilledIn( zeroMatters: true ));
        IsTrue (True      .FilledIn(              true ));
        IsFalse(False     .FilledIn(                   ));
        IsFalse(False     .FilledIn( zeroMatters: false));
        IsFalse(False     .FilledIn(              false));
        IsTrue (False     .FilledIn( zeroMatters       ));
        IsTrue (False     .FilledIn( zeroMatters: true ));
        IsTrue (False     .FilledIn(              true ));
        IsTrue (NullyTrue .FilledIn(                   ));
        IsTrue (NullyTrue .FilledIn( zeroMatters: false));
        IsTrue (NullyTrue .FilledIn(              false));
        IsTrue (NullyTrue .FilledIn( zeroMatters       ));
        IsTrue (NullyTrue .FilledIn( zeroMatters: true ));
        IsTrue (NullyTrue .FilledIn(              true ));
        IsFalse(NullyFalse.FilledIn(                   ));
        IsFalse(NullyFalse.FilledIn( zeroMatters: false));
        IsFalse(NullyFalse.FilledIn(              false));
        IsTrue (NullyFalse.FilledIn( zeroMatters       ));
        IsTrue (NullyFalse.FilledIn( zeroMatters: true ));
        IsTrue (NullyFalse.FilledIn(              true ));
        IsFalse(NullBool  .FilledIn(                   ));
        IsFalse(NullBool  .FilledIn( zeroMatters: false));
        IsFalse(NullBool  .FilledIn(              false));
        IsFalse(NullBool  .FilledIn( zeroMatters       ));
        IsFalse(NullBool  .FilledIn( zeroMatters: true ));
        IsFalse(NullBool  .FilledIn(              true ));
    }

    [TestMethod]
    public void Bool_Coalesce_ZeroMatters_Test()
    {
        IsTrue (Coalesce(False, NullyTrue, NullBool                        ));
        IsTrue (Coalesce(False, NullyTrue, NullBool,     zeroMatters: false));
        IsTrue (Coalesce(False, NullyTrue, NullBool,                  false));
        IsFalse(Coalesce(False, NullyTrue, NullBool,     zeroMatters       ));
        IsFalse(Coalesce(False, NullyTrue, NullBool,     zeroMatters: true ));
        IsFalse(Coalesce(False, NullyTrue, NullBool,                  true ));

        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue                    ));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters: false));
        IsTrue (NullyFalse.Coalesce(NullBool, NullyTrue,              false));
        IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters       ));
        IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue, zeroMatters: true ));
        IsFalse(NullyFalse.Coalesce(NullBool, NullyTrue,              true ));

        IsFalse(NullyFalse.Coalesce(NullBool                               ));
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters: false));
        IsFalse(NullyFalse.Coalesce(NullBool,                         false));
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters       ));
        IsFalse(NullyFalse.Coalesce(NullBool,            zeroMatters: true ));
        IsFalse(NullyFalse.Coalesce(NullBool,                         true ));
    }

    // Enums
        
    enum EnumWith0
    {
        OneLast = 1,
        ZeroFirst = 0 // Swapping doesn't change that default = 0
    }

    enum EnumNo0
    {
        OneFirst = 1,
        TwoLast = 2
    }

    EnumWith0? With0_Null             = null;
    EnumWith0  With0_Default          = default;
    EnumWith0? With0_DefaultNully     = default;
    EnumWith0  ZeroFirst              = EnumWith0.ZeroFirst;
    EnumWith0? ZeroFirst_Nully        = EnumWith0.ZeroFirst;
    EnumWith0  OneLast                = EnumWith0.OneLast;
    EnumWith0? OneLast_Nully          = EnumWith0.OneLast;
    EnumWith0  ZeroFirstInvalid       = (EnumWith0)(-1);
    EnumWith0? ZeroFirstInvalid_Nully = (EnumWith0)(-1);
    EnumNo0?   No0_Null               = null;
    EnumNo0    No0_Default            = default;
    EnumNo0?   No0_DefaultNully       = default;
    EnumNo0    OneFirst               = EnumNo0.OneFirst;
    EnumNo0?   OneFirst_Nully         = EnumNo0.OneFirst;
    EnumNo0    TwoLast                = EnumNo0.TwoLast;
    EnumNo0?   TwoLast_Nully          = EnumNo0.TwoLast;
    EnumNo0    No0Invalid             = (EnumNo0)(-1);
    EnumNo0?   No0Invalid_Nully       = (EnumNo0)(-1);

    [TestMethod]
    public void Enum_FilledIn_Test()
    {
        IsFalse (With0_Null        .FilledIn());
        IsFalse (With0_Default     .FilledIn());
        IsFalse (With0_DefaultNully.FilledIn());
        IsFalse (ZeroFirst         .FilledIn());
        IsFalse (ZeroFirst_Nully   .FilledIn());
        IsTrue  (OneLast           .FilledIn());
        IsTrue  (OneLast_Nully     .FilledIn());

        IsFalse (No0_Null          .FilledIn());
        IsFalse (No0_Default       .FilledIn());
        IsFalse (No0_DefaultNully  .FilledIn());
        IsTrue  (OneFirst          .FilledIn());
        IsTrue  (OneFirst_Nully    .FilledIn());
        IsTrue  (TwoLast           .FilledIn());
        IsTrue  (TwoLast_Nully     .FilledIn());
        AreEqual((EnumNo0)0, No0_Default);
    }

    [TestMethod]
    public void Enum_FilledIn_ZeroMatters_Test()
    {
        IsFalse (With0_Null        .FilledIn(                  ));
        IsFalse (With0_Null        .FilledIn(zeroMatters: false));
        IsFalse (With0_Null        .FilledIn(             false));
        IsFalse (With0_Null        .FilledIn(zeroMatters       ));
        IsFalse (With0_Null        .FilledIn(zeroMatters: true ));
        IsFalse (With0_Null        .FilledIn(             true ));
        IsFalse (With0_Default     .FilledIn(                  ));
        IsFalse (With0_Default     .FilledIn(zeroMatters: false));
        IsFalse (With0_Default     .FilledIn(             false));
        IsTrue  (With0_Default     .FilledIn(zeroMatters       ));
        IsTrue  (With0_Default     .FilledIn(zeroMatters: true ));
        IsTrue  (With0_Default     .FilledIn(             true ));
        IsFalse (With0_DefaultNully.FilledIn(                  ));
        IsFalse (With0_DefaultNully.FilledIn(zeroMatters: false));
        IsFalse (With0_DefaultNully.FilledIn(             false));
        IsFalse (With0_DefaultNully.FilledIn(zeroMatters       ));
        IsFalse (With0_DefaultNully.FilledIn(zeroMatters: true ));
        IsFalse (With0_DefaultNully.FilledIn(             true ));
        IsFalse (ZeroFirst         .FilledIn(                  ));
        IsFalse (ZeroFirst         .FilledIn(zeroMatters: false));
        IsFalse (ZeroFirst         .FilledIn(             false));
        IsTrue  (ZeroFirst         .FilledIn(zeroMatters       ));
        IsTrue  (ZeroFirst         .FilledIn(zeroMatters: true ));
        IsTrue  (ZeroFirst         .FilledIn(             true ));
        IsFalse (ZeroFirst_Nully   .FilledIn(                  ));
        IsFalse (ZeroFirst_Nully   .FilledIn(zeroMatters: false));
        IsFalse (ZeroFirst_Nully   .FilledIn(             false));
        IsTrue  (ZeroFirst_Nully   .FilledIn(zeroMatters       ));
        IsTrue  (ZeroFirst_Nully   .FilledIn(zeroMatters: true ));
        IsTrue  (ZeroFirst_Nully   .FilledIn(             true ));
        IsTrue  (OneLast           .FilledIn(                  ));
        IsTrue  (OneLast           .FilledIn(zeroMatters: false));
        IsTrue  (OneLast           .FilledIn(             false));
        IsTrue  (OneLast           .FilledIn(zeroMatters       ));
        IsTrue  (OneLast           .FilledIn(zeroMatters: true ));
        IsTrue  (OneLast           .FilledIn(             true ));
        IsTrue  (OneLast_Nully     .FilledIn(                  ));
        IsTrue  (OneLast_Nully     .FilledIn(zeroMatters: false));
        IsTrue  (OneLast_Nully     .FilledIn(             false));
        IsTrue  (OneLast_Nully     .FilledIn(zeroMatters       ));
        IsTrue  (OneLast_Nully     .FilledIn(zeroMatters: true ));
        IsTrue  (OneLast_Nully     .FilledIn(             true ));
        IsFalse (No0_Null          .FilledIn(                  ));
        IsFalse (No0_Null          .FilledIn(zeroMatters: false));
        IsFalse (No0_Null          .FilledIn(             false));
        IsFalse (No0_Null          .FilledIn(zeroMatters       ));
        IsFalse (No0_Null          .FilledIn(zeroMatters: true ));
        IsFalse (No0_Null          .FilledIn(             true ));
        IsFalse (No0_Default       .FilledIn(                  ));
        IsFalse (No0_Default       .FilledIn(zeroMatters: false));
        IsFalse (No0_Default       .FilledIn(             false));
        IsTrue  (No0_Default       .FilledIn(zeroMatters       ));
        IsTrue  (No0_Default       .FilledIn(zeroMatters: true ));
        IsTrue  (No0_Default       .FilledIn(             true ));
        IsFalse (No0_DefaultNully  .FilledIn(                  ));
        IsFalse (No0_DefaultNully  .FilledIn(zeroMatters: false));
        IsFalse (No0_DefaultNully  .FilledIn(             false));
        IsFalse (No0_DefaultNully  .FilledIn(zeroMatters       ));
        IsFalse (No0_DefaultNully  .FilledIn(zeroMatters: true ));
        IsFalse (No0_DefaultNully  .FilledIn(             true ));
        IsTrue  (OneFirst          .FilledIn(                  ));
        IsTrue  (OneFirst          .FilledIn(zeroMatters: false));
        IsTrue  (OneFirst          .FilledIn(             false));
        IsTrue  (OneFirst          .FilledIn(zeroMatters       ));
        IsTrue  (OneFirst          .FilledIn(zeroMatters: true ));
        IsTrue  (OneFirst          .FilledIn(             true ));
        IsTrue  (OneFirst_Nully    .FilledIn(                  ));
        IsTrue  (OneFirst_Nully    .FilledIn(zeroMatters: false));
        IsTrue  (OneFirst_Nully    .FilledIn(             false));
        IsTrue  (OneFirst_Nully    .FilledIn(zeroMatters       ));
        IsTrue  (OneFirst_Nully    .FilledIn(zeroMatters: true ));
        IsTrue  (OneFirst_Nully    .FilledIn(             true ));
        IsTrue  (TwoLast           .FilledIn(                  ));
        IsTrue  (TwoLast           .FilledIn(zeroMatters: false));
        IsTrue  (TwoLast           .FilledIn(             false));
        IsTrue  (TwoLast           .FilledIn(zeroMatters       ));
        IsTrue  (TwoLast           .FilledIn(zeroMatters: true ));
        IsTrue  (TwoLast           .FilledIn(             true ));
        IsTrue  (TwoLast_Nully     .FilledIn(                  ));
        IsTrue  (TwoLast_Nully     .FilledIn(zeroMatters: false));
        IsTrue  (TwoLast_Nully     .FilledIn(             false));
        IsTrue  (TwoLast_Nully     .FilledIn(zeroMatters       ));
        IsTrue  (TwoLast_Nully     .FilledIn(zeroMatters: true ));
        IsTrue  (TwoLast_Nully     .FilledIn(             true ));
        AreEqual((EnumNo0)0, No0_Default);
    }

    [TestMethod]
    public void Enum_Coalesce_Test()
    {
        // 3-Arg Static Nully
        NoNullRet(OneLast,   Coalesce(With0_Default, OneLast, ZeroFirst_Nully));
        // 4-Arg/Variadic Static Nully
        NoNullRet(OneLast,   Coalesce(With0_Default, With0_Null, OneLast, ZeroFirst_Nully));
        // Extension Method Variadic
        NoNullRet(OneFirst,  No0_Default.Coalesce(No0_Null, OneFirst, TwoLast));
        // Chaining, String Trailed, Mixed Static/Extensions
        NoNullRet("OneLast", Coalesce(With0_Default, With0_Null).Coalesce(OneLast).Coalesce("Never"));
    }

    [TestMethod]
    public void Enum_Coalesce_ZeroMatters_Test()
    {
        // 3-Arg Static Nully, Flags Front and Back
        NoNullRet(OneLast,   Coalesce(                    With0_Default, OneLast, ZeroFirst_Nully));
        NoNullRet(OneLast,   Coalesce(zeroMatters: false, With0_Default, OneLast, ZeroFirst_Nully));
        NoNullRet(OneLast,   Coalesce(             false, With0_Default, OneLast, ZeroFirst_Nully));
        NoNullRet(ZeroFirst, Coalesce(zeroMatters,        With0_Default, OneLast, ZeroFirst_Nully));
        NoNullRet(ZeroFirst, Coalesce(zeroMatters: true,  With0_Default, OneLast, ZeroFirst_Nully));
        NoNullRet(ZeroFirst, Coalesce(             true,  With0_Default, OneLast, ZeroFirst_Nully));
        NoNullRet(OneLast,   Coalesce(With0_Default, OneLast, ZeroFirst_Nully                    ));
        NoNullRet(OneLast,   Coalesce(With0_Default, OneLast, ZeroFirst_Nully, zeroMatters: false));
        NoNullRet(OneLast,   Coalesce(With0_Default, OneLast, ZeroFirst_Nully,              false));
        NoNullRet(ZeroFirst, Coalesce(With0_Default, OneLast, ZeroFirst_Nully, zeroMatters       ));
        NoNullRet(ZeroFirst, Coalesce(With0_Default, OneLast, ZeroFirst_Nully, zeroMatters: true ));
        NoNullRet(ZeroFirst, Coalesce(With0_Default, OneLast, ZeroFirst_Nully,              true ));
        
        // Variadic/4-Arg Static Nully, Flags always the Front
        NoNullRet(OneLast,   Coalesce(                    With0_Default, With0_Null, OneLast, ZeroFirst_Nully));
        NoNullRet(OneLast,   Coalesce(zeroMatters: false, With0_Default, With0_Null, OneLast, ZeroFirst_Nully));
        NoNullRet(OneLast,   Coalesce(             false, With0_Default, With0_Null, OneLast, ZeroFirst_Nully));
        NoNullRet(ZeroFirst, Coalesce(zeroMatters,        With0_Default, With0_Null, OneLast, ZeroFirst_Nully));
        NoNullRet(ZeroFirst, Coalesce(zeroMatters: true,  With0_Default, With0_Null, OneLast, ZeroFirst_Nully));
        NoNullRet(ZeroFirst, Coalesce(             true,  With0_Default, With0_Null, OneLast, ZeroFirst_Nully));

        // Chaining, String Trailed, Mixed Static/Extensions
        NoNullRet("OneLast",   Coalesce(With0_Default, With0_Null                    ).Coalesce(OneLast                    ).Coalesce("Never"                    ));
        NoNullRet("OneLast",   Coalesce(With0_Default, With0_Null, zeroMatters: false).Coalesce(OneLast, zeroMatters: false).Coalesce("Never", zeroMatters: false));
        NoNullRet("OneLast",   Coalesce(With0_Default, With0_Null,              false).Coalesce(OneLast,              false).Coalesce("Never",              false));
        NoNullRet("ZeroFirst", Coalesce(With0_Default, With0_Null, zeroMatters       ).Coalesce(OneLast, zeroMatters       ).Coalesce("Never", zeroMatters       ));
        NoNullRet("ZeroFirst", Coalesce(With0_Default, With0_Null, zeroMatters: true ).Coalesce(OneLast, zeroMatters: true ).Coalesce("Never", zeroMatters: true ));
        NoNullRet("ZeroFirst", Coalesce(With0_Default, With0_Null,              true ).Coalesce(OneLast,              true ).Coalesce("Never",              true ));

        // Extension Method, Variadic
        NoNullRet(OneFirst,   No0_Default.Coalesce(                    No0_Null, OneFirst, TwoLast));
        NoNullRet(OneFirst,   No0_Default.Coalesce(zeroMatters: false, No0_Null, OneFirst, TwoLast));
        NoNullRet(OneFirst,   No0_Default.Coalesce(             false, No0_Null, OneFirst, TwoLast));
        NoNullRet((EnumNo0)0, No0_Default.Coalesce(zeroMatters,        No0_Null, OneFirst, TwoLast));
        NoNullRet((EnumNo0)0, No0_Default.Coalesce(zeroMatters: true,  No0_Null, OneFirst, TwoLast));
        NoNullRet((EnumNo0)0, No0_Default.Coalesce(             true,  No0_Null, OneFirst, TwoLast));
    }

    /// <summary>
    /// TODO: Detect enum values out of range eventually and see them as not filled in.
    /// </summary>
    [TestMethod]
    public void Enum_FilledIn_UnspecifiedValues_Test()
    {
      // IsFalse (ZeroFirstInvalid.FilledIn()); 
      // IsFalse (ZeroFirstInvalidNully.FilledIn()); 
      // IsFalse (OneFirstInvalid.FilledIn()); 
      // IsFalse (OneFirstInvalidNully.FilledIn()); 
        IsTrue  (ZeroFirstInvalid      .FilledIn());
        IsTrue  (ZeroFirstInvalid_Nully.FilledIn());
        IsTrue  (No0Invalid            .FilledIn());
        IsTrue  (No0Invalid_Nully      .FilledIn());
    }

    /// <summary>
    /// TODO: Trailing String/bool combos are a little less flexible: Too much type confusion.
    /// Add more flag in front overloads to resolve better and more optimally and more well behaved.
    /// </summary>
    [TestMethod]
    public void Enum_Coalesce_FlagInFront_Confusion()
    {
        NoNullRet("OneLast",   Coalesce(                    With0_Default, With0_Null).Coalesce(                    OneLast).Coalesce(                    "Never"));
      //NoNullRet("OneLast",   Coalesce(zeroMatters: false, With0_Default, With0_Null).Coalesce(zeroMatters: false, OneLast).Coalesce(zeroMatters: false, "Never"));
        NoNullRet("OneLast",   Coalesce(             false, With0_Default, With0_Null).Coalesce(             false, OneLast).Coalesce(             false, "Never"));
        NoNullRet("ZeroFirst", Coalesce(zeroMatters,        With0_Default, With0_Null).Coalesce(zeroMatters,        OneLast).Coalesce(zeroMatters,        "Never"));
      //NoNullRet("ZeroFirst", Coalesce(zeroMatters: true,  With0_Default, With0_Null).Coalesce(zeroMatters: true,  OneLast).Coalesce(zeroMatters: true,  "Never"));
        NoNullRet("ZeroFirst", Coalesce(             true,  With0_Default, With0_Null).Coalesce(             true,  OneLast).Coalesce(             true,  "Never"));
    }

    // Double

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
    public void Double_FilledIn_ZeroMatters_Tests()
    {
        IsFalse(Has(NullDouble                         ));
        IsFalse(Has(NullDouble,      zeroMatters: false));
        IsFalse(Has(NullDouble,                   false));
        IsFalse(Has(NullDouble,      zeroMatters       ));
        IsFalse(Has(NullDouble,      zeroMatters: true ));
        IsFalse(Has(NullDouble,                   true ));
        IsFalse(Has(ZeroDouble                         ));
        IsFalse(Has(ZeroDouble,      zeroMatters: false));
        IsFalse(Has(ZeroDouble,                   false));
        IsTrue (Has(ZeroDouble,      zeroMatters       ));
        IsTrue (Has(ZeroDouble,      zeroMatters: true ));
        IsTrue (Has(ZeroDouble,                   true ));
        IsTrue (Has(OneDouble                          ));
        IsTrue (Has(OneDouble,       zeroMatters: false));
        IsTrue (Has(OneDouble,                    false));
        IsTrue (Has(OneDouble,       zeroMatters       ));
        IsTrue (Has(OneDouble,       zeroMatters: true ));
        IsTrue (Has(OneDouble,                    true ));
        IsTrue (Has(TwoDouble                          ));
        IsTrue (Has(TwoDouble,       zeroMatters: false));
        IsTrue (Has(TwoDouble,                    false));
        IsTrue (Has(TwoDouble,       zeroMatters       ));
        IsTrue (Has(TwoDouble,       zeroMatters: true ));
        IsTrue (Has(TwoDouble,                    true ));
        IsFalse(Has(NullyZeroDouble                    ));
        IsFalse(Has(NullyZeroDouble, zeroMatters: false));
        IsFalse(Has(NullyZeroDouble,              false));
        IsTrue (Has(NullyZeroDouble, zeroMatters       ));
        IsTrue (Has(NullyZeroDouble, zeroMatters: true ));
        IsTrue (Has(NullyZeroDouble,              true ));
        IsTrue (Has(NullyOneDouble                     ));
        IsTrue (Has(NullyOneDouble,  zeroMatters: false));
        IsTrue (Has(NullyOneDouble,               false));
        IsTrue (Has(NullyOneDouble,  zeroMatters       ));
        IsTrue (Has(NullyOneDouble,  zeroMatters: true ));
        IsTrue (Has(NullyOneDouble,               true ));
        IsTrue (Has(NullyTwoDouble                     ));
        IsTrue (Has(NullyTwoDouble,  zeroMatters: false));
        IsTrue (Has(NullyTwoDouble,               false));
        IsTrue (Has(NullyTwoDouble,  zeroMatters       ));
        IsTrue (Has(NullyTwoDouble,  zeroMatters: true ));
        IsTrue (Has(NullyTwoDouble,               true ));

        IsFalse(FilledIn(NullDouble                         ));
        IsFalse(FilledIn(NullDouble,      zeroMatters: false));
        IsFalse(FilledIn(NullDouble,                   false));
        IsFalse(FilledIn(NullDouble,      zeroMatters       ));
        IsFalse(FilledIn(NullDouble,      zeroMatters: true ));
        IsFalse(FilledIn(NullDouble,                   true ));
        IsFalse(FilledIn(ZeroDouble                         ));
        IsFalse(FilledIn(ZeroDouble,      zeroMatters: false));
        IsFalse(FilledIn(ZeroDouble,                   false));
        IsTrue (FilledIn(ZeroDouble,      zeroMatters       ));
        IsTrue (FilledIn(ZeroDouble,      zeroMatters: true ));
        IsTrue (FilledIn(ZeroDouble,                   true ));
        IsTrue (FilledIn(OneDouble                          ));
        IsTrue (FilledIn(OneDouble,       zeroMatters: false));
        IsTrue (FilledIn(OneDouble,                    false));
        IsTrue (FilledIn(OneDouble,       zeroMatters       ));
        IsTrue (FilledIn(OneDouble,       zeroMatters: true ));
        IsTrue (FilledIn(OneDouble,                    true ));
        IsTrue (FilledIn(TwoDouble                          ));
        IsTrue (FilledIn(TwoDouble,       zeroMatters: false));
        IsTrue (FilledIn(TwoDouble,                    false));
        IsTrue (FilledIn(TwoDouble,       zeroMatters       ));
        IsTrue (FilledIn(TwoDouble,       zeroMatters: true ));
        IsTrue (FilledIn(TwoDouble,                    true ));
        IsFalse(FilledIn(NullyZeroDouble                    ));
        IsFalse(FilledIn(NullyZeroDouble, zeroMatters: false));
        IsFalse(FilledIn(NullyZeroDouble,              false));
        IsTrue (FilledIn(NullyZeroDouble, zeroMatters       ));
        IsTrue (FilledIn(NullyZeroDouble, zeroMatters: true ));
        IsTrue (FilledIn(NullyZeroDouble,              true ));
        IsTrue (FilledIn(NullyOneDouble                     ));
        IsTrue (FilledIn(NullyOneDouble,  zeroMatters: false));
        IsTrue (FilledIn(NullyOneDouble,               false));
        IsTrue (FilledIn(NullyOneDouble,  zeroMatters       ));
        IsTrue (FilledIn(NullyOneDouble,  zeroMatters: true ));
        IsTrue (FilledIn(NullyOneDouble,               true ));
        IsTrue (FilledIn(NullyTwoDouble                     ));
        IsTrue (FilledIn(NullyTwoDouble,  zeroMatters: false));
        IsTrue (FilledIn(NullyTwoDouble,               false));
        IsTrue (FilledIn(NullyTwoDouble,  zeroMatters       ));
        IsTrue (FilledIn(NullyTwoDouble,  zeroMatters: true ));
        IsTrue (FilledIn(NullyTwoDouble,               true ));

        IsFalse(NullDouble     .FilledIn(                   ));
        IsFalse(NullDouble     .FilledIn( zeroMatters: false));
        IsFalse(NullDouble     .FilledIn(              false));
        IsFalse(NullDouble     .FilledIn( zeroMatters       ));
        IsFalse(NullDouble     .FilledIn( zeroMatters: true ));
        IsFalse(NullDouble     .FilledIn(              true ));
        IsFalse(ZeroDouble     .FilledIn(                   ));
        IsFalse(ZeroDouble     .FilledIn( zeroMatters: false));
        IsFalse(ZeroDouble     .FilledIn(              false));
        IsTrue (ZeroDouble     .FilledIn( zeroMatters       ));
        IsTrue (ZeroDouble     .FilledIn( zeroMatters: true ));
        IsTrue (ZeroDouble     .FilledIn(              true ));
        IsTrue (OneDouble      .FilledIn(                   ));
        IsTrue (OneDouble      .FilledIn( zeroMatters: false));
        IsTrue (OneDouble      .FilledIn(              false));
        IsTrue (OneDouble      .FilledIn( zeroMatters       ));
        IsTrue (OneDouble      .FilledIn( zeroMatters: true ));
        IsTrue (OneDouble      .FilledIn(              true ));
        IsTrue (TwoDouble      .FilledIn(                   ));
        IsTrue (TwoDouble      .FilledIn( zeroMatters: false));
        IsTrue (TwoDouble      .FilledIn(              false));
        IsTrue (TwoDouble      .FilledIn( zeroMatters       ));
        IsTrue (TwoDouble      .FilledIn( zeroMatters: true ));
        IsTrue (TwoDouble      .FilledIn(              true ));
        IsFalse(NullyZeroDouble.FilledIn(                   ));
        IsFalse(NullyZeroDouble.FilledIn( zeroMatters: false));
        IsFalse(NullyZeroDouble.FilledIn(              false));
        IsTrue (NullyZeroDouble.FilledIn( zeroMatters       ));
        IsTrue (NullyZeroDouble.FilledIn( zeroMatters: true ));
        IsTrue (NullyZeroDouble.FilledIn(              true ));
        IsTrue (NullyOneDouble .FilledIn(                   ));
        IsTrue (NullyOneDouble .FilledIn( zeroMatters: false));
        IsTrue (NullyOneDouble .FilledIn(              false));
        IsTrue (NullyOneDouble .FilledIn( zeroMatters       ));
        IsTrue (NullyOneDouble .FilledIn( zeroMatters: true ));
        IsTrue (NullyOneDouble .FilledIn(              true ));
        IsTrue (NullyTwoDouble .FilledIn(                   ));
        IsTrue (NullyTwoDouble .FilledIn( zeroMatters: false));
        IsTrue (NullyTwoDouble .FilledIn(              false));
        IsTrue (NullyTwoDouble .FilledIn( zeroMatters       ));
        IsTrue (NullyTwoDouble .FilledIn( zeroMatters: true ));
        IsTrue (NullyTwoDouble .FilledIn(              true ));
    }

    [TestMethod]
    public void Double_Coalesce_Tests()
    {
        NoNullRet(OneDouble, Coalesce(NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(TwoDouble, Coalesce(NullDouble, ZeroDouble).Coalesce(TwoDouble).Coalesce(NullyOneDouble));
        NoNullRet(OneDouble, NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble));
    }

    // TODO: Use zeroMatters flags.

    /*
    [TestMethod]
    public void Double_Coalesce_ZeroMatters_Tests()
    {
        NoNullRet(OneDouble, Coalesce(NullDouble, ZeroDouble, OneDouble, NullyTwoDouble));
        NoNullRet(TwoDouble, Coalesce(NullDouble, ZeroDouble).Coalesce(TwoDouble).Coalesce(NullyOneDouble));
        NoNullRet(OneDouble, NullyZeroDouble.Coalesce(NullyOneDouble, OneDouble));
    }
    */

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
        // Obviously not filled
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

