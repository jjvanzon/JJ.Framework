
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
    private const  string               _expectedText    = "a";
    private const  string               _sameText        = _expectedText;
    private const  string               _actualText      = "b";
    private static readonly object?     _obj             = new();
    private static readonly object?     _noObj           = null;
    private static readonly int?        _nullableOne     = 1;
    private static readonly Type        _intType         = typeof(int);
    private static readonly Type        _stringType      = typeof(string);

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
    public void AssertCore_NotEqual_AsObject()
    {
        NotEqual   (_expectedObject, _actualObject);
        AreNotEqual(_expectedObject, _actualObject);
        NotEqual   (_expectedObject, _actualObject, "oops");
        AreNotEqual(_expectedObject, _actualObject, "oops");

        Throws(() => NotEqual   (_expectedObject, _sameObject),         "NotEqual failed", "sameObject");
        Throws(() => AreNotEqual(_expectedObject, _sameObject),         "NotEqual failed", "sameObject");
        Throws(() => NotEqual   (_expectedObject, _sameObject, "oops"), "NotEqual failed", "sameObject", "oops");
        Throws(() => AreNotEqual(_expectedObject, _sameObject, "oops"), "NotEqual failed", "sameObject", "oops");
    }

    [TestMethod]
    public void AssertCore_NotEqual_ReferenceType()
    {
        NotEqual   (_expectedCulture, _actualCulture);
        AreNotEqual(_expectedCulture, _actualCulture);
        NotEqual   (_expectedCulture, _actualCulture, "oops");
        AreNotEqual(_expectedCulture, _actualCulture, "oops");

        Throws(() => NotEqual   (_expectedCulture, _sameCulture),         "NotEqual failed", "sameCulture");
        Throws(() => AreNotEqual(_expectedCulture, _sameCulture),         "NotEqual failed", "sameCulture");
        Throws(() => NotEqual   (_expectedCulture, _sameCulture, "oops"), "NotEqual failed", "sameCulture", "oops");
        Throws(() => AreNotEqual(_expectedCulture, _sameCulture, "oops"), "NotEqual failed", "sameCulture", "oops");
    }

    [TestMethod]
    public void AssertCore_NotEqual_ValueType()
    {
        const int same = 1;

        NotEqual   (1, 2);
        AreNotEqual(1, 2);
        NotEqual   (1, 2, "oops");
        AreNotEqual(1, 2, "oops");

        Throws(() => NotEqual   (1, same),         "NotEqual failed", "same");
        Throws(() => AreNotEqual(1, same),         "NotEqual failed", "same");
        Throws(() => NotEqual   (1, same, "oops"), "NotEqual failed", "same", "oops");
        Throws(() => AreNotEqual(1, same, "oops"), "NotEqual failed", "same", "oops");
    }

    [TestMethod]
    public void AssertCore_NotEqual_String()
    {
        const string same = "a";

        NotEqual   ("a", "b");
        AreNotEqual("a", "b");
        NotEqual   ("a", "b", "oops");
        AreNotEqual("a", "b", "oops");

        Throws(() => NotEqual   ("a", same),         "NotEqual failed", "same");
        Throws(() => AreNotEqual("a", same),         "NotEqual failed", "same");
        Throws(() => NotEqual   ("a", same, "oops"), "NotEqual failed", "same", "oops");
        Throws(() => AreNotEqual("a", same, "oops"), "NotEqual failed", "same", "oops");
    }

    // Same

    [TestMethod]
    public void AssertCore_AreSame_AsObject()
    {
        AreSame(_expectedObject, _sameObject);
        AreSame(_expectedObject, _sameObject, "oops");

        Throws(() => AreSame(_expectedObject, _actualObject),         "AreSame failed", "actualObject");
        Throws(() => AreSame(_expectedObject, _actualObject, "oops"), "AreSame failed", "actualObject", "oops");
    }

    [TestMethod]
    public void AssertCore_AreSame_ReferenceType()
    {
        AreSame(_expectedCulture, _sameCulture);
        AreSame(_expectedCulture, _sameCulture, "oops");

        Throws(() => AreSame(_expectedCulture, _actualCulture),         "AreSame failed", "actualCulture");
        Throws(() => AreSame(_expectedCulture, _actualCulture, "oops"), "AreSame failed", "actualCulture", "oops");
    }

    [TestMethod]
    public void AssertCore_AreSame_String()
    {
        AreSame(_expectedText, _sameText);
        AreSame(_expectedText, _sameText, "oops");

        Throws(() => AreSame(_expectedText, _actualText),         "AreSame failed", "actualText");
        Throws(() => AreSame(_expectedText, _actualText, "oops"), "AreSame failed", "actualText", "oops");
    }

    // NotSame

    [TestMethod]
    public void AssertCore_NotSame_AsObject()
    {
           NotSame(_expectedObject, _actualObject);
        AreNotSame(_expectedObject, _actualObject);
           NotSame(_expectedObject, _actualObject, "oops");
        AreNotSame(_expectedObject, _actualObject, "oops");

        Throws(() =>    NotSame(_expectedObject, _sameObject),         "NotSame failed", "sameObject");
        Throws(() => AreNotSame(_expectedObject, _sameObject),         "NotSame failed", "sameObject");
        Throws(() =>    NotSame(_expectedObject, _sameObject, "oops"), "NotSame failed", "sameObject", "oops");
        Throws(() => AreNotSame(_expectedObject, _sameObject, "oops"), "NotSame failed", "sameObject", "oops");
    }

    [TestMethod]
    public void AssertCore_NotSame_ReferenceType()
    {
           NotSame(_expectedCulture, _actualCulture);
        AreNotSame(_expectedCulture, _actualCulture);
           NotSame(_expectedCulture, _actualCulture, "oops");
        AreNotSame(_expectedCulture, _actualCulture, "oops");

        Throws(() =>    NotSame(_expectedCulture, _sameCulture),         "NotSame failed", "sameCulture");
        Throws(() => AreNotSame(_expectedCulture, _sameCulture),         "NotSame failed", "sameCulture");
        Throws(() =>    NotSame(_expectedCulture, _sameCulture, "oops"), "NotSame failed", "sameCulture", "oops");
        Throws(() => AreNotSame(_expectedCulture, _sameCulture, "oops"), "NotSame failed", "sameCulture", "oops");
    }

    [TestMethod]
    public void AssertCore_NotSame_String()
    {
           NotSame(_expectedText, _actualText);
        AreNotSame(_expectedText, _actualText);
           NotSame(_expectedText, _actualText, "oops");
        AreNotSame(_expectedText, _actualText, "oops");

        Throws(() =>    NotSame(_expectedText, _sameText),         "NotSame failed", "sameText");
        Throws(() => AreNotSame(_expectedText, _sameText),         "NotSame failed", "sameText");
        Throws(() =>    NotSame(_expectedText, _sameText, "oops"), "NotSame failed", "sameText", "oops");
        Throws(() => AreNotSame(_expectedText, _sameText, "oops"), "NotSame failed", "sameText", "oops");
    }

    // Null

    [TestMethod]
    public void AssertCore_Null()
    {
        IsNull(_noObj);
        IsNull(_noObj, "oops");
        Throws(() => IsNull(_obj),         "IsNull failed", "obj");
        Throws(() => IsNull(_obj, "oops"), "IsNull failed", "obj", "oops");
    }

    // NotNull

    [TestMethod]
    public void AssertCore_NotNull()
    {
          NotNull(_obj);
        IsNotNull(_obj);
          NotNull(_obj, "oops");
        IsNotNull(_obj, "oops");

        Throws(() =>   NotNull(_noObj),         "NotNull failed", "noObj");
        Throws(() => IsNotNull(_noObj),         "NotNull failed", "noObj");
        Throws(() =>   NotNull(_noObj, "oops"), "NotNull failed", "noObj", "oops");
        Throws(() => IsNotNull(_noObj, "oops"), "NotNull failed", "noObj", "oops");
    }

    // NullOrEmpty

    [TestMethod]
    public void AssertCore_NotNullOrEmpty()
    {
        const string empty = "";
        string? noText = null;

          NotNullOrEmpty("x");
        IsNotNullOrEmpty("x");
          NotNullOrEmpty("x", "oops");
        IsNotNullOrEmpty("x", "oops");

        Throws(() =>   NotNullOrEmpty(empty),          "NotNullOrEmpty failed", "empty");
        Throws(() => IsNotNullOrEmpty(empty),          "NotNullOrEmpty failed", "empty");
        Throws(() =>   NotNullOrEmpty(noText),         "NotNullOrEmpty failed", "noText");
        Throws(() => IsNotNullOrEmpty(noText),         "NotNullOrEmpty failed", "noText");
        Throws(() =>   NotNullOrEmpty(empty,  "oops"), "NotNullOrEmpty failed", "empty", "oops");
        Throws(() => IsNotNullOrEmpty(empty,  "oops"), "NotNullOrEmpty failed", "empty", "oops");
        Throws(() =>   NotNullOrEmpty(noText, "oops"), "NotNullOrEmpty failed", "noText", "oops");
        Throws(() => IsNotNullOrEmpty(noText, "oops"), "NotNullOrEmpty failed", "noText", "oops");
    }

    [TestMethod]
    public void AssertCore_NullOrEmpty()
    {
        const string filled = "x";
        const string empty = "";
        string? noText = null;

          NullOrEmpty(empty);
        IsNullOrEmpty(empty);
          NullOrEmpty(noText);
        IsNullOrEmpty(noText);
          NullOrEmpty(empty,  "oops");
        IsNullOrEmpty(empty,  "oops");
          NullOrEmpty(noText, "oops");
        IsNullOrEmpty(noText, "oops");

        Throws(() =>   NullOrEmpty(filled),         "NullOrEmpty failed", "filled");
        Throws(() => IsNullOrEmpty(filled),         "NullOrEmpty failed", "filled");
        Throws(() =>   NullOrEmpty(filled, "oops"), "NullOrEmpty failed", "filled", "oops");
        Throws(() => IsNullOrEmpty(filled, "oops"), "NullOrEmpty failed", "filled", "oops");
    }

    // NullOrWhiteSpace

    [TestMethod]
    public void AssertCore_NotNullOrWhiteSpace()
    {
        const string whitespace = " ";
        const string empty = "";
        const string tab = "\t";
        string? noText = null;

          NotNullOrWhiteSpace("x");
        IsNotNullOrWhiteSpace("x");
          NotNullOrWhiteSpace("x", "oops");
        IsNotNullOrWhiteSpace("x", "oops");

        Throws(() =>   NotNullOrWhiteSpace(whitespace),         "NotNullOrWhiteSpace failed", "whitespace");
        Throws(() => IsNotNullOrWhiteSpace(whitespace),         "NotNullOrWhiteSpace failed", "whitespace");
        Throws(() =>   NotNullOrWhiteSpace(empty),              "NotNullOrWhiteSpace failed", "empty");
        Throws(() => IsNotNullOrWhiteSpace(empty),              "NotNullOrWhiteSpace failed", "empty");
        Throws(() =>   NotNullOrWhiteSpace(tab),                "NotNullOrWhiteSpace failed", "tab");
        Throws(() => IsNotNullOrWhiteSpace(tab),                "NotNullOrWhiteSpace failed", "tab");
        Throws(() =>   NotNullOrWhiteSpace(noText),             "NotNullOrWhiteSpace failed", "noText");
        Throws(() => IsNotNullOrWhiteSpace(noText),             "NotNullOrWhiteSpace failed", "noText");
        Throws(() =>   NotNullOrWhiteSpace(whitespace, "oops"), "NotNullOrWhiteSpace failed", "whitespace", "oops");
        Throws(() => IsNotNullOrWhiteSpace(whitespace, "oops"), "NotNullOrWhiteSpace failed", "whitespace", "oops");
        Throws(() =>   NotNullOrWhiteSpace(empty,      "oops"), "NotNullOrWhiteSpace failed", "empty",      "oops");
        Throws(() => IsNotNullOrWhiteSpace(empty,      "oops"), "NotNullOrWhiteSpace failed", "empty",      "oops");
        Throws(() =>   NotNullOrWhiteSpace(tab,        "oops"), "NotNullOrWhiteSpace failed", "tab",        "oops");
        Throws(() => IsNotNullOrWhiteSpace(tab,        "oops"), "NotNullOrWhiteSpace failed", "tab",        "oops");
        Throws(() =>   NotNullOrWhiteSpace(noText,     "oops"), "NotNullOrWhiteSpace failed", "noText",     "oops");
        Throws(() => IsNotNullOrWhiteSpace(noText,     "oops"), "NotNullOrWhiteSpace failed", "noText",     "oops");
    }

    [TestMethod]
    public void AssertCore_NullOrWhiteSpace()
    {
        const string text = "x";
        const string empty = "";
        const string whitespace = " ";
        const string tab = "\t";
        string? noText = null;

          NullOrWhiteSpace(whitespace);
        IsNullOrWhiteSpace(whitespace);
          NullOrWhiteSpace(empty);
        IsNullOrWhiteSpace(empty);
          NullOrWhiteSpace(tab);
        IsNullOrWhiteSpace(tab);
          NullOrWhiteSpace(noText);
        IsNullOrWhiteSpace(noText);
          NullOrWhiteSpace(whitespace, "oops");
        IsNullOrWhiteSpace(whitespace, "oops");
          NullOrWhiteSpace(empty, "oops");
        IsNullOrWhiteSpace(empty, "oops");
          NullOrWhiteSpace(tab, "oops");
        IsNullOrWhiteSpace(tab, "oops");
          NullOrWhiteSpace(noText, "oops");
        IsNullOrWhiteSpace(noText, "oops");

        Throws(() =>   NullOrWhiteSpace(text),         "NullOrWhiteSpace failed", "text");
        Throws(() => IsNullOrWhiteSpace(text),         "NullOrWhiteSpace failed", "text");
        Throws(() =>   NullOrWhiteSpace(text, "oops"), "NullOrWhiteSpace failed", "text", "oops");
        Throws(() => IsNullOrWhiteSpace(text, "oops"), "NullOrWhiteSpace failed", "text", "oops");
    }

    // True

    [TestMethod]
    public void AssertCore_IsTrue()
    {
        IsTrue(true);
        IsTrue(true, "oops");

        Throws(() => IsTrue(false),         "IsTrue failed", "false");
        Throws(() => IsTrue(false, "oops"), "IsTrue failed", "false", "oops");
    }

    // False

    [TestMethod]
    public void AssertCore_IsFalse()
    {
        IsFalse(false);
        IsFalse(false, "oops");

        Throws(() => IsFalse(true),         "IsFalse failed", "true");
        Throws(() => IsFalse(true, "oops"), "IsFalse failed", "true", "oops");
    }

    // Fail

    [TestMethod]
    public void AssertCore_Fail()
    {
        Throws(() => Fail(), " failed");
        Throws(() => Fail("x"), " failed", "x");
    }

    // Contains

    [TestMethod]
    public void AssertCore_Contains()
    {
        Contains("needle", "haystack NEEDLE hay");
        Throws(() => Contains("needle", "haystack"), "does not contain");
    }

    // NoNullRet

    [TestMethod]
    public void AssertCore_NoNullRet()
    {
        string nullText = null!;

        NoNullRet(1);
        NoNullRet(1, "oops");
        NoNullRet(1, 1);
        NoNullRet(1, 1, "oops");
        NoNullRet("a", "a");
        NoNullRet("a", "a", "oops");

        Throws(() => NoNullRet(nullText),      "NotNull failed", "nullText");
        Throws(() => NoNullRet("a", nullText), "NotNull failed", "nullText");
    }

    [TestMethod]
    public void AssertCore_NullRet()
    {
        int? wrong = 2;
        const int nonNullable = 1;

        NullRet(1, (int?)1);
        NullRet(1, (int?)1, "oops");

        Throws(() => NullRet(1, wrong),       "AreEqual failed", "wrong");
        Throws(() => NullRet(1, nonNullable), "IsType failed", "nonNullable");

        // These don't exist yet. Overloads clashed.
        //Throws(() => NoNullRet(nullText, "oops"), "NotNull failed", "oops");
        //Throws(() => NoNullRet("a", nullText, "oops"), "NotNull failed", "oops");
        //Throws(() => NullRet(1, (int?)2, "oops"), "AreEqual failed", "oops");
        //Throws(() => NullRet(1, 1, "oops"), "IsType failed", "oops");
    }

    // Throws

    [TestMethod]
    public void AssertCore_Throws()
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


        Throws(() => Throws(() => { }), "An exception should have occurred.");
    }

    [TestMethod]
    public void AssertCore_Throws_DidNotThrow()
    {
        const string expectedMsgPart = "An exception should have"; // been throws/occurred.
        // Throws-ception needed to test the "didn't throw" case.
        Throws(() => Throws         (() => { }        ), expectedMsgPart);
        Throws(() => Throws         (() => ""         ), expectedMsgPart);
        Throws(() => ThrowsException(() => ""         ), expectedMsgPart);
        Throws(() => Throws         (() => { }, "murp"), expectedMsgPart);
        Throws(() => Throws         (() => "",  "murp"), expectedMsgPart);
        Throws(() => ThrowsException(() => "",  "murp"), expectedMsgPart);
        Throws(() => Throws         <InvalidOperationException>(() => { }        ), expectedMsgPart);
        Throws(() => Throws         <InvalidOperationException>(() => ""         ), expectedMsgPart);
        Throws(() => ThrowsException<InvalidOperationException>(() => ""         ), expectedMsgPart);
        Throws(() => Throws         <InvalidOperationException>(() => { }, "murp"), expectedMsgPart);
        Throws(() => Throws         <InvalidOperationException>(() => "",  "murp"), expectedMsgPart);
        Throws(() => ThrowsException<InvalidOperationException>(() => "",  "murp"), expectedMsgPart);
        Throws(() => Throws         (() => { }, typeof(InvalidOperationException)        ), expectedMsgPart);
        Throws(() => Throws         (() => "",  typeof(InvalidOperationException)        ), expectedMsgPart);
        Throws(() => ThrowsException(() => "",  typeof(InvalidOperationException)        ), expectedMsgPart);
        Throws(() => Throws         (() => { }, typeof(InvalidOperationException), "murp"), expectedMsgPart);
        Throws(() => Throws         (() => "",  typeof(InvalidOperationException), "murp"), expectedMsgPart);
        Throws(() => ThrowsException(() => "",  typeof(InvalidOperationException), "murp"), expectedMsgPart);
    }

    // TODO: Wrong exception type case.
    // TODO: Wrong message case.
    // TODO: Wrong exception type and wrong message case.

    [TestMethod]
    public void AssertCore_ThrowsOnOtherThread()
    {
        ThrowsOnOtherThread         (ThrowingAction);
        ThrowsOnOtherThread         (ThrowingFunc);
        ThrowsExceptionOnOtherThread(ThrowingFunc);
    }

    // TODO: DidNotThrow variants etc. for ThrowsOnOtherThread variants.

    private void ThrowingAction() => throw new InvalidOperationException("boom");
    private object ThrowingFunc() => throw new InvalidOperationException("boom");

    // Type

    [TestMethod]
    public void AssertCore_IsType_WithValue()
    {
        IsType(typeof(int?), _nullableOne);
        IsType(typeof(int?), _nullableOne, "oops");

        Throws(() => IsType(typeof(int), _nullableOne),         "IsType failed", "_nullableOne");
        Throws(() => IsType(typeof(int), _nullableOne, "oops"), "IsType failed", "_nullableOne", "oops");
    }

    [TestMethod]
    public void AssertCore_IsType_TwoTypes()
    {
        IsType(typeof(int?), _nullableOne);
        IsType(typeof(int?), _nullableOne, "oops");

        Throws(() => IsType(typeof(int), _stringType),         "IsType failed", "_stringType");
        Throws(() => IsType(typeof(int), _stringType, "oops"), "IsType failed", "_stringType", "oops");
    }

    // NotType

    [TestMethod]
    public void AssertCore_NotType_WithValue()
    {
        NotType(typeof(int), _nullableOne);
        NotType(typeof(int), _nullableOne, "oops");

        Throws(() => NotType(typeof(int?), _nullableOne),         "NotType failed", "nullableOne");
        Throws(() => NotType(typeof(int?), _nullableOne, "oops"), "NotType failed", "nullableOne", "oops");
    }

    [TestMethod]
    public void AssertCore_NotType_WithTwoTypes()
    {
        NotType(typeof(string), _intType);
        NotType(typeof(string), _intType, "oops");

        Throws(() => NotType(typeof(int), _intType),         "NotType failed", "_intType");
        Throws(() => NotType(typeof(int), _intType, "oops"), "NotType failed", "_intType", "oops");
    }
}
