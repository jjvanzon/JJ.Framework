namespace JJ.Framework.Mathematics.Legacy;

/// <inheritdoc cref="_randomizerlegacy" />
public static class RandomizerLegacy
{
    private static readonly Random _random = CreateRandom();
        
    private static Random CreateRandom()
    {
        int randomSeed = Guid.NewGuid().GetHashCode();
            
        var random = new Random(randomSeed);
            
        return random;
    }
        
    /// <inheritdoc cref="_getint32" />
    public static int GetInt32() => GetInt32(int.MinValue, int.MaxValue - 1);
        
    /// <inheritdoc cref="_getint32max" />
    public static int GetInt32(int max) => GetInt32(0, max);
        
    /// <inheritdoc cref="_getint32minmax" />
    public static int GetInt32(int min, int max)
    {
        checked
        {
            int result = _random.Next(min, max + 1);
            return result;
        }
    }

    /// <inheritdoc cref="_getdouble" />
    public static double GetDouble() => _random.NextDouble();
        
    /// <inheritdoc cref="_getdoublemax" />
    public static double GetDouble(double max) => GetDouble(0, max);
        
    /// <inheritdoc cref="_getdoubleminmax" />
    public static double GetDouble(double min, double max)
    {
        double between0And1 = GetDouble();
        double range        = max - min;
        double value        = min + between0And1 * range;
        return value;
    }

    /// <inheritdoc cref="_getsingle" />
    public static float GetSingle() => (float)_random.NextDouble();

    /// <inheritdoc cref="_getsinglemax" />
    public static float GetSingle(float max) => GetSingle(0, max);
        
    /// <inheritdoc cref="_getsingleminmax" />
    public static float GetSingle(float min, float max)
    {
        float between0And1 = GetSingle();
        float range        = max - min;
        float value        = min + between0And1 * range;
        return value;
    }
    
    /// <inheritdoc cref="_getrandomitem" />
    public static T GetRandomItem<T>(params IEnumerable<T> collection)
    {
        // ReSharper disable once PossibleMultipleEnumeration
        int count = collection.Count();
        if (count == 0)
        {
            throw new Exception("collection.Count() == 0");
        }

        int index = GetInt32(count - 1);
        // ReSharper disable once PossibleMultipleEnumeration
        return collection.ElementAt(index);
    }

    /// <inheritdoc cref="_trygetrandomitem" />
    public static T? TryGetRandomItem<T>(IEnumerable<T>? collection) 
        where T : struct
    {
        if (collection == null) return null;

        // ReSharper disable once PossibleMultipleEnumeration
        int count = collection.Count();
        if (count == 0)
        {
            return null;
        }

        int index = GetInt32(count - 1);
        // ReSharper disable once PossibleMultipleEnumeration
        return collection.ElementAt(index);
    }

    /// <inheritdoc cref="_trygetrandomitem" />
    public static T? TryGetRandomItem<T>(IEnumerable<T?>? collection) 
        where T : struct
    {
        if (collection == null) return null;

        // ReSharper disable once PossibleMultipleEnumeration
        int count = collection.Count();
        if (count == 0)
        {
            return null;
        }

        int index = GetInt32(count - 1);
        // ReSharper disable once PossibleMultipleEnumeration
        return collection.ElementAt(index);
    }

    /// <inheritdoc cref="_trygetrandomitem" />
    public static T? TryGetRandomItem<T>(IEnumerable<T?>? collection, T? _ = null) 
        where T : class
    {
        if (collection == null) return null;

        // ReSharper disable once PossibleMultipleEnumeration
        int count = collection.Count();
        if (count == 0)
        {
            return null;
        }

        int index = GetInt32(count - 1);
        // ReSharper disable once PossibleMultipleEnumeration
        return collection.ElementAt(index);
    }
}
