namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Value_Tests
{
    [TestMethod]
    public void FilledIn_True_Int1()
    {
        IsTrue(Has(NoNull1));
        IsTrue(Has(Nully1));
        IsTrue(NoNull1.FilledIn());
        IsTrue(Nully1.FilledIn());
        IsTrue(FilledIn(NoNull1));
        IsTrue(FilledIn(Nully1));
    }

    [TestMethod]
    public void FilledIn_True_Int1_Default0MattersFalse()
    {
        IsTrue(Has(NoNull1,       zeroMatters: false));
        IsTrue(Has(Nully1,        zeroMatters: false));
        IsTrue(NoNull1.FilledIn(  zeroMatters: false));
        IsTrue(Nully1 .FilledIn(  zeroMatters: false));
        IsTrue(FilledIn(NoNull1,  zeroMatters: false));
        IsTrue(FilledIn(Nully1,   zeroMatters: false));
    }

    [TestMethod]
    public void FilledIn_True_Int1_Default0MattersTrue()
    {
        IsTrue(Has(NoNull1,       zeroMatters: true));
        IsTrue(Has(Nully1,        zeroMatters: true));
        IsTrue(NoNull1.FilledIn(  zeroMatters: true));
        IsTrue(Nully1 .FilledIn(  zeroMatters: true));
        IsTrue(FilledIn(NoNull1,  zeroMatters: true));
        IsTrue(FilledIn(Nully1,   zeroMatters: true));
    }

    [TestMethod]
    public void FilledIn_True_Int1_Default0Matters()
    {
        IsTrue(Has(NoNull1,       zeroMatters));
        IsTrue(Has(Nully1,        zeroMatters));
        IsTrue(NoNull1.FilledIn(  zeroMatters));
        IsTrue(Nully1 .FilledIn(  zeroMatters));
        IsTrue(FilledIn(NoNull1,  zeroMatters));
        IsTrue(FilledIn(Nully1,   zeroMatters));
    }
    
    [TestMethod]
    public void FilledIn_False_IntNullOr0()
    {
        IsFalse(Has(NullNum));
        IsFalse(Has(NoNull0));
        IsFalse(Has(Nully0));
        IsFalse(NullNum.FilledIn());
        IsFalse(NoNull0.FilledIn());
        IsFalse(Nully0.FilledIn());
        IsFalse(FilledIn(NullNum));
        IsFalse(FilledIn(NoNull0));
        IsFalse(FilledIn(Nully0));
    }

    [TestMethod]
    public void FilledIn_False_IntNullOr0_Default0MattersFalse()
    {
        IsFalse(Has(NullNum,      zeroMatters: false));
        IsFalse(Has(NoNull0,      zeroMatters: false));
        IsFalse(Has(Nully0,       zeroMatters: false));
        IsFalse(NullNum.FilledIn( zeroMatters: false));
        IsFalse(NoNull0.FilledIn( zeroMatters: false));
        IsFalse(Nully0 .FilledIn( zeroMatters: false));
        IsFalse(FilledIn(NullNum, zeroMatters: false));
        IsFalse(FilledIn(NoNull0, zeroMatters: false));
        IsFalse(FilledIn(Nully0,  zeroMatters: false));
    }
    
    [TestMethod]
    public void IsNully_Int_False()
    {
        IsFalse(NoNull1.IsNully());
        IsFalse(Nully1.IsNully());
        IsFalse(IsNully(NoNull1));
        IsFalse(IsNully(Nully1));
    }
    
    [TestMethod]
    public void IsNully_Int_True()
    {
        IsTrue(NullNum.IsNully());
        IsTrue(NoNull0.IsNully());
        IsTrue(Nully0.IsNully());
        IsTrue(IsNully(NullNum));
        IsTrue(IsNully(NoNull0));
        IsTrue(IsNully(Nully0));
    }
}