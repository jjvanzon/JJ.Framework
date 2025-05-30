### FilledIn Tests

```cs
        IsFalse(FilledInHelper      .Has     (_nullString         ));
        IsFalse(FilledInHelper      .Has     (_nullableEmptyString));
        IsFalse(FilledInHelper      .FilledIn(_nullString         ));
        IsFalse(FilledInHelper      .FilledIn(_nullableEmptyString));

        IsTrue (FilledInHelper      .Has     (_nullableFilledText));
        IsTrue (FilledInHelper      .Has     (_nonNullFilledText ));
        IsTrue (FilledInHelper      .FilledIn(_nullableFilledText));
        IsTrue (FilledInHelper      .FilledIn(_nonNullFilledText ));

        IsTrue (FilledInHelper      .Has     (_nullableWhiteSpace                 ));
        IsFalse(FilledInHelper      .Has     (_nullableWhiteSpace, true           ));
        IsFalse(FilledInHelper      .Has     (_nullableWhiteSpace, trimSpace: true));
        IsTrue (FilledInHelper      .FilledIn(_nullableWhiteSpace                 ));
        IsFalse(FilledInHelper      .FilledIn(_nullableWhiteSpace, true           ));
        IsFalse(FilledInHelper      .FilledIn(_nullableWhiteSpace, trimSpace: true));

        // TODO: I expected trimSpace to be active by default.
        // TODO: Only use single-flag enum: `Has(x, trimSpace)` ?
        // Oh, that only works if trimSpace isn't the default.
        // spaceMatters? `Has(someText, spaceMatters)`

    [TestMethod]
    public void FilledIn_TrimSpace_DefaultFalse()
    {

        IsTrue(Has(_nullableSpace));
        IsFalse(Has(_nullableSpace, true));
        IsFalse(Has(_nullableSpace, trimSpace: true));
        IsTrue(Has(_nonNullSpace));
        IsFalse(Has(_nonNullSpace, true));
        IsFalse(Has(_nonNullSpace, trimSpace: true));
        IsTrue(_nullableSpace.FilledIn());
        IsFalse(_nullableSpace.FilledIn(true));
        IsFalse(_nullableSpace.FilledIn(trimSpace: true));
        IsTrue(_nonNullSpace.FilledIn());
        IsFalse(_nonNullSpace.FilledIn(true));
        IsFalse(_nonNullSpace.FilledIn(trimSpace: true));
        IsTrue(FilledIn(_nullableSpace));
        IsFalse(FilledIn(_nullableSpace, true));
        IsFalse(FilledIn(_nullableSpace, trimSpace: true));
        IsTrue(FilledIn(_nonNullSpace));
        IsFalse(FilledIn(_nonNullSpace, true));
        IsFalse(FilledIn(_nonNullSpace, trimSpace: true));
    }

    [TestMethod]
    public void FilledIn_TrimSpace_DefaultTrue()
    {
        IsFalse(Has(_nullableSpace));
        IsFalse(Has(_nullableSpace, true));
        IsFalse(Has(_nullableSpace, trimSpace: true));
        IsFalse(Has(_nonNullSpace));
        IsFalse(Has(_nonNullSpace, true));
        IsFalse(Has(_nonNullSpace, trimSpace: true));
        IsFalse(_nullableSpace.FilledIn());
        IsFalse(_nullableSpace.FilledIn(true));
        IsFalse(_nullableSpace.FilledIn(trimSpace: true));
        IsFalse(_nonNullSpace.FilledIn());
        IsFalse(_nonNullSpace.FilledIn(true));
        IsFalse(_nonNullSpace.FilledIn(trimSpace: true));
        IsFalse(FilledIn(_nullableSpace));
        IsFalse(FilledIn(_nullableSpace, true));
        IsFalse(FilledIn(_nullableSpace, trimSpace: true));
        IsFalse(FilledIn(_nonNullSpace));
        IsFalse(FilledIn(_nonNullSpace, true));
        IsFalse(FilledIn(_nonNullSpace, trimSpace: true));
    }

```

### FilledInHelper Redundant Collection Overloads

