namespace JJ.Framework.Reflection.Core;

public static partial class Reflect
{
    // Fields

    /// <summary>
    /// Type.GetField returns null if the field does not exist.
    /// This method is a little safer than that and throws a clear exception if the field does not exist.
    /// </summary>
    [Obsolete("Use Reflect, Reflector or ReflectExtensions instead.", true)]
    public static FieldInfo GetFieldOrException(Type type, string name)
    {
        if (type == null) throw new ArgumentNullException(nameof(type));
        FieldInfo field = type.GetField(name, BindingFlagsAll);
        if (field == null) throw new Exception($"Field '{name}' not found on type '{type}'.");
        return field;
    }
}

public static partial class ReflectExtensions
{
    // Fields

    /// <summary>
    /// Type.GetField returns null if the field does not exist.
    /// This method is a little safer than that and throws a clear exception if the field does not exist.
    /// </summary>
    [Obsolete("Use Reflect, Reflector or ReflectExtensions instead.", true)]
    public static FieldInfo GetFieldOrException(this Type type, string name)
        => Reflect.GetFieldOrException(type, name);
}