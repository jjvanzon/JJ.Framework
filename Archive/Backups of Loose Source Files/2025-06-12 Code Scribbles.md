
```cs
        // TODO: Alternative doc to consider:

        /// <summary>
        /// Simple helpers and extensions for flag operations on ints and [Flags] enums:<br/>
        /// – <c>HasFlag</c> to ask "is this bit or flag set?"<br/>
        /// – <c>SetFlag</c> / <c>ClearFlag</c> for toggling a single flag<br/>
        /// – <c>SetFlags</c> / <c>ClearFlags</c> when you’ve got a collection of flags<br/>
        /// Works on both raw integer masks and enum-typed flags, so you never typo your bit math again.
        /// </summary>
        public struct _flaggingalt { }
```

```xml

  <PropertyGroup>
    <!--<NoWarn>$(NoWarn);1701</NoWarn>-->
    <!--<NoWarn>$(NoWarn);1702</NoWarn>-->
    <!--<NoWarn>$(NoWarn);CA1806</NoWarn>-->
    <!--<NoWarn>$(NoWarn);CS0219</NoWarn>-->
    <!--<NoWarn>$(NoWarn);CS0618</NoWarn>-->
  </PropertyGroup>
```

```cs
        
        ///// <summary>
        ///// </summary>
        //public struct _coalesce { }
        
        ///// <summary>
        ///// </summary>
        //public struct _contains { }
        
        ///// <summary>
        ///// </summary>
        //public struct _has { }
        
        ///// <summary>
        ///// </summary>
        //public struct _in { }
        
        ///// <summary>
        ///// </summary>
        //public struct _is { }
        
        ///// <summary>
        ///// </summary>
        //public struct _isnully { }
```


```cs
        /// <summary>
        /// Central static APIs for null‐or‐empty checks, fallback coalescing, containment, and loose comparisons:
        /// <list type="bullet">
        ///   <item><c>Has</c> / <c>IsNully</c> – null‐or‐empty tests for strings, numbers, collections, enums</item>
        ///   <item><c>Coalesce</c> – first non‐nully value picker (beyond <c>??</c>)</item>
        ///   <item><c>Contains</c> / <c>In</c> – membership tests in collections or value sets</item>
        ///   <item><c>Is</c> – case/trim‐insensitive or loose equality checks</item>
        /// </list>
        /// Use these to replace scattered guard logic with clear, consistent method calls.
        /// </summary>
        public static class _existencecore { }
```

```cs
    
    // Super Magic Resolvers
    
    // (Temporary until that of AccessCore is migrated, but it's dependencies get

        //method = type.GetMethod(name, bindingFlags);
        //method = type.GetMethod(name, bindingFlags, null, argTypes, null);
```

```cs


    //static IsStaticTests()
    //{
    //   StaticEvent += StaticEventHandler;
    //}

    //static void StaticEventHandler(object? sender, EventArgs e) { }

```

```bash
del "$(OutputPath)JJ.Framework.PlatformCompatibility.Core.dll"
```

```cs
public string Name => Coalesce(_name, _config.Name, DefaultName);
if (!Has(text)) return text;
````

```cs
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceSBAndText     (SB?     sb,   string? fallback                           ) => HasSB      (sb                ) ? $"{sb}" : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceSBAndText     (SB?     sb,   string? fallback, bool         spaceMatters) => HasSB      (sb,   spaceMatters) ? $"{sb}" : CoalesceText(fallback);
    /// <inheritdoc cref="_coalesce" />
    public static string CoalesceSBAndText     (SB?     sb,   string? fallback, SpaceMatters spaceMatters) => HasSB      (sb,   spaceMatters) ? $"{sb}" : CoalesceText(fallback);

    // TODO: Variants with IEnumerable<string> (non-nullable strings) for lack of covariance?
    public static bool In(string? value, params IEnumerable<string?>? coll) ...

