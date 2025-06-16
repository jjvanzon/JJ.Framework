namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_ignorecaseobsolete" />
    [Obsolete(IgnoreCaseObsolete, true)]
    public static bool Is(string? a, string? b, bool ignoreCase, [UsedImplicitly] int dummy1 = 1, [UsedImplicitly] int dummy2 = 2) 
        => throw new NotSupportedException(IgnoreCaseObsolete);
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_ignorecaseobsolete" />
    [Obsolete(IgnoreCaseObsolete, true)]
    public static bool Is(this string? a, string? b, bool ignoreCase, [UsedImplicitly] int dummy1 = 1, [UsedImplicitly] int dummy2 = 2) 
        => throw new NotSupportedException(IgnoreCaseObsolete);
}