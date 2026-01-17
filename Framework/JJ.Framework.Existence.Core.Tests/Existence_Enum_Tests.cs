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
    public void Test_Enum_Existence_Verify0IsDefault()
    {
        AreEqual((EnumNo0)0, No0_Default);
    }

    [TestMethod]
    public void Test_Enum_Has()
    {
        IsFalse(Has(With0_Null             ));
        IsFalse(Has(With0_Default          ));
        IsFalse(Has(With0_DefaultNully     ));
        IsFalse(Has(ZeroFirst              ));
        IsFalse(Has(ZeroFirst_Nully        ));
        IsTrue (Has(OneLast                ));
        IsTrue (Has(OneLast_Nully          ));
        IsFalse(Has(No0_Null               ));
        IsFalse(Has(No0_Default            ));
        IsFalse(Has(No0_DefaultNully       ));
        IsTrue (Has(OneFirst               ));
        IsTrue (Has(OneFirst_Nully         ));
        IsTrue (Has(TwoLast                ));
        IsTrue (Has(TwoLast_Nully          ));
    }

    [TestMethod]
    public void Test_Enum_FilledIn_Static()
    {
        IsFalse(FilledIn(With0_Null        ));
        IsFalse(FilledIn(With0_Default     ));
        IsFalse(FilledIn(With0_DefaultNully));
        IsFalse(FilledIn(ZeroFirst         ));
        IsFalse(FilledIn(ZeroFirst_Nully   ));
        IsTrue (FilledIn(OneLast           ));
        IsTrue (FilledIn(OneLast_Nully     ));
        IsFalse(FilledIn(No0_Null          ));
        IsFalse(FilledIn(No0_Default       ));
        IsFalse(FilledIn(No0_DefaultNully  ));
        IsTrue (FilledIn(OneFirst          ));
        IsTrue (FilledIn(OneFirst_Nully    ));
        IsTrue (FilledIn(TwoLast           ));
        IsTrue (FilledIn(TwoLast_Nully     ));
    }

    [TestMethod]
    public void Test_Enum_FilledIn_Extensions()
    {
        IsFalse(With0_Null        .FilledIn());
        IsFalse(With0_Default     .FilledIn());
        IsFalse(With0_DefaultNully.FilledIn());
        IsFalse(ZeroFirst         .FilledIn());
        IsFalse(ZeroFirst_Nully   .FilledIn());
        IsTrue (OneLast           .FilledIn());
        IsTrue (OneLast_Nully     .FilledIn());
        IsFalse(No0_Null          .FilledIn());
        IsFalse(No0_Default       .FilledIn());
        IsFalse(No0_DefaultNully  .FilledIn());
        IsTrue (OneFirst          .FilledIn());
        IsTrue (OneFirst_Nully    .FilledIn());
        IsTrue (TwoLast           .FilledIn());
        IsTrue (TwoLast_Nully     .FilledIn());
    }

    [TestMethod]
    public void Test_Enum_IsNully_Static()
    {
        IsTrue (IsNully (With0_Null        ));
        IsTrue (IsNully (With0_Default     ));
        IsTrue (IsNully (With0_DefaultNully));
        IsTrue (IsNully (ZeroFirst         ));
        IsTrue (IsNully (ZeroFirst_Nully   ));
        IsFalse(IsNully (OneLast           ));
        IsFalse(IsNully (OneLast_Nully     ));
        IsTrue (IsNully (No0_Null          ));
        IsTrue (IsNully (No0_Default       ));
        IsTrue (IsNully (No0_DefaultNully  ));
        IsFalse(IsNully (OneFirst          ));
        IsFalse(IsNully (OneFirst_Nully    ));
        IsFalse(IsNully (TwoLast           ));
        IsFalse(IsNully (TwoLast_Nully     ));
    }

    [TestMethod]
    public void Test_Enum_IsNully_Extensions()
    {
        IsTrue (With0_Null        .IsNully ());
        IsTrue (With0_Default     .IsNully ());
        IsTrue (With0_DefaultNully.IsNully ());
        IsTrue (ZeroFirst         .IsNully ());
        IsTrue (ZeroFirst_Nully   .IsNully ());
        IsFalse(OneLast           .IsNully ());
        IsFalse(OneLast_Nully     .IsNully ());
        IsTrue (No0_Null          .IsNully ());
        IsTrue (No0_Default       .IsNully ());
        IsTrue (No0_DefaultNully  .IsNully ());
        IsFalse(OneFirst          .IsNully ());
        IsFalse(OneFirst_Nully    .IsNully ());
        IsFalse(TwoLast           .IsNully ());
        IsFalse(TwoLast_Nully     .IsNully ());
    }

    [TestMethod]
    public void Test_Enum_Has_ZeroMatters()
    {
        IsFalse (Has     (With0_Null                            ));
        IsFalse (Has     (With0_Null,         zeroMatters: false));
        IsFalse (Has     (With0_Null,                      false));
        IsFalse (Has     (With0_Null,         zeroMatters       ));
        IsFalse (Has     (With0_Null,         zeroMatters: true ));
        IsFalse (Has     (With0_Null,                      true ));
        IsFalse (Has     (With0_Default                         ));
        IsFalse (Has     (With0_Default,      zeroMatters: false));
        IsFalse (Has     (With0_Default,                   false));
        IsTrue  (Has     (With0_Default,      zeroMatters       ));
        IsTrue  (Has     (With0_Default,      zeroMatters: true ));
        IsTrue  (Has     (With0_Default,                   true ));
        IsFalse (Has     (With0_DefaultNully                    ));
        IsFalse (Has     (With0_DefaultNully, zeroMatters: false));
        IsFalse (Has     (With0_DefaultNully,              false));
        IsFalse (Has     (With0_DefaultNully, zeroMatters       ));
        IsFalse (Has     (With0_DefaultNully, zeroMatters: true ));
        IsFalse (Has     (With0_DefaultNully,              true ));
        IsFalse (Has     (ZeroFirst                             ));
        IsFalse (Has     (ZeroFirst,          zeroMatters: false));
        IsFalse (Has     (ZeroFirst,                       false));
        IsTrue  (Has     (ZeroFirst,          zeroMatters       ));
        IsTrue  (Has     (ZeroFirst,          zeroMatters: true ));
        IsTrue  (Has     (ZeroFirst,                       true ));
        IsFalse (Has     (ZeroFirst_Nully                       ));
        IsFalse (Has     (ZeroFirst_Nully,    zeroMatters: false));
        IsFalse (Has     (ZeroFirst_Nully,                 false));
        IsTrue  (Has     (ZeroFirst_Nully,    zeroMatters       ));
        IsTrue  (Has     (ZeroFirst_Nully,    zeroMatters: true ));
        IsTrue  (Has     (ZeroFirst_Nully,                 true ));
        IsTrue  (Has     (OneLast                               ));
        IsTrue  (Has     (OneLast,            zeroMatters: false));
        IsTrue  (Has     (OneLast,                         false));
        IsTrue  (Has     (OneLast,            zeroMatters       ));
        IsTrue  (Has     (OneLast,            zeroMatters: true ));
        IsTrue  (Has     (OneLast,                         true ));
        IsTrue  (Has     (OneLast_Nully                         ));
        IsTrue  (Has     (OneLast_Nully,      zeroMatters: false));
        IsTrue  (Has     (OneLast_Nully,                   false));
        IsTrue  (Has     (OneLast_Nully,      zeroMatters       ));
        IsTrue  (Has     (OneLast_Nully,      zeroMatters: true ));
        IsTrue  (Has     (OneLast_Nully,                   true ));
        IsFalse (Has     (No0_Null                              ));
        IsFalse (Has     (No0_Null,           zeroMatters: false));
        IsFalse (Has     (No0_Null,                        false));
        IsFalse (Has     (No0_Null,           zeroMatters       ));
        IsFalse (Has     (No0_Null,           zeroMatters: true ));
        IsFalse (Has     (No0_Null,                        true ));
        IsFalse (Has     (No0_Default                           ));
        IsFalse (Has     (No0_Default,        zeroMatters: false));
        IsFalse (Has     (No0_Default,                     false));
        IsTrue  (Has     (No0_Default,        zeroMatters       ));
        IsTrue  (Has     (No0_Default,        zeroMatters: true ));
        IsTrue  (Has     (No0_Default,                     true ));
        IsFalse (Has     (No0_DefaultNully                      ));
        IsFalse (Has     (No0_DefaultNully,   zeroMatters: false));
        IsFalse (Has     (No0_DefaultNully,                false));
        IsFalse (Has     (No0_DefaultNully,   zeroMatters       ));
        IsFalse (Has     (No0_DefaultNully,   zeroMatters: true ));
        IsFalse (Has     (No0_DefaultNully,                true ));
        IsTrue  (Has     (OneFirst                              ));
        IsTrue  (Has     (OneFirst,           zeroMatters: false));
        IsTrue  (Has     (OneFirst,                        false));
        IsTrue  (Has     (OneFirst,           zeroMatters       ));
        IsTrue  (Has     (OneFirst,           zeroMatters: true ));
        IsTrue  (Has     (OneFirst,                        true ));
        IsTrue  (Has     (OneFirst_Nully                        ));
        IsTrue  (Has     (OneFirst_Nully,     zeroMatters: false));
        IsTrue  (Has     (OneFirst_Nully,                  false));
        IsTrue  (Has     (OneFirst_Nully,     zeroMatters       ));
        IsTrue  (Has     (OneFirst_Nully,     zeroMatters: true ));
        IsTrue  (Has     (OneFirst_Nully,                  true ));
        IsTrue  (Has     (TwoLast                               ));
        IsTrue  (Has     (TwoLast,            zeroMatters: false));
        IsTrue  (Has     (TwoLast,                         false));
        IsTrue  (Has     (TwoLast,            zeroMatters       ));
        IsTrue  (Has     (TwoLast,            zeroMatters: true ));
        IsTrue  (Has     (TwoLast,                         true ));
        IsTrue  (Has     (TwoLast_Nully                         ));
        IsTrue  (Has     (TwoLast_Nully,      zeroMatters: false));
        IsTrue  (Has     (TwoLast_Nully,                   false));
        IsTrue  (Has     (TwoLast_Nully,      zeroMatters       ));
        IsTrue  (Has     (TwoLast_Nully,      zeroMatters: true ));
        IsTrue  (Has     (TwoLast_Nully,                   true ));
    }

    [TestMethod]
    public void Test_Enum_FilledIn_Extensions_ZeroMatters()
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
    }

    [TestMethod]
    public void Test_Enum_FilledIn_Static_ZeroMatters()
    {
        IsFalse (FilledIn(With0_Null                            ));
        IsFalse (FilledIn(With0_Null,         zeroMatters: false));
        IsFalse (FilledIn(With0_Null,                      false));
        IsFalse (FilledIn(With0_Null,         zeroMatters       ));
        IsFalse (FilledIn(With0_Null,         zeroMatters: true ));
        IsFalse (FilledIn(With0_Null,                      true ));
        IsFalse (FilledIn(With0_Default                         ));
        IsFalse (FilledIn(With0_Default,      zeroMatters: false));
        IsFalse (FilledIn(With0_Default,                   false));
        IsTrue  (FilledIn(With0_Default,      zeroMatters       ));
        IsTrue  (FilledIn(With0_Default,      zeroMatters: true ));
        IsTrue  (FilledIn(With0_Default,                   true ));
        IsFalse (FilledIn(With0_DefaultNully                    ));
        IsFalse (FilledIn(With0_DefaultNully, zeroMatters: false));
        IsFalse (FilledIn(With0_DefaultNully,              false));
        IsFalse (FilledIn(With0_DefaultNully, zeroMatters       ));
        IsFalse (FilledIn(With0_DefaultNully, zeroMatters: true ));
        IsFalse (FilledIn(With0_DefaultNully,              true ));
        IsFalse (FilledIn(ZeroFirst                             ));
        IsFalse (FilledIn(ZeroFirst,          zeroMatters: false));
        IsFalse (FilledIn(ZeroFirst,                       false));
        IsTrue  (FilledIn(ZeroFirst,          zeroMatters       ));
        IsTrue  (FilledIn(ZeroFirst,          zeroMatters: true ));
        IsTrue  (FilledIn(ZeroFirst,                       true ));
        IsFalse (FilledIn(ZeroFirst_Nully                       ));
        IsFalse (FilledIn(ZeroFirst_Nully,    zeroMatters: false));
        IsFalse (FilledIn(ZeroFirst_Nully,                 false));
        IsTrue  (FilledIn(ZeroFirst_Nully,    zeroMatters       ));
        IsTrue  (FilledIn(ZeroFirst_Nully,    zeroMatters: true ));
        IsTrue  (FilledIn(ZeroFirst_Nully,                 true ));
        IsTrue  (FilledIn(OneLast                               ));
        IsTrue  (FilledIn(OneLast,            zeroMatters: false));
        IsTrue  (FilledIn(OneLast,                         false));
        IsTrue  (FilledIn(OneLast,            zeroMatters       ));
        IsTrue  (FilledIn(OneLast,            zeroMatters: true ));
        IsTrue  (FilledIn(OneLast,                         true ));
        IsTrue  (FilledIn(OneLast_Nully                         ));
        IsTrue  (FilledIn(OneLast_Nully,      zeroMatters: false));
        IsTrue  (FilledIn(OneLast_Nully,                   false));
        IsTrue  (FilledIn(OneLast_Nully,      zeroMatters       ));
        IsTrue  (FilledIn(OneLast_Nully,      zeroMatters: true ));
        IsTrue  (FilledIn(OneLast_Nully,                   true ));
        IsFalse (FilledIn(No0_Null                              ));
        IsFalse (FilledIn(No0_Null,           zeroMatters: false));
        IsFalse (FilledIn(No0_Null,                        false));
        IsFalse (FilledIn(No0_Null,           zeroMatters       ));
        IsFalse (FilledIn(No0_Null,           zeroMatters: true ));
        IsFalse (FilledIn(No0_Null,                        true ));
        IsFalse (FilledIn(No0_Default                           ));
        IsFalse (FilledIn(No0_Default,        zeroMatters: false));
        IsFalse (FilledIn(No0_Default,                     false));
        IsTrue  (FilledIn(No0_Default,        zeroMatters       ));
        IsTrue  (FilledIn(No0_Default,        zeroMatters: true ));
        IsTrue  (FilledIn(No0_Default,                     true ));
        IsFalse (FilledIn(No0_DefaultNully                      ));
        IsFalse (FilledIn(No0_DefaultNully,   zeroMatters: false));
        IsFalse (FilledIn(No0_DefaultNully,                false));
        IsFalse (FilledIn(No0_DefaultNully,   zeroMatters       ));
        IsFalse (FilledIn(No0_DefaultNully,   zeroMatters: true ));
        IsFalse (FilledIn(No0_DefaultNully,                true ));
        IsTrue  (FilledIn(OneFirst                              ));
        IsTrue  (FilledIn(OneFirst,           zeroMatters: false));
        IsTrue  (FilledIn(OneFirst,                        false));
        IsTrue  (FilledIn(OneFirst,           zeroMatters       ));
        IsTrue  (FilledIn(OneFirst,           zeroMatters: true ));
        IsTrue  (FilledIn(OneFirst,                        true ));
        IsTrue  (FilledIn(OneFirst_Nully                        ));
        IsTrue  (FilledIn(OneFirst_Nully,     zeroMatters: false));
        IsTrue  (FilledIn(OneFirst_Nully,                  false));
        IsTrue  (FilledIn(OneFirst_Nully,     zeroMatters       ));
        IsTrue  (FilledIn(OneFirst_Nully,     zeroMatters: true ));
        IsTrue  (FilledIn(OneFirst_Nully,                  true ));
        IsTrue  (FilledIn(TwoLast                               ));
        IsTrue  (FilledIn(TwoLast,            zeroMatters: false));
        IsTrue  (FilledIn(TwoLast,                         false));
        IsTrue  (FilledIn(TwoLast,            zeroMatters       ));
        IsTrue  (FilledIn(TwoLast,            zeroMatters: true ));
        IsTrue  (FilledIn(TwoLast,                         true ));
        IsTrue  (FilledIn(TwoLast_Nully                         ));
        IsTrue  (FilledIn(TwoLast_Nully,      zeroMatters: false));
        IsTrue  (FilledIn(TwoLast_Nully,                   false));
        IsTrue  (FilledIn(TwoLast_Nully,      zeroMatters       ));
        IsTrue  (FilledIn(TwoLast_Nully,      zeroMatters: true ));
        IsTrue  (FilledIn(TwoLast_Nully,                   true ));
    }

    // TODO: Test IsNully with zeroMatters flags.

    [TestMethod]
    public void Test_Enum_Coalesce()
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
    public void Test_Enum_Coalesce_ZeroMatters()
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
    public void BUG_Enum_FilledIn_UnspecifiedValues_SeenAsFilledIn()
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
}