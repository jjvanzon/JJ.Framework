namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Guid_Tests
{
    // Guid

    readonly Guid? NullGuid = null;
    readonly Guid  EmptyGuid = Guid.Empty;
    readonly Guid? EmptyNullyGuid = Guid.Empty;
    readonly Guid  ZeroGuid = new("00000000-0000-0000-0000-000000000000");
    readonly Guid? ZeroNullyGuid = new("00000000-0000-0000-0000-000000000000");
    readonly Guid  OneGuid = new("00000000-0000-0000-0000-000000000001");
    readonly Guid? OneNullyGuid = new("00000000-0000-0000-0000-000000000001");
    readonly Guid  RandomGuid = Guid.NewGuid();
    readonly Guid? RandomNullyGuid = Guid.NewGuid();

    [TestMethod]
    public void Test_Guid_Has()
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
    }

    [TestMethod]
    public void Test_Guid_FilledIn()
    {
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
    }

    [TestMethod]
    public void Test_Guid_IsNully()
    {
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
    }

    [TestMethod]
    public void Test_Guid_Coalesce()
    {
        NoNullRet(OneGuid, Coalesce(NullGuid, EmptyGuid).Coalesce(ZeroGuid, OneGuid, RandomGuid));
    }

    [TestMethod]
    public void Test_Guid_Has_ZeroMatters()
    {
        IsFalse(Has     (NullGuid                           ));
        IsFalse(Has     (NullGuid,        zeroMatters: false));
        IsFalse(Has     (NullGuid,                     false));
        IsFalse(Has     (NullGuid,        zeroMatters       ));
        IsFalse(Has     (NullGuid,        zeroMatters: true ));
        IsFalse(Has     (NullGuid,                     true ));
        IsFalse(Has     (EmptyGuid                          ));
        IsFalse(Has     (EmptyGuid,       zeroMatters: false));
        IsFalse(Has     (EmptyGuid,                    false));
        IsTrue (Has     (EmptyGuid,       zeroMatters       ));
        IsTrue (Has     (EmptyGuid,       zeroMatters: true ));
        IsTrue (Has     (EmptyGuid,                    true ));
        IsFalse(Has     (EmptyNullyGuid                     ));
        IsFalse(Has     (EmptyNullyGuid,  zeroMatters: false));
        IsFalse(Has     (EmptyNullyGuid,               false));
        IsTrue (Has     (EmptyNullyGuid,  zeroMatters       ));
        IsTrue (Has     (EmptyNullyGuid,  zeroMatters: true ));
        IsTrue (Has     (EmptyNullyGuid,               true ));
        IsFalse(Has     (ZeroGuid                           ));
        IsFalse(Has     (ZeroGuid,        zeroMatters: false));
        IsFalse(Has     (ZeroGuid,                     false));
        IsTrue (Has     (ZeroGuid,        zeroMatters       ));
        IsTrue (Has     (ZeroGuid,        zeroMatters: true ));
        IsTrue (Has     (ZeroGuid,                     true ));
        IsFalse(Has     (ZeroNullyGuid                      ));
        IsFalse(Has     (ZeroNullyGuid,   zeroMatters: false));
        IsFalse(Has     (ZeroNullyGuid,                false));
        IsTrue (Has     (ZeroNullyGuid,   zeroMatters       ));
        IsTrue (Has     (ZeroNullyGuid,   zeroMatters: true ));
        IsTrue (Has     (ZeroNullyGuid,                true ));
        IsTrue (Has     (OneGuid                            ));
        IsTrue (Has     (OneGuid,         zeroMatters: false));
        IsTrue (Has     (OneGuid,                      false));
        IsTrue (Has     (OneGuid,         zeroMatters       ));
        IsTrue (Has     (OneGuid,         zeroMatters: true ));
        IsTrue (Has     (OneGuid,                      true ));
        IsTrue (Has     (OneNullyGuid                       ));
        IsTrue (Has     (OneNullyGuid,    zeroMatters: false));
        IsTrue (Has     (OneNullyGuid,                 false));
        IsTrue (Has     (OneNullyGuid,    zeroMatters       ));
        IsTrue (Has     (OneNullyGuid,    zeroMatters: true ));
        IsTrue (Has     (OneNullyGuid,                 true ));
        IsTrue (Has     (RandomGuid                         ));
        IsTrue (Has     (RandomGuid,      zeroMatters: false));
        IsTrue (Has     (RandomGuid,                   false));
        IsTrue (Has     (RandomGuid,      zeroMatters       ));
        IsTrue (Has     (RandomGuid,      zeroMatters: true ));
        IsTrue (Has     (RandomGuid,                   true ));
        IsTrue (Has     (RandomNullyGuid                    ));
        IsTrue (Has     (RandomNullyGuid, zeroMatters: false));
        IsTrue (Has     (RandomNullyGuid,              false));
        IsTrue (Has     (RandomNullyGuid, zeroMatters       ));
        IsTrue (Has     (RandomNullyGuid, zeroMatters: true ));
        IsTrue (Has     (RandomNullyGuid,              true ));
    }

    [TestMethod]
    public void Test_Guid_FilledIn_ZeroMatters()
    {
        IsFalse(FilledIn(NullGuid                           ));
        IsFalse(FilledIn(NullGuid,        zeroMatters: false));
        IsFalse(FilledIn(NullGuid,                     false));
        IsFalse(FilledIn(NullGuid,        zeroMatters       ));
        IsFalse(FilledIn(NullGuid,        zeroMatters: true ));
        IsFalse(FilledIn(NullGuid,                     true ));
        IsFalse(FilledIn(EmptyGuid                          ));
        IsFalse(FilledIn(EmptyGuid,       zeroMatters: false));
        IsFalse(FilledIn(EmptyGuid,                    false));
        IsTrue (FilledIn(EmptyGuid,       zeroMatters       ));
        IsTrue (FilledIn(EmptyGuid,       zeroMatters: true ));
        IsTrue (FilledIn(EmptyGuid,                    true ));
        IsFalse(FilledIn(EmptyNullyGuid                     ));
        IsFalse(FilledIn(EmptyNullyGuid,  zeroMatters: false));
        IsFalse(FilledIn(EmptyNullyGuid,               false));
        IsTrue (FilledIn(EmptyNullyGuid,  zeroMatters       ));
        IsTrue (FilledIn(EmptyNullyGuid,  zeroMatters: true ));
        IsTrue (FilledIn(EmptyNullyGuid,               true ));
        IsFalse(FilledIn(ZeroGuid                           ));
        IsFalse(FilledIn(ZeroGuid,        zeroMatters: false));
        IsFalse(FilledIn(ZeroGuid,                     false));
        IsTrue (FilledIn(ZeroGuid,        zeroMatters       ));
        IsTrue (FilledIn(ZeroGuid,        zeroMatters: true ));
        IsTrue (FilledIn(ZeroGuid,                     true ));
        IsFalse(FilledIn(ZeroNullyGuid                      ));
        IsFalse(FilledIn(ZeroNullyGuid,   zeroMatters: false));
        IsFalse(FilledIn(ZeroNullyGuid,                false));
        IsTrue (FilledIn(ZeroNullyGuid,   zeroMatters       ));
        IsTrue (FilledIn(ZeroNullyGuid,   zeroMatters: true ));
        IsTrue (FilledIn(ZeroNullyGuid,                true ));
        IsTrue (FilledIn(OneGuid                            ));
        IsTrue (FilledIn(OneGuid,         zeroMatters: false));
        IsTrue (FilledIn(OneGuid,                      false));
        IsTrue (FilledIn(OneGuid,         zeroMatters       ));
        IsTrue (FilledIn(OneGuid,         zeroMatters: true ));
        IsTrue (FilledIn(OneGuid,                      true ));
        IsTrue (FilledIn(OneNullyGuid                       ));
        IsTrue (FilledIn(OneNullyGuid,    zeroMatters: false));
        IsTrue (FilledIn(OneNullyGuid,                 false));
        IsTrue (FilledIn(OneNullyGuid,    zeroMatters       ));
        IsTrue (FilledIn(OneNullyGuid,    zeroMatters: true ));
        IsTrue (FilledIn(OneNullyGuid,                 true ));
        IsTrue (FilledIn(RandomGuid                         ));
        IsTrue (FilledIn(RandomGuid,      zeroMatters: false));
        IsTrue (FilledIn(RandomGuid,                   false));
        IsTrue (FilledIn(RandomGuid,      zeroMatters       ));
        IsTrue (FilledIn(RandomGuid,      zeroMatters: true ));
        IsTrue (FilledIn(RandomGuid,                   true ));
        IsTrue (FilledIn(RandomNullyGuid                    ));
        IsTrue (FilledIn(RandomNullyGuid, zeroMatters: false));
        IsTrue (FilledIn(RandomNullyGuid,              false));
        IsTrue (FilledIn(RandomNullyGuid, zeroMatters       ));
        IsTrue (FilledIn(RandomNullyGuid, zeroMatters: true ));
        IsTrue (FilledIn(RandomNullyGuid,              true ));
        IsFalse(NullGuid       .FilledIn(                   ));
        IsFalse(NullGuid       .FilledIn( zeroMatters: false));
        IsFalse(NullGuid       .FilledIn(              false));
        IsFalse(NullGuid       .FilledIn( zeroMatters       ));
        IsFalse(NullGuid       .FilledIn( zeroMatters: true ));
        IsFalse(NullGuid       .FilledIn(              true ));
        IsFalse(EmptyGuid      .FilledIn(                   ));
        IsFalse(EmptyGuid      .FilledIn( zeroMatters: false));
        IsFalse(EmptyGuid      .FilledIn(              false));
        IsTrue (EmptyGuid      .FilledIn( zeroMatters       ));
        IsTrue (EmptyGuid      .FilledIn( zeroMatters: true ));
        IsTrue (EmptyGuid      .FilledIn(              true ));
        IsFalse(EmptyNullyGuid .FilledIn(                   ));
        IsFalse(EmptyNullyGuid .FilledIn( zeroMatters: false));
        IsFalse(EmptyNullyGuid .FilledIn(              false));
        IsTrue (EmptyNullyGuid .FilledIn( zeroMatters       ));
        IsTrue (EmptyNullyGuid .FilledIn( zeroMatters: true ));
        IsTrue (EmptyNullyGuid .FilledIn(              true ));
        IsFalse(ZeroGuid       .FilledIn(                   ));
        IsFalse(ZeroGuid       .FilledIn( zeroMatters: false));
        IsFalse(ZeroGuid       .FilledIn(              false));
        IsTrue (ZeroGuid       .FilledIn( zeroMatters       ));
        IsTrue (ZeroGuid       .FilledIn( zeroMatters: true ));
        IsTrue (ZeroGuid       .FilledIn(              true ));
        IsFalse(ZeroNullyGuid  .FilledIn(                   ));
        IsFalse(ZeroNullyGuid  .FilledIn( zeroMatters: false));
        IsFalse(ZeroNullyGuid  .FilledIn(              false));
        IsTrue (ZeroNullyGuid  .FilledIn( zeroMatters       ));
        IsTrue (ZeroNullyGuid  .FilledIn( zeroMatters: true ));
        IsTrue (ZeroNullyGuid  .FilledIn(              true ));
        IsTrue (OneGuid        .FilledIn(                   ));
        IsTrue (OneGuid        .FilledIn( zeroMatters: false));
        IsTrue (OneGuid        .FilledIn(              false));
        IsTrue (OneGuid        .FilledIn( zeroMatters       ));
        IsTrue (OneGuid        .FilledIn( zeroMatters: true ));
        IsTrue (OneGuid        .FilledIn(              true ));
        IsTrue (OneNullyGuid   .FilledIn(                   ));
        IsTrue (OneNullyGuid   .FilledIn( zeroMatters: false));
        IsTrue (OneNullyGuid   .FilledIn(              false));
        IsTrue (OneNullyGuid   .FilledIn( zeroMatters       ));
        IsTrue (OneNullyGuid   .FilledIn( zeroMatters: true ));
        IsTrue (OneNullyGuid   .FilledIn(              true ));
        IsTrue (RandomGuid     .FilledIn(                   ));
        IsTrue (RandomGuid     .FilledIn( zeroMatters: false));
        IsTrue (RandomGuid     .FilledIn(              false));
        IsTrue (RandomGuid     .FilledIn( zeroMatters       ));
        IsTrue (RandomGuid     .FilledIn( zeroMatters: true ));
        IsTrue (RandomGuid     .FilledIn(              true ));
        IsTrue (RandomNullyGuid.FilledIn(                   ));
        IsTrue (RandomNullyGuid.FilledIn( zeroMatters: false));
        IsTrue (RandomNullyGuid.FilledIn(              false));
        IsTrue (RandomNullyGuid.FilledIn( zeroMatters       ));
        IsTrue (RandomNullyGuid.FilledIn( zeroMatters: true ));
        IsTrue (RandomNullyGuid.FilledIn(              true ));
    }

    [TestMethod]
    public void Test_Guid_IsNully_ZeroMatters()
    {
        IsTrue (IsNully( NullGuid                           ));
        IsTrue (IsNully( NullGuid,        zeroMatters: false));
        IsTrue (IsNully( NullGuid,                     false));
        IsTrue (IsNully( NullGuid,        zeroMatters       ));
        IsTrue (IsNully( NullGuid,        zeroMatters: true ));
        IsTrue (IsNully( NullGuid,                     true ));
        IsTrue (IsNully( EmptyGuid                          ));
        IsTrue (IsNully( EmptyGuid,       zeroMatters: false));
        IsTrue (IsNully( EmptyGuid,                    false));
        IsFalse(IsNully( EmptyGuid,       zeroMatters       ));
        IsFalse(IsNully( EmptyGuid,       zeroMatters: true ));
        IsFalse(IsNully( EmptyGuid,                    true ));
        IsTrue (IsNully( EmptyNullyGuid                     ));
        IsTrue (IsNully( EmptyNullyGuid,  zeroMatters: false));
        IsTrue (IsNully( EmptyNullyGuid,               false));
        IsFalse(IsNully( EmptyNullyGuid,  zeroMatters       ));
        IsFalse(IsNully( EmptyNullyGuid,  zeroMatters: true ));
        IsFalse(IsNully( EmptyNullyGuid,               true ));
        IsTrue (IsNully( ZeroGuid                           ));
        IsTrue (IsNully( ZeroGuid,        zeroMatters: false));
        IsTrue (IsNully( ZeroGuid,                     false));
        IsFalse(IsNully( ZeroGuid,        zeroMatters       ));
        IsFalse(IsNully( ZeroGuid,        zeroMatters: true ));
        IsFalse(IsNully( ZeroGuid,                     true ));
        IsTrue (IsNully( ZeroNullyGuid                      ));
        IsTrue (IsNully( ZeroNullyGuid,   zeroMatters: false));
        IsTrue (IsNully( ZeroNullyGuid,                false));
        IsFalse(IsNully( ZeroNullyGuid,   zeroMatters       ));
        IsFalse(IsNully( ZeroNullyGuid,   zeroMatters: true ));
        IsFalse(IsNully( ZeroNullyGuid,                true ));
        IsFalse(IsNully( OneGuid                            ));
        IsFalse(IsNully( OneGuid,         zeroMatters: false));
        IsFalse(IsNully( OneGuid,                      false));
        IsFalse(IsNully( OneGuid,         zeroMatters       ));
        IsFalse(IsNully( OneGuid,         zeroMatters: true ));
        IsFalse(IsNully( OneGuid,                      true ));
        IsFalse(IsNully( OneNullyGuid                       ));
        IsFalse(IsNully( OneNullyGuid,    zeroMatters: false));
        IsFalse(IsNully( OneNullyGuid,                 false));
        IsFalse(IsNully( OneNullyGuid,    zeroMatters       ));
        IsFalse(IsNully( OneNullyGuid,    zeroMatters: true ));
        IsFalse(IsNully( OneNullyGuid,                 true ));
        IsFalse(IsNully( RandomGuid                         ));
        IsFalse(IsNully( RandomGuid,      zeroMatters: false));
        IsFalse(IsNully( RandomGuid,                   false));
        IsFalse(IsNully( RandomGuid,      zeroMatters       ));
        IsFalse(IsNully( RandomGuid,      zeroMatters: true ));
        IsFalse(IsNully( RandomGuid,                   true ));
        IsFalse(IsNully( RandomNullyGuid                    ));
        IsFalse(IsNully( RandomNullyGuid, zeroMatters: false));
        IsFalse(IsNully( RandomNullyGuid,              false));
        IsFalse(IsNully( RandomNullyGuid, zeroMatters       ));
        IsFalse(IsNully( RandomNullyGuid, zeroMatters: true ));
        IsFalse(IsNully( RandomNullyGuid,              true ));
        IsTrue (NullGuid       .IsNully(                    ));
        IsTrue (NullGuid       .IsNully(  zeroMatters: false));
        IsTrue (NullGuid       .IsNully(               false));
        IsTrue (NullGuid       .IsNully(  zeroMatters       ));
        IsTrue (NullGuid       .IsNully(  zeroMatters: true ));
        IsTrue (NullGuid       .IsNully(               true ));
        IsTrue (EmptyGuid      .IsNully(                    ));
        IsTrue (EmptyGuid      .IsNully(  zeroMatters: false));
        IsTrue (EmptyGuid      .IsNully(               false));
        IsFalse(EmptyGuid      .IsNully(  zeroMatters       ));
        IsFalse(EmptyGuid      .IsNully(  zeroMatters: true ));
        IsFalse(EmptyGuid      .IsNully(               true ));
        IsTrue (EmptyNullyGuid .IsNully(                    ));
        IsTrue (EmptyNullyGuid .IsNully(  zeroMatters: false));
        IsTrue (EmptyNullyGuid .IsNully(               false));
        IsFalse(EmptyNullyGuid .IsNully(  zeroMatters       ));
        IsFalse(EmptyNullyGuid .IsNully(  zeroMatters: true ));
        IsFalse(EmptyNullyGuid .IsNully(               true ));
        IsTrue (ZeroGuid       .IsNully(                    ));
        IsTrue (ZeroGuid       .IsNully(  zeroMatters: false));
        IsTrue (ZeroGuid       .IsNully(               false));
        IsFalse(ZeroGuid       .IsNully(  zeroMatters       ));
        IsFalse(ZeroGuid       .IsNully(  zeroMatters: true ));
        IsFalse(ZeroGuid       .IsNully(               true ));
        IsTrue (ZeroNullyGuid  .IsNully(                    ));
        IsTrue (ZeroNullyGuid  .IsNully(  zeroMatters: false));
        IsTrue (ZeroNullyGuid  .IsNully(               false));
        IsFalse(ZeroNullyGuid  .IsNully(  zeroMatters       ));
        IsFalse(ZeroNullyGuid  .IsNully(  zeroMatters: true ));
        IsFalse(ZeroNullyGuid  .IsNully(               true ));
        IsFalse(OneGuid        .IsNully(                    ));
        IsFalse(OneGuid        .IsNully(  zeroMatters: false));
        IsFalse(OneGuid        .IsNully(               false));
        IsFalse(OneGuid        .IsNully(  zeroMatters       ));
        IsFalse(OneGuid        .IsNully(  zeroMatters: true ));
        IsFalse(OneGuid        .IsNully(               true ));
        IsFalse(OneNullyGuid   .IsNully(                    ));
        IsFalse(OneNullyGuid   .IsNully(  zeroMatters: false));
        IsFalse(OneNullyGuid   .IsNully(               false));
        IsFalse(OneNullyGuid   .IsNully(  zeroMatters       ));
        IsFalse(OneNullyGuid   .IsNully(  zeroMatters: true ));
        IsFalse(OneNullyGuid   .IsNully(               true ));
        IsFalse(RandomGuid     .IsNully(                    ));
        IsFalse(RandomGuid     .IsNully(  zeroMatters: false));
        IsFalse(RandomGuid     .IsNully(               false));
        IsFalse(RandomGuid     .IsNully(  zeroMatters       ));
        IsFalse(RandomGuid     .IsNully(  zeroMatters: true ));
        IsFalse(RandomGuid     .IsNully(               true ));
        IsFalse(RandomNullyGuid.IsNully(                    ));
        IsFalse(RandomNullyGuid.IsNully(  zeroMatters: false));
        IsFalse(RandomNullyGuid.IsNully(               false));
        IsFalse(RandomNullyGuid.IsNully(  zeroMatters       ));
        IsFalse(RandomNullyGuid.IsNully(  zeroMatters: true ));
        IsFalse(RandomNullyGuid.IsNully(               true ));
    }

    [TestMethod]
    public void Tests_Guid_Coalesce_ZeroMatters()
    {
        NoNullRet(OneGuid,  Coalesce(NullGuid, EmptyGuid                    ).Coalesce(                    ZeroGuid, OneGuid, RandomGuid));
        NoNullRet(OneGuid,  Coalesce(NullGuid, EmptyGuid, zeroMatters: false).Coalesce(zeroMatters: false, ZeroGuid, OneGuid, RandomGuid));
        NoNullRet(OneGuid,  Coalesce(NullGuid, EmptyGuid,              false).Coalesce(             false, ZeroGuid, OneGuid, RandomGuid));
        NoNullRet(ZeroGuid, Coalesce(NullGuid, EmptyGuid, zeroMatters       ).Coalesce(zeroMatters,        ZeroGuid, OneGuid, RandomGuid));
        NoNullRet(ZeroGuid, Coalesce(NullGuid, EmptyGuid, zeroMatters: true ).Coalesce(zeroMatters: true,  ZeroGuid, OneGuid, RandomGuid));
        NoNullRet(ZeroGuid, Coalesce(NullGuid, EmptyGuid,              true ).Coalesce(             true,  ZeroGuid, OneGuid, RandomGuid));
        // TODO: More variants?
    }
}