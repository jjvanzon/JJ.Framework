using static System.DateTime;

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_DateTime_Tests
{
    // DateTime

    readonly DateTime? NullDateTime         = null;
    readonly DateTime  DefaultDateTime      = default;
    readonly DateTime? DefaultNullyDateTime = default;
    readonly DateTime  NewDateTime          = new();
    readonly DateTime? NewNullyDateTime     = new();
    readonly DateTime  MinDateTime          = MinValue;
    readonly DateTime? MinNullyDateTime     = MinValue; 
    readonly DateTime  MaxDateTime          = MaxValue;
    readonly DateTime? MaxNullyDateTime     = MaxValue;
    readonly DateTime  NowDateTime          = Now;
    readonly DateTime? NowNullyDateTime     = Now;
    readonly DateTime  SomeDateTime         = new(2023, 10, 1, 12, 10, 23);
    readonly DateTime? SomeNullyDateTime    = new(2023, 10, 1, 12, 10, 23);
                                   
    [TestMethod]
    public void Test_DateTime_Has()
    {
        IsFalse(Has     (NullDateTime         ));
        IsFalse(Has     (DefaultDateTime      ));
        IsFalse(Has     (DefaultNullyDateTime ));
        IsFalse(Has     (NewDateTime          ));
        IsFalse(Has     (NewNullyDateTime     ));
        IsFalse(Has     (MinDateTime          ));
        IsFalse(Has     (MinNullyDateTime     ));
        IsTrue (Has     (MaxDateTime          ));
        IsTrue (Has     (MaxNullyDateTime     ));
        IsTrue (Has     (NowDateTime          ));
        IsTrue (Has     (NowNullyDateTime     ));
        IsTrue (Has     (SomeDateTime         ));
        IsTrue (Has     (SomeNullyDateTime    ));
    }
    
    [TestMethod]
    public void Test_DateTime_Has_ZeroMatters()
    {
        IsFalse(Has     (NullDateTime                            ));
        IsFalse(Has     (NullDateTime,         zeroMatters: false));
        IsFalse(Has     (NullDateTime,                      false));
        IsFalse(Has     (NullDateTime,         zeroMatters       ));
        IsFalse(Has     (NullDateTime,         zeroMatters: true ));
        IsFalse(Has     (NullDateTime,                      true ));
        IsFalse(Has     (DefaultDateTime                         ));
        IsFalse(Has     (DefaultDateTime,      zeroMatters: false));
        IsFalse(Has     (DefaultDateTime,                   false));
        IsTrue (Has     (DefaultDateTime,      zeroMatters       ));
        IsTrue (Has     (DefaultDateTime,      zeroMatters: true ));
        IsTrue (Has     (DefaultDateTime,                   true ));
        IsFalse(Has     (DefaultNullyDateTime                    ));
        IsFalse(Has     (DefaultNullyDateTime, zeroMatters: false));
        IsFalse(Has     (DefaultNullyDateTime,              false));
        IsFalse(Has     (DefaultNullyDateTime, zeroMatters       ));
        IsFalse(Has     (DefaultNullyDateTime, zeroMatters: true ));
        IsFalse(Has     (DefaultNullyDateTime,              true ));
        IsFalse(Has     (NewDateTime                             ));
        IsFalse(Has     (NewDateTime,          zeroMatters: false));
        IsFalse(Has     (NewDateTime,                       false));
        IsTrue (Has     (NewDateTime,          zeroMatters       ));
        IsTrue (Has     (NewDateTime,          zeroMatters: true ));
        IsTrue (Has     (NewDateTime,                       true ));
        IsFalse(Has     (NewNullyDateTime                        ));
        IsFalse(Has     (NewNullyDateTime,     zeroMatters: false));
        IsFalse(Has     (NewNullyDateTime,                  false));
        IsTrue (Has     (NewNullyDateTime,     zeroMatters       ));
        IsTrue (Has     (NewNullyDateTime,     zeroMatters: true ));
        IsTrue (Has     (NewNullyDateTime,                  true ));
        IsFalse(Has     (MinDateTime                             ));
        IsFalse(Has     (MinDateTime,          zeroMatters: false));
        IsFalse(Has     (MinDateTime,                       false));
        IsTrue (Has     (MinDateTime,          zeroMatters       ));
        IsTrue (Has     (MinDateTime,          zeroMatters: true ));
        IsTrue (Has     (MinDateTime,                       true ));
        IsFalse(Has     (MinNullyDateTime                        ));
        IsFalse(Has     (MinNullyDateTime,     zeroMatters: false));
        IsFalse(Has     (MinNullyDateTime,                  false));
        IsTrue (Has     (MinNullyDateTime,     zeroMatters       ));
        IsTrue (Has     (MinNullyDateTime,     zeroMatters: true ));
        IsTrue (Has     (MinNullyDateTime,                  true ));
        IsTrue (Has     (MaxDateTime                             ));
        IsTrue (Has     (MaxDateTime,          zeroMatters: false));
        IsTrue (Has     (MaxDateTime,                       false));
        IsTrue (Has     (MaxDateTime,          zeroMatters       ));
        IsTrue (Has     (MaxDateTime,          zeroMatters: true ));
        IsTrue (Has     (MaxDateTime,                       true ));
        IsTrue (Has     (MaxNullyDateTime                        ));
        IsTrue (Has     (MaxNullyDateTime,     zeroMatters: false));
        IsTrue (Has     (MaxNullyDateTime,                  false));
        IsTrue (Has     (MaxNullyDateTime,     zeroMatters       ));
        IsTrue (Has     (MaxNullyDateTime,     zeroMatters: true ));
        IsTrue (Has     (MaxNullyDateTime,                  true ));
        IsTrue (Has     (NowDateTime                             ));
        IsTrue (Has     (NowDateTime,          zeroMatters: false));
        IsTrue (Has     (NowDateTime,                       false));
        IsTrue (Has     (NowDateTime,          zeroMatters       ));
        IsTrue (Has     (NowDateTime,          zeroMatters: true ));
        IsTrue (Has     (NowDateTime,                       true ));
        IsTrue (Has     (NowNullyDateTime                        ));
        IsTrue (Has     (NowNullyDateTime,     zeroMatters: false));
        IsTrue (Has     (NowNullyDateTime,                  false));
        IsTrue (Has     (NowNullyDateTime,     zeroMatters       ));
        IsTrue (Has     (NowNullyDateTime,     zeroMatters: true ));
        IsTrue (Has     (NowNullyDateTime,                  true ));
        IsTrue (Has     (SomeDateTime                            ));
        IsTrue (Has     (SomeDateTime,         zeroMatters: false));
        IsTrue (Has     (SomeDateTime,                      false));
        IsTrue (Has     (SomeDateTime,         zeroMatters       ));
        IsTrue (Has     (SomeDateTime,         zeroMatters: true ));
        IsTrue (Has     (SomeDateTime,                      true ));
        IsTrue (Has     (SomeNullyDateTime                       ));
        IsTrue (Has     (SomeNullyDateTime,    zeroMatters: false));
        IsTrue (Has     (SomeNullyDateTime,                 false));
        IsTrue (Has     (SomeNullyDateTime,    zeroMatters       ));
        IsTrue (Has     (SomeNullyDateTime,    zeroMatters: true ));
        IsTrue (Has     (SomeNullyDateTime,                 true ));
    }

    [TestMethod]
    public void Test_DateTime_FilledIn_Static()
    {
        IsFalse(FilledIn(NullDateTime         ));
        IsFalse(FilledIn(DefaultDateTime      ));
        IsFalse(FilledIn(DefaultNullyDateTime ));
        IsFalse(FilledIn(NewDateTime          ));
        IsFalse(FilledIn(NewNullyDateTime     ));
        IsFalse(FilledIn(MinDateTime          ));
        IsFalse(FilledIn(MinNullyDateTime     ));
        IsTrue (FilledIn(MaxDateTime          ));
        IsTrue (FilledIn(MaxNullyDateTime     ));
        IsTrue (FilledIn(NowDateTime          ));
        IsTrue (FilledIn(NowNullyDateTime     ));
        IsTrue (FilledIn(SomeDateTime         ));
        IsTrue (FilledIn(SomeNullyDateTime    ));
    }

    [TestMethod]
    public void Test_DateTime_FilledIn_Extensions()
    {
        IsFalse(NullDateTime        .FilledIn());
        IsFalse(DefaultDateTime     .FilledIn());
        IsFalse(DefaultNullyDateTime.FilledIn());
        IsFalse(NewDateTime         .FilledIn());
        IsFalse(NewNullyDateTime    .FilledIn());
        IsFalse(MinDateTime         .FilledIn());
        IsFalse(MinNullyDateTime    .FilledIn());
        IsTrue (MaxDateTime         .FilledIn());
        IsTrue (MaxNullyDateTime    .FilledIn());
        IsTrue (NowDateTime         .FilledIn());
        IsTrue (NowNullyDateTime    .FilledIn());
        IsTrue (SomeDateTime        .FilledIn());
        IsTrue (SomeNullyDateTime   .FilledIn());
    }
    
    [TestMethod]
    public void Test_DateTime_FilledIn_StaticZeroMatters()
    {
        IsFalse(FilledIn(NullDateTime                            ));
        IsFalse(FilledIn(NullDateTime,         zeroMatters: false));
        IsFalse(FilledIn(NullDateTime,                      false));
        IsFalse(FilledIn(NullDateTime,         zeroMatters       ));
        IsFalse(FilledIn(NullDateTime,         zeroMatters: true ));
        IsFalse(FilledIn(NullDateTime,                      true ));
        IsFalse(FilledIn(DefaultDateTime                         ));
        IsFalse(FilledIn(DefaultDateTime,      zeroMatters: false));
        IsFalse(FilledIn(DefaultDateTime,                   false));
        IsTrue (FilledIn(DefaultDateTime,      zeroMatters       ));
        IsTrue (FilledIn(DefaultDateTime,      zeroMatters: true ));
        IsTrue (FilledIn(DefaultDateTime,                   true ));
        IsFalse(FilledIn(DefaultNullyDateTime                    ));
        IsFalse(FilledIn(DefaultNullyDateTime, zeroMatters: false));
        IsFalse(FilledIn(DefaultNullyDateTime,              false));
        IsFalse(FilledIn(DefaultNullyDateTime, zeroMatters       ));
        IsFalse(FilledIn(DefaultNullyDateTime, zeroMatters: true ));
        IsFalse(FilledIn(DefaultNullyDateTime,              true ));
        IsFalse(FilledIn(NewDateTime                             ));
        IsFalse(FilledIn(NewDateTime,          zeroMatters: false));
        IsFalse(FilledIn(NewDateTime,                       false));
        IsTrue (FilledIn(NewDateTime,          zeroMatters       ));
        IsTrue (FilledIn(NewDateTime,          zeroMatters: true ));
        IsTrue (FilledIn(NewDateTime,                       true ));
        IsFalse(FilledIn(NewNullyDateTime                        ));
        IsFalse(FilledIn(NewNullyDateTime,     zeroMatters: false));
        IsFalse(FilledIn(NewNullyDateTime,                  false));
        IsTrue (FilledIn(NewNullyDateTime,     zeroMatters       ));
        IsTrue (FilledIn(NewNullyDateTime,     zeroMatters: true ));
        IsTrue (FilledIn(NewNullyDateTime,                  true ));
        IsFalse(FilledIn(MinDateTime                             ));
        IsFalse(FilledIn(MinDateTime,          zeroMatters: false));
        IsFalse(FilledIn(MinDateTime,                       false));
        IsTrue (FilledIn(MinDateTime,          zeroMatters       ));
        IsTrue (FilledIn(MinDateTime,          zeroMatters: true ));
        IsTrue (FilledIn(MinDateTime,                       true ));
        IsFalse(FilledIn(MinNullyDateTime                        ));
        IsFalse(FilledIn(MinNullyDateTime,     zeroMatters: false));
        IsFalse(FilledIn(MinNullyDateTime,                  false));
        IsTrue (FilledIn(MinNullyDateTime,     zeroMatters       ));
        IsTrue (FilledIn(MinNullyDateTime,     zeroMatters: true ));
        IsTrue (FilledIn(MinNullyDateTime,                  true ));
        IsTrue (FilledIn(MaxDateTime                             ));
        IsTrue (FilledIn(MaxDateTime,          zeroMatters: false));
        IsTrue (FilledIn(MaxDateTime,                       false));
        IsTrue (FilledIn(MaxDateTime,          zeroMatters       ));
        IsTrue (FilledIn(MaxDateTime,          zeroMatters: true ));
        IsTrue (FilledIn(MaxDateTime,                       true ));
        IsTrue (FilledIn(MaxNullyDateTime                        ));
        IsTrue (FilledIn(MaxNullyDateTime,     zeroMatters: false));
        IsTrue (FilledIn(MaxNullyDateTime,                  false));
        IsTrue (FilledIn(MaxNullyDateTime,     zeroMatters       ));
        IsTrue (FilledIn(MaxNullyDateTime,     zeroMatters: true ));
        IsTrue (FilledIn(MaxNullyDateTime,                  true ));
        IsTrue (FilledIn(NowDateTime                             ));
        IsTrue (FilledIn(NowDateTime,          zeroMatters: false));
        IsTrue (FilledIn(NowDateTime,                       false));
        IsTrue (FilledIn(NowDateTime,          zeroMatters       ));
        IsTrue (FilledIn(NowDateTime,          zeroMatters: true ));
        IsTrue (FilledIn(NowDateTime,                       true ));
        IsTrue (FilledIn(NowNullyDateTime                        ));
        IsTrue (FilledIn(NowNullyDateTime,     zeroMatters: false));
        IsTrue (FilledIn(NowNullyDateTime,                  false));
        IsTrue (FilledIn(NowNullyDateTime,     zeroMatters       ));
        IsTrue (FilledIn(NowNullyDateTime,     zeroMatters: true ));
        IsTrue (FilledIn(NowNullyDateTime,                  true ));
        IsTrue (FilledIn(SomeDateTime                            ));
        IsTrue (FilledIn(SomeDateTime,         zeroMatters: false));
        IsTrue (FilledIn(SomeDateTime,                      false));
        IsTrue (FilledIn(SomeDateTime,         zeroMatters       ));
        IsTrue (FilledIn(SomeDateTime,         zeroMatters: true ));
        IsTrue (FilledIn(SomeDateTime,                      true ));
        IsTrue (FilledIn(SomeNullyDateTime                       ));
        IsTrue (FilledIn(SomeNullyDateTime,    zeroMatters: false));
        IsTrue (FilledIn(SomeNullyDateTime,                 false));
        IsTrue (FilledIn(SomeNullyDateTime,    zeroMatters       ));
        IsTrue (FilledIn(SomeNullyDateTime,    zeroMatters: true ));
        IsTrue (FilledIn(SomeNullyDateTime,                 true ));
    }
    
    [TestMethod]
    public void Test_DateTime_FilledIn_ExtensionsZeroMatters()
    {
        IsFalse(NullDateTime         .FilledIn(                  ));
        IsFalse(NullDateTime         .FilledIn(zeroMatters: false));
        IsFalse(NullDateTime         .FilledIn(             false));
        IsFalse(NullDateTime         .FilledIn(zeroMatters       ));
        IsFalse(NullDateTime         .FilledIn(zeroMatters: true ));
        IsFalse(NullDateTime         .FilledIn(             true ));
        IsFalse(DefaultDateTime      .FilledIn(                  ));
        IsFalse(DefaultDateTime      .FilledIn(zeroMatters: false));
        IsFalse(DefaultDateTime      .FilledIn(             false));
        IsTrue (DefaultDateTime      .FilledIn(zeroMatters       ));
        IsTrue (DefaultDateTime      .FilledIn(zeroMatters: true ));
        IsTrue (DefaultDateTime      .FilledIn(             true ));
        IsFalse(DefaultNullyDateTime .FilledIn(                  ));
        IsFalse(DefaultNullyDateTime .FilledIn(zeroMatters: false));
        IsFalse(DefaultNullyDateTime .FilledIn(             false));
        IsFalse(DefaultNullyDateTime .FilledIn(zeroMatters       ));
        IsFalse(DefaultNullyDateTime .FilledIn(zeroMatters: true ));
        IsFalse(DefaultNullyDateTime .FilledIn(             true ));
        IsFalse(NewDateTime          .FilledIn(                  ));
        IsFalse(NewDateTime          .FilledIn(zeroMatters: false));
        IsFalse(NewDateTime          .FilledIn(             false));
        IsTrue (NewDateTime          .FilledIn(zeroMatters       ));
        IsTrue (NewDateTime          .FilledIn(zeroMatters: true ));
        IsTrue (NewDateTime          .FilledIn(             true ));
        IsFalse(NewNullyDateTime     .FilledIn(                  ));
        IsFalse(NewNullyDateTime     .FilledIn(zeroMatters: false));
        IsFalse(NewNullyDateTime     .FilledIn(             false));
        IsTrue (NewNullyDateTime     .FilledIn(zeroMatters       ));
        IsTrue (NewNullyDateTime     .FilledIn(zeroMatters: true ));
        IsTrue (NewNullyDateTime     .FilledIn(             true ));
        IsFalse(MinDateTime          .FilledIn(                  ));
        IsFalse(MinDateTime          .FilledIn(zeroMatters: false));
        IsFalse(MinDateTime          .FilledIn(             false));
        IsTrue (MinDateTime          .FilledIn(zeroMatters       ));
        IsTrue (MinDateTime          .FilledIn(zeroMatters: true ));
        IsTrue (MinDateTime          .FilledIn(             true ));
        IsFalse(MinNullyDateTime     .FilledIn(                  ));
        IsFalse(MinNullyDateTime     .FilledIn(zeroMatters: false));
        IsFalse(MinNullyDateTime     .FilledIn(             false));
        IsTrue (MinNullyDateTime     .FilledIn(zeroMatters       ));
        IsTrue (MinNullyDateTime     .FilledIn(zeroMatters: true ));
        IsTrue (MinNullyDateTime     .FilledIn(             true ));
        IsTrue (MaxDateTime          .FilledIn(                  ));
        IsTrue (MaxDateTime          .FilledIn(zeroMatters: false));
        IsTrue (MaxDateTime          .FilledIn(             false));
        IsTrue (MaxDateTime          .FilledIn(zeroMatters       ));
        IsTrue (MaxDateTime          .FilledIn(zeroMatters: true ));
        IsTrue (MaxDateTime          .FilledIn(             true ));
        IsTrue (MaxNullyDateTime     .FilledIn(                  ));
        IsTrue (MaxNullyDateTime     .FilledIn(zeroMatters: false));
        IsTrue (MaxNullyDateTime     .FilledIn(             false));
        IsTrue (MaxNullyDateTime     .FilledIn(zeroMatters       ));
        IsTrue (MaxNullyDateTime     .FilledIn(zeroMatters: true ));
        IsTrue (MaxNullyDateTime     .FilledIn(             true ));
        IsTrue (NowDateTime          .FilledIn(                  ));
        IsTrue (NowDateTime          .FilledIn(zeroMatters: false));
        IsTrue (NowDateTime          .FilledIn(             false));
        IsTrue (NowDateTime          .FilledIn(zeroMatters       ));
        IsTrue (NowDateTime          .FilledIn(zeroMatters: true ));
        IsTrue (NowDateTime          .FilledIn(             true ));
        IsTrue (NowNullyDateTime     .FilledIn(                  ));
        IsTrue (NowNullyDateTime     .FilledIn(zeroMatters: false));
        IsTrue (NowNullyDateTime     .FilledIn(             false));
        IsTrue (NowNullyDateTime     .FilledIn(zeroMatters       ));
        IsTrue (NowNullyDateTime     .FilledIn(zeroMatters: true ));
        IsTrue (NowNullyDateTime     .FilledIn(             true ));
        IsTrue (SomeDateTime         .FilledIn(                  ));
        IsTrue (SomeDateTime         .FilledIn(zeroMatters: false));
        IsTrue (SomeDateTime         .FilledIn(             false));
        IsTrue (SomeDateTime         .FilledIn(zeroMatters       ));
        IsTrue (SomeDateTime         .FilledIn(zeroMatters: true ));
        IsTrue (SomeDateTime         .FilledIn(             true ));
        IsTrue (SomeNullyDateTime    .FilledIn(                  ));
        IsTrue (SomeNullyDateTime    .FilledIn(zeroMatters: false));
        IsTrue (SomeNullyDateTime    .FilledIn(             false));
        IsTrue (SomeNullyDateTime    .FilledIn(zeroMatters       ));
        IsTrue (SomeNullyDateTime    .FilledIn(zeroMatters: true ));
        IsTrue (SomeNullyDateTime    .FilledIn(             true ));
    }

    [TestMethod]
    public void Test_DateTime_IsNully_Static()
    {
        IsTrue (IsNully( NullDateTime         ));
        IsTrue (IsNully( DefaultDateTime      ));
        IsTrue (IsNully( DefaultNullyDateTime ));
        IsTrue (IsNully( NewDateTime          ));
        IsTrue (IsNully( NewNullyDateTime     ));
        IsTrue (IsNully( MinDateTime          ));
        IsTrue (IsNully( MinNullyDateTime     ));
        IsFalse(IsNully( MaxDateTime          ));
        IsFalse(IsNully( MaxNullyDateTime     ));
        IsFalse(IsNully( NowDateTime          ));
        IsFalse(IsNully( NowNullyDateTime     ));
        IsFalse(IsNully( SomeDateTime         ));
        IsFalse(IsNully( SomeNullyDateTime    ));
    }

    [TestMethod]
    public void Test_DateTime_IsNully_Extensions()
    {
        IsTrue (NullDateTime        .IsNully ());
        IsTrue (DefaultDateTime     .IsNully ());
        IsTrue (DefaultNullyDateTime.IsNully ());
        IsTrue (NewDateTime         .IsNully ());
        IsTrue (NewNullyDateTime    .IsNully ());
        IsTrue (MinDateTime         .IsNully ());
        IsTrue (MinNullyDateTime    .IsNully ());
        IsFalse(MaxDateTime         .IsNully ());
        IsFalse(MaxNullyDateTime    .IsNully ());
        IsFalse(NowDateTime         .IsNully ());
        IsFalse(NowNullyDateTime    .IsNully ());
        IsFalse(SomeDateTime        .IsNully ());
        IsFalse(SomeNullyDateTime   .IsNully ());
    }
    
    [TestMethod]
    public void Test_DateTime_IsNully_StaticZeroMatters()
    {
        IsTrue (IsNully (NullDateTime                            ));
        IsTrue (IsNully (NullDateTime,         zeroMatters: false));
        IsTrue (IsNully (NullDateTime,                      false));
        IsTrue (IsNully (NullDateTime,         zeroMatters       ));
        IsTrue (IsNully (NullDateTime,         zeroMatters: true ));
        IsTrue (IsNully (NullDateTime,                      true ));
        IsTrue (IsNully (DefaultDateTime                         ));
        IsTrue (IsNully (DefaultDateTime,      zeroMatters: false));
        IsTrue (IsNully (DefaultDateTime,                   false));
        IsFalse(IsNully (DefaultDateTime,      zeroMatters       ));
        IsFalse(IsNully (DefaultDateTime,      zeroMatters: true ));
        IsFalse(IsNully (DefaultDateTime,                   true ));
        IsTrue (IsNully (DefaultNullyDateTime                    ));
        IsTrue (IsNully (DefaultNullyDateTime, zeroMatters: false));
        IsTrue (IsNully (DefaultNullyDateTime,              false));
        IsTrue (IsNully (DefaultNullyDateTime, zeroMatters       ));
        IsTrue (IsNully (DefaultNullyDateTime, zeroMatters: true ));
        IsTrue (IsNully (DefaultNullyDateTime,              true ));
        IsTrue (IsNully (NewDateTime                             ));
        IsTrue (IsNully (NewDateTime,          zeroMatters: false));
        IsTrue (IsNully (NewDateTime,                       false));
        IsFalse(IsNully (NewDateTime,          zeroMatters       ));
        IsFalse(IsNully (NewDateTime,          zeroMatters: true ));
        IsFalse(IsNully (NewDateTime,                       true ));
        IsTrue (IsNully (NewNullyDateTime                        ));
        IsTrue (IsNully (NewNullyDateTime,     zeroMatters: false));
        IsTrue (IsNully (NewNullyDateTime,                  false));
        IsFalse(IsNully (NewNullyDateTime,     zeroMatters       ));
        IsFalse(IsNully (NewNullyDateTime,     zeroMatters: true ));
        IsFalse(IsNully (NewNullyDateTime,                  true ));
        IsTrue (IsNully (MinDateTime                             ));
        IsTrue (IsNully (MinDateTime,          zeroMatters: false));
        IsTrue (IsNully (MinDateTime,                       false));
        IsFalse(IsNully (MinDateTime,          zeroMatters       ));
        IsFalse(IsNully (MinDateTime,          zeroMatters: true ));
        IsFalse(IsNully (MinDateTime,                       true ));
        IsTrue (IsNully (MinNullyDateTime                        ));
        IsTrue (IsNully (MinNullyDateTime,     zeroMatters: false));
        IsTrue (IsNully (MinNullyDateTime,                  false));
        IsFalse(IsNully (MinNullyDateTime,     zeroMatters       ));
        IsFalse(IsNully (MinNullyDateTime,     zeroMatters: true ));
        IsFalse(IsNully (MinNullyDateTime,                  true ));
        IsFalse(IsNully (MaxDateTime                             ));
        IsFalse(IsNully (MaxDateTime,          zeroMatters: false));
        IsFalse(IsNully (MaxDateTime,                       false));
        IsFalse(IsNully (MaxDateTime,          zeroMatters       ));
        IsFalse(IsNully (MaxDateTime,          zeroMatters: true ));
        IsFalse(IsNully (MaxDateTime,                       true ));
        IsFalse(IsNully (MaxNullyDateTime                        ));
        IsFalse(IsNully (MaxNullyDateTime,     zeroMatters: false));
        IsFalse(IsNully (MaxNullyDateTime,                  false));
        IsFalse(IsNully (MaxNullyDateTime,     zeroMatters       ));
        IsFalse(IsNully (MaxNullyDateTime,     zeroMatters: true ));
        IsFalse(IsNully (MaxNullyDateTime,                  true ));
        IsFalse(IsNully (NowDateTime                             ));
        IsFalse(IsNully (NowDateTime,          zeroMatters: false));
        IsFalse(IsNully (NowDateTime,                       false));
        IsFalse(IsNully (NowDateTime,          zeroMatters       ));
        IsFalse(IsNully (NowDateTime,          zeroMatters: true ));
        IsFalse(IsNully (NowDateTime,                       true ));
        IsFalse(IsNully (NowNullyDateTime                        ));
        IsFalse(IsNully (NowNullyDateTime,     zeroMatters: false));
        IsFalse(IsNully (NowNullyDateTime,                  false));
        IsFalse(IsNully (NowNullyDateTime,     zeroMatters       ));
        IsFalse(IsNully (NowNullyDateTime,     zeroMatters: true ));
        IsFalse(IsNully (NowNullyDateTime,                  true ));
        IsFalse(IsNully (SomeDateTime                            ));
        IsFalse(IsNully (SomeDateTime,         zeroMatters: false));
        IsFalse(IsNully (SomeDateTime,                      false));
        IsFalse(IsNully (SomeDateTime,         zeroMatters       ));
        IsFalse(IsNully (SomeDateTime,         zeroMatters: true ));
        IsFalse(IsNully (SomeDateTime,                      true ));
        IsFalse(IsNully (SomeNullyDateTime                       ));
        IsFalse(IsNully (SomeNullyDateTime,    zeroMatters: false));
        IsFalse(IsNully (SomeNullyDateTime,                 false));
        IsFalse(IsNully (SomeNullyDateTime,    zeroMatters       ));
        IsFalse(IsNully (SomeNullyDateTime,    zeroMatters: true ));
        IsFalse(IsNully (SomeNullyDateTime,                 true ));
    }
    
    [TestMethod]
    public void Test_DateTime_IsNully_ExtensionsZeroMatters()
    {
        IsTrue (NullDateTime         .IsNully (                  ));
        IsTrue (NullDateTime         .IsNully (zeroMatters: false));
        IsTrue (NullDateTime         .IsNully (             false));
        IsTrue (NullDateTime         .IsNully (zeroMatters       ));
        IsTrue (NullDateTime         .IsNully (zeroMatters: true ));
        IsTrue (NullDateTime         .IsNully (             true ));
        IsTrue (DefaultDateTime      .IsNully (                  ));
        IsTrue (DefaultDateTime      .IsNully (zeroMatters: false));
        IsTrue (DefaultDateTime      .IsNully (             false));
        IsFalse(DefaultDateTime      .IsNully (zeroMatters       ));
        IsFalse(DefaultDateTime      .IsNully (zeroMatters: true ));
        IsFalse(DefaultDateTime      .IsNully (             true ));
        IsTrue (DefaultNullyDateTime .IsNully (                  ));
        IsTrue (DefaultNullyDateTime .IsNully (zeroMatters: false));
        IsTrue (DefaultNullyDateTime .IsNully (             false));
        IsTrue (DefaultNullyDateTime .IsNully (zeroMatters       ));
        IsTrue (DefaultNullyDateTime .IsNully (zeroMatters: true ));
        IsTrue (DefaultNullyDateTime .IsNully (             true ));
        IsTrue (NewDateTime          .IsNully (                  ));
        IsTrue (NewDateTime          .IsNully (zeroMatters: false));
        IsTrue (NewDateTime          .IsNully (             false));
        IsFalse(NewDateTime          .IsNully (zeroMatters       ));
        IsFalse(NewDateTime          .IsNully (zeroMatters: true ));
        IsFalse(NewDateTime          .IsNully (             true ));
        IsTrue (NewNullyDateTime     .IsNully (                  ));
        IsTrue (NewNullyDateTime     .IsNully (zeroMatters: false));
        IsTrue (NewNullyDateTime     .IsNully (             false));
        IsFalse(NewNullyDateTime     .IsNully (zeroMatters       ));
        IsFalse(NewNullyDateTime     .IsNully (zeroMatters: true ));
        IsFalse(NewNullyDateTime     .IsNully (             true ));
        IsTrue (MinDateTime          .IsNully (                  ));
        IsTrue (MinDateTime          .IsNully (zeroMatters: false));
        IsTrue (MinDateTime          .IsNully (             false));
        IsFalse(MinDateTime          .IsNully (zeroMatters       ));
        IsFalse(MinDateTime          .IsNully (zeroMatters: true ));
        IsFalse(MinDateTime          .IsNully (             true ));
        IsTrue (MinNullyDateTime     .IsNully (                  ));
        IsTrue (MinNullyDateTime     .IsNully (zeroMatters: false));
        IsTrue (MinNullyDateTime     .IsNully (             false));
        IsFalse(MinNullyDateTime     .IsNully (zeroMatters       ));
        IsFalse(MinNullyDateTime     .IsNully (zeroMatters: true ));
        IsFalse(MinNullyDateTime     .IsNully (             true ));
        IsFalse(MaxDateTime          .IsNully (                  ));
        IsFalse(MaxDateTime          .IsNully (zeroMatters: false));
        IsFalse(MaxDateTime          .IsNully (             false));
        IsFalse(MaxDateTime          .IsNully (zeroMatters       ));
        IsFalse(MaxDateTime          .IsNully (zeroMatters: true ));
        IsFalse(MaxDateTime          .IsNully (             true ));
        IsFalse(MaxNullyDateTime     .IsNully (                  ));
        IsFalse(MaxNullyDateTime     .IsNully (zeroMatters: false));
        IsFalse(MaxNullyDateTime     .IsNully (             false));
        IsFalse(MaxNullyDateTime     .IsNully (zeroMatters       ));
        IsFalse(MaxNullyDateTime     .IsNully (zeroMatters: true ));
        IsFalse(MaxNullyDateTime     .IsNully (             true ));
        IsFalse(NowDateTime          .IsNully (                  ));
        IsFalse(NowDateTime          .IsNully (zeroMatters: false));
        IsFalse(NowDateTime          .IsNully (             false));
        IsFalse(NowDateTime          .IsNully (zeroMatters       ));
        IsFalse(NowDateTime          .IsNully (zeroMatters: true ));
        IsFalse(NowDateTime          .IsNully (             true ));
        IsFalse(NowNullyDateTime     .IsNully (                  ));
        IsFalse(NowNullyDateTime     .IsNully (zeroMatters: false));
        IsFalse(NowNullyDateTime     .IsNully (             false));
        IsFalse(NowNullyDateTime     .IsNully (zeroMatters       ));
        IsFalse(NowNullyDateTime     .IsNully (zeroMatters: true ));
        IsFalse(NowNullyDateTime     .IsNully (             true ));
        IsFalse(SomeDateTime         .IsNully (                  ));
        IsFalse(SomeDateTime         .IsNully (zeroMatters: false));
        IsFalse(SomeDateTime         .IsNully (             false));
        IsFalse(SomeDateTime         .IsNully (zeroMatters       ));
        IsFalse(SomeDateTime         .IsNully (zeroMatters: true ));
        IsFalse(SomeDateTime         .IsNully (             true ));
        IsFalse(SomeNullyDateTime    .IsNully (                  ));
        IsFalse(SomeNullyDateTime    .IsNully (zeroMatters: false));
        IsFalse(SomeNullyDateTime    .IsNully (             false));
        IsFalse(SomeNullyDateTime    .IsNully (zeroMatters       ));
        IsFalse(SomeNullyDateTime    .IsNully (zeroMatters: true ));
        IsFalse(SomeNullyDateTime    .IsNully (             true ));
    }

    // TODO: Add more coalesce cases?

    [TestMethod]
    public void Test_DateTime_Coalesce()
    {
        NoNullRet(SomeDateTime, Coalesce(NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
    }

    [TestMethod]
    public void Test_DateTime_Coalesce_ZeroMatters()
    {
        NoNullRet(SomeDateTime, Coalesce(                    NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
        NoNullRet(SomeDateTime, Coalesce(zeroMatters: false, NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
        NoNullRet(SomeDateTime, Coalesce(             false, NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
        NoNullRet(NewDateTime,  Coalesce(zeroMatters,        NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
        NoNullRet(NewDateTime,  Coalesce(zeroMatters: true,  NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
        NoNullRet(NewDateTime,  Coalesce(             true,  NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
    }
}