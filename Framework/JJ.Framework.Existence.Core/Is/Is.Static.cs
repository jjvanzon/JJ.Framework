// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

public static partial class FilledInHelper
{
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b                                                                            ) => IsUtil.Is(a, b                            );
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, CaseMatters  caseMatters                                                  ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, bool         caseMatters                                                  ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, SpaceMatters spaceMatters                                                 ) => IsUtil.Is(a, b, spaceMatters              );
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, bool         spaceMatters, [Implic(Reason = OverloadByName)] int dummy = 0) => IsUtil.Is(a, b, spaceMatters: spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, CaseMatters  caseMatters,  SpaceMatters spaceMatters                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, CaseMatters  caseMatters,  bool         spaceMatters                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, bool         caseMatters,  SpaceMatters spaceMatters                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, SpaceMatters spaceMatters, CaseMatters  caseMatters                       ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, SpaceMatters spaceMatters, bool         caseMatters                       ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, bool         spaceMatters, CaseMatters  caseMatters                       ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     string? a, string? b, bool         caseMatters,  bool         spaceMatters                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     CaseMatters  caseMatters,                             string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />
    public static bool Is(     bool         caseMatters,                             string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />
    public static bool Is(     SpaceMatters spaceMatters,                            string? a, string? b                      ) => IsUtil.Is(a, b, spaceMatters              );
    /// <inheritdoc cref="_is" />
    public static bool Is(     bool         spaceMatters, string? a, string? b, [Implic(Reason = OverloadByName)] int dummy = 0) => IsUtil.Is(a, b, spaceMatters: spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     CaseMatters  caseMatters,  SpaceMatters spaceMatters, string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     CaseMatters  caseMatters,  bool         spaceMatters, string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     bool         caseMatters,  SpaceMatters spaceMatters, string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     SpaceMatters spaceMatters, CaseMatters  caseMatters , string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     SpaceMatters spaceMatters, bool         caseMatters , string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     bool         spaceMatters, CaseMatters  caseMatters , string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    public static bool Is(     bool         caseMatters,  bool         spaceMatters, string? a, string? b                      ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
}