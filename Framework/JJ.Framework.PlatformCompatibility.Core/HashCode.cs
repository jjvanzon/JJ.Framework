namespace System;

#if NETSTANDARD2_0
public struct HashCode
{
    
    private const int PRIME_LIKE_SEED = -2128831035; // same bits as 0x811C9DC5
    private const int PRIME_MULTIPLIER = 16777619;

    public static int Combine<T1>(T1 v1) => v1?.GetHashCode() ?? 0;

    public static int Combine<T1, T2>(T1 v1, T2 v2)
    {
        unchecked
        {
            int h = PRIME_LIKE_SEED;
            h = (h ^ v1?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v2?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            return h;
        }
    }

    public static int Combine<T1, T2, T3>(T1 v1, T2 v2, T3 v3)
    {
        unchecked
        {
            int h = PRIME_LIKE_SEED;
            h = (h ^ v1?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v2?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v3?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            return h;
        }
    }

    public static int Combine<T1, T2, T3, T4>(T1 v1, T2 v2, T3 v3, T4 v4)
    {
        unchecked
        {
            int h = PRIME_LIKE_SEED;
            h = (h ^ v1?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v2?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v3?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v4?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            return h;
        }
    }

    public static int Combine<T1, T2, T3, T4, T5>(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5)
    {
        unchecked
        {
            int h = PRIME_LIKE_SEED;
            h = (h ^ v1?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v2?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v3?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v4?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v5?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            return h;
        }
    }

    public static int Combine<T1, T2, T3, T4, T5, T6>(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6)
    {
        unchecked
        {
            int h = PRIME_LIKE_SEED;
            h = (h ^ v1?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v2?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v3?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v4?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v5?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v6?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            return h;
        }
    }

    public static int Combine<T1, T2, T3, T4, T5, T6, T7>(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6, T7 v7)
    {
        unchecked
        {
            int h = PRIME_LIKE_SEED;
            h = (h ^ v1?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v2?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v3?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v4?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v5?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v6?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v7?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            return h;
        }
    }

    public static int Combine<T1, T2, T3, T4, T5, T6, T7, T8>(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6, T7 v7, T8 v8)
    {
        unchecked
        {
            int h = PRIME_LIKE_SEED;
            h = (h ^ v1?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v2?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v3?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v4?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v5?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v6?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v7?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            h = (h ^ v8?.GetHashCode() ?? 0) * PRIME_MULTIPLIER;
            return h;
        }
    }
}
#endif
