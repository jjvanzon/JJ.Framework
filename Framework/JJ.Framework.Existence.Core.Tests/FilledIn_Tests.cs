namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledIn_Tests
{
    private static readonly Dummy? NullyFilled = NullyFilledObj;

    // Objects

    [TestMethod]
    public void FilledIn_Object_True()
    {
        IsTrue(FilledIn(NoNullObj));
        IsTrue(FilledIn(NullyFilled));
        IsTrue(NoNullObj.FilledIn());
        IsTrue(NullyFilled.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Object_False()
    {
        IsFalse(FilledIn(NullObj));
        IsFalse(NullObj.FilledIn());
    }
}