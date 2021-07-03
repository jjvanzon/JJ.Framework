using System;
using System.Collections.Generic;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
    internal static class FuncCache<T>
    {
        private static readonly Dictionary<object, Func<T>> _items = new Dictionary<object, Func<T>>();

        public static bool ContainsKey(object key) => _items.ContainsKey(key);

        public static Func<T> GetItem(object key) => _items[key];

        public static void SetItem(object key, Func<T> value) => _items[key] = value;
    }
}
