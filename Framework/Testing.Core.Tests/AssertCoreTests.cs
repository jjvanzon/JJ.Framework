using static JJ.Framework.Testing.Core.Tests.Mocks;

namespace JJ.Framework.Testing.Core.Tests;

internal static class Mocks
{
    public static readonly CultureInfo ExpectedCulture = InvariantCulture;
    public static readonly CultureInfo SameCulture     = ExpectedCulture;
    public static readonly CultureInfo ActualCulture   = new("nl-NL");
    public static readonly object      ExpectedObject  = ExpectedCulture;
    public static readonly object      SameObject      = SameCulture;
    public static readonly object      ActualObject    = ActualCulture;
    public const  string               ExpectedText    = "a";
    public const  string               SameText        = ExpectedText;
    public const  string               ActualText      = "b";
    public const  string?              NullText        = null;
    public static readonly object?     Obj             = new();
    public static readonly object?     NoObj           = null;
    public static readonly int?        NullableOne     = 1;
    public static readonly Type        IntType         = typeof(int);
    public static readonly Type        StringType      = typeof(string);
}

[TestClass]
public class AssertCore_Equals_Tests
{
    // AreEqual

    [TestMethod]
    public void AssertCore_AreEqual_AsObject()
    {
        AreEqual(ExpectedObject, SameObject);
        AreEqual(ExpectedObject, SameObject, "oops");

        Throws(() => AreEqual(ExpectedObject, ActualObject),         "AreEqual failed", "Tested", "ActualObject");
        Throws(() => AreEqual(ExpectedObject, ActualObject, "oops"), "AreEqual failed", "Tested", "ActualObject", "oops");
    }

    [TestMethod]
    public void AssertCore_AreEqual_ReferenceType()
    {
        AreEqual(ExpectedCulture, SameCulture);
        AreEqual(ExpectedCulture, SameCulture, "oops");

        Throws(() => AreEqual(ExpectedCulture, ActualCulture),         "AreEqual failed", "Tested", "ActualCulture");
        Throws(() => AreEqual(ExpectedCulture, ActualCulture, "oops"), "AreEqual failed", "Tested", "ActualCulture", "oops");
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
        NotEqual   (ExpectedObject, ActualObject);
        AreNotEqual(ExpectedObject, ActualObject);
        NotEqual   (ExpectedObject, ActualObject, "oops");
        AreNotEqual(ExpectedObject, ActualObject, "oops");

        Throws(() => NotEqual   (ExpectedObject, SameObject),         "NotEqual failed", "SameObject");
        Throws(() => AreNotEqual(ExpectedObject, SameObject),         "NotEqual failed", "SameObject");
        Throws(() => NotEqual   (ExpectedObject, SameObject, "oops"), "NotEqual failed", "SameObject", "oops");
        Throws(() => AreNotEqual(ExpectedObject, SameObject, "oops"), "NotEqual failed", "SameObject", "oops");
    }

    [TestMethod]
    public void AssertCore_NotEqual_ReferenceType()
    {
        NotEqual   (ExpectedCulture, ActualCulture);
        AreNotEqual(ExpectedCulture, ActualCulture);
        NotEqual   (ExpectedCulture, ActualCulture, "oops");
        AreNotEqual(ExpectedCulture, ActualCulture, "oops");

        Throws(() => NotEqual   (ExpectedCulture, SameCulture),         "NotEqual failed", "SameCulture");
        Throws(() => AreNotEqual(ExpectedCulture, SameCulture),         "NotEqual failed", "SameCulture");
        Throws(() => NotEqual   (ExpectedCulture, SameCulture, "oops"), "NotEqual failed", "SameCulture", "oops");
        Throws(() => AreNotEqual(ExpectedCulture, SameCulture, "oops"), "NotEqual failed", "SameCulture", "oops");
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
        AreSame(ExpectedObject, SameObject);
        AreSame(ExpectedObject, SameObject, "oops");

        Throws(() => AreSame(ExpectedObject, ActualObject),         "AreSame failed", "ActualObject");
        Throws(() => AreSame(ExpectedObject, ActualObject, "oops"), "AreSame failed", "ActualObject", "oops");
    }

    [TestMethod]
    public void AssertCore_AreSame_ReferenceType()
    {
        AreSame(ExpectedCulture, SameCulture);
        AreSame(ExpectedCulture, SameCulture, "oops");

        Throws(() => AreSame(ExpectedCulture, ActualCulture),         "AreSame failed", "ActualCulture");
        Throws(() => AreSame(ExpectedCulture, ActualCulture, "oops"), "AreSame failed", "ActualCulture", "oops");
    }

