```cs

    public static bool HasFlags(int value, params ICollection<int> flags)
    {
        ThrowIfNull(flags);
        foreach (int flag in flags)
        {
            if (!HasFlag(value, flag)) return false;
        }
        return true;
    }
    
    public static bool HasFlags<TEnum>(TEnum value, params ICollection<TEnum> flags) where TEnum : Enum
    {
        ThrowIfNull(flags);
        foreach (TEnum flag in flags)
        {
            if (!HasFlag(value, flag)) return false;
        }
        return true;
    }

    public static bool  HasFlags         (this int   value, params ICollection<int>   flags)                    => FlagHelper.HasFlags  (value, flags);
    public static bool  HasFlags  <TEnum>(this TEnum value, params ICollection<TEnum> flags) where TEnum : Enum => FlagHelper.HasFlags  (value, flags);

```