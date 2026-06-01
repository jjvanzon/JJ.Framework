namespace JJ.Framework.Reflection.Core;

public static partial class Reflect
{
    public static string GetAssemblyName<TType>() => ReflectUtility.GetAssemblyName<TType>();
    public static string TryGetAssemblyName<TType>() => ReflectUtility.TryGetAssemblyName<TType>();

    public static string GetAssemblyName(Type type) => ReflectUtility.GetAssemblyName(type);
    public static string TryGetAssemblyName(Type type) => ReflectUtility.TryGetAssemblyName(type);
    
    public static string GetAssemblyName(Assembly assembly) => ReflectUtility.GetAssemblyName(assembly);
    public static string TryGetAssemblyName(Assembly assembly) => ReflectUtility.TryGetAssemblyName(assembly);

    [MethodImpl(NoInlining)]
    [AotWarn(CallingAssembly)]
    public static string GetAssemblyName()
    {
        try
        {
            return GetAssemblyName(Assembly.GetCallingAssembly());
        }
        catch
        {
           // Fallback for self-contained apps
           return GetAssemblyName(Assembly.GetExecutingAssembly());
        }
    }

    [MethodImpl(NoInlining)]
    [AotWarn(CallingAssembly)]
    public static string TryGetAssemblyName()
    {
        try
        {
            return TryGetAssemblyName(Assembly.GetCallingAssembly());
        }
        catch
        {
           // Fallback for self-contained apps
           return TryGetAssemblyName(Assembly.GetExecutingAssembly());
        }
    }
}

public static partial class ReflectExtensions
{
    public static string GetAssemblyName(this Type type) => ReflectUtility.GetAssemblyName(type);
    public static string TryGetAssemblyName(this Type type) => ReflectUtility.TryGetAssemblyName(type);
    
    public static string GetAssemblyName(this Assembly assembly) => ReflectUtility.GetAssemblyName(assembly);
    public static string TryGetAssemblyName(this Assembly assembly) => ReflectUtility.TryGetAssemblyName(assembly);
}

internal static partial class ReflectUtility
{
    public static string GetAssemblyName<TType>() => GetAssemblyName(typeof(TType));
    public static string TryGetAssemblyName<TType>() => TryGetAssemblyName(typeof(TType));
    
    public static string GetAssemblyName(Type type) => GetAssemblyName(type.NotNull().Assembly);
    public static string TryGetAssemblyName(Type type) => TryGetAssemblyName(type.NotNull().Assembly);

    public static string GetAssemblyName(Assembly assembly)
    {
        string assemblyName = TryGetAssemblyName(assembly);
        if (!Has(assemblyName)) throw new Exception(nameof(assemblyName) + " not found.");
        return assemblyName ?? throw new NullException(() => assembly);
    }

    public static string TryGetAssemblyName(Assembly assembly) => assembly.NotNull().GetName().Name ?? "";
}