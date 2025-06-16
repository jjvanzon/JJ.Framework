// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_ignorecaseobsolete" />
    [Obsolete(IgnoreCaseWarning, true)]
    [Prio(-1)]
    public static bool Is(string? a, string? b, bool ignoreCase, [UsedImplicitly] int dummy1 = 1, [UsedImplicitly] int dummy2 = 2) 
        => throw new NotSupportedException(IgnoreCaseWarning);
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_ignorecaseobsolete" />
    [Obsolete(IgnoreCaseWarning, true)]
    [Prio(-1)]
    public static bool Is(this string? a, string? b, bool ignoreCase, [UsedImplicitly] int dummy1 = 1, [UsedImplicitly] int dummy2 = 2) 
        => throw new NotSupportedException(IgnoreCaseWarning);
}