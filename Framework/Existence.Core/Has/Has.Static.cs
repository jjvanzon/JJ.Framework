namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       string?        text                               )                  => HasText     (text                  );
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       string?        text,     bool         spaceMatters)                  => HasText     (text,     spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       string?        text,     SpaceMatters spaceMatters)                  => HasText     (text,     spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       StringBuilder? sb                                 )                  => HasSB       (sb                    );
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       StringBuilder? sb,       bool         spaceMatters)                  => HasSB       (sb,       spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       StringBuilder? sb,       SpaceMatters spaceMatters)                  => HasSB       (sb,       spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       bool           val                                )                  => HasBool     (val                   );
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       bool           val,      bool         zeroMatters )                  => HasBool     (val,      zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       bool           val,      ZeroMatters  zeroMatters )                  => HasBool     (val,      zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       bool?          nullyVal                           )                  => HasBoolNully(nullyVal              );
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       bool?          nullyVal, bool         zeroMatters )                  => HasBoolNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]       bool?          nullyVal, ZeroMatters  zeroMatters )                  => HasBoolNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]       T              valOrObj                           )                  => HasValOrObj (valOrObj              );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]       T              val,      bool         zeroMatters ) where T : struct => HasVal      (val,      zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]       T              val,      ZeroMatters  zeroMatters ) where T : struct => HasVal      (val,      zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]       T?             nullyVal                           ) where T : struct => HasValNully (nullyVal              );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]       T?             nullyVal, bool         zeroMatters ) where T : struct => HasValNully (nullyVal, zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]       T?             nullyVal, ZeroMatters  zeroMatters ) where T : struct => HasValNully (nullyVal, zeroMatters );

    // Flags in Front

    /// <inheritdoc cref="_has" />
    public static bool Has          (bool         spaceMatters, [NotNullWhen(true )]     string?        text      )                  => HasText     (text,     spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          (SpaceMatters spaceMatters, [NotNullWhen(true )]     string?        text      )                  => HasText     (text,     spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          (bool         spaceMatters, [NotNullWhen(true )]     StringBuilder? sb        )                  => HasSB       (sb,       spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          (SpaceMatters spaceMatters, [NotNullWhen(true )]     StringBuilder? sb        )                  => HasSB       (sb,       spaceMatters);
    // Ambiguous:
    ///// <inheritdoc cref="_has" />
    //public static bool Has        (bool         zeroMatters,  [NotNullWhen(true )]     bool           val       )                  => HasBool     (val,      zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has          (ZeroMatters  zeroMatters,  [NotNullWhen(true )]     bool           val       )                  => HasBool     (val,      zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has          (bool         zeroMatters,  [NotNullWhen(true )]     bool?          nullyVal  )                  => HasBoolNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has          (ZeroMatters  zeroMatters,  [NotNullWhen(true )]     bool?          nullyVal  )                  => HasBoolNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       (bool         zeroMatters,  [NotNullWhen(true )]     T              val       ) where T : struct => HasVal      (val,      zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       (ZeroMatters  zeroMatters,  [NotNullWhen(true )]     T              val       ) where T : struct => HasVal      (val,      zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       (bool         zeroMatters,  [NotNullWhen(true )]     T?             nullyVal  ) where T : struct => HasValNully (nullyVal, zeroMatters );
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       (ZeroMatters  zeroMatters,  [NotNullWhen(true )]     T?             nullyVal  ) where T : struct => HasValNully (nullyVal, zeroMatters );

}