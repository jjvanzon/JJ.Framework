namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_Tests
{
    private static readonly Dummy? NullyFilled = NullyFilledObj;
    
    // Objects

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