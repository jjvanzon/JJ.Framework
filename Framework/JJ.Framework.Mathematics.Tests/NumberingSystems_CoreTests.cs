#pragma warning disable IDE0130 // Namespace != folder

namespace JJ.Framework.Mathematics.Tests;

using static NumberingSystems;

/// <summary>
/// Limited addition to NumberingSystemTests,
/// adding coverage where missing in the originals.
/// </summary>
[TestClass]
public class NumberingSystems_CoreTests
{
    // FromBase (with default digits)

    [TestMethod]
    public void FromBase_WithDefaultDigits_LowercaseHex()
    {
        int result = FromBase("ff", b: 16);

        // f=15 in base 16
        // ff = 15*16^1 + 15*16^0 = 240 + 15 = 255
        AreEqual(255, result);
    }

    [TestMethod]
    public void FromBase_WithDefaultDigits_LowercaseBase36()
    {
        int result = FromBase("az", b: 36);

        // a=10, z=35 in base 36
        // az = 10*36^1 + 35*36^0 = 360 + 35 = 395
        AreEqual(395, result);
    }

    // FromBase (exception cases)

    [TestMethod]
    public void FromBase_WithDefaultDigits_InvalidCharacter_Throws()
    {
        Throws(
            () => FromBase("1@", b: 16),
            typeof(Exception),
            "Invalid digit",
            "@");
    }

    [TestMethod]
    public void Known_Limitation_FromBase_WithDefaultDigits_BaseAbove36_CharacterBeyondZ_Throws()
    {
        Throws(
            () => FromBase("{", b: 37),
            typeof(Exception),
            "Invalid digit",
            "{");
    }

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
    public void FromBase_WithDigitChars_Arrows()
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

    [TestMethod]
    public void FromBase_WithCharCodeRange_PunctuationRange()
    {
        int result = FromBase("?>:;", ':', '?');

        // Base is '?' - ':' + 1 = 6
        // :=0, ;=1, <=2, ==3, >=4, ?=5 in base 6
        // ?>:; = 5*6^3 + 4*6^2 + 0*6^1 + 1*6^0 = 1080 + 144 + 0 + 1 = 1225
        AreEqual(1225, result);
    }

    // Base 64

    private static readonly char[] _digitsBase64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".ToCharArray();

    [TestMethod]
    public void FromBase_WithDigitChars_Base64StandardAlphabet()
    {
        int result = FromBase("/+", b: 64, _digitsBase64);

        // /=63, +=62 in base 64
        // /+ = 63*64^1 + 62*64^0 = 4032 + 62 = 4094
        AreEqual(4094, result);
    }

    [TestMethod]
    public void FromBase_WithDigitChars_Base64StandardAlphabet_RoundTripToBase()
    {
        int num = 123456789;

        string base64String = ToBase(num, 64, _digitsBase64);
        int convertedBack = FromBase(base64String, 64, _digitsBase64);

        AreEqual(num, convertedBack);
    }

    [TestMethod]
    public void Base64_DotNetAndCustom_SideBySide()
    {
        const int original = 123456789;

        // .NET Base64 (bytes -> text -> bytes)
        byte[] bytes;
        unchecked
        {
            bytes =
            [
                (byte)(original >> 24),
                (byte)(original >> 16),
                (byte)(original >> 8),
                (byte)original
            ];
        }
        string dotNetBase64 = Convert.ToBase64String(bytes);
        byte[] decodedBytes = Convert.FromBase64String(dotNetBase64);
        int dotNetDecoded =
            (decodedBytes[0] << 24) |
            (decodedBytes[1] << 16) |
            (decodedBytes[2] << 8) |
            decodedBytes[3];

        // Custom base-64 (number -> text -> number)
        string customBase64 = ToBase(original, 64, _digitsBase64);
        int customDecoded = FromBase(customBase64, 64, _digitsBase64);

        AreEqual(original, dotNetDecoded);
        AreEqual(original, customDecoded);
    }
}
