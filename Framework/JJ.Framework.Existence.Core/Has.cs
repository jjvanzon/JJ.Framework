namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{
    public static bool HasText         ([NotNullWhen(true)] string?         text)                  => !IsNullOrWhiteSpace(text);
    public static bool HasText         ([NotNullWhen(true)] string?         text, bool trimSpace)  =>  trimSpace ? !IsNullOrWhiteSpace(text): !IsNullOrEmpty(text);
    public static bool HasObject       ([NotNullWhen(true)] object?         obj )                  =>  obj != null;
    public static bool HasVal<T>       ([NotNullWhen(true)] T               val ) where T : struct => !Equals(val, default(T));
    public static bool HasValNully<T>  ([NotNullWhen(true)] T?              val ) where T : struct => !Equals(val, default(T?)) && !Equals(val, default(T));
    public static bool HasCollection<T>([NotNullWhen(true)] IEnumerable<T>? coll)                  =>  coll?.Any() ?? false;
}

public static partial class FilledInHelper
{
    public static bool FilledIn   ([NotNullWhen(true)]       string?         text)                  =>  HasText(text);
    public static bool FilledIn   ([NotNullWhen(true)]       string?         text, bool trimSpace)  =>  HasText(text, trimSpace);
    public static bool FilledIn   ([NotNullWhen(true)]       object?         obj )                  =>  HasObject(obj);
    public static bool FilledIn<T>([NotNullWhen(true)]       T               val ) where T : struct =>  HasVal(val);
    public static bool FilledIn<T>([NotNullWhen(true)]       T?              val ) where T : struct =>  HasValNully(val);
    public static bool FilledIn<T>([NotNullWhen(true)]       IEnumerable<T>? coll)                  =>  HasCollection(coll);
                                                             
    public static bool Has        ([NotNullWhen(true)]       string?         text)                  =>  HasText(text);
    public static bool Has        ([NotNullWhen(true)]       string?         text, bool trimSpace)  =>  HasText(text, trimSpace);
    public static bool Has        ([NotNullWhen(true)]       object?         obj )                  =>  HasObject(obj);
    public static bool Has<T>     ([NotNullWhen(true)]       T?              val ) where T : struct =>  HasValNully(val);
    public static bool Has<T>     ([NotNullWhen(true)]       T               val ) where T : struct =>  HasVal(val);
    public static bool Has<T>     ([NotNullWhen(true)]       IEnumerable<T>? coll)                  =>  HasCollection(coll);
                                                             
    public static bool IsNully    ([NotNullWhen(false)]      string?         text)                  => !HasText(text);
    public static bool IsNully    ([NotNullWhen(false)]      string?         text, bool trimSpace)  => !HasText(text, trimSpace);
    public static bool IsNully    ([NotNullWhen(false)]      object?         obj )                  => !HasObject(obj);
    public static bool IsNully<T> ([NotNullWhen(false)]      T?              val ) where T : struct => !HasValNully(val);
    public static bool IsNully<T> ([NotNullWhen(false)]      T               val ) where T : struct => !HasVal(val);
    public static bool IsNully<T> ([NotNullWhen(false)]      IEnumerable<T>? coll)                  => !HasCollection(coll);
}

public static partial class FilledInExtensions
{
    public static bool FilledIn   ([NotNullWhen(true)]  this string?         text)                  => HasText(text);
    public static bool FilledIn   ([NotNullWhen(true)]  this string?         text, bool trimSpace)  => HasText(text, trimSpace);
    public static bool FilledIn   ([NotNullWhen(true)]  this object?         obj )                  => HasObject(obj);
    public static bool FilledIn<T>([NotNullWhen(true)]  this T?              val ) where T : struct => HasValNully(val);
    public static bool FilledIn<T>([NotNullWhen(true)]  this T               val ) where T : struct => HasVal(val);
    public static bool FilledIn<T>([NotNullWhen(true)]  this IEnumerable<T>? coll)                  => HasCollection(coll);
                                                             
  //public static bool Has        ([NotNullWhen(true)]  this string?         text)                  =>  HasText(text);
  //public static bool Has        ([NotNullWhen(true)]  this string?         text, bool trimSpace)  =>  HasText(text, trimSpace);
  //public static bool Has        ([NotNullWhen(true)]  this object?         obj )                  =>  HasObj(obj);
  //public static bool Has<T>     ([NotNullWhen(true)]  this T?              val ) where T : struct =>  HasValNully(val);
  //public static bool Has<T>     ([NotNullWhen(true)]  this T               val ) where T : struct =>  HasVal(val);
  //public static bool Has<T>     ([NotNullWhen(true)]  this IEnumerable<T>? coll)                  =>  HasCollection(coll);
    
    public static bool IsNully    ([NotNullWhen(false)] this string?         text)                  => !HasText(text);
    public static bool IsNully    ([NotNullWhen(false)] this string?         text, bool trimSpace)  => !HasText(text, trimSpace);
    public static bool IsNully    ([NotNullWhen(false)] this object?         obj )                  => !HasObject(obj);
    public static bool IsNully<T> ([NotNullWhen(false)] this T               val ) where T : struct => !HasVal(val);
    public static bool IsNully<T> ([NotNullWhen(false)] this T?              val ) where T : struct => !HasValNully(val);
    public static bool IsNully<T> ([NotNullWhen(false)] this IEnumerable<T>? coll)                  => !HasCollection(coll);
}
