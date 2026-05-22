namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertCore_Existence_Tests
{
    // Null

    [TestMethod]
    public void Test_AssertCore_Null()
    {
        IsNull(NoObj);
        IsNull(NoObj, "oops");
        Throws(() => IsNull(Obj),         "IsNull failed", "Obj");
        Throws(() => IsNull(Obj, "oops"), "IsNull failed", "Obj", "oops");
    }

    // NotNull

    [TestMethod]
    public void Test_AssertCore_NotNull()
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
    public void Test_AssertCore_NotNullOrEmpty()
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
    public void Test_AssertCore_NullOrEmpty()
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
    public void Test_AssertCore_NotNullOrWhiteSpace()
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
    public void Test_AssertCore_NullOrWhiteSpace()
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
    public void Test_AssertCore_Contains() => Contains("needle", "haystack needle hay");
    
    [TestMethod]
    public void Test_AssertCore_Contains_IgnoresCase() => Contains("needle", "haystack NEEDLE hay");

    [TestMethod]
    public void Test_AssertCore_Contains_AssertsError() => Throws(() => Contains("needle", "haystack"), "does not contain");

    // NoNullRet

    [TestMethod]
    public void Test_AssertCore_NoNullRet()
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
    public void Test_AssertCore_NullRet()
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