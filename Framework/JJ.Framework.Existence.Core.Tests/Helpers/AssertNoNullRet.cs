namespace JJ.Framework.Existence.Core.Tests.Helpers;

internal static class AssertNoNullRet
{
    // For values and objects

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : notnull
    {
        NotNull(ret, message);
    }

    // For objects

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(object? expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : notnull
    {
        NotNull(ret, message);
        AreEqual(expected, ret, message);
    }
    
    // For text

    /// <inheritdoc cref="_nonullret" />
    [Prio(1)]
    public static void NoNullRet(string? expected, string ret, [ArgExpress(nameof(ret))] string message = "")
    {
        NotNull(ret, message);
        AreEqual(expected, ret, message);
    }

    // For int
    
    /// <inheritdoc cref="_nonullret" />
    //public static void NoNullRet<TRet>(int expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
    //    where TRet : struct
    //{
    //    AreEqual(expected, ret, message);
    //    IsType(typeof(int), ret, message);
    //    NotType(typeof(int?), ret, message);
    //}

    /// <inheritdoc cref="_nullret" />
    public static void NullRet<TRet>(int expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
    {
        AreEqual(expected, ret, message);
        IsType(typeof(int?), ret, message);
        NotType(typeof(int), ret, message);
    }
    
    /// <inheritdoc cref="_nullret" />
    public static void NullRet<TRet>(int? expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
    {
        AreEqual(expected, ret, message);
        IsType(typeof(int?), ret, message);
        NotType(typeof(int), ret, message);
    }
}