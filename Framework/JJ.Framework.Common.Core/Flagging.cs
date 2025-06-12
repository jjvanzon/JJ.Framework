namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_flagging" />
public static class FlagHelper
{
    // Singular For Ints
    
    /// <inheritdoc cref="_flagging" />
    public static bool HasFlag(int value, int flag) 
        => (value & flag) == flag;

    /// <inheritdoc cref="_flagging" />
    public static int SetFlag(int value, int flag) 
        => value | flag;
    
    /// <inheritdoc cref="_flagging" />
    public static int ClearFlag(int value, int flag) 
        => value & ~flag;

    // Singular For Enums
    
    /// <inheritdoc cref="_flagging" />
    public static bool HasFlag<TEnum>(TEnum value, TEnum flag) where TEnum : Enum
        => HasFlag((int)(object)value, (int)(object)flag);
    
    /// <inheritdoc cref="_flagging" />
    public static TEnum SetFlag<TEnum>(TEnum value, TEnum flag) where TEnum : Enum
        => (TEnum)(object)SetFlag((int)(object)value, (int)(object)flag);
    
    /// <inheritdoc cref="_flagging" />
    public static TEnum ClearFlag<TEnum>(TEnum value, TEnum flag) where TEnum : Enum
        => (TEnum)(object)ClearFlag((int)(object)value, (int)(object)flag);
    
    // Plural for Ints
    
    /// <inheritdoc cref="_flagging" />
    public static int ClearFlags(int value, params ICollection<int> flags)
    {
        ThrowIfNull(flags);
        foreach (int flag in flags)
        {
            value = ClearFlag(value, flag);
        }
        return value;
    }
    
    /// <inheritdoc cref="_flagging" />
    public static int SetFlags(int value, params ICollection<int> flags)
    {
        ThrowIfNull(flags);
        foreach (int flag in flags)
        {
            value = SetFlag(value, flag);
        }
        return value;
    }

    // Plural for Enums

    /// <inheritdoc cref="_flagging" />
    public static TEnum SetFlags<TEnum>(TEnum value, params ICollection<TEnum> flags) where TEnum : Enum
    {
        ThrowIfNull(flags);
        foreach (TEnum flag in flags)
        {
            value = SetFlag(value, flag);
        }
        return value;
    }

    /// <inheritdoc cref="_flagging" />
    public static TEnum ClearFlags<TEnum>(TEnum value, params ICollection<TEnum> flags) where TEnum : Enum
    {
        ThrowIfNull(flags);
        foreach (TEnum flag in flags)
        {
            value = ClearFlag(value, flag);
        }
        return value;
    }
}

/// <inheritdoc cref="_flagging" />
public static class FlagExtensions
{
    /// <inheritdoc cref="_flagging" />
    public static bool  HasFlag          (this int   value, int                       flag )                    => FlagHelper.HasFlag   (value, flag );
    /// <inheritdoc cref="_flagging" />
    public static int   SetFlag          (this int   value, int                       flag )                    => FlagHelper.SetFlag   (value, flag );
    /// <inheritdoc cref="_flagging" />
    public static int   ClearFlag        (this int   value, int                       flag )                    => FlagHelper.ClearFlag (value, flag );
    /// <inheritdoc cref="_flagging" />
    public static int   SetFlags         (this int   value, params ICollection<int>   flags)                    => FlagHelper.SetFlags  (value, flags);
    /// <inheritdoc cref="_flagging" />
    public static int   ClearFlags       (this int   value, params ICollection<int>   flags)                    => FlagHelper.ClearFlags(value, flags);
  ///// <inheritdoc cref="_flagging" />
  //public static bool  HasFlag   <TEnum>(this TEnum value, TEnum                     flag ) where TEnum : Enum => FlagHelper.HasFlag   (value, flag ); // Already supported by .NET
    /// <inheritdoc cref="_flagging" />
    public static TEnum SetFlag   <TEnum>(this TEnum value, TEnum                     flag ) where TEnum : Enum => FlagHelper.SetFlag   (value, flag );
    /// <inheritdoc cref="_flagging" />
    public static TEnum ClearFlag <TEnum>(this TEnum value, TEnum                     flag ) where TEnum : Enum => FlagHelper.ClearFlag (value, flag );
    /// <inheritdoc cref="_flagging" />
    public static TEnum SetFlags  <TEnum>(this TEnum value, params ICollection<TEnum> flags) where TEnum : Enum => FlagHelper.SetFlags  (value, flags);
    /// <inheritdoc cref="_flagging" />
    public static TEnum ClearFlags<TEnum>(this TEnum value, params ICollection<TEnum> flags) where TEnum : Enum => FlagHelper.ClearFlags(value, flags);
}
