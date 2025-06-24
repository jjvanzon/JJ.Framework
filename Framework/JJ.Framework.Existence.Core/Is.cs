// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
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
    public static bool Is(string? a, string? b, bool caseMatters, [UsedImplicitly] SpaceMatters spaceMatters)
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
    public static bool Is(string? a, string? b, [UsedImplicitly] CaseMatters caseMatters, bool spaceMatters)
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
    public static bool Is(string? a, string? b, [UsedImplicitly] CaseMatters caseMatters)
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
    public static bool Is(string? a, string? b, [UsedImplicitly] SpaceMatters spaceMatters)
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
    public static bool Is(string? a, string? b, [UsedImplicitly] CaseMatters caseMatters, [UsedImplicitly] SpaceMatters spaceMatters)
    {
        if (a == b) return true;
        
        const StringComparison compare = Ordinal;
        
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }
}

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b) 
        => ExistenceUtil.Is(a, b);

    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, CaseMatters caseMatters) 
        => ExistenceUtil.Is(a, b, caseMatters);
    
    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, bool caseMatters) 
        => ExistenceUtil.Is(a, b, caseMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, SpaceMatters spaceMatters) 
        => ExistenceUtil.Is(a, b, spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, bool spaceMatters, [UsedImplicitly] int dummy = 0)
        => ExistenceUtil.Is(a, b, spaceMatters: spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, CaseMatters caseMatters, SpaceMatters spaceMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, CaseMatters caseMatters, bool spaceMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);
    
    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, bool caseMatters, SpaceMatters spaceMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, SpaceMatters spaceMatters, CaseMatters caseMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, SpaceMatters spaceMatters, bool caseMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);
    
    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, bool spaceMatters, CaseMatters caseMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(string? a, string? b, bool caseMatters, bool spaceMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b)
        => ExistenceUtil.Is(a, b);

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, CaseMatters caseMatters)
        => ExistenceUtil.Is(a, b, caseMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool caseMatters)
        => ExistenceUtil.Is(a, b, caseMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters)
        => ExistenceUtil.Is(a, b, spaceMatters);
    
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool spaceMatters, [UsedImplicitly] int dummy = 0)
        => ExistenceUtil.Is(a, b, spaceMatters: spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, CaseMatters caseMatters, SpaceMatters spaceMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, CaseMatters caseMatters, bool spaceMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool caseMatters, SpaceMatters spaceMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);
    
    
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters, CaseMatters caseMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);
    
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters, bool caseMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);
    
    
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool spaceMatters, CaseMatters caseMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool caseMatters, bool spaceMatters)
        => ExistenceUtil.Is(a, b, caseMatters, spaceMatters);
}