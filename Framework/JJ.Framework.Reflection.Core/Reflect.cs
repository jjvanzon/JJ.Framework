namespace JJ.Framework.Reflection.Core;

public static partial class Reflect
{
   public const BindingFlags BindingFlagsAll =
        BindingFlags.Public |
        BindingFlags.NonPublic |
        BindingFlags.Instance |
        BindingFlags.Static |
        BindingFlags.FlattenHierarchy |
        BindingFlags.IgnoreCase;
    
    private static readonly ReflectionCacheLegacy _cache = new(BindingFlagsAll);
}
    