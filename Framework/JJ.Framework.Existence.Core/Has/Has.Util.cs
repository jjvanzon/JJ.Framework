// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_has" />
internal static class HasUtil
{
    /// <inheritdoc cref="_has" />
    public static bool HasText       ([NotNullWhen(true)] string? text                                )                  =>                !IsNullOrWhiteSpace(text);
    /// <inheritdoc cref="_has" />
    public static bool HasText       ([NotNullWhen(true)] string? text,      SpaceMatters spaceMatters)                  =>                !IsNullOrEmpty(text);
    /// <inheritdoc cref="_has" />
    public static bool HasText       ([NotNullWhen(true)] string? text,      bool         spaceMatters)                  => spaceMatters ? !IsNullOrEmpty(text) : !IsNullOrWhiteSpace(text);
    /// <inheritdoc cref="_has" />
    public static bool HasBool       ([NotNullWhen(true)] bool    boolean                             )                  => boolean;
    /// <inheritdoc cref="_has" />
    public static bool HasBool       ([NotNullWhen(true)] bool    boolean,   ZeroMatters  zeroMatters )                  => true;
    /// <inheritdoc cref="_has" />
    public static bool HasBool       ([NotNullWhen(true)] bool    boolean,   bool         zeroMatters )                  => zeroMatters || boolean;
    /// <inheritdoc cref="_has" />
    public static bool HasBoolNully  ([NotNullWhen(true)] bool?   nullyBool                           )                  => nullyBool ?? false;
    /// <inheritdoc cref="_has" />
    public static bool HasBoolNully  ([NotNullWhen(true)] bool?   nullyBool, ZeroMatters  zeroMatters )                  => nullyBool != null;
    /// <inheritdoc cref="_has" />
    public static bool HasBoolNully  ([NotNullWhen(true)] bool?   nullyBool, bool         zeroMatters )                  => zeroMatters ? nullyBool != null : nullyBool ?? false;
    /// <inheritdoc cref="_has" />
    public static bool HasVal     <T>([NotNullWhen(true)] T       val                                 )                  =>                !Equals(val,      default(T));
    /// <inheritdoc cref="_has" />
    public static bool HasVal     <T>([NotNullWhen(true)] T       val,       ZeroMatters  zeroMatters ) where T : struct => true;
    /// <inheritdoc cref="_has" />
    public static bool HasVal     <T>([NotNullWhen(true)] T       val,       bool         zeroMatters ) where T : struct => zeroMatters || !Equals(val,      default(T));
    /// <inheritdoc cref="_has" />
    public static bool HasObject  <T>([NotNullWhen(true)] T       obj                                 )                  =>                !Equals(obj,      default(T));
    /// <inheritdoc cref="_has" />
    public static bool HasValOrObj<T>([NotNullWhen(true)] T       thing                               )                  =>                !Equals(thing,    default(T));
    /// <inheritdoc cref="_has" />
    public static bool HasValNully<T>([NotNullWhen(true)] T?      nullyVal                            ) where T : struct =>                !Equals(nullyVal, default(T?)) && !Equals(nullyVal, default(T));
    /// <inheritdoc cref="_has" />
    public static bool HasValNully<T>([NotNullWhen(true)] T?      nullyVal,  ZeroMatters  zeroMatters ) where T : struct =>                !Equals(nullyVal, default(T?));
    /// <inheritdoc cref="_has" />
    public static bool HasValNully<T>([NotNullWhen(true)] T?      nullyVal,  bool         zeroMatters ) where T : struct => !zeroMatters ? !Equals(nullyVal, default(T?)) && !Equals(nullyVal, default(T)) : !Equals(nullyVal, default(T?));

    /// <inheritdoc cref="_has" />
    public static bool HasSB([NotNullWhen(true)] StringBuilder? sb) => HasSB_SpaceIgnored(sb);
    /// <inheritdoc cref="_has" />
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
