using static System.DateTime;

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_DateTime_Tests
{
    // DateTime

    DateTime? NullDateTime         = null;
    DateTime  DefaultDateTime      = default;
    DateTime? DefaultNullyDateTime = default;
    DateTime  NewDateTime          = new();
    DateTime? NewNullyDateTime     = new();
    DateTime  MinDateTime          = MinValue;
    DateTime? MinNullyDateTime     = MinValue; 
    DateTime  MaxDateTime          = MaxValue;
    DateTime? MaxNullyDateTime     = MaxValue;
    DateTime  NowDateTime          = Now;
    DateTime? NowNullyDateTime     = Now;
    DateTime  SomeDateTime         = new(2023, 10, 1, 12, 10, 23);
    DateTime? SomeNullyDateTime    = new(2023, 10, 1, 12, 10, 23);
                                   
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
    public void Test_DateTime_FilledIn()
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
    public void Test_DateTime_IsNully()
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
    public void Test_DateTime_Coalesce()
    {
        NoNullRet(SomeDateTime, Coalesce(NewNullyDateTime, NewDateTime, SomeNullyDateTime, NowNullyDateTime, SomeDateTime));
    }
}