```
using System.Collections;

    // Part of the reason for so many overloads is C#'s best-matching quirks in case of generics.
    // For instance C# will choose a wider concrete type over a more narrow ìnterface.
    // I.e. in case of List<T> it'd rather pick object? than IList<T>.
    // To work around that, an overload with List<T> is specified explicitly and so for other collection types.
    // Also, nullable semantics for value types couldn't be used, unless handle things specifically as `T?` (with a question mark).
    //public static bool FilledIn   ([NotNull]                /*params*/ object?[]? coll )                  => coll is { Length: > 0 };
    //public static bool FilledIn<T>([NotNull]                /*params*/ T      []? coll ) where T : struct => coll is { Length: > 0 };
    //public static bool FilledIn<T>([NotNull]                /*params*/ T?     []? coll ) where T : struct => coll is { Length: > 0 };
    //public static bool FilledIn<T>([NotNull]                List               <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull]                HashSet            <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull]                IList              <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn   ([NotNull]                IList                 ? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull]                ISet               <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull]                ICollection        <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull]                IReadOnlyList      <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull]                IReadOnlyCollection<T>? coll) => coll is { Count: > 0 };

    //public static bool Has        ([NotNull]                /*params*/ object?[]? coll )                  => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                /*params*/ T      []? coll ) where T : struct => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                /*params*/ T?     []? coll ) where T : struct => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                List               <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                HashSet            <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                IList              <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                ISet               <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                ICollection        <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                IReadOnlyList      <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull]                IReadOnlyCollection<T>? coll)   => FilledIn(coll);

    //public static bool IsNully    ([NotNullWhen(false)]      /*params*/ object[]? coll )                  => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      /*params*/ T     []? coll ) where T : struct => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      /*params*/ T?    []? coll ) where T : struct => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      List               <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      HashSet            <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      IList              <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      ISet               <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      ICollection        <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      IReadOnlyList      <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)]      IReadOnlyCollection<T>? coll)   => !FilledIn(coll);

    //public static bool In<T>(     T    value, params             T[]?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    //public static bool In<T>(     T?   value, params             T[]?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T?   value, params             T?[]? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T    value, List               <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    //public static bool In<T>(     T?   value, List               <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T?   value, List               <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T    value, HashSet            <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    //public static bool In<T>(     T?   value, HashSet            <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T?   value, HashSet            <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T    value, IList              <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    //public static bool In<T>(     T?   value, IList              <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T?   value, IList              <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T    value, ISet               <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    //public static bool In<T>(     T?   value, ISet               <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T?   value, ISet               <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T    value, ICollection        <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    //public static bool In<T>(     T?   value, ICollection        <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T?   value, ICollection        <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T    value, IReadOnlyList      <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    //public static bool In<T>(     T?   value, IReadOnlyList      <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T?   value, IReadOnlyList      <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T    value, IReadOnlyCollection<T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    //public static bool In<T>(     T?   value, IReadOnlyCollection<T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(     T?   value, IReadOnlyCollection<T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);

    //public static                    T[] Coalesce<T>(                        T[]? coll,                     T[]? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static List               <T> Coalesce<T>(     List               <T>? coll,  List               <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static HashSet            <T> Coalesce<T>(     HashSet            <T>? coll,  HashSet            <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static IList              <T> Coalesce<T>(     IList              <T>? coll,  IList              <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static ISet               <T> Coalesce<T>(     ISet               <T>? coll,  ISet               <T>? fallback) => Has(coll) ? coll : fallback ?? new HashSet<T>();
    //public static ICollection        <T> Coalesce<T>(     ICollection        <T>? coll,  ICollection        <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static IReadOnlyList      <T> Coalesce<T>(     IReadOnlyList      <T>? coll,  IReadOnlyList      <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static IReadOnlyCollection<T> Coalesce<T>(     IReadOnlyCollection<T>? coll,  IReadOnlyCollection<T>? fallback) => Has(coll) ? coll : fallback ?? [ ];

    //public static string Coalesce   (     List               <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(     List               <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(     List               <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (     HashSet            <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(     HashSet            <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(     HashSet            <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (     IList              <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(     IList              <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(     IList              <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (     ISet               <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(     ISet               <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(     ISet               <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (     ICollection        <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(     ICollection        <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(     ICollection        <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (     IReadOnlyList      <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(     IReadOnlyList      <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(     IReadOnlyList      <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (     IReadOnlyCollection<string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(     IReadOnlyCollection<T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(     IReadOnlyCollection<T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    
    //public static string Coalesce   (     params             string?[]? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(     params             T[]      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(     params             T?[]     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    
```

### FilledInExtensions Redundant Collection Overloads

