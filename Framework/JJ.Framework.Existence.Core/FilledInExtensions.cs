// ReSharper disable RedundantNullableFlowAttribute
namespace JJ.Framework.Existence.Core;

public static class FilledInExtensions
{
    public static bool FilledIn   ([NotNullWhen(true)]  this string?         text)                  => HasText(text);
    public static bool FilledIn   ([NotNullWhen(true)]  this string?         text, bool trimSpace)  => HasText(text, trimSpace);
    public static bool FilledIn   ([NotNullWhen(true)]  this object?         obj )                  => HasObj(obj);
    public static bool FilledIn<T>([NotNullWhen(true)]  this T?              val ) where T : struct => HasValNullable(val);
    public static bool FilledIn<T>([NotNullWhen(true)]  this T               val ) where T : struct => HasValtNonNull(val);
    public static bool FilledIn<T>([NotNullWhen(true)]  this IEnumerable<T>? coll)                  => HasCollection(coll);
                                                             
  //public static bool Has        ([NotNullWhen(true)]  this string?         text)                  =>  HasText(text);
  //public static bool Has        ([NotNullWhen(true)]  this string?         text, bool trimSpace)  =>  HasText(text, trimSpace);
  //public static bool Has        ([NotNullWhen(true)]  this object?         obj )                  =>  HasObj(obj);
  //public static bool Has<T>     ([NotNullWhen(true)]  this T?              val ) where T : struct =>  HasValNullable(val);
  //public static bool Has<T>     ([NotNullWhen(true)]  this T               val ) where T : struct =>  HasValtNonNull(val);
  //public static bool Has<T>     ([NotNullWhen(true)]  this IEnumerable<T>? coll)                  =>  HasCollection(coll);
    
    public static bool IsNully    ([NotNullWhen(false)] this string?         text)                  => !HasText(text);
    public static bool IsNully    ([NotNullWhen(false)] this string?         text, bool trimSpace)  => !HasText(text, trimSpace);
    public static bool IsNully    ([NotNullWhen(false)] this object?         obj )                  => !HasObj(obj);
    public static bool IsNully<T> ([NotNullWhen(false)] this T               val ) where T : struct => !HasValtNonNull(val);
    public static bool IsNully<T> ([NotNullWhen(false)] this T?              val ) where T : struct => !HasValNullable(val);
    public static bool IsNully<T> ([NotNullWhen(false)] this IEnumerable<T>? coll)                  => !HasCollection(coll);
    
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

    public static string Coalesce   (this string? text                   )                        => CoalesceString(text);
    public static T      Coalesce<T>(this T?      obj                    ) where T : class, new() => CoalesceObj(obj);
    public static T      Coalesce<T>(this T?      val                    ) where T : struct       => CoalesceValNullable(val);

    // Single Fallback

    public static string Coalesce   (this string? text, string? fallback)                 => CoalesceTwoStrings(text, fallback);
    public static string Coalesce   (this string? text, string? fallback, bool trimSpace) => CoalesceTwoStrings(text, fallback, trimSpace);
    public static string Coalesce   (this object? obj, string? fallback)                  => CoalesceSomethingToString(HasObj           (obj), obj, fallback);
    public static string Coalesce<T>(this T       val, string? fallback) where T : struct => CoalesceSomethingToString(HasValtNonNull (val), val, fallback);
    public static string Coalesce<T>(this T?      val, string? fallback) where T : struct => CoalesceSomethingToString(HasValNullable(val), val, fallback);
    
    public static T      Coalesce<T>(this object? obj, T?      fallback) where T : class, new() =>  HasObj        (obj) ? (T)obj    : CoalesceObj(fallback);
    public static T      Coalesce<T>(this T?      val, T?      fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(this T?      val, T       fallback) where T : struct       =>  HasValNullable(val) ? val.Value : CoalesceValNonNull (fallback);
    public static T      Coalesce<T>(this T       val, T?      fallback) where T : struct       =>  HasValtNonNull(val) ? val       : CoalesceValNullable(fallback);
    public static T      Coalesce<T>(this T       val, T       fallback) where T : struct       =>  HasValtNonNull(val) ? val       : CoalesceValNonNull (fallback);

    // 2-Stage Fallback (for some)
    
    public static string Coalesce   (this string? text, string? fallback, string? fallback2)                  => Coalesce(text, Coalesce(fallback, fallback2));
    public static string Coalesce   (this string? text, string? fallback, string? fallback2, bool trimSpace)  => Coalesce(text, Coalesce(fallback, fallback2, trimSpace), trimSpace);
    public static string Coalesce<T>(this T       obj, T        fallback, string? fallback2)                  => Coalesce(obj,  Coalesce(fallback, fallback2));
    public static string Coalesce<T>(this T?      val, T?       fallback, string? fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(this T       obj, T        fallback, T       fallback2) where T : new()  => Coalesce(obj,  Coalesce(fallback, fallback2));
    public static T      Coalesce<T>(this T?      val, T?       fallback, T?      fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));

    // Variadic Fallbacks

    public static string Coalesce   (this                       IEnumerable<string?>? fallbacks)                  => FilledInHelper.Coalesce(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : new()  => FilledInHelper.Coalesce(fallbacks);
    public static T      Coalesce<T>(this                       IEnumerable<T?>?      fallbacks) where T : struct => FilledInHelper.Coalesce(fallbacks);

    public static string Coalesce   (this string? first, params IEnumerable<string?>? fallbacks)                  => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : new()  => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
    public static T      Coalesce<T>(this T?      first, params IEnumerable<T?>?      fallbacks) where T : struct => FilledInHelper.Coalesce(first.Concat(fallbacks ?? [ ]));
}
