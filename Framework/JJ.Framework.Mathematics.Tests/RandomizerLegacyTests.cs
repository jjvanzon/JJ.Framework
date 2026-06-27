#pragma warning disable IDE0034
namespace JJ.Framework.Mathematics.Legacy.Tests;

[TestClass]
public class RandomizerLegacyTests
{
    private const int REPEATS = 1000;
 
    // Int32

    [TestMethod]
    public void Test_RandomizerLegacy_GetInt32()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetInt32();
            IsTrue(val <= int.MaxValue - 1);
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_GetInt32_WithMax()
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
    public void Test_RandomizerLegacy_GetInt32_WithMinAndMax()
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
    public void Test_RandomizerLegacy_GetDouble()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            double val = RandomizerLegacy.GetDouble();
            IsTrue(val >= 0);
            IsTrue(val < 1);
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_GetDouble_WithMax()
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
    public void Test_RandomizerLegacy_GetDouble_WithMinAndMax()
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
    public void Test_RandomizerLegacy_GetSingle()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            float val = RandomizerLegacy.GetSingle();
            IsTrue(val >= 0);
            IsTrue(val < 1);
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_GetSingle_WithMax()
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
    public void Test_RandomizerLegacy_GetSingle_WithMinAndMax()
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

    // GetRandomItem

    [TestMethod]
    public void Test_RandomizerLegacy_GetRandomItem_FromValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_GetRandomItem_FromOneValue()
    {
        int[] items = [ 42 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetRandomItem(items);
            AreEqual(42, val);
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_GetRandomItem_EmptyValueColl_Throws()
    {
        int[] items = [ ];
        Throws(() => RandomizerLegacy.GetRandomItem(items));
    }

    [TestMethod]
    public void Test_RandomizerLegacy_GetRandomItem_AllowsNullItems_JustNotEmptyColl()
    {
        int?[] items = [ 1, null, 2 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    // TODO: Cover nullable values, texts and reference types separately.

    // TryGetRandomItem (with Values)

    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_FromMultipleValues()
    {
        int[] items = [ 1, 2, 3, 4, 5 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
    
    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_JustOneValue()
    {
        int[] items = [ 3 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.TryGetRandomItem(items);
            AreEqual(3, val);
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_FromNoValues_ReturnsDefault()
    {
        int[] items = [ ];
        // One might expect null, but it is 0.
        // Inconsistent with text types or reference types.
        int val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(0, val);
    }
    
    // TryGetRandomItem (Nullables)

    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_FromNullables()
    {
        int?[] items = [ 1, null, 2 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_JustOneNullable()
    {
        int?[] items = [ 1, null, 2 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int? val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_EmptyNullableCollection_ReturnsNull()
    {
        int?[] items = [ ];
        int? val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // TryGetRandomItem (from Text)

    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_FromMultipleTexts()
    {
        string[] items = [ "one", "two", "three", "four", "five" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = RandomizerLegacy.TryGetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_JustOneText()
    {
        string[] items = [ "one" ];

        for (int i = 0; i < REPEATS; i++)
        {
            string val = RandomizerLegacy.TryGetRandomItem(items);
            AreEqual("one", val);
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_TryGetRandomItem_FromNoTexts_ReturnsNull()
    {
        string[] items = [];
        string? val = RandomizerLegacy.TryGetRandomItem(items);
        AreEqual(null, val);
    }

    // TODO: From Ref Type (non-string)
    // TODO: Test support for some different collection types.
}