```
    // Part of the reason for so many overloads is C#'s best-matching quirks in case of generics.
    // For instance C# will choose a wider concrete type over a more narrow ìnterface.
    // I.e. in case of List<T> it'd rather pick object? than IList<T>.
    // To work around that, an overload with List<T> is specified explicitly and so for other collection types.
    // Also, nullable semantics for value types couldn't be used, unless handle things specifically as `T?` (with a question mark).

    //public static bool FilledIn   ([NotNull] this          /*params*/ object?[]? coll )                  => coll is { Length: > 0 };
    //public static bool FilledIn<T>([NotNull] this          /*params*/ T      []? coll ) where T : struct => coll is { Length: > 0 };
    //public static bool FilledIn<T>([NotNull] this          /*params*/ T?     []? coll ) where T : struct => coll is { Length: > 0 };
    //public static bool FilledIn<T>([NotNull] this           List               <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull] this           HashSet            <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull] this           IList              <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull] this           ISet               <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull] this           ICollection        <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull] this           IReadOnlyList      <T>? coll) => coll is { Count: > 0 };
    //public static bool FilledIn<T>([NotNull] this           IReadOnlyCollection<T>? coll) => coll is { Count: > 0 };
    
    //public static bool Has        ([NotNull] this           string? value)                  => FilledIn(value);
    //public static bool Has        ([NotNull] this           string? value, bool trimSpace)  => FilledIn(value, trimSpace);
    //public static bool Has<T>     ([NotNull] this           T       value)                  => FilledIn(value);
    //public static bool Has<T>     ([NotNull] this           T?      value) where T : struct => FilledIn(value);
    //public static bool Has<T>     ([NotNull] this                              T[]? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull] this           List               <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull] this           HashSet            <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull] this           IList              <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull] this           ISet               <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull] this           ICollection        <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull] this           IReadOnlyList      <T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull] this           IReadOnlyCollection<T>? coll)   => FilledIn(coll);
    //public static bool Has<T>     ([NotNull] this           IEnumerable        <T>? coll)   => FilledIn(coll);

    //public static bool IsNully<T> ([NotNullWhen(false)] this object?[]  coll ) where T : struct => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this T      []? coll ) where T : struct => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this T?     []? coll ) where T : struct => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this List               <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this HashSet            <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this IList              <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this ISet               <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this ICollection        <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this IReadOnlyList      <T>? coll)   => !FilledIn(coll);
    //public static bool IsNully<T> ([NotNullWhen(false)] this IReadOnlyCollection<T>? coll)   => !FilledIn(coll);

    //public static bool In<T>(this T    value, params             T[]?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    //public static bool In<T>(this T?   value, params             T[]?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, params             T?[]? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T    value, List               <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    //public static bool In<T>(this T?   value, List               <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, List               <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T    value, HashSet            <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    //public static bool In<T>(this T?   value, HashSet            <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, HashSet            <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T    value, IList              <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false;
    //public static bool In<T>(this T?   value, IList              <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, IList              <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T    value, ISet               <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    //public static bool In<T>(this T?   value, ISet               <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, ISet               <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T    value, ICollection        <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    //public static bool In<T>(this T?   value, ICollection        <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, ICollection        <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T    value, IReadOnlyList      <T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    //public static bool In<T>(this T?   value, IReadOnlyList      <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, IReadOnlyList      <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T    value, IReadOnlyCollection<T>?  comparisons)                  =>                    comparisons?.Contains(value      ) ?? false; 
    //public static bool In<T>(this T?   value, IReadOnlyCollection<T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, IReadOnlyCollection<T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);

    //public static object?[] Coalesce   (this object?[]? coll,  object?[]? fallback )                  => Has(coll) ? coll : fallback ?? [ ];
    //public static T      [] Coalesce<T>(this T      []? coll,  T      []? fallback ) where T : struct => Has(coll) ? coll : fallback ?? [ ];
    //public static T?     [] Coalesce<T>(this T?     []? coll,  T?     []? fallback ) where T : struct => Has(coll) ? coll : fallback ?? [ ];
    //public static List               <T> Coalesce<T>(this List               <T>? coll,  List               <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static HashSet            <T> Coalesce<T>(this HashSet            <T>? coll,  HashSet            <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static IList              <T> Coalesce<T>(this IList              <T>? coll,  IList              <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static ISet               <T> Coalesce<T>(this ISet               <T>? coll,  ISet               <T>? fallback) => Has(coll) ? coll : fallback ?? new HashSet<T>();
    //public static ICollection        <T> Coalesce<T>(this ICollection        <T>? coll,  ICollection        <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static IReadOnlyList      <T> Coalesce<T>(this IReadOnlyList      <T>? coll,  IReadOnlyList      <T>? fallback) => Has(coll) ? coll : fallback ?? [ ];
    //public static IReadOnlyCollection<T> Coalesce<T>(this IReadOnlyCollection<T>? coll,  IReadOnlyCollection<T>? fallback) => Has(coll) ? coll : fallback ?? [ ];

    //public static string Coalesce   (this List               <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(this List               <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(this List               <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (this HashSet            <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(this HashSet            <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(this HashSet            <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (this IList              <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(this IList              <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(this IList              <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (this ISet               <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(this ISet               <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(this ISet               <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (this ICollection        <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(this ICollection        <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(this ICollection        <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (this IReadOnlyList      <string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(this IReadOnlyList      <T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(this IReadOnlyList      <T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);
    //public static string Coalesce   (this IReadOnlyCollection<string?>? fallbacks)                 => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(this IReadOnlyCollection<T>      ? fallbacks)                 => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(this IReadOnlyCollection<T?>     ? fallbacks) where T: struct => Coalesce((IEnumerable<T?>     ?)fallbacks);

    //public static bool In   (this string? value, params string?[]?     comparisons                 ) => comparisons?.Contains(value, ignoreCase: true)        ?? false;
    //public static bool In   (this string? value, string?[]?            comparisons, bool ignoreCase) => comparisons?.Contains(value, ignoreCase      )        ?? false;
    //public static bool In<T>(this T?   value, IEnumerable        <T>?  comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);
    //public static bool In<T>(this T?   value, IEnumerable        <T?>? comparisons) where T : struct => value.HasValue && (comparisons?.Contains(value.Value) ?? false);

    //public static string Coalesce   (this string?[]? fallbacks)                  => Coalesce((IEnumerable<string?>?)fallbacks);
    //public static T      Coalesce<T>(this T      []? fallbacks) where T : struct => Coalesce((IEnumerable<T>      ?)fallbacks);
    //public static T      Coalesce<T>(this T?     []? fallbacks) where T : struct => Coalesce((IEnumerable<T?>     ?)fallbacks);

```

### Coalesce Tests

trimSpace no effect in plain coalesce without fallbacks:

```cs
        //AreEqual("", @null .Coalesce(trimSpace: true));
        //AreEqual("", ""    .Coalesce(trimSpace: true));
        //AreEqual(" ", " "  .Coalesce(trimSpace: true));
        //AreEqual("", @null .Coalesce(trimSpace: false));
        //AreEqual("", ""    .Coalesce(trimSpace: false));
        //AreEqual(" ", " "  .Coalesce(trimSpace: false));

//public static string Coalesce   (this string? value,                   bool trimSpace)  => FilledInHelper.Coalesce(value,          trimSpace);
    //public static string Coalesce   (     string? value,                   bool trimSpace)  => Has(value, trimSpace) ? value       :    value ?? ""     ;
```

### Coalesce Testing for Nullable Types

```cs
            //Assert.IsInstanceOfType<int?>(nully0); // Succeeds
            //Assert.IsInstanceOfType<int?>(nully1); // Succeeds
            //Assert.IsNotInstanceOfType<int>(nully0); // Fails.
            //Assert.IsNotInstanceOfType<int>(nully1); // Fails.
            //Assert.IsInstanceOfType(nully1, typeof(int?)); // Succeeds
            //Assert.IsNotInstanceOfType(nully1, typeof(int)); // Fails.
            
            //IsOfType<int?>(() => nully0); // TODO: Fails
            //IsOfType<int?>(() => nully1); // TODO: Fails


            Type nully1Type = nully1.GetType();
            bool isNullable = Nullable.GetUnderlyingType(typeof(int?)) != null;      // true
            bool same      = Nullable.GetUnderlyingType(nully1.GetType()) == typeof(int);
            
            //AreEqual(typeof(int), nully1.GetUnderlyingType());
            
            AreEqual(typeof(int?), nully1.GetType()); // Fails
            NotEqual(typeof(int),  nully1.GetType());
            AreEqual(typeof(int),  @null.Coalesce().GetType());
            NotEqual(typeof(int?), @null.Coalesce().GetType());
            AreEqual(typeof(int),  nully1.Coalesce().GetType());
            NotEqual(typeof(int?), nully1.Coalesce().GetType());

            
            AreEqual(0, nully0.Coalesce());
            AreEqual(0,      0.Coalesce());
            AreEqual(1, nully1.Coalesce());
            AreEqual(1,      1.Coalesce());
            
            
            AreEqual(0, Coalesce(nully0));
            AreEqual(0, Coalesce(     0));
            AreEqual(1, Coalesce(nully1));
            AreEqual(1, Coalesce(     1));
```

