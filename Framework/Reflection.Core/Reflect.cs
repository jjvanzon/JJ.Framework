namespace JJ.Framework.Reflection.Core;

public static partial class Reflect
{
   public const BindingFlags BindingFlagsAll =
        Public |
        NonPublic |
        Instance |
        Static |
        FlattenHierarchy |
        IgnoreCase;
    
    internal static readonly ReflectionCacheLegacy _cache = new(BindingFlagsAll);
}
    