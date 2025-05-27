// ReSharper disable RedundantNullableFlowAttribute
namespace JJ.Framework.Existence.Core;

public static class FilledInExtensions
{
    public static bool FilledIn   ([NotNullWhen(true)]  this string?         text)                  => HasString(text);
    public static bool FilledIn   ([NotNullWhen(true)]  this string?         text, bool trimSpace)  => HasString(text, trimSpace);
    public static bool FilledIn   ([NotNullWhen(true)]  this object?         obj )                  => HasRef(obj);
    public static bool FilledIn<T>([NotNullWhen(true)]  this T?              val ) where T : struct => HasStructNullable(val);
    public static bool FilledIn<T>([NotNullWhen(true)]  this T               val ) where T : struct => HasStructNonNull(val);
    public static bool FilledIn<T>([NotNullWhen(true)]  this IEnumerable<T>? coll)                  => HasCollection(coll);
  //public static bool FilledIn<T>([NotNullWhen(true)]  this T?              val) where T : notnull => !Default(val); // notnull lied. it wouldn't take non nullable structs.
  //public static bool FilledIn<T>([NotNullWhen(true)]  this T?              val) where T : new()   => !Default(val);
    
  //public static bool Has        ([NotNullWhen(true)]  this string?         value)                   =>  HasString(value);
  //public static bool Has        ([NotNullWhen(true)]  this string?         value, bool trimSpace)   =>  HasString(value, trimSpace);
  //public static bool Has<T>     ([NotNullWhen(true)]  this T?              value) where T : notnull => !Default(value);
  //public static bool Has<T>     ([NotNullWhen(true)]  this T?              value) where T : struct  => !NullOrDefault(value);
  //public static bool Has<T>     ([NotNullWhen(true)]  this IEnumerable<T>? coll )                   =>  HasCollection(coll);
////public static bool Has        ([NotNullWhen(true)]  this object?         value)                   =>  HasRef(value);
////public static bool Has<T>     ([NotNullWhen(true)]  this T               value) where T : struct  => !Default(value);
////public static bool Has<T>     ([NotNullWhen(true)]  this T?              value) where T : new()   => !Default(value);
    
    public static bool IsNully    ([NotNullWhen(false)] this string?         text)                  => !HasString(text);
    public static bool IsNully    ([NotNullWhen(false)] this string?         text, bool trimSpace)  => !HasString(text, trimSpace);
    public static bool IsNully    ([NotNullWhen(false)] this object?         obj )                  => !HasRef(obj);
    public static bool IsNully<T> ([NotNullWhen(false)] this T               val ) where T : struct => !HasStructNonNull(val);
    public static bool IsNully<T> ([NotNullWhen(false)] this T?              val ) where T : struct => !HasStructNullable(val);
    public static bool IsNully<T> ([NotNullWhen(false)] this IEnumerable<T>? coll)                  => !HasCollection(coll);
  //public static bool IsNully<T> ([NotNullWhen(false)] this T?              val) where T : notnull =>  Default(val);
  //public static bool IsNully<T> ([NotNullWhen(false)] this T?              val) where T : new()   =>  NullOrDefault(val);
  //public static bool IsNully<T> ([NotNullWhen(false)] this T               val) where T : struct  =>  Default(val);
    
    public static bool Is(this string? value, string? comparison                 ) => FilledInHelper.Is(value, comparison       );
    public static bool Is(this string? value, string? comparison, bool ignoreCase) => FilledInHelper.Is(value, comparison, ignoreCase);

