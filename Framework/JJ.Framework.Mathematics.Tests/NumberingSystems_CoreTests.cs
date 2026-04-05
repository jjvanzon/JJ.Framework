#pragma warning disable IDE0130 // Namespace != folder

namespace JJ.Framework.Mathematics.Tests;

using static NumberingSystems;

[TestClass]
public class NumberingSystems_CoreTests
{
    // FromBase (with digit chars)
    
    [TestMethod]
    public void FromBase_WithDigitChars_Base3()
    {
        int result = FromBase("XYZ", b: 3, ['X', 'Y', 'Z']);
        
        // X=0, Y=1, Z=2 in base 3
        // XYZ = 0*3² + 1*3¹ + 2*3⁰ = 0 + 3 + 2 = 5
        AreEqual(5, result);
    }

    [TestMethod]
    public void FromBase_WithDigitChars_Base2()
    {
        int result = FromBase("bab", b: 2, ['a', 'b']);
        
        // b=1, a=0 in base 2
        // bab = 1*2² + 0*2¹ + 1*2⁰ = 4 + 0 + 1 = 5
        AreEqual(5, result);
    }

    [TestMethod]
    public void FromBase_WithDigitChars_RoundTripToBase()
    {
        char[] digitChars = ['p', 'q', 'r', 's', 't'];
        string converted = ToBase(123, digitChars);
        int result = FromBase(converted, 5, digitChars);
        
        AreEqual(123, result);
    }

    // FromBase (with char range)

    [TestMethod]
    public void FromBase_WithCharCodeRange_LowercaseAtoE()
    {
        int result = FromBase("ace", 'a', 'e');
        
        // Base is 'e' - 'a' + 1 = 5
        // a=0, c=2, e=4 in base 5
        // ace = 0*5² + 2*5¹ + 4*5⁰ = 0 + 10 + 4 = 14
        AreEqual(14, result);
    }

    [TestMethod]
    public void FromBase_WithCharCodeRange_DigitsBase10()
    {
        int result = FromBase("248", '0', '9');
        
        // Base is '9' - '0' + 1 = 10
        // 248 in base 10 = 248
        AreEqual(248, result);
    }

    [TestMethod]
    public void FromBase_WithCharCodeRange_BinaryRange()
    {
        int result = FromBase("101", '0', '1');
        
        // Base is '1' - '0' + 1 = 2
        // 101 in binary = 1*4 + 0*2 + 1*1 = 5
        AreEqual(5, result);
    }

    [TestMethod]
    public void FromBase_WithCharCodeRange_CapitalLetters()
    {
        int result = FromBase("ACE", 'A', 'E');
        
        // Base is 'E' - 'A' + 1 = 5
        // A=0, C=2, E=4 in base 5
        // ACE = 0*5² + 2*5¹ + 4*5⁰ = 0 + 10 + 4 = 14
        AreEqual(14, result);
    }

    [TestMethod]
    public void FromBase_WithCharCodeRange_RoundTripToBase()
    {
        const int original = 456;
        string converted = ToBase(original, 16, 'A');
        int result = FromBase(converted, 'A', 'P');
        
        AreEqual(original, result);
    }
}
