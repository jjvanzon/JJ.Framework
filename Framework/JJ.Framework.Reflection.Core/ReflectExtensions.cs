
namespace JJ.Framework.Reflection.Core;

public static class ReflectExtensions
{
    public static PropertyInfo  Prop(this Type type,                        [Caller] string name = "") => Reflect.Prop(type, name);
    public static PropertyInfo? Prop(this Type type, NullableFlag nullable, [Caller] string name = "") => Reflect.Prop(type, nullable, name);
    public static PropertyInfo? Prop(this Type type, bool         nullable, [Caller] string name = "") => Reflect.Prop(type, nullable, name);
    public static PropertyInfo? Prop(this Type type, string       name,     NullableFlag nullable) => Reflect.Prop(type, name, nullable);
    public static PropertyInfo? Prop(this Type type, string       name,     bool         nullable) => Reflect.Prop(type, name, nullable);
}