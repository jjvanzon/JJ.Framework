
namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertCoreTests
{
    private static readonly CultureInfo _expectedCulture = InvariantCulture;
    private static readonly CultureInfo _sameCulture     = _expectedCulture;
    private static readonly CultureInfo _actualCulture   = new("nl-NL");
    private static readonly object      _expectedObject  = _expectedCulture;
    private static readonly object      _sameObject      = _sameCulture;
    private static readonly object      _actualObject    = _actualCulture;

    // AreEqual

    [TestMethod]
    public void AssertCore_AreEqual_AsObject()
    {
        AreEqual(_expectedObject, _sameObject);
        AreEqual(_expectedObject, _sameObject, "oops");

        Throws(() => AreEqual(_expectedObject, _actualObject),         "AreEqual failed", "Tested", "actualObject");
        Throws(() => AreEqual(_expectedObject, _actualObject, "oops"), "AreEqual failed", "Tested", "actualObject", "oops");
    }

    [TestMethod]
    public void AssertCore_AreEqual_ReferenceType()
    {
        AreEqual(_expectedCulture, _sameCulture);
        AreEqual(_expectedCulture, _sameCulture, "oops");

        Throws(() => AreEqual(_expectedCulture, _actualCulture),         "AreEqual failed", "Tested", "actualCulture");
        Throws(() => AreEqual(_expectedCulture, _actualCulture, "oops"), "AreEqual failed", "Tested", "actualCulture", "oops");
    }

    [TestMethod]
    public void AssertCore_AreEqual_ValueType()
    {
        AreEqual(1, 1);
        AreEqual(1, 1, "oops");

        Throws(() => AreEqual(1, 2),         "AreEqual failed", "Tested", "2");
        Throws(() => AreEqual(1, 2, "oops"), "AreEqual failed", "Tested", "2", "oops");
    }

    [TestMethod]
    public void AssertCore_AreEqual_String()
    {
        AreEqual("a", "a");
        AreEqual("a", "a", "oops");

        Throws(() => AreEqual("a", "b"),         "AreEqual failed", "Tested", "b");
        Throws(() => AreEqual("a", "b", "oops"), "AreEqual failed", "Tested", "b", "oops");
    }

    // NotEqual

    [TestMethod]
    public void AssertCore_NotEqual_And_AreNotEqual_Overloads()
    {
        const int same = 1;

        NotEqual(_expectedObject, _actualObject);
        NotEqual(_expectedObject, _actualObject, "oops");
        AreNotEqual(_expectedObject, _actualObject);
        AreNotEqual(_expectedObject, _actualObject, "oops");
        NotEqual(1, 2);
        NotEqual(1, 2, "oops");
        AreNotEqual(1, 2);
        AreNotEqual(1, 2, "oops");

        Throws(() => NotEqual(_expectedObject, _expectedObject), "NotEqual failed", "expected");
        Throws(() => NotEqual(1, same, "oops"), "NotEqual failed", "same", "oops");
        Throws(() => AreNotEqual(_expectedObject, _expectedObject), "NotEqual failed", "expected");
        Throws(() => AreNotEqual(1, same, "oops"), "NotEqual failed", "same", "oops");
    }

    // Same

    [TestMethod]
    public void AssertCore_AreSame_NotSame_NotSame_Overloads()
    {
        var x = new object();
        var y = new object();

        AreSame(x, x);
        AreSame(x, x, "oops");

        NotSame(x, y);
        NotSame(x, y, "oops");

        AreNotSame(x, y);
        AreNotSame(x, y, "oops");

        Throws(() => AreSame(x, y), "AreSame failed", "y");
        Throws(() => AreSame(x, y, "oops"), "AreSame failed", "y", "oops");
        Throws(() => NotSame(x, x), "NotSame failed", "x");
        Throws(() => NotSame(x, x, "oops"), "NotSame failed", "x", "oops");
        Throws(() => AreNotSame(x, x), "NotSame failed", "x");
        Throws(() => AreNotSame(x, x, "oops"), "NotSame failed", "x", "oops");
    }

    // Null

    [TestMethod]
    public void AssertCore_Null_Overloads()
    {
        object? obj = new();
        object? noObj = null;

        IsNull(noObj);
        IsNull(noObj, "oops");
        Throws(() => IsNull(obj), "IsNull failed", "obj");
        Throws(() => IsNull(obj, "oops"), "IsNull failed", "obj", "oops");
    }

    // NotNull

    [TestMethod]
    public void AssertCore_NotNull_Overloads()
    {
        object? obj = new();
        object? noObj = null;

        IsNotNull(obj);
        IsNotNull(obj, "oops");
        NotNull(obj);
        NotNull(obj, "oops");

        Throws(() => IsNotNull(noObj), "NotNull failed", "noObj");
        Throws(() => IsNotNull(noObj, "oops"), "NotNull failed", "noObj", "oops");
        Throws(() => NotNull(noObj), "NotNull failed", "noObj");
        Throws(() => NotNull(noObj, "oops"), "NotNull failed", "noObj", "oops");
    }

    // NullOrEmpty

    [TestMethod]
    public void AssertCore_NullOrEmpty_Overloads()
    {
        const string filled = "x";
        const string empty = "";

        IsNotNullOrEmpty("x");
        IsNotNullOrEmpty("x", "oops");
        NotNullOrEmpty("x");
        NotNullOrEmpty("x", "oops");
        
        IsNullOrEmpty("");
        IsNullOrEmpty("", "oops");
        NullOrEmpty("");
        NullOrEmpty("", "oops");

        Throws(() => IsNotNullOrEmpty(empty), "NotNullOrEmpty failed", "empty");
        Throws(() => IsNotNullOrEmpty("", "oops"), "NotNullOrEmpty failed", "oops");
        Throws(() => NotNullOrEmpty(empty), "NotNullOrEmpty failed", "empty");
        Throws(() => NotNullOrEmpty("", "oops"), "NotNullOrEmpty failed", "oops");
        
        Throws(() => IsNullOrEmpty(filled), "NullOrEmpty failed", "filled");
        Throws(() => IsNullOrEmpty(filled, "oops"), "NullOrEmpty failed", "filled", "oops");
        Throws(() => NullOrEmpty(filled), "NullOrEmpty failed", "filled");
        Throws(() => NullOrEmpty(filled, "oops"), "NullOrEmpty failed", "filled", "oops");
    }

    // NullOrWhiteSpace

    [TestMethod]
    public void AssertCore_NullOrWhiteSpace_Overloads()
    {
        const string text = "x";
        const string whitespace = " ";

        IsNotNullOrWhiteSpace("x");
        IsNotNullOrWhiteSpace("x", "oops");
        NotNullOrWhiteSpace("x");
        NotNullOrWhiteSpace("x", "oops");
        IsNullOrWhiteSpace(" ");
        IsNullOrWhiteSpace(" ", "oops");
        NullOrWhiteSpace("\t");
        NullOrWhiteSpace("\t", "oops");

        Throws(() => IsNotNullOrWhiteSpace(whitespace), "NotNullOrWhiteSpace failed", "whitespace");
        Throws(() => IsNotNullOrWhiteSpace(" ", "oops"), "NotNullOrWhiteSpace failed", "oops");
        Throws(() => NotNullOrWhiteSpace(whitespace), "NotNullOrWhiteSpace failed", "whitespace");
        Throws(() => NotNullOrWhiteSpace(" ", "oops"), "NotNullOrWhiteSpace failed", "oops");
        Throws(() => IsNullOrWhiteSpace(text), "NullOrWhiteSpace failed", "text");
        Throws(() => IsNullOrWhiteSpace(text, "oops"), "NullOrWhiteSpace failed", "text", "oops");
        Throws(() => NullOrWhiteSpace(text), "NullOrWhiteSpace failed", "text");
        Throws(() => NullOrWhiteSpace(text, "oops"), "NullOrWhiteSpace failed", "text", "oops");
    }

    // True/False/Contains

    [TestMethod]
    public void AssertCore_Misc_Methods()
    {
        const bool falseValue = false;
        const bool trueValue = true;

        IsTrue(true);
        IsTrue(true, "oops");
        IsFalse(false);
        IsFalse(false, "oops");
        Contains("needle", "haystack NEEDLE hay");
        Throws(() => Fail(), " failed");
        Throws(() => Fail("x"), " failed", "x");

        Throws(() => IsTrue(falseValue), "IsTrue failed", "falseValue");
        Throws(() => IsTrue(false, "oops"), "IsTrue failed", "oops");
        Throws(() => IsFalse(trueValue), "IsFalse failed", "trueValue");
        Throws(() => IsFalse(true, "oops"), "IsFalse failed", "oops");
        Throws(() => Contains("needle", "haystack"), "does not contain");
    }

    // NoNullRet

    [TestMethod]
    public void AssertCore_NoNullRet_And_NullRet_Methods()
    {
        string nullText = null!;
        int? wrong = 2;
        const int nonNullable = 1;

        NoNullRet(1);
        NoNullRet(1, "oops");
        NoNullRet(1, 1);
        NoNullRet(1, 1, "oops");
        NoNullRet("a", "a");
        NoNullRet("a", "a", "oops");
        NullRet(1, (int?)1);
        NullRet(1, (int?)1, "oops");

        Throws(() => NoNullRet(nullText), "NotNull failed", "nullText");
        Throws(() => NoNullRet("a", nullText), "NotNull failed", "nullText");
        Throws(() => NullRet(1, wrong), "AreEqual failed", "wrong");
        Throws(() => NullRet(1, nonNullable), "IsType failed", "nonNullable");

        // These don't exist yet. Overloads clashed.
        //Throws(() => NoNullRet(nullText, "oops"), "NotNull failed", "oops");
        //Throws(() => NoNullRet("a", nullText, "oops"), "NotNull failed", "oops");
        //Throws(() => NullRet(1, (int?)2, "oops"), "AreEqual failed", "oops");
        //Throws(() => NullRet(1, 1, "oops"), "IsType failed", "oops");
    }

    // Throws

    [TestMethod]
    public void AssertCore_Throws_Methods()
    {
        Throws         (ThrowingAction        );
        Throws         (ThrowingFunc          );
        ThrowsException(ThrowingFunc          );
        Throws         (ThrowingAction, "boom");
        Throws         (ThrowingFunc,   "boom");
        ThrowsException(ThrowingFunc,   "boom");
        Throws         <InvalidOperationException>(ThrowingAction        );
        Throws         <InvalidOperationException>(ThrowingFunc          );
        ThrowsException<InvalidOperationException>(ThrowingFunc          );
        Throws         <InvalidOperationException>(ThrowingAction, "boom");
        Throws         <InvalidOperationException>(ThrowingFunc,   "boom");
        ThrowsException<InvalidOperationException>(ThrowingFunc,   "boom");
        Throws         (ThrowingAction, typeof(InvalidOperationException)        );
        Throws         (ThrowingFunc,   typeof(InvalidOperationException)        );
        ThrowsException(ThrowingFunc,   typeof(InvalidOperationException)        );
        Throws         (ThrowingAction, typeof(InvalidOperationException), "boom");
        Throws         (ThrowingFunc,   typeof(InvalidOperationException), "boom");
        ThrowsException(ThrowingFunc,   typeof(InvalidOperationException), "boom");
        
    }

    [TestMethod]
    public void AssertCore_ThrowsOnOtherThread_Methods()
    {
        ThrowsOnOtherThread         (ThrowingAction);
        ThrowsOnOtherThread         (ThrowingFunc);
        ThrowsExceptionOnOtherThread(ThrowingFunc);
    }

    private void ThrowingAction() => throw new InvalidOperationException("boom");
    private object ThrowingFunc() => throw new InvalidOperationException("boom");

    // Type

    [TestMethod]
    public void AssertCore_IsType_Methods()
    {
        int? nullableOne = 1;

        IsType (typeof(int?), (int?)1);
        IsType (typeof(int?), (int?)1, "oops");

        Throws(() => IsType(typeof(int), nullableOne), "IsType failed", "nullableOne");
        Throws(() => IsType(typeof(int), (int?)1, "oops"), "IsType failed", "(int?)1", "oops");
    }

    // NotType

    [TestMethod]
    public void AssertCore_NotType_Methods()
    {
        int? nullableOne = 1;
        var intType = typeof(int);

        NotType(typeof(int), (int?)1);
        NotType(typeof(int), (int?)1, "oops");
        NotType(typeof(string), typeof(int));
        NotType(typeof(string), typeof(int), "oops");

        Throws(() => NotType(typeof(int?), nullableOne), "NotType failed", "nullableOne");
        Throws(() => NotType(typeof(int?), (int?)1, "oops"), "NotType failed", "(int?)1", "oops");
        Throws(() => NotType(typeof(int), intType), "NotType failed", "intType");
        Throws(() => NotType(typeof(int), typeof(int), "oops"), "NotType failed", "typeof(int)", "oops");
    }
}
