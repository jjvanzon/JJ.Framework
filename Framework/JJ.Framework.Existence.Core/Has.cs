namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{

    /// <inheritdoc cref="_has" />
    public static bool HasText       ([NotNullWhen(true)] string? text)                                =>                                       !IsNullOrWhiteSpace(text);
    /// <inheritdoc cref="_has" />
    // ReSharper disable once UnusedParameter.Global
    public static bool HasText       ([NotNullWhen(true)] string? text,     SpaceMatters spaceMatters) =>                !IsNullOrEmpty(text);
    /// <inheritdoc cref="_has" />                                           
    public static bool HasText       ([NotNullWhen(true)] string? text,     bool         spaceMatters) => spaceMatters ? !IsNullOrEmpty(text) : !IsNullOrWhiteSpace(text);
    /// <inheritdoc cref="_has" />                                           
    public static bool HasVal     <T>([NotNullWhen(true)] T       val)                                 =>                !Equals(val,   default(T));
    /// <inheritdoc cref="_has" />                                           
    // ReSharper disable UnusedParameter.Global                              
    public static bool HasVal     <T>([NotNullWhen(true)] T       val,      ZeroMatters  zeroMatters)  => true;
    // ReSharper restore UnusedParameter.Global                              
    /// <inheritdoc cref="_has" />                                           
    public static bool HasVal     <T>([NotNullWhen(true)] T       val,      bool         zeroMatters)  => zeroMatters || !Equals(val,   default(T));
    /// <inheritdoc cref="_has" />                                           
    public static bool HasObject  <T>([NotNullWhen(true)] T       obj)                                 =>                !Equals(obj,   default(T));
    /// <inheritdoc cref="_has" />                                           
    public static bool HasValOrObj<T>([NotNullWhen(true)] T       thing)                               =>                !Equals(thing, default(T));
    /// <inheritdoc cref="_has" />                                           
    // ReSharper disable UnusedParameter.Global                              
    public static bool HasValOrObj<T>([NotNullWhen(true)] T       thing,    ZeroMatters  zeroMatters)  =>                !Equals(thing, default(T));
    // ReSharper restore UnusedParameter.Global                              
    /// <inheritdoc cref="_has" />                                           
    public static bool HasValOrObj<T>([NotNullWhen(true)] T       thing,    bool         zeroMatters)  => !zeroMatters ? !Equals(thing, default(T)) : !Equals(thing, null);
    /// <inheritdoc cref="_has" />
    public static bool HasValNully<T>([NotNullWhen(true)] T?      nullyVal)                          where T : struct =>                !Equals(nullyVal, default(T?)) && !Equals(nullyVal, default(T));
    /// <inheritdoc cref="_has" />
    // ReSharper disable once UnusedParameter.Global
    public static bool HasValNully<T>([NotNullWhen(true)] T?      nullyVal, ZeroMatters zeroMatters) where T : struct =>                !Equals(nullyVal, default(T?));
    /// <inheritdoc cref="_has" />
    public static bool HasValNully<T>([NotNullWhen(true)] T?      nullyVal, bool        zeroMatters) where T : struct => !zeroMatters ? !Equals(nullyVal, default(T?)) && !Equals(nullyVal, default(T)) : !Equals(nullyVal, default(T?));

    /// <inheritdoc cref="_has" />
    public static bool HasSB([NotNullWhen(true)] StringBuilder? sb) => HasSB_SpaceIgnored(sb);
    /// <inheritdoc cref="_has" />
    // ReSharper disable once UnusedParameter.Global
    public static bool HasSB([NotNullWhen(true)] StringBuilder? sb, SpaceMatters spaceMatters) => HasSB_SpaceMatters(sb);

    /// <inheritdoc cref="_has" />
    public static bool HasSB([NotNullWhen(true)] StringBuilder? sb, bool spaceMatters) => HasSB_IfSpaceMatters(sb, spaceMatters);

    /// <inheritdoc cref="_has" />
    private static bool HasSB_IfSpaceMatters([NotNullWhen(true)] StringBuilder? sb, bool spaceMatters)
    {
        if (sb == null) return false;
        if (sb.Length == 0) return false;
        if (spaceMatters) return sb.Length > 0;
        string text = sb.ToString();
        return !IsNullOrWhiteSpace(text);
    }

    /// <inheritdoc cref="_has" />
    private static bool HasSB_SpaceIgnored([NotNullWhen(true)] StringBuilder? sb)
    {
        if (sb == null) return false;
        if (sb.Length == 0) return false;
        string text = sb.ToString();
        return !IsNullOrWhiteSpace(text);
    }

    /// <inheritdoc cref="_has" />
    private static bool HasSB_SpaceMatters([NotNullWhen(true)] StringBuilder? sb)
    {
        if (sb == null) return false;
        if (sb.Length == 0) return false;
        return sb.Length > 0;
    }
}

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      string?        text                           ) => HasText(text);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      string?        text, bool         spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      string?        text, SpaceMatters spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      StringBuilder? sb                             ) => HasSB(sb);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      StringBuilder? sb,   bool         spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has          ([NotNullWhen(true )]      StringBuilder? sb,   SpaceMatters spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]      T              valOrObj)                        => HasValOrObj(valOrObj);
    /// <inheritdoc cref="_has" />
    public static bool Has<T>       ([NotNullWhen(true )]      T?             nullyVal) where T : struct       => HasValNully(nullyVal);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text                           ) => HasText(text);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text, bool         spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      string?        text, SpaceMatters spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb                             ) => HasSB(sb);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb,   bool         spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )]      StringBuilder? sb,   SpaceMatters spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T              valOrObj)                        => HasValOrObj(valOrObj);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T?             nullyVal) where T : struct       => HasValNully(nullyVal);
                                                                                                               
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      string?        text                           ) => !HasText(text);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      string?        text, bool         spaceMatters) => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      string?        text, SpaceMatters spaceMatters) => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      StringBuilder? sb                             ) => !HasSB(sb);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      StringBuilder? sb,   bool         spaceMatters) => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)]      StringBuilder? sb,   SpaceMatters spaceMatters) => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T              valOrObj)                        => !HasValOrObj(valOrObj);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)]      T?             nullyVal) where T : struct       => !HasValNully(nullyVal);
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text                           ) => HasText(text);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text, bool         spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this string?        text, SpaceMatters spaceMatters) => HasText(text, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb                             ) => HasSB(sb);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb,   bool         spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn     ([NotNullWhen(true )] this StringBuilder? sb,   SpaceMatters spaceMatters) => HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T              valOrObj)                        => HasValOrObj(valOrObj);
    /// <inheritdoc cref="_filledin" />
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T?             nullyVal) where T : struct       => HasValNully(nullyVal);
                                                                                                             
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text                           ) => !HasText(text);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text, bool         spaceMatters) => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this string?        text, SpaceMatters spaceMatters) => !HasText(text, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb                             ) => !HasSB(sb);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb,   bool         spaceMatters) => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully      ([NotNullWhen(false)] this StringBuilder? sb,   SpaceMatters spaceMatters) => !HasSB(sb, spaceMatters);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T              valOrObj)                        => !HasValOrObj(valOrObj);
    /// <inheritdoc cref="_isnully" />
    public static bool IsNully<T>   ([NotNullWhen(false)] this T?             nullyVal) where T : struct       => !HasValNully(nullyVal);
}