    [TestMethod]
    public void AssertCore_AreSame_String()
    {
        AreSame(ExpectedText, SameText);
        AreSame(ExpectedText, SameText, "oops");

        Throws(() => AreSame(ExpectedText, ActualText),         "AreSame failed", "actualText");
        Throws(() => AreSame(ExpectedText, ActualText, "oops"), "AreSame failed", "actualText", "oops");
    }

    // NotSame

    [TestMethod]
    public void AssertCore_NotSame_AsObject()
    {
           NotSame(ExpectedObject, ActualObject);
        AreNotSame(ExpectedObject, ActualObject);
           NotSame(ExpectedObject, ActualObject, "oops");
        AreNotSame(ExpectedObject, ActualObject, "oops");

        Throws(() =>    NotSame(ExpectedObject, SameObject),         "NotSame failed", "SameObject");
        Throws(() => AreNotSame(ExpectedObject, SameObject),         "NotSame failed", "SameObject");
        Throws(() =>    NotSame(ExpectedObject, SameObject, "oops"), "NotSame failed", "SameObject", "oops");
        Throws(() => AreNotSame(ExpectedObject, SameObject, "oops"), "NotSame failed", "SameObject", "oops");
    }

    [TestMethod]
    public void AssertCore_NotSame_ReferenceType()
    {
           NotSame(ExpectedCulture, ActualCulture);
        AreNotSame(ExpectedCulture, ActualCulture);
           NotSame(ExpectedCulture, ActualCulture, "oops");
        AreNotSame(ExpectedCulture, ActualCulture, "oops");

        Throws(() =>    NotSame(ExpectedCulture, SameCulture),         "NotSame failed", "SameCulture");
        Throws(() => AreNotSame(ExpectedCulture, SameCulture),         "NotSame failed", "SameCulture");
        Throws(() =>    NotSame(ExpectedCulture, SameCulture, "oops"), "NotSame failed", "SameCulture", "oops");
        Throws(() => AreNotSame(ExpectedCulture, SameCulture, "oops"), "NotSame failed", "SameCulture", "oops");
    }

    [TestMethod]
    public void AssertCore_NotSame_String()
    {
           NotSame(ExpectedText, ActualText);
        AreNotSame(ExpectedText, ActualText);
           NotSame(ExpectedText, ActualText, "oops");
        AreNotSame(ExpectedText, ActualText, "oops");

        Throws(() =>    NotSame(ExpectedText, SameText),         "NotSame failed", "SameText");
        Throws(() => AreNotSame(ExpectedText, SameText),         "NotSame failed", "SameText");
        Throws(() =>    NotSame(ExpectedText, SameText, "oops"), "NotSame failed", "SameText", "oops");
        Throws(() => AreNotSame(ExpectedText, SameText, "oops"), "NotSame failed", "SameText", "oops");
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
        const string empty = "";

          NotNullOrEmpty("x");
        IsNotNullOrEmpty("x");
          NotNullOrEmpty("x", "oops");
        IsNotNullOrEmpty("x", "oops");

        Throws(() =>   NotNullOrEmpty(empty),            "NotNullOrEmpty failed", "Empty");
        Throws(() => IsNotNullOrEmpty(empty),            "NotNullOrEmpty failed", "Empty");
        Throws(() =>   NotNullOrEmpty(NullText),         "NotNullOrEmpty failed", "NullText");
        Throws(() => IsNotNullOrEmpty(NullText),         "NotNullOrEmpty failed", "NullText");
        Throws(() =>   NotNullOrEmpty(empty,    "oops"), "NotNullOrEmpty failed", "Empty", "oops");
        Throws(() => IsNotNullOrEmpty(empty,    "oops"), "NotNullOrEmpty failed", "Empty", "oops");
        Throws(() =>   NotNullOrEmpty(NullText, "oops"), "NotNullOrEmpty failed", "NullText", "oops");
        Throws(() => IsNotNullOrEmpty(NullText, "oops"), "NotNullOrEmpty failed", "NullText", "oops");
    }

