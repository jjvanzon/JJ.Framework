// ReSharper disable CheckNamespace
#pragma warning disable IDE0130 // Namespace != folder

namespace JJ.Framework.Mathematics.Tests;

using static Maths;

[TestClass]
public class Maths_CoreTests
{
    // Log

    [TestMethod]
    public void Log_ValueSmallerThanBase_Returns0()
    {
        AreEqual(0, Log(9, 10));
    }

    [TestMethod]
    public void Log_ValueEqualToBase_Returns1()
    {
        AreEqual(1, Log(10, 10));
    }

    [TestMethod]
    public void Log_ExactPower_ReturnsPower()
    {
        AreEqual(3, Log(1000, 10));
    }

    [TestMethod]
    public void Log_NonExactPower_ReturnsFlooredResult()
    {
        AreEqual(2, Log(999, 10));
    }

    [TestMethod]
    public void Log_Base2_ExactPower_ReturnsPower()
    {
        AreEqual(10, Log(1024, 2));
    }

    [TestMethod]
    public void Log_Base2_NonExactPower_ReturnsFlooredResult()
    {
        AreEqual(9, Log(1023, 2));
    }

    [TestMethod]
    public void Log_Base3_ExactPower_ReturnsPower()
    {
        AreEqual(4, Log(81, 3));
    }

    [TestMethod]
    public void Log_Base3_NonExactPower_ReturnsFlooredResult()
    {
        AreEqual(3, Log(80, 3));
    }

    [TestMethod]
    public void Log_Base16_ExactPower_ReturnsPower()
    {
        AreEqual(3, Log(4096, 16));
    }
}
