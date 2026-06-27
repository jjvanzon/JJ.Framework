#pragma warning disable IDE0034
namespace JJ.Framework.Mathematics.Legacy.Tests;

[TestClass]
public class RandomizerLegacyTests
{
    private const int REPEATS = 1000;

    // Int

    [TestMethod]
    public void Test_Legacy_GetInt32()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetInt32();
            IsTrue(val <= int.MaxValue - 1);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetInt32_WithMax()
    {
        const int max = 10;

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetInt32(max);
            IsTrue(val >= 0);
            IsTrue(val <= max);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetInt32_WithMinAndMax()
    {
        const int min = -5;
        const int max = 5;

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetInt32(min, max);
            IsTrue(val >= min);
            IsTrue(val <= max);
        }
    }

    // Double

    [TestMethod]
    public void Test_Legacy_GetDouble()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            double val = RandomizerLegacy.GetDouble();
            IsTrue(val >= 0);
            IsTrue(val < 1);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetDouble_WithMax()
    {
        const double max = 10.5;

        for (int i = 0; i < REPEATS; i++)
        {
            double val = RandomizerLegacy.GetDouble(max);
            IsTrue(val >= 0);
            IsTrue(val < max);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetDouble_WithMinAndMax()
    {
        const double min = -5.5;
        const double max = 5.5;

        for (int i = 0; i < REPEATS; i++)
        {
            double val = RandomizerLegacy.GetDouble(min, max);
            IsTrue(val >= min);
            IsTrue(val < max);
        }
    }

    // Single

    [TestMethod]
    public void Test_Legacy_GetSingle()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            float val = RandomizerLegacy.GetSingle();
            IsTrue(val >= 0);
            IsTrue(val < 1);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetSingle_WithMax()
    {
        const float max = 10.5f;

        for (int i = 0; i < REPEATS; i++)
        {
            float val = RandomizerLegacy.GetSingle(max);
            IsTrue(val >= 0);
            IsTrue(val < max);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetSingle_WithMinAndMax()
    {
        const float min = -5.5f;
        const float max = 5.5f;

        for (int i = 0; i < REPEATS; i++)
        {
            float val = RandomizerLegacy.GetSingle(min, max);
            IsTrue(val >= min);
            IsTrue(val < max);
        }
    }

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

    // TryGetRandomItem (Values)

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromMultipleValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneValue()
    {
        int[] items = [ 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.TryGetRandomItem(items);
            AreEqual(3, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNoValues_ReturnsDefault()
    {
        int[] items = [ ];
        // One might expect null, but it is 0.
        // Inconsistent with text types or reference types.
        int val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(0, val);
    }
    
    // TryGetRandomItem (Nullables)

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNullables()
    {
        int?[] items = [ 1, null, 2 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneNullable()
    {
        int?[] items = [ null ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.TryGetRandomItem(items);
            AreEqual(null, val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_NullablesNone_ReturnsNull()
    {
        int?[] items = [ ];
        int? val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // TryGetRandomItem (Text)

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromMultipleTexts()
    {
        string[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_JustOneText()
    {
        string[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = RandomizerLegacy.TryGetRandomItem(items);
            AreEqual("one", val);
        }
    }

    [TestMethod]
    public void Test_Legacy_TryGetRandomItem_FromNoTexts_ReturnsNull()
    {
        string[] items = [];
        string? val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // TODO: From Ref Type (non-string): one set with nullable syntax, one without.
    // TODO: Test support for some different collection types.
    // TODO: Test params works everywhere it's declared.
    // TODO: Test null coll not allowed.
    // TODO: Try should probably be reworked and not return 0 and allow more nulls (e.g. null coll) for developer sanity.
    // TODO: (No)NullRet checks.
    // TODO: Split over multiple files.
}
