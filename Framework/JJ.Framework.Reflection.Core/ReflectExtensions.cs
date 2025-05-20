
namespace JJ.Framework.Reflection.Core;

// TODO: Make public once API surface quality is checked.
internal static class ReflectExtensions
{
    public static PropertyInfo  Prop(this Type type, string name, Reflector reflect) => reflect.Prop(type, name);
    public static PropertyInfo? Prop(this Type type, string name, NullableFlag nullable, Reflector reflect) => reflect.Prop(type, name, nullable);
    public static PropertyInfo? Prop(this Type type, string name, bool nullable, Reflector reflect) => reflect.Prop(type, name, nullable);
    
    public static PropertyInfo  Prop(this Type type, string name) => Reflect.Prop(type, name);
    public static PropertyInfo? Prop(this Type type, string name, NullableFlag nullable) => Reflect.Prop(type, name, nullable);
    public static PropertyInfo? Prop(this Type type, string name, bool nullable) => Reflect.Prop(type, name, nullable);
}