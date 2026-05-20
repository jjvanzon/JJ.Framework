
namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertCore_Methods_Tests
{
    [TestMethod]
    public void AssertCore_AreEqual_Object_Overloads()
    {
        object expected = InvariantCulture;
        object same = expected;
        object other = new CultureInfo("nl-NL");

        AreEqual(expected, same);
        AreEqual(expected, same, "oops");
        Throws(() => AreEqual(expected, other), "AreEqual failed.", "other");
        Throws(() => AreEqual(expected, other, "oops"), "AreEqual failed.", "other", "oops");
    }

    [TestMethod]
    public void AssertCore_AreEqual_Generic_Overloads()
    {
        AreEqual(1, 1);
        AreEqual(1, 1, "oops");
        AreEqual("a", "a");
        AreEqual("a", "a", "oops");

        var expectedCulture = InvariantCulture;
        var sameCulture = expectedCulture;
        var actualCulture = new CultureInfo("nl-NL");

        AreEqual(expectedCulture, sameCulture);
        AreEqual(expectedCulture, sameCulture, "oops");

        Throws(() => AreEqual(1, 2), "AreEqual failed.", "Tested", "2");
        Throws(() => AreEqual("a", "b"), "AreEqual failed.", "Tested", "b");
        Throws(() => AreEqual(expectedCulture, actualCulture), "AreEqual failed.", "Tested", "actualCulture");
        Throws(() => AreEqual(1, 2, "oops"), "AreEqual failed.", "Tested", "2", "oops");
        Throws(() => AreEqual("a", "b", "oops"), "AreEqual failed.", "Tested", "b\"", "oops");
        Throws(() => AreEqual(expectedCulture, actualCulture, "oops"), "AreEqual failed.", "Tested", "actualCulture", "oops");
    }

    [TestMethod]
    public void AssertCore_NotEqual_And_AreNotEqual_Overloads()
    {
        object expected = InvariantCulture;
        object different = new CultureInfo("nl-NL");
        const int same = 1;

        NotEqual(expected, different);
        NotEqual(expected, different, "oops");
        NotEqual(1, 2);
        NotEqual(1, 2, "oops");
        AreNotEqual(expected, different);
        AreNotEqual(expected, different, "oops");
        AreNotEqual(1, 2);
        AreNotEqual(1, 2, "oops");

        Throws(() => NotEqual(expected, expected), "NotEqual failed.");
        Throws(() => NotEqual(1, same, "oops"), "NotEqual failed.", "same", "oops");
        Throws(() => AreNotEqual(expected, expected), "AreNotEqual failed.");
        Throws(() => AreNotEqual(1, same, "oops"), "AreNotEqual failed.", "same", "oops");
    }

    [TestMethod]
    public void AssertCore_AreSame_NotSame_AreNotSame_Overloads()
    {
        var x = new object();
        var y = new object();

        AreSame(x, x);
        AreSame(x, x, "oops");

        NotSame(x, y);
        NotSame(x, y, "oops");

        AreNotSame(x, y);
        AreNotSame(x, y, "oops");

        Throws(() => AreSame(x, y), "AreSame failed.");
        Throws(() => AreSame(x, y, "oops"), "AreSame failed.", "y", "oops");
        Throws(() => NotSame(x, x), "NotSame failed.");
        Throws(() => NotSame(x, x, "oops"), "NotSame failed.", "x", "oops");
        Throws(() => AreNotSame(x, x), "AreNotSame failed.");
        Throws(() => AreNotSame(x, x, "oops"), "AreNotSame failed.", "x", "oops");
    }

    [TestMethod]
    public void AssertCore_Null_Overloads()
    {
        object value = new();

        IsNotNull(new object());
        IsNotNull(new object(), "oops");
        NotNull(new object());
        NotNull(new object(), "oops");
        IsNull((object?)null);
        IsNull((object?)null, "oops");

        Throws(() => IsNotNull((object?)null), "NotNull failed.");
        Throws(() => IsNotNull((object?)null, "oops"), "NotNull failed.", "oops");
        Throws(() => NotNull((object?)null), "NotNull failed.");
        Throws(() => NotNull((object?)null, "oops"), "NotNull failed.", "oops");
        Throws(() => IsNull(value), "IsNull failed.");
        Throws(() => IsNull(value, "oops"), "IsNull failed.", "value", "oops");
    }

    [TestMethod]
    public void AssertCore_NullOrEmpty_Overloads()
    {
        string filled = "x";

        IsNotNullOrEmpty("x");
        IsNotNullOrEmpty("x", "oops");
        NotNullOrEmpty("x");
        NotNullOrEmpty("x", "oops");
        IsNullOrEmpty("");
        IsNullOrEmpty("", "oops");
        NullOrEmpty("");
        NullOrEmpty("", "oops");

        Throws(() => IsNotNullOrEmpty(""), "NotNullOrEmpty failed.");
        Throws(() => IsNotNullOrEmpty("", "oops"), "NotNullOrEmpty failed.", "oops");
        Throws(() => NotNullOrEmpty(""), "NotNullOrEmpty failed.");
        Throws(() => NotNullOrEmpty("", "oops"), "NotNullOrEmpty failed.", "oops");
        Throws(() => IsNullOrEmpty(filled), "NullOrEmpty failed.");
        Throws(() => IsNullOrEmpty(filled, "oops"), "NullOrEmpty failed.", "filled", "oops");
        Throws(() => NullOrEmpty(filled), "NullOrEmpty failed.");
        Throws(() => NullOrEmpty(filled, "oops"), "NullOrEmpty failed.", "filled", "oops");
    }

    [TestMethod]
    public void AssertCore_NullOrWhiteSpace_Overloads()
    {
        const string text = "x";

        IsNotNullOrWhiteSpace("x");
        IsNotNullOrWhiteSpace("x", "oops");
        NotNullOrWhiteSpace("x");
        NotNullOrWhiteSpace("x", "oops");
        IsNullOrWhiteSpace(" ");
        IsNullOrWhiteSpace(" ", "oops");
        NullOrWhiteSpace("\t");
        NullOrWhiteSpace("\t", "oops");

        Throws(() => IsNotNullOrWhiteSpace(" "), "NotNullOrWhiteSpace failed.");
        Throws(() => IsNotNullOrWhiteSpace(" ", "oops"), "NotNullOrWhiteSpace failed.", "oops");
        Throws(() => NotNullOrWhiteSpace(" "), "NotNullOrWhiteSpace failed.");
        Throws(() => NotNullOrWhiteSpace(" ", "oops"), "NotNullOrWhiteSpace failed.", "oops");
        Throws(() => IsNullOrWhiteSpace(text), "NullOrWhiteSpace failed.");
        Throws(() => IsNullOrWhiteSpace(text, "oops"), "NullOrWhiteSpace failed.", "text", "oops");
        Throws(() => NullOrWhiteSpace(text), "NullOrWhiteSpace failed.");
        Throws(() => NullOrWhiteSpace(text, "oops"), "NullOrWhiteSpace failed.", "text", "oops");
    }

    [TestMethod]
    public void AssertCore_Misc_Methods()
    {
        IsTrue(true);
        IsTrue(true, "oops");
        IsFalse(false);
        IsFalse(false, "oops");
        Contains("needle", "haystack NEEDLE hay");
        Throws(() => Fail(), " failed.");
        Throws(() => Fail("x"), " failed.", "x");

        Throws(() => IsTrue(false), "IsTrue failed.");
        Throws(() => IsTrue(false, "oops"), "IsTrue failed.", "oops");
        Throws(() => IsFalse(true), "IsFalse failed.");
        Throws(() => IsFalse(true, "oops"), "IsFalse failed.", "oops");
        Throws(() => Contains("needle", "haystack"), "does not contain");
    }

    [TestMethod]
    public void AssertCore_NoNullRet_And_NullRet_Methods()
    {
        string nullText = null!;

        NoNullRet(1);
        NoNullRet(1, "oops");
        NoNullRet(1, 1);
        NoNullRet(1, 1, "oops");
        NoNullRet("a", "a");
        NoNullRet("a", "a", "oops");
        NullRet(1, (int?)1);
        NullRet(1, (int?)1, "oops");

        Throws(() => NoNullRet(nullText), "NotNull failed.");
        Throws(() => NoNullRet("a", nullText), "NotNull failed.");
        Throws(() => NullRet(1, (int?)2), "AreEqual failed.");
        Throws(() => NullRet(1, 1), "IsType failed.");

        // These don't exist yet.
        //Throws(() => NoNullRet(nullText, "oops"), "NotNull failed.", "oops");
        //Throws(() => NoNullRet("a", nullText, "oops"), "NotNull failed.", "oops");
        //Throws(() => NullRet(1, (int?)2, "oops"), "AreEqual failed.", "oops");
        //Throws(() => NullRet(1, 1, "oops"), "IsType failed.", "oops");
    }

    [TestMethod]
    public void AssertCore_Throws_Methods()
    {
        Action throwingAction = () => throw new InvalidOperationException("boom");
        Func<object?> throwingFunc = () => throw new InvalidOperationException("boom");

        Throws(throwingAction, "boom");
        Throws(throwingFunc, "boom");
        Throws(throwingAction, typeof(InvalidOperationException), "boom");
        Throws(throwingFunc, typeof(InvalidOperationException), "boom");
        Throws<InvalidOperationException>(throwingAction, "boom");
        Throws<InvalidOperationException>(throwingFunc, "boom");
    }

    [TestMethod]
    public void AssertCore_ThrowsException_Methods()
    {
        Func<object?> throwInvalidOperation = () => throw new InvalidOperationException();
        Func<object?> throwInvalidOperationWithMessage = () => throw new InvalidOperationException("boom");

        ThrowsException(throwInvalidOperation);
        ThrowsException(throwInvalidOperationWithMessage, "boom");
        ThrowsException(throwInvalidOperation, typeof(InvalidOperationException));
        ThrowsException(throwInvalidOperationWithMessage, typeof(InvalidOperationException), "boom");
        ThrowsException<InvalidOperationException>(throwInvalidOperation);
        ThrowsException<InvalidOperationException>(throwInvalidOperationWithMessage, "boom");
    }

    [TestMethod]
    public void AssertCore_ThrowsOnOtherThread_Methods()
    {
        Action throwingAction = () => throw new InvalidOperationException();
        Func<object?> throwingFunc = () => throw new InvalidOperationException();

        ThrowsExceptionOnOtherThread(throwingFunc);
        ThrowsOnOtherThread(throwingAction);
        ThrowsOnOtherThread(throwingFunc);
    }

    [TestMethod]
    public void AssertCore_Type_Methods()
    {
        IsType (typeof(int?), (int?)1);
        IsType (typeof(int?), (int?)1, "oops");
        NotType(typeof(int), (int?)1);
        NotType(typeof(int), (int?)1, "oops");
        NotType(typeof(string), typeof(int));
        NotType(typeof(string), typeof(int), "oops");

        Throws(() => IsType(typeof(int), (int?)1), "IsType failed.");
        Throws(() => IsType(typeof(int), (int?)1, "oops"), "IsType failed.", "oops");
        Throws(() => NotType(typeof(int?), (int?)1), "NotType failed.");
        Throws(() => NotType(typeof(int?), (int?)1, "oops"), "NotType failed.", "oops");
        Throws(() => NotType(typeof(int), typeof(int)), "NotType failed.");
        Throws(() => NotType(typeof(int), typeof(int), "oops"), "NotType failed.", "oops");
    }
}
