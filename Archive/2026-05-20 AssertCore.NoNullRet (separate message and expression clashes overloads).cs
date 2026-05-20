namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // NoNullRet
    
    // For values and objects

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(TRet ret, [ArgExpress(nameof(ret))] string expression = "")
        where TRet : notnull
    {
        NotNull(ret, expression);
    }

    /// <inheritdoc cref="_nonullret" />
    [Prio(1)]
    public static void NoNullRet<TRet>(TRet ret, string message, [ArgExpress(nameof(ret))] string expression = "")
        where TRet : notnull
    {
        NotNull(ret, message, expression);
    }

    // For objects

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(object? expected, TRet ret, [ArgExpress(nameof(ret))] string expression = "")
        where TRet : notnull
    {
        NotNull(ret, expression);
        AreEqual(expected, ret, expression);
    }

    /// <inheritdoc cref="_nonullret" />
    [Prio(1)]
    public static void NoNullRet<TRet>(object? expected, TRet ret, string message, [ArgExpress(nameof(ret))] string expression = "")
        where TRet : notnull
    {
        NotNull(ret, message, expression);
        AreEqual(expected, ret, message, expression);
    }
    
    // For text

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet(string? expected, string ret, [ArgExpress(nameof(ret))] string expression = "")
    {
        NotNull(ret, expression);
        AreEqual(expected, ret, expression);
    }

    /// <inheritdoc cref="_nonullret" />
    [Prio(1)]
    public static void NoNullRet(string? expected, string ret, string message, [ArgExpress(nameof(ret))] string expression = "")
    {
        NotNull(ret, message, expression);
        AreEqual(expected, ret, message, expression);
    }
    
    // NullRet
    
    // For values

    /// <inheritdoc cref="_nullret" />
    public static void NullRet<TExpected, TRet>(TExpected expected, TRet ret, [ArgExpress(nameof(ret))] string expression = "")
        where TExpected : struct
    {
        AreEqual(expected, ret, expression);
        IsType(typeof(TExpected?), ret, expression);
        NotType(typeof(TExpected), ret, expression);
    }

    /// <inheritdoc cref="_nullret" />
    [Prio(1)]
    public static void NullRet<TExpected, TRet>(TExpected expected, TRet ret, string message, [ArgExpress(nameof(ret))] string expression = "")
        where TExpected : struct
    {
        AreEqual(expected, ret, message, expression);
        IsType(typeof(TExpected?), ret, message, expression);
        NotType(typeof(TExpected), ret, message, expression);
    }
}