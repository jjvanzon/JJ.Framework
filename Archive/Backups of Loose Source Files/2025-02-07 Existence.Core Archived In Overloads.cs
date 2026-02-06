    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         spaceMatters, [Implic(Reason=NameOvl)]int dum=0, params IEnumerable<string?>? coll) => InUtil.In(value, coll, spaceMatters, dum);
    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool         spaceMatters,  bool         caseMatters, [Implic(Reason=NameOvl)]int dum=0, params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
    /// <inheritdoc cref="_in" />
    public static bool In(     string? value, bool         spaceMatters, [Implic(Reason=NameOvl)]int dum=0, params IEnumerable<string?>? coll) => InUtil.In(value, coll, spaceMatters, dum);
    /// <inheritdoc cref="_in" />
    public static bool In(     string? value, bool         spaceMatters,  bool         caseMatters, [Implic(Reason=NameOvl)]int dum=0, params IEnumerable<string?>? coll) => InUtil.In(value, coll, caseMatters, spaceMatters);
