// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global
// ReSharper disable UseSymbolAlias

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

// ncrunch: no coverage end
