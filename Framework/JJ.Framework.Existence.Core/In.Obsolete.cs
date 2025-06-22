// ReSharper disable MethodOverloadWithOptionalParameter

namespace JJ.Framework.Existence.Core;

// ncrunch: no coverage start

public static partial class FilledInHelper
{
    /*
    /// <inheritdoc cref="_in" />
    [Prio(-1), Obsolete(IgnoreCaseWarning, true)]
    public static bool In(
        string? value, bool ignoreCase, params IEnumerable<string?>? coll)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }
    */

    /// <inheritdoc cref="_in" />
    [Prio(-1), Obsolete(IgnoreCaseWarning, true)]
    public static bool In(
        string? value, IEnumerable<string?>? coll, bool ignoreCase, 
        [UsedImplicitly] int dummy1 = 1, [UsedImplicitly] int dummy2 = 2)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }

    /// <inheritdoc cref="_contains" />
    [Prio(-1), Obsolete(IgnoreCaseWarning, true)]
    public static bool Contains(IEnumerable<string?>? source, string? match, bool ignoreCase = false,
        [UsedImplicitly] int dummy = 0)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }
}

public static partial class FilledInExtensions
{
    /*
    /// <inheritdoc cref="_in" />
    [Obsolete(IgnoreCaseWarning, true)]
    [Prio(-1)]
    public static bool In(
        this string? value, bool ignoreCase, IEnumerable<string?>? coll, 
        [UsedImplicitly] int dummy = 0)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }
    */

    /// <inheritdoc cref="_in" />
    [Obsolete(IgnoreCaseWarning, true)]
    [Prio(-1)]
    public static bool In(
        this string? value, IEnumerable<string?>? coll, bool ignoreCase, 
        [UsedImplicitly] int dummy1 = 1, [UsedImplicitly] int dummy2 = 2)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }

    /// <inheritdoc cref="_contains" />
    [Obsolete(IgnoreCaseWarning, true)]
    [Prio(-1)]
    public static bool Contains(
        this IEnumerable<string?>? source, string? match, bool ignoreCase = false,
        [UsedImplicitly] int dummy = 0)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }
}

// ncrunch: no coverage end
