namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_isnully"/>
public static class IsNullyExtensions
{
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text                               ) => !HasText(text);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text,     bool         spaceMatters) => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text,     SpaceMatters spaceMatters) => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb                                 ) => !HasSB(sb);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb,       bool         spaceMatters) => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb,       SpaceMatters spaceMatters) => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              valOrObj                           ) => !HasValOrObj(valOrObj);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              valOrObj, bool         zeroMatters ) where T : struct => !HasVal(valOrObj, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              valOrObj, ZeroMatters  zeroMatters ) where T : struct => !HasVal(valOrObj, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal                           ) where T : struct => !HasValNully(nullyVal);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal, bool         zeroMatters ) where T : struct => !HasValNully(nullyVal, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal, ZeroMatters  zeroMatters ) where T : struct => !HasValNully(nullyVal, zeroMatters);
}