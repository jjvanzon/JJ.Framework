#pragma warning disable IDE0130 // Namespace != folder

namespace JJ.Framework.Mathematics.Tests;

using static NumberingSystems;

[TestClass]
public class NumberingSystems_CoreTests
{
    // FromBase (with digit chars)

    [TestMethod]
    public void FromBase_WithDigitChars_SpecialCharacters()
    {
        char[] digitChars = ['#', '*', '$', '%'];
        int result = FromBase("$*#%", b: 4, digitChars);

        // #=0, *=1, $=2, %=3 in base 4
        // $*#% = 2*4^3 + 1*4^2 + 0*4^1 + 3*4^0 = 128 + 16 + 0 + 3 = 147
        AreEqual(147, result);
    }

    [TestMethod]
    public void FromBase_WithDigitChars_ArrowCharacters()
    {
        char[] digitChars = [ '↓', '↑', '←', '→'];
        int result = FromBase("←↑↓←", b: 4, digitChars);

        // ↓=0, ↑=1, ←=2, →=3 in base 4
        // ←↑↓← = 2*4^3 + 1*4^2 + 0*4^1 + 2*4^0 = 128 + 16 + 0 + 2 = 146
        AreEqual(146, result);
    }

    [TestMethod]
    public void FromBase_WithDigitChars_Greek()
    {
        char[] digitChars = ['α', 'β', 'γ', 'δ', 'ε'];
        int result = FromBase("εγαβ", b: 5, digitChars);

        // α=0, β=1, γ=2, δ=3, ε=4 in base 5
        // εγαβ = 4*5^3 + 2*5^2 + 0*5^1 + 1*5^0 = 500 + 50 + 0 + 1 = 551
        AreEqual(551, result);
    }

    [TestMethod]
    public void FromBase_WithDigitChars_RoundTripSpecialChars()
    {
        char[] digitChars = ['@', '#', '!', '$', '%', '^', '&', '*'];
        int original = 12345;
        string converted = ToBase(original, digitChars);
        int result = FromBase(converted, 8, digitChars);

        AreEqual(original, result);
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
