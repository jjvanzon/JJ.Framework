
```cs    
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

        // Reults in negative number (JJ.Framework FromBase can't handle)
        byte[] inputBytes =
        [
            0b_1111_1100, 
            0b_0101_0101, 
            0b_1100_1100, 
            0b_1111_0000
        ];

        // First bit not filled = positive; convoluted: use binary literal for int directly.
        byte[] inputBytes =
        [
            0b_0111_1100, 
            0b_0101_0101, 
            0b_1100_1100, 
            0b_1111_0001
        ];

        return BytesToInt(inputBytes);

        // Naive example;
        //return 123456789;

        // Shifted 4 bits (try resolve padding problem)
        //return 123456789 << 4;

        //return 0b01111111_11111111_11111111_11111111;
        return 0b00000111_11111111_11111111_11111111;
        //return 0b00000001_11111111_11111111_11110000;
        //return 0b00000000_00000000_00000000_00000000;
        //return 0b00000000_00000000_00000000_00000001;

    // Is signed, unsigned an issue?
    // What if I start with the bits as input?


    // Bytes need to result in at least 1 bit set in the first 6 bits,
    // So both .NET (cuts up things in 6 bit chunks)
    // And JJ.Framework use all digit places.

    private static int GetBase64InputInt()
    {

    }

```