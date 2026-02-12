namespace JJ.Framework.Existence.Core;
using SB = StringBuilder;

/// <inheritdoc cref="_coalesce"/>
public static partial class CoalesceExtensions
{
          // [Prio] attributes:
          // These overloads clash: first.Coalesce(others), List.Coalesce(), and string.Coalesce().
          // Prio(1) on IEnumerable<T> for List.Coalesce() else List becomes the first arg in (first, others).
          // Prio(2) on string.Coalesce() makes it win over IEnumerable<char> in string-specific calls.
          
          // 1 Arg

          /// <inheritdoc cref="_coalesce" />
[Prio(2)] public static string Coalesce   (this string? text)                  => CoalesceText     (text);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb  )                  => CoalesceSB       (sb);

          // 2 Args
          
          /// <inheritdoc cref="_coalesce" /> 
          public static string Coalesce   (this string? text, string? fallback                           ) => CoalesceTwoTexts      (text, fallback);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback                           ) => CoalesceTextAndSB     (text, fallback);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback                           ) => CoalesceSBAndText     (sb,   fallback);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   SB?     fallback                           ) => CoalesceTwoSBs        (sb,   fallback);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this object? obj,  string? fallback)                            => CoalesceObjectToText  (obj,  fallback);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, string? fallback, bool         spaceMatters) => CoalesceTwoTexts      (text, fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback, bool         spaceMatters) => CoalesceTextAndSB     (text, fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback, bool         spaceMatters) => CoalesceSBAndText     (sb,   fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   SB?     fallback, bool         spaceMatters) => CoalesceTwoSBs        (sb,   fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, string? fallback, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback, SpaceMatters spaceMatters) => CoalesceTextAndSB     (text, fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SpaceMatters spaceMatters) => CoalesceTwoSBs        (sb,   fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, bool         spaceMatters, string? fallback) => CoalesceTwoTexts      (text, fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, bool         spaceMatters, SB?     fallback) => CoalesceTextAndSB     (text, fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   bool         spaceMatters, string? fallback) => CoalesceSBAndText     (sb,   fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   bool         spaceMatters, SB?     fallback) => CoalesceTwoSBs        (sb,   fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SpaceMatters spaceMatters, string? fallback) => CoalesceTwoTexts      (text, fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SpaceMatters spaceMatters, SB?     fallback) => CoalesceTextAndSB     (text, fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   SpaceMatters spaceMatters, string? fallback) => CoalesceSBAndText     (sb,   fallback, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   SpaceMatters spaceMatters, SB?     fallback) => CoalesceTwoSBs        (sb,   fallback, spaceMatters);

          // 3 Args (for text)
          
          /// <inheritdoc cref="_coalesce" />  
          public static string Coalesce   (this string? text, string? fallback, string? fallback2                           ) => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, string? fallback, SB?     fallback2                           ) => CoalesceTwoTexts      (text, CoalesceTextAndSB     (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback, string? fallback2                           ) => CoalesceTwoTexts      (text, CoalesceSBAndText     (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback, SB?     fallback2                           ) => CoalesceTextAndSB     (text, CoalesceTwoSBs        (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback, string? fallback2                           ) => CoalesceSBAndText     (sb,   CoalesceTwoTexts      (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback, SB?     fallback2                           ) => CoalesceSBAndText     (sb,   CoalesceTextAndSB     (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   SB?     fallback, string? fallback2                           ) => CoalesceSBAndText     (sb,   CoalesceSBAndText     (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SB?     fallback2                           ) => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, string? fallback, string? fallback2, bool         spaceMatters) => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, string? fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTwoTexts      (text, CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback, string? fallback2, bool         spaceMatters) => CoalesceTwoTexts      (text, CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTextAndSB     (text, CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback, string? fallback2, bool         spaceMatters) => CoalesceSBAndText     (sb,   CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback, SB?     fallback2, bool         spaceMatters) => CoalesceSBAndText     (sb,   CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   SB?     fallback, string? fallback2, bool         spaceMatters) => CoalesceSBAndText     (sb,   CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SB?     fallback2, bool         spaceMatters) => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, string? fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, string? fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceTwoTexts      (text, CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SB?     fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTextAndSB     (text, CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   string? fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   SB?     fallback, string? fallback2, SpaceMatters spaceMatters) => CoalesceSBAndText     (sb,   CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   SB?     fallback, SB?     fallback2, SpaceMatters spaceMatters) => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, bool         spaceMatters, string? fallback, string? fallback2) => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, bool         spaceMatters, string? fallback, SB?     fallback2) => CoalesceTwoTexts      (text, CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, bool         spaceMatters, SB?     fallback, string? fallback2) => CoalesceTwoTexts      (text, CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, bool         spaceMatters, SB?     fallback, SB?     fallback2) => CoalesceTextAndSB     (text, CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   bool         spaceMatters, string? fallback, string? fallback2) => CoalesceSBAndText     (sb,   CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   bool         spaceMatters, string? fallback, SB?     fallback2) => CoalesceSBAndText     (sb,   CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   bool         spaceMatters, SB?     fallback, string? fallback2) => CoalesceSBAndText     (sb,   CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   bool         spaceMatters, SB?     fallback, SB?     fallback2) => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SpaceMatters spaceMatters, string? fallback, string? fallback2) => CoalesceTwoTexts      (text, CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SpaceMatters spaceMatters, string? fallback, SB?     fallback2) => CoalesceTwoTexts      (text, CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SpaceMatters spaceMatters, SB?     fallback, string? fallback2) => CoalesceTwoTexts      (text, CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? text, SpaceMatters spaceMatters, SB?     fallback, SB?     fallback2) => CoalesceTextAndSB     (text, CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   SpaceMatters spaceMatters, string? fallback, string? fallback2) => CoalesceSBAndText     (sb,   CoalesceTwoTexts      (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   SpaceMatters spaceMatters, string? fallback, SB?     fallback2) => CoalesceSBAndText     (sb,   CoalesceTextAndSB     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this SB?     sb,   SpaceMatters spaceMatters, SB?     fallback, string? fallback2) => CoalesceSBAndText     (sb,   CoalesceSBAndText     (fallback, fallback2, spaceMatters), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     sb,   SpaceMatters spaceMatters, SB?     fallback, SB?     fallback2) => CoalesceTwoSBs        (sb,   CoalesceTwoSBs        (fallback, fallback2, spaceMatters), spaceMatters);

          // N Args

          /// <inheritdoc cref="_coalesce" />  
[Prio(1)] public static string Coalesce   (this IEnumerable<string?>? fallbacks                           ) => CoalesceManyTexts  (fallbacks);
          /// <inheritdoc cref="_coalesce" />
[Prio(1)] public static string Coalesce   (this IEnumerable<string?>? fallbacks, SpaceMatters spaceMatters) => CoalesceManyTexts  (fallbacks, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
[Prio(1)] public static string Coalesce   (this IEnumerable<string?>? fallbacks, bool         spaceMatters) => CoalesceManyTexts  (fallbacks, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
[Prio(1)] public static SB     Coalesce   (this IEnumerable<SB?>?     fallbacks                           ) => CoalesceManySBs    (fallbacks);
          /// <inheritdoc cref="_coalesce" />
[Prio(1)] public static SB     Coalesce   (this IEnumerable<SB?>?     fallbacks, SpaceMatters spaceMatters) => CoalesceManySBs    (fallbacks, spaceMatters);
          /// <inheritdoc cref="_coalesce" />
[Prio(1)] public static SB     Coalesce   (this IEnumerable<SB?>?     fallbacks, bool         spaceMatters) => CoalesceManySBs    (fallbacks, spaceMatters);

          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? first,                                     params IEnumerable<string?>? fallbacks   )                  => CoalesceManyTexts  (new [] {       first }.Concat(fallbacks ?? [ ]));
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? first, bool                  spaceMatters, params IEnumerable<string?>? fallbacks   )                  => CoalesceManyTexts  (new [] {       first }.Concat(fallbacks ?? [ ]), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? first, SpaceMatters          spaceMatters, params IEnumerable<string?>? fallbacks   )                  => CoalesceManyTexts  (new [] {       first }.Concat(fallbacks ?? [ ]), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     first,                                     params IEnumerable<SB?>?     fallbacks   )                  => CoalesceManySBs    (new [] {       first }.Concat(fallbacks ?? [ ]));
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     first, bool                  spaceMatters, params IEnumerable<SB?>?     fallbacks   )                  => CoalesceManySBs    (new [] {       first }.Concat(fallbacks ?? [ ]), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     first, SpaceMatters          spaceMatters, params IEnumerable<SB?>?     fallbacks   )                  => CoalesceManySBs    (new [] {       first }.Concat(fallbacks ?? [ ]), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? first, IEnumerable<string?>? fallbacks,    bool                         spaceMatters)                  => CoalesceManyTexts  (new [] {       first }.Concat(fallbacks ?? [ ]), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static string Coalesce   (this string? first, IEnumerable<string?>? fallbacks,    SpaceMatters                 spaceMatters)                  => CoalesceManyTexts  (new [] {       first }.Concat(fallbacks ?? [ ]), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     first, IEnumerable<SB?>?     fallbacks,    bool                         spaceMatters)                  => CoalesceManySBs    (new [] {       first }.Concat(fallbacks ?? [ ]), spaceMatters);
          /// <inheritdoc cref="_coalesce" />
          public static SB     Coalesce   (this SB?     first, IEnumerable<SB?>?     fallbacks,    SpaceMatters                 spaceMatters)                  => CoalesceManySBs    (new [] {       first }.Concat(fallbacks ?? [ ]), spaceMatters);
}