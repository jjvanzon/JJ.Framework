
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
```