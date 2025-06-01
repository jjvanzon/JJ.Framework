using System.Collections;
using NonGeneric = System.Collections;
using Concurrent = System.Collections.Concurrent;
using ObjectModel = System.Collections.ObjectModel;
using Specialized = System.Collections.Specialized;
// ReSharper disable RedundantNameQualifier
// ReSharper disable GenericEnumeratorNotDisposed

namespace JJ.Framework.Existence.Core;

internal static partial class ExistenceUtility
{
    public static bool HasArray            <T>([NotNullWhen(true)]                    T[]? coll)                   => coll is { Length : > 0 };
    public static bool HasColl                ([NotNullWhen(true)]         ICollection   ? coll)                   => coll is { Count  : > 0 };
    public static bool HasCollOfT          <T>([NotNullWhen(true)]         ICollection<T>? coll)                   => coll is { Count  : > 0 };
    public static bool HasReadOnlyColl     <T>([NotNullWhen(true)] IReadOnlyCollection<T>? coll)                   => coll is { Count  : > 0 };
    
    public static bool Has_ImmutableArray  <T>([NotNullWhen(true)] ref ImmutableArray<T> ? coll)                   => coll is { IsEmpty: false };
    public static bool Has_ImmutableStack  <T>([NotNullWhen(true)] IImmutableStack<T>    ? coll)                   => coll is { IsEmpty: false };
    #if NET6_0_OR_GREATER
    public static bool Has_PriorityQueue<T, U>([NotNullWhen(true)] PriorityQueue<T, U>   ? coll)                   => coll is { Count  : > 0 };
    #endif

    //[Obsolete("WARNING: Use variant for more specific collection type if you can.")]
    public static bool HasEnumerable        <T>([NotNullWhen(true)]            IEnumerable<T>? coll)                   => coll?               .Any() ?? false;
    //[Obsolete("WARNING: Use variant for more specific collection type if you can.")]
    public static bool HasEnumerable_NonGeneric([NotNullWhen(true)] NonGeneric.IEnumerable   ? coll)                   => HasEnumerator(coll?.GetEnumerator());
    //[Obsolete("WARNING: Use variant for more specific collection type if you can.")]
    public static bool HasEnumerator([NotNullWhen(true)] NonGeneric.IEnumerator? coll)
    {
        if (coll == null) return false;
        bool ret = coll.MoveNext(); 
        coll.Reset(); 
        return ret;
    }
    public static bool Has_StringEnumerator([NotNullWhen(true)] Specialized.StringEnumerator? coll)
    {
        if (coll == null) return false;
        bool ret = coll.MoveNext(); 
        coll.Reset(); 
        return ret;
    }
    //private static bool Has_ImmutableArrayEnumerator<T>(ImmutableArray<T>.Enumerator? coll)
    //{
    //    if (coll == null) return false;
    //    bool ret = coll.MoveNext(); 
    //    coll.Reset(); 
    //    return ret;
    //}

}

