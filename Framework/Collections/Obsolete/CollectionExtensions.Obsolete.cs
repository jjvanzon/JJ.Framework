namespace JJ.Framework.Collections.Obsolete;

public static class CollectionExtensions
{
    private const string USE_SYSTEM_LINQ_MESSAGE = "Use the version from System.Linq instead.";

    [Obsolete(USE_SYSTEM_LINQ_MESSAGE, true)]
    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        => throw new NotSupportedException(USE_SYSTEM_LINQ_MESSAGE);
}
