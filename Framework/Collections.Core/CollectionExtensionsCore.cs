namespace JJ.Framework.Collections.Core;

public static class CollectionExtensionsCore
{
    // TODO: Port to legacy from here.

    /// <summary> AddRange is a member of List&lt;T&gt;. Here is an overload for ICollection&lt;T&gt;. </summary>
    public static void RemoveRange<T>(this ICollection<T> dest, IEnumerable<T> source)
    {
        if (dest == null) throw new ArgumentNullException(nameof(dest));
        if (source == null) throw new ArgumentNullException(nameof(source));

        foreach (T item in source)
        {
            dest.Remove(item);
        }
    }
}