namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class IsNully_Object_Tests : TestBase
{
    [TestMethod]
    public void IsNully_Object_Extensions()
    {
        IsTrue (NullObj       .IsNully());
        IsFalse(NoNullObj     .IsNully());
        IsFalse(NullyFilledObj.IsNully());
    }

    [TestMethod]
    public void IsNully_Object_Static()
    {
        IsTrue (IsNully(NullObj       ));
        IsFalse(IsNully(NoNullObj     ));
        IsFalse(IsNully(NullyFilledObj));
    }
}