    public static bool In   (this string? value,                  params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, coll);
    public static bool In   (this string? value, bool ignoreCase, params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, ignoreCase, coll);
    public static bool In   (this string? value,                         IEnumerable<string?>? coll, bool ignoreCase) => FilledInHelper.In(value, coll, ignoreCase);
    public static bool In<T>(this T       value,                  params IEnumerable<T>?       coll)                  => FilledInHelper.In(value, coll);
    public static bool In<T>(this T       value,                  params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    public static bool In<T>(this T?      value,                  params IEnumerable<T>?       coll) where T : struct => FilledInHelper.In(value, coll);
    public static bool In<T>(this T?      value,                  params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    
    public static bool Contains(this IEnumerable<string> source, string match, bool ignoreCase = false) => FilledInHelper.Contains(source, match, ignoreCase);
    
    // Plain Coalesce (for some)

    public static string Coalesce   (this string? value                  )                        => CoalesceString(value);
    public static T      Coalesce<T>(this T?      value                  ) where T : class, new() => CoalesceRef(value);
    public static T      Coalesce<T>(this T?      value                  ) where T : struct       => CoalesceStructNullable(value);
  //public static T?     Coalesce<T>(this T?      value                  ) where T : class        => HasRef        (value           ) ? value       : default;
  //public static T      Coalesce<T>(this T?      value                  ) where T : new()        => FilledInHelper.Coalesce(value);
  //public static T      Coalesce<T>(this T?      value                  ) where T : notnull      => FilledInHelper.Coalesce(value);

    // Single Fallback

    public static string Coalesce   (this string? value, string? fallback)                  => CoalesceTwoStrings(value, fallback);
    public static string Coalesce   (this string? value, string? fallback, bool trimSpace)  => CoalesceTwoStrings(value, fallback, trimSpace);
    public static string Coalesce   (this object? value, string? fallback)                  => CoalesceObjectToString(HasRef           (value), value, fallback);
    public static string Coalesce<T>(this T       value, string? fallback) where T : struct => CoalesceObjectToString(HasStructNonNull (value), value, fallback);
    public static string Coalesce<T>(this T?      value, string? fallback) where T : struct => CoalesceObjectToString(HasStructNullable(value), value, fallback);
    
    public static T      Coalesce<T>(this object? value, T?      fallback) where T : class, new() =>  HasRef           (value) ? (T)value    : CoalesceRef(fallback);
    public static T      Coalesce<T>(this T?      value, T?      fallback) where T : struct       =>  HasStructNullable(value) ? value.Value : CoalesceStructNullable(fallback);
    public static T      Coalesce<T>(this T?      value, T       fallback) where T : struct       =>  HasStructNullable(value) ? value.Value : CoalesceStructNonNull (fallback);
    public static T      Coalesce<T>(this T       value, T?      fallback) where T : struct       =>  HasStructNonNull (value) ? value       : CoalesceStructNullable(fallback);
    public static T      Coalesce<T>(this T       value, T       fallback) where T : struct       =>  HasStructNonNull (value) ? value       : CoalesceStructNonNull (fallback);

    // 2-Stage Fallback (for some)
    
    public static string Coalesce   (this string? value, string? fallback, string? fallback2)                  => FilledInHelper.Coalesce(value, fallback, fallback2           );
    public static string Coalesce   (this string? value, string? fallback, string? fallback2, bool trimSpace)  => FilledInHelper.Coalesce(value, fallback, fallback2, trimSpace);
    public static string Coalesce<T>(this T       value, T       fallback, string? fallback2)                  => FilledInHelper.Coalesce(value, fallback, fallback2           );
    public static string Coalesce<T>(this T?      value, T?      fallback, string? fallback2) where T : struct => FilledInHelper.Coalesce(value, fallback, fallback2           );
    public static T      Coalesce<T>(this T       value, T       fallback, T       fallback2) where T : new()  => FilledInHelper.Coalesce(value, fallback, fallback2           );
    public static T      Coalesce<T>(this T?      value, T?      fallback, T?      fallback2) where T : struct => FilledInHelper.Coalesce(value, fallback, fallback2           );

    // Variadic Fallbacks

    public static string Coalesce   (this                       IEnumerable<string?>? fallbacks)                 => FilledInHelper.Coalesce(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : new() => FilledInHelper.Coalesce(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : struct => FilledInHelper.Coalesce(fallbacks);

    public static string Coalesce   (this string? first, params IEnumerable<string?>? fallbacks)                 => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : new() => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : struct => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
}
