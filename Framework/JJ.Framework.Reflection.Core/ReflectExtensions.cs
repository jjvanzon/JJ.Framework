
namespace JJ.Framework.Reflection.Core;

public static class ReflectExtensions
{
    public static PropertyInfo  Prop(this Type type, string name, Reflect reflect) => reflect.Prop(type, name);
    public static PropertyInfo? Prop(this Type type, string name, NullableFlag nullable, Reflect reflect) => reflect.Prop(type, name, nullable);
    public static PropertyInfo? Prop(this Type type, string name, bool nullable, Reflect reflect) => reflect.Prop(type, name, nullable);
}