namespace JJ.Framework.Common.Core;

public static class FlagHelper
{
    // Singular For Ints
    
    public static bool HasFlag(int value, int flag) 
        => (value & flag) == flag;

    public static int SetFlag(int value, int flag) 
        => value | flag;
    
    public static int ClearFlag(int value, int flag) 
        => value & ~flag;

    // Singular For Enums
    
    public static bool HasFlag<TEnum>(TEnum value, TEnum flag) where TEnum : Enum
        => HasFlag((int)(object)value, (int)(object)flag);
    
    public static TEnum SetFlag<TEnum>(TEnum value, TEnum flag) where TEnum : Enum
        => (TEnum)(object)SetFlag((int)(object)value, (int)(object)flag);
    
    public static TEnum ClearFlag<TEnum>(TEnum value, TEnum flag) where TEnum : Enum
        => (TEnum)(object)ClearFlag((int)(object)value, (int)(object)flag);
    
    // Plural for Ints
    
    public static int ClearFlags(int value, params ICollection<int> flags)
    {
        ThrowIfNull(flags);
        foreach (int flag in flags)
        {
            value = ClearFlag(value, flag);
        }
        return value;
    }
    
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

    public static TEnum SetFlags<TEnum>(TEnum value, params ICollection<TEnum> flags) where TEnum : Enum
    {
        ThrowIfNull(flags);
        foreach (TEnum flag in flags)
        {
            value = SetFlag(value, flag);
        }
        return value;
    }

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

public static class FlagExtensions
{
    public static bool  HasFlag          (this int   value, int                       flag )                    => FlagHelper.HasFlag   (value, flag );
    public static int   SetFlag          (this int   value, int                       flag )                    => FlagHelper.SetFlag   (value, flag );
    public static int   ClearFlag        (this int   value, int                       flag )                    => FlagHelper.ClearFlag (value, flag );
    public static int   SetFlags         (this int   value, params ICollection<int>   flags)                    => FlagHelper.SetFlags  (value, flags);
    public static int   ClearFlags       (this int   value, params ICollection<int>   flags)                    => FlagHelper.ClearFlags(value, flags);
  //public static bool  HasFlag   <TEnum>(this TEnum value, TEnum                     flag ) where TEnum : Enum => FlagHelper.HasFlag   (value, flag ); // Already supported by .NET
    public static TEnum SetFlag   <TEnum>(this TEnum value, TEnum                     flag ) where TEnum : Enum => FlagHelper.SetFlag   (value, flag );
    public static TEnum ClearFlag <TEnum>(this TEnum value, TEnum                     flag ) where TEnum : Enum => FlagHelper.ClearFlag (value, flag );
    public static TEnum SetFlags  <TEnum>(this TEnum value, params ICollection<TEnum> flags) where TEnum : Enum => FlagHelper.SetFlags  (value, flags);
    public static TEnum ClearFlags<TEnum>(this TEnum value, params ICollection<TEnum> flags) where TEnum : Enum => FlagHelper.ClearFlags(value, flags);
}
