namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{
    public static bool HasText       ([NotNullWhen(true)]      string? text)                      => !IsNullOrWhiteSpace(text);
    public static bool HasText       ([NotNullWhen(true)]      string? text, bool trimSpace)      => trimSpace ? !IsNullOrWhiteSpace(text): !IsNullOrEmpty(text);
    public static bool HasVal     <T>([NotNullWhen(true)]      T       thing)                     => !Equals(thing, default(T));
    public static bool HasObject  <T>([NotNullWhen(true)]      T       thing)                     => !Equals(thing, default(T));
    public static bool HasValOrObj<T>([NotNullWhen(true)]      T       thing)                     => !Equals(thing, default(T));
    public static bool HasValNully<T>([NotNullWhen(true)]      T?      nullyVal) where T : struct => !Equals(nullyVal, default(T?)) && !Equals(nullyVal, default(T));
}

public static partial class FilledInHelper
{
    public static bool FilledIn     ([NotNullWhen(true )]      string? text)                      => HasText(text);
    public static bool FilledIn     ([NotNullWhen(true )]      string? text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T       valOrObj)                  => HasValOrObj(valOrObj);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?      nullyVal) where T : struct => HasValNully(nullyVal);
    
    public static bool Has          ([NotNullWhen(true )]      string? text)                      => HasText(text);
    public static bool Has          ([NotNullWhen(true )]      string? text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool Has<T>       ([NotNullWhen(true )]      T       valOrObj)                  => HasValOrObj(valOrObj);
    public static bool Has<T>       ([NotNullWhen(true )]      T?      nullyVal) where T : struct => HasValNully(nullyVal);
                                    
    public static bool IsNully      ([NotNullWhen(false)]      string? text)                      => !HasText(text);
    public static bool IsNully      ([NotNullWhen(false)]      string? text, bool trimSpace)      => !HasText(text, trimSpace);
    public static bool IsNully<T>   ([NotNullWhen(false)]      T       valOrObj)                  => !HasValOrObj(valOrObj);
    public static bool IsNully<T>   ([NotNullWhen(false)]      T?      nullyVal) where T : struct => !HasValNully(nullyVal);
}

public static partial class FilledInExtensions
{
    public static bool FilledIn     ([NotNullWhen(true )] this string? text)                      => HasText(text);
    public static bool FilledIn     ([NotNullWhen(true )] this string? text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T       valOrObj)                  => HasValOrObj(valOrObj);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T?      nullyVal) where T : struct => HasValNully(nullyVal);
  
    public static bool IsNully      ([NotNullWhen(false)] this string? text)                      => !HasText(text);
    public static bool IsNully      ([NotNullWhen(false)] this string? text, bool trimSpace)      => !HasText(text, trimSpace);
    public static bool IsNully<T>   ([NotNullWhen(false)] this T       valOrObj)                  => !HasValOrObj(valOrObj);
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?      nullyVal) where T : struct => !HasValNully(nullyVal);
}