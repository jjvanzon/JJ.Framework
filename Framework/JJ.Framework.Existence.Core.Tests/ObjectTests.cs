namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class ObjectTests
{
    [TestMethod]
    public void FilledIn_Object_True()
    {
        IsTrue(Has(NonNullObject));
        IsTrue(Has(NullableFilled));
        IsTrue(FilledIn(NonNullObject));
        IsTrue(FilledIn(NullableFilled));
        IsTrue(NonNullObject.FilledIn());
        IsTrue(NullableFilled.FilledIn());
    }
    
    [TestMethod]
    public void FilledIn_Object_False()
    {
        IsFalse(Has(NullObject));
        IsFalse(FilledIn(NullObject));
        IsFalse(NullObject.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Object_False()
    {
        IsFalse(IsNully(NonNullObject));
        IsFalse(IsNully(NullableFilled));
        IsFalse(NonNullObject.IsNully());
        IsFalse(NullableFilled.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Object_True()
    {
        IsTrue(IsNully(NullObject));
        IsTrue(NullObject.IsNully());
    }
}