namespace JJ.Framework.Reflection.Core;

internal static class DebuggerDisplays
{
    public static string DebuggerDisplay(Reflect obj)
    {
        return $"{obj.GetType().Name} ({obj.BindingFlags})";
    }
}