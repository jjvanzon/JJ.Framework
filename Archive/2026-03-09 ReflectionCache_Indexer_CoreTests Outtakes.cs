        ReflectionCache_Indexer_CoreTests_GenericOverload.Untrim();

    internal static void Untrim()
    {
        // Statically reference indexer getters so the linker preserves them.
        var func1 = (Func<HelperClass, long, int>)((h, a) => h[a]);
        var func2 = (Func<HelperClass, long, float, int>)((h, a, b) => h[a, b]);
        var func3 = (Func<HelperClass, long, float, short, int>)((h, a, b, c) => h[a, b, c]);
        var func4 = (Func<HelperClass, long, float, short, byte, int>)((h, a, b, c, d) => h[a, b, c, d]);
        var func5 = (Func<HelperClass, long, float, short, byte, char, int>)((h, a, b, c, d, e) => h[a, b, c, d, e]);
        var func6 = (Func<HelperClass, long, float, short, byte, char, decimal, int>)((h, a, b, c, d, e, f) => h[a, b, c, d, e, f]);
        var func7 = (Func<HelperClass, long, float, short, byte, char, decimal, bool, int>)((h, a, b, c, d, e, f, g) => h[a, b, c, d, e, f, g]);
    }
