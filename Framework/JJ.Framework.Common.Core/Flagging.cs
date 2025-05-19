namespace JJ.Framework.Common.Core;

public static class FlagHelper
{
    public static TEnum SetFlag<TEnum>(TEnum value, TEnum flag) where TEnum : Enum
        => (TEnum)(object)SetFlag((int)(object)value, (int)(object)flag);
    
    public static TEnum ClearFlag<TEnum>(TEnum value, TEnum flag) where TEnum : Enum
        => (TEnum)(object)ClearFlag((int)(object)value, (int)(object)flag);

    public static int SetFlag(int value, int flag) => value | flag;
    public static int ClearFlag(int value, int flag) => value & ~flag;
}

public static class FlagExtensions
{
    public static TEnum SetFlag<TEnum>(this TEnum value, TEnum flag) where TEnum : Enum => FlagHelper.SetFlag(value, flag);
    public static TEnum ClearFlag<TEnum>(this TEnum value, TEnum flag) where TEnum : Enum => FlagHelper.ClearFlag(value, flag);
    public static int SetFlag(this int value, int flag) => FlagHelper.SetFlag(value, flag);
    public static int ClearFlag(this int value, int flag) => FlagHelper.ClearFlag(value, flag);
}
