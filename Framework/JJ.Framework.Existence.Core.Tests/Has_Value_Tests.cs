namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Value_Tests
{
    [TestMethod]
    public void Has_True_Int1()
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
    }
    
    [TestMethod]
    public void Has_False_Int0()
    {
        // zeroMatters false
        IsFalse(Has(NoNull0                         ));
        IsFalse(Has(NoNull0,      zeroMatters: false));
        IsFalse(Has(NoNull0,                   false));
        IsFalse(Has(Nully0                          ));
        IsFalse(Has(Nully0,       zeroMatters: false));
        IsFalse(Has(Nully0,                    false));
    }
    
    [TestMethod]
    public void Has_False_IntNull()
    {
        // zeroMatters false
        IsFalse(Has(NullNum                         ));
        IsFalse(Has(NullNum,      zeroMatters: false));
        IsFalse(Has(NullNum,                   false));
    }

    [TestMethod]
    public void Has_True_Int0_ZeroMatters()
    {
        IsTrue(Has(NoNull0,      zeroMatters       ));
        IsTrue(Has(NoNull0,      zeroMatters: true ));
        IsTrue(Has(NoNull0,                   true ));
        IsTrue(Has(Nully0,       zeroMatters       ));
        IsTrue(Has(Nully0,       zeroMatters: true ));
        IsTrue(Has(Nully0,                    true ));
    }

    [TestMethod]
    public void Has_False_IntNull_ZeroMatters()
    {
        IsFalse(Has(NullNum,      zeroMatters       ));
        IsFalse(Has(NullNum,      zeroMatters: true ));
        IsFalse(Has(NullNum,                   true ));
    }
}