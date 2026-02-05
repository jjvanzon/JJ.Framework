// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_in" />
public static class InExtensions
{
    // Text

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value,                                                        params IEnumerable<string?>? coll) => InUtil.In(value, coll);

    // Flags in Front

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, CaseMatters  caseMatters,                              params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         caseMatters,                              params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, CaseMatters  caseMatters,   SpaceMatters spaceMatters, params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, CaseMatters  caseMatters,   bool         spaceMatters, params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         caseMatters,   SpaceMatters spaceMatters, params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         caseMatters,   bool         spaceMatters, params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    
    // Flags in Front / Swap Parameters

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, SpaceMatters spaceMatters,                             params IEnumerable<string?>? coll) => InUtil.In(value, coll, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         spaceMatters, [Implic(Reason=NameOvl)]int dum=0, params IEnumerable<string?>? coll) => InUtil.In(value, coll, spaceMatters, dum);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         spaceMatters,                                    IEnumerable<string?>? coll, [Implic(Reason=NameOvl)]int dum=0) => InUtil.In(value, coll, spaceMatters, dum);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, SpaceMatters spaceMatters,  CaseMatters  caseMatters,  params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, SpaceMatters spaceMatters,  bool         caseMatters,  params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         spaceMatters,  CaseMatters  caseMatters,  params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    
    // Flags in Back

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         spaceMatters,  bool         caseMatters, IEnumerable<string?>? coll, [Implic(Reason=NameOvl)]int dum=0) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         spaceMatters,  bool         caseMatters, [Implic(Reason=NameOvl)]int dum=0, params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, CaseMatters  caseMatters                            ) => InUtil.In(value, coll, caseMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool         caseMatters                            ) => InUtil.In(value, coll, caseMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, CaseMatters  caseMatters,  SpaceMatters spaceMatters) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool         caseMatters,  SpaceMatters spaceMatters) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, CaseMatters  caseMatters,  bool         spaceMatters) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool         caseMatters,  bool         spaceMatters) => InUtil.In(value, coll, caseMatters, spaceMatters);
        
    // Flags in Back / Parameters Swapped

    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters                           ) => InUtil.In(value, coll, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool         spaceMatters, [Implic(Reason=NameOvl)]int dum=0) => InUtil.In(value, coll, spaceMatters, dum);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, CaseMatters caseMatters  ) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool         spaceMatters, CaseMatters caseMatters  ) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, bool        caseMatters  ) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, IEnumerable<string?>? coll, bool         spaceMatters, bool        caseMatters, [Implic(Reason=NameOvl)]int dum=0) => InUtil.In(value, coll, caseMatters, spaceMatters);


    // Values and Objects

    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T  value, params IEnumerable<T>?  coll)                  => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T  value, params IEnumerable<T?>? coll) where T : struct => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T? value, params IEnumerable<T>?  coll) where T : struct => FilledInHelper.In(value, coll);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(this T? value, params IEnumerable<T?>? coll) where T : struct => FilledInHelper.In(value, coll);
}