    [TestMethod]
    public void AssertCore_NullOrEmpty()
    {
        const string filled = "x";
        const string empty = "";

          NullOrEmpty(empty);
        IsNullOrEmpty(empty);
          NullOrEmpty(NullText);
        IsNullOrEmpty(NullText);
          NullOrEmpty(empty,  "oops");
        IsNullOrEmpty(empty,  "oops");
          NullOrEmpty(NullText, "oops");
        IsNullOrEmpty(NullText, "oops");

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
        Throws(() =>   NotNullOrWhiteSpace(NullText),           "NotNullOrWhiteSpace failed", "NullText");
        Throws(() => IsNotNullOrWhiteSpace(NullText),           "NotNullOrWhiteSpace failed", "NullText");
        Throws(() =>   NotNullOrWhiteSpace(whitespace, "oops"), "NotNullOrWhiteSpace failed", "whitespace", "oops");
        Throws(() => IsNotNullOrWhiteSpace(whitespace, "oops"), "NotNullOrWhiteSpace failed", "whitespace", "oops");
        Throws(() =>   NotNullOrWhiteSpace(empty,      "oops"), "NotNullOrWhiteSpace failed", "empty",      "oops");
        Throws(() => IsNotNullOrWhiteSpace(empty,      "oops"), "NotNullOrWhiteSpace failed", "empty",      "oops");
        Throws(() =>   NotNullOrWhiteSpace(tab,        "oops"), "NotNullOrWhiteSpace failed", "tab",        "oops");
        Throws(() => IsNotNullOrWhiteSpace(tab,        "oops"), "NotNullOrWhiteSpace failed", "tab",        "oops");
        Throws(() =>   NotNullOrWhiteSpace(NullText,   "oops"), "NotNullOrWhiteSpace failed", "NullText",     "oops");
        Throws(() => IsNotNullOrWhiteSpace(NullText,   "oops"), "NotNullOrWhiteSpace failed", "NullText",     "oops");
    }

    [TestMethod]
    public void AssertCore_NullOrWhiteSpace()
    {
        const string text = "x";
        const string empty = "";
        const string whitespace = " ";
        const string tab = "\t";
        
          NullOrWhiteSpace(whitespace);
        IsNullOrWhiteSpace(whitespace);
          NullOrWhiteSpace(empty);
        IsNullOrWhiteSpace(empty);
          NullOrWhiteSpace(tab);
        IsNullOrWhiteSpace(tab);
          NullOrWhiteSpace(NullText);
        IsNullOrWhiteSpace(NullText);
          NullOrWhiteSpace(whitespace, "oops");
        IsNullOrWhiteSpace(whitespace, "oops");
          NullOrWhiteSpace(empty, "oops");
        IsNullOrWhiteSpace(empty, "oops");
          NullOrWhiteSpace(tab, "oops");
        IsNullOrWhiteSpace(tab, "oops");
          NullOrWhiteSpace(NullText, "oops");
        IsNullOrWhiteSpace(NullText, "oops");

        Throws(() =>   NullOrWhiteSpace(text),         "NullOrWhiteSpace failed", "text");
        Throws(() => IsNullOrWhiteSpace(text),         "NullOrWhiteSpace failed", "text");
        Throws(() =>   NullOrWhiteSpace(text, "oops"), "NullOrWhiteSpace failed", "text", "oops");
        Throws(() => IsNullOrWhiteSpace(text, "oops"), "NullOrWhiteSpace failed", "text", "oops");
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
public class AssertCoreTests
{
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
        const int nonNullable = 1;
        string? BullText = null;

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
public class AssertCore_Throws_Tests
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
public class AssertCore_Types_Tests
{
    // Type

    [TestMethod]
    public void AssertCore_IsType_WithValue()
    {
        IsType(typeof(int?), NullableOne);
        IsType(typeof(int?), NullableOne, "oops");

        Throws(() => IsType(typeof(int), NullableOne),         "IsType failed", "NullableOne");
        Throws(() => IsType(typeof(int), NullableOne, "oops"), "IsType failed", "NullableOne", "oops");
    }

    [TestMethod]
    public void AssertCore_IsType_TwoTypes()
    {
        IsType(typeof(int?), NullableOne);
        IsType(typeof(int?), NullableOne, "oops");

        Throws(() => IsType(typeof(int), StringType),         "IsType failed", "StringType");
        Throws(() => IsType(typeof(int), StringType, "oops"), "IsType failed", "StringType", "oops");
    }

    // NotType

    [TestMethod]
    public void AssertCore_NotType_WithValue()
    {
        NotType(typeof(int), NullableOne);
        NotType(typeof(int), NullableOne, "oops");

        Throws(() => NotType(typeof(int?), NullableOne),         "NotType failed", "NullableOne");
        Throws(() => NotType(typeof(int?), NullableOne, "oops"), "NotType failed", "NullableOne", "oops");
    }

    [TestMethod]
    public void AssertCore_NotType_WithTwoTypes()
    {
        NotType(typeof(string), IntType);
        NotType(typeof(string), IntType, "oops");

        Throws(() => NotType(typeof(int), IntType),         "NotType failed", "IntType");
        Throws(() => NotType(typeof(int), IntType, "oops"), "NotType failed", "IntType", "oops");
    }
}
