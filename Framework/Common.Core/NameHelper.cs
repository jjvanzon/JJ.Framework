// ReSharper disable EntityNameCapturedOnly.Global

namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_namehelper"/>
public static class NameHelper
{
    /// <inheritdoc cref="_name"/>
    public static string Name([Caller] string name = "")
        => name.CutLeft("get_").CutLeft("set_");

    #pragma warning disable IDE0060 // Parameter unused (expression only used for ArgExpress
    /// <inheritdoc cref="_textof" />
    public static string TextOf(object? expression, [ArgExpress(nameof(expression))] string expressionString = "")
        => expressionString;
}