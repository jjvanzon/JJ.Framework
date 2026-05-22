using static JJ.Framework.Testing.Core.Tests.Mocks;

namespace JJ.Framework.Testing.Core.Tests;

internal static class Mocks
{
    public const  string?          NullText     = null;
    public const  string           Empty        = "";
    public const  string           Filled       = "x";
    public const  string           WhiteSpace   = " ";
    public const  string           Tab          = "\t";
    public static readonly object? Obj          = new();
    public static readonly object? NoObj        = null;
}

[TestClass]
public class AssertCore_Equals_Tests
{
    private static readonly CultureInfo _wxpectedCulture = InvariantCulture;
    private static readonly CultureInfo _sameCulture     = _wxpectedCulture;
    private static readonly CultureInfo _actualCulture   = new("nl-NL");
    private static readonly object      _expectedObject  = _wxpectedCulture;
    private static readonly object      _sameObject      = _sameCulture;
    private static readonly object      _actualObject    = _actualCulture;
    private const  string               _expectedText     = "a";
    private const  string               _sameText         = _expectedText;
    private const  string               _actualText       = "b";

    // AreEqual

    [TestMethod]
    public void AssertCore_AreEqual_AsObject()
    {
        AreEqual(_expectedObject, _sameObject);
        AreEqual(_expectedObject, _sameObject, "oops");

        Throws(() => AreEqual(_expectedObject, _actualObject),         "AreEqual failed", "Tested", "ActualObject");
        Throws(() => AreEqual(_expectedObject, _actualObject, "oops"), "AreEqual failed", "Tested", "ActualObject", "oops");
    }

    [TestMethod]
    public void AssertCore_AreEqual_ReferenceType()
    {
        AreEqual(_wxpectedCulture, _sameCulture);
        AreEqual(_wxpectedCulture, _sameCulture, "oops");

        Throws(() => AreEqual(_wxpectedCulture, _actualCulture),         "AreEqual failed", "Tested", "ActualCulture");
        Throws(() => AreEqual(_wxpectedCulture, _actualCulture, "oops"), "AreEqual failed", "Tested", "ActualCulture", "oops");
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

        Throws(() => NotEqual   (_expectedObject, _sameObject),         "NotEqual failed", "SameObject");
        Throws(() => AreNotEqual(_expectedObject, _sameObject),         "NotEqual failed", "SameObject");
        Throws(() => NotEqual   (_expectedObject, _sameObject, "oops"), "NotEqual failed", "SameObject", "oops");
        Throws(() => AreNotEqual(_expectedObject, _sameObject, "oops"), "NotEqual failed", "SameObject", "oops");
    }

    [TestMethod]
    public void AssertCore_NotEqual_ReferenceType()
    {
        NotEqual   (_wxpectedCulture, _actualCulture);
        AreNotEqual(_wxpectedCulture, _actualCulture);
        NotEqual   (_wxpectedCulture, _actualCulture, "oops");
        AreNotEqual(_wxpectedCulture, _actualCulture, "oops");

        Throws(() => NotEqual   (_wxpectedCulture, _sameCulture),         "NotEqual failed", "SameCulture");
        Throws(() => AreNotEqual(_wxpectedCulture, _sameCulture),         "NotEqual failed", "SameCulture");
        Throws(() => NotEqual   (_wxpectedCulture, _sameCulture, "oops"), "NotEqual failed", "SameCulture", "oops");
        Throws(() => AreNotEqual(_wxpectedCulture, _sameCulture, "oops"), "NotEqual failed", "SameCulture", "oops");
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
        NotEqual   ("a", "b");
        AreNotEqual("a", "b");
        NotEqual   ("a", "b", "oops");
        AreNotEqual("a", "b", "oops");

        Throws(() => NotEqual   ("a", _sameText),         "NotEqual failed", "SameText");
        Throws(() => AreNotEqual("a", _sameText),         "NotEqual failed", "SameText");
        Throws(() => NotEqual   ("a", _sameText, "oops"), "NotEqual failed", "SameText", "oops");
        Throws(() => AreNotEqual("a", _sameText, "oops"), "NotEqual failed", "SameText", "oops");
    }

    // Same

    [TestMethod]
    public void AssertCore_AreSame_AsObject()
    {
        AreSame(_expectedObject, _sameObject);
        AreSame(_expectedObject, _sameObject, "oops");

        Throws(() => AreSame(_expectedObject, _actualObject),         "AreSame failed", "ActualObject");
        Throws(() => AreSame(_expectedObject, _actualObject, "oops"), "AreSame failed", "ActualObject", "oops");
    }

