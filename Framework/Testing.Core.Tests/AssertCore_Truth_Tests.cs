namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertCore_Truth_Tests
{
    // True

    [TestMethod]
    public void Test_AssertCore_IsTrue()
    {
        IsTrue(true);
        IsTrue(true, "oops");

        Throws(() => IsTrue(false),         "IsTrue failed", "false");
        Throws(() => IsTrue(false, "oops"), "IsTrue failed", "false", "oops");
    }

    // False

    [TestMethod]
    public void Test_AssertCore_IsFalse()
    {
        IsFalse(false);
        IsFalse(false, "oops");

        Throws(() => IsFalse(true),         "IsFalse failed", "true");
        Throws(() => IsFalse(true, "oops"), "IsFalse failed", "true", "oops");
    }

    // Fail

    [TestMethod]
    public void Test_AssertCore_Fail()
    {
        Throws(() => Fail(      ), "failed");
        Throws(() => Fail("oops"), "failed", "oops");
    }
}