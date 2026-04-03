// ReSharper disable MethodOverloadWithOptionalParameter

namespace JJ.Framework.Existence.Core;

/// <inheritdoc cref="_coalesce"/>
public static class CoalesceObjectExtensions
{
    // [Prio] attributes:
    // These overloads clash: first.Coalesce(others), List.Coalesce(), and string.Coalesce().
    // Prio(1) on IEnumerable<T> for List.Coalesce() else List becomes the first arg in (first, others).
    // Prio(2) on string.Coalesce() makes it win over IEnumerable<char> in string-specific calls.

    // 3 Args

    /// <inheritdoc cref="_coalesce" />
    public static string Coalesce(this object? obj, object? fallback, string? fallback2) => CoalesceObjectToText(obj, CoalesceObjectToText(fallback, fallback2));

    // N Args

    // Thjese serve both objects and values. Unable to create separate overloads for each.

    /// <inheritdoc cref="_coalesce" />
    [Prio(1)] public static T Coalesce<T>(this IEnumerable<T?>? fallbacks) where T : new() => CoalesceManyObjects(fallbacks);

    /// <inheritdoc cref="_coalesce" />
    public static T Coalesce<T>(this T? first, params IEnumerable<T?>? fallbacks) where T : new() => CoalesceManyObjects(new[] { first }.Concat(fallbacks ?? []));
}