### ConfigCascader Tripping over Coalesce One Collection Ffalling back to Another

Finally the solution was to use a collection of concrete collection types: instead of `IEnumerable<IList<T>>` an `IEnumerable<List<T>>`.

```cs
    //Categories = CoalesceCollection(            xmlLayers.Select(x => GetCats(x))),
    //Categories = CoalesceCategories(xmlLayers),
    //Categories = CoalesceCategories(  xmlLayers.Select(x => GetCats(x))),
        
        //private static IList<string> CoalesceCategories(LoggerXml[] xmlLayers)
        //{
        //    return CoalesceCategories(xmlLayers.Select(x => GetCats(x)));
        //}

        private static IList<string> CoalesceCategories(IEnumerable<IList<string>> collections)
        {
            //return collections.Where(FilledIn).FirstOrDefault() ?? [ ];
            //return CoalesceLists(collections);
            return CoalesceCollections<IList<string>, string>(collections);
        }

        //private static IList<T> CoalesceLists<T>(IEnumerable<IList<T>> collections)
        //{
        //    return collections.Where(FilledIn).FirstOrDefault() ?? [ ];
        //}

        //private static TColl Coalesce<TItem, TColl>(IEnumerable<TColl> collections)
        //    where TColl : IEnumerable<TItem>
        //{
        //    return CoalesceCollections<TItem, TColl>(collections);
        //}

        private static TColl CoalesceCollections<TColl, TItem>(IEnumerable<TColl> collections)
            where TColl : IEnumerable<TItem>
            
        {
            IEnumerable<IEnumerable<TItem>> enumerables = collections.Select(x => (IEnumerable<TItem>)x);
            IEnumerable<TItem> firstFilledEnumerable = enumerables.Where(FilledIn).FirstOrDefault();
            TColl firstFilledTColl = (TColl)firstFilledEnumerable;
            IEnumerable<TItem> emptyEnumerable = [ ];
            TColl emptyColl = (TColl)emptyEnumerable;
            return firstFilledTColl ?? emptyColl;
        }
```

### FilledInHelper : One Collection falling back to another

Plain variadic coalesce method took over the job.

```cs

    //public static IEnumerable<T> Coalesce<T>(IEnumerable<T>? coll, IEnumerable<T>? fallback) => Has(coll) ? coll : fallback ?? [];
    //public static IEnumerable<T> Coalesce<T>(IEnumerable<T>? coll) => Has(coll) ? coll : [ ];
    //public static T[] Coalesce<T>(T[]? coll, T[]? fallback) => Has(coll) ? coll : fallback ?? [];
    //public static T[] Coalesce<T>(T[]? coll, T[]? fallback) => Has(coll) ? coll : fallback ?? [];
    

    public static TColl CoalesceCollection<TColl, TItem>(params IEnumerable<TColl> collections)
        where TColl : IEnumerable<TItem>
        
    {
        IEnumerable<IEnumerable<TItem>> enumerables = collections.Select(x => (IEnumerable<TItem>)x);
        IEnumerable<TItem> firstFilledEnumerable = enumerables.Where(FilledIn).FirstOrDefault();
        TColl firstFilledTColl = (TColl)firstFilledEnumerable;
        IEnumerable<TItem> emptyEnumerable = [ ];
        TColl emptyColl = (TColl)emptyEnumerable;
        return firstFilledTColl ?? emptyColl;
    }

    //public static TColl Coalesce<TItem, TColl>(params IEnumerable<TColl>? fallbacks)
    //    where TColl : IEnumerable<TItem>, new()
    //{
    //    if (fallbacks == null) return new();
        
    //    TColl last = default;
        
    //    foreach (var fallback in fallbacks)
    //    {
    //        if (Has(fallback)) return fallback;
    //        last = fallback;
    //    }
        
    //    return last ?? new();
    //}
```

### FilledInHelper

```cs
    //public static T      Coalesce<T>(     object? value                  ) where T : class, new() => Has(value     ) ? (T)value    : new T();
    //public static T      Coalesce<T>(     T       value                  ) where T : struct => Has(value           ) ? value       : default;
```

### FilledInExtensions
    
```cs
    //public static string Coalesce   (this string? value                  )                  => FilledInHelper.Coalesce(value                    );
    //public static T      Coalesce<T>(this T       value                  )                  => FilledInHelper.Coalesce(value                    );
    //public static T      Coalesce<T>(this T?      value                  ) where T : struct => FilledInHelper.Coalesce(value                    );

    //public static T      Coalesce<T>(this object? value                  ) where T : class, new() => FilledInHelper.Coalesce(value                   );


    // One Collection falling back to another

    public static IEnumerable<T> Coalesce<T>(this IEnumerable<T>? coll, IEnumerable<T>? fallback) => FilledInHelper.Coalesce(coll, fallback);
```

### FilledIn Tests: Avoid Tests with `null` Literals 

