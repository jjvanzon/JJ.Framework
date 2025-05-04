namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_name"/>
public static class NameHelper
{
    /// <inheritdoc cref="_name"/>
    public static string Name([CallerMemberName] string name = null)
        => name.CutLeft("get_").CutLeft("set_");
}