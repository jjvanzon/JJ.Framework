namespace JJ.Framework.Mathematics.Legacy.Tests;

using static RandomizerLegacy;

[TestClass]
public class RandomizerLegacyTests_TryGetRandomItem
{
    private const int REPEATS = 1000;

    // Values

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneValue()
    {
        int[] items = [ 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = TryGetRandomItem(items);
            AreEqual(3, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NoValues_ReturnsDefault()
    {
        int[] items = [ ];
        // One might expect null, but it is 0.
        // Inconsistent with text types or reference types.
        int val = TryGetRandomItem(items);
        AreEqual(0, val);
    }
    
    // Nullables

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNullableFilledValues_Allowed()
    {
        int?[] items = [ 1, 2, 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_AllowsNullValues()
    {
        int?[] items = [ 1, null, 2 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNull()
    {
        int?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = TryGetRandomItem(items);
            AreEqual(null, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNulllyFilled()
    {
        int?[] items = [ 1 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = TryGetRandomItem(items);
            AreEqual(1, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_Nullables_None_ReturnsNull()
    {
        int?[] items = [ ];
        int? val = TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // Text

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromTexts()
    {
        string[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneText()
    {
        string[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = TryGetRandomItem(items);
            AreEqual("one", val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNoTexts_ReturnsNull()
    {
        string[] items = [];
        string? val = TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // Nullable Text

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNullableTexts()
    {
        string?[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_AllowsNullText()
    {
        string?[] items = [ "one", null, "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNullText()
    {
        string?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = TryGetRandomItem(items);
            AreEqual(null, val);
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNullyFilledText()
    {
        string?[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string? val = TryGetRandomItem(items);
            AreEqual("one", val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NullableTexts_None_ReturnsNull()
    {
        string?[] items = [];
        string? val = TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // TODO: Cover other (nullable) reference type
}