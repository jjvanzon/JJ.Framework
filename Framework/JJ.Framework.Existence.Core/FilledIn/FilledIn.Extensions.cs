namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_filledin"/>
public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text                               ) => HasText(text);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text,     bool         spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text,     SpaceMatters spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb                                 ) => HasSB(sb);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb,       bool         spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb,       SpaceMatters spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T              valOrObj                           ) => HasValOrObj(valOrObj);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T              val,      bool         zeroMatters ) where T : struct => HasVal(val, zeroMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T              val,      ZeroMatters  zeroMatters ) where T : struct => HasVal(val, zeroMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T?             nullyVal                           ) where T : struct => HasValNully(nullyVal);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T?             nullyVal, bool         zeroMatters ) where T : struct => HasValNully(nullyVal, zeroMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T?             nullyVal, ZeroMatters  zeroMatters ) where T : struct => HasValNully(nullyVal, zeroMatters);
}