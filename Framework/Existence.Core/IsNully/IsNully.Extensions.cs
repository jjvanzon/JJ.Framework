namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_isnully"/>
public static class IsNullyExtensions
{
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text                                )                  => !HasText     (text                   );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text,      bool         spaceMatters)                  => !HasText     (text,      spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text,      SpaceMatters spaceMatters)                  => !HasText     (text,      spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb                                  )                  => !HasSB       (sb                     );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb,        bool         spaceMatters)                  => !HasSB       (sb,        spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb,        SpaceMatters spaceMatters)                  => !HasSB       (sb,        spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)] this bool           boolean                             )                  => !HasBool     (boolean                );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)] this bool           boolean,   bool         zeroMatters )                  => !HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)] this bool           boolean,   ZeroMatters  zeroMatters )                  => !HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)] this bool?          nullyBool                           )                  => !HasBoolNully(nullyBool              );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)] this bool?          nullyBool, bool         zeroMatters )                  => !HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)] this bool?          nullyBool, ZeroMatters  zeroMatters )                  => !HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              valOrObj                            )                  => !HasValOrObj (valOrObj               );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              val,       bool         zeroMatters ) where T : struct => !HasVal      (val,       zeroMatters );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              val,       ZeroMatters  zeroMatters ) where T : struct => !HasVal      (val,       zeroMatters );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal                            ) where T : struct => !HasValNully (nullyVal               );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal,  bool         zeroMatters ) where T : struct => !HasValNully (nullyVal,  zeroMatters );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal,  ZeroMatters  zeroMatters ) where T : struct => !HasValNully (nullyVal,  zeroMatters );
}