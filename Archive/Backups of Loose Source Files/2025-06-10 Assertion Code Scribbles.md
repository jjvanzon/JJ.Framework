```cs    
    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(int expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : struct
    {
        AreEqual(expected, ret, message);
        IsType(typeof(int), ret, message);
        NotType(typeof(int?), ret, message);
    }
    /// <inheritdoc cref="_nullret" />
    [Prio(1)]
    public static void NullRet(string? expected, string? ret, [ArgExpress(nameof(ret))] string message = "")
    {
        AssertCore.NullRet(ret, message);
        AreEqual(expected, ret, message);
    }

```