using static System.DateTime;
﻿namespace JJ.Framework.Existence.Core.Tests;

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
}