```cs
            //AreEqual(""     , Coalesce(nullCulture,  null ));
            //AreEqual(""     , nullCulture.Coalesce(  null ));

            // TODO: Does not compile
            //AreEqual(0, Coalesce( NullNum, null   ));
            //AreEqual(0, Coalesce(  Nully0, null   ));
            //AreEqual(1, Coalesce(  Nully1, null   ));
            //int? Nully2 = 2;
            // TODO: Doesn't compile without casting null.
            //AreEqual(2, Coalesce(  Nully2, null   ));
            //AreEqual(0, Coalesce(    null, null   ));
            //AreEqual(0, Coalesce(       0, null   ));
            //AreEqual(1, Coalesce(       1, null   ));
            //AreEqual(2, Coalesce(       2, null   ));
            //AreEqual(0, Coalesce(    null, NullNum));
            //AreEqual(0, Coalesce(    null,  Nully0));
            //AreEqual(1, Coalesce(    null,  Nully1));
            //AreEqual(0, Coalesce(    null,  Nully0));
            //AreEqual(1, Coalesce(    null,  Nully1));
            //AreEqual(2, Coalesce(    null,  Nully2));
            //AreEqual(0, Coalesce(    null,       0));
            //AreEqual(1, Coalesce(    null,       1));
            //AreEqual(2, Coalesce(    null,       2));
            // TODO: Does not Compile
            //AreEqual(0,  NullNum.Coalesce( null   ));
            //AreEqual(0,   Nully0.Coalesce( null   ));
            //AreEqual(1,   Nully1.Coalesce( null   ));
            //AreEqual(2,   Nully2.Coalesce( null   ));
            //AreEqual(0,        0.Coalesce( null   ));
            //AreEqual(1,        1.Coalesce( null   ));
            //AreEqual(2,        2.Coalesce( null   ));
            //AreEqual(0,     null.Coalesce( NullNum)); // TODO: Does not Compile
            //AreEqual(0,     null.Coalesce(  Nully0)); // TODO: Does not Compile
            //AreEqual(1,     null.Coalesce(  Nully1)); // TODO: Does not Compile
            //AreEqual(2,     null.Coalesce(  Nully2)); // TODO: Does not Compile
            //AreEqual(0,     null.Coalesce(       0)); // TODO: Does not Compile
            //AreEqual(1,     null.Coalesce(       1)); // TODO: Does not Compile
            //AreEqual(2,     null.Coalesce(       2)); // TODO: Does not Compile
            NotNull (                Coalesce(null,           null      ));
            NotNull (                Coalesce(NullObject,     null      ));
            AreEqual(NonNullObject,  Coalesce(NonNullObject,  null      ));
            AreEqual(NullableFilled, Coalesce(NullableFilled, null      ));
            NotNull (                Coalesce(null,           NullObject));
            AreEqual(NonNullObject,  Coalesce(null,           NonNullObject));
            AreEqual(NullableFilled, Coalesce(null,           NullableFilled));
            NotNull (                null          .Coalesce(null      ));
            NotNull (                NullObject    .Coalesce(null      ));
            AreEqual(NonNullObject,  NonNullObject .Coalesce(null      ));
            AreEqual(NullableFilled, NullableFilled.Coalesce(null      ));
            NotNull (                null          .Coalesce(NullObject));
            //AreEqual(NonNullObject,  null          .Coalesce(NonNullObject));
            //AreEqual(NullableFilled, null          .Coalesce(NullableFilled));

    // These didn't help
    //public static T      Coalesce<T>(     object? value, T?      fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     T?      value, object? fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, object? fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, T?      fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     T?      value, object? fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, object? fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    // These didn't help
    //public static T      Coalesce<T>(     object? value, T?      fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     T?      value, object? fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, object? fallback) where T : new()   => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, T?      fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     T?      value, object? fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
    //public static T      Coalesce<T>(     object? value, object? fallback) where T : struct => Has(value           ) ? (T)value    : Coalesce((T?)fallback)    ;
```

### FilledIn Tests: Removed while simplifying compile time type checks
        
