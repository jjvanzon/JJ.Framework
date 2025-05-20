namespace JJ.Framework.Reflection.Core;

public static partial class Reflect
{
    public static string GetAssemblyName<TType>()
        => TryGetAssemblyName(typeof(TType).Assembly);
    
    public static string TryGetAssemblyName(Assembly assembly) => assembly?.GetName().Name;
    
    public static string GetAssemblyName(Assembly assembly) => TryGetAssemblyName(assembly) ?? throw new NullException(() => assembly);
}
