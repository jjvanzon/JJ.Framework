using System.Collections.Immutable;

namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{
    public static bool HasText         ([NotNullWhen(true)] string?            text)                      => !IsNullOrWhiteSpace(text);
    public static bool HasText         ([NotNullWhen(true)] string?            text, bool trimSpace)      => trimSpace ? !IsNullOrWhiteSpace(text): !IsNullOrEmpty(text);
    public static bool HasVal<T>       ([NotNullWhen(true)] T                  thing)                     => !Equals(thing, default(T));
    public static bool HasObject<T>    ([NotNullWhen(true)] T                  thing)                     => !Equals(thing, default(T));
    public static bool HasValOrObj<T>  ([NotNullWhen(true)] T                  thing)                     => !Equals(thing, default(T));
    public static bool HasValNully<T>  ([NotNullWhen(true)] T?                 nullyVal) where T : struct => !Equals(nullyVal, default(T?)) && !Equals(nullyVal, default(T));
    public static bool HasCollection<T>([NotNullWhen(true)]               T[]? coll)                      => coll is { Length : > 0};
    public static bool HasCollection<T>([NotNullWhen(true)] IEnumerable   <T>? coll)                      => coll?.Any() ?? false;
    public static bool HasCollection<T>([NotNullWhen(true)] ICollection   <T>? coll)                      => coll is { Count : > 0};
    public static bool HasCollection<T>([NotNullWhen(true)] ISet          <T>? coll)                      => coll is { Count : > 0};
}

public static partial class FilledInHelper
{
    public static bool FilledIn     ([NotNullWhen(true )]      string?                   text)                      => HasText(text);
    public static bool FilledIn     ([NotNullWhen(true )]      string?                   text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T                         valOrObj)                  => HasValOrObj(valOrObj);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?                        nullyVal) where T : struct => HasValNully(nullyVal);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IEnumerable        <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ICollection        <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IList              <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ISet               <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      IDictionary        <T,U>? coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IReadOnlyList      <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IReadOnlyCollection<T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]                         T[]?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      List               <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      HashSet            <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      Dictionary         <T,U>? coll) where T : notnull    => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableList      <T>?   coll)                      => HasCollection(coll);
                                                             
    public static bool Has          ([NotNullWhen(true )]      string?                   text)                      => HasText(text);
    public static bool Has          ([NotNullWhen(true )]      string?                   text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool Has<T>       ([NotNullWhen(true )]      T                         valOrObj)                  => HasValOrObj(valOrObj);
    public static bool Has<T>       ([NotNullWhen(true )]      T?                        nullyVal) where T : struct => HasValNully(nullyVal);
    public static bool Has<T>       ([NotNullWhen(true )]      IEnumerable        <T>?   coll)                      => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ICollection        <T>?   coll)                      => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IList              <T>?   coll)                      => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ISet               <T>?   coll)                      => HasCollection(coll);
    public static bool Has<T,U>     ([NotNullWhen(true )]      IDictionary        <T,U>? coll)                      => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IReadOnlyList      <T>?   coll)                      => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IReadOnlyCollection<T>?   coll)                      => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]                         T[]?   coll)                      => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      List               <T>?   coll)                      => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      HashSet            <T>?   coll)                      => HasCollection(coll);
    public static bool Has<T,U>     ([NotNullWhen(true )]      Dictionary         <T,U>? coll) where T : notnull    => HasCollection(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ImmutableList      <T>?   coll)                      => HasCollection(coll);
                                    
    public static bool IsNully      ([NotNullWhen(false)]      string?                   text)                      => !HasText(text);
    public static bool IsNully      ([NotNullWhen(false)]      string?                   text, bool trimSpace)      => !HasText(text, trimSpace);
    public static bool IsNully<T>   ([NotNullWhen(false)]      T                         valOrObj)                  => !HasValOrObj(valOrObj);
    public static bool IsNully<T>   ([NotNullWhen(false)]      T?                        nullyVal) where T : struct => !HasValNully(nullyVal);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IEnumerable        <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ICollection        <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IList              <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ISet               <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)]      IDictionary        <T,U>? coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IReadOnlyList      <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IReadOnlyCollection<T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]                         T[]?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      List               <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      HashSet            <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)]      Dictionary         <T,U>? coll) where T : notnull    => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ImmutableList      <T>?   coll)                      => !HasCollection(coll);
}

public static partial class FilledInExtensions
{
    public static bool FilledIn     ([NotNullWhen(true )] this string?                   text)                      => HasText(text);
    public static bool FilledIn     ([NotNullWhen(true )] this string?                   text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T                         valOrObj)                  => HasValOrObj(valOrObj);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T?                        nullyVal) where T : struct => HasValNully(nullyVal);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IEnumerable        <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ICollection        <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IList              <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ISet               <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IReadOnlyList      <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IReadOnlyCollection<T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )] this IDictionary        <T,U>? coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this                    T[]?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this List               <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this HashSet            <T>?   coll)                      => HasCollection(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )] this Dictionary         <T,U>? coll) where T : notnull    => HasCollection(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ImmutableList      <T>?   coll)                      => HasCollection(coll);
  
    public static bool IsNully      ([NotNullWhen(false)] this string?                   text)                      => !HasText(text);
    public static bool IsNully      ([NotNullWhen(false)] this string?                   text, bool trimSpace)      => !HasText(text, trimSpace);
    public static bool IsNully<T>   ([NotNullWhen(false)] this T                         valOrObj)                  => !HasValOrObj(valOrObj);
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?                        nullyVal) where T : struct => !HasValNully(nullyVal);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IEnumerable        <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ICollection        <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IList              <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ISet               <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IReadOnlyList      <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IReadOnlyCollection<T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)] this IDictionary        <T,U>? coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this                    T[]?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this List               <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this HashSet            <T>?   coll)                      => !HasCollection(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)] this Dictionary         <T,U>? coll) where T : notnull    => !HasCollection(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ImmutableList      <T>?   coll)                      => !HasCollection(coll);
}