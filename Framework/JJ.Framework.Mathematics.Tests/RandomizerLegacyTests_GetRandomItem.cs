namespace JJ.Framework.Mathematics.Legacy.Tests;

[TestClass]
public class RandomizerLegacyTests_GetRandomItem
{
    private const int REPEATS = 1000;

    // TODO: Only differentiate between get and tryget where behavior is different, not where it is synonymous?

    // RandomItem (Values)

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneValue()
    {
        int[] items = [ 42 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetRandomItem(items);
            AreEqual(42, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNoValues_NotAllowed()
    {
        int[] items = [ ];
        Throws(() => RandomizerLegacy.GetRandomItem(items));
    }

    // GetRandomItem (Nullables)

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNullyFilledValues()
    {
        int?[] items = [ 1, 2, 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_AllowsNullValues()
    {
        int?[] items = [ 1, null, 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNulllyFilled()
    {
        int?[] items = [ 1 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.GetRandomItem(items);
            AreEqual(1, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNull()
    {
        int?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.GetRandomItem(items);
            AreEqual(null, val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_NullablesNone_NotAllowed()
    {
        int?[] items = [ ];
        Throws(() => RandomizerLegacy.GetRandomItem(items));
    }

    // GetRandomItem (Text)

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromMultipleTexts()
    {
        string[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneText()
    {
        string[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = RandomizerLegacy.GetRandomItem(items);
            AreEqual("one", val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNoTexts_Throws()
    {
        string[] items = [];
        Throws(() => RandomizerLegacy.GetRandomItem(items));
    }

    // GetRandomItem (Nullable Text)

    [TestMethod]
    public void Test_Legacy_GetRandomItem_FromNullableTexts()
    {
        string?[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_WithANullText()
    {
        string?[] items = [ "one", null, "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNullableText()
    {
        string?[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = RandomizerLegacy.GetRandomItem(items);
            AreEqual("one", val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_GetRandomItem_JustOneNullText()
    {
        string?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = RandomizerLegacy.GetRandomItem(items);
            AreEqual(null, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetRandomItem_NullyTextsNone_Throws()
    {
        string?[] items = [];
        Throws(() => RandomizerLegacy.GetRandomItem(items));
    }

    // TODO: Cover (nullable?) reference types separately.
}