public static partial class FilledInHelper
{
    public static bool FilledIn<T>  ([NotNullWhen(true )]      T[]?                      coll)                      => HasArray(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.ArrayList                                  ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.BitArray                                   ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.CollectionBase                             ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.DictionaryBase                             ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.Hashtable                                  ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.Queue                                      ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.ReadOnlyCollectionBase                     ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.SortedList                                 ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.Stack                                      ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      NonGeneric.IEnumerator                                ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      Dictionary<T,U>                                       ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      Dictionary<T,U>.KeyCollection                         ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      Dictionary<T,U>.ValueCollection                       ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      HashSet<T>                                            ? coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      LinkedList<T>                                         ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      List<T>                                               ? coll)                      => HasColl(coll);
    #if NET9_0_OR_GREATER
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      OrderedDictionary<T,U>                                ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      OrderedDictionary<T,U>.KeyCollection                  ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      OrderedDictionary<T,U>.ValueCollection                ? coll) where T : notnull    => HasColl(coll);
    #endif
    #if NET6_0_OR_GREATER
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      PriorityQueue<T,U>                                    ? coll)                      => Has_PriorityQueue(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      PriorityQueue<T,U>.UnorderedItemsCollection           ? coll)                      => HasColl(coll);
    #endif
    public static bool FilledIn<T>    ([NotNullWhen(true )]      Queue<T>                                              ? coll)                      => HasEnumerable(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      SortedDictionary<T,U>                                 ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      SortedDictionary<T,U>.KeyCollection                   ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      SortedDictionary<T,U>.ValueCollection                 ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      SortedList<T,U>                                       ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      SortedSet<T>                                          ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      Stack<T>                                              ? coll)                      => HasEnumerable(coll);
  //public static bool FilledIn<T,U,V>([NotNullWhen(true )]      Dictionary<T,U>.AlternateLookup<V>                    ? coll) where T : notnull where V : notnull => HasCollection(coll.Dictionary);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      Dictionary<T,U>.Enumerator                            ? coll) where T : notnull    => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      Dictionary<T,U>.KeyCollection.Enumerator              ? coll) where T : notnull    => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      Dictionary<T,U>.ValueCollection.Enumerator            ? coll) where T : notnull    => HasEnumerator(coll);
  //public static bool FilledIn<T>    ([NotNullWhen(true )]      HashSet<T>.AlternateLookup<TAlternate>                ? coll)                      => HasCollection(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      HashSet<T>.Enumerator                                 ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      LinkedList<T>.Enumerator                              ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      List<T>.Enumerator                                    ? coll)                      => HasEnumerator(coll);
    #if NET9_0_OR_GREATER
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      OrderedDictionary<T,U>.Enumerator                     ? coll) where T : notnull    => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      OrderedDictionary<T,U>.KeyCollection.Enumerator       ? coll) where T : notnull    => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      OrderedDictionary<T,U>.ValueCollection.Enumerator     ? coll) where T : notnull    => HasEnumerator(coll);
    #endif
    #if NET6_0_OR_GREATER
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      PriorityQueue<T,U>.UnorderedItemsCollection.Enumerator? coll)                      => HasEnumerator(coll);
    #endif
    public static bool FilledIn<T>    ([NotNullWhen(true )]      Queue<T>.Enumerator                                   ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      SortedDictionary<T,U>.Enumerator                      ? coll) where T: notnull     => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      SortedDictionary<T,U>.KeyCollection.Enumerator        ? coll) where T: notnull     => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      SortedDictionary<T,U>.ValueCollection.Enumerator      ? coll) where T: notnull     => HasEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      SortedSet<T>.Enumerator                               ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      Stack<T>.Enumerator                                   ? coll)                      => HasEnumerator(coll);
  //public static bool FilledIn<T>    ([NotNullWhen(true )]      IAsyncEnumerable<T>                                   ? coll)                      => HasCollection(coll);
  //public static bool FilledIn<T>    ([NotNullWhen(true )]      IAsyncEnumerator<T>                                   ? coll)                      => HasCollection(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ICollection<T>                                        ? coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      IDictionary<T,U>                                      ? coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IEnumerable<T>                                        ? coll)                      => HasEnumerable(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IEnumerator<T>                                        ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IList<T>                                              ? coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IReadOnlyCollection<T>                                ? coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      IReadOnlyDictionary<T,U>                              ? coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IReadOnlyList<T>                                      ? coll)                      => HasReadOnlyColl(coll);
    //#if !NETSTANDARD2_0
    //public static bool FilledIn<T>    ([NotNullWhen(true )]      IReadOnlySet<T>                                       ? coll)                      => HasReadOnlyCollection(coll);
    //#endif
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ISet<T>                                               ? coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ObjectModel.Collection<T>                             ? coll)                      => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ObjectModel.KeyedCollection<T,U>                      ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ObjectModel.ObservableCollection<T>                   ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ObjectModel.ReadOnlyCollection<T>                     ? coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ObjectModel.ReadOnlyDictionary<T,U>                   ? coll) where T : notnull    => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ObjectModel.ReadOnlyDictionary<T,U>.KeyCollection     ? coll) where T : notnull    => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ObjectModel.ReadOnlyDictionary<T,U>.ValueCollection   ? coll) where T : notnull    => HasReadOnlyColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ObjectModel.ReadOnlyObservableCollection<T>           ? coll)                      => HasReadOnlyColl(coll);
    #if NET9_0_OR_GREATER
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ObjectModel.ReadOnlySet<T>                            ? coll)                      => HasReadOnlyColl(coll);
    #endif
    public static bool FilledIn<T>    ([NotNullWhen(true )]      Concurrent.BlockingCollection<T>                      ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ConcurrentBag<T>                                      ? coll)                      => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ConcurrentDictionary<T,U>                             ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ConcurrentQueue<T>                                    ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ConcurrentStack<T>                                    ? coll)                      => HasColl(coll);
  //public static bool FilledIn<T,U,V>([NotNullWhen(true )]      ConcurrentDictionary<T,U>.AlternateLookup<V>          ? coll) where T : notnull    => HasCollection(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      Concurrent.IProducerConsumerCollection<T>             ? coll)                      => HasEnumerable(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.HybridDictionary                          ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.ListDictionary                            ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.NameObjectCollectionBase                  ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.NameObjectCollectionBase.KeysCollection   ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.NameValueCollection                       ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.OrderedDictionary                         ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.StringCollection                          ? coll)                      => HasColl(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.StringDictionary                          ? coll)                      => HasEnumerable_NonGeneric(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.StringEnumerator                          ? coll)                      => Has_StringEnumerator(coll);
    public static bool FilledIn       ([NotNullWhen(true )]      Specialized.IOrderedDictionary                        ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableArray<T>.Builder                             ? coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ImmutableDictionary<T,U>.Builder                      ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ImmutableDictionary<T,U>                              ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableHashSet<T>.Builder                           ? coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableHashSet<T>                                   ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableList<T>.Builder                              ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableList<T>                                      ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableQueue<T>                                     ? coll)                      => HasEnumerable(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ImmutableSortedDictionary<T,U>.Builder                ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ImmutableSortedDictionary<T,U>                        ? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableSortedSet<T>.Builder                         ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableSortedSet<T>                                 ? coll)                      => HasColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableStack<T>                                     ? coll)                      => Has_ImmutableStack(coll);
  //public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableArray<T>.Enumerator                          ? coll)                      => Has_ImmutableArrayEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableArray<T>                                     ? coll)                      => Has_ImmutableArray(ref coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ImmutableDictionary<T,U>.Enumerator                   ? coll) where T : notnull    => HasEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableHashSet<T>.Enumerator                        ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableList<T>.Enumerator                           ? coll)                      => HasEnumerator(coll);
  //public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableQueue<T>.Enumerator                          ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      ImmutableSortedDictionary<T,U>.Enumerator             ? coll) where T : notnull    => HasEnumerator(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableSortedSet<T>.Enumerator                      ? coll)                      => HasEnumerator(coll);
  //public static bool FilledIn<T>    ([NotNullWhen(true )]      ImmutableStack<T>.Enumerator                          ? coll)                      => HasEnumerator(coll);
    public static bool FilledIn<T,U>  ([NotNullWhen(true )]      IImmutableDictionary<T,U>                             ? coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IImmutableList<T>                                     ? coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IImmutableQueue<T>                                    ? coll)                      => HasEnumerable(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IImmutableSet<T>                                      ? coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T>    ([NotNullWhen(true )]      IImmutableStack<T>                                    ? coll)                      => HasEnumerable(coll);

    public static bool Has<T>       ([NotNullWhen(true )]      T[]?                      coll)                      => HasArray(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IEnumerable        <T>?   coll)                      => HasEnumerable(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ICollection        <T>?   coll)                      => HasCollOfT(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IList              <T>?   coll)                      => HasCollOfT(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ISet               <T>?   coll)                      => HasCollOfT(coll);
    public static bool Has<T,U>     ([NotNullWhen(true )]      IDictionary        <T,U>? coll)                      => HasCollOfT(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IReadOnlyList      <T>?   coll)                      => HasReadOnlyColl(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      IReadOnlyCollection<T>?   coll)                      => HasReadOnlyColl(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      List               <T>?   coll)                      => HasColl(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      HashSet            <T>?   coll)                      => HasCollOfT(coll);
    public static bool Has<T,U>     ([NotNullWhen(true )]      Dictionary         <T,U>? coll) where T : notnull    => HasColl(coll);
    public static bool Has<T>       ([NotNullWhen(true )]      ImmutableList      <T>?   coll)                      => HasColl(coll);
                                    
    public static bool IsNully<T>   ([NotNullWhen(false)]      T[]?                      coll)                      => !HasArray(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IEnumerable        <T>?   coll)                      => !HasEnumerable(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ICollection        <T>?   coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IList              <T>?   coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ISet               <T>?   coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)]      IDictionary        <T,U>? coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IReadOnlyList      <T>?   coll)                      => !HasReadOnlyColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      IReadOnlyCollection<T>?   coll)                      => !HasReadOnlyColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      List               <T>?   coll)                      => !HasColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      HashSet            <T>?   coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)]      Dictionary         <T,U>? coll) where T : notnull    => !HasColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)]      ImmutableList      <T>?   coll)                      => !HasColl(coll);
}

