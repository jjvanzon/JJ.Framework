namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertCore_Methods_Tests
{
    // TODO: Use a reference type for the (object) tests.
    // TODO: Test for type int, string, maybe CultureInfo (for a reference type).

    [TestMethod]
    public void AssertCore_AreEqual_Object_Overloads()
    {
        AreEqual((object)1, (object)1);
        AreEqual((object)1, (object)1, "ok");
        Throws(() => AreEqual((object)1, (object)2), "Assert.AreEqual failed.");
        Throws(() => AreEqual((object)1, (object)2, "x"), "Assert.AreEqual failed.", "x");
    }

    [TestMethod]
    public void AssertCore_AreEqual_Generic_Overloads()
    {
        AreEqual(1, 1);
        AreEqual(1, 1, "ok");
        // TODO: From now on, test if `actual` ends up in the message too.
        //Throws(() => AreEqual(1, 2), "Assert.AreEqual failed.");
        Throws(() => AreEqual(1, 2), "AreEqual failed.", "Tested", "2");
        //Throws(() => AreEqual(1, 2, "x"), "Assert.AreEqual failed.", "x");
        Throws(() => AreEqual(1, 2, "yeah"), "AreEqual failed.", "Tested", "2", "yeah");
    }

    // TODO: You didn't test the failure cases here.

    [TestMethod]
    public void AssertCore_NotEqual_And_AreNotEqual_Overloads()
    {
        // TODO: Using a reference type (e.g. CultureInfo) should take care of the ugly (object) casts.
        // TODO: Replace "ok" by "yeah"
        NotEqual((object)1, (object)2);
        NotEqual((object)1, (object)2, "ok");
        NotEqual(1, 2);
        NotEqual(1, 2, "ok");
        AreNotEqual((object)1, (object)2);
        AreNotEqual((object)1, (object)2, "ok");
        AreNotEqual(1, 2);
        AreNotEqual(1, 2, "ok");
    }

    [TestMethod]
    public void AssertCore_AreSame_NotSame_AreNotSame_Overloads()
    {
        var x = new object();
        var y = new object();

        AreSame((object)x, (object)x);
        AreSame((object)x, (object)x, "ok");
        AreSame(x, x);
        AreSame(x, x, "ok");

        NotSame((object)x, (object)y);
        NotSame((object)x, (object)y, "ok");
        NotSame(x, y);
        NotSame(x, y, "ok");

        AreNotSame((object)x, (object)y);
        AreNotSame((object)x, (object)y, "ok");
        AreNotSame(x, y);
        AreNotSame(x, y, "ok");
    }

    [TestMethod]
    public void AssertCore_Null_Overloads()
    {
        IsNotNull(new object());
        IsNotNull(new object(), "ok");
        NotNull(new object());
        NotNull(new object(), "ok");
        IsNull((object?)null);
        IsNull((object?)null, "ok");
    }

    [TestMethod]
    public void AssertCore_NullOrEmpty_Overloads()
    {
        IsNotNullOrEmpty("x");
        IsNotNullOrEmpty("x", "ok");
        NotNullOrEmpty("x");
        NotNullOrEmpty("x", "ok");
        IsNullOrEmpty("");
        IsNullOrEmpty("", "ok");
        NullOrEmpty("");
        NullOrEmpty("", "ok");
    }

    [TestMethod]
    public void AssertCore_NullOrWhiteSpace_Overloads()
    {
        IsNotNullOrWhiteSpace("x");
        IsNotNullOrWhiteSpace("x", "ok");
        NotNullOrWhiteSpace("x");
        NotNullOrWhiteSpace("x", "ok");
        IsNullOrWhiteSpace(" ");
        IsNullOrWhiteSpace(" ", "ok");
        NullOrWhiteSpace("\t");
        NullOrWhiteSpace("\t", "ok");
    }

    [TestMethod]
    public void AssertCore_Misc_Methods()
    {
        IsTrue(true);
        IsTrue(true, "ok");
        IsFalse(false);
        IsFalse(false, "ok");
        Contains("needle", "haystack NEEDLE hay");
        Throws(() => Fail(), "Assert. failed.");
        Throws(() => Fail("x"), "Assert. failed.", "x");
    }

    [TestMethod]
    public void AssertCore_NoNullRet_And_NullRet_Methods()
    {
        NoNullRet(1);
        NoNullRet(1, "ok");
        NoNullRet(1, 1);
        NoNullRet(1, 1, "ok");
        NoNullRet("a", "a");
        NoNullRet("a", "a", "ok");
        NullRet(1, (int?)1);
        NullRet(1, (int?)1, "ok");
    }

    // TODO: Avoid casts to (Action) and (Func<>).

    [TestMethod]
    public void AssertCore_Throws_Methods()
    {
        Throws((Action)(() => throw new InvalidOperationException("boom")), "boom");
        Throws((Func<object?>)(() => throw new InvalidOperationException("boom")), "boom");
        Throws((Action)(() => throw new InvalidOperationException("boom")), typeof(InvalidOperationException), "boom");
        Throws((Func<object?>)(() => throw new InvalidOperationException("boom")), typeof(InvalidOperationException), "boom");
        Throws<InvalidOperationException>((Action)(() => throw new InvalidOperationException("boom")), "boom");
        Throws<InvalidOperationException>((Func<object?>)(() => throw new InvalidOperationException("boom")), "boom");
    }

    [TestMethod]
    public void AssertCore_ThrowsException_Methods()
    {
        ThrowsException((Func<object?>)(() => throw new InvalidOperationException()));
        ThrowsException((Func<object?>)(() => throw new InvalidOperationException("boom")), "boom");
        ThrowsException((Func<object?>)(() => throw new InvalidOperationException()), typeof(InvalidOperationException));
        ThrowsException((Func<object?>)(() => throw new InvalidOperationException("boom")), typeof(InvalidOperationException), "boom");
        ThrowsException<InvalidOperationException>((Func<object?>)(() => throw new InvalidOperationException()));
        ThrowsException<InvalidOperationException>((Func<object?>)(() => throw new InvalidOperationException("boom")), "boom");
    }

    [TestMethod]
    public void AssertCore_ThrowsOnOtherThread_Methods()
    {
        ThrowsExceptionOnOtherThread((Func<object?>)(() => throw new InvalidOperationException()));
        ThrowsOnOtherThread((Action)(() => throw new InvalidOperationException()));
        ThrowsOnOtherThread((Func<object?>)(() => throw new InvalidOperationException()));
    }

    [TestMethod]
    public void AssertCore_Type_Methods()
    {
        IsType(typeof(int?), (int?)1);
        IsType(typeof(int?), (int?)1, "ok");
        NotType(typeof(int), (int?)1);
        NotType(typeof(int), (int?)1, "ok");
        NotType(typeof(string), typeof(int));
        NotType(typeof(string), typeof(int), "ok");
    }
}
