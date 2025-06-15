namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtil
{
    /// <inheritdoc cref="_contains" />
    public static bool Contains(IEnumerable<string?>? coll, string? value, bool matchCase = false)
    {
        if (coll == null) return false;
        value = (value ?? "").Trim();
        var stringComparison = matchCase.MatchCaseToStringComparison();
        return coll.Any(x => x == value || (x ?? "").Trim().Equals(value, stringComparison));
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool matchCase, bool spaceMatters)
    {
        if (coll == null) return false;
        
        value ??= "";
        
        if (!spaceMatters) 
        { 
            value = value.Trim();
        }
        
        var stringComparison = matchCase.MatchCaseToStringComparison();
        
        foreach (string? x in coll)
        {
            if (x == value)
            {
                return true; 
            }
            
            string capture = x ?? "";
            
            if (!spaceMatters)
            {
                capture = capture.Trim();
            }
            
            if (capture.Equals(value, stringComparison)) 
            {
                return true;
            }
        }

        return false;
    }

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll)
    {
        if (coll == null) return false;
        value = (value ?? "").Trim();
        return coll.Any(x => x == value || (x ?? "").Trim().Equals(value, OrdinalIgnoreCase));
    }
    
    public static bool In(string? value, IEnumerable<string?>? coll, MatchCase matchCase)
    {
        if (coll == null) return false;
        value = (value ?? "").Trim();
        return coll.Any(x => x == value || (x ?? "").Trim().Equals(value, Ordinal));
    }
    
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value ??= "";
        return coll.Any(x => x == value || (x ?? "").Equals(value, OrdinalIgnoreCase));
    }

    public static bool In(string? value, IEnumerable<string?>? coll, MatchCase matchCase, SpaceMatters spaceMatters)
    {
        if (coll == null) return false;
        value ??= "";
        return coll.Any(x => x == value || (x ?? "").Equals(value, Ordinal));
    }
}

public static partial class FilledInHelper
{
    // TODO: Variants with IEnumerable<string> (non-nullable strings) for lack of covariance?
    
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value,                 params IEnumerable<string?>? coll                 ) =>                    coll .Contains(value, matchCase: false);
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value, bool matchCase, params IEnumerable<string?>? coll                 ) =>                    coll .Contains(value, matchCase       );
    /// <inheritdoc cref="_in" />
    public static bool In   (     string? value,                        IEnumerable<string?>? coll, bool matchCase ) =>                    coll .Contains(value, matchCase       );
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T       value,                 params IEnumerable<T>?       coll)                  =>                    coll?.Contains(value                  ) ?? false; 
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T       value,                 params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T?      value,                 params IEnumerable<T>?       coll) where T : struct => value.HasValue && (coll?.Contains(value.Value            ) ?? false);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(     T?      value,                 params IEnumerable<T?>?      coll) where T : struct =>                    coll?.Contains(value                  ) ?? false;
}

public static partial class FilledInExtensions
{
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value,                 params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value, bool matchCase, params IEnumerable<string?>? coll                 ) => FilledInHelper.In(value, matchCase, coll);
    /// <inheritdoc cref="_in" />
    public static bool In   (this string? value,                        IEnumerable<string?>? coll, bool matchCase ) => FilledInHelper.In(value, coll, matchCase);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T       value,                 params IEnumerable<T>?       coll)                  => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T       value,                 params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T?      value,                 params IEnumerable<T>?       coll) where T : struct => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T?      value,                 params IEnumerable<T?>?      coll) where T : struct => FilledInHelper.In(value, coll);
    
    /// <inheritdoc cref="_contains" />
    public static bool Contains(this IEnumerable<string?>? source, string? match, bool matchCase = false) => ExistenceUtil.Contains(source, match, matchCase);
}