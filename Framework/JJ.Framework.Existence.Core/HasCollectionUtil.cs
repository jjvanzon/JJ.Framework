namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_has" />
internal static class HasCollectionUtil
{
    /// <inheritdoc cref="_has"/>
    public static bool HasArray            <T>([NotNullWhen(true)] T[]                   ? coll) => coll is { Length          : > 0   };
    /// <inheritdoc cref="_has"/>
    public static bool HasColl                ([NotNullWhen(true)] ICollection           ? coll) => coll is { Count           : > 0   };
    /// <inheritdoc cref="_has"/>
    public static bool HasCollT            <T>([NotNullWhen(true)] ICollection<T>        ? coll) => coll is { Count           : > 0   };
    /// <inheritdoc cref="_has"/>
    public static bool HasReadOnlyColl     <T>([NotNullWhen(true)] IReadOnlyCollection<T>? coll) => coll is { Count           : > 0   };
    /// <inheritdoc cref="_has"/>
    public static bool HasLookup         <T,U>([NotNullWhen(true)] ILookup<T, U>         ? coll) => coll is { Count           : > 0   };
    /// <inheritdoc cref="_has"/>
    public static bool HasEnumerable       <T>([NotNullWhen(true)] IEnumerable<T>        ? coll) => coll?.Any() == true;
    /// <inheritdoc cref="_has"/>
    public static bool Has_ImmutableArray  <T>([NotNullWhen(true)] ref ImmutableArray<T>   coll) => coll is { IsDefaultOrEmpty: false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_ImmutableArray  <T>([NotNullWhen(true)] ref ImmutableArray<T> ? coll) => coll is { IsDefaultOrEmpty: false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_ImmutableStack  <T>([NotNullWhen(true)] IImmutableStack<T>    ? coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_ImmutableQueue  <T>([NotNullWhen(true)] IImmutableQueue<T>    ? coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_Memory          <T>([NotNullWhen(true)] Memory<T>               coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_Memory          <T>([NotNullWhen(true)] Memory<T>             ? coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_Span            <T>([NotNullWhen(true)] Span<T>                 coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_ReadOnlyMemory  <T>([NotNullWhen(true)] ReadOnlyMemory<T>       coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_ReadOnlyMemory  <T>([NotNullWhen(true)] ReadOnlyMemory<T>     ? coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_ReadOnlySpan    <T>([NotNullWhen(true)] ReadOnlySpan<T>         coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_ReadOnlySequence<T>([NotNullWhen(true)] ReadOnlySequence<T>     coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_ReadOnlySequence<T>([NotNullWhen(true)] ReadOnlySequence<T>   ? coll) => coll is { IsEmpty         : false };
    /// <inheritdoc cref="_has"/>
    public static bool Has_StringDictionary   ([NotNullWhen(true)] StringDictionary      ? coll) => coll is { Count           : > 0   };
    #if NET6_0_OR_GREATER
    /// <inheritdoc cref="_has"/>
    public static bool Has_PriorityQueue< T,U>([NotNullWhen(true)] PriorityQueue<T, U>   ? coll) => coll is { Count           : > 0   };
    #endif
}