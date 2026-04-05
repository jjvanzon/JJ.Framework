// ReSharper disable CheckNamespace
#pragma warning disable IDE0130 // Namespace != folder

namespace JJ.Framework.Mathematics.Tests;

using static Maths;

[TestClass]
public class Maths_CoreTests
{
    // Pow

    [TestMethod]
    public void Pow_Base3_Exponent4_Returns81()
    {
        AreEqual(81, Pow(3, 4));
    }

    [TestMethod]
    public void Pow_Base10_Exponent3_Returns1000()
    {
        AreEqual(1000, Pow(10, 3));
    }

    [TestMethod]
    public void Pow_Base1_AnyPositiveExponent_Returns1()
    {
        AreEqual(1, Pow(1, 7));
    }

    [TestMethod]
    public void Pow_Base0_PositiveExponent_Returns0()
    {
        AreEqual(0, Pow(0, 5));
    }

    [TestMethod]
    public void Pow_Exponent0_Returns1_Apparently()
    {
        AreEqual(1, Pow(1, 0));
        AreEqual(1, Pow(2, 0));
        AreEqual(1, Pow(3, 0));
        AreEqual(1, Pow(4, 0));
        AreEqual(1, Pow(5, 0));
    }
    
    [TestMethod]
    public void Pow_0ToThe0_Apparently1()
    {
        AreEqual(1, Pow(0, 0));
    }

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
    
    [TestMethod]
    public void Log_Int32MaxValue_Base2_Returns30_Not32_BecauseFlooredAndSign()
    {
        AreEqual(30, Log(int.MaxValue, 2));
    }

    
    [TestMethod]
    public void Log_Base1_Weird()
    {
        //AreEqual(0, Log(1, 1));
    }

    [TestMethod]
    public void Log_OfOne_Returns0()
    {
        AreEqual(0, Log(1, 2));
        AreEqual(0, Log(1, 3));
        AreEqual(0, Log(1, 4));
        AreEqual(0, Log(1, 5));
        AreEqual(0, Log(1, 8));
        AreEqual(0, Log(1, 10));
        AreEqual(0, Log(1, 16));
    }
    
    [TestMethod]
    public void Log_OfZero_Undefined()
    {
        Throws(() => Log(0,  1), "value", "0");
        Throws(() => Log(0,  2), "value", "0");
        Throws(() => Log(0,  3), "value", "0");
        Throws(() => Log(0,  4), "value", "0");
        Throws(() => Log(0,  5), "value", "0");
        Throws(() => Log(0,  8), "value", "0");
        Throws(() => Log(0, 10), "value", "0");
        Throws(() => Log(0, 16), "value", "0");
    }

    [TestMethod]
    public void Log_Base0_Undefined()
    {
        Throws(() => Log( 2, 0), "base", "0");
        Throws(() => Log( 3, 0), "base", "0");
        Throws(() => Log( 4, 0), "base", "0");
        Throws(() => Log( 5, 0), "base", "0");
        Throws(() => Log( 8, 0), "base", "0");
        Throws(() => Log(10, 0), "base", "0");
        Throws(() => Log(16, 0), "base", "0");
    }
}
