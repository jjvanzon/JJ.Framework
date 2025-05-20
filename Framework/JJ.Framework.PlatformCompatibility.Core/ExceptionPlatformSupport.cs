using System.Diagnostics.CodeAnalysis;

namespace JJ.Framework.PlatformCompatibility.Core;

public static class ExceptionPlatformSupport
{
    #if !NET8_0_OR_GREATER
    public static void ThrowIfNull(object? argument, [CallerArgumentExpression(nameof(argument))] string expression = "")
    {
        if (argument == null) throw new ArgumentNullException(expression);
    }

    public static void ThrowIfNullOrWhiteSpace(string? argument, [CallerArgumentExpression(nameof(argument))] string expression = "")
    {
        if (!string.IsNullOrWhiteSpace(argument)) return;
        if (string.IsNullOrWhiteSpace(expression)) expression = nameof(argument);
        throw new ArgumentException($"{expression} is null or white space.");
    }
    #endif
}