// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_is" />
public static class IsExtensions
{
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b                                                                            ) => IsUtil.Is(a, b                            );
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, CaseMatters  caseMatters                                                  ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool         caseMatters                                                  ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters                                                 ) => IsUtil.Is(a, b, spaceMatters              );
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool         spaceMatters, [Implic(Reason = OverloadByName)] int dummy = 0) => IsUtil.Is(a, b, spaceMatters: spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, CaseMatters  caseMatters,  SpaceMatters spaceMatters                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, CaseMatters  caseMatters,  bool         spaceMatters                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool         caseMatters,  SpaceMatters spaceMatters                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters, CaseMatters  caseMatters                       ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters, bool         caseMatters                       ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool         spaceMatters, CaseMatters  caseMatters                       ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, bool         caseMatters,  bool         spaceMatters                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, CaseMatters  caseMatters,                             string? b                      ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, bool         caseMatters,                             string? b                      ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, SpaceMatters spaceMatters,                            string? b                      ) => IsUtil.Is(a, b, spaceMatters              );
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, bool         spaceMatters, string? b, [Implic(Reason = OverloadByName)] int dummy = 0) => IsUtil.Is(a, b, spaceMatters: spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, CaseMatters  caseMatters,  SpaceMatters spaceMatters, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, CaseMatters  caseMatters,  bool         spaceMatters, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, bool         caseMatters,  SpaceMatters spaceMatters, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, SpaceMatters spaceMatters, CaseMatters  caseMatters,  string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, SpaceMatters spaceMatters, bool         caseMatters,  string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, bool         spaceMatters, CaseMatters  caseMatters,  string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, bool         caseMatters,  bool         spaceMatters, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
}