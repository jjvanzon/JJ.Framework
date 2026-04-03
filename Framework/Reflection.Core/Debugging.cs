namespace JJ.Framework.Reflection.Core;

internal static class Debugging
{
    public static string Descriptor(Reflector obj)
    {
        return $"{obj.GetType().Name} ({obj.BindingFlags})";
    }
}