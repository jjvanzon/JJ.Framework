namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class ObjectTests
{
    [TestMethod]
    public void FilledIn_Object_True()
    {
        IsTrue(Has(NonNullObj));
        IsTrue(Has(NullyFilled));
        IsTrue(FilledIn(NonNullObj));
        IsTrue(FilledIn(NullyFilled));
        IsTrue(NonNullObj.FilledIn());
        IsTrue(NullyFilled.FilledIn());
    }
    
    [TestMethod]
    public void FilledIn_Object_False()
    {
        IsFalse(Has(NullObj));
        IsFalse(FilledIn(NullObj));
        IsFalse(NullObj.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Object_False()
    {
        IsFalse(IsNully(NonNullObj));
        IsFalse(IsNully(NullyFilled));
        IsFalse(NonNullObj.IsNully());
        IsFalse(NullyFilled.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Object_True()
    {
        IsTrue(IsNully(NullObj));
        IsTrue(NullObj.IsNully());
    }
}