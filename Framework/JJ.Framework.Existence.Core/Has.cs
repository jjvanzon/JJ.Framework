namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{
    public static bool HasText       ([NotNullWhen(true)]      string? text)                      => !IsNullOrWhiteSpace(text);
    public static bool HasText       ([NotNullWhen(true)]      string? text, bool trimSpace)      => trimSpace ? !IsNullOrWhiteSpace(text): !IsNullOrEmpty(text);
    public static bool HasVal     <T>([NotNullWhen(true)]      T       val)                       => !Equals(val, default(T));
    public static bool HasObject  <T>([NotNullWhen(true)]      T       obj)                       => !Equals(obj, default(T));
    public static bool HasValOrObj<T>([NotNullWhen(true)]      T       thing)                     => !Equals(thing, default(T));
    public static bool HasValNully<T>([NotNullWhen(true)]      T?      nullyVal) where T : struct => !Equals(nullyVal, default(T?)) && !Equals(nullyVal, default(T));

    public static bool Has_StringBuilder(StringBuilder? sb) => sb is { Length: > 0 };
    public static bool Has_StringBuilder(StringBuilder? sb, bool trimSpace)
    {
        if (sb == null) return false;
        if (sb.Length == 0) return false;
        if (!trimSpace) return sb.Length > 0;
        string text = sb.ToString().Trim();
        return text.Length > 0;
    }
}

public static partial class FilledInHelper
{
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text)                      => HasText(text);
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb)                        => Has_StringBuilder(sb);
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb,   bool trimSpace)      => Has_StringBuilder(sb, trimSpace);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              valOrObj)                  => HasValOrObj(valOrObj);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal) where T : struct => HasValNully(nullyVal);
                                                                                                             
    public static bool Has          ([NotNullWhen(true )]      string?        text)                      => HasText(text);
    public static bool Has          ([NotNullWhen(true )]      string?        text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool Has          ([NotNullWhen(true )]      StringBuilder? sb)                        => Has_StringBuilder(sb);
    public static bool Has          ([NotNullWhen(true )]      StringBuilder? sb,   bool trimSpace)      => Has_StringBuilder(sb, trimSpace);
    public static bool Has<T>       ([NotNullWhen(true )]      T              valOrObj)                  => HasValOrObj(valOrObj);
    public static bool Has<T>       ([NotNullWhen(true )]      T?             nullyVal) where T : struct => HasValNully(nullyVal);
                                                                                                             
    public static bool IsNully      ([NotNullWhen(false)]      string? text)                             => !HasText(text);
    public static bool IsNully      ([NotNullWhen(false)]      string? text,      bool trimSpace)        => !HasText(text, trimSpace);
    public static bool IsNully      ([NotNullWhen(true )]      StringBuilder? sb)                        => !Has_StringBuilder(sb);
    public static bool IsNully      ([NotNullWhen(true )]      StringBuilder? sb, bool trimSpace)        => !Has_StringBuilder(sb, trimSpace);
    public static bool IsNully<T>   ([NotNullWhen(false)]      T              valOrObj)                  => !HasValOrObj(valOrObj);
    public static bool IsNully<T>   ([NotNullWhen(false)]      T?             nullyVal) where T : struct => !HasValNully(nullyVal);
}

public static partial class FilledInExtensions
{
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text)                      => HasText(text);
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb)                        => Has_StringBuilder(sb);
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb,   bool trimSpace)      => Has_StringBuilder(sb, trimSpace);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T              valOrObj)                  => HasValOrObj(valOrObj);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T?             nullyVal) where T : struct => HasValNully(nullyVal);
                                                                                                             
    public static bool Has          ([NotNullWhen(true )] this string?        text)                      => HasText(text);
    public static bool Has          ([NotNullWhen(true )] this string?        text, bool trimSpace)      => HasText(text, trimSpace);
    public static bool Has          ([NotNullWhen(true )] this StringBuilder? sb)                        => Has_StringBuilder(sb);
    public static bool Has          ([NotNullWhen(true )] this StringBuilder? sb,   bool trimSpace)      => Has_StringBuilder(sb, trimSpace);
    public static bool Has<T>       ([NotNullWhen(true )] this T              valOrObj)                  => HasValOrObj(valOrObj);
    public static bool Has<T>       ([NotNullWhen(true )] this T?             nullyVal) where T : struct => HasValNully(nullyVal);
                                                                                                             
    public static bool IsNully      ([NotNullWhen(false)] this string? text)                             => !HasText(text);
    public static bool IsNully      ([NotNullWhen(false)] this string? text,      bool trimSpace)        => !HasText(text, trimSpace);
    public static bool IsNully      ([NotNullWhen(true )] this StringBuilder? sb)                        => !Has_StringBuilder(sb);
    public static bool IsNully      ([NotNullWhen(true )] this StringBuilder? sb, bool trimSpace)        => !Has_StringBuilder(sb, trimSpace);
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              valOrObj)                  => !HasValOrObj(valOrObj);
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal) where T : struct => !HasValNully(nullyVal);
}