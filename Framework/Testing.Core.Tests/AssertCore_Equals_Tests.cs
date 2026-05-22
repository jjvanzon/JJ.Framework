namespace JJ.Framework.Testing.Core.Tests;

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
    public void Test_AssertCore_AreEqual_AsObject()
    {
        AreEqual(_expectedObject, _sameObject);
        AreEqual(_expectedObject, _sameObject, "oops");

        Throws(() => AreEqual(_expectedObject, _actualObject),         "AreEqual failed", "Tested", "ActualObject");
        Throws(() => AreEqual(_expectedObject, _actualObject, "oops"), "AreEqual failed", "Tested", "ActualObject", "oops");
    }

    [TestMethod]
    public void Test_AssertCore_AreEqual_ReferenceType()
    {
        AreEqual(_wxpectedCulture, _sameCulture);
        AreEqual(_wxpectedCulture, _sameCulture, "oops");

        Throws(() => AreEqual(_wxpectedCulture, _actualCulture),         "AreEqual failed", "Tested", "ActualCulture");
        Throws(() => AreEqual(_wxpectedCulture, _actualCulture, "oops"), "AreEqual failed", "Tested", "ActualCulture", "oops");
    }

    [TestMethod]
    public void Test_AssertCore_AreEqual_ValueType()
    {
        AreEqual(1, 1);
        AreEqual(1, 1, "oops");

        Throws(() => AreEqual(1, 2),         "AreEqual failed", "Tested", "2");
        Throws(() => AreEqual(1, 2, "oops"), "AreEqual failed", "Tested", "2", "oops");
    }

    [TestMethod]
    public void Test_AssertCore_AreEqual_String()
    {
        AreEqual("a", "a");
        AreEqual("a", "a", "oops");

        Throws(() => AreEqual("a", "b"),         "AreEqual failed", "Tested", "b");
        Throws(() => AreEqual("a", "b", "oops"), "AreEqual failed", "Tested", "b", "oops");
    }

    // NotEqual

    [TestMethod]
    public void Test_AssertCore_NotEqual_AsObject()
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
    public void Test_AssertCore_NotEqual_ReferenceType()
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
    public void Test_AssertCore_NotEqual_ValueType()
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
    public void Test_AssertCore_NotEqual_String()
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
    public void Test_AssertCore_AreSame_AsObject()
    {
        AreSame(_expectedObject, _sameObject);
        AreSame(_expectedObject, _sameObject, "oops");

        Throws(() => AreSame(_expectedObject, _actualObject),         "AreSame failed", "ActualObject");
        Throws(() => AreSame(_expectedObject, _actualObject, "oops"), "AreSame failed", "ActualObject", "oops");
    }

    [TestMethod]
    public void Test_AssertCore_AreSame_ReferenceType()
    {
        AreSame(_wxpectedCulture, _sameCulture);
        AreSame(_wxpectedCulture, _sameCulture, "oops");

        Throws(() => AreSame(_wxpectedCulture, _actualCulture),         "AreSame failed", "ActualCulture");
        Throws(() => AreSame(_wxpectedCulture, _actualCulture, "oops"), "AreSame failed", "ActualCulture", "oops");
    }

    [TestMethod]
    public void Test_AssertCore_AreSame_String()
    {
        AreSame(_expectedText, _sameText);
        AreSame(_expectedText, _sameText, "oops");

        Throws(() => AreSame(_expectedText, _actualText),         "AreSame failed", "actualText");
        Throws(() => AreSame(_expectedText, _actualText, "oops"), "AreSame failed", "actualText", "oops");
    }

    // NotSame

    [TestMethod]
    public void Test_AssertCore_NotSame_AsObject()
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
    public void Test_AssertCore_NotSame_ReferenceType()
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
    public void Test_AssertCore_NotSame_String()
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