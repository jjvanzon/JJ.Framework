#pragma warning disable IDE0001 // Redundant qualifier
// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global
// ReSharper disable UseSymbolAlias
// ReSharper disable UnusedType.Global

// ncrunch: no coverage start

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static System.String;

namespace JJ.Framework.PlatformCompatibility.Core;

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
