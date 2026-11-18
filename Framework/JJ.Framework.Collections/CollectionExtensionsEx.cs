// ReSharper disable ConvertToExtensionBlock

namespace JJ.Framework.Collections.Legacy;

/// <inheritdoc cref="_collectionextensionsex" />
public static class CollectionExtensionsEx
{
    /// <inheritdoc cref="_addwithparams" />
    public static void Add<T>(this ICollection<T> collection, params IEnumerable<T> items)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (items == null) throw new ArgumentNullException(nameof(items));
           
        foreach (var x in items)
        {
            collection.Add(x);
        }
    }

    /// <inheritdoc cref="_addrange" />
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (items == null) throw new ArgumentNullException(nameof(items));
            
         foreach (var x in items)
         {
             collection.Add(x);
         }
    }

    /// <summary> Overload of <c>Concat</c> that takes a single item, e.g. <c>myCollection.Concat(myItem);</c></summary>
    public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, T second) => first.Concat(new[] { second });
        
    /// <summary>
    /// Overload of <c>Concat</c> that starts with a single item and then adds a collection to it e.g.
    /// <c>myItem.Concat(myCollection);</c>
    /// </summary>
    public static IEnumerable<T> Concat<T>(this T first, IEnumerable<T> second) => new[] { first }.Concat(second);

    /// <summary>
    /// Variant of <c>Distinct</c> that takes a key selector that determines what makes an item unique, for example: <br/>
    /// <c>myItems.Distinct(x => x.LastName);</c> <br/>
    /// For multi-part keys, use: <br/>
    /// <c>myItems.Distinct(x => new { x.FirstName, x.LastName });</c>
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
    /// Variant of <c>Except</c> taking a predicate, e.g. <br />
    /// <c>myCollection.Except(x =&gt; string.Equals(x, "Blah"));</c> <br />
    /// (This is the same as a negated <c>Where</c> predicate, but if you are already thinking in terms of <c>Except</c>,
    /// this might better express your intent.)
    /// </summary>
    public static IEnumerable<T> Except<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        return source.Where(x => !predicate(x));
    }
    
    /// <inheritdoc cref="_foreachwithindex" />       
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
    {
        if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
        if (action == null) throw new ArgumentNullException(nameof(action));

        int i = 0;
        foreach (var x in enumerable)
        {
            action(x, i++);
        }
    }

    /// <summary>
    /// Non-generic variant of <c>OfType&lt;T&gt;</c> taking a <c>Type</c> as a parameter.<br/>
    /// It sacrifices automatic casts of items to the desired type.
    /// Still this may be useful for certain non-generic scenarios.
    /// </summary>
    public static IEnumerable<TSource> OfType<TSource>(this IEnumerable<TSource> source, Type type)
    {
        if (type == null) throw new ArgumentNullException(nameof(type));
        return source.Where(x => x?.GetType() == type);
    }

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
    
    /// <inheritdoc cref="_removerange" />
    public static void RemoveRange<T>(this ICollection<T> dest, params IEnumerable<T> source)
    {
        if (dest == null) throw new ArgumentNullException(nameof(dest));
        if (source == null) throw new ArgumentNullException(nameof(source));

        foreach (T item in source)
        {
            dest.Remove(item);
        }
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
}