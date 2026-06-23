namespace JJ.Framework.Compilation.Core.Formatters;

internal static class DotNetFormatterHelper
{
    /// <inheritdoc cref="_prettifyseparators" />
    public static string PrettifySeparators(string text) => text.Replace('"', '\'').Replace('\\', '/');
}
