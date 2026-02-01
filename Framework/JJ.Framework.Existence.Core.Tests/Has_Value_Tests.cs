namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Value_Tests
{
    // Has / FilledIn

    [TestMethod]
    public void FilledIn_True_Int1()
    {
        // Invariant under zeroMatters
        IsTrue(Has(NoNull1                         ));
        IsTrue(Has(NoNull1,      zeroMatters       ));
        IsTrue(Has(NoNull1,      zeroMatters: true ));
        IsTrue(Has(NoNull1,      zeroMatters: false));
        IsTrue(Has(Nully1                          ));
        IsTrue(Has(Nully1,       zeroMatters       ));
        IsTrue(Has(Nully1,       zeroMatters: true ));
        IsTrue(Has(Nully1,       zeroMatters: false));
        IsTrue(NoNull1.FilledIn(                   ));
        IsTrue(NoNull1.FilledIn( zeroMatters       ));
        IsTrue(NoNull1.FilledIn( zeroMatters: true ));
        IsTrue(NoNull1.FilledIn( zeroMatters: false));
        IsTrue(Nully1 .FilledIn(                   ));
        IsTrue(Nully1 .FilledIn( zeroMatters       ));
        IsTrue(Nully1 .FilledIn( zeroMatters: true ));
        IsTrue(Nully1 .FilledIn( zeroMatters: false));
        IsTrue(FilledIn(NoNull1                    ));
        IsTrue(FilledIn(NoNull1, zeroMatters       ));
        IsTrue(FilledIn(NoNull1, zeroMatters: true ));
        IsTrue(FilledIn(NoNull1, zeroMatters: false));
        IsTrue(FilledIn(Nully1                     ));
        IsTrue(FilledIn(Nully1,  zeroMatters       ));
        IsTrue(FilledIn(Nully1,  zeroMatters: true ));
        IsTrue(FilledIn(Nully1,  zeroMatters: false));
        IsTrue(FilledIn(zeroMatters,        NoNull1));
        IsTrue(FilledIn(zeroMatters: true , NoNull1));
        IsTrue(FilledIn(zeroMatters: false, NoNull1));
        IsTrue(FilledIn(zeroMatters,        Nully1 ));
        IsTrue(FilledIn(zeroMatters: true , Nully1 ));
        IsTrue(FilledIn(zeroMatters: false, Nully1 ));
    }
    
    [TestMethod]
    public void FilledIn_False_Int0()
    {
        // zeroMatters false
        IsFalse(Has(NoNull0                         ));
        IsFalse(Has(NoNull0,      zeroMatters: false));
        IsFalse(Has(NoNull0,                   false));
        IsFalse(Has(Nully0                          ));
        IsFalse(Has(Nully0,       zeroMatters: false));
        IsFalse(Has(Nully0,                    false));
        IsFalse(NoNull0.FilledIn(                   ));
        IsFalse(NoNull0.FilledIn( zeroMatters: false));
        IsFalse(NoNull0.FilledIn(              false));
        IsFalse(Nully0 .FilledIn(                   ));
        IsFalse(Nully0 .FilledIn( zeroMatters: false));
        IsFalse(Nully0 .FilledIn(              false));
        IsFalse(FilledIn(NoNull0                    ));
        IsFalse(FilledIn(NoNull0, zeroMatters: false));
        IsFalse(FilledIn(NoNull0,              false));
        IsFalse(FilledIn(Nully0                     ));
        IsFalse(FilledIn(Nully0,  zeroMatters: false));
        IsFalse(FilledIn(Nully0,               false));
        IsFalse(FilledIn(zeroMatters: false, NoNull0));
        IsFalse(FilledIn(             false, NoNull0));
        IsFalse(FilledIn(zeroMatters: false, Nully0 ));
        IsFalse(FilledIn(             false, Nully0 ));
    }
    
    [TestMethod]
    public void FilledIn_False_IntNull()
    {
        // zeroMatters false
        IsFalse(Has(NullNum                         ));
        IsFalse(Has(NullNum,      zeroMatters: false));
        IsFalse(Has(NullNum,                   false));
        IsFalse(NullNum.FilledIn(                   ));
        IsFalse(NullNum.FilledIn( zeroMatters: false));
        IsFalse(NullNum.FilledIn(              false));
        IsFalse(FilledIn(NullNum                    ));
        IsFalse(FilledIn(NullNum, zeroMatters: false));
        IsFalse(FilledIn(NullNum,              false));
        IsFalse(FilledIn(zeroMatters: false, NullNum));
        IsFalse(FilledIn(             false, NullNum));
    }

    [TestMethod]
    public void FilledIn_True_Int0_ZeroMatters()
    {
        IsTrue(Has(NoNull0,      zeroMatters       ));
        IsTrue(Has(NoNull0,      zeroMatters: true ));
        IsTrue(Has(NoNull0,                   true ));
        IsTrue(Has(Nully0,       zeroMatters       ));
        IsTrue(Has(Nully0,       zeroMatters: true ));
        IsTrue(Has(Nully0,                    true ));
        IsTrue(NoNull0.FilledIn( zeroMatters       ));
        IsTrue(NoNull0.FilledIn( zeroMatters: true ));
        IsTrue(NoNull0.FilledIn(              true ));
        IsTrue(Nully0 .FilledIn( zeroMatters       ));
        IsTrue(Nully0 .FilledIn( zeroMatters: true ));
        IsTrue(Nully0 .FilledIn(              true ));
        IsTrue(FilledIn(NoNull0, zeroMatters       ));
        IsTrue(FilledIn(NoNull0, zeroMatters: true ));
        IsTrue(FilledIn(NoNull0,              true ));
        IsTrue(FilledIn(Nully0,  zeroMatters       ));
        IsTrue(FilledIn(Nully0,  zeroMatters: true ));
        IsTrue(FilledIn(Nully0,               true ));
        IsTrue(FilledIn(zeroMatters,       NoNull0 ));
        IsTrue(FilledIn(zeroMatters: true, NoNull0 ));
        IsTrue(FilledIn(             true, NoNull0 ));
        IsTrue(FilledIn(zeroMatters,       Nully0  ));
        IsTrue(FilledIn(zeroMatters: true, Nully0  ));
        IsTrue(FilledIn(             true, Nully0  ));
    }

    [TestMethod]
    public void FilledIn_False_IntNull_ZeroMatters()
    {
        IsFalse(Has(NullNum,      zeroMatters       ));
        IsFalse(Has(NullNum,      zeroMatters: true ));
        IsFalse(Has(NullNum,                   true ));
        IsFalse(NullNum.FilledIn( zeroMatters       ));
        IsFalse(NullNum.FilledIn( zeroMatters: true ));
        IsFalse(NullNum.FilledIn(              true ));
        IsFalse(FilledIn(NullNum, zeroMatters       ));
        IsFalse(FilledIn(NullNum, zeroMatters: true ));
        IsFalse(FilledIn(NullNum,              true ));
        IsFalse(FilledIn(zeroMatters,       NullNum ));
        IsFalse(FilledIn(zeroMatters: true, NullNum ));
        IsFalse(FilledIn(             true, NullNum ));
    }

    // IsNully
    
    [TestMethod]
    public void IsNully_False_Int1()
    {
        // Invariant under zeroMatters
        IsFalse(NoNull1.IsNully(                   ));
        IsFalse(NoNull1.IsNully( zeroMatters       ));
        IsFalse(NoNull1.IsNully( zeroMatters: true ));
        IsFalse(NoNull1.IsNully(              true ));
        IsFalse(NoNull1.IsNully( zeroMatters: false));
        IsFalse(NoNull1.IsNully(              false));
        IsFalse(Nully1 .IsNully(                   ));
        IsFalse(Nully1 .IsNully( zeroMatters       ));
        IsFalse(Nully1 .IsNully( zeroMatters: true ));
        IsFalse(Nully1 .IsNully(              true ));
        IsFalse(Nully1 .IsNully( zeroMatters: false));
        IsFalse(Nully1 .IsNully(              false));
        IsFalse(IsNully(NoNull1                    ));
        IsFalse(IsNully(NoNull1, zeroMatters       ));
        IsFalse(IsNully(NoNull1, zeroMatters: true ));
        IsFalse(IsNully(NoNull1,              true ));
        IsFalse(IsNully(NoNull1, zeroMatters: false));
        IsFalse(IsNully(NoNull1,              false));
        IsFalse(IsNully(Nully1                     ));
        IsFalse(IsNully(Nully1,  zeroMatters       ));
        IsFalse(IsNully(Nully1,  zeroMatters: true ));
        IsFalse(IsNully(Nully1,               true ));
        IsFalse(IsNully(Nully1,  zeroMatters: false));
        IsFalse(IsNully(Nully1,               false));
    }

    [TestMethod]
    public void IsNully_True_Int0()
    {
        // zeroMatters false
        IsTrue(NoNull0.IsNully(                   ));
        IsTrue(NoNull0.IsNully( zeroMatters: false));
        IsTrue(NoNull0.IsNully(              false));
        IsTrue(Nully0 .IsNully(                   ));
        IsTrue(Nully0 .IsNully( zeroMatters: false));
        IsTrue(Nully0 .IsNully(              false));
        IsTrue(IsNully(NoNull0                    ));
        IsTrue(IsNully(NoNull0, zeroMatters: false));
        IsTrue(IsNully(NoNull0,              false));
        IsTrue(IsNully(Nully0                     ));
        IsTrue(IsNully(Nully0,  zeroMatters: false));
        IsTrue(IsNully(Nully0,               false));
    }
    
    [TestMethod]
    public void IsNully_True_IntNull()
    {
        IsTrue(NullNum.IsNully(                   ));
        IsTrue(NullNum.IsNully( zeroMatters: false));
        IsTrue(NullNum.IsNully(              false));
        IsTrue(IsNully(NullNum                    ));
        IsTrue(IsNully(NullNum, zeroMatters: false));
        IsTrue(IsNully(NullNum,              false));
    }

    [TestMethod]
    public void IsNully_False_Int0_ZeroMatters()
    {
        IsFalse(IsNully(NoNull0, zeroMatters       ));
        IsFalse(IsNully(NoNull0, zeroMatters: true ));
        IsFalse(IsNully(NoNull0,              true ));
        IsFalse(IsNully(Nully0,  zeroMatters       ));
        IsFalse(IsNully(Nully0,  zeroMatters: true ));
        IsFalse(IsNully(Nully0,               true ));
        IsFalse(NoNull0.IsNully( zeroMatters       ));
        IsFalse(NoNull0.IsNully( zeroMatters: true ));
        IsFalse(NoNull0.IsNully(              true ));
        IsFalse(Nully0 .IsNully( zeroMatters       ));
        IsFalse(Nully0 .IsNully( zeroMatters: true ));
        IsFalse(Nully0 .IsNully(              true ));
        IsFalse(IsNully(NoNull0, zeroMatters       ));
        IsFalse(IsNully(NoNull0, zeroMatters: true ));
        IsFalse(IsNully(NoNull0,              true ));
        IsFalse(IsNully(Nully0,  zeroMatters       ));
        IsFalse(IsNully(Nully0,  zeroMatters: true ));
        IsFalse(IsNully(Nully0,               true ));
    }

    [TestMethod]
    public void IsNully_True_IntNull_ZeroMatters()
    {
        IsTrue(IsNully(NullNum, zeroMatters       ));
        IsTrue(IsNully(NullNum, zeroMatters: true ));
        IsTrue(IsNully(NullNum,              true ));
        IsTrue(NullNum.IsNully( zeroMatters       ));
        IsTrue(NullNum.IsNully( zeroMatters: true ));
        IsTrue(NullNum.IsNully(              true ));
        IsTrue(IsNully(NullNum, zeroMatters       ));
        IsTrue(IsNully(NullNum, zeroMatters: true ));
        IsTrue(IsNully(NullNum,              true ));
    }
}