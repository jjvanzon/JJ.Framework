namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    public static bool Is(string? a, string? b) => Is(a, b, ignoreCase: true);
    public static bool Is(string? a, string? b, bool ignoreCase)
    {
        if (a == b) return true;
        
        StringComparison compare = ignoreCase.ToStringComparison();
        
        a = (a ?? "").Trim(); b = (b ?? "").Trim();
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveExcessiveWhiteSpace();
        b = b.RemoveExcessiveWhiteSpace();
        if (string.Equals(a, b, compare)) return true;
        
        a = a.RemoveAccents();
        b = b.RemoveAccents();
        return string.Equals(a, b, compare);
    }
}

public static partial class FilledInExtensions
{
    public static bool Is(this string? value, string? comparison                 ) => FilledInHelper.Is(value, comparison       );
    public static bool Is(this string? value, string? comparison, bool ignoreCase) => FilledInHelper.Is(value, comparison, ignoreCase);
}