namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text                               )                  => HasText    (text                  );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text,     bool         spaceMatters)                  => HasText    (text,     spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text,     SpaceMatters spaceMatters)                  => HasText    (text,     spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb                                 )                  => HasSB      (sb                    );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb,       bool         spaceMatters)                  => HasSB      (sb,       spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb,       SpaceMatters spaceMatters)                  => HasSB      (sb,       spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              valOrObj                           )                  => HasValOrObj(valOrObj              );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              val,      bool         zeroMatters ) where T : struct => HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              val,      ZeroMatters  zeroMatters ) where T : struct => HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal                           ) where T : struct => HasValNully(nullyVal              );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal, bool         zeroMatters ) where T : struct => HasValNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal, ZeroMatters  zeroMatters ) where T : struct => HasValNully(nullyVal, zeroMatters );

    // Parameter Swap

    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (bool         spaceMatters, [NotNullWhen(true )]      string?        text    )                  => HasText    (text,     spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (SpaceMatters spaceMatters, [NotNullWhen(true )]      string?        text    )                  => HasText    (text,     spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (bool         spaceMatters, [NotNullWhen(true )]      StringBuilder? sb      )                  => HasSB      (sb,       spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     (SpaceMatters spaceMatters, [NotNullWhen(true )]      StringBuilder? sb      )                  => HasSB      (sb,       spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  (bool         zeroMatters,  [NotNullWhen(true )]      T              val     ) where T : struct => HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  (ZeroMatters  zeroMatters,  [NotNullWhen(true )]      T              val     ) where T : struct => HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  (bool         zeroMatters,  [NotNullWhen(true )]      T?             nullyVal) where T : struct => HasValNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  (ZeroMatters  zeroMatters,  [NotNullWhen(true )]      T?             nullyVal) where T : struct => HasValNully(nullyVal, zeroMatters );

    // Boolean Disambiguation

    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      bool           val,      bool         zeroMatters )                  => HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      bool           val,      ZeroMatters  zeroMatters )                  => HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      bool?          nullyVal, bool         zeroMatters )                  => HasValNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      bool?          nullyVal, ZeroMatters  zeroMatters )                  => HasValNully(nullyVal, zeroMatters );
}