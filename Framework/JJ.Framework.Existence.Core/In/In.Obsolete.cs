// ReSharper disable MethodOverloadWithOptionalParameter
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

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
        NameOvl ovl1 = default, NameOvl ovl2 = default)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }

    /// <inheritdoc cref="_contains" />
    [Prio(-1), Obsolete(IgnoreCaseWarning, true)]
    public static bool Contains(IEnumerable<string?>? source, string? match, bool ignoreCase = false,
        NameOvl ovl = default)
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
        [UsedImplicitly(Reason = OverloadByName)] int dummy = 0)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }
    */

    /// <inheritdoc cref="_in" />
    [Obsolete(IgnoreCaseWarning, true)]
    [Prio(-1)]
    public static bool In(
        this string? value, IEnumerable<string?>? coll, bool ignoreCase, 
        NameOvl ovl1 = default, NameOvl ovl2 = default)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }

    /// <inheritdoc cref="_contains" />
    [Obsolete(IgnoreCaseWarning, true)]
    [Prio(-1)]
    // Retaining obsolete method as internal, which now clashes with public method.
    internal static bool Contains(
        this IEnumerable<string?>? source, string? match, bool ignoreCase = false,
        NameOvl ovl = default)
    {
        throw new NotSupportedException(IgnoreCaseWarning);
    }
}

// ncrunch: no coverage end
