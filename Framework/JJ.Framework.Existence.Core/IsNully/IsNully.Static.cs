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

    // Flags in Front

    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (bool         spaceMatters, [NotNullWhen(true )]      string?        text    )                  => !HasText    (text,     spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (SpaceMatters spaceMatters, [NotNullWhen(true )]      string?        text    )                  => !HasText    (text,     spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (bool         spaceMatters, [NotNullWhen(true )]      StringBuilder? sb      )                  => !HasSB      (sb,       spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (SpaceMatters spaceMatters, [NotNullWhen(true )]      StringBuilder? sb      )                  => !HasSB      (sb,       spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully<T>   (bool         zeroMatters,  [NotNullWhen(true )]      T              val     ) where T : struct => !HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully<T>   (ZeroMatters  zeroMatters,  [NotNullWhen(true )]      T              val     ) where T : struct => !HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully<T>   (bool         zeroMatters,  [NotNullWhen(true )]      T?             nullyVal) where T : struct => !HasValNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully<T>   (ZeroMatters  zeroMatters,  [NotNullWhen(true )]      T?             nullyVal) where T : struct => !HasValNully(nullyVal, zeroMatters );

    // Boolean Disambiguation

    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(true )]      bool           val,      bool         zeroMatters )                  => !HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(true )]      bool           val,      ZeroMatters  zeroMatters )                  => !HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(true )]      bool?          nullyVal, bool         zeroMatters )                  => !HasValNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      ([NotNullWhen(true )]      bool?          nullyVal, ZeroMatters  zeroMatters )                  => !HasValNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (ZeroMatters  zeroMatters ,[NotNullWhen(true )]      bool           val      )                  => !HasVal     (val,      zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (bool         zeroMatters ,[NotNullWhen(true )]      bool?          nullyVal )                  => !HasValNully(nullyVal, zeroMatters );
    /// <inheritdoc cref="_filledin" />
    public static bool IsNully      (ZeroMatters  zeroMatters ,[NotNullWhen(true )]      bool?          nullyVal )                  => !HasValNully(nullyVal, zeroMatters );
}