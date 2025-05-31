namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Object
{
    [TestMethod]
    public void FilledIn_Object_True()
    {
        IsTrue(Has(NoNullObj));
        IsTrue(Has(NullyFilled));
        IsTrue(FilledIn(NoNullObj));
        IsTrue(FilledIn(NullyFilled));
        IsTrue(NoNullObj.FilledIn());
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
        IsFalse(IsNully(NoNullObj));
        IsFalse(IsNully(NullyFilled));
        IsFalse(NoNullObj.IsNully());
        IsFalse(NullyFilled.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Object_True()
    {
        IsTrue(IsNully(NullObj));
        IsTrue(NullObj.IsNully());
    }
}