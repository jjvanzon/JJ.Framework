namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Tests
{
    private static readonly Dummy? NullyFilled = NullyFilledObj;

    // Objects

    [TestMethod]
    public void Has_Object_True()
    {
        IsTrue(Has(NoNullObj));
        IsTrue(Has(NullyFilled));
    }
    
    [TestMethod]
    public void Has_Object_False()
    {
        IsFalse(Has(NullObj));
    }
}