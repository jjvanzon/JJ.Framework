```cs
    public static string Coalesce(SB? sb, string? fallback, string? fallback2) => CoalesceSBToText(sb, CoalesceTwoTexts(fallback, fallback2));
    public static string Coalesce   (     SB?     sb,   string? fallback, string? fallback2, bool trimSpace)  => CoalesceSBToText      (sb,   CoalesceTwoTexts      (fallback, fallback2, trimSpace), trimSpace);

    public static  string CoalesceText     (string? text)                         => HasText    (text) ? text      : text ?? ""   ;
    public static  SB     CoalesceSB       (SB?     sb  )                         => HasSB      (sb  ) ? sb        : sb   ?? new();
    public static  T      CoalesceVal      <T>(T    val ) where T : struct        => HasVal     (val ) ? val       : default      ;
    public static  T      CoalesceValNully <T>(T?   val ) where T : struct        => HasValNully(val ) ? val.Value : default      ;
    public static  T      CoalesceObject   <T>(T?   obj ) where T : class, new()  => HasObject(obj ) ? obj : new T();
```