namespace JJ.Framework.Existence.Core;
using SB = StringBuilder;

/// <inheritdoc cref="_existencecore"/>
public static partial class FilledInHelper
{
    // 1 Arg
    
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text)                  => CoalesceText     (text);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb  )                  => CoalesceSB       (sb  );

    // 2 Args

    /// <inheritdoc cref="_coalesce" /> 
    public static string Coalesce   (     string? text, string? fallback                           ) => CoalesceTwoTexts    (text, fallback              );
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback                           ) => CoalesceTextAndSB   (text, fallback              );
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback                           ) => CoalesceSBAndText   (sb,   fallback              );
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback                           ) => CoalesceTwoSBs      (sb,   fallback              );
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, bool         spaceMatters) => CoalesceTwoTexts    (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, bool         spaceMatters) => CoalesceTextAndSB   (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, bool         spaceMatters) => CoalesceSBAndText   (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, bool         spaceMatters) => CoalesceTwoSBs      (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, SpaceMatters spaceMatters) => CoalesceTwoTexts    (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, SpaceMatters spaceMatters) => CoalesceTextAndSB   (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, SpaceMatters spaceMatters) => CoalesceSBAndText   (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SpaceMatters spaceMatters) => CoalesceTwoSBs      (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, string? text, string? fallback) => CoalesceTwoTexts    (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, string? text, SB?     fallback) => CoalesceTextAndSB   (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, SB?     sb,   string? fallback) => CoalesceSBAndText   (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     bool         spaceMatters, SB?     sb,   SB?     fallback) => CoalesceTwoSBs      (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, string? text, string? fallback) => CoalesceTwoTexts    (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, string? text, SB?     fallback) => CoalesceTextAndSB   (text, fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, SB?     sb,   string? fallback) => CoalesceSBAndText   (sb,   fallback, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SpaceMatters spaceMatters, SB?     sb,   SB?     fallback) => CoalesceTwoSBs      (sb,   fallback, spaceMatters);

    // 3 Args
    
    /// <inheritdoc cref="_coalesce" /> 
    public static string Coalesce   (     string? text, string? fallback, string? fallback2                           ) => CoalesceTwoTexts (text, CoalesceTwoTexts (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, string? fallback2                           ) => CoalesceTwoTexts (text, CoalesceSBAndText(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, SB?     fallback2                           ) => CoalesceTwoTexts (text, CoalesceTextAndSB(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, SB?     fallback2                           ) => CoalesceTextAndSB(text, CoalesceTwoSBs   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, string? fallback2                           ) => CoalesceSBAndText(sb,   CoalesceTwoTexts (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, SB?     fallback2                           ) => CoalesceSBAndText(sb,   CoalesceTextAndSB(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   SB?     fallback, string? fallback2                           ) => CoalesceSBAndText(sb,   CoalesceSBAndText(fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SB?     fallback2                           ) => CoalesceTwoSBs   (sb,   CoalesceTwoSBs   (fallback, fallback2));
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, string? fallback2, bool         spaceMatters) => CoalesceTwoTexts (text, CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTwoTexts (text, CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, string? fallback2, bool         spaceMatters) => CoalesceTwoTexts (text, CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTextAndSB(text, CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, string? fallback2, bool         spaceMatters) => CoalesceSBAndText(sb,   CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, SB?     fallback2, bool         spaceMatters) => CoalesceSBAndText(sb,   CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   SB?     fallback, string? fallback2, bool         spaceMatters) => CoalesceSBAndText(sb,   CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTwoSBs   (sb,   CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts (text, CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, string? fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts (text, CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts (text, CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     string? text, SB?     fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTextAndSB(text, CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText(sb,   CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   string? fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText(sb,   CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SB?     sb,   SB?     fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText(sb,   CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SB?     sb,   SB?     fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTwoSBs   (sb,   CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, string? text, string? fallback, string? fallback2) => CoalesceTwoTexts (text, CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, string? text, string? fallback, SB?     fallback2) => CoalesceTwoTexts (text, CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, string? text, SB?     fallback, string? fallback2) => CoalesceTwoTexts (text, CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, string? text, SB?     fallback, SB?     fallback2) => CoalesceTextAndSB(text, CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, SB?     sb,   string? fallback, string? fallback2) => CoalesceSBAndText(sb,   CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, SB?     sb,   string? fallback, SB?     fallback2) => CoalesceSBAndText(sb,   CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     bool         spaceMatters, SB?     sb,   SB?     fallback, string? fallback2) => CoalesceSBAndText(sb,   CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     bool         spaceMatters, SB?     sb,   SB?     fallback, SB?     fallback2) => CoalesceTwoSBs   (sb,   CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, string? text, string? fallback, string? fallback2) => CoalesceTwoTexts (text, CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, string? text, string? fallback, SB?     fallback2) => CoalesceTwoTexts (text, CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, string? text, SB?     fallback, string? fallback2) => CoalesceTwoTexts (text, CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, string? text, SB?     fallback, SB?     fallback2) => CoalesceTextAndSB(text, CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, SB?     sb,   string? fallback, string? fallback2) => CoalesceSBAndText(sb,   CoalesceTwoTexts (fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, SB?     sb,   string? fallback, SB?     fallback2) => CoalesceSBAndText(sb,   CoalesceTextAndSB(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (     SpaceMatters spaceMatters, SB?     sb,   SB?     fallback, string? fallback2) => CoalesceSBAndText(sb,   CoalesceSBAndText(fallback, fallback2, spaceMatters), spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (     SpaceMatters spaceMatters, SB?     sb,   SB?     fallback, SB?     fallback2) => CoalesceTwoSBs   (sb,   CoalesceTwoSBs   (fallback, fallback2, spaceMatters), spaceMatters);

    // N Args

    /// <inheritdoc cref="_coalesce" /> 
    public static string Coalesce   (                                    params IEnumerable<string?>? fallbacks   )                  => CoalesceManyTexts  (fallbacks);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (bool                  spaceMatters, params IEnumerable<string?>? fallbacks   )                  => CoalesceManyTexts  (fallbacks, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (SpaceMatters          spaceMatters, params IEnumerable<string?>? fallbacks   )                  => CoalesceManyTexts  (fallbacks, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (                                    params IEnumerable<SB?>?     fallbacks   )                  => CoalesceManySBs    (fallbacks              );
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (bool                  spaceMatters, params IEnumerable<SB?>?     fallbacks   )                  => CoalesceManySBs    (fallbacks, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (SpaceMatters          spaceMatters, params IEnumerable<SB?>?     fallbacks   )                  => CoalesceManySBs    (fallbacks, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (IEnumerable<string?>? fallbacks,    bool                         spaceMatters)                  => CoalesceManyTexts  (fallbacks, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce   (IEnumerable<string?>? fallbacks,    SpaceMatters                 spaceMatters)                  => CoalesceManyTexts  (fallbacks, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (IEnumerable<SB?>?     fallbacks,    bool                         spaceMatters)                  => CoalesceManySBs    (fallbacks, spaceMatters);
    /// <inheritdoc cref="_coalesce" />
    public static SB     Coalesce   (IEnumerable<SB?>?     fallbacks,    SpaceMatters                 spaceMatters)                  => CoalesceManySBs    (fallbacks, spaceMatters);
}

