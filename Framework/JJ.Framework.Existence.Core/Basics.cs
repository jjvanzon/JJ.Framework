namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    public const string IgnoreCaseWarning = 
        "Use matchCase instead. " +
        "FLIP YOUR BOOLEANS IF NEEDED: " +
        "Where ignoreCase: false, matchCase should now be true. " +
        "Default behavior is to ignore case.";

    // Belongs in Text.Core but prevents shipping an extra dependency for now.
    public static StringComparison MatchCaseToStringComparison(this bool matchCase) 
        => matchCase ? Ordinal : OrdinalIgnoreCase;
}