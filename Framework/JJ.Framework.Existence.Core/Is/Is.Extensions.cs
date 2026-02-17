// ReSharper disable MethodOverloadWithOptionalParameter
namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_is" />
public static class IsExtensions
{
    // Flags in Back

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b                                                                               ) => IsUtil.Is(a, b                            );
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, CaseMatters  caseMatters                                                     ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, bool         caseMatters                                                     ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, CaseMatters  caseMatters,  SpaceMatters spaceMatters                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, CaseMatters  caseMatters,  bool         spaceMatters                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, bool         caseMatters,  SpaceMatters spaceMatters                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, bool         caseMatters,  bool         spaceMatters                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    
    // Flags in Back / Swapped Parametrs

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters                                                    ) => IsUtil.Is(a, b, spaceMatters              );
    /// <inheritdoc cref="_is" />                                                                                                 
    // ReSharper disable once UnusedParameter.Global
    public static bool Is(this string? a, string? b, bool         spaceMatters,                          NameOvl ovl = default    ) => IsUtil.Is(a, b, spaceMatters: spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters, CaseMatters  caseMatters                          ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, SpaceMatters spaceMatters, bool         caseMatters                          ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, string? b, bool         spaceMatters, CaseMatters  caseMatters                          ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    // ReSharper disable once UnusedParameter.Global
    public static bool Is(this string? a, string? b, bool         spaceMatters, bool         caseMatters, NameOvl ovl = default   ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    
    // Flags in Front

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, CaseMatters  caseMatters,                             string? b                         ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, bool         caseMatters,                             string? b                         ) => IsUtil.Is(a, b, caseMatters               );
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, CaseMatters  caseMatters,  SpaceMatters spaceMatters, string? b                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, CaseMatters  caseMatters,  bool         spaceMatters, string? b                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, bool         caseMatters,  SpaceMatters spaceMatters, string? b                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, bool         caseMatters,  bool         spaceMatters, string? b                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);

    // Flags in Front / Swapped Parameters

    /// <inheritdoc cref="_is" />
    public static bool Is(this string? a, SpaceMatters spaceMatters,                            string? b                         ) => IsUtil.Is(a, b, spaceMatters              );
    /// <inheritdoc cref="_is" />                                                                                                 
    // ReSharper disable once UnusedParameter.Global
    public static bool Is(this string? a, bool         spaceMatters,                            string? b, NameOvl ovl = default  ) => IsUtil.Is(a, b, spaceMatters: spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, SpaceMatters spaceMatters, CaseMatters  caseMatters,  string? b                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, SpaceMatters spaceMatters, bool         caseMatters,  string? b                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />                                                                                                 
    public static bool Is(this string? a, bool         spaceMatters, CaseMatters  caseMatters,  string? b                         ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
    /// <inheritdoc cref="_is" />
    // ReSharper disable once UnusedParameter.Global
    public static bool Is(this string? a, bool         spaceMatters, bool         caseMatters,  string? b, NameOvl ovl = default  ) => IsUtil.Is(a, b, caseMatters,  spaceMatters);
}