```cs        
        AreEqual(typeof(int?), CompileTimeType(NullNum));
        AreEqual(typeof(int),  CompileTimeType(NullNum.Coalesce()));
        AreEqual(typeof(int),  CompileTimeType(Coalesce(NullNum)));

        
        NotType(typeof(int?), NullNum.Coalesce()); // Fails
        NotType(typeof(int?), NullNum.Coalesce()); // Succeeds
        NotEqual(typeof(int?), CompileTimeType(NullNum.Coalesce())); // Succeeds
        
        int res = NullNum.Coalesce();
        NotType(typeof(int?), res); // Succeeds
        NotEqual(typeof(int?), CompileTimeType(res)); // Succeeds




        AreEqual(0,            Coalesce( NullNum, NullNum));
        IsType  (typeof(int),  Coalesce( NullNum, NullNum));
        NotType (typeof(int?), Coalesce( NullNum, NullNum));
        AreEqual(0,            Coalesce(  Nully0, NullNum));
        IsType  (typeof(int),  Coalesce(  Nully0, NullNum));
        NotType (typeof(int?), Coalesce(  Nully0, NullNum));
        AreEqual(1,            Coalesce(  Nully1, NullNum));
        IsType  (typeof(int),  Coalesce(  Nully1, NullNum));
        NotType (typeof(int?), Coalesce(  Nully1, NullNum));
        AreEqual(2,            Coalesce(  Nully2, NullNum));
        IsType  (typeof(int),  Coalesce(  Nully2, NullNum));
        NotType (typeof(int?), Coalesce(  Nully2, NullNum));
        AreEqual(0,            Coalesce(       0, NullNum));
        IsType  (typeof(int),  Coalesce(       0, NullNum));
        NotType (typeof(int?), Coalesce(       0, NullNum));
        AreEqual(1,            Coalesce(       1, NullNum));
        IsType  (typeof(int),  Coalesce(       1, NullNum));
        NotType (typeof(int?), Coalesce(       1, NullNum));
        AreEqual(2,            Coalesce(       2, NullNum));
        IsType  (typeof(int),  Coalesce(       2, NullNum));
        NotType (typeof(int?), Coalesce(       2, NullNum));
        AreEqual(0,            Coalesce( NullNum,  Nully0));
        IsType  (typeof(int),  Coalesce( NullNum,  Nully0));
        NotType (typeof(int?), Coalesce( NullNum,  Nully0));
        AreEqual(0,            Coalesce(  Nully0,  Nully0));
        IsType  (typeof(int),  Coalesce(  Nully0,  Nully0));
        NotType (typeof(int?), Coalesce(  Nully0,  Nully0));
        AreEqual(1,            Coalesce(  Nully1,  Nully0));
        IsType  (typeof(int),  Coalesce(  Nully1,  Nully0));
        NotType (typeof(int?), Coalesce(  Nully1,  Nully0));
        AreEqual(2,            Coalesce(  Nully2,  Nully0));
        IsType  (typeof(int),  Coalesce(  Nully2,  Nully0));
        NotType (typeof(int?), Coalesce(  Nully2,  Nully0));
        AreEqual(0,            Coalesce(       0,  Nully0));
        IsType  (typeof(int),  Coalesce(       0,  Nully0));
        NotType (typeof(int?), Coalesce(       0,  Nully0));
        AreEqual(1,            Coalesce(       1,  Nully0));
        IsType  (typeof(int),  Coalesce(       1,  Nully0));
        NotType (typeof(int?), Coalesce(       1,  Nully0));
        AreEqual(2,            Coalesce(       2,  Nully0));
        IsType  (typeof(int),  Coalesce(       2,  Nully0));
        NotType (typeof(int?), Coalesce(       2,  Nully0));
        AreEqual(1,            Coalesce( NullNum,  Nully1));
        IsType  (typeof(int),  Coalesce( NullNum,  Nully1));
        NotType (typeof(int?), Coalesce( NullNum,  Nully1));
        AreEqual(1,            Coalesce(  Nully0,  Nully1));
        IsType  (typeof(int),  Coalesce(  Nully0,  Nully1));
        NotType (typeof(int?), Coalesce(  Nully0,  Nully1));
        AreEqual(1,            Coalesce(  Nully1,  Nully1));
        IsType  (typeof(int),  Coalesce(  Nully1,  Nully1));
        NotType (typeof(int?), Coalesce(  Nully1,  Nully1));
        AreEqual(2,            Coalesce(  Nully2,  Nully1));
        IsType  (typeof(int),  Coalesce(  Nully2,  Nully1));
        NotType (typeof(int?), Coalesce(  Nully2,  Nully1));
        AreEqual(1,            Coalesce(       0,  Nully1));
        IsType  (typeof(int),  Coalesce(       0,  Nully1));
        NotType (typeof(int?), Coalesce(       0,  Nully1));
        AreEqual(1,            Coalesce(       1,  Nully1));
        IsType  (typeof(int),  Coalesce(       1,  Nully1));
        NotType (typeof(int?), Coalesce(       1,  Nully1));
        AreEqual(2,            Coalesce(       2,  Nully1));
        IsType  (typeof(int),  Coalesce(       2,  Nully1));
        NotType (typeof(int?), Coalesce(       2,  Nully1));
        AreEqual(2,            Coalesce( NullNum,  Nully2));
        IsType  (typeof(int),  Coalesce( NullNum,  Nully2));
        NotType (typeof(int?), Coalesce( NullNum,  Nully2));
        AreEqual(2,            Coalesce(  Nully0,  Nully2));
        IsType  (typeof(int),  Coalesce(  Nully0,  Nully2));
        NotType (typeof(int?), Coalesce(  Nully0,  Nully2));
        AreEqual(1,            Coalesce(  Nully1,  Nully2));
        IsType  (typeof(int),  Coalesce(  Nully1,  Nully2));
        NotType (typeof(int?), Coalesce(  Nully1,  Nully2));
        AreEqual(2,            Coalesce(  Nully2,  Nully2));
        IsType  (typeof(int),  Coalesce(  Nully2,  Nully2));
        NotType (typeof(int?), Coalesce(  Nully2,  Nully2));
        AreEqual(2,            Coalesce(       0,  Nully2));
        IsType  (typeof(int),  Coalesce(       0,  Nully2));
        NotType (typeof(int?), Coalesce(       0,  Nully2));
        AreEqual(1,            Coalesce(       1,  Nully2));
        IsType  (typeof(int),  Coalesce(       1,  Nully2));
        NotType (typeof(int?), Coalesce(       1,  Nully2));
        AreEqual(2,            Coalesce(       2,  Nully2));
        IsType  (typeof(int),  Coalesce(       2,  Nully2));
        NotType (typeof(int?), Coalesce(       2,  Nully2));
        AreEqual(0,            Coalesce( NullNum,       0));
        IsType  (typeof(int),  Coalesce( NullNum,       0));
        NotType (typeof(int?), Coalesce( NullNum,       0));
        AreEqual(0,            Coalesce(  Nully0,       0));
        IsType  (typeof(int),  Coalesce(  Nully0,       0));
        NotType (typeof(int?), Coalesce(  Nully0,       0));
        AreEqual(1,            Coalesce(  Nully1,       0));
        IsType  (typeof(int),  Coalesce(  Nully1,       0));
        NotType (typeof(int?), Coalesce(  Nully1,       0));
        AreEqual(2,            Coalesce(  Nully2,       0));
        IsType  (typeof(int),  Coalesce(  Nully2,       0));
        NotType (typeof(int?), Coalesce(  Nully2,       0));
        AreEqual(0,            Coalesce(       0,       0));
        IsType  (typeof(int),  Coalesce(       0,       0));
        NotType (typeof(int?), Coalesce(       0,       0));
        AreEqual(1,            Coalesce(       1,       0));
        IsType  (typeof(int),  Coalesce(       1,       0));
        NotType (typeof(int?), Coalesce(       1,       0));
        AreEqual(2,            Coalesce(       2,       0));
        IsType  (typeof(int),  Coalesce(       2,       0));
        NotType (typeof(int?), Coalesce(       2,       0));
        AreEqual(1,            Coalesce( NullNum,       1));
        IsType  (typeof(int),  Coalesce( NullNum,       1));
        NotType (typeof(int?), Coalesce( NullNum,       1));
        AreEqual(1,            Coalesce(  Nully0,       1));
        IsType  (typeof(int),  Coalesce(  Nully0,       1));
        NotType (typeof(int?), Coalesce(  Nully0,       1));
        AreEqual(1,            Coalesce(  Nully1,       1));
        IsType  (typeof(int),  Coalesce(  Nully1,       1));
        NotType (typeof(int?), Coalesce(  Nully1,       1));
        AreEqual(2,            Coalesce(  Nully2,       1));
        IsType  (typeof(int),  Coalesce(  Nully2,       1));
        NotType (typeof(int?), Coalesce(  Nully2,       1));
        AreEqual(1,            Coalesce(       0,       1));
        IsType  (typeof(int),  Coalesce(       0,       1));
        NotType (typeof(int?), Coalesce(       0,       1));
        AreEqual(1,            Coalesce(       1,       1));
        IsType  (typeof(int),  Coalesce(       1,       1));
        NotType (typeof(int?), Coalesce(       1,       1));
        AreEqual(2,            Coalesce(       2,       1));
        IsType  (typeof(int),  Coalesce(       2,       1));
        NotType (typeof(int?), Coalesce(       2,       1));
        AreEqual(2,            Coalesce( NullNum,       2));
        IsType  (typeof(int),  Coalesce( NullNum,       2));
        NotType (typeof(int?), Coalesce( NullNum,       2));
        AreEqual(2,            Coalesce(  Nully0,       2));
        IsType  (typeof(int),  Coalesce(  Nully0,       2));
        NotType (typeof(int?), Coalesce(  Nully0,       2));
        AreEqual(1,            Coalesce(  Nully1,       2));
        IsType  (typeof(int),  Coalesce(  Nully1,       2));
        NotType (typeof(int?), Coalesce(  Nully1,       2));
        AreEqual(2,            Coalesce(  Nully2,       2));
        IsType  (typeof(int),  Coalesce(  Nully2,       2));
        NotType (typeof(int?), Coalesce(  Nully2,       2));
        AreEqual(2,            Coalesce(       0,       2));
        IsType  (typeof(int),  Coalesce(       0,       2));
        NotType (typeof(int?), Coalesce(       0,       2));
        AreEqual(1,            Coalesce(       1,       2));
        IsType  (typeof(int),  Coalesce(       1,       2));
        NotType (typeof(int?), Coalesce(       1,       2));
        AreEqual(2,            Coalesce(       2,       2));
        IsType  (typeof(int),  Coalesce(       2,       2));
        NotType (typeof(int?), Coalesce(       2,       2));

    //private static void AssertIntCoalesce<TExpected, TActual>(TExpected expected, TActual actual)
    //{
    //    AreEqual(expected,     actual);
    //    IsType  (typeof(int),  actual);
    //    NotType (typeof(int?), actual);
    //}

    
    ///// <inheritdoc cref="_nonullret" />
    //public static void NoNullRet<TRet>(TRet expected, TRet ret)
    //    where TRet : notnull
    //{
    //    AreEqual(expected, ret);
    //}
    
    /// <inheritdoc cref="_nonullret" />
    //public static void NullRet<TRet>(TRet? expected)
    //    where TRet : class
    //{
        //AreEqual(expected, ret);
        // From ChatGPT (doesn't work):
        //if (typeof(TRet) == typeof(object)) _ = (TRet?)null;
    //}    
    
    ///// <inheritdoc cref="_nonullret" />
    //public static void NullRet<TRet>(TRet? expected, TRet? ret)
    //    where TRet : class
    //{
    //    AreEqual(expected, ret);
    //}

    /// <inheritdoc cref="_nonullret" />
    public static void NoNullRet<TRet>(TRet ret, [ArgExpress(nameof(ret))] string message = "")
        where TRet : struct
    {
        IsType(typeof(int), ret);
        NotType(typeof(int?), ret);
    }
        
        // TODO: Check return types. After extending Testing.Core's helpers.
        //IsOfType<StringBuilder>(() => Coalesce(NullObject,           NullObject));
        // TODO: More tests

```

