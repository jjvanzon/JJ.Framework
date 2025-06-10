namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_name"/>
public static class NameHelper
{
    /// <inheritdoc cref="_name"/>
    public static string Name([CallerMemberName] string name = null)
        => name.CutLeft("get_").CutLeft("set_");
    
    // ReSharper disable once EntityNameCapturedOnly.Global
    public static string TextOf(object? expression, [CallerArgumentExpression(nameof(expression))] string expressionString = null)
        => expressionString;
    
}