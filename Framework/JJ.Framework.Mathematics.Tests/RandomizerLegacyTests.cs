#pragma warning disable IDE0034

namespace JJ.Framework.Mathematics.Legacy.Tests;

using static RandomizerLegacy;

[TestClass]
public class RandomizerLegacyTests
{
    private const int REPEATS = 100;

    // Int

    [TestMethod]
    public void Test_Legacy_GetInt32()
    {
        for (int i = 0; i < REPEATS; i++)
        {
            int val = GetInt32();
            IsTrue(val <= int.MaxValue - 1);
        }
    }

    [TestMethod]
    public void Test_Legacy_GetInt32_WithMax()
    {
        const int max = 10;

        for (int i = 0; i < REPEATS; i++)
        {
            int val = GetInt32(max);
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
            int val = GetInt32(min, max);
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
            double val = GetDouble();
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
            double val = GetDouble(max);
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
            double val = GetDouble(min, max);
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
            float val = GetSingle();
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
            float val = GetSingle(max);
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
            float val = GetSingle(min, max);
            IsTrue(val >= min);
            IsTrue(val < max);
        }
    }
}