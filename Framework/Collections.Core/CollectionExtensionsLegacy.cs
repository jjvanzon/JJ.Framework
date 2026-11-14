namespace JJ.Framework.Collections.Core;

public static class CollectionExtensionsLegacy
{
    /// <inheritdoc cref="_onebecomestwo" />
    public static IList<T> OneBecomesTwo<T>(this IList<T> list)
    {
        if (list       == null) throw new ArgumentNullException(nameof(list));
        if (list.Count == 1) list = new List<T> { list[0], list[0] };
        return list;
    }
        
    /// <inheritdoc cref="_onebecomestwo" />
    public static T[] OneBecomesTwo<T>(this T[] list) => OneBecomesTwo((IList<T>)list).ToArray();

    /// <inheritdoc cref="_product" />
    public static double Product<TSource>(this IEnumerable<TSource> collection, Func<TSource, double> selector)
        => collection.Select(selector).Product();

    /// <inheritdoc cref="_product" />
    public static double Product(this IEnumerable<double> collection)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
            
        var array = collection as double[] ?? collection.ToArray();
            
        if (array.Length == 0) return 1;
            
        var product = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            product *= array[i];
        }
            
        return product;
    }

    /// <inheritdoc cref="_product" />
    public static float Product<TSource>(this IEnumerable<TSource> collection, Func<TSource, float> selector)
        => collection.Select(selector).Product();

    /// <inheritdoc cref="_product" />
    public static float Product(this IEnumerable<float> collection)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        var array = collection as float[] ?? collection.ToArray();

        if (array.Length == 0) return 1;

        var product = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }

    /// <inheritdoc cref="_product" />
    public static int Product<TSource>(this IEnumerable<TSource> collection, Func<TSource, int> selector)
        => collection.Select(selector).Product();

    /// <inheritdoc cref="_product" />
    public static int Product(this IEnumerable<int> collection)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        var array = collection as int[] ?? collection.ToArray();

        if (array.Length == 0) return 1;

        var product = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }

    /// <inheritdoc cref="_product" />
    public static long Product<TSource>(this IEnumerable<TSource> collection, Func<TSource, long> selector)
        => collection.Select(selector).Product();

    /// <inheritdoc cref="_product" />
    public static long Product(this IEnumerable<long> collection)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        var array = collection as long[] ?? collection.ToArray();

        if (array.Length == 0) return 1;

        var product = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }

    /// <inheritdoc cref="_product" />
    public static decimal Product<TSource>(this IEnumerable<TSource> collection, Func<TSource, decimal> selector)
        => collection.Select(selector).Product();

    /// <inheritdoc cref="_product" />
    public static decimal Product(this IEnumerable<decimal> collection)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        var array = collection as decimal[] ?? collection.ToArray();

        if (array.Length == 0) return 1;

        var product = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }
     
    /// <inheritdoc cref="_sumoftimespan" />
    
    public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
    {
        if (timeSpans == null) throw new ArgumentNullException(nameof(timeSpans));
        return timeSpans.Aggregate((x, y) => x + y);
    }
       
    /// <inheritdoc cref="_sumoftimespan" />
    public static TimeSpan Sum<T>(this IEnumerable<T> source, Func<T, TimeSpan> selector)
    {
        return source.Select(selector).Sum();
    }

    /// <summary>
    /// Distinct that takes a key selector that determines what makes an item unique, e.g. myItems.Distinct(x => x.LastName);
    /// For multi-part as keys, use `myItems.Distinct(x => new { x.FirstName, x.LastName });`
    /// </summary>
    public static IEnumerable<TItem> Distinct<TItem, TKey>(this IEnumerable<TItem> enumerable, Func<TItem, TKey> keySelector)
    {
        if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
        if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

        var hashSet = new HashSet<TKey>();

        foreach (TItem item in enumerable)
        {
            TKey key = keySelector(item);

            if (hashSet.Add(key))
            {
                yield return item;
            }
        }
    }
    
    /// <summary>
    /// Similar to OfType&lt;T&gt; but now taking a Type.
    /// This misses the advantage of automatically casting items to the desired type.
    /// Still this may be useful for certain cases.
    /// </summary>
    public static IEnumerable<TSource> OfType<TSource>(this IEnumerable<TSource> source, Type type)
    {
        if (type == null) throw new ArgumentNullException(nameof(type));
        return source.Where(x => x?.GetType() == type);
    }

    /// <summary> Overload of Concat that takes a single item, e.g. myCollection.Concat(myItem); </summary>
    public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, T second) => first.Concat(new[] { second });
        
    /// <summary>
    /// Overload of Concat that starts with a single item and then adds a collection to it e.g.
    /// myItem.Concat(myCollection);
    /// </summary>
    public static IEnumerable<T> Concat<T>(this T first, IEnumerable<T> second) => new[] { first }.Concat(second);

    /// <summary>
    /// An overload of Except that takes a predicate, e.g. myCollection.Except(x => string.Equals("Blah");
    /// (This is the same as a negated Where predicate, but if you are already thinking in terms of Except,
    /// this might express your intent clearer.)
    /// </summary>
    public static IEnumerable<T> Except<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        return source.Where(x => !predicate(x));
    }
}