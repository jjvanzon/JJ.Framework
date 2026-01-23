namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text                               ) => HasText(text);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text,     bool         spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text,     SpaceMatters spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb                                 ) => HasSB(sb);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb,       bool         spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb,       SpaceMatters spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              valOrObj                           ) => HasValOrObj(valOrObj);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              valOrObj, bool         zeroMatters ) where T : struct => HasVal(valOrObj, zeroMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              valOrObj, ZeroMatters  zeroMatters ) where T : struct => HasVal(valOrObj, zeroMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal                           ) where T : struct => HasValNully(nullyVal);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal, bool         zeroMatters ) where T : struct => HasValNully(nullyVal, zeroMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal, ZeroMatters  zeroMatters ) where T : struct => HasValNully(nullyVal, zeroMatters);
}