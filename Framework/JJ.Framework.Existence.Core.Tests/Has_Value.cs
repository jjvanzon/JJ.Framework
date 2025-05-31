namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Value
{
    [TestMethod]
    public void FilledIn_Int_True()
    {
        IsTrue(Has(NoNull1));
        IsTrue(Has(Nully1));
        IsTrue(NoNull1.FilledIn());
        IsTrue(Nully1.FilledIn());
        IsTrue(FilledIn(NoNull1));
        IsTrue(FilledIn(Nully1));
    }
    
    [TestMethod]
    public void FilledIn_Int_False()
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