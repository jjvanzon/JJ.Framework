#pragma warning disable IDE0130 // Namespace != folder
// ReSharper disable CheckNamespace

namespace JJ.Framework.Mathematics.Tests;

using static Double;

/// <summary>
/// <c>Maths</c> in the JJ.Framework int-based variant.
/// <c>Math</c> is .NET's own, usually based on doubles.
/// Results between both of them are evaluated and compared for consistency.
/// </summary>
[TestClass]
public class Maths_CoreTests
{
    // Pow

    [TestMethod]
    public void Pow_Base3_Exponent4_Returns81()
    {
        AreEqual(81, Maths.Pow(3, 4));
        AreEqual(81, Math .Pow(3, 4));
    }

    [TestMethod]
    public void Pow_Base10_Exponent3_Returns1000()
    {
        AreEqual(1000, Maths.Pow(10, 3));
        AreEqual(1000, Math .Pow(10, 3));
    }

    [TestMethod]
    public void Pow_Base1_AnyPositiveExponent_Returns1()
    {
        AreEqual(1, Maths.Pow(1, 7));
        AreEqual(1, Math .Pow(1, 7));
    }

    [TestMethod]
    public void Pow_Base0_PositiveExponent_Returns0()
    {
        AreEqual(0, Maths.Pow(0, 5));
        AreEqual(0, Math .Pow(0, 5));
    }

    /// <summary>
    /// Anything to the power of 0 is 1.
    /// </summary>
    [TestMethod]
    public void Pow_Exponent0_Returns1()
    {
        AreEqual(1, Maths.Pow(1, 0));
        AreEqual(1, Math .Pow(1, 0));
        AreEqual(1, Maths.Pow(2, 0));
        AreEqual(1, Math .Pow(2, 0));
        AreEqual(1, Maths.Pow(3, 0));
        AreEqual(1, Math .Pow(3, 0));
        AreEqual(1, Maths.Pow(4, 0));
        AreEqual(1, Math .Pow(4, 0));
        AreEqual(1, Maths.Pow(5, 0));
        AreEqual(1, Math .Pow(5, 0));
    }
    
    /// <summary>
    /// 0 ^ 0 is conventionally 1, though mathematically debatable.
    /// </summary>
    [TestMethod]
    public void Pow_0ToThe0_Apparently1()
    {
        AreEqual(1, Maths.Pow(0, 0));
        AreEqual(1, Math .Pow(0, 0));
    }

    /// <summary>
    /// A negative times a negative is positive, so even powers of negatives are positive.
    /// </summary>
    [TestMethod]
    public void Pow_NegativeBase_EvenExponent_ReturnsPositive()
    {
        AreEqual(4,  Maths.Pow(-2, 2));
        AreEqual(4,  Math .Pow(-2, 2));
        AreEqual(16, Maths.Pow(-2, 4));
        AreEqual(16, Math .Pow(-2, 4));
        AreEqual(9,  Maths.Pow(-3, 2));
        AreEqual(9,  Math .Pow(-3, 2));
        AreEqual(25, Maths.Pow(-5, 2));
        AreEqual(25, Math .Pow(-5, 2));
    }

    /// <summary>
    /// Odd powers of negatives stay negative.
    /// </summary>
    [TestMethod]
    public void Pow_NegativeBase_OddExponent_ReturnsNegative()
    {
        AreEqual(  -8, Maths.Pow(-2, 3));
        AreEqual(  -8, Math .Pow(-2, 3));
        AreEqual( -27, Maths.Pow(-3, 3));
        AreEqual( -27, Math .Pow(-3, 3));
        AreEqual(-125, Maths.Pow(-5, 3));
        AreEqual(-125, Math .Pow(-5, 3));
    }

    /// <summary>
    /// Anything to the power of 0 is 1, even negatives.
    /// </summary>
    [TestMethod]
    public void Pow_NegativeBase_Exponent0_Returns1()
    {
        AreEqual(1, Maths.Pow(-1, 0));
        AreEqual(1, Math .Pow(-1, 0));
        AreEqual(1, Maths.Pow(-2, 0));
        AreEqual(1, Math .Pow(-2, 0));
        AreEqual(1, Maths.Pow(-3, 0));
        AreEqual(1, Math .Pow(-3, 0));
        AreEqual(1, Maths.Pow(-5, 0));
        AreEqual(1, Math .Pow(-5, 0));
        AreEqual(1, Maths.Pow(-10, 0));
        AreEqual(1, Math .Pow(-10, 0));
    }