    [TestMethod]
    public void AssertCore_AreSame_ReferenceType()
    {
        AreSame(_wxpectedCulture, _sameCulture);
        AreSame(_wxpectedCulture, _sameCulture, "oops");

        Throws(() => AreSame(_wxpectedCulture, _actualCulture),         "AreSame failed", "ActualCulture");
        Throws(() => AreSame(_wxpectedCulture, _actualCulture, "oops"), "AreSame failed", "ActualCulture", "oops");
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

        Throws(() =>    NotSame(_expectedObject, _sameObject),         "NotSame failed", "SameObject");
        Throws(() => AreNotSame(_expectedObject, _sameObject),         "NotSame failed", "SameObject");
        Throws(() =>    NotSame(_expectedObject, _sameObject, "oops"), "NotSame failed", "SameObject", "oops");
        Throws(() => AreNotSame(_expectedObject, _sameObject, "oops"), "NotSame failed", "SameObject", "oops");
    }

    [TestMethod]
    public void AssertCore_NotSame_ReferenceType()
    {
           NotSame(_wxpectedCulture, _actualCulture);
        AreNotSame(_wxpectedCulture, _actualCulture);
           NotSame(_wxpectedCulture, _actualCulture, "oops");
        AreNotSame(_wxpectedCulture, _actualCulture, "oops");

        Throws(() =>    NotSame(_wxpectedCulture, _sameCulture),         "NotSame failed", "SameCulture");
        Throws(() => AreNotSame(_wxpectedCulture, _sameCulture),         "NotSame failed", "SameCulture");
        Throws(() =>    NotSame(_wxpectedCulture, _sameCulture, "oops"), "NotSame failed", "SameCulture", "oops");
        Throws(() => AreNotSame(_wxpectedCulture, _sameCulture, "oops"), "NotSame failed", "SameCulture", "oops");
    }

    [TestMethod]
    public void AssertCore_NotSame_String()
    {
           NotSame(_expectedText, _actualText);
        AreNotSame(_expectedText, _actualText);
           NotSame(_expectedText, _actualText, "oops");
        AreNotSame(_expectedText, _actualText, "oops");

        Throws(() =>    NotSame(_expectedText, _sameText),         "NotSame failed", "SameText");
        Throws(() => AreNotSame(_expectedText, _sameText),         "NotSame failed", "SameText");
        Throws(() =>    NotSame(_expectedText, _sameText, "oops"), "NotSame failed", "SameText", "oops");
        Throws(() => AreNotSame(_expectedText, _sameText, "oops"), "NotSame failed", "SameText", "oops");
    }
}

[TestClass]
public class AssertCore_Existence_Tests
{
    // Null

    [TestMethod]
    public void AssertCore_Null()
    {
        IsNull(NoObj);
        IsNull(NoObj, "oops");
        Throws(() => IsNull(Obj),         "IsNull failed", "Obj");
        Throws(() => IsNull(Obj, "oops"), "IsNull failed", "Obj", "oops");
    }

    // NotNull

    [TestMethod]
    public void AssertCore_NotNull()
    {
          NotNull(Obj);
        IsNotNull(Obj);
          NotNull(Obj, "oops");
        IsNotNull(Obj, "oops");

        Throws(() =>   NotNull(NoObj),         "NotNull failed", "NoObj");
        Throws(() => IsNotNull(NoObj),         "NotNull failed", "NoObj");
        Throws(() =>   NotNull(NoObj, "oops"), "NotNull failed", "NoObj", "oops");
        Throws(() => IsNotNull(NoObj, "oops"), "NotNull failed", "NoObj", "oops");
    }

    // NullOrEmpty

