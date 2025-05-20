namespace JJ.Framework.Reflection.Core;

internal static class DebuggerDisplays
{
    public static string DebuggerDisplay(Reflector obj)
    {
        return $"{obj.GetType().Name} ({obj.BindingFlags})";
    }
}