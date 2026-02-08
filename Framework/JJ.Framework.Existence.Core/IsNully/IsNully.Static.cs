 namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]       string?        text                                )                  => !HasText(text);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]       string?        text,      bool         spaceMatters)                  => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]       string?        text,      SpaceMatters spaceMatters)                  => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]       StringBuilder? sb                                  )                  => !HasSB(sb);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]       StringBuilder? sb,        bool         spaceMatters)                  => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]       StringBuilder? sb,        SpaceMatters spaceMatters)                  => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)]       bool           boolean                             )                  => !HasBool     (boolean                );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)]       bool           boolean,   bool         zeroMatters )                  => !HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)]       bool           boolean,   ZeroMatters  zeroMatters )                  => !HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)]       bool?          nullyBool                           )                  => !HasBoolNully(nullyBool              );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)]       bool?          nullyBool, bool         zeroMatters )                  => !HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(false)]       bool?          nullyBool, ZeroMatters  zeroMatters )                  => !HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]       T              valOrObj                            )                  => !HasValOrObj(valOrObj);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]       T              val,       bool         zeroMatters ) where T : struct => !HasVal(val, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]       T              val,       ZeroMatters  zeroMatters ) where T : struct => !HasVal(val, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]       T?             nullyVal                            ) where T : struct => !HasValNully(nullyVal);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]       T?             nullyVal,  bool         zeroMatters ) where T : struct => !HasValNully(nullyVal, zeroMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]       T?             nullyVal,  ZeroMatters  zeroMatters ) where T : struct => !HasValNully(nullyVal, zeroMatters);

    // Flags in Front

    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (bool         spaceMatters, [NotNullWhen(false)]      string?        text      )                  => !HasText    (text,     spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (SpaceMatters spaceMatters, [NotNullWhen(false)]      string?        text      )                  => !HasText    (text,     spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (bool         spaceMatters, [NotNullWhen(false)]      StringBuilder? sb        )                  => !HasSB      (sb,       spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (SpaceMatters spaceMatters, [NotNullWhen(false)]      StringBuilder? sb        )                  => !HasSB      (sb,       spaceMatters);
    // Ambiguous:
    ///// <inheritdoc cref="_filledin" />
    //public static bool FilledIn   (bool         zeroMatters,  [NotNullWhen(false)]     bool           boolean    )                  => !HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (ZeroMatters  zeroMatters,  [NotNullWhen(false)]      bool           boolean   )                  => !HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (bool         zeroMatters,  [NotNullWhen(false)]      bool?          nullyBool )                  => !HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (ZeroMatters  zeroMatters,  [NotNullWhen(false)]      bool?          nullyBool )                  => !HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully<T>   (bool         zeroMatters,  [NotNullWhen(false)]      T              val       ) where T : struct => !HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully<T>   (ZeroMatters  zeroMatters,  [NotNullWhen(false)]      T              val       ) where T : struct => !HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully<T>   (bool         zeroMatters,  [NotNullWhen(false)]      T?             nullyVal  ) where T : struct => !HasValNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully<T>   (ZeroMatters  zeroMatters,  [NotNullWhen(false)]      T?             nullyVal  ) where T : struct => !HasValNully(nullyVal, zeroMatters );
}