    [TestMethod]
    public void AssertCore_NotNullOrEmpty()
    {
          NotNullOrEmpty("x");
        IsNotNullOrEmpty("x");
          NotNullOrEmpty("x", "oops");
        IsNotNullOrEmpty("x", "oops");

        Throws(() =>   NotNullOrEmpty(Empty),            "NotNullOrEmpty failed", "Empty");
        Throws(() => IsNotNullOrEmpty(Empty),            "NotNullOrEmpty failed", "Empty");
        Throws(() =>   NotNullOrEmpty(NullText),         "NotNullOrEmpty failed", "NullText");
        Throws(() => IsNotNullOrEmpty(NullText),         "NotNullOrEmpty failed", "NullText");
        Throws(() =>   NotNullOrEmpty(Empty,    "oops"), "NotNullOrEmpty failed", "Empty", "oops");
        Throws(() => IsNotNullOrEmpty(Empty,    "oops"), "NotNullOrEmpty failed", "Empty", "oops");
        Throws(() =>   NotNullOrEmpty(NullText, "oops"), "NotNullOrEmpty failed", "NullText", "oops");
        Throws(() => IsNotNullOrEmpty(NullText, "oops"), "NotNullOrEmpty failed", "NullText", "oops");
    }

    [TestMethod]
    public void AssertCore_NullOrEmpty()
    {
          NullOrEmpty(Empty);
        IsNullOrEmpty(Empty);
          NullOrEmpty(NullText);
        IsNullOrEmpty(NullText);
          NullOrEmpty(Empty, "oops");
        IsNullOrEmpty(Empty, "oops");
          NullOrEmpty(NullText, "oops");
        IsNullOrEmpty(NullText, "oops");

        Throws(() =>   NullOrEmpty(Filled),         "NullOrEmpty failed", "Filled");
        Throws(() => IsNullOrEmpty(Filled),         "NullOrEmpty failed", "Filled");
        Throws(() =>   NullOrEmpty(Filled, "oops"), "NullOrEmpty failed", "Filled", "oops");
        Throws(() => IsNullOrEmpty(Filled, "oops"), "NullOrEmpty failed", "Filled", "oops");
    }

    // NullOrWhiteSpace

    [TestMethod]
    public void AssertCore_NotNullOrWhiteSpace()
    {
          NotNullOrWhiteSpace("x");
        IsNotNullOrWhiteSpace("x");
          NotNullOrWhiteSpace("x", "oops");
        IsNotNullOrWhiteSpace("x", "oops");

        Throws(() =>   NotNullOrWhiteSpace(WhiteSpace),         "NotNullOrWhiteSpace failed", "Whitespace");
        Throws(() => IsNotNullOrWhiteSpace(WhiteSpace),         "NotNullOrWhiteSpace failed", "Whitespace");
        Throws(() =>   NotNullOrWhiteSpace(Empty),              "NotNullOrWhiteSpace failed", "Empty");
        Throws(() => IsNotNullOrWhiteSpace(Empty),              "NotNullOrWhiteSpace failed", "Empty");
        Throws(() =>   NotNullOrWhiteSpace(Tab),                "NotNullOrWhiteSpace failed", "Tab");
        Throws(() => IsNotNullOrWhiteSpace(Tab),                "NotNullOrWhiteSpace failed", "Tab");
        Throws(() =>   NotNullOrWhiteSpace(NullText),           "NotNullOrWhiteSpace failed", "NullText");
        Throws(() => IsNotNullOrWhiteSpace(NullText),           "NotNullOrWhiteSpace failed", "NullText");
        Throws(() =>   NotNullOrWhiteSpace(WhiteSpace, "oops"), "NotNullOrWhiteSpace failed", "Whitespace", "oops");
        Throws(() => IsNotNullOrWhiteSpace(WhiteSpace, "oops"), "NotNullOrWhiteSpace failed", "Whitespace", "oops");
        Throws(() =>   NotNullOrWhiteSpace(Empty,      "oops"), "NotNullOrWhiteSpace failed", "Empty",      "oops");
        Throws(() => IsNotNullOrWhiteSpace(Empty,      "oops"), "NotNullOrWhiteSpace failed", "Empty",      "oops");
        Throws(() =>   NotNullOrWhiteSpace(Tab,        "oops"), "NotNullOrWhiteSpace failed", "Tab",        "oops");
        Throws(() => IsNotNullOrWhiteSpace(Tab,        "oops"), "NotNullOrWhiteSpace failed", "Tab",        "oops");
        Throws(() =>   NotNullOrWhiteSpace(NullText,   "oops"), "NotNullOrWhiteSpace failed", "NullText",       "oops");
        Throws(() => IsNotNullOrWhiteSpace(NullText,   "oops"), "NotNullOrWhiteSpace failed", "NullText",       "oops");
    }

