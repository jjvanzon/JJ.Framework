

    #region Obsolete

    // ncrunch: no coverage start

    // ReSharper disable UnusedTypeParameter
    // ReSharper disable UnusedParameter.Local
    // ReSharper disable EntityNameCapturedOnly.Local

    private const string ObsoleteTExpectedArg 
        = "Overload unworkable. Here the argument is always the expected type, and a null/not-null difference cannot be evaluated.";
        
    private const string ObsoleteObjectArg
        = "Overload unworkable. Here the argument is object? and the return type info from the argument is lost.";

    // ReSharper disable once UnusedMember.Local
    [Obsolete(ObsoleteTExpectedArg, true)]
    private static void IsType<TExpected>(TExpected value, [ArgExpress(nameof(value))] string message = "") 
        => throw new NotSupportedException(ObsoleteTExpectedArg);
    
    // ReSharper disable once UnusedMember.Local
    [Obsolete(ObsoleteTExpectedArg, true)]
    private static void NotType<TExpected>(TExpected value, [ArgExpress(nameof(value))] string message = "") 
        => throw new NotSupportedException(ObsoleteTExpectedArg);
        
    // ReSharper disable once UnusedMember.Local
    [Obsolete(ObsoleteObjectArg, true)]
    private static void NotType<TExpected>(object? value, [ArgExpress(nameof(value))] string message = "") 
        => throw new NotSupportedException(ObsoleteObjectArg);
    
    // ncrunch: no coverage end

    #endregion


    [TestMethod]
    public void AssertCore_ThrowsException_WrongMessage()
    {
        const string expectedMsgPart = "AreEqual failed";

        Throws(() => ThrowsException(ThrowingFunc, "murp"), expectedMsgPart);
        Throws(() => ThrowsException<InvalidOperationException>(ThrowingFunc, "murp"), expectedMsgPart);
        Throws(() => ThrowsException(ThrowingFunc, typeof(InvalidOperationException), "murp"), expectedMsgPart);
    }
