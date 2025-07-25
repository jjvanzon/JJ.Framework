namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Value_Tests
{
    // Has / FilledIn

    [TestMethod]
    public void FilledIn_True_Int1()
    {
        // Invariant under zeroMatters
        IsTrue(Has(NoNull1                        ));
        IsTrue(Has(NoNull1,     zeroMatters       ));
        IsTrue(Has(NoNull1,     zeroMatters: true ));
        IsTrue(Has(NoNull1,     zeroMatters: false));
        IsTrue(Has(Nully1                         ));
        IsTrue(Has(Nully1,      zeroMatters       ));
        IsTrue(Has(Nully1,      zeroMatters: true ));
        IsTrue(Has(Nully1,      zeroMatters: false));
        IsTrue(NoNull1.FilledIn(                  ));
        IsTrue(NoNull1.FilledIn(zeroMatters       ));
        IsTrue(NoNull1.FilledIn(zeroMatters: true ));
        IsTrue(NoNull1.FilledIn(zeroMatters: false));
        IsTrue(Nully1 .FilledIn(                  ));
        IsTrue(Nully1 .FilledIn(zeroMatters       ));
        IsTrue(Nully1 .FilledIn(zeroMatters: true ));
        IsTrue(Nully1 .FilledIn(zeroMatters: false));
        IsTrue(FilledIn(NoNull1                   ));
        IsTrue(FilledIn(NoNull1,zeroMatters       ));
        IsTrue(FilledIn(NoNull1,zeroMatters: true ));
        IsTrue(FilledIn(NoNull1,zeroMatters: false));
        IsTrue(FilledIn(Nully1                    ));
        IsTrue(FilledIn(Nully1, zeroMatters       ));
        IsTrue(FilledIn(Nully1, zeroMatters: true ));
        IsTrue(FilledIn(Nully1, zeroMatters: false));
    }
    
    [TestMethod]
    public void FilledIn_False_Int0()
    {
        // zeroMatters false
        IsFalse(Has(NoNull0                         ));
        IsFalse(Has(NoNull0,      zeroMatters: false));
        IsFalse(Has(Nully0                          ));
        IsFalse(Has(Nully0,       zeroMatters: false));
        IsFalse(NoNull0.FilledIn(                   ));
        IsFalse(NoNull0.FilledIn( zeroMatters: false));
        IsFalse(Nully0 .FilledIn(                   ));
        IsFalse(Nully0 .FilledIn( zeroMatters: false));
        IsFalse(FilledIn(NoNull0                    ));
        IsFalse(FilledIn(NoNull0, zeroMatters: false));
        IsFalse(FilledIn(Nully0                     ));
        IsFalse(FilledIn(Nully0,  zeroMatters: false));
    }
    
    [TestMethod]
    public void FilledIn_False_IntNull()
    {
        // zeroMatters false
        IsFalse(Has(NullNum                         ));
        IsFalse(Has(NullNum,      zeroMatters: false));
        IsFalse(NullNum.FilledIn(                   ));
        IsFalse(NullNum.FilledIn( zeroMatters: false));
        IsFalse(FilledIn(NullNum                    ));
        IsFalse(FilledIn(NullNum, zeroMatters: false));
    }

    [TestMethod]
    public void FilledIn_True_Int0_ZeroMatters()
    {
        IsTrue(Has(NoNull0,      zeroMatters       ));
        IsTrue(Has(NoNull0,      zeroMatters: true ));
        IsTrue(Has(Nully0,       zeroMatters       ));
        IsTrue(Has(Nully0,       zeroMatters: true ));
        IsTrue(NoNull0.FilledIn( zeroMatters       ));
        IsTrue(NoNull0.FilledIn( zeroMatters: true ));
        IsTrue(Nully0 .FilledIn( zeroMatters       ));
        IsTrue(Nully0 .FilledIn( zeroMatters: true ));
        IsTrue(FilledIn(NoNull0, zeroMatters       ));
        IsTrue(FilledIn(NoNull0, zeroMatters: true ));
        IsTrue(FilledIn(Nully0,  zeroMatters       ));
        IsTrue(FilledIn(Nully0,  zeroMatters: true ));
    }

    [TestMethod]
    public void FilledIn_False_IntNull_ZeroMatters()
    {
        IsFalse(Has(NullNum,      zeroMatters       ));
        IsFalse(Has(NullNum,      zeroMatters: true ));
        IsFalse(NullNum.FilledIn( zeroMatters       ));
        IsFalse(NullNum.FilledIn( zeroMatters: true ));
        IsFalse(FilledIn(NullNum, zeroMatters       ));
        IsFalse(FilledIn(NullNum, zeroMatters: true ));
    }

    // IsNully
    
    [TestMethod]
    public void IsNully_False_Int1()
    {
        // Invariant under zeroMatters
        IsFalse(NoNull1.IsNully(                   ));
        IsFalse(NoNull1.IsNully( zeroMatters       ));
        IsFalse(NoNull1.IsNully( zeroMatters: true ));
        IsFalse(NoNull1.IsNully( zeroMatters: false));
        IsFalse(Nully1 .IsNully(                   ));
        IsFalse(Nully1 .IsNully( zeroMatters       ));
        IsFalse(Nully1 .IsNully( zeroMatters: true ));
        IsFalse(Nully1 .IsNully( zeroMatters: false));
        IsFalse(IsNully(NoNull1                    ));
        IsFalse(IsNully(NoNull1, zeroMatters       ));
        IsFalse(IsNully(NoNull1, zeroMatters: true ));
        IsFalse(IsNully(NoNull1, zeroMatters: false));
        IsFalse(IsNully(Nully1                     ));
        IsFalse(IsNully(Nully1,  zeroMatters       ));
        IsFalse(IsNully(Nully1,  zeroMatters: true ));
        IsFalse(IsNully(Nully1,  zeroMatters: false));
    }
    
    [TestMethod]
    public void IsNully_True_Int0()
    {
        // zeroMatters false
        IsTrue(NoNull0.IsNully(                   ));
        IsTrue(NoNull0.IsNully( zeroMatters: false));
        IsTrue(Nully0 .IsNully(                   ));
        IsTrue(Nully0 .IsNully( zeroMatters: false));
        IsTrue(IsNully(NoNull0                    ));
        IsTrue(IsNully(NoNull0, zeroMatters: false));
        IsTrue(IsNully(Nully0                     ));
        IsTrue(IsNully(Nully0,  zeroMatters: false));
    }
    
    [TestMethod]
    public void IsNully_True_IntNull()
    {
        IsTrue(NullNum.IsNully(                   ));
        IsTrue(NullNum.IsNully( zeroMatters: false));
        IsTrue(IsNully(NullNum                    ));
        IsTrue(IsNully(NullNum, zeroMatters: false));
    }

    [TestMethod]
    public void IsNully_False_Int0_ZeroMatters()
    {
        IsFalse(IsNully(NoNull0, zeroMatters       ));
        IsFalse(IsNully(NoNull0, zeroMatters: true ));
        IsFalse(IsNully(Nully0,  zeroMatters       ));
        IsFalse(IsNully(Nully0,  zeroMatters: true ));
        IsFalse(NoNull0.IsNully( zeroMatters       ));
        IsFalse(NoNull0.IsNully( zeroMatters: true ));
        IsFalse(Nully0 .IsNully( zeroMatters       ));
        IsFalse(Nully0 .IsNully( zeroMatters: true ));
        IsFalse(IsNully(NoNull0, zeroMatters       ));
        IsFalse(IsNully(NoNull0, zeroMatters: true ));
        IsFalse(IsNully(Nully0,  zeroMatters       ));
        IsFalse(IsNully(Nully0,  zeroMatters: true ));
    }

    [TestMethod]
    public void IsNully_True_IntNull_ZeroMatters()
    {
        IsTrue(IsNully(NullNum, zeroMatters       ));
        IsTrue(IsNully(NullNum, zeroMatters: true ));
        IsTrue(NullNum.IsNully( zeroMatters       ));
        IsTrue(NullNum.IsNully( zeroMatters: true ));
        IsTrue(IsNully(NullNum, zeroMatters       ));
        IsTrue(IsNully(NullNum, zeroMatters: true ));
    }
}