    [TestMethod]
    public void AssertCore_NullOrWhiteSpace()
    {
          NullOrWhiteSpace(WhiteSpace);
        IsNullOrWhiteSpace(WhiteSpace);
          NullOrWhiteSpace(Empty);
        IsNullOrWhiteSpace(Empty);
          NullOrWhiteSpace(Tab);
        IsNullOrWhiteSpace(Tab);
          NullOrWhiteSpace(NullText);
        IsNullOrWhiteSpace(NullText);
          NullOrWhiteSpace(WhiteSpace, "oops");
        IsNullOrWhiteSpace(WhiteSpace, "oops");
          NullOrWhiteSpace(Empty, "oops");
        IsNullOrWhiteSpace(Empty, "oops");
          NullOrWhiteSpace(Tab, "oops");
        IsNullOrWhiteSpace(Tab, "oops");
          NullOrWhiteSpace(NullText, "oops");
        IsNullOrWhiteSpace(NullText, "oops");

        Throws(() =>   NullOrWhiteSpace(Filled),         "NullOrWhiteSpace failed", "Filled");
        Throws(() => IsNullOrWhiteSpace(Filled),         "NullOrWhiteSpace failed", "Filled");
        Throws(() =>   NullOrWhiteSpace(Filled, "oops"), "NullOrWhiteSpace failed", "Filled", "oops");
        Throws(() => IsNullOrWhiteSpace(Filled, "oops"), "NullOrWhiteSpace failed", "Filled", "oops");
    }

    // Contains

    [TestMethod]
    public void AssertCore_Contains() => Contains("needle", "haystack needle hay");
    
    [TestMethod]
    public void AssertCore_Contains_IgnoresCase() => Contains("needle", "haystack NEEDLE hay");

    [TestMethod]
    public void AssertCore_Contains_AssertsError() => Throws(() => Contains("needle", "haystack"), "does not contain");

    // NoNullRet

    [TestMethod]
    public void AssertCore_NoNullRet()
    {
        int nonNullInt = 1;

        NoNullRet(1);
        NoNullRet(1, "oops");
        NoNullRet(1, 1);
        NoNullRet(1, 1, "oops");
        NoNullRet("a", "a");
        NoNullRet("a", "a", "oops");

        // When `!` is removed, compiler complains = NoNullRet
        Throws(() => NoNullRet(NullText!             ), "NotNull failed", "NullText");
        Throws(() => NoNullRet("a", NullText!        ), "NotNull failed", "NullText");
        Throws(() => NoNullRet("a", NullText!, "oops"), "NotNull failed", "NullText", "oops");
        Throws(() => NoNullRet("a", "b"              ), "AreEqual failed", "a", "b");
        Throws(() => NoNullRet("a", "b",       "oops"), "AreEqual failed", "a", "b", "oops");
    }

    [TestMethod]
    public void AssertCore_NullRet()
    {
        int? wrong = 2;
        // ReSharper disable once ConvertToConstant.Local
        int nonNullable = 1;

        // TODO: This doesn't check all types (ref, text) just vals.
        NullRet(1, (int?)1);
        NullRet(1, (int?)1, "oops");

        Throws(() => NullRet(1, wrong              ), "AreEqual failed", "wrong"              );
        Throws(() => NullRet(1, nonNullable        ), "IsType failed",   "nonNullable"        );
        Throws(() => NullRet(1, wrong,       "oops"), "AreEqual failed", "wrong",       "oops");
        Throws(() => NullRet(1, nonNullable, "oops"), "IsType failed",   "nonNullable", "oops");
    }
}

[TestClass]
public class AssertCore_Truth_Tests
{
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
        Throws(() => Fail(      ), "failed");
        Throws(() => Fail("oops"), "failed", "oops");
    }
}

