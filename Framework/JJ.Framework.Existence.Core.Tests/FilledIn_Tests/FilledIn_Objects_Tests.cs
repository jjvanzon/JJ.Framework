namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledIn_Objects_Tests : TestBase
{
    [TestMethod]
    public void FilledIn_Object_Extensions()
    {
        IsFalse(NullObj       .FilledIn());
        IsTrue (NoNullObj     .FilledIn());
        IsTrue (NullyFilledObj.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Object_Static()
    {
        IsFalse(FilledIn(NullObj       ));
        IsTrue (FilledIn(NoNullObj     ));
        IsTrue (FilledIn(NullyFilledObj));
    }
}