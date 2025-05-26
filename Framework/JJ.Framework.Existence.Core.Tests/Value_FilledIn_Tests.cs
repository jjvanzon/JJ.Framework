namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Value_FilledIn_Tests
{
    [TestMethod]
    public void FilledIn_Int_True()
    {
        IsTrue(Has(NonNull1));
        IsTrue(Has(Nully1));
        IsTrue(NonNull1.FilledIn());
        IsTrue(Nully1.FilledIn());
        IsTrue(FilledIn(NonNull1));
        IsTrue(FilledIn(Nully1));
    }
    
    [TestMethod]
    public void FilledIn_Int_False()
    {
        IsFalse(Has(NullNum));
        IsFalse(Has(NonNull0));
        IsFalse(Has(Nully0));
        IsFalse(NullNum.FilledIn());
        IsFalse(NonNull0.FilledIn());
        IsFalse(Nully0.FilledIn());
        IsFalse(FilledIn(NullNum));
        IsFalse(FilledIn(NonNull0));
        IsFalse(FilledIn(Nully0));
    }
        
    [TestMethod]
    public void IsNully_Int_False()
    {
        IsFalse(NonNull1.IsNully());
        IsFalse(Nully1.IsNully());
        IsFalse(IsNully(NonNull1));
        IsFalse(IsNully(Nully1));
    }
    
    [TestMethod]
    public void IsNully_Int_True()
    {
        IsTrue(NullNum.IsNully());
        IsTrue(NonNull0.IsNully());
        IsTrue(Nully0.IsNully());
        IsTrue(IsNully(NullNum));
        IsTrue(IsNully(NonNull0));
        IsTrue(IsNully(Nully0));
    }
}