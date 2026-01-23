// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_is" />
internal static class IsUtil
{
    /// <inheritdoc cref="_is" />
    [MethodImpl(AggressiveInlining)]
    public static bool Is(string? a, string? b, bool caseMatters = false, bool spaceMatters = false)
    {
        if (a == b) return true;
        
        StringComparison compare = caseMatters.CaseMattersToStringComparison();
        
        if (!spaceMatters) { a = (a ?? "").Trim(); b = (b ?? "").Trim(); }
        if (string.Equals(a, b, compare)) return true;
        
        if (!spaceMatters) { a = a.RemoveExcessiveWhiteSpace(); b = b.RemoveExcessiveWhiteSpace(); }
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }

    /// <inheritdoc cref="_is" />
    [MethodImpl(AggressiveInlining)]
    public static bool Is(string? a, string? b, bool caseMatters, [UsedImplicitly(Reason = MagicBool)] SpaceMatters spaceMatters)
    {
        if (a == b) return true;
        
        StringComparison compare = caseMatters.CaseMattersToStringComparison();
        
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }

    /// <inheritdoc cref="_is" />
    [MethodImpl(AggressiveInlining)]
    public static bool Is(string? a, string? b, [UsedImplicitly(Reason = MagicBool)] CaseMatters caseMatters, bool spaceMatters)
    {
        if (a == b) return true;
        
        const StringComparison compare = Ordinal;
        
        if (!spaceMatters) { a = (a ?? "").Trim(); b = (b ?? "").Trim(); }
        if (string.Equals(a, b, compare)) return true;
        
        if (!spaceMatters) { a = a.RemoveExcessiveWhiteSpace(); b = b.RemoveExcessiveWhiteSpace(); }
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }

    /// <inheritdoc cref="_is" />
    [MethodImpl(AggressiveInlining)]
    public static bool Is(string? a, string? b, [UsedImplicitly(Reason = MagicBool)] CaseMatters caseMatters)
    {
        if (a == b) return true;
        
        const StringComparison compare = Ordinal;
        
        a = (a ?? "").Trim(); b = (b ?? "").Trim();
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveExcessiveWhiteSpace(); b = b.RemoveExcessiveWhiteSpace();
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }

    /// <inheritdoc cref="_is" />
    [MethodImpl(AggressiveInlining)]
    public static bool Is(string? a, string? b, [UsedImplicitly(Reason = MagicBool)] SpaceMatters spaceMatters)
    {
        if (a == b) return true;
        
        const StringComparison compare = OrdinalIgnoreCase;
        
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }

    /// <inheritdoc cref="_is" />
    [MethodImpl(AggressiveInlining)]
    public static bool Is(string? a, string? b, [UsedImplicitly(Reason = MagicBool)] CaseMatters caseMatters, [UsedImplicitly(Reason = MagicBool)] SpaceMatters spaceMatters)
    {
        if (a == b) return true;
        
        const StringComparison compare = Ordinal;
        
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }
}