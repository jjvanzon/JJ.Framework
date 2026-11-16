// ReSharper disable InvokeAsExtensionMember
namespace JJ.Framework.Collections.Legacy;

/// <inheritdoc cref="_staticenumerableex" />
public static class StaticEnumerableEx
{
    /// <inheritdoc cref="Enumerable.Union{T}(IEnumerable{T}, IEnumerable{T})" />
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second) 
        => Enumerable.Union(first, second);

    /// <inheritdoc cref="Enumerable.Union{T}(IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T})" />
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) 
        => Enumerable.Union(first, second, comparer);
}