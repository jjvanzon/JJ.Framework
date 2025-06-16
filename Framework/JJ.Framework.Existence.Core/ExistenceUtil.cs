namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    // Belongs in Text.Core but prevents shipping an extra dependency for now.
    

    public static StringComparison MatchCaseToStringComparison(this bool matchCase)
    {
        return matchCase ? Ordinal : OrdinalIgnoreCase;
    }
    
}