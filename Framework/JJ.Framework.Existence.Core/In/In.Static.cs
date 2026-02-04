namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_in" />
    public static bool In(string? value,                                                                IEnumerable<string?>? coll) => InUtil.In(value, coll);

    // Flags in Front

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, CaseMatters  caseMatters,                                params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool         caseMatters,                                params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value,                             SpaceMatters spaceMatters,   params IEnumerable<string?>? coll) => InUtil.In(value, coll, spaceMatters);
    /// <inheritdoc cref="_in" />
    // ReSharper disable once MethodOverloadWithOptionalParameter
    public static bool In(string? value,                             bool         spaceMatters,          IEnumerable<string?>? coll, [Implic(Reason = NameOvl)] int dummy = 1) => InUtil.In(value, coll, spaceMatters, dummy);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, CaseMatters  caseMatters,   SpaceMatters spaceMatters,   params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, CaseMatters  caseMatters,   bool         spaceMatters,   params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool         caseMatters,   SpaceMatters spaceMatters,   params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool caseMatters = default, bool spaceMatters = default, params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);

    // Flags in Front / Swap Parameters

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, SpaceMatters spaceMatters,  CaseMatters  caseMatters,    params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, SpaceMatters spaceMatters,  bool         caseMatters,    params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool         spaceMatters,  CaseMatters  caseMatters,    params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);

    // Flags in Back
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, CaseMatters  caseMatters                            ) => InUtil.In(value, coll, caseMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool         caseMatters                            ) => InUtil.In(value, coll, caseMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll,                            SpaceMatters spaceMatters) => InUtil.In(value, coll, spaceMatters);
    /// <inheritdoc cref="_in" />
    // ReSharper disable once MethodOverloadWithOptionalParameter
    public static bool In(string? value, IEnumerable<string?>? coll,                            bool         spaceMatters, [Implic(Reason = NameOvl)] int dummy = 1) => InUtil.In(value, coll, spaceMatters, dummy);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, CaseMatters  caseMatters,  SpaceMatters spaceMatters) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, CaseMatters  caseMatters,  bool         spaceMatters) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool         caseMatters,  SpaceMatters spaceMatters) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool         caseMatters,  bool         spaceMatters) => InUtil.In(value, coll, caseMatters, spaceMatters);

    // Flags in Back / Swap Parameters

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, CaseMatters  caseMatters ) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, bool         spaceMatters, CaseMatters  caseMatters ) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, IEnumerable<string?>? coll, SpaceMatters spaceMatters, bool         caseMatters ) => InUtil.In(value, coll, caseMatters, spaceMatters);

    // Values and Objects

    /// <inheritdoc cref="_in" />
    public static bool In<T>(T    value, IEnumerable<T>?       coll)                  => coll?.Contains(value) ?? false;
    /// <inheritdoc cref="_in" />
    public static bool In<T>(T    value, IEnumerable<T?>?      coll) where T : struct => coll?.Contains(value) ?? false;
    /// <inheritdoc cref="_in" />
    public static bool In<T>(T?   value, IEnumerable<T>?       coll) where T : struct => value.HasValue && (coll?.Contains(value.Value) ?? false);
    /// <inheritdoc cref="_in" />
    public static bool In<T>(T?   value, IEnumerable<T?>?      coll) where T : struct => coll?.Contains(value) ?? false;
}