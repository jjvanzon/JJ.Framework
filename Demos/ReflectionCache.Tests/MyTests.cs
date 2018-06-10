using System;
using System.Diagnostics;
using System.Reflection;
// ReSharper disable UnusedVariable

namespace JJ.Demos.ReflectionCache.Tests
{
    public class MyTests
    {
        public static void Execute()
        {
            const int iterations = 1000;

            Console.WriteLine();

            Console.WriteLine("My Tests Comparing Property Get Methods");

            long direct = TestGetPropertiesDirect(iterations);
            long cached = TestGetPropertiesCached(iterations);

            Console.WriteLine(
                "Cached access is {0} times faster than reflection access",
                direct / (double)cached);

            TestGetPropertiesCachedAndDirectInOneMethod(iterations);
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
                    //PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
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

        private static readonly ReflectionCache_Adapted _cache = new ReflectionCache_Adapted(BindingFlags.Public | BindingFlags.Instance);

        //private static Dictionary<Type, PropertyInfo[]> _propertyDictionary =
        //		   new Dictionary<Type, PropertyInfo[]>();

        //private static object _propertyDictionaryLock = new object();

        private static PropertyInfo[] GetCachedProperties(Type type) => _cache.GetProperties(type);

        /// <summary>
        /// Returns a list of types to use for the subsequent tests
        /// </summary>
        private static Type[] GetTestTypes() => typeof(string).Assembly.GetTypes();

        private static void TestGetPropertiesCachedAndDirectInOneMethod(int iterations)
        {
            Type[] types = GetTestTypes();

            Stopwatch cacheStopwatch = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                foreach (Type type in types)
                {
                    PropertyInfo[] properties = _cache.GetProperties(type);
                }
            }

            cacheStopwatch.Stop();

            types = GetTestTypes();

            Stopwatch directStopwatch = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                foreach (Type type in types)
                {
                    //PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo[] properties = type.GetProperties();
                }
            }

            directStopwatch.Stop();

            Console.WriteLine(
                "TestGetPropertiesCachedAndDirectInOneMethod: cached is {0:0.0#} times faster",
                directStopwatch.ElapsedTicks / (double)cacheStopwatch.ElapsedTicks);
        }
    }
}