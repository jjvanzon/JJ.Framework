
namespace JJ.Framework.Reflection.Core;

public static class ReflectExtensions
{
    public static PropertyInfo  Prop(this Type type,                        [Caller] string name = "") => Reflect.Prop(type, name);
    public static PropertyInfo? Prop(this Type type, NullableFlag nullable, [Caller] string name = "") => Reflect.Prop(type, nullable, name);
    public static PropertyInfo? Prop(this Type type, bool         nullable, [Caller] string name = "") => Reflect.Prop(type, nullable, name);
    public static PropertyInfo? Prop(this Type type, string       name,     NullableFlag    nullable ) => Reflect.Prop(type, name, nullable);
    public static PropertyInfo? Prop(this Type type, string       name,     bool            nullable ) => Reflect.Prop(type, name, nullable);
    public static PropertyInfo  Prop<T>(this T obj,                         [Caller] string name = "") => Reflect.Prop(obj,  name);
    public static PropertyInfo? Prop<T>(this T obj,  NullableFlag nullable, [Caller] string name = "") => Reflect.Prop(obj,  nullable, name);
    public static PropertyInfo? Prop<T>(this T obj,  bool         nullable, [Caller] string name = "") => Reflect.Prop(obj,  nullable, name);
    public static PropertyInfo? Prop<T>(this T obj,  string       name,     NullableFlag    nullable ) => Reflect.Prop(obj,  name, nullable);
    public static PropertyInfo? Prop<T>(this T obj,  string       name,     bool            nullable ) => Reflect.Prop(obj,  name, nullable);
}