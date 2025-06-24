namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    public const string IgnoreCaseWarning = 
        "Use caseMatters instead. " +
        "FLIP YOUR BOOLEANS IF NEEDED: " +
        "Where ignoreCase: false, caseMatters should now be true. " +
        "Default behavior is to ignore case.";

    // Belongs in Text.Core but prevents shipping an extra dependency for now.
    public static StringComparison CaseMattersToStringComparison(this bool caseMatters) 
        => caseMatters ? Ordinal : OrdinalIgnoreCase;
}