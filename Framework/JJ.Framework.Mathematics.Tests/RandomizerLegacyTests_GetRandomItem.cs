namespace JJ.Framework.Mathematics.Legacy.Tests;

using static RandomizerLegacy;

[TestClass]
public class RandomizerLegacyTests_GetRandomItem
{
    private const int REPEATS = 1000;

    // Values

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneValue()
    {
        int[] items = [ 42 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = GetRandomItem(items);
            AreEqual(42, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_NoValues_NotAllowed()
    {
        int[] items = [ ];
        Throws(() => GetRandomItem(items));
    }

    // Nullables

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNullableFilledValues_Allowed()
    {
        int?[] items = [ 1, 2, 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_AllowsNullValues()
    {
        int?[] items = [ 1, null, 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNull()
    {
        int?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = GetRandomItem(items);
            AreEqual(null, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNulllyFilled()
    {
        int?[] items = [ 1 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = GetRandomItem(items);
            AreEqual(1, val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_Nullables_None_NotAllowed()
    {
        int?[] items = [ ];
        Throws(() => GetRandomItem(items));
    }

    // Text

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromTexts()
    {
        string[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneText()
    {
        string[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = GetRandomItem(items);
            AreEqual("one", val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNoTexts_Throws()
    {
        string[] items = [];
        Throws(() => GetRandomItem(items));
    }

    // Nullable Text

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNullableTexts()
    {
        string?[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_AllowsNullText()
    {
        string?[] items = [ "one", null, "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNullText()
    {
        string?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = GetRandomItem(items);
            AreEqual(null, val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNullyFilledText()
    {
        string?[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = GetRandomItem(items);
            AreEqual("one", val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_NullableTexts_None_Throws()
    {
        string?[] items = [];
        Throws(() => GetRandomItem(items));
    }

    // TODO: Cover other (nullable) reference type
    // TODO: Test support for some different collection types.
    // TODO: Test params works everywhere it's declared.
    // TODO: Test null coll not allowed.
    // TODO: Try should probably be reworked and not return 0 and allow more nulls (e.g. null coll) for developer sanity.
    // TODO: (No)NullRet checks.
    // TODO: Only differentiate between get and tryget where behavior is different, not where it is synonymous?
}