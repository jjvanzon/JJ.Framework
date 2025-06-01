using System.Collections;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{
    public static bool HasArray            <T>([NotNullWhen(true)] T[]                   ? coll) => coll is { Length : > 0 };
    public static bool HasColl                ([NotNullWhen(true)] ICollection           ? coll) => coll is { Count  : > 0 };
    public static bool HasCollT            <T>([NotNullWhen(true)] ICollection<T>        ? coll) => coll is { Count  : > 0 };
    public static bool HasReadOnlyColl     <T>([NotNullWhen(true)] IReadOnlyCollection<T>? coll) => coll is { Count  : > 0 };
    public static bool HasEnumerable       <T>([NotNullWhen(true)] IEnumerable<T>        ? coll) => coll?.Any() ?? false;
    public static bool Has_ImmutableArray  <T>([NotNullWhen(true)] ref ImmutableArray<T> ? coll) => coll is { IsEmpty: false };
    public static bool Has_ImmutableStack  <T>([NotNullWhen(true)] IImmutableStack<T>    ? coll) => coll is { IsEmpty: false };
    public static bool Has_ImmutableQueue  <T>([NotNullWhen(true)] IImmutableQueue<T>    ? coll) => coll is { IsEmpty: false };
    public static bool Has_StringDictionary   ([NotNullWhen(true)] StringDictionary      ? coll) => coll is { Count  : > 0 };
    #if NET6_0_OR_GREATER
    public static bool Has_PriorityQueue<T, U>([NotNullWhen(true)] PriorityQueue<T, U>   ? coll) => coll is { Count  : > 0 };
    #endif
}

