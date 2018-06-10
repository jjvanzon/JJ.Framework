using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
// ReSharper disable UnusedVariable

namespace JJ.Demos.ReflectionCache.Tests
{
    public static class HisTests
    {
        public static void Execute()
        {
            const int iterations = 1000;

            Console.WriteLine();

            Console.WriteLine("His Tests Comparing Property Get Methods");

            long direct = TestGetPropertiesDirect(iterations);
            long cached = TestGetPropertiesCached(iterations);

            Console.WriteLine(
                "Cached access is {0} times faster than reflection access",
                direct / (double)cached);
        }

        private static long TestGetPropertiesDirect(int iterations)
        {
            Console.WriteLine("TestGetPropertiesDirect...");

            Type[] types = GetTestTypes();
            var gets = 0;

            Stopwatch sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                foreach (Type type in types)
                {
                    PropertyInfo[] properties = type.GetProperties();
                    gets++;
                }
            }

            sw.Stop();

            Console.WriteLine("type.GetProperties(): {0} ms / {1}x", sw.ElapsedMilliseconds, gets);

            return sw.ElapsedMilliseconds;
        }

        private static long TestGetPropertiesCached(int iterations)
        {
            Console.WriteLine("TestGetPropertiesCached...");

            Type[] types = GetTestTypes();
            var gets = 0;

            Stopwatch sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                foreach (Type type in types)
                {
                    PropertyInfo[] properties = GetCachedProperties(type);
                    gets++;
                }
            }

            sw.Stop();

            Console.WriteLine("ReflectionCache.GetProperties(): {0} ms / {1}x", sw.ElapsedMilliseconds, gets);

            return sw.ElapsedMilliseconds;
        }

        // Caching

        //private static ReflectionCache_Adapted _cache = new ReflectionCache_Adapted(BindingFlags.Public | BindingFlags.Instance);

        private static readonly Dictionary<Type, PropertyInfo[]> _propertyDictionary =
            new Dictionary<Type, PropertyInfo[]>();

        private static readonly object _propertyDictionaryLock = new object();

        private static PropertyInfo[] GetCachedProperties(Type type)
        {
            //return _cache.GetProperties(type);

            lock (_propertyDictionaryLock)
            {
                if (_propertyDictionary.TryGetValue(type, out PropertyInfo[] properties) == false)
                {
                    properties = type.GetProperties();
                    _propertyDictionary.Add(type, properties);
                }

                return properties;
            }
        }

        /// <summary>
        /// Returns a list of types to use for the subsequent tests
        /// </summary>
        private static Type[] GetTestTypes() => typeof(string).Assembly.GetTypes();
    }
}