namespace JJ.Framework.Collections.Core;

public static class StaticEnumerable
{
    /// <inheritdoc cref="Enumerable.Union{T}(IEnumerable{T}, IEnumerable{T})" />
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second) 
        => Enumerable.Union(first, second);

    /// <inheritdoc cref="Enumerable.Union{T}(IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T})" />
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) 
        => Enumerable.Union(first, second, comparer);

    ///// <inheritdoc cref="Enumerable.UnionBy{T, U}(IEnumerable{T}, IEnumerable{T}, Func{T,U})" />
    //public static IEnumerable<TSource> UnionBy<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
    //    => Enumerable.UnionBy(first, second, keySelector);

    ///// <inheritdoc cref="Enumerable.UnionBy{T, U}(IEnumerable{T}, IEnumerable{T}, Func{T,U}, IEqualityComparer{U})" />
    //public static IEnumerable<TSource> UnionBy<TSource, TKey>(IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) 
    //    => Enumerable.UnionBy(first, second, keySelector, comparer);
}