```

```cs
    public static StringComparison IgnoreCaseToStringComparison(this bool ignoreCase)
    {
        return ignoreCase ? OrdinalIgnoreCase : Ordinal;
    }

    public static StringComparison ToStringComparison(this MatchCase matchCase) => Ordinal;


  /// <inheritdoc cref="_in" />
  public static bool In(string? value, bool spaceMatters, int dummy = 1, params IEnumerable<string?>? coll) 
      => ExistenceUtil.In(value, coll, spaceMatters, dummy);


    /// <inheritdoc cref="_in" />
    public static bool In(this string? value, bool spaceMatters, int dummy = 1, params IEnumerable<string?>? coll) 
        => ExistenceUtil.In(value, coll, spaceMatters, dummy);


    public const string MatchCaseWarning =
        "BREAKING CHANGE: ignoreCase replaced by matchCase! " +
        "Where ignoreCase: false, matchCase should now be true!";

        /// <b>Reason: clear separation between match and collection.</b>


    ///// <inheritdoc cref="_in" />
    //public static bool In(string? value, params IEnumerable<string?>? coll) => coll.Contains(value, ignoreCase: true);

    ///// <inheritdoc cref="_in" />
    //public static bool In<T>(T value, params IEnumerable<T>? coll) => coll?.Contains(value) ?? false;

    ///// <inheritdoc cref="_in" />
    //public static bool In<T>(T value, params IEnumerable<T?>? coll) where T : struct => coll?.Contains(value) ?? false;

    ///// <inheritdoc cref="_in" />
    //public static bool In<T>(T? value, params IEnumerable<T>? coll) where T : struct
    //    => value.HasValue && (coll?.Contains(value.Value) ?? false);

    ///// <inheritdoc cref="_in" />
    //public static bool In<T>(T? value, params IEnumerable<T?>? coll) where T : struct => coll?.Contains(value) ?? false;

