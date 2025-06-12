namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{
    /// <inheritdoc cref="_has" />
    public static bool HasText       ([NotNullWhen(true)]      string? text)                      => !IsNullOrWhiteSpace(text);
    /// <inheritdoc cref="_has" />
    public static bool HasText       ([NotNullWhen(true)]      string? text, bool trimSpace)      => trimSpace ? !IsNullOrWhiteSpace(text): !IsNullOrEmpty(text);
    /// <inheritdoc cref="_has" />
    public static bool HasVal     <T>([NotNullWhen(true)]      T       val)                       => !Equals(val, default(T));
    /// <inheritdoc cref="_has" />
    public static bool HasObject  <T>([NotNullWhen(true)]      T       obj)                       => !Equals(obj, default(T));
    /// <inheritdoc cref="_has" />
    public static bool HasValOrObj<T>([NotNullWhen(true)]      T       thing)                     => !Equals(thing, default(T));
    /// <inheritdoc cref="_has" />
    public static bool HasValNully<T>([NotNullWhen(true)]      T?      nullyVal) where T : struct => !Equals(nullyVal, default(T?)) && !Equals(nullyVal, default(T));

    /// <inheritdoc cref="_has" />
    public static bool HasSB([NotNullWhen(true)] StringBuilder? sb) => HasSB(sb, trimSpace: true);
    /// <inheritdoc cref="_has" />
    public static bool HasSB([NotNullWhen(true)] StringBuilder? sb, bool trimSpace)
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
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      string?        text)                      => HasText(text);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      string?        text, bool trimSpace)      => HasText(text, trimSpace);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      StringBuilder? sb)                        => HasSB(sb);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      StringBuilder? sb,   bool trimSpace)      => HasSB(sb, trimSpace);
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]      T              valOrObj)                  => HasValOrObj(valOrObj);
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]      T?             nullyVal) where T : struct => HasValNully(nullyVal);

    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text)                      => HasText(text);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text, bool trimSpace)      => HasText(text, trimSpace);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb)                        => HasSB(sb);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb,   bool trimSpace)      => HasSB(sb, trimSpace);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              valOrObj)                  => HasValOrObj(valOrObj);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal) where T : struct => HasValNully(nullyVal);

    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      string? text)                             => !HasText(text);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      string? text,      bool trimSpace)        => !HasText(text, trimSpace);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      StringBuilder? sb)                        => !HasSB(sb);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      StringBuilder? sb, bool trimSpace)        => !HasSB(sb, trimSpace);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T              valOrObj)                  => !HasValOrObj(valOrObj);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T?             nullyVal) where T : struct => !HasValNully(nullyVal);
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text)                      => HasText(text);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text, bool trimSpace)      => HasText(text, trimSpace);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb)                        => HasSB(sb);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb,   bool trimSpace)      => HasSB(sb, trimSpace);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T              valOrObj)                  => HasValOrObj(valOrObj);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T?             nullyVal) where T : struct => HasValNully(nullyVal);
                                                                                                             
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string? text)                             => !HasText(text);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string? text,      bool trimSpace)        => !HasText(text, trimSpace);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb)                        => !HasSB(sb);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb, bool trimSpace)        => !HasSB(sb, trimSpace);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              valOrObj)                  => !HasValOrObj(valOrObj);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal) where T : struct => !HasValNully(nullyVal);
}