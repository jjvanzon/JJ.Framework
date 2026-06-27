namespace JJ.Framework.Mathematics.Legacy.Tests;

[TestClass]
public class RandomizerLegacyTests
{
    private const int REPEATS = 1000;
 
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


}
