namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Enum_Tests
{
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
}