    /// <summary>
    /// A negative exponent flips to a fraction (e.g. 2 ^ -1 = 1/2).
    /// For integers that rounds down to 0.
    /// </summary>
    [TestMethod]
    public void Pow_NegativeExponent_ReturnsFractionFlooredTo0()
    {
        AreEqual(0,            Maths.Pow( 2, -1));
        AreEqual(0, Math.Floor(Math .Pow( 2, -1)));
        AreEqual(0,            Maths.Pow( 3, -1));
        AreEqual(0, Math.Floor(Math .Pow( 3, -1)));
        AreEqual(0,            Maths.Pow( 5, -2));
        AreEqual(0, Math.Floor(Math .Pow( 5, -2)));
        AreEqual(0,            Maths.Pow(10, -3));
        AreEqual(0, Math.Floor(Math .Pow(10, -3)));
    }

    /// <summary>
    /// 1 * 1 * 1 * ... is always 1, even with a negative exponent.
    /// </summary>
    [TestMethod]
    public void Pow_Base1_NegativeExponent_Returns1()
    {
        AreEqual(1, Maths.Pow(1, -1));
        AreEqual(1, Math .Pow(1, -1));
        AreEqual(1, Maths.Pow(1, -2));
        AreEqual(1, Math .Pow(1, -2));
        AreEqual(1, Maths.Pow(1, -5));
        AreEqual(1, Math .Pow(1, -5));
    }

    /// <summary>
    /// (-1) * (-1) = 1, and that doesn't change with a negative exponent.
    /// </summary>
    [TestMethod]
    public void Pow_BaseNeg1_NegativeEvenExponent_Returns1()
    {
        AreEqual(1, Maths.Pow(-1, -2));
        AreEqual(1, Math .Pow(-1, -2));
        AreEqual(1, Maths.Pow(-1, -4));
        AreEqual(1, Math .Pow(-1, -4));
    }

    /// <summary>
    /// (-1) * (-1) * (-1) = -1, and that doesn't change with a negative exponent.
    /// </summary>
    [TestMethod]
    public void Pow_BaseNeg1_NegativeOddExponent_ReturnsNeg1()
    {
        AreEqual(-1, Maths.Pow(-1, -1));
        AreEqual(-1, Math .Pow(-1, -1));
        AreEqual(-1, Maths.Pow(-1, -3));
        AreEqual(-1, Math .Pow(-1, -3));
    }

    /// <summary>
    /// 0 * 0 * 0 * ... is always 0, and a negative exponent means dividing by zero.
    /// </summary>
    [TestMethod]
    public void Pow_Base0_NegativeExponent_DivideByZero()
    {
        Throws(() =>      Maths.Pow(0, -1));
        IsTrue(IsInfinity(Math .Pow(0, -1)));
        Throws(() =>      Maths.Pow(0, -2));
        IsTrue(IsInfinity(Math .Pow(0, -2)));
    }

    // Log

    [TestMethod]
    public void Log_ValueSmallerThanBase_Returns0()
    {
        AreEqual(0,            Maths.Log(9, 10));
        AreEqual(0, Math.Floor(Math .Log(9, 10)));
    }

    [TestMethod]
    public void Log_ValueEqualToBase_Returns1()
    {
        AreEqual(1, Maths.Log(10, 10));
        AreEqual(1, Math .Log(10, 10));
    }

    [TestMethod]
    public void Log_ExactPower_ReturnsPower()
    {
        AreEqual(3,       Maths.Log(1000, 10));
        AreEqual(3, () => Math .Log(1000, 10), delta: 0.00001);
    }

    [TestMethod]
    public void Log_NonExactPower_ReturnsFlooredResult()
    {
        AreEqual(2,            Maths.Log(999, 10));
        AreEqual(2, Math.Floor(Math .Log(999, 10)));
    }

    [TestMethod]
    public void Log_Base2_ExactPower_ReturnsPower()
    {
        AreEqual(10, Maths.Log(1024, 2));
        AreEqual(10, Math .Log(1024, 2));
    }

    [TestMethod]
    public void Log_Base2_NonExactPower_ReturnsFlooredResult()
    {
        AreEqual(9,            Maths.Log(1023, 2));
        AreEqual(9, Math.Floor(Math .Log(1023, 2)));
    }

    [TestMethod]
    public void Log_Base3_ExactPower_ReturnsPower()
    {
        AreEqual(4, Maths.Log(81, 3));
        AreEqual(4, Math .Log(81, 3));
    }

    [TestMethod]
    public void Log_Base3_NonExactPower_ReturnsFlooredResult()
    {
        AreEqual(3,            Maths.Log(80, 3));
        AreEqual(3, Math.Floor(Math .Log(80, 3)));
    }

