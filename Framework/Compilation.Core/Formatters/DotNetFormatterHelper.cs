namespace JJ.Framework.Compilation.Core.Formatters;

internal static class DotNetFormatterHelper
{
    /// <summary>
    /// Replace backslahes and double quotes by foreward slashes and single quotes
    /// because it'd look bad in the debugger display.
    /// (Replace afterwards preferred over "separator" parameter, because values can contain these chars too.
    /// </summary>
    public static string PrettifySeparators(string text) => text.Replace('"', '\'').Replace('\\', '/');
}