[TestClass]
public class AssertCore_Throw_Tests
{
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
    }

    [TestMethod]
    public void AssertCore_Throws_DidNotThrow()
    {
        const string expectedMsgPart = "An exception should have"; // been throws/occurred.
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

    [TestMethod]
    public void AssertCore_Throws_WrongExceptionType()
    {
        const string expectedMsgPart = "AreEqual failed";

        Throws(() => Throws         <NullReferenceException>(ThrowingAction), expectedMsgPart);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc  ), expectedMsgPart);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc  ), expectedMsgPart);
        Throws(() => Throws         <NullReferenceException>(ThrowingAction, "boom"), expectedMsgPart);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc  , "boom"), expectedMsgPart);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc  , "boom"), expectedMsgPart);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException)), expectedMsgPart);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException)), expectedMsgPart);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException)), expectedMsgPart);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException), "boom"), expectedMsgPart);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException), "boom"), expectedMsgPart);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException), "boom"), expectedMsgPart);
    }

    [TestMethod]
    public void AssertCore_Throws_WrongMessage()
    {
        string[] msgParts = [ "boom", "murp" ];

        Throws(() => Throws         (ThrowingAction, "murp"), msgParts);
        Throws(() => Throws         (ThrowingFunc,   "murp"), msgParts);
        Throws(() => ThrowsException(ThrowingFunc,   "murp"), msgParts);
        Throws(() => Throws         <InvalidOperationException>(ThrowingAction, "murp"), msgParts);
        Throws(() => Throws         <InvalidOperationException>(ThrowingFunc,   "murp"), msgParts);
        Throws(() => ThrowsException<InvalidOperationException>(ThrowingFunc,   "murp"), msgParts);
        Throws(() => Throws         (ThrowingAction, typeof(InvalidOperationException), "murp"), msgParts);
        Throws(() => Throws         (ThrowingFunc,   typeof(InvalidOperationException), "murp"), msgParts);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(InvalidOperationException), "murp"), msgParts);
    }

    [TestMethod]
    public void AssertCore_Throws_WrongExceptionType_And_WrongMessage()
    {
        const string expectedMsgPart = "AreEqual failed";

        Throws(() => Throws         <NullReferenceException>(ThrowingAction, "murp"), expectedMsgPart);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc,   "murp"), expectedMsgPart);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc,   "murp"), expectedMsgPart);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException), "murp"), expectedMsgPart);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException), "murp"), expectedMsgPart);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException), "murp"), expectedMsgPart);
    }

    [TestMethod]
    public void AssertCore_ThrowsOnOtherThread()
    {
        ThrowsOnOtherThread         (ThrowingAction);
        ThrowsOnOtherThread         (ThrowingFunc);
        ThrowsExceptionOnOtherThread(ThrowingFunc);
    }

    [TestMethod]
    public void AssertCore_ThrowsOnOtherThread_DidNotThrow()
    {
        const string expectedMsgPart = "An exception should have";

        Throws(() => ThrowsOnOtherThread         (() => { }), expectedMsgPart);
        Throws(() => ThrowsOnOtherThread         (() => ""), expectedMsgPart);
        Throws(() => ThrowsExceptionOnOtherThread(() => ""), expectedMsgPart);
    }

    private void ThrowingAction() => throw new InvalidOperationException("boom");
    private object ThrowingFunc() => throw new InvalidOperationException("boom");
}

[TestClass]
public class AssertCore_Type_Tests
{
    private static readonly int? _nullableOne = 1;
    private static readonly Type _intType      = typeof(int);
    private static readonly Type _stringType   = typeof(string);

    // Type

    [TestMethod]
    public void AssertCore_IsType_WithValue()
    {
        IsType(typeof(int?), _nullableOne);
        IsType(typeof(int?), _nullableOne, "oops");

        Throws(() => IsType(typeof(int), _nullableOne),         "IsType failed", "NullableOne");
        Throws(() => IsType(typeof(int), _nullableOne, "oops"), "IsType failed", "NullableOne", "oops");
    }

    [TestMethod]
    public void AssertCore_IsType_TwoTypes()
    {
        IsType(typeof(int?), _nullableOne);
        IsType(typeof(int?), _nullableOne, "oops");

        Throws(() => IsType(typeof(int), _stringType),         "IsType failed", "StringType");
        Throws(() => IsType(typeof(int), _stringType, "oops"), "IsType failed", "StringType", "oops");
    }

    // NotType

    [TestMethod]
    public void AssertCore_NotType_WithValue()
    {
        NotType(typeof(int), _nullableOne);
        NotType(typeof(int), _nullableOne, "oops");

        Throws(() => NotType(typeof(int?), _nullableOne),         "NotType failed", "NullableOne");
        Throws(() => NotType(typeof(int?), _nullableOne, "oops"), "NotType failed", "NullableOne", "oops");
    }

    [TestMethod]
    public void AssertCore_NotType_WithTwoTypes()
    {
        NotType(typeof(string), _intType);
        NotType(typeof(string), _intType, "oops");

        Throws(() => NotType(typeof(int), _intType),         "NotType failed", "IntType");
        Throws(() => NotType(typeof(int), _intType, "oops"), "NotType failed", "IntType", "oops");
    }
}
