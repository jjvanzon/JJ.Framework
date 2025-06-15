namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    // Belongs in Text.Core but prevents shipping an extra dependency for now.
    
    public static StringComparison IgnoreCaseToStringComparison(this bool ignoreCase)
    {
        return ignoreCase ? OrdinalIgnoreCase : Ordinal;
    }

    public static StringComparison MatchCaseToStringComparison(this bool matchCase)
    {
        return matchCase ? Ordinal : OrdinalIgnoreCase;
    }
    
    public static StringComparison ToStringComparison(this MatchCase matchCase) => Ordinal;
}