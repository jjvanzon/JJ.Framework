#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE0002 // Redundant qualifier

namespace JJ.Framework.Mathematics.Tests;

using static Randomizer;

[TestClass]
public class Randomizer_CoreTests
{
    private const int REPEATS = 1000;

    // GetInt32

    [TestMethod]
    public void GetInt32_WithoutParameters_ReturnsValueInFullRangeExceptMaxValue()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            int val = Randomizer.GetInt32();
            IsTrue(val <= int.MaxValue - 1);
        }
    }

    [TestMethod]
    public void GetInt32_WithMax_ReturnsValueInRangeIncludingMax()
    {
        const int max = 10;

        for (int i = 0; i < REPEATS; i++)
        {
            int val = Randomizer.GetInt32(max);
            IsTrue(val >= 0);
            IsTrue(val <= max);
        }
    }

    [TestMethod]
    public void GetInt32_WithMinAndMax_ReturnsValueInInclusiveRange()
    {
        const int min = -5;
        const int max = 5;

        for (int i = 0; i < REPEATS; i++)
        {
            int val = Randomizer.GetInt32(min, max);
            IsTrue(val >= min);
            IsTrue(val <= max);
        }
    }

    [TestMethod]
    public void GetInt32_WithInt32MaxValueMinus1_Succeeds()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            Randomizer.GetInt32(0, int.MaxValue - 1);
        }
    }

    [TestMethod]
    public void GetInt32_WithInt32MaxValue_ThrowsOverflowException()
    {
        Throws<OverflowException>(() => Randomizer.GetInt32(0, int.MaxValue));
    }

    // GetRandomItem

    [TestMethod]
    public void GetRandomItem_WithEmptyCollection_ThrowsException()
    {
        int[] items = [];
        Throws(() => GetRandomItem(items));
    }

    [TestMethod]
    public void GetRandomItem_WithSingleItem_ReturnsThatItem()
    {
        int[] items = [ 123 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = GetRandomItem(items);
            AreEqual(123, val);
        }
    }

    [TestMethod]
    public void GetRandomItem_WithMultipleItems_ReturnsItemFromCollection()
    {
        int[] items = [ 10, 20, 30, 40 ];

        for (int i = 0; i < REPEATS; i++)
        {
            int val = GetRandomItem(items);
            IsTrue(items.Contains(val));
        }
    }
}
