namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       string?        text                                )                  => HasText     (text                   );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       string?        text,      bool         spaceMatters)                  => HasText     (text,      spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       string?        text,      SpaceMatters spaceMatters)                  => HasText     (text,      spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       StringBuilder? sb                                  )                  => HasSB       (sb                     );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       StringBuilder? sb,        bool         spaceMatters)                  => HasSB       (sb,        spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       StringBuilder? sb,        SpaceMatters spaceMatters)                  => HasSB       (sb,        spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       bool           boolean                             )                  => HasBool     (boolean                );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       bool           boolean,   bool         zeroMatters )                  => HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       bool           boolean,   ZeroMatters  zeroMatters )                  => HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       bool?          nullyBool                           )                  => HasBoolNully(nullyBool              );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       bool?          nullyBool, bool         zeroMatters )                  => HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]       bool?          nullyBool, ZeroMatters  zeroMatters )                  => HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]       T              valOrObj                            )                  => HasValOrObj (valOrObj               );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]       T              val,       bool         zeroMatters ) where T : struct => HasVal      (val,       zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]       T              val,       ZeroMatters  zeroMatters ) where T : struct => HasVal      (val,       zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]       T?             nullyVal                            ) where T : struct => HasValNully (nullyVal               );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]       T?             nullyVal,  bool         zeroMatters ) where T : struct => HasValNully (nullyVal,  zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]       T?             nullyVal,  ZeroMatters  zeroMatters ) where T : struct => HasValNully (nullyVal,  zeroMatters );

    // Flags in Front

    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (bool         spaceMatters, [NotNullWhen(true )]     string?        text       )                  => HasText     (text,      spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (SpaceMatters spaceMatters, [NotNullWhen(true )]     string?        text       )                  => HasText     (text,      spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (bool         spaceMatters, [NotNullWhen(true )]     StringBuilder? sb         )                  => HasSB       (sb,        spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (SpaceMatters spaceMatters, [NotNullWhen(true )]     StringBuilder? sb         )                  => HasSB       (sb,        spaceMatters);
    // Ambiguous:
    ///// <inheritdoc cref="_filledin" />
    //public static bool FilledIn   (bool         zeroMatters,  [NotNullWhen(true )]     bool           boolean    )                  => HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (ZeroMatters  zeroMatters,  [NotNullWhen(true )]     bool           boolean    )                  => HasBool     (boolean,   zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (bool         zeroMatters,  [NotNullWhen(true )]     bool?          nullyBool  )                  => HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (ZeroMatters  zeroMatters,  [NotNullWhen(true )]     bool?          nullyBool  )                  => HasBoolNully(nullyBool, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  (bool         zeroMatters,  [NotNullWhen(true )]     T              val        ) where T : struct => HasVal      (val,       zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  (ZeroMatters  zeroMatters,  [NotNullWhen(true )]     T              val        ) where T : struct => HasVal      (val,       zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  (bool         zeroMatters,  [NotNullWhen(true )]     T?             nullyVal   ) where T : struct => HasValNully (nullyVal,  zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  (ZeroMatters  zeroMatters,  [NotNullWhen(true )]     T?             nullyVal   ) where T : struct => HasValNully (nullyVal,  zeroMatters );
}