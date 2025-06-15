namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    // Copied from Text.Core to prevent shipping a wide dependency.
    public static StringComparison IgnoreCaseToStringComparison(this bool ignoreCase)
    {
        return ignoreCase ? OrdinalIgnoreCase : Ordinal;
    }

    public static StringComparison MatchCaseToStringComparison(this bool matchCase)
    {
        return matchCase ? Ordinal : OrdinalIgnoreCase;
    }
}