    [TestMethod]
    public void Log_Base16_ExactPower_ReturnsPower()
    {
        AreEqual(3, Maths.Log(4096, 16));
        AreEqual(3, Math .Log(4096, 16));
    }
    
    [TestMethod]
    public void Log_Int32MaxValue_Base2_Returns30_Not32_BecauseFlooredAndSign()
    {
        AreEqual(30,            Maths.Log(int.MaxValue, 2));
        AreEqual(30, Math.Floor(Math .Log(int.MaxValue, 2)));
    }

    
    /// <summary>
    /// 0 isn't a power of anything.
    /// </summary>
    [TestMethod]
    public void Log_OfZero_Undefined()
    {
        Throws(() =>      Maths.Log(0,  1), "value", "0");
        IsTrue(IsNaN     (Math .Log(0,  1)));
        Throws(() =>      Maths.Log(0,  2), "value", "0");
        IsTrue(IsInfinity(Math .Log(0,  2)));
        Throws(() =>      Maths.Log(0,  3), "value", "0");
        IsTrue(IsInfinity(Math .Log(0,  3)));
        Throws(() =>      Maths.Log(0,  4), "value", "0");
        IsTrue(IsInfinity(Math .Log(0,  4)));
        Throws(() =>      Maths.Log(0,  5), "value", "0");
        IsTrue(IsInfinity(Math .Log(0,  5)));
        Throws(() =>      Maths.Log(0,  8), "value", "0");
        IsTrue(IsInfinity(Math .Log(0,  8)));
        Throws(() =>      Maths.Log(0, 10), "value", "0");
        IsTrue(IsInfinity(Math .Log(0, 10)));
        Throws(() =>      Maths.Log(0, 16), "value", "0");
        IsTrue(IsInfinity(Math .Log(0, 16)));
    }

    /// <summary>
    /// Anything to the power of 0 is 1. Log of 1 is 0 because no factors.
    /// </summary>
    [TestMethod]
    public void Log_OfOne_Returns0()
    {
        AreEqual(0, Maths.Log(1, 2));
        AreEqual(0, Math .Log(1, 2));
        AreEqual(0, Maths.Log(1, 3));
        AreEqual(0, Math .Log(1, 3));
        AreEqual(0, Maths.Log(1, 4));
        AreEqual(0, Math .Log(1, 4));
        AreEqual(0, Maths.Log(1, 5));
        AreEqual(0, Math .Log(1, 5));
        AreEqual(0, Maths.Log(1, 8));
        AreEqual(0, Math .Log(1, 8));
        AreEqual(0, Maths.Log(1, 10));
        AreEqual(0, Math .Log(1, 10));
        AreEqual(0, Maths.Log(1, 16));
        AreEqual(0, Math .Log(1, 16));
    }

    /// <summary>
    /// No positive integer base raised to a power yields a negative.
    /// </summary>
    [TestMethod]
    public void Log_OfNegative_Undefined()
    {
        Throws(() => Maths.Log(-2,  2), "value", "negative");
        IsTrue(IsNaN(Math .Log(-2,  2)));
        Throws(() => Maths.Log(-3,  3), "value", "negative");
        IsTrue(IsNaN(Math .Log(-3,  3)));
        Throws(() => Maths.Log(-4,  4), "value", "negative");
        IsTrue(IsNaN(Math .Log(-4,  4)));
        Throws(() => Maths.Log(-5,  5), "value", "negative");
        IsTrue(IsNaN(Math .Log(-5,  5)));
        Throws(() => Maths.Log(-6,  8), "value", "negative");
        IsTrue(IsNaN(Math .Log(-6,  8)));
        Throws(() => Maths.Log(-7, 10), "value", "negative");
        IsTrue(IsNaN(Math .Log(-7, 10)));
        Throws(() => Maths.Log(-8, 16), "value", "negative");
        IsTrue(IsNaN(Math .Log(-8, 16)));
    }

