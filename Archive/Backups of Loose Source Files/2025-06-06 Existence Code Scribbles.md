

```cs
    public static string Coalesce(SB? sb, string? fallback, string? fallback2) => CoalesceSBToText(sb, CoalesceTwoTexts(fallback, fallback2));
    public static string Coalesce   (     SB?     sb,   string? fallback, string? fallback2, bool trimSpace)  => CoalesceSBToText      (sb,   CoalesceTwoTexts      (fallback, fallback2, trimSpace), trimSpace);
```