public static partial class FilledInHelper
{
    // Common
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T[]                                        ? coll)                   => HasArray(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IList<T>                                   ? coll)                   => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ISet<T>                                    ? coll)                   => HasCollT(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      IDictionary<T,U>                           ? coll)                   => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ICollection<T>                             ? coll)                   => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IEnumerable<T>                             ? coll)                   => HasEnumerable(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      List<T>                                    ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      HashSet<T>                                 ? coll)                   => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      Stack<T>                                   ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      Queue<T>                                   ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      LinkedList<T>                              ? coll)                   => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      SortedList<T,U>                            ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      SortedSet<T>                               ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      Dictionary<T,U>                            ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      Dictionary<T,U>.KeyCollection              ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      Dictionary<T,U>.ValueCollection            ? coll) where T : notnull => HasColl(coll);
    // Immutable
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IImmutableList<T>                          ? coll)                   => HasReadOnlyColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IImmutableSet<T>                           ? coll)                   => HasReadOnlyColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IImmutableStack<T>                         ? coll)                   => Has_ImmutableStack(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IImmutableQueue<T>                         ? coll)                   => Has_ImmutableQueue(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      IImmutableDictionary<T,U>                  ? coll)                   => HasReadOnlyColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableArray<T>                          ? coll)                   => Has_ImmutableArray(ref coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableArray<T>.Builder                  ? coll)                   => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableList<T>                           ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableList<T>.Builder                   ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableHashSet<T>                        ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableHashSet<T>.Builder                ? coll)                   => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableStack<T>                          ? coll)                   => Has_ImmutableStack(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableQueue<T>                          ? coll)                   => Has_ImmutableQueue(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      ImmutableDictionary<T,U>                   ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      ImmutableDictionary<T,U>.Builder           ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableSortedSet<T>                      ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ImmutableSortedSet<T>.Builder              ? coll)                   => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      ImmutableSortedDictionary<T,U>             ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      ImmutableSortedDictionary<T,U>.Builder     ? coll) where T : notnull => HasColl(coll);
    // ReadOnly
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IReadOnlyCollection<T>                     ? coll)                   => HasReadOnlyColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IReadOnlyList<T>                           ? coll)                   => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      IReadOnlyDictionary<T,U>                   ? coll)                   => HasReadOnlyColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ReadOnlyCollection<T>                      ? coll)                   => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      ReadOnlyDictionary<T,U>                    ? coll) where T : notnull => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      ReadOnlyDictionary<T,U>.KeyCollection      ? coll) where T : notnull => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      ReadOnlyDictionary<T,U>.ValueCollection    ? coll) where T : notnull => HasReadOnlyColl(coll);
    #if NET9_0_OR_GREATER                                                                                 
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IReadOnlySet<T>                            ? coll)                   => HasReadOnlyColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ReadOnlySet<T>                             ? coll)                   => HasReadOnlyColl(coll);
    #endif
    // Concurrent
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ConcurrentBag<T>                           ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ConcurrentQueue<T>                         ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ConcurrentStack<T>                         ? coll)                   => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      ConcurrentDictionary<T,U>                  ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      BlockingCollection<T>                      ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      IProducerConsumerCollection<T>             ? coll)                   => HasColl(coll);
    // Specific
    public static bool FilledIn<T,U>([NotNullWhen(true )]      SortedDictionary<T,U>                      ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      SortedDictionary<T,U>.KeyCollection        ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      SortedDictionary<T,U>.ValueCollection      ? coll) where T : notnull => HasColl(coll);
    #if NET9_0_OR_GREATER
    public static bool FilledIn<T,U>([NotNullWhen(true )]      OrderedDictionary<T,U>                     ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      OrderedDictionary<T,U>.KeyCollection       ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      OrderedDictionary<T,U>.ValueCollection     ? coll) where T : notnull => HasColl(coll);
    #endif
    #if NET6_0_OR_GREATER
    public static bool FilledIn<T,U>([NotNullWhen(true )]      PriorityQueue<T,U>                         ? coll)                   => Has_PriorityQueue(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      PriorityQueue<T,U>.UnorderedItemsCollection? coll)                   => HasColl(coll);
    #endif
    public static bool FilledIn<T>  ([NotNullWhen(true )]      Collection<T>                              ? coll)                   => HasColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )]      KeyedCollection<T,U>                       ? coll) where T : notnull => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ObservableCollection<T>                    ? coll)                   => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )]      ReadOnlyObservableCollection<T>            ? coll)                   => HasColl(coll);
    // Legacy
    public static bool FilledIn     ([NotNullWhen(true )]      ArrayList                                  ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      BitArray                                   ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      CollectionBase                             ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      DictionaryBase                             ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      Hashtable                                  ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      Queue                                      ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      ReadOnlyCollectionBase                     ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      SortedList                                 ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      Stack                                      ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      HybridDictionary                           ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      ListDictionary                             ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      NameObjectCollectionBase                   ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      NameObjectCollectionBase.KeysCollection    ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      NameValueCollection                        ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      OrderedDictionary                          ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      StringCollection                           ? coll)                   => HasColl(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      StringDictionary                           ? coll)                   => Has_StringDictionary(coll);
    public static bool FilledIn     ([NotNullWhen(true )]      IOrderedDictionary                         ? coll)                   => HasColl(coll);

    public static bool Has<T>       ([NotNullWhen(true )]      T[]?                      coll)                      => HasArray(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IEnumerable        <T>?   coll)                      => HasEnumerable(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ICollection        <T>?   coll)                      => HasCollT(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IList              <T>?   coll)                      => HasCollT(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ISet               <T>?   coll)                      => HasCollT(coll);
    public static bool Has<T,U>     ([NotNullWhen(true )]      IDictionary        <T,U>? coll)                      => HasCollT(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IReadOnlyList      <T>?   coll)                      => HasReadOnlyColl(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IReadOnlyCollection<T>?   coll)                      => HasReadOnlyColl(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      List               <T>?   coll)                      => HasColl(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      HashSet            <T>?   coll)                      => HasCollT(coll);
    public static bool Has<T,U>     ([NotNullWhen(true )]      Dictionary         <T,U>? coll) where T : notnull    => HasColl(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ImmutableList      <T>?   coll)                      => HasColl(coll);
                                    
    public static bool IsNully<T>   ([NotNullWhen(false)]      T[]?                      coll)                      => !HasArray(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IEnumerable        <T>?   coll)                      => !HasEnumerable(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ICollection        <T>?   coll)                      => !HasCollT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IList              <T>?   coll)                      => !HasCollT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ISet               <T>?   coll)                      => !HasCollT(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)]      IDictionary        <T,U>? coll)                      => !HasCollT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IReadOnlyList      <T>?   coll)                      => !HasReadOnlyColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IReadOnlyCollection<T>?   coll)                      => !HasReadOnlyColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      List               <T>?   coll)                      => !HasColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      HashSet            <T>?   coll)                      => !HasCollT(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)]      Dictionary         <T,U>? coll) where T : notnull    => !HasColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ImmutableList      <T>?   coll)                      => !HasColl(coll);
}

public static partial class FilledInExtensions
{
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T[]?                      coll)                      => HasArray(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IEnumerable        <T>?   coll)                      => HasEnumerable(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ICollection        <T>?   coll)                      => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IList              <T>?   coll)                      => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ISet               <T>?   coll)                      => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IReadOnlyList      <T>?   coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IReadOnlyCollection<T>?   coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )] this IDictionary        <T,U>? coll)                      => HasCollT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this List               <T>?   coll)                      => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this HashSet            <T>?   coll)                      => HasCollT(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )] this Dictionary         <T,U>? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ImmutableList      <T>?   coll)                      => HasColl(coll);
  
    public static bool IsNully<T>   ([NotNullWhen(false)] this T[]?                      coll)                      => !HasArray(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IEnumerable        <T>?   coll)                      => !HasEnumerable(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ICollection        <T>?   coll)                      => !HasCollT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IList              <T>?   coll)                      => !HasCollT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ISet               <T>?   coll)                      => !HasCollT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IReadOnlyList      <T>?   coll)                      => !HasReadOnlyColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IReadOnlyCollection<T>?   coll)                      => !HasReadOnlyColl(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)] this IDictionary        <T,U>? coll)                      => !HasCollT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this List               <T>?   coll)                      => !HasColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this HashSet            <T>?   coll)                      => !HasCollT(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)] this Dictionary         <T,U>? coll) where T : notnull    => !HasColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ImmutableList      <T>?   coll)                      => !HasColl(coll);
}