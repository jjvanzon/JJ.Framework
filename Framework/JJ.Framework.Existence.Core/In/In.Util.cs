// ReSharper disable MethodOverloadWithOptionalParameter

namespace JJ.Framework.Existence.Core;

internal static class InUtil
{
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, OrdinalIgnoreCase));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, [Implic(Reason = MagicBool)] CaseMatters caseMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, Ordinal));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x).Equals(value, stringComparison));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, OrdinalIgnoreCase));
    }

    /// <inheritdoc cref="_in" />
    // ReSharper disable once UnusedParameter.Global
    public static bool In(string? value, IEnumerable<string?>? coll, bool spaceMatters, NameOvl ovl = default)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, OrdinalIgnoreCase));
    }
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, [Implic(Reason = MagicBool)] CaseMatters caseMatters, [Implic(Reason = MagicBool)] SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, Ordinal));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, [Implic(Reason = MagicBool)] CaseMatters caseMatters, bool spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, Ordinal));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters, [Implic(Reason = MagicBool)] SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, stringComparison));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool caseMatters, bool spaceMatters)
    {
        if (coll == null) return false;
        value = FormatValue(value, spaceMatters);
        var stringComparison = GetStringComparison(caseMatters);
        return coll.Any(x => x == value || FormatValue(x, spaceMatters).Equals(value, stringComparison));
    }
    
    // Helpers

    [MethodImpl(AggressiveInlining)]
    public static string FormatValue(string? value) 
        => (value ?? "").Trim();

    [MethodImpl(AggressiveInlining)]
    public static string FormatValue(string? value, [Implic(Reason = MagicBool)] SpaceMatters spaceMatters) 
        => value ?? "";

    [MethodImpl(AggressiveInlining)]
    public static string FormatValue(string? value, bool spaceMatters)
        => spaceMatters ? value ?? "" : (value ?? "").Trim();

    [MethodImpl(AggressiveInlining)]
    public static StringComparison GetStringComparison(bool caseMatters)
        => caseMatters ? Ordinal : OrdinalIgnoreCase;
}