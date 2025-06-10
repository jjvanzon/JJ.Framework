namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // NoNullRet
    
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
    
    // NullRet
    
    // For values

    /// <inheritdoc cref="_nullret" />
    public static void NullRet<TExpected, TRet>(TExpected expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TExpected : struct
    {
        AreEqual(expected, ret, message);
        IsType(typeof(TExpected?), ret, message);
        NotType(typeof(TExpected), ret, message);
    }
}