public static partial class FilledInExtensions
{
    public static bool FilledIn<T>  ([NotNullWhen(true )] this T[]?                      coll)                      => HasArray(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IEnumerable        <T>?   coll)                      => HasEnumerable(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ICollection        <T>?   coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IList              <T>?   coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ISet               <T>?   coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IReadOnlyList      <T>?   coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this IReadOnlyCollection<T>?   coll)                      => HasReadOnlyColl(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )] this IDictionary        <T,U>? coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this List               <T>?   coll)                      => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this HashSet            <T>?   coll)                      => HasCollOfT(coll);
    public static bool FilledIn<T,U>([NotNullWhen(true )] this Dictionary         <T,U>? coll) where T : notnull    => HasColl(coll);
    public static bool FilledIn<T>  ([NotNullWhen(true )] this ImmutableList      <T>?   coll)                      => HasColl(coll);
  
    public static bool IsNully<T>   ([NotNullWhen(false)] this T[]?                      coll)                      => !HasArray(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IEnumerable        <T>?   coll)                      => !HasEnumerable(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ICollection        <T>?   coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IList              <T>?   coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ISet               <T>?   coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IReadOnlyList      <T>?   coll)                      => !HasReadOnlyColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this IReadOnlyCollection<T>?   coll)                      => !HasReadOnlyColl(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)] this IDictionary        <T,U>? coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this List               <T>?   coll)                      => !HasColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this HashSet            <T>?   coll)                      => !HasCollOfT(coll);
    public static bool IsNully<T,U> ([NotNullWhen(false)] this Dictionary         <T,U>? coll) where T : notnull    => !HasColl(coll);
    public static bool IsNully<T>   ([NotNullWhen(false)] this ImmutableList      <T>?   coll)                      => !HasColl(coll);
}