namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Prios: 
    // The methods have value args and text args.
    // Overloads with message + expression go first, otherwise a custom message would map just the expression.
    // Overloads with strings as values go even before that, otherwise one of the string values owuld be nterpreted as the message.

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
        NotNull(ret, expression + " " + message);
    }

    // For objects

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(object? expected, TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : notnull
    {
        NotNull(ret, message);
        AreEqual(expected, ret, message);
    }

    /// <inheritdoc cref="_nonullret" />
    [Prio(1)]
    public static void NoNullRet<TRet>(object? expected, TRet ret, string message, [ArgExpress(nameof(ret))] string expression = "")
        where TRet : notnull
    {
        var comboMsg = expression + " " + message;
        NotNull(ret, comboMsg);
        AreEqual(expected, ret, comboMsg);
    }
    
    // For text

    /// <inheritdoc cref="_nonullret" />
    [Prio(2)]
    public static void NoNullRet(string? expected, string ret, [ArgExpress(nameof(ret))] string message = "")
    {
        NotNull(ret, message);
        AreEqual(expected, ret, message);
    }

    /// <inheritdoc cref="_nonullret" />
    [Prio(3)]
    public static void NoNullRet(string? expected, string ret, string message, [ArgExpress(nameof(ret))] string expression = "")
    {
        var comboMsg = expression + " " + message;
        NotNull(ret, comboMsg);
        AreEqual(expected, ret, comboMsg);
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

    /// <inheritdoc cref="_nullret" />
    [Prio(1)]
    public static void NullRet<TExpected, TRet>(TExpected expected, TRet ret, string message, [ArgExpress(nameof(ret))] string expression = "")
        where TExpected : struct
    {
        var comboMsg = expression + " " + message;
        AreEqual(expected, ret, comboMsg);
        IsType(typeof(TExpected?), ret, comboMsg);
        NotType(typeof(TExpected), ret, comboMsg);
    }
}