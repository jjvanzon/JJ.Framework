namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_membername"/>
public static class NameHelper
{
    /// <inheritdoc cref="_membername"/>
    public static string Name([CallerMemberName] string calledMemberName = null)
        => calledMemberName.CutLeft("get_").CutLeft("set_");
}