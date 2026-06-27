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
    public void Test_RandomizerLegacy_GetRandomItem()
    {
        var items = new[] { 1, 2, 3, 4, 5 };

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }

    [TestMethod]
    public void Test_RandomizerLegacy_GetRandomItem_EmptyCollection()
    {
        var items = new int[] { };
        Throws(() => RandomizerLegacy.GetRandomItem(items));
    }

    [TestMethod]
    public void Test_RandomizerLegacy_GetRandomItem_SingleItem()
    {
        var items = new[] { 42 };

        for (int i = 0; i < REPEATS; i++)
        {
            int val = RandomizerLegacy.GetRandomItem(items);
            AreEqual(42, val);
        }
    }
    }
}