    /// <summary>
    /// 0 * 0 * 0 * ... is always 0. You can never reach 2, 3, 4, etc.
    /// </summary>
    [TestMethod]
    public void Log_Base0_Undefined()
    {
        Throws(() => Maths.Log( 2, 0), "base", "0");
        IsTrue(IsNaN(Math .Log( 2, 0)));
        Throws(() => Maths.Log( 3, 0), "base", "0");
        IsTrue(IsNaN(Math .Log( 3, 0)));
        Throws(() => Maths.Log( 4, 0), "base", "0");
        IsTrue(IsNaN(Math .Log( 4, 0)));
        Throws(() => Maths.Log( 5, 0), "base", "0");
        IsTrue(IsNaN(Math .Log( 5, 0)));
        Throws(() => Maths.Log( 8, 0), "base", "0");
        IsTrue(IsNaN(Math .Log( 8, 0)));
        Throws(() => Maths.Log(10, 0), "base", "0");
        IsTrue(IsNaN(Math .Log(10, 0)));
        Throws(() => Maths.Log(16, 0), "base", "0");
        IsTrue(IsNaN(Math .Log(16, 0)));
    }

    /// <summary>
    /// 1 * 1 * 1 * ... is always 1. You can never reach 2, 3, 4, etc.
    /// </summary>
    [TestMethod]
    public void Log_Base1_Undefined()
    {
        Throws(() => Maths.Log( 1, 1), "base", "1");
        IsTrue(IsNaN(Math .Log( 1, 1)));
        Throws(() => Maths.Log( 2, 1), "base", "1");
        IsTrue(IsNaN(Math .Log( 2, 1)));
        Throws(() => Maths.Log( 3, 1), "base", "1");
        IsTrue(IsNaN(Math .Log( 3, 1)));
        Throws(() => Maths.Log( 4, 1), "base", "1");
        IsTrue(IsNaN(Math .Log( 4, 1)));
        Throws(() => Maths.Log( 5, 1), "base", "1");
        IsTrue(IsNaN(Math .Log( 5, 1)));
        Throws(() => Maths.Log( 8, 1), "base", "1");
        IsTrue(IsNaN(Math .Log( 8, 1)));
        Throws(() => Maths.Log(10, 1), "base", "1");
        IsTrue(IsNaN(Math .Log(10, 1)));
        Throws(() => Maths.Log(16, 1), "base", "1");
        IsTrue(IsNaN(Math .Log(16, 1)));
    }
        
    /// <summary>
    /// Negative bases flip sign each power, making logarithms ill-defined.
    /// </summary>
    [TestMethod]
    public void Log_BaseNegative_Undefined()
    {
        Throws(() => Maths.Log( 1,  -1), "base", "negative");
        IsTrue(IsNaN(Math .Log( 1,  -1)));
        Throws(() => Maths.Log( 2,  -2), "base", "negative");
        IsTrue(IsNaN(Math .Log( 2,  -2)));
        Throws(() => Maths.Log( 3,  -3), "base", "negative");
        IsTrue(IsNaN(Math .Log( 3,  -3)));
        Throws(() => Maths.Log( 4,  -4), "base", "negative");
        IsTrue(IsNaN(Math .Log( 4,  -4)));
        Throws(() => Maths.Log( 5,  -5), "base", "negative");
        IsTrue(IsNaN(Math .Log( 5,  -5)));
        Throws(() => Maths.Log( 8,  -8), "base", "negative");
        IsTrue(IsNaN(Math .Log( 8,  -8)));
        Throws(() => Maths.Log(10, -10), "base", "negative");
        IsTrue(IsNaN(Math .Log(10, -10)));
        Throws(() => Maths.Log(16, -16), "base", "negative");
        IsTrue(IsNaN(Math .Log(16, -16)));
    }

    /// <summary>
    /// Negative bases and values can sometimes work together (e.g. (-2) ^ 1 = -2),
    /// but this integer version rejects them, same as .NET's Math.Log.
    /// </summary>
    [TestMethod]
    public void Log_AllNegative_Undefined()
    {
        Throws(() => Maths.Log(-2,  -2), "negative");
        IsTrue(IsNaN(Math .Log(-2,  -2))); // The log -2 of -2 is 1, but .NET draws the line here so, so do I.
        Throws(() => Maths.Log(-3,  -3), "negative");
        IsTrue(IsNaN(Math .Log(-3,  -3)));
        Throws(() => Maths.Log(-4,  -4), "negative");
        IsTrue(IsNaN(Math .Log(-4,  -4)));
        Throws(() => Maths.Log(-5,  -5), "negative");
        IsTrue(IsNaN(Math .Log(-5,  -5)));
        Throws(() => Maths.Log(-6,  -8), "negative");
        IsTrue(IsNaN(Math .Log(-6,  -8)));
        Throws(() => Maths.Log(-7, -10), "negative");
        IsTrue(IsNaN(Math .Log(-7, -10)));
        Throws(() => Maths.Log(-8, -16), "negative");
        IsTrue(IsNaN(Math .Log(-8, -16)));
    }
}
