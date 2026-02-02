namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      string?        text                               )                  => !HasText(text);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      string?        text,     bool         spaceMatters)                  => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      string?        text,     SpaceMatters spaceMatters)                  => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      StringBuilder? sb                                 )                  => !HasSB(sb);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      StringBuilder? sb,       bool         spaceMatters)                  => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      StringBuilder? sb,       SpaceMatters spaceMatters)                  => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T              valOrObj                           )                  => !HasValOrObj(valOrObj);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T              valOrObj, bool         zeroMatters ) where T : struct => !HasVal(valOrObj, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T              valOrObj, ZeroMatters  zeroMatters ) where T : struct => !HasVal(valOrObj, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T?             nullyVal                           ) where T : struct => !HasValNully(nullyVal);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T?             nullyVal, bool         zeroMatters ) where T : struct => !HasValNully(nullyVal, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T?             nullyVal, ZeroMatters  zeroMatters ) where T : struct => !HasValNully(nullyVal, zeroMatters);
}