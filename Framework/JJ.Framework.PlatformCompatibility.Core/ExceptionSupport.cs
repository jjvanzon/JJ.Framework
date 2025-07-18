// ReSharper disable UnusedMember.Global

// ncrunch: no coverage start

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static System.String;

namespace JJ.Framework.PlatformCompatibility.Core;

internal static class ArgumentNullExceptionSupport
{
    #if !NET6_0_OR_GREATER

    public static void ThrowIfNull([System.Diagnostics.CodeAnalysis.NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string expression = "")
    {
        if (argument == null) throw new ArgumentNullException(expression);
    }

    #endif
}

internal static class ArgumentExceptionSupport
{
    #if !NET8_0_OR_GREATER

    public static void ThrowIfNullOrWhiteSpace([System.Diagnostics.CodeAnalysis.NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string expression = "")
    {
        if (argument == null)
        {
            if (IsNullOrWhiteSpace(expression)) expression = nameof(argument);
            throw new ArgumentNullException($"{expression} is null.");
        }
        
        if (IsNullOrWhiteSpace(argument))
        {
            if (IsNullOrWhiteSpace(expression)) expression = nameof(argument);
            throw new ArgumentException($"{expression} is null or white space.");
        }
    }
    
    #endif
}

// ncrunch: no coverage end
