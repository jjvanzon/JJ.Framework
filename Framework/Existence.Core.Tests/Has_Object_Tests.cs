namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Has_Object_Tests : TestBase
{
    [TestMethod]
    public void Has_Object()
    {
        IsFalse(Has(NullObj));
        IsTrue (Has(NoNullObj));
        IsTrue (Has(NullyFilledObj));
    }
}