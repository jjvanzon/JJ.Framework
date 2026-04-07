#pragma warning disable IDE0130 // Namespace != folder
#pragma warning disable IDE0048 // Paranthesize precedence

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
        const int input = 0b_111_000_110_001;
        string toBase = ToBase(input, digitChars);
        AreEqual("*@&#", toBase);
        int fromBase = FromBase(toBase, 8, digitChars);
        AreEqual(input, fromBase);
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
        const int input = 0x4872;
        string toBase = ToBase(input, b: 16, 'A');
        AreEqual("EIHC", toBase);
        int fromBase = FromBase(toBase, 'A', 'P');
        AreEqual(input, fromBase);
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
    public void FromBase_WithDigitChars_Base64Roundtrip()
    {
        int num = 123456789;

        string base64String = ToBase(num, 64, _digitsBase64);
        int convertedBack = FromBase(base64String, 64, _digitsBase64);

        AreEqual(num, convertedBack);
    }

    // .NET Base64 encodes raw bytes in 6-bit groups (with '=' padding),
    // It's chopping the number up, basically.
    // Int = 32 bit.
    // .NET serializer sees bits:
    // [0,5], [6,11], [12,17], [18,23], [24,29], [30-31] + 4 bits left + "=="
    // Each part becomes a digit.
    //
    // How does that different from JJ.Famework?
    // Internally it calls GetDigitValues.
    // The above are the .NET's digit values sort of.
    // If you first shift the number 4 bits left <<.
    // So first 4 bits of input number can't be set (they fall off)
    // JJ.Framework can only handle positive numbers (signed ints)
    // So the first bit can't be set.
    // So in total the first 5 bits can't be set, or they cause trouble


    [DataRow(0b00000000_00000000_00000000_00000000)]
    [DataRow(0b00000000_00000000_00000000_00000001)]
    [DataRow(0b00000111_11111111_11111111_11111111)]
    [DataRow(0b00000101_01010101_01010101_10101010)]
    [DataRow(123456789)]
    [DataTestMethod]
    public void ToBase64_DotNetAndJJFramework_SideBySide(int inputInt)
    {
        Log(inputInt);

        byte[] inputBytes = IntToBytes(inputInt);

        LogBytes(inputBytes);

        // Manhandle JJ.Framework input.
        // 6-bit blocks leave .NET serializer with 4 extra bits at the right
        int inputIntShifted = inputInt;
        inputIntShifted <<= 4;

        Log(inputIntShifted);

        // Convert, our dear JJ.Framework...
        string toBase64_JJ = ToBase(inputIntShifted, _digitsBase64);

        Log(toBase64_JJ);

        // Manhandle JJ.Framework output.
        // .NET loves to end with ==
        string toBase64_JJ_Formatted = toBase64_JJ + "==";
        // Lead with A's (the 0's of base 64)
        toBase64_JJ_Formatted = toBase64_JJ_Formatted.PadLeft(8, 'A'); 

        Log(toBase64_JJ_Formatted);

        // Do your thing .NET...
        string toBase64_Net = ToBase64String(inputBytes);

        Log(toBase64_Net);

        // Now they agree, sort of.
        AreEqual(toBase64_Net, toBase64_JJ_Formatted);
    }

    [DataRow("AAAAAA==")] // 0
    [DataRow("AAAAAQ==")] // 1 but shifted left 4 bits = 16
    [DataRow("AAAAAR==")]
    [DataRow("AAAAAS==")]
    [DataRow("AAAAAT==")]
    [DataRow("AAAAZA==")]
    [DataRow("AAAZAA==")]
    [DataTestMethod]
    public void FromBase64_DotNetAndJJFramework_SideBySide(string input)
    {
        Log(input);

        // Call .NET
        byte[] dotNet_Bytes = FromBase64String(input);

        LogBytes(dotNet_Bytes);

        int dotNet_Num = BytesToInt(dotNet_Bytes);

        Log(dotNet_Num);

        // Manhandle input for JJ.Framework:
        // .NET loves to end with ==
        string inputNoPad = input.CutRight("==");

        Log(inputNoPad);

        // Call JJ.Framework
        int jj_FromBase = FromBase(inputNoPad, 64, _digitsBase64);

        Log(jj_FromBase);

        // Manhandle output of JJ.Framework:
        // 6-bit blocks leave .NET serializer with 4 extra bits at the right,
        // to be ignored by JJ.Framework.
        int jj_FromBase_ShiftBack = jj_FromBase;
        jj_FromBase_ShiftBack >>= 4;

        Log(jj_FromBase_ShiftBack);

        AreEqual(dotNet_Num, jj_FromBase_ShiftBack);
    }

    private static byte[] IntToBytes(int input)
    {
        /*
        // Alteredinput itself:
        int val0 = input >> 24;
        int val1 = input << 8 >> 24;
        int val2 = input << 16 >> 24;
        int val3 = input << 24 >> 24;
        */

        int val0 = (input & 0b_01111111_00000000_00000000_00000000) >> 24;
        int val1 = (input & 0b_00000000_11111111_00000000_00000000) >> 16;
        int val2 = (input & 0b_00000000_00000000_11111111_00000000) >> 8;
        int val3 = (input & 0b_00000000_00000000_00000000_11111111);

        var byte0 = (byte)val0;
        var byte1 = (byte)val1;
        var byte2 = (byte)val2;
        var byte3 = (byte)val3;

        byte[] bytes = [byte0, byte1, byte2, byte3];
        return bytes;
    }

    private static int BytesToInt(byte[] bytes)
    {
        return (bytes[0] << 24) |
               (bytes[1] << 16) |
               (bytes[2] << 8) |
               bytes[3];
    }

    private static void Log<T>(T x, [ArgExpress("x")] string argExpress = "")
    {
        Trace.WriteLine(argExpress + ": " + x);
    }

    private static void LogBytes(byte[] inputBytes, [ArgExpress(nameof(inputBytes))] string argExpress = "")
    {
        if (inputBytes == null) 
        {
            Trace.WriteLine(argExpress + ": <null>");
        }
        else
        {
            Trace.WriteLine(
                $"{argExpress}[{inputBytes.Length}] = [ {string.Join(", ", inputBytes)} ]");

        }
    }
}