### Testing.Core IsType

```cs    
    [Obsolete] public static void IsType<TType, TObject>(TObject obj, [ArgExpress(nameof(obj))] string message = "") => throw new NotSupportedException();
    //{
    //    var expected = typeof(TType);
    //    var actual = CompileTimeType(obj);
    //    IsType(expected, actual, message);
    //}

        //Check(expected, actual, message, () => expected == actual);
    //    => Check(typeof(T), message, () => CompileTimeType(val) == typeof(T));
    //    => Check(typeof(T), message, () => CompileTimeType(obj) != typeof(T));
    //    => Check(typeof(T), message, () => CompileTimeType(obj) != typeof(T));
```

### Coalesce

```cs

  //public static bool NullRef            ([NotNullWhen(true)]       object?         value)                           => value == null;
  //public static bool NotDefault<T>      ([NotNullWhen(true)]       T               value) where T : notnull         => !Equals(value, default(T));
  //public static bool NotNullOrDefault<T>([NotNullWhen(true)]       T?              value) where T : struct          => !Equals(value, default(T?)) && !Equals(value, default(T));
  //public static bool NotDefault<T>      ([NotNullWhen(true)]       T               value) where T : new()           => !Equals(value, default(T));
  //public static bool NotDefault<T>      ([NotNullWhen(true)]       T               value) where T : notnull, new()  => !Equals(value, default(T));
  //public static bool NotHasStruct<T>    ([NotNullWhen(true)]       T?              value) where T : struct          => Equals(value, default(T?)) ||  Equals(value, default(T));

    //public static T      Coalesce<T>(     T       value                  ) where T : struct => Has(value           ) ? value       : new();
    //public static T      Coalesce<T>(this T       value                  ) where T : struct => FilledInHelper.Coalesce(value);

    //public static string Coalesce   (     object? value, string? fallback)                        => HasRef         (value) ? CoalesceStrings($"{value}", fallback           ) : "";
    //public static string Coalesce<T>(     T?      value, string? fallback) where T : struct       => HasStruct(value) ? CoalesceStrings($"{value}", fallback) : CoalesceString(fallback);
    //public static string Coalesce<T>(     T       value, string? fallback) where T : struct       => HasStruct(value) ? CoalesceStrings($"{value}", fallback) : CoalesceString(fallback);

  //public static bool FilledIn<T>([NotNullWhen(true)]       T?              val) where T : notnull => !Default(val);
  //public static bool FilledIn<T>([NotNullWhen(true)]       T?              val) where T : new()   => !Default(val);
  //public static bool Has<T>     ([NotNullWhen(true)]       T?              value) where T : notnull => !Default(value);
  //public static bool Has<T>     ([NotNullWhen(true)]       T?              value) where T : new()   => !Default(value);
  //public static bool IsNully<T> ([NotNullWhen(false)]      T?              value) where T : notnull =>  Default(value);
  //public static bool IsNully<T> ([NotNullWhen(false)]      T               value) where T : struct  => !HasStruct<T>(value);
  //public static bool IsNully<T> ([NotNullWhen(false)]      T?              value) where T : new()   => !HasStruct(value);

  //public static T?      Coalesce<T>(     T?      value                  ) where T : class        => HasRef        (value           ) ? value       : default;
  //public static T?      Coalesce<T>(     T?      value                  ) where T : new()        => HasRef        (value           ) ? value       : default;
  //public static T       Coalesce<T>(     T       value                  ) where T : notnull      => !Default      (value           ) ? value       : default;

  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : notnull      => !Default      (value    ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : struct       => !NullOrDefault(value    ) ? value.Value : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : notnull      => !Default      (value    ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T       value, T       fallback) where T : struct       => Has(value               ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : new()        => Has(value                      ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T       value, T       fallback) where T : class, new() => !Default      (value           ) ? value       : Coalesce(fallback)    ;
  //public static T      Coalesce<T>(     T?      value, T?      fallback) where T : new()        => !NullOrDefault(value           ) ? value.Value : Coalesce(fallback)    ;

  //public static bool FilledIn<T>([NotNullWhen(true)]  this T?              val) where T : notnull => !Default(val); // notnull lied. it wouldn't take non nullable structs.
  //public static bool FilledIn<T>([NotNullWhen(true)]  this T?              val) where T : new()   => !Default(val);

  //public static bool IsNully<T> ([NotNullWhen(false)] this T?              val) where T : notnull =>  Default(val);
  //public static bool IsNully<T> ([NotNullWhen(false)] this T?              val) where T : new()   =>  NullOrDefault(val);
  //public static bool IsNully<T> ([NotNullWhen(false)] this T               val) where T : struct  =>  Default(val);

  //public static T?     Coalesce<T>(this T?      value                  ) where T : class        => HasRef        (value           ) ? value       : default;
  //public static T      Coalesce<T>(this T?      value                  ) where T : new()        => FilledInHelper.Coalesce(value);
  //public static T      Coalesce<T>(this T?      value                  ) where T : notnull      => FilledInHelper.Coalesce(value);
```

