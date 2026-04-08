#pragma warning disable IDE0001 // Redundant qualifier
// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global
// ReSharper disable UseSymbolAlias
// ReSharper disable UnusedType.Global
// ReSharper disable RedundantNameQualifier

using JJ.Framework.PlatformCompatibility.Core.docs;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static System.String;

namespace JJ.Framework.PlatformCompatibility.Core;

/// <inheritdoc cref="_argumentnullexceptionsupport" />
internal static class ArgumentNullExceptionSupport
{
    #if !NET6_0_OR_GREATER

    /// <inheritdoc cref="_argumentnullexceptionsupport" />
    public static void ThrowIfNull([System.Diagnostics.CodeAnalysis.NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string expression = "")
    {
        if (argument == null) 
            throw new ArgumentNullException(expression);
    }

    #endif
}