```

### Not Supported: In(x, a, b, c)

```cs
        // Not supported

        // Semantically unclear:
        IsFalse(In("Yellow", "Red", "Green", "Blue"));
        IsTrue (In("GREEN" , "Red", "Green", "Blue"));

        // Not semantically clear; not supported
        IsTrue (In("Green",   "Red",  "Green", "Blue"));
        IsTrue (In(" Green ", "Red", "Green",  "Blue"));


      IsTrue(  In(a,   a, NullText,   b  )); // Semantically unclear: not supported.
      IsTrue(  In(b,   a, Empty,      b  )); // Semantically unclear: not supported.
      IsTrue(  In(a,   a, NullyEmpty, b  )); // Semantically unclear: not supported.
      IsTrue(  In(b,   a, Space,      b  )); // Semantically unclear: not supported.
      IsTrue(  In(a,   a, NullySpace, b  )); // Semantically unclear: not supported.
      
      IsTrue (In(NullText,     a, b, NullText  )); // Semantically unclear: not supported.
      IsTrue (In(Empty,        a, b, NullText  )); // Semantically unclear: not supported.
      IsTrue (In(Space,        a, b, NullText  )); // Semantically unclear: not supported.
      IsTrue (In(NullyEmpty,   a, b, NullText  )); // Semantically unclear: not supported.
      IsTrue (In(NullySpace,   a, b, NullText  )); // Semantically unclear: not supported.
      IsTrue (In(NullText,     a, Empty, b  )); // Semantically unclear: not supported.
      IsTrue (In(Empty,        a, Empty, b  )); // Semantically unclear: not supported.
      IsTrue (In(Space,        a, Empty, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullyEmpty,   a, Empty, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullySpace,   a, Empty, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullText,     a, NullyEmpty, b  )); // Semantically unclear: not supported.
      IsTrue (In(Empty,        a, NullyEmpty, b  )); // Semantically unclear: not supported.
      IsTrue (In(Space,        a, NullyEmpty, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullyEmpty,   a, NullyEmpty, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullySpace,   a, NullyEmpty, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullText,     Space, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(Empty,        Space, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(Space,        Space, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullyEmpty,   Space, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullySpace,   Space, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullText,     NullySpace, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(Empty,        NullySpace, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(Space,        NullySpace, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullyEmpty,   NullySpace, a, b  )); // Semantically unclear: not supported.
      IsTrue (In(NullySpace,   NullySpace, a, b  )); // Semantically unclear: not supported.
      IsFalse(In(NullText,     a, b  )); // Semantically unclear: not supported.
      IsFalse(In(Empty,        a, b  )); // Semantically unclear: not supported.
      IsFalse(In(NullyEmpty,   a, b  )); // Semantically unclear: not supported.
      IsFalse(In(Space,        a, b  )); // Semantically unclear: not supported.
      IsFalse(In(NullySpace,   a, b  )); // Semantically unclear: not supported.

      IsTrue (  In(a,   a, b, c  )); // Semantically unclear: not supported.
      IsTrue (  In(b,   a, b, c  )); // Semantically unclear: not supported.
      IsFalse(d.In(   [ a, b, c ])); // Semantically unclear: not supported.
      IsFalse(  In(d,   a, b, c  )); // Semantically unclear: not supported.

      IsTrue (  In(1,   1, 2, 3  )); // Semantically unclear: not supported.
      IsTrue (  In(2,   1, 2, 3  )); // Semantically unclear: not supported.
      IsFalse(  In(4,   1, 2, 3  )); // Semantically unclear: not supported.
```

### Not Supported: Flags in the front
    
```cs
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, MatchCase matchCase, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool matchCase, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase);

    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, MatchCase matchCase, SpaceMatters spaceMatters, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);

    /// <inheritdoc cref="_in" />
    public static bool In(string? value, SpaceMatters spaceMatters, MatchCase matchCase, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);
    
    /// <inheritdoc cref="_in" />
    public static bool In(string? value, bool matchCase = default, bool spaceMatters = default, params IEnumerable<string?>? coll)
        => ExistenceUtil.In(value, coll, matchCase, spaceMatters);


      IsTrue (In("GREEN", matchCase: false,   "Red", "Green", "Blue"  ));
      IsTrue (In("GREEN", matchCase: false, [ "Red", "Green", "Blue" ]));
      IsFalse(In("GREEN", matchCase,         "Red", "Green", "Blue"   ));
      IsFalse(In("GREEN", matchCase: true,   "Red", "Green", "Blue"   ));
      IsFalse(In("GREEN", matchCase,       [ "Red", "Green", "Blue" ] ));
      IsFalse(In("GREEN", matchCase: true, [ "Red", "Green", "Blue" ] ));
      IsTrue (In("Green", matchCase,          "Red", "Green", "Blue"  ));
      IsTrue (In("Green", matchCase: true,    "Red", "Green", "Blue"  ));
      IsTrue (In("Green", matchCase,        [ "Red", "Green", "Blue" ]));
      IsTrue (In("Green", matchCase: true,  [ "Red", "Green", "Blue" ]));

      IsTrue (In("Green", spaceMatters,   "Red",  "Green",  "Blue"         ));
      IsTrue (In("Green", spaceMatters, [ "Red",  "Green",  "Blue" ]       ));
      IsFalse(In(" Green ", spaceMatters,   "Red", "Green",   "Blue"       )); // TODO: Too weird? Don't support?
      IsFalse(In(" Green ", spaceMatters, [ "Red", "Green",   "Blue" ]     ));
      IsFalse(In("Green", spaceMatters,   "Red", " Green ", "Blue"         )); // TODO: Flag in front unexpected? Don't support?
      IsFalse(In("Green", spaceMatters, [ "Red", " Green ", "Blue" ]       ));

        // Overload clashes
        IsTrue ("Green"  .In(spaceMatters: false,   "Red",  "Green",  "Blue"  ));
        IsTrue ("Green"  .In(spaceMatters: false, [ "Red",  "Green",  "Blue" ]));
        IsTrue ("Green"  .In(spaceMatters: true ,   "Red",  "Green",  "Blue"  ));
        IsTrue ("Green"  .In(spaceMatters: true , [ "Red",  "Green",  "Blue" ]));

```