### From CoalesceManyVals

```cs
    //if (HasValNully(val))
    //{
    //    if (val is T ret)
    //    {
    //        return ret;
    //    }
    //}
```

### Coalesce

```cs
    //public static string Coalesce   (this string? text, string? fallback, string? fallback2)                  => Coalesce(text, Coalesce(fallback, fallback2));
    //public static string Coalesce   (this string? text, string? fallback, string? fallback2, bool trimSpace)  => Coalesce(text, Coalesce(fallback, fallback2, trimSpace), trimSpace);
    //public static string Coalesce<T>(this T       obj,  T       fallback, string? fallback2)                  => Coalesce(obj,  Coalesce(fallback, fallback2));
    //public static string Coalesce<T>(this T?      val,  T?      fallback, string? fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));
    //public static T      Coalesce<T>(this T       obj,  T       fallback, T       fallback2) where T : new()  => Coalesce(obj,  Coalesce(fallback, fallback2));
    //public static T      Coalesce<T>(this T?      val,  T?      fallback, T?      fallback2) where T : struct => Coalesce(val,  Coalesce(fallback, fallback2));
```

### Coalesce: Arity 1 TrimSpace Irrelevant

```cs
    public static  string CoalesceText          (string? text, bool trimSpace)         => HasText    (text, trimSpace) ? text      : text ?? "";
    public static string Coalesce   (     string? text, bool trimSpace)        => CoalesceText    (text, trimSpace);
    public static string Coalesce   (this string? text, bool trimSpace)        => CoalesceText    (text, trimSpace);
    
    [TestMethod]
    public void Coalesce_Arity1_Trim_TrimSpace()
    {
        AreEqual("   ", NullText   .Coalesce());
        AreEqual("   ", NullText   .Coalesce(trimSpace: true));
        AreEqual("   ", NullText   .Coalesce(trimSpace: false));
        
        AreEqual(""   , NullText.Coalesce( trimSpace: false));
        AreEqual(""   , ""      .Coalesce( trimSpace: false));
        AreEqual("   ", "   "   .Coalesce( trimSpace: false));
        AreEqual("Hi" , "Hi"    .Coalesce( trimSpace: false));
        AreEqual(""   , Coalesce(NullText, trimSpace: false));
        AreEqual(""   , Coalesce(""      , trimSpace: false));
        AreEqual("   ", Coalesce("   "   , trimSpace: false));
        AreEqual("Hi" , Coalesce("Hi"    , trimSpace: false));
    }
```

### Coalesce: 

Arity 2 with Objects resolves to arity N. 

```cs
    public static T      Coalesce<T>(     object? obj,  T?      fallback) where T : class, new() => CoalesceTwoObjects    (obj as T, fallback);
    public static T      Coalesce<T>(this object? obj,  T?      fallback) where T : class, new() => CoalesceTwoObjects    (obj as T, fallback);
    public static T      CoalesceTwoObjects    <T>(T?   obj,  T?      fallback) where T : class, new() => HasObject  (obj) ? obj       : CoalesceObject  (fallback);
```

More specific arity 2 overload `(T? T?) where T : class` would clash with `struct`-targeted overload.  
A more general overload `(object?, object?)` can't infer the type (must be known to create a new one).  
It's only an extra feature anyway. You'd probably use a null-coalescing operator `??` instead if you want speed.
And if you do want the syntax sugar: It's there.