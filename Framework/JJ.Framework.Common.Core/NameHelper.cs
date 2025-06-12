// ReSharper disable EntityNameCapturedOnly.Global

namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_namehelper"/>
public static class NameHelper
{
    /// <inheritdoc cref="_name"/>
    public static string Name([CallerMemberName] string name = null)
        => name.CutLeft("get_").CutLeft("set_");

    /// <inheritdoc cref="_textof" />
    public static string TextOf(object? expression, [CallerArgumentExpression(nameof(expression))] string expressionString = "")
        => expressionString;
    
}