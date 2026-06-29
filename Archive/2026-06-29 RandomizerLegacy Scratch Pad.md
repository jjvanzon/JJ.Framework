```cs

    // TODO: Only differentiate between get and tryget tests where behavior is different, not where it is synonymous?}

    ///// <inheritdoc cref="_trygetrandomitem" />
    //public static T? TryGetRandomItem<T>(params IEnumerable<T>? collection) 
    //    where T : struct
    //{
    //    if (collection == null) return null;
    //
    //    // ReSharper disable once PossibleMultipleEnumeration
    //    int count = collection.Count();
    //    if (count == 0)
    //    {
    //        return null;
    //    }
    //
    //    int index = GetInt32(count - 1);
    //    // ReSharper disable once PossibleMultipleEnumeration
    //    return collection.ElementAt(index);
    //}
```