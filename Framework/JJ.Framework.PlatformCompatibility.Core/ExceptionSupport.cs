using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
    
namespace JJ.Framework.PlatformCompatibility.Core;

internal static class ExceptionSupport
{
    #if !NET8_0_OR_GREATER
    
    public static void ThrowIfNull([System.Diagnostics.CodeAnalysis.NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string expression = "")
    {
        if (argument == null) throw new ArgumentNullException(expression);
    }

    public static void ThrowIfNullOrWhiteSpace(string? argument, [CallerArgumentExpression(nameof(argument))] string expression = "")
    {
        if (argument == null)
        {
            if (string.IsNullOrWhiteSpace(expression)) expression = nameof(argument);
            throw new ArgumentNullException($"{expression} is null.");
        }
        
        if (string.IsNullOrWhiteSpace(argument))
        {
            if (string.IsNullOrWhiteSpace(expression)) expression = nameof(argument);
            throw new ArgumentException($"{expression} is null or white space.");